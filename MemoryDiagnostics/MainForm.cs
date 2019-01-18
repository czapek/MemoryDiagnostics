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
        Dictionary<string, ManagedObject> lastSnapshot;
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
            process = allProcesses.FirstOrDefault(p => p.ProcessName.Contains(textBoxProcessFilter.Text.Trim()));
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

                Dictionary<string, ManagedObject> managedObjectsDic = ListObjects(runtime, textBoxObjectFilter.Text.Trim());

                if (lastSnapshot != null)
                {
                    foreach (ManagedObject mo in managedObjectsDic.Values)
                    {
                        mo.ObjectCount = mo.ObjectPtrs.Count;
                        if (lastSnapshot.ContainsKey(mo.ObjectName))
                            mo.ObjectCountLast = lastSnapshot[mo.ObjectName].ObjectPtrs.Count;

                        if (!checkBoxChange.Checked || mo.ObjectChange > 0)
                            managedObjects.Add(mo);
                    }

                    if (!checkBoxChange.Checked)
                        foreach (ManagedObject mo in lastSnapshot.Values)
                        {
                            if (!managedObjectsDic.ContainsKey(mo.ObjectName))
                            {
                                mo.ObjectCountLast = mo.ObjectPtrs.Count;
                                mo.ObjectCount = 0;
                                managedObjects.Add(mo);
                            }
                        }
                }

                if (checkBoxChange.Checked)
                    managedObjects = managedObjects.OrderByDescending(x => x.ObjectChange).ThenBy(x => x.ObjectName).ToList();
                else
                    managedObjects = managedObjects.OrderBy(x => x.ObjectName).ToList();

                lastSnapshot = managedObjectsDic;
                bindingSourceMain.DataSource = managedObjects;
            }

            this.Text = snapshotCnt + ". Snapshot";
            Cursor.Current = Cursors.Default;
            snapshotCnt++;
        }

        private static Dictionary<string, ManagedObject> ListObjects(ClrRuntime runtime, string startsWith)
        {
            Dictionary<String, ManagedObject> managedObjects = new Dictionary<string, ManagedObject>();

            if (runtime.Heap.CanWalkHeap)
            {
                foreach (ulong ptr in runtime.Heap.EnumerateObjectAddresses())
                {
                    ClrType type = runtime.Heap.GetObjectType(ptr);
                    if (type != null && (String.IsNullOrEmpty(startsWith) || type.Name.StartsWith(startsWith)))
                    {
                        if (!managedObjects.ContainsKey(type.Name))
                        {
                            managedObjects.Add(type.Name, new ManagedObject()
                            {
                                ClrType = type,
                                ObjectPtrs = new List<ulong>()
                            });
                        }
                        managedObjects[type.Name].ObjectPtrs.Add(ptr);
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
