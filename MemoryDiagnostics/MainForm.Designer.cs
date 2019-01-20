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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.buttonNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProcessFilter = new System.Windows.Forms.TextBox();
            this.textBoxObjectFilter = new System.Windows.Forms.TextBox();
            this.checkBoxChange = new System.Windows.Forms.CheckBox();
            this.dataGridViewSnapshot = new System.Windows.Forms.DataGridView();
            this.bindingSourceSnapshot = new System.Windows.Forms.BindingSource(this.components);
            this.Snapshot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoryEphemeral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoryLargeObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Regular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Other = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrivateBytes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectSizeFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectCountLast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSnapshot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSnapshot)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToDeleteRows = false;
            this.dataGridViewMain.AllowUserToOrderColumns = true;
            this.dataGridViewMain.AllowUserToResizeRows = false;
            this.dataGridViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMain.AutoGenerateColumns = false;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OjectName,
            this.ObjectSizeFormat,
            this.ObjectCount,
            this.ObjectChange,
            this.ObjectCountLast});
            this.dataGridViewMain.DataSource = this.bindingSourceMain;
            this.dataGridViewMain.Location = new System.Drawing.Point(527, 53);
            this.dataGridViewMain.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.RowTemplate.Height = 24;
            this.dataGridViewMain.Size = new System.Drawing.Size(1474, 679);
            this.dataGridViewMain.TabIndex = 0;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(765, 12);
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
            // 
            // checkBoxChange
            // 
            this.checkBoxChange.AutoSize = true;
            this.checkBoxChange.Checked = true;
            this.checkBoxChange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxChange.Location = new System.Drawing.Point(313, 19);
            this.checkBoxChange.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxChange.Name = "checkBoxChange";
            this.checkBoxChange.Size = new System.Drawing.Size(107, 17);
            this.checkBoxChange.TabIndex = 4;
            this.checkBoxChange.Text = "only new Objects";
            this.checkBoxChange.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSnapshot
            // 
            this.dataGridViewSnapshot.AllowUserToAddRows = false;
            this.dataGridViewSnapshot.AllowUserToDeleteRows = false;
            this.dataGridViewSnapshot.AllowUserToOrderColumns = true;
            this.dataGridViewSnapshot.AllowUserToResizeRows = false;
            this.dataGridViewSnapshot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewSnapshot.AutoGenerateColumns = false;
            this.dataGridViewSnapshot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSnapshot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Snapshot,
            this.Date,
            this.MemoryEphemeral,
            this.MemoryLargeObject,
            this.Regular,
            this.Other,
            this.PrivateBytes});
            this.dataGridViewSnapshot.DataSource = this.bindingSourceSnapshot;
            this.dataGridViewSnapshot.Location = new System.Drawing.Point(1, 53);
            this.dataGridViewSnapshot.Name = "dataGridViewSnapshot";
            this.dataGridViewSnapshot.ReadOnly = true;
            this.dataGridViewSnapshot.Size = new System.Drawing.Size(521, 679);
            this.dataGridViewSnapshot.TabIndex = 5;
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
            dataGridViewCellStyle11.Format = "HH:mm:ss";
            this.Date.DefaultCellStyle = dataGridViewCellStyle11;
            this.Date.HeaderText = "Time";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 55;
            // 
            // MemoryEphemeral
            // 
            this.MemoryEphemeral.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MemoryEphemeral.DataPropertyName = "MemoryEphemeral";
            dataGridViewCellStyle12.Format = "n0";
            this.MemoryEphemeral.DefaultCellStyle = dataGridViewCellStyle12;
            this.MemoryEphemeral.HeaderText = "Ephemeral";
            this.MemoryEphemeral.Name = "MemoryEphemeral";
            this.MemoryEphemeral.ReadOnly = true;
            this.MemoryEphemeral.Width = 82;
            // 
            // MemoryLargeObject
            // 
            this.MemoryLargeObject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MemoryLargeObject.DataPropertyName = "MemoryLargeObject";
            dataGridViewCellStyle13.Format = "n0";
            this.MemoryLargeObject.DefaultCellStyle = dataGridViewCellStyle13;
            this.MemoryLargeObject.HeaderText = "LargeObject";
            this.MemoryLargeObject.Name = "MemoryLargeObject";
            this.MemoryLargeObject.ReadOnly = true;
            this.MemoryLargeObject.Width = 90;
            // 
            // Regular
            // 
            this.Regular.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Regular.DataPropertyName = "MemoryRegular";
            dataGridViewCellStyle14.Format = "n0";
            this.Regular.DefaultCellStyle = dataGridViewCellStyle14;
            this.Regular.HeaderText = "Regular";
            this.Regular.Name = "Regular";
            this.Regular.ReadOnly = true;
            this.Regular.Width = 69;
            // 
            // Other
            // 
            this.Other.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Other.DataPropertyName = "MemoryOther";
            dataGridViewCellStyle15.Format = "n0";
            this.Other.DefaultCellStyle = dataGridViewCellStyle15;
            this.Other.HeaderText = "Other";
            this.Other.Name = "Other";
            this.Other.ReadOnly = true;
            this.Other.Width = 58;
            // 
            // PrivateBytes
            // 
            this.PrivateBytes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PrivateBytes.DataPropertyName = "MemoryPrivateBytes";
            dataGridViewCellStyle16.Format = "n0";
            this.PrivateBytes.DefaultCellStyle = dataGridViewCellStyle16;
            this.PrivateBytes.HeaderText = "PrivateBytes";
            this.PrivateBytes.Name = "PrivateBytes";
            this.PrivateBytes.ReadOnly = true;
            this.PrivateBytes.Width = 91;
            // 
            // OjectName
            // 
            this.OjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OjectName.DataPropertyName = "ObjectName";
            this.OjectName.HeaderText = "Object";
            this.OjectName.Name = "OjectName";
            this.OjectName.ReadOnly = true;
            this.OjectName.Width = 63;
            // 
            // ObjectSizeFormat
            // 
            this.ObjectSizeFormat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ObjectSizeFormat.DataPropertyName = "ObjectSize";
            dataGridViewCellStyle17.Format = "n0";
            this.ObjectSizeFormat.DefaultCellStyle = dataGridViewCellStyle17;
            this.ObjectSizeFormat.HeaderText = "Bytes";
            this.ObjectSizeFormat.Name = "ObjectSizeFormat";
            this.ObjectSizeFormat.ReadOnly = true;
            this.ObjectSizeFormat.Width = 58;
            // 
            // ObjectCount
            // 
            this.ObjectCount.DataPropertyName = "ObjectCount";
            dataGridViewCellStyle18.Format = "n0";
            this.ObjectCount.DefaultCellStyle = dataGridViewCellStyle18;
            this.ObjectCount.HeaderText = "Count";
            this.ObjectCount.Name = "ObjectCount";
            this.ObjectCount.ReadOnly = true;
            this.ObjectCount.Width = 60;
            // 
            // ObjectChange
            // 
            this.ObjectChange.DataPropertyName = "ObjectChange";
            dataGridViewCellStyle19.Format = "n0";
            this.ObjectChange.DefaultCellStyle = dataGridViewCellStyle19;
            this.ObjectChange.HeaderText = "Change";
            this.ObjectChange.Name = "ObjectChange";
            this.ObjectChange.ReadOnly = true;
            this.ObjectChange.Width = 60;
            // 
            // ObjectCountLast
            // 
            this.ObjectCountLast.DataPropertyName = "ObjectCountLast";
            dataGridViewCellStyle20.Format = "n0";
            this.ObjectCountLast.DefaultCellStyle = dataGridViewCellStyle20;
            this.ObjectCountLast.HeaderText = "Last";
            this.ObjectCountLast.Name = "ObjectCountLast";
            this.ObjectCountLast.ReadOnly = true;
            this.ObjectCountLast.Width = 60;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2003, 733);
            this.Controls.Add(this.dataGridViewSnapshot);
            this.Controls.Add(this.checkBoxChange);
            this.Controls.Add(this.textBoxObjectFilter);
            this.Controls.Add(this.textBoxProcessFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.dataGridViewMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSnapshot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSnapshot)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn OjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectSizeFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectCountLast;
        private System.Windows.Forms.DataGridViewTextBoxColumn Snapshot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoryEphemeral;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoryLargeObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Regular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Other;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrivateBytes;
    }
}

