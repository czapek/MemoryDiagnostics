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
        SortedDictionary<string, ManagedObject> lastSnapshot;
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
                this.Text = ex.Message;
            }
        }

        private void CreateManagedObjects()
        {
            List<ManagedObject> managedObjectsCompare = new List<ManagedObject>();
            using (DataTarget dataTarget = DataTarget.AttachToProcess(process.Id, 10000, AttachFlag.Passive))
            {
                ClrInfo clrVersion = dataTarget.ClrVersions.First();
                ClrRuntime runtime = clrVersion.CreateRuntime();
                Snapshot snapshot = new Snapshot() { MemoryPrivateBytes = process.PrivateMemorySize64, Date = DateTime.Now, Position = Snapshots.Count };
                Snapshots.Add(snapshot);
                CollectMemory(runtime, snapshot);
                snapshot.ManagedObjectDic = ListObjects(runtime);

                if (lastSnapshot != null)
                {
                    string filter = textBoxObjectFilter.Text.Trim();

                    foreach (ManagedObject mo in snapshot.ManagedObjectDic.Values)
                    {
                        if (filter.Length != 0 && !mo.ObjectName.Contains(filter))
                            continue;

                        mo.ObjectCount = mo.ObjectPtrs.Count;
                        if (lastSnapshot.ContainsKey(mo.ObjectName))
                            mo.ObjectCountLast = lastSnapshot[mo.ObjectName].ObjectPtrs.Count;

                        if (!checkBoxChange.Checked || mo.ObjectChange > 0)
                            managedObjectsCompare.Add(mo);
                    }

                    if (!checkBoxChange.Checked)
                        foreach (ManagedObject mo in lastSnapshot.Values)
                        {
                            if (filter.Length != 0 && !mo.ObjectName.Contains(filter))
                                continue;

                            if (!snapshot.ManagedObjectDic.ContainsKey(mo.ObjectName))
                            {
                                mo.ObjectCountLast = mo.ObjectPtrs.Count;
                                mo.ObjectCount = 0;
                                managedObjectsCompare.Add(mo);
                            }
                        }
                }

                if (checkBoxChange.Checked)
                    managedObjectsCompare = managedObjectsCompare.OrderByDescending(x => x.ObjectChange).ThenBy(x => x.ObjectName).ToList();
                else
                    managedObjectsCompare = managedObjectsCompare.OrderByDescending(x => x.ObjectChange > 0).ThenBy(x => x.ObjectChange == 0).ThenByDescending(x => x.ObjectChange < 0).ThenBy(x => x.ObjectName).ToList();

                lastSnapshot = snapshot.ManagedObjectDic;
                bindingSourceMain.DataSource = managedObjectsCompare;
                bindingSourceSnapshot.DataSource = null;
                bindingSourceSnapshot.DataSource = Snapshots;    
            }

            this.Text = String.Format("{0}. Snapshot, {1:n0} KB (private bytes)", snapshotCnt, process.PrivateMemorySize64 / 1024);
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
    }
}
