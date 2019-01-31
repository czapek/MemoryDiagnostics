using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryDiagnostics
{
    public partial class ObjectInspector : Form
    {
        ClrRuntime runtime;
        List<ClrTypeHelper> globalSearchList = new List<ClrTypeHelper>();
        public ObjectInspector(ClrRuntime runtime, List<String> managedObjects)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.runtime = runtime;
            InitializeComponent();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));


            List<ClrTypeHelper> typeList = new List<ClrTypeHelper>();
            foreach (String s in managedObjects.OrderBy(x => x))
                typeList.AddRange(ClrMdHelper.GetPtrsForObjectName(runtime, s));

            this.treeViewObjects.Nodes.Clear();

            foreach (ClrTypeHelper c in typeList)
            {
                TreeNode node = new TreeNode(c.Name) { Tag = c };
                c.TreeNode = node;
                node.Nodes.Add(new TreeNode());
                treeViewObjects.Nodes.Add(node);
                globalSearchList.Add(c);
            }
            Cursor.Current = Cursors.Default;
        }

        private void ObjectInspector_Load(object sender, EventArgs e)
        {
            textBoxFilter.Focus();
        }

        private void treeViewObjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ClrTypeHelper c = e.Node.Tag as ClrTypeHelper;
            if (c.ObjectInfo == null)
                c.ObjectInfo = ClrMdHelper.GetInfoOfObject(runtime, c.Ptr, null);

            richTextBoxInfo.Text = c.ObjectInfo;
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            FilterNodes();
        }

        private void FilterNodes()
        {
            Cursor.Current = Cursors.WaitCursor;
            TreeNode foundNode = null;
            richTextBoxInfo.Clear();
            foreach (ClrTypeHelper c in globalSearchList)
            {
                if (c.ObjectInfo == null)
                    c.ObjectInfo = ClrMdHelper.GetInfoOfObject(runtime, c.Ptr, null);

                if (c.ObjectInfo.Contains(textBoxFilter.Text))
                {
                    if (foundNode == null) foundNode = c.TreeNode;
                    c.TreeNode.BackColor = Color.LightGreen;
                    richTextBoxInfo.AppendText(c.ObjectInfo + System.Environment.NewLine);

                }
                else
                    c.TreeNode.BackColor = Color.White;
            }
            if (foundNode != null)
                foundNode.EnsureVisible();
            Cursor.Current = Cursors.Default;
        }

        private void textBoxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FilterNodes();
            }
        }

        private void treeViewObjects_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Tag == null)
            {
                e.Node.Nodes.Clear();
                ClrTypeHelper c = (ClrTypeHelper)e.Node.Tag;

                ClrType type = runtime.Heap.GetObjectType(c.Ptr);
                foreach (ClrObject o in type.EnumerateObjectReferences(c.Ptr))
                {

                    if (o.Type.Name == "System.String")
                        continue;

                    ClrType refType = runtime.Heap.GetObjectType(o.Address);

                    TreeNode refNode = new TreeNode(refType.Name);
                    refNode.Nodes.Add(new TreeNode());
                    ClrTypeHelper refHelper = new ClrTypeHelper()
                    {
                        Ptr = o.Address,
                        Name = refType.Name,
                        Size = type.GetSize(o.Address),
                        TreeNode = refNode
                    };

                    System.Diagnostics.Debug.WriteLine("{0:X} {1}", o.Address, refType.Name);
                    refNode.Tag = refHelper;
                    e.Node.Nodes.Add(refNode);
                    globalSearchList.Add(refHelper);
                }

                foreach (ClrInstanceField f in type.Fields)
                {
                    System.Diagnostics.Debug.WriteLine("{0:X} {1}", f.GetAddress(c.Ptr), f.Type);
                }
            }
        }

        private void openInRetentionTreeViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<String> managedObjects = new List<String>();
            ulong ptr = 0;
            if (treeViewObjects.SelectedNode != null)
                ptr = ((ClrTypeHelper)treeViewObjects.SelectedNode.Tag).Ptr;

            RetentionTreeViewer r = new RetentionTreeViewer(runtime, ptr);
            r.Show(this);
        }
    }
}
