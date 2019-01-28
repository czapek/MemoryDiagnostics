using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryDiagnostics
{
    public partial class RetentionTreeViewer : Form
    {
        ClrRuntime runtime;
        public RetentionTreeViewer()
        {
            InitializeComponent();
        }

        public RetentionTreeViewer(ClrRuntime runtime, String objectName)
        {
            this.runtime = runtime;
            InitializeComponent();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            List<ClrTypeHelper> c = ClrMdHelper.GetPtrsForObjectName(runtime, objectName);
            comboBoxClrMdTypes.Items.AddRange(c.ToArray());

            if (comboBoxClrMdTypes.Items.Count > 0)
                comboBoxClrMdTypes.SelectedIndex = 0;
        }

        private void AddNodesRecursive(ClrTypeHelper root, TreeNodeCollection nodes)
        {
            TreeNode nodeParent = new TreeNode(root.Name);
            nodes.Add(nodeParent);
            foreach (ClrTypeHelper p in root.Parents)
            {
                AddNodesRecursive(p, nodeParent.Nodes);
            }
        }

        private void comboBoxClrMdTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ClrTypeHelper clrTypeHelper = comboBoxClrMdTypes.SelectedItem as ClrTypeHelper;
            ClrMdHelper.BuildFullRetentionTree(runtime, clrTypeHelper);
            this.treeViewRetention.Nodes.Clear();
            AddNodesRecursive(clrTypeHelper, this.treeViewRetention.Nodes);
            Cursor.Current = Cursors.Default;
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewRetention.ExpandAll();
        }

        private void collapsAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewRetention.CollapseAll();
        }

        private void saveAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClrTypeHelper clrTypeHelper = comboBoxClrMdTypes.SelectedItem as ClrTypeHelper;
            saveFileDialogImage.FileName = String.Format("clrmd_{0:yyyyMMdd_HHmmss}_{1:X}", DateTime.Now, clrTypeHelper.Ptr);
            if (saveFileDialogImage.ShowDialog() != DialogResult.OK)
                return;

            Bitmap bm = new Bitmap(treeViewRetention.Width, treeViewRetention.Height);
            treeViewRetention.DrawToBitmap(bm,
                new Rectangle(0, 0, treeViewRetention.Width, treeViewRetention.Height));

            bm.Save(saveFileDialogImage.FileName, ImageFormat.Png);
        }
    }
}
