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
        Dictionary<DateTime, Dictionary<String, List<ulong>>> snapshots = new Dictionary<DateTime, Dictionary<string, List<ulong>>>();
        Dictionary<String, List<ulong>> lastSnapshot;
        Process process;
        int snapshotCnt = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartWatching();
        }

        private void StartWatching()
        {
            Process[] allProcesses = Process.GetProcesses();
            process = allProcesses.FirstOrDefault(p => p.ProcessName.Contains("MediaBrowser"));
            NextSnapshot();
        }

        private void NextSnapshot()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<ManagedObject> managedObjects = new List<ManagedObject>();
            using (DataTarget dataTarget = DataTarget.AttachToProcess(process.Id, 10000, AttachFlag.Passive))
            {
                ClrInfo clrVersion = dataTarget.ClrVersions.First();
                ClrRuntime runtime = clrVersion.CreateRuntime();
              
                Dictionary<String, List<ulong>> meonaObjects = ListObjects(runtime, "MediaBrowser").OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

                if (lastSnapshot != null)
                {
                    foreach (KeyValuePair<String, List<ulong>> kv in meonaObjects)
                    {
                        if (lastSnapshot.ContainsKey(kv.Key))
                        {
                            managedObjects.Add(new ManagedObject() { ObjectName = kv.Key, ObjectCount = kv.Value.Count, ObjectChange = kv.Value.Count - lastSnapshot[kv.Key].Count });
                        }
                        else
                        {
                            managedObjects.Add(new ManagedObject() { ObjectName = kv.Key, ObjectCount = kv.Value.Count, ObjectChange = kv.Value.Count });
                        }
                    }

                    foreach (KeyValuePair<String, List<ulong>> kv in lastSnapshot)
                    {
                        if (!meonaObjects.ContainsKey(kv.Key))
                        {
                            managedObjects.Add(new ManagedObject() { ObjectName = kv.Key, ObjectCount = kv.Value.Count, ObjectChange = kv.Value.Count });
                        }
                    }
                }

                managedObjects = managedObjects.OrderByDescending(x => x.ObjectChange).ThenBy(x => x.ObjectName).ToList();
                lastSnapshot = meonaObjects;
                snapshots.Add(DateTime.Now, meonaObjects);
                bindingSourceMain.DataSource = managedObjects;
            }

            this.Text = snapshotCnt + ". Snapshot";
            Cursor.Current = Cursors.Default;
            snapshotCnt++;
        }

        private static Dictionary<string, List<ulong>> ListObjects(ClrRuntime runtime, string startsWith)
        {
            Dictionary<String, List<ulong>> meonaObjects = new Dictionary<string, List<ulong>>();
            if (runtime.Heap.CanWalkHeap)
            {
                foreach (ulong ptr in runtime.Heap.EnumerateObjectAddresses())
                {
                    ClrType type = runtime.Heap.GetObjectType(ptr);
                    if (type != null && (startsWith == null || type.Name.StartsWith(startsWith)))
                    {
                        if (!meonaObjects.ContainsKey(type.Name))
                            meonaObjects.Add(type.Name, new List<ulong>());

                        meonaObjects[type.Name].Add(ptr);
                    }
                }
            }
            return meonaObjects;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            NextSnapshot();
        }
    }
}
