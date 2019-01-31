using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryDiagnostics
{
    //https://github.com/Microsoft/clrmd/blob/master/Documentation/ClrRuntime.md
    public partial class MainForm : Form
    {
        List<Snapshot> Snapshots = new List<Snapshot>();
        Process process;
        int snapshotPosition = 0;
        uint dataTargetTimeOut = 10000;
        AttachFlag dataTargetAttachFlag = AttachFlag.NonInvasive;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(string[] args)
        {
            InitializeComponent();

            if (args.Length > 0)
                textBoxProcessFilter.Text = args[0];

            if (args.Length > 1)
                textBoxObjectFilter.Text = args[1];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NextSnapshot();
        }

        private void NextSnapshot()
        {
            List<Process> allProcesses = Process.GetProcesses().Where(p => p.ProcessName.Contains(textBoxProcessFilter.Text.Trim())).ToArray().ToList();
            process = allProcesses.FirstOrDefault(p => !p.ProcessName.Contains("vshost"));//avoid VisualStudio Host Process
            if (process == null)
                process = allProcesses.FirstOrDefault();

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CreateManagedObjects();
                Cursor.Current = Cursors.Default;
            }
            catch (NullReferenceException ex)
            {
                this.Text = "Process not found: " + textBoxProcessFilter.Text.Trim();
            }
            catch (Exception ex)
            {
                if (ex is ClrDiagnosticsException && process != null)
                    MessageBox.Show("This tool have to be compiled for the same architecture as the aimed process " + process.ProcessName + " (32/64bit)", ex.Message);
                this.Text = ex.Message;
            }
        }

        private void CreateManagedObjects()
        {
            using (DataTarget dataTarget = DataTarget.AttachToProcess(process.Id, dataTargetTimeOut, dataTargetAttachFlag))
            {
                ClrInfo clrVersion = dataTarget.ClrVersions.First();
                ClrRuntime runtime = clrVersion.CreateRuntime();
                Snapshot snapshot = new Snapshot() { MemoryPrivateBytes = process.PrivateMemorySize64, Date = DateTime.Now, Position = Snapshots.Count };
                Snapshots.Add(snapshot);
                snapshotPosition = Snapshots.Count - 1;
                snapshot.Comment = snapshotPosition + ". Snapshot Comment: ";
                richTextBoxComment.Text = snapshot.Comment;
                CollectMemory(runtime, snapshot);
                snapshot.ManagedObjectDic = ListObjects(runtime);
                RefreshSnapshotGrid(snapshot);
            }
        }

        private void RefreshSnapshotGrid(Snapshot selectedSnapshot)
        {
            bindingSourceSnapshot.DataSource = null;
            bindingSourceSnapshot.DataSource = Snapshots;

            Regular.Visible = Snapshots.Sum(x => (long)x.MemoryRegular) > 0;
            Reserved.Visible = Snapshots.Sum(x => (long)x.MemoryReserved) > 0;

            if (Snapshots.Count > 1)
                CompareSnapshotsAndDisplay(selectedSnapshot, Snapshots[Snapshots.Count - 2]);
            else
                CompareSnapshotsAndDisplay(selectedSnapshot, selectedSnapshot);

            dataGridViewSnapshot.ClearSelection();
            dataGridViewSnapshot.Rows[snapshotPosition].Selected = true;
            splitContainerMain.SplitterDistance = dataGridViewSnapshot.Columns.Cast<DataGridViewColumn>().Where(x => x.Visible).Sum(x => x.Width) + 6;
        }

        Snapshot snapshot1Current;
        Snapshot snapshot2Current;
        private void CompareSnapshotsAndDisplay(Snapshot snapshot1, Snapshot snapshot2)
        {
            if (snapshot1 == null || snapshot2 == null)
                return;

            snapshot1Current = snapshot1;
            snapshot2Current = snapshot2;
            snapshotPosition = Snapshots.FindIndex(x => x.Date == snapshot1Current.Date);
            int snapshotPosition2 = Snapshots.FindIndex(x => x.Date == snapshot2Current.Date);

            SortableBindingList<ManagedObject> managedObjectsCompare = CompareSnapshots(snapshot1, snapshot2, textBoxObjectFilter.Text.Trim(), checkBoxChange.Checked);
            bindingSourceMain.DataSource = managedObjectsCompare;

            this.Text = String.Format("{0}. Snapshot compared with {2}., {1:n0} KB (private bytes)", snapshotPosition, snapshot1Current.MemoryPrivateBytes / 1024, snapshotPosition2);
        }

        private SortableBindingList<ManagedObject> CompareSnapshots(Snapshot snapshot1, Snapshot snapshot2, string filter, Boolean? onlyChangedFilter)
        {
            if (snapshot1 == null || snapshot2 == null)
                return null;

            SortableBindingList<ManagedObject> managedObjectsCompare = new SortableBindingList<ManagedObject>();

            foreach (ManagedObject mo in snapshot1.ManagedObjectDic.Values)
            {
                if (filter.Length != 0 && !mo.ObjectName.Contains(filter))
                    continue;

                if (snapshot2.ManagedObjectDic.ContainsKey(mo.ObjectName))
                    mo.ObjectCountLastHelper = snapshot2.ManagedObjectDic[mo.ObjectName].ObjectCount;

                if ((!onlyChangedFilter.HasValue || !onlyChangedFilter.Value || mo.ObjectChange > 0)
                    && (typeFilter.Count == 0 || typeFilter.Contains(mo.ObjectName)))
                    managedObjectsCompare.Add(mo);
            }

            if (!onlyChangedFilter.HasValue || !onlyChangedFilter.Value)
                foreach (ManagedObject mo in snapshot2.ManagedObjectDic.Values)
                {
                    if (filter.Length != 0 && !mo.ObjectName.Contains(filter))
                        continue;

                    if (!snapshot1.ManagedObjectDic.ContainsKey(mo.ObjectName)
                        && (typeFilter.Count == 0 || typeFilter.Contains(mo.ObjectName)))
                    {
                        ManagedObject fakeObjekt = new ManagedObject()
                        {
                            ObjectCountLastHelper = mo.ObjectCount,
                            ObjectName = mo.ObjectName,
                            ObjectSize = mo.ObjectSize,
                            ObjectCount = 0
                        };

                        managedObjectsCompare.Add(fakeObjekt);
                    }
                }

            return managedObjectsCompare;
        }

        private static void CollectMemory(ClrRuntime runtime, Snapshot s)
        {
            foreach (ClrMemoryRegion r in runtime.EnumerateMemoryRegions())
            {
                if (r.Type == ClrMemoryRegionType.GCSegment)
                {
                    if (r.GCSegmentType == GCSegmentType.Ephemeral)
                        s.MemoryEphemeral += r.Size;

                    if (r.GCSegmentType == GCSegmentType.LargeObject)
                        s.MemoryLargeObject += r.Size;

                    if (r.GCSegmentType == GCSegmentType.Regular)
                        s.MemoryRegular += r.Size;
                }
                else if (r.Type == ClrMemoryRegionType.ReservedGCSegment)
                {
                    s.MemoryReserved += r.Size;
                }
                else
                {
                    s.MemoryOther += r.Size;
                }
            }
        }

        private static SortedDictionary<string, ManagedObject> ListObjects(ClrRuntime runtime)
        {
            SortedDictionary<String, ManagedObject> managedObjects = new SortedDictionary<string, ManagedObject>();

            if (runtime.Heap.CanWalkHeap)
            {
                foreach (ulong ptr in runtime.Heap.EnumerateObjectAddresses())
                {
                    ClrType type = runtime.Heap.GetObjectType(ptr);

                    //Free objects are not real objects in the strictest sense. They are actually markers placed by the GC to 
                    //denote free space on the heap. Free objects have no fields (though they do have a size). In general, if 
                    //you are trying to find heap fragmentation, you will need to take a look at how many Free objects there are, 
                    //how big they are, and what lies between them. Otherwise, you should ignore them.
                    //https://github.com/Microsoft/clrmd/blob/master/Documentation/TypesAndFields.md
                    if (type == null || type.IsFree)
                        continue;

                    ManagedObject mo = null;
                    if (!managedObjects.ContainsKey(type.Name))
                    {
                        mo = new ManagedObject()
                        {
                            ObjectName = type.Name
                        };
                        managedObjects.Add(type.Name, mo);
                    }

                    if (mo == null)
                        mo = managedObjects[type.Name];

                    mo.ObjectCount++;
                    mo.ObjectSize += type.GetSize(ptr);

                }
            }
            return managedObjects;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            NextSnapshot();
        }

        private void CompareWithThisSnapshot()
        {
            if (dataGridViewSnapshot.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewSnapshot.SelectedRows[0];
                Snapshot s = row.DataBoundItem as Snapshot;

                if (s != null && Snapshots.Count > 0)
                    CompareSnapshotsAndDisplay(snapshot1Current, s);
            }
        }

        private void checkBoxChange_CheckedChanged(object sender, EventArgs e)
        {
            CompareSnapshotsAndDisplay(snapshot1Current, snapshot2Current);
        }

        private void textBoxObjectFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CompareSnapshotsAndDisplay(snapshot1Current, snapshot2Current);
        }

        private void dataGridViewSnapshot_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Snapshot snapshot = dataGridViewSnapshot.Rows[e.RowIndex].DataBoundItem as Snapshot;
            if (snapshot == null)
                return;

            dataGridViewSnapshot.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = Snapshots[e.RowIndex].Comment;

            int index = Snapshots.FindIndex(x => x.Date == snapshot.Date);

            Snapshot snapshotPrev = null;
            if (index > 0)
                snapshotPrev = Snapshots[index - 1];

            if (snapshotPrev == null)
                return;

            if (dataGridViewSnapshot.Columns[e.ColumnIndex].Name.Equals("PrivateBytes"))
            {
                if (snapshotPrev.MemoryPrivateBytes > snapshot.MemoryPrivateBytes)
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.SelectionBackColor = Color.DarkGreen;
                }
                else if (snapshotPrev.MemoryPrivateBytes < snapshot.MemoryPrivateBytes)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                }
            }

            if (dataGridViewSnapshot.Columns[e.ColumnIndex].Name.Equals("MemoryEphemeral"))
            {
                if (snapshotPrev.MemoryEphemeral > snapshot.MemoryEphemeral)
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.SelectionBackColor = Color.DarkGreen;
                }
                else if (snapshotPrev.MemoryEphemeral < snapshot.MemoryEphemeral)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                }
            }

            if (dataGridViewSnapshot.Columns[e.ColumnIndex].Name.Equals("MemoryLargeObject"))
            {
                if (snapshotPrev.MemoryLargeObject > snapshot.MemoryLargeObject)
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.SelectionBackColor = Color.DarkGreen;
                }
                else if (snapshotPrev.MemoryLargeObject < snapshot.MemoryLargeObject)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                }
            }

            if (dataGridViewSnapshot.Columns[e.ColumnIndex].Name.Equals("Regular"))
            {
                if (snapshotPrev.MemoryRegular > snapshot.MemoryRegular)
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.SelectionBackColor = Color.DarkGreen;
                }
                else if (snapshotPrev.MemoryRegular < snapshot.MemoryRegular)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                }
            }

            if (dataGridViewSnapshot.Columns[e.ColumnIndex].Name.Equals("Reserved"))
            {
                if (snapshotPrev.MemoryReserved > snapshot.MemoryReserved)
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.SelectionBackColor = Color.DarkGreen;
                }
                else if (snapshotPrev.MemoryReserved < snapshot.MemoryReserved)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                }
            }

            if (dataGridViewSnapshot.Columns[e.ColumnIndex].Name.Equals("Other"))
            {
                if (snapshotPrev.MemoryOther > snapshot.MemoryOther)
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.SelectionBackColor = Color.DarkGreen;
                }
                else if (snapshotPrev.MemoryOther < snapshot.MemoryOther)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                }
            }

            if (dataGridViewSnapshot.Columns[e.ColumnIndex].Name.Equals("ObjectAllCount"))
            {
                if (snapshotPrev.ObjectCount > snapshot.ObjectCount)
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.SelectionBackColor = Color.DarkGreen;
                }
                else if (snapshotPrev.ObjectCount < snapshot.ObjectCount)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                }
            }
        }

        private void compareWithThisSnapshotDoubleClickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompareWithThisSnapshot();
        }

        private void dataGridViewSnapshot_DoubleClick(object sender, EventArgs e)
        {
            selectThisSnapshot();
        }

        private void selectThisSnapshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectThisSnapshot();
        }

        private void selectThisSnapshot()
        {
            if (dataGridViewSnapshot.SelectedRows.Count > 0)
            {
                Snapshots[snapshotPosition].Comment = richTextBoxComment.Text;
                Snapshot selected = dataGridViewSnapshot.SelectedRows[0].DataBoundItem as Snapshot;
                snapshotChange = true;
                richTextBoxComment.Text = selected.Comment;
                snapshotChange = false;
                if (selected != null)
                {
                    snapshotPosition = Snapshots.FindIndex(x => x.Date == selected.Date);

                    if (snapshotPosition >= 1)
                        snapshot2Current = Snapshots[snapshotPosition - 1];
                    else
                        snapshot2Current = Snapshots[0];

                    CompareSnapshotsAndDisplay(selected, snapshot2Current);
                }
            }
        }

        private void deleteThisSnapshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewSnapshot.SelectedRows.Count > 0)
            {
                Snapshot selected = dataGridViewSnapshot.SelectedRows[0].DataBoundItem as Snapshot;
                int index = Snapshots.FindIndex(x => x.Date == selected.Date);
                Snapshots.RemoveAt(index);
                bindingSourceSnapshot.DataSource = null;
                bindingSourceSnapshot.DataSource = Snapshots;
            }
        }

        private void dataGridViewSnapshot_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dataGridViewSnapshot.HitTest(e.X, e.Y);
                if (hti.RowIndex >= 0)
                {
                    dataGridViewSnapshot.ClearSelection();
                    dataGridViewSnapshot.Rows[hti.RowIndex].Selected = true;
                }
            }
        }

        private void filterForSelectedTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewMain.SelectedRows)
            {
                ManagedObject m = row.DataBoundItem as ManagedObject;
                if (m != null)
                    typeFilter.Add(m.ObjectName);
            }
            CompareSnapshotsAndDisplay(snapshot1Current, snapshot2Current);
        }

        List<string> typeFilter = new List<string>();
        private void clearFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            typeFilter.Clear();
            CompareSnapshotsAndDisplay(snapshot1Current, snapshot2Current);
        }

        private void copyObjectNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.SelectedRows.Count > 0)
            {
                ManagedObject m = dataGridViewMain.SelectedRows[0].DataBoundItem as ManagedObject;
                if (m != null)
                    Clipboard.SetText(m.ObjectName);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Snapshots.Count == 0)
                return;

            saveFileDialogSnapshot.FileName = String.Format("clrmd_{0:yyyyMMdd_HHmmss}", Snapshots.Count > 0 ? Snapshots[0].Date : DateTime.Now);
            if (saveFileDialogSnapshot.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (FileStream writerFileStream = new FileStream(saveFileDialogSnapshot.FileName, FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(writerFileStream, Snapshots);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialogSnapshot.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (FileStream readerFileStream = new FileStream(openFileDialogSnapshot.FileName, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Snapshots = (List<Snapshot>)formatter.Deserialize(readerFileStream);
                    if (Snapshots.Count > 0)
                        RefreshSnapshotGrid(Snapshots[Snapshots.Count - 1]);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool snapshotChange = false;
        private void richTextBoxComment_TextChanged(object sender, EventArgs e)
        {
            if (Snapshots.Count > 0 && !snapshotChange)
                Snapshots[snapshotPosition].Comment = richTextBoxComment.Text;
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            if (Snapshots.Count == 0)
                return;

            saveFileDialogReport.FileName = String.Format("clrmd_{0:yyyyMMdd_HHmmss}", Snapshots.Count > 0 ? Snapshots[0].Date : DateTime.Now);
            if (saveFileDialogReport.ShowDialog() != DialogResult.OK)
                return;

            Cursor.Current = Cursors.WaitCursor;
            SortedList<String, List<ManagedObject>> fullObjectList = new SortedList<string, List<ManagedObject>>();
            Snapshot lastSnapshot = null;
            foreach (Snapshot s in Snapshots)
            {
                SortableBindingList<ManagedObject> comparedSnapshots = CompareSnapshots(s, lastSnapshot, String.Empty, null);
                foreach (string n in s.ManagedObjectDic.Keys)
                {
                    if (!fullObjectList.ContainsKey(n))
                    {
                        fullObjectList.Add(n, new List<ManagedObject>());
                    }

                    if (comparedSnapshots != null)
                    {
                        ManagedObject mo = comparedSnapshots.FirstOrDefault(x => x.ObjectName == n);

                        if (mo != null)
                        {
                            mo.SnapshotKey = s.Date;
                            fullObjectList[n].Add(mo);
                        }
                    }
                    else
                    {
                        if (Snapshots[0].ManagedObjectDic.ContainsKey(n))
                        {
                            Snapshots[0].ManagedObjectDic[n].SnapshotKey = s.Date;
                            fullObjectList[n].Add(Snapshots[0].ManagedObjectDic[n]);
                        }
                    }
                }

                lastSnapshot = s;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("ObjectName;Sum;");
            sb.AppendLine(String.Join(";", Snapshots.Select(x => x.Date.ToString("HH:mm:ss"))));

            foreach (KeyValuePair<String, List<ManagedObject>> smo in fullObjectList.OrderBy(x => x.Key))
            {
                sb.Append(smo.Key + ";");
                sb.Append(smo.Value.Sum(x => x.ObjectChange));
                sb.Append(";");
                foreach (Snapshot s in Snapshots)
                {
                    ManagedObject mo = smo.Value.FirstOrDefault(x => x.SnapshotKey == s.Date);
                    if (mo != null && mo.ObjectChange != 0)
                        sb.Append(mo.ObjectChange);
                    else
                        sb.Append(0);
                    sb.Append(";");
                }
                sb.AppendLine();
            }
            Cursor.Current = Cursors.Default;

            File.WriteAllText(saveFileDialogReport.FileName, sb.ToString());

        }

        /// <summary>
        /// Find all Strings in Heap an generate a dublicate string report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStrings_Click(object sender, EventArgs e)
        {
            if (process == null)
                return;

            saveFileDialogStrings.FileName = String.Format("clrmd_{0:yyyyMMdd_HHmmss}", DateTime.Now);
            if (saveFileDialogStrings.ShowDialog() != DialogResult.OK)
                return;

            if (File.Exists(saveFileDialogStrings.FileName))
                File.Delete(saveFileDialogStrings.FileName);

            Cursor.Current = Cursors.WaitCursor;

            HashSet<StringObjectHelper> stringObjectList = new HashSet<StringObjectHelper>();
            ulong fullSize = 0;
            int objectCount = 0;
            using (StreamWriter writer = new StreamWriter(saveFileDialogStrings.FileName, true, Encoding.UTF8))
            {
                using (DataTarget dataTarget = DataTarget.AttachToProcess(process.Id, dataTargetTimeOut, dataTargetAttachFlag))
                {
                    ClrInfo clrVersion = dataTarget.ClrVersions.First();
                    ClrRuntime runtime = clrVersion.CreateRuntime();
                    if (runtime.Heap.CanWalkHeap)
                    {
                        foreach (ulong ptr in runtime.Heap.EnumerateObjectAddresses())
                        {
                            ClrType type = runtime.Heap.GetObjectType(ptr);

                            if (type == null || type.IsString == false)
                            {
                                continue;
                            }

                            StringObjectHelper stringObject = new StringObjectHelper();
                            stringObject.String = (string)type.GetValue(ptr);
                            stringObject.Size = type.GetSize(ptr);

                            StringObjectHelper stringObjectFound;
                            if (stringObjectList.TryGetValue(stringObject, out stringObjectFound))
                                stringObjectFound.PtrList.Add(ptr);
                            else
                            {
                                stringObject.PtrList.Add(ptr);
                                stringObjectList.Add(stringObject);
                            }
                            objectCount++;
                            fullSize += stringObject.Size;

                            //write all strings
                            writer.WriteLine("**{0}#{1:X}#G{2}#{3:n0}",
                                objectCount,
                                ptr,
                                type.Heap.GetGeneration(ptr),
                                stringObject.Size);

                            writer.WriteLine(stringObject.String);
                        }
                    }

                    writer.WriteLine();
                    writer.WriteLine("**Position#HeapPtr#Generation#Size");
                    writer.WriteLine();
                    writer.WriteLine("{0:n0} String Objects", objectCount);
                    writer.WriteLine("{0:n0} String unique Strings", stringObjectList.Count);
                    writer.WriteLine("{0:n0} Bytes", fullSize);
                }
            }

            //write dublicate info
            var orderedList = stringObjectList.OrderByDescending(x => x.PtrList.Count);
            using (StreamWriter writer = new StreamWriter(saveFileDialogStrings.FileName + ".unique.csv", true, Encoding.UTF8))
            {
                writer.WriteLine("Count;Size;FullSize;Content;Ptrs");
                foreach (StringObjectHelper so in orderedList)
                {
                    string pointerList = String.Join(",", so.PtrList.Select(x => String.Format("x{0:X}", x)));
                    writer.WriteLine(String.Format("{0};{1};{2};{3};{4}",
                            so.PtrList.Count,
                            so.Size,
                            so.Size * (ulong)so.PtrList.Count,
                            (so.String.Length > 50 ? so.String.Substring(0, 50) + " ..." : so.String).Replace("'", "").Replace(";", "").Replace("\r", " ").Replace("\n", ""),
                            pointerList.Length > 50 ? pointerList.Substring(0, 50) + " ..." : pointerList));
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void walkTheHeapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.SelectedRows.Count > 0)
            {
                ManagedObject m = dataGridViewMain.SelectedRows[0].DataBoundItem as ManagedObject;
                using (DataTarget dataTarget = DataTarget.AttachToProcess(process.Id, dataTargetTimeOut, dataTargetAttachFlag))
                {
                    ClrInfo clrVersion = dataTarget.ClrVersions.First();
                    ClrRuntime runtime = clrVersion.CreateRuntime();
                    RetentionTreeViewer r = new RetentionTreeViewer(runtime, m.ObjectName);
                    r.ShowDialog(this);
                }
            }
        }

        //https://github.com/Microsoft/dotnet-samples/tree/master/Microsoft.Diagnostics.Runtime/CLRMD
        private void objectOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (process == null)
                return;

            saveFileDialogObjects.FileName = String.Format("clrmd_{0:yyyyMMdd_HHmmss}_FieldInfo", DateTime.Now);
            if (saveFileDialogObjects.ShowDialog() != DialogResult.OK)
                return;

            if (File.Exists(saveFileDialogObjects.FileName))
                File.Delete(saveFileDialogObjects.FileName);

            Cursor.Current = Cursors.WaitCursor;

            using (DataTarget dataTarget = DataTarget.AttachToProcess(process.Id, dataTargetTimeOut, dataTargetAttachFlag))
            {
                ClrInfo clrVersion = dataTarget.ClrVersions.First();
                ClrRuntime runtime = clrVersion.CreateRuntime();
                if (runtime.Heap.CanWalkHeap)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialogObjects.FileName, true, Encoding.UTF8))
                    {
                        foreach (DataGridViewRow row in dataGridViewMain.SelectedRows)
                        {
                            ManagedObject m = row.DataBoundItem as ManagedObject;
                            
                            writer.WriteLine("*********************** {0} ************************", m.ObjectName);
                            writer.WriteLine();

                            foreach (ulong ptr in runtime.Heap.EnumerateObjectAddresses())
                            {
                                ClrType type = runtime.Heap.GetObjectType(ptr);

                                if (type == null || type.Name != m.ObjectName)
                                    continue;

                                 writer.WriteLine("{1} {0:X}", ptr, m.ObjectName);
                                foreach (ClrInstanceField f in type.Fields)
                                {
                                    object value = f.GetValue(ptr);                                   

                                    if ((f.IsObjectReference || f.ElementType == ClrElementType.Struct) && f.ElementType != ClrElementType.String)
                                    {
                                        value = String.Format("{1} {0:X}", f.GetAddress(ptr), f.ElementType);

                                        if (f.ElementType == ClrElementType.Struct && f.Type.Name == "System.DateTime")
                                        {
                                            foreach (ClrInstanceField fd in f.Type.Fields)
                                                if (fd.Name == "dateData")
                                                {
                                                    //https://stackoverflow.com/questions/10759287/interpret-uint64-datedata-in-net-datetime-structure
                                                    //http://www.dotnetframework.org/default.aspx/DotNET/DotNET/8@0/untmp/whidbey/REDBITS/ndp/clr/src/BCL/System/DateTime@cs/1/DateTime@cs
                                                    UInt64 dateData = (UInt64)fd.GetValue(fd.GetAddress(ptr));
                                                    Int64 ticks = (Int64)(dateData & (UInt64)0x3FFFFFFFFFFFFFFF);
                                                    //TODO klappt nicht so recht
                                                    //value = DateTime.FromBinary(ticks);
                                                }

                                        }
                                    }
                                    writer.WriteLine("\t{0}: {1} [{2}]", f.Name.StartsWith("<") ? f.Name.Replace(">k__BackingField", "").TrimStart('<') : f.Name, value, f.Type.Name);                                    
                                }
                                writer.WriteLine();
                            }
                            writer.WriteLine();
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
