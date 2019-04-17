namespace MemoryDiagnostics
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.OjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectSizeFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectCountLast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripMemoryObjects = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterForSelectedTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyObjectNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.walkTheHeapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInObjectInspectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.buttonNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProcessFilter = new System.Windows.Forms.TextBox();
            this.textBoxObjectFilter = new System.Windows.Forms.TextBox();
            this.checkBoxChange = new System.Windows.Forms.CheckBox();
            this.dataGridViewSnapshot = new System.Windows.Forms.DataGridView();
            this.Snapshot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectAllCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrivateBytes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoryEphemeral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoryLargeObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Regular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reserved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Other = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripSnapshot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectThisSnapshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareWithThisSnapshotDoubleClickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteThisSnapshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSourceSnapshot = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.saveFileDialogSnapshot = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogSnapshot = new System.Windows.Forms.OpenFileDialog();
            this.richTextBoxComment = new System.Windows.Forms.RichTextBox();
            this.buttonReport = new System.Windows.Forms.Button();
            this.saveFileDialogReport = new System.Windows.Forms.SaveFileDialog();
            this.buttonStrings = new System.Windows.Forms.Button();
            this.saveFileDialogStrings = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialogObjects = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.contextMenuStripMemoryObjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSnapshot)).BeginInit();
            this.contextMenuStripSnapshot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSnapshot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToDeleteRows = false;
            this.dataGridViewMain.AllowUserToOrderColumns = true;
            this.dataGridViewMain.AllowUserToResizeRows = false;
            this.dataGridViewMain.AutoGenerateColumns = false;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OjectName,
            this.ObjectSizeFormat,
            this.ObjectCount,
            this.ObjectChange,
            this.ObjectCountLast});
            this.dataGridViewMain.ContextMenuStrip = this.contextMenuStripMemoryObjects;
            this.dataGridViewMain.DataSource = this.bindingSourceMain;
            this.dataGridViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMain.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMain.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.RowHeadersVisible = false;
            this.dataGridViewMain.RowTemplate.Height = 24;
            this.dataGridViewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMain.Size = new System.Drawing.Size(1173, 773);
            this.dataGridViewMain.TabIndex = 0;
            // 
            // OjectName
            // 
            this.OjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OjectName.DataPropertyName = "ObjectName";
            this.OjectName.HeaderText = "Object";
            this.OjectName.Name = "OjectName";
            this.OjectName.ReadOnly = true;
            this.OjectName.Width = 630;
            // 
            // ObjectSizeFormat
            // 
            this.ObjectSizeFormat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ObjectSizeFormat.DataPropertyName = "ObjectSize";
            dataGridViewCellStyle1.Format = "n0";
            this.ObjectSizeFormat.DefaultCellStyle = dataGridViewCellStyle1;
            this.ObjectSizeFormat.HeaderText = "Bytes";
            this.ObjectSizeFormat.Name = "ObjectSizeFormat";
            this.ObjectSizeFormat.ReadOnly = true;
            this.ObjectSizeFormat.Width = 58;
            // 
            // ObjectCount
            // 
            this.ObjectCount.DataPropertyName = "ObjectCount";
            dataGridViewCellStyle2.Format = "n0";
            this.ObjectCount.DefaultCellStyle = dataGridViewCellStyle2;
            this.ObjectCount.HeaderText = "Count";
            this.ObjectCount.Name = "ObjectCount";
            this.ObjectCount.ReadOnly = true;
            this.ObjectCount.Width = 60;
            // 
            // ObjectChange
            // 
            this.ObjectChange.DataPropertyName = "ObjectChange";
            dataGridViewCellStyle3.Format = "n0";
            this.ObjectChange.DefaultCellStyle = dataGridViewCellStyle3;
            this.ObjectChange.HeaderText = "Change";
            this.ObjectChange.Name = "ObjectChange";
            this.ObjectChange.ReadOnly = true;
            this.ObjectChange.Width = 60;
            // 
            // ObjectCountLast
            // 
            this.ObjectCountLast.DataPropertyName = "ObjectCountLast";
            dataGridViewCellStyle4.Format = "n0";
            this.ObjectCountLast.DefaultCellStyle = dataGridViewCellStyle4;
            this.ObjectCountLast.HeaderText = "Last";
            this.ObjectCountLast.Name = "ObjectCountLast";
            this.ObjectCountLast.ReadOnly = true;
            this.ObjectCountLast.Width = 60;
            // 
            // contextMenuStripMemoryObjects
            // 
            this.contextMenuStripMemoryObjects.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterForSelectedTypesToolStripMenuItem,
            this.clearFilterToolStripMenuItem,
            this.copyObjectNameToolStripMenuItem,
            this.walkTheHeapToolStripMenuItem,
            this.openInObjectInspectorToolStripMenuItem,
            this.objectOverviewToolStripMenuItem});
            this.contextMenuStripMemoryObjects.Name = "contextMenuStripMeomoryObjects";
            this.contextMenuStripMemoryObjects.Size = new System.Drawing.Size(244, 136);
            // 
            // filterForSelectedTypesToolStripMenuItem
            // 
            this.filterForSelectedTypesToolStripMenuItem.Name = "filterForSelectedTypesToolStripMenuItem";
            this.filterForSelectedTypesToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.filterForSelectedTypesToolStripMenuItem.Text = "Add selected types to filter";
            this.filterForSelectedTypesToolStripMenuItem.Click += new System.EventHandler(this.filterForSelectedTypesToolStripMenuItem_Click);
            // 
            // clearFilterToolStripMenuItem
            // 
            this.clearFilterToolStripMenuItem.Name = "clearFilterToolStripMenuItem";
            this.clearFilterToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.clearFilterToolStripMenuItem.Text = "Clear Filter";
            this.clearFilterToolStripMenuItem.Click += new System.EventHandler(this.clearFilterToolStripMenuItem_Click);
            // 
            // copyObjectNameToolStripMenuItem
            // 
            this.copyObjectNameToolStripMenuItem.Name = "copyObjectNameToolStripMenuItem";
            this.copyObjectNameToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.copyObjectNameToolStripMenuItem.Text = "Copy this Type Name";
            this.copyObjectNameToolStripMenuItem.Click += new System.EventHandler(this.copyObjectNameToolStripMenuItem_Click);
            // 
            // walkTheHeapToolStripMenuItem
            // 
            this.walkTheHeapToolStripMenuItem.Name = "walkTheHeapToolStripMenuItem";
            this.walkTheHeapToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.walkTheHeapToolStripMenuItem.Text = "Open Retention Tree Viewer";
            this.walkTheHeapToolStripMenuItem.Click += new System.EventHandler(this.walkTheHeapToolStripMenuItem_Click);
            // 
            // openInObjectInspectorToolStripMenuItem
            // 
            this.openInObjectInspectorToolStripMenuItem.Name = "openInObjectInspectorToolStripMenuItem";
            this.openInObjectInspectorToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.openInObjectInspectorToolStripMenuItem.Text = "Open in Object Inspector";
            this.openInObjectInspectorToolStripMenuItem.Click += new System.EventHandler(this.openInObjectInspectorToolStripMenuItem_Click);
            // 
            // objectOverviewToolStripMenuItem
            // 
            this.objectOverviewToolStripMenuItem.Name = "objectOverviewToolStripMenuItem";
            this.objectOverviewToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.objectOverviewToolStripMenuItem.Text = "Save Field Overview of this Type";
            this.objectOverviewToolStripMenuItem.Click += new System.EventHandler(this.objectOverviewToolStripMenuItem_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(491, 12);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(194, 29);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "Next Snapshot";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Process Filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Object Filter";
            // 
            // textBoxProcessFilter
            // 
            this.textBoxProcessFilter.Location = new System.Drawing.Point(83, 4);
            this.textBoxProcessFilter.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProcessFilter.Name = "textBoxProcessFilter";
            this.textBoxProcessFilter.Size = new System.Drawing.Size(206, 20);
            this.textBoxProcessFilter.TabIndex = 3;
            // 
            // textBoxObjectFilter
            // 
            this.textBoxObjectFilter.Location = new System.Drawing.Point(83, 28);
            this.textBoxObjectFilter.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxObjectFilter.Name = "textBoxObjectFilter";
            this.textBoxObjectFilter.Size = new System.Drawing.Size(206, 20);
            this.textBoxObjectFilter.TabIndex = 3;
            this.textBoxObjectFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxObjectFilter_KeyDown);
            // 
            // checkBoxChange
            // 
            this.checkBoxChange.AutoSize = true;
            this.checkBoxChange.Location = new System.Drawing.Point(313, 19);
            this.checkBoxChange.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxChange.Name = "checkBoxChange";
            this.checkBoxChange.Size = new System.Drawing.Size(133, 17);
            this.checkBoxChange.TabIndex = 4;
            this.checkBoxChange.Text = "show only new objects";
            this.checkBoxChange.UseVisualStyleBackColor = true;
            this.checkBoxChange.CheckedChanged += new System.EventHandler(this.checkBoxChange_CheckedChanged);
            // 
            // dataGridViewSnapshot
            // 
            this.dataGridViewSnapshot.AllowUserToAddRows = false;
            this.dataGridViewSnapshot.AllowUserToDeleteRows = false;
            this.dataGridViewSnapshot.AllowUserToOrderColumns = true;
            this.dataGridViewSnapshot.AllowUserToResizeRows = false;
            this.dataGridViewSnapshot.AutoGenerateColumns = false;
            this.dataGridViewSnapshot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSnapshot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Snapshot,
            this.Date,
            this.ObjectAllCount,
            this.PrivateBytes,
            this.MemoryEphemeral,
            this.MemoryLargeObject,
            this.Regular,
            this.Reserved,
            this.Other});
            this.dataGridViewSnapshot.ContextMenuStrip = this.contextMenuStripSnapshot;
            this.dataGridViewSnapshot.DataSource = this.bindingSourceSnapshot;
            this.dataGridViewSnapshot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSnapshot.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSnapshot.Name = "dataGridViewSnapshot";
            this.dataGridViewSnapshot.ReadOnly = true;
            this.dataGridViewSnapshot.RowHeadersVisible = false;
            this.dataGridViewSnapshot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSnapshot.Size = new System.Drawing.Size(484, 773);
            this.dataGridViewSnapshot.TabIndex = 5;
            this.dataGridViewSnapshot.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewSnapshot_CellFormatting);
            this.dataGridViewSnapshot.DoubleClick += new System.EventHandler(this.dataGridViewSnapshot_DoubleClick);
            this.dataGridViewSnapshot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewSnapshot_KeyDown);
            this.dataGridViewSnapshot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewSnapshot_MouseDown);
            // 
            // Snapshot
            // 
            this.Snapshot.DataPropertyName = "Position";
            this.Snapshot.HeaderText = "";
            this.Snapshot.Name = "Snapshot";
            this.Snapshot.ReadOnly = true;
            this.Snapshot.Width = 30;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Date.DataPropertyName = "Date";
            dataGridViewCellStyle5.Format = "HH:mm:ss";
            this.Date.DefaultCellStyle = dataGridViewCellStyle5;
            this.Date.HeaderText = "Time";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 55;
            // 
            // ObjectAllCount
            // 
            this.ObjectAllCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ObjectAllCount.DataPropertyName = "ObjectCount";
            dataGridViewCellStyle6.Format = "n0";
            this.ObjectAllCount.DefaultCellStyle = dataGridViewCellStyle6;
            this.ObjectAllCount.HeaderText = "Count";
            this.ObjectAllCount.Name = "ObjectAllCount";
            this.ObjectAllCount.ReadOnly = true;
            this.ObjectAllCount.Width = 60;
            // 
            // PrivateBytes
            // 
            this.PrivateBytes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PrivateBytes.DataPropertyName = "MemoryPrivateBytes";
            dataGridViewCellStyle7.Format = "n0";
            this.PrivateBytes.DefaultCellStyle = dataGridViewCellStyle7;
            this.PrivateBytes.HeaderText = "PrivateBytes";
            this.PrivateBytes.Name = "PrivateBytes";
            this.PrivateBytes.ReadOnly = true;
            this.PrivateBytes.Width = 91;
            // 
            // MemoryEphemeral
            // 
            this.MemoryEphemeral.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MemoryEphemeral.DataPropertyName = "MemoryEphemeral";
            dataGridViewCellStyle8.Format = "n0";
            this.MemoryEphemeral.DefaultCellStyle = dataGridViewCellStyle8;
            this.MemoryEphemeral.HeaderText = "Ephemeral";
            this.MemoryEphemeral.Name = "MemoryEphemeral";
            this.MemoryEphemeral.ReadOnly = true;
            this.MemoryEphemeral.Width = 82;
            // 
            // MemoryLargeObject
            // 
            this.MemoryLargeObject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MemoryLargeObject.DataPropertyName = "MemoryLargeObject";
            dataGridViewCellStyle9.Format = "n0";
            this.MemoryLargeObject.DefaultCellStyle = dataGridViewCellStyle9;
            this.MemoryLargeObject.HeaderText = "LargeObject";
            this.MemoryLargeObject.Name = "MemoryLargeObject";
            this.MemoryLargeObject.ReadOnly = true;
            this.MemoryLargeObject.Width = 90;
            // 
            // Regular
            // 
            this.Regular.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Regular.DataPropertyName = "MemoryRegular";
            dataGridViewCellStyle10.Format = "n0";
            this.Regular.DefaultCellStyle = dataGridViewCellStyle10;
            this.Regular.HeaderText = "Regular";
            this.Regular.Name = "Regular";
            this.Regular.ReadOnly = true;
            this.Regular.Width = 69;
            // 
            // Reserved
            // 
            this.Reserved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Reserved.DataPropertyName = "MemoryReserved";
            dataGridViewCellStyle11.Format = "n0";
            this.Reserved.DefaultCellStyle = dataGridViewCellStyle11;
            this.Reserved.HeaderText = "Reserved";
            this.Reserved.Name = "Reserved";
            this.Reserved.ReadOnly = true;
            this.Reserved.Width = 78;
            // 
            // Other
            // 
            this.Other.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Other.DataPropertyName = "MemoryOther";
            dataGridViewCellStyle12.Format = "n0";
            this.Other.DefaultCellStyle = dataGridViewCellStyle12;
            this.Other.HeaderText = "Other";
            this.Other.Name = "Other";
            this.Other.ReadOnly = true;
            this.Other.Width = 58;
            // 
            // contextMenuStripSnapshot
            // 
            this.contextMenuStripSnapshot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectThisSnapshotToolStripMenuItem,
            this.compareWithThisSnapshotDoubleClickToolStripMenuItem,
            this.deleteThisSnapshotToolStripMenuItem});
            this.contextMenuStripSnapshot.Name = "contextMenuStripSnapshot";
            this.contextMenuStripSnapshot.Size = new System.Drawing.Size(255, 70);
            // 
            // selectThisSnapshotToolStripMenuItem
            // 
            this.selectThisSnapshotToolStripMenuItem.Name = "selectThisSnapshotToolStripMenuItem";
            this.selectThisSnapshotToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.selectThisSnapshotToolStripMenuItem.Text = "Select this Snapshot (DoubleClick)";
            this.selectThisSnapshotToolStripMenuItem.Click += new System.EventHandler(this.selectThisSnapshotToolStripMenuItem_Click);
            // 
            // compareWithThisSnapshotDoubleClickToolStripMenuItem
            // 
            this.compareWithThisSnapshotDoubleClickToolStripMenuItem.Name = "compareWithThisSnapshotDoubleClickToolStripMenuItem";
            this.compareWithThisSnapshotDoubleClickToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.compareWithThisSnapshotDoubleClickToolStripMenuItem.Text = "Compare with this Snapshot";
            this.compareWithThisSnapshotDoubleClickToolStripMenuItem.Click += new System.EventHandler(this.compareWithThisSnapshotDoubleClickToolStripMenuItem_Click);
            // 
            // deleteThisSnapshotToolStripMenuItem
            // 
            this.deleteThisSnapshotToolStripMenuItem.Name = "deleteThisSnapshotToolStripMenuItem";
            this.deleteThisSnapshotToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.deleteThisSnapshotToolStripMenuItem.Text = "Delete this Snapshot";
            this.deleteThisSnapshotToolStripMenuItem.Click += new System.EventHandler(this.deleteThisSnapshotToolStripMenuItem_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 53);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.dataGridViewSnapshot);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.dataGridViewMain);
            this.splitContainerMain.Size = new System.Drawing.Size(1665, 775);
            this.splitContainerMain.SplitterDistance = 486;
            this.splitContainerMain.TabIndex = 7;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(1601, 11);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(67, 29);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoad.Location = new System.Drawing.Point(1529, 11);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(67, 29);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // saveFileDialogSnapshot
            // 
            this.saveFileDialogSnapshot.Filter = "MemoryDiagnostics File|*.mdi";
            this.saveFileDialogSnapshot.Title = "Save your Snapshots";
            // 
            // openFileDialogSnapshot
            // 
            this.openFileDialogSnapshot.Filter = "MemoryDiagnostics File|*.mdi";
            this.openFileDialogSnapshot.Title = "Load your Snapshots";
            // 
            // richTextBoxComment
            // 
            this.richTextBoxComment.Location = new System.Drawing.Point(703, 8);
            this.richTextBoxComment.Name = "richTextBoxComment";
            this.richTextBoxComment.Size = new System.Drawing.Size(356, 36);
            this.richTextBoxComment.TabIndex = 8;
            this.richTextBoxComment.Text = "";
            this.richTextBoxComment.TextChanged += new System.EventHandler(this.richTextBoxComment_TextChanged);
            // 
            // buttonReport
            // 
            this.buttonReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReport.Location = new System.Drawing.Point(1431, 11);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(75, 29);
            this.buttonReport.TabIndex = 9;
            this.buttonReport.Text = "Report";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // saveFileDialogReport
            // 
            this.saveFileDialogReport.Filter = "comma separated value |*.csv";
            this.saveFileDialogReport.Title = "Generate a csv report";
            // 
            // buttonStrings
            // 
            this.buttonStrings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStrings.Location = new System.Drawing.Point(1351, 11);
            this.buttonStrings.Name = "buttonStrings";
            this.buttonStrings.Size = new System.Drawing.Size(75, 29);
            this.buttonStrings.TabIndex = 9;
            this.buttonStrings.Text = "Strings";
            this.buttonStrings.UseVisualStyleBackColor = true;
            this.buttonStrings.Click += new System.EventHandler(this.buttonStrings_Click);
            // 
            // saveFileDialogStrings
            // 
            this.saveFileDialogStrings.Filter = "text file |*.txt";
            this.saveFileDialogStrings.Title = "Write all Strings fom Heap";
            // 
            // saveFileDialogObjects
            // 
            this.saveFileDialogObjects.Filter = "text file |*.txt";
            this.saveFileDialogObjects.Title = "Write Field Info of all Objects";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1671, 831);
            this.Controls.Add(this.buttonStrings);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.richTextBoxComment);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.checkBoxChange);
            this.Controls.Add(this.textBoxObjectFilter);
            this.Controls.Add(this.textBoxProcessFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonNext);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1400, 500);
            this.Name = "MainForm";
            this.Text = "MemoryDiagnostics";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.contextMenuStripMemoryObjects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSnapshot)).EndInit();
            this.contextMenuStripSnapshot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSnapshot)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.BindingSource bindingSourceMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxProcessFilter;
        private System.Windows.Forms.TextBox textBoxObjectFilter;
        private System.Windows.Forms.CheckBox checkBoxChange;
        private System.Windows.Forms.DataGridView dataGridViewSnapshot;
        private System.Windows.Forms.BindingSource bindingSourceSnapshot;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSnapshot;
        private System.Windows.Forms.ToolStripMenuItem compareWithThisSnapshotDoubleClickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectThisSnapshotToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMemoryObjects;
        private System.Windows.Forms.ToolStripMenuItem filterForSelectedTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyObjectNameToolStripMenuItem;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSnapshot;
        private System.Windows.Forms.OpenFileDialog openFileDialogSnapshot;
        private System.Windows.Forms.DataGridViewTextBoxColumn OjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectSizeFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectCountLast;
        private System.Windows.Forms.DataGridViewTextBoxColumn Snapshot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectAllCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrivateBytes;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoryEphemeral;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoryLargeObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Regular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reserved;
        private System.Windows.Forms.DataGridViewTextBoxColumn Other;
        private System.Windows.Forms.RichTextBox richTextBoxComment;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.SaveFileDialog saveFileDialogReport;
        private System.Windows.Forms.Button buttonStrings;
        private System.Windows.Forms.SaveFileDialog saveFileDialogStrings;
        private System.Windows.Forms.ToolStripMenuItem deleteThisSnapshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectOverviewToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogObjects;
        private System.Windows.Forms.ToolStripMenuItem walkTheHeapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInObjectInspectorToolStripMenuItem;
    }
}

