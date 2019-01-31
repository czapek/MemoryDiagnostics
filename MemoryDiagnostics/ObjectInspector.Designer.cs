namespace MemoryDiagnostics
{
    partial class ObjectInspector
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewObjects = new System.Windows.Forms.TreeView();
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.contextMenuStripObjectTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openInRetentionTreeViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStripObjectTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(1, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewObjects);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxInfo);
            this.splitContainer1.Size = new System.Drawing.Size(1177, 696);
            this.splitContainer1.SplitterDistance = 455;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewObjects
            // 
            this.treeViewObjects.ContextMenuStrip = this.contextMenuStripObjectTree;
            this.treeViewObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewObjects.Location = new System.Drawing.Point(0, 0);
            this.treeViewObjects.Name = "treeViewObjects";
            this.treeViewObjects.Size = new System.Drawing.Size(455, 696);
            this.treeViewObjects.TabIndex = 0;
            this.treeViewObjects.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewObjects_BeforeExpand);
            this.treeViewObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewObjects_AfterSelect);
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxInfo.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.ReadOnly = true;
            this.richTextBoxInfo.Size = new System.Drawing.Size(718, 696);
            this.richTextBoxInfo.TabIndex = 0;
            this.richTextBoxInfo.Text = "";
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(9, 10);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(389, 20);
            this.textBoxFilter.TabIndex = 1;
            this.textBoxFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFilter_KeyDown);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(404, 10);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 2;
            this.buttonFilter.Text = "Search";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // contextMenuStripObjectTree
            // 
            this.contextMenuStripObjectTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInRetentionTreeViewerToolStripMenuItem});
            this.contextMenuStripObjectTree.Name = "contextMenuStripObjectTree";
            this.contextMenuStripObjectTree.Size = new System.Drawing.Size(234, 26);
            // 
            // openInRetentionTreeViewerToolStripMenuItem
            // 
            this.openInRetentionTreeViewerToolStripMenuItem.Name = "openInRetentionTreeViewerToolStripMenuItem";
            this.openInRetentionTreeViewerToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.openInRetentionTreeViewerToolStripMenuItem.Text = "Open in Retention Tree Viewer";
            this.openInRetentionTreeViewerToolStripMenuItem.Click += new System.EventHandler(this.openInRetentionTreeViewerToolStripMenuItem_Click);
            // 
            // ObjectInspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 737);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ObjectInspector";
            this.Text = "Object Inspector";
            this.Load += new System.EventHandler(this.ObjectInspector_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStripObjectTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewObjects;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripObjectTree;
        private System.Windows.Forms.ToolStripMenuItem openInRetentionTreeViewerToolStripMenuItem;
    }
}