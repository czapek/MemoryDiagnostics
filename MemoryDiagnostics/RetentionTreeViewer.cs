﻿using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
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

        public RetentionTreeViewer(ClrRuntime runtime, List<String> managedObjects)
        {
            this.runtime = runtime;
            InitializeComponent();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            if (runtime != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<ClrTypeHelper> c = new List<ClrTypeHelper>();
                foreach (String s in managedObjects)
                    c.AddRange(ClrMdHelper.GetPtrsForObjectName(runtime, s));

                comboBoxClrMdTypes.Items.AddRange(c.ToArray());

                Cursor.Current = Cursors.Default;
            }
            else
            {
                openFileDialog();
            }
        }

        public RetentionTreeViewer(ClrRuntime runtime, ulong ptr)
        {
            this.runtime = runtime;
            InitializeComponent();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            openTreeFromPtr(ptr);
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

        private void comboBoxClrMdTypes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ulong ptr;
                if (runtime != null && ulong.TryParse(comboBoxClrMdTypes.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out ptr))
                {
                    openTreeFromPtr(ptr);
                }
            }
        }

        private void openTreeFromPtr(ulong ptr)
        {
            if (ptr == 0)
                return;

            ClrTypeHelper clr = comboBoxClrMdTypes.Items.Cast<ClrTypeHelper>().FirstOrDefault(x => x.Ptr == ptr);

            if(clr != null)
            {
                comboBoxClrMdTypes.SelectedItem = clr;
                return;
            }

            ClrType type = runtime.Heap.GetObjectType(ptr);
            if (type != null)
            {
                ClrTypeHelper clrTypeHelper = new ClrTypeHelper()
                {
                    Ptr = ptr,
                    Name = type.Name,
                    Size = type.GetSize(ptr)
                };

                comboBoxClrMdTypes.Items.Add(clrTypeHelper);
                comboBoxClrMdTypes.SelectedIndex = comboBoxClrMdTypes.Items.Count - 1;
            }
        }
    }
}
