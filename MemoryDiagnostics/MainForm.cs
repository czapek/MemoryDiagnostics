using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryDiagnostics
{
    public partial class MainForm : Form
    {
        List<Snapshot> Snapshots = new List<Snapshot>();
        Process process;
        int snapshotCnt = 0;

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
            Process[] allProcesses = Process.GetProcesses();
            process = allProcesses.FirstOrDefault(p => p.ProcessName.Contains(textBoxProcessFilter.Text.Trim()));

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CreateManagedObjects();
                Cursor.Current = Cursors.Default;
                snapshotCnt++;
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
            using (DataTarget dataTarget = DataTarget.AttachToProcess(process.Id, 10000, AttachFlag.Passive))
            {
                ClrInfo clrVersion = dataTarget.ClrVersions.First();
                ClrRuntime runtime = clrVersion.CreateRuntime();
                Snapshot snapshot = new Snapshot() { MemoryPrivateBytes = process.PrivateMemorySize64, Date = DateTime.Now, Position = Snapshots.Count };
                Snapshots.Add(snapshot);
                CollectMemory(runtime, snapshot);
                snapshot.ManagedObjectDic = ListObjects(runtime);

                if (Snapshots.Count > 1)
                    CompareSnapshots(snapshot, Snapshots[Snapshots.Count - 2]);

                bindingSourceSnapshot.DataSource = null;
                bindingSourceSnapshot.DataSource = Snapshots;
                Regular.Visible = Snapshots.Sum(x => (long)x.MemoryRegular) > 0;
                Reserved.Visible = Snapshots.Sum(x => (long)x.MemoryReserved) > 0;
            }

            this.Text = String.Format("{0}. Snapshot, {1:n0} KB (private bytes)", snapshotCnt, process.PrivateMemorySize64 / 1024);
        }

        Snapshot snapshot1Current;
        Snapshot snapshot2Current;
        private void CompareSnapshots(Snapshot snapshot1, Snapshot snapshot2)
        {
            if (snapshot1 == null || snapshot2 == null)
                return;

            snapshot1Current = snapshot1;
            snapshot2Current = snapshot2;

            string filter = textBoxObjectFilter.Text.Trim();
            List<ManagedObject> managedObjectsCompare = new List<ManagedObject>();

            foreach (ManagedObject mo in snapshot1.ManagedObjectDic.Values)
            {
                if (filter.Length != 0 && !mo.ObjectName.Contains(filter))
                    continue;

                mo.ObjectCount = mo.ObjectPtrs.Count;
                if (snapshot2.ManagedObjectDic.ContainsKey(mo.ObjectName))
                    mo.ObjectCountLast = snapshot2.ManagedObjectDic[mo.ObjectName].ObjectPtrs.Count;

                if (!checkBoxChange.Checked || mo.ObjectChange > 0)
                    managedObjectsCompare.Add(mo);
            }

            if (!checkBoxChange.Checked)
                foreach (ManagedObject mo in snapshot2.ManagedObjectDic.Values)
                {
                    if (filter.Length != 0 && !mo.ObjectName.Contains(filter))
                        continue;

                    if (!snapshot1.ManagedObjectDic.ContainsKey(mo.ObjectName))
                    {
                        mo.ObjectCountLast = mo.ObjectPtrs.Count;
                        mo.ObjectCount = 0;
                        managedObjectsCompare.Add(mo);
                    }
                }

            if (checkBoxChange.Checked)
                managedObjectsCompare = managedObjectsCompare.OrderByDescending(x => x.ObjectChange).ThenBy(x => x.ObjectName).ToList();
            else
                managedObjectsCompare = managedObjectsCompare.OrderByDescending(x => x.ObjectChange > 0).ThenBy(x => x.ObjectChange == 0).ThenByDescending(x => x.ObjectChange < 0).ThenBy(x => x.ObjectName).ToList();

            bindingSourceMain.DataSource = managedObjectsCompare;
        }

        //https://github.com/Microsoft/clrmd/blob/master/Documentation/ClrRuntime.md
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
                    if (type != null)
                    {
                        ManagedObject mo = null;
                        if (!managedObjects.ContainsKey(type.Name))
                        {
                            mo = new ManagedObject()
                            {
                                ClrType = type,
                                ObjectPtrs = new List<ulong>()
                            };
                            managedObjects.Add(type.Name, mo);
                        }

                        if (mo == null)
                            mo = managedObjects[type.Name];

                        mo.ObjectPtrs.Add(ptr);
                        mo.ObjectSize += type.GetSize(ptr);
                    }
                }
            }
            return managedObjects;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            NextSnapshot();
        }

        private void dataGridViewSnapshot_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewSnapshot.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewSnapshot.SelectedRows[0];
                Snapshot s = row.DataBoundItem as Snapshot;

                if (s != null && Snapshots.Count > 0)
                    CompareSnapshots(Snapshots[Snapshots.Count - 1], s);
            }

        }

        private void checkBoxChange_CheckedChanged(object sender, EventArgs e)
        {
            CompareSnapshots(snapshot1Current, snapshot2Current);
        }

        private void textBoxObjectFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                CompareSnapshots(snapshot1Current, snapshot2Current);
        }

        private void dataGridViewSnapshot_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Snapshot snapshot = dataGridViewSnapshot.Rows[e.RowIndex].DataBoundItem as Snapshot;
            if (snapshot == null)
                return;

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
        }
    }
}
