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
            this.comboBoxClrMdTypes = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapsAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogImage = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewRetention
            // 
            this.treeViewRetention.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewRetention.ContextMenuStrip = this.contextMenuStrip1;
            this.treeViewRetention.Location = new System.Drawing.Point(0, 28);
            this.treeViewRetention.Name = "treeViewRetention";
            this.treeViewRetention.Size = new System.Drawing.Size(844, 569);
            this.treeViewRetention.TabIndex = 0;
            // 
            // comboBoxClrMdTypes
            // 
            this.comboBoxClrMdTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxClrMdTypes.FormattingEnabled = true;
            this.comboBoxClrMdTypes.Location = new System.Drawing.Point(0, 0);
            this.comboBoxClrMdTypes.Name = "comboBoxClrMdTypes";
            this.comboBoxClrMdTypes.Size = new System.Drawing.Size(844, 21);
            this.comboBoxClrMdTypes.TabIndex = 1;
            this.comboBoxClrMdTypes.SelectedIndexChanged += new System.EventHandler(this.comboBoxClrMdTypes_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandAllToolStripMenuItem,
            this.collapsAllToolStripMenuItem,
            this.saveAsImageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 70);
            // 
            // expandAllToolStripMenuItem
            // 
            this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
            this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.expandAllToolStripMenuItem.Text = "Expand all";
            this.expandAllToolStripMenuItem.Click += new System.EventHandler(this.expandAllToolStripMenuItem_Click);
            // 
            // collapsAllToolStripMenuItem
            // 
            this.collapsAllToolStripMenuItem.Name = "collapsAllToolStripMenuItem";
            this.collapsAllToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.collapsAllToolStripMenuItem.Text = "Collaps all";
            this.collapsAllToolStripMenuItem.Click += new System.EventHandler(this.collapsAllToolStripMenuItem_Click);
            // 
            // saveAsImageToolStripMenuItem
            // 
            this.saveAsImageToolStripMenuItem.Name = "saveAsImageToolStripMenuItem";
            this.saveAsImageToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveAsImageToolStripMenuItem.Text = "Save as Image";
            this.saveAsImageToolStripMenuItem.Click += new System.EventHandler(this.saveAsImageToolStripMenuItem_Click);
            // 
            // saveFileDialogImage
            // 
            this.saveFileDialogImage.Filter = "png image |*.png";
            this.saveFileDialogImage.Title = "Save Image of Retention Tree";
            // 
            // RetentionTreeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 596);
            this.Controls.Add(this.comboBoxClrMdTypes);
            this.Controls.Add(this.treeViewRetention);
            this.Name = "RetentionTreeViewer";
            this.Text = "RetentionTree Viewer";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewRetention;
        private System.Windows.Forms.ComboBox comboBoxClrMdTypes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem expandAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapsAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsImageToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogImage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}