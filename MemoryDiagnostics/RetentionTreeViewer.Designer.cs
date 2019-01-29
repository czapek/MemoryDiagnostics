namespace MemoryDiagnostics
{
    partial class RetentionTreeViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeViewRetention = new System.Windows.Forms.TreeView();
            this.contextMenuStripRetention = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapsAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxClrMdTypes = new System.Windows.Forms.ComboBox();
            this.saveFileDialogImage = new System.Windows.Forms.SaveFileDialog();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.openFileDialogRetentionTree = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogRetentionTree = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStripRetention.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewRetention
            // 
            this.treeViewRetention.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewRetention.ContextMenuStrip = this.contextMenuStripRetention;
            this.treeViewRetention.Location = new System.Drawing.Point(0, 28);
            this.treeViewRetention.Name = "treeViewRetention";
            this.treeViewRetention.Size = new System.Drawing.Size(844, 569);
            this.treeViewRetention.TabIndex = 0;
            // 
            // contextMenuStripRetention
            // 
            this.contextMenuStripRetention.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandAllToolStripMenuItem,
            this.collapsAllToolStripMenuItem});
            this.contextMenuStripRetention.Name = "contextMenuStrip1";
            this.contextMenuStripRetention.Size = new System.Drawing.Size(129, 48);
            // 
            // expandAllToolStripMenuItem
            // 
            this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
            this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.expandAllToolStripMenuItem.Text = "Expand all";
            this.expandAllToolStripMenuItem.Click += new System.EventHandler(this.expandAllToolStripMenuItem_Click);
            // 
            // collapsAllToolStripMenuItem
            // 
            this.collapsAllToolStripMenuItem.Name = "collapsAllToolStripMenuItem";
            this.collapsAllToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.collapsAllToolStripMenuItem.Text = "Collaps all";
            this.collapsAllToolStripMenuItem.Click += new System.EventHandler(this.collapsAllToolStripMenuItem_Click);
            // 
            // comboBoxClrMdTypes
            // 
            this.comboBoxClrMdTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxClrMdTypes.FormattingEnabled = true;
            this.comboBoxClrMdTypes.Location = new System.Drawing.Point(2, 4);
            this.comboBoxClrMdTypes.Name = "comboBoxClrMdTypes";
            this.comboBoxClrMdTypes.Size = new System.Drawing.Size(680, 21);
            this.comboBoxClrMdTypes.TabIndex = 1;
            this.comboBoxClrMdTypes.Text = "Enter also a free hex pointer and press return ...";
            this.comboBoxClrMdTypes.SelectedIndexChanged += new System.EventHandler(this.comboBoxClrMdTypes_SelectedIndexChanged);
            this.comboBoxClrMdTypes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxClrMdTypes_KeyDown);
            // 
            // saveFileDialogImage
            // 
            this.saveFileDialogImage.Filter = "png image |*.png";
            this.saveFileDialogImage.Title = "Save Image of Retention Tree";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(766, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoad.Location = new System.Drawing.Point(688, 3);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // openFileDialogRetentionTree
            // 
            this.openFileDialogRetentionTree.Filter = "Retention Tree File|*.rte";
            this.openFileDialogRetentionTree.Title = "Open Retention Tree";
            // 
            // saveFileDialogRetentionTree
            // 
            this.saveFileDialogRetentionTree.Filter = "Retention Tree File|*.rte";
            this.saveFileDialogRetentionTree.Title = "Save Retention Tree";
            // 
            // RetentionTreeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 596);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxClrMdTypes);
            this.Controls.Add(this.treeViewRetention);
            this.Name = "RetentionTreeViewer";
            this.Text = "RetentionTree Viewer";
            this.contextMenuStripRetention.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewRetention;
        private System.Windows.Forms.ComboBox comboBoxClrMdTypes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRetention;
        private System.Windows.Forms.ToolStripMenuItem expandAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapsAllToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogImage;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialogRetentionTree;
        private System.Windows.Forms.SaveFileDialog saveFileDialogRetentionTree;
    }
}