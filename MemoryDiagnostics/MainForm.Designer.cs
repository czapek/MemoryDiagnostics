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
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.buttonNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProcessFilter = new System.Windows.Forms.TextBox();
            this.textBoxObjectFilter = new System.Windows.Forms.TextBox();
            this.checkBoxChange = new System.Windows.Forms.CheckBox();
            this.OjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectCountLast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
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
            this.ObjectCount,
            this.ObjectChange,
            this.ObjectCountLast});
            this.dataGridViewMain.DataSource = this.bindingSourceMain;
            this.dataGridViewMain.Location = new System.Drawing.Point(0, 53);
            this.dataGridViewMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.RowTemplate.Height = 24;
            this.dataGridViewMain.Size = new System.Drawing.Size(968, 351);
            this.dataGridViewMain.TabIndex = 0;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(765, 12);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.textBoxProcessFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxProcessFilter.Name = "textBoxProcessFilter";
            this.textBoxProcessFilter.Size = new System.Drawing.Size(206, 20);
            this.textBoxProcessFilter.TabIndex = 3;
            // 
            // textBoxObjectFilter
            // 
            this.textBoxObjectFilter.Location = new System.Drawing.Point(83, 28);
            this.textBoxObjectFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.checkBoxChange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxChange.Name = "checkBoxChange";
            this.checkBoxChange.Size = new System.Drawing.Size(107, 17);
            this.checkBoxChange.TabIndex = 4;
            this.checkBoxChange.Text = "only new Objects";
            this.checkBoxChange.UseVisualStyleBackColor = true;
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
            // ObjectCount
            // 
            this.ObjectCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ObjectCount.DataPropertyName = "ObjectCount";
            this.ObjectCount.HeaderText = "Count";
            this.ObjectCount.Name = "ObjectCount";
            this.ObjectCount.ReadOnly = true;
            this.ObjectCount.Width = 60;
            // 
            // ObjectChange
            // 
            this.ObjectChange.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ObjectChange.DataPropertyName = "ObjectChange";
            this.ObjectChange.HeaderText = "Change";
            this.ObjectChange.Name = "ObjectChange";
            this.ObjectChange.ReadOnly = true;
            this.ObjectChange.Width = 69;
            // 
            // ObjectCountLast
            // 
            this.ObjectCountLast.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ObjectCountLast.DataPropertyName = "ObjectCountLast";
            this.ObjectCountLast.HeaderText = "Last";
            this.ObjectCountLast.Name = "ObjectCountLast";
            this.ObjectCountLast.ReadOnly = true;
            this.ObjectCountLast.Width = 52;
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(446, 12);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(97, 29);
            this.buttonSort.TabIndex = 5;
            this.buttonSort.Text = "Sort ..";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 405);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.checkBoxChange);
            this.Controls.Add(this.textBoxObjectFilter);
            this.Controls.Add(this.textBoxProcessFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.dataGridViewMain);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn OjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectCountLast;
        private System.Windows.Forms.Button buttonSort;
    }
}

