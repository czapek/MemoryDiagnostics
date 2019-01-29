using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

        public RetentionTreeViewer(bool openFile)
        {
            InitializeComponent();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            if (openFile)
                openFileDialog();

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

            if (clrTypeHelper.Parents.Count == 0)
                ClrMdHelper.BuildFullRetentionTree(runtime, clrTypeHelper);

            this.treeViewRetention.Nodes.Clear();
            AddNodesRecursive(clrTypeHelper, this.treeViewRetention.Nodes);
            Cursor.Current = Cursors.Default;
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewRetention.ExpandAll();
        }

        public void ScrollToBottom(Panel p)
        {
            using (Control c = new Control() { Parent = p, Dock = DockStyle.Bottom })
            {
                p.ScrollControlIntoView(c);
                c.Parent = null;
            }
        }

        private void collapsAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewRetention.CollapseAll();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<ClrTypeHelper> typeHelpers = comboBoxClrMdTypes.Items.Cast<ClrTypeHelper>().Where(x => x.Parents.Count > 0).ToList();

            if (typeHelpers.Count == 0)
                return;

            saveFileDialogRetentionTree.FileName = String.Format("clrmd_{0:yyyyMMdd_HHmmss}", DateTime.Now);
            if (saveFileDialogRetentionTree.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (FileStream writerFileStream = new FileStream(saveFileDialogRetentionTree.FileName, FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(writerFileStream, typeHelpers);
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
            openFileDialog();
        }

        private void openFileDialog()
        {
            if (openFileDialogRetentionTree.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (FileStream readerFileStream = new FileStream(openFileDialogRetentionTree.FileName, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<ClrTypeHelper> typeHelpers = (List<ClrTypeHelper>)formatter.Deserialize(readerFileStream);
                    comboBoxClrMdTypes.Items.Clear();
                    comboBoxClrMdTypes.Items.AddRange(typeHelpers.ToArray());

                    if (comboBoxClrMdTypes.Items.Count > 0)
                        comboBoxClrMdTypes.SelectedIndex = 0;

                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
