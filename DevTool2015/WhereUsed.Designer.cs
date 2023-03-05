namespace DevTool2015
{
    partial class WhereUsed
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
            this.tbUsedRecord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbWhereUsed = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbProcedures = new System.Windows.Forms.ComboBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // tbUsedRecord
            // 
            this.tbUsedRecord.Location = new System.Drawing.Point(102, 40);
            this.tbUsedRecord.Name = "tbUsedRecord";
            this.tbUsedRecord.Size = new System.Drawing.Size(121, 20);
            this.tbUsedRecord.TabIndex = 8;
            this.tbUsedRecord.TextChanged += new System.EventHandler(this.tbUsedRecord_TextChanged);
            this.tbUsedRecord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUsedRecord_KeyPress);
            this.tbUsedRecord.Validated += new System.EventHandler(this.tbUsedRecord_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Номер объекта";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(404, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(135, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbWhereUsed
            // 
            this.tbWhereUsed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWhereUsed.Location = new System.Drawing.Point(15, 66);
            this.tbWhereUsed.Multiline = true;
            this.tbWhereUsed.Name = "tbWhereUsed";
            this.tbWhereUsed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbWhereUsed.Size = new System.Drawing.Size(716, 299);
            this.tbWhereUsed.TabIndex = 12;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(404, 37);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(297, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(707, 43);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(0, 13);
            this.labelProgress.TabIndex = 14;
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Table",
            "Page",
            "Report",
            "Codeunit",
            "Query",
            "XMLport"});
            this.cbType.Location = new System.Drawing.Point(102, 14);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 21);
            this.cbType.TabIndex = 15;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Тип Объекта";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Где используется процедура:";
            // 
            // cbProcedures
            // 
            this.cbProcedures.FormattingEnabled = true;
            this.cbProcedures.Location = new System.Drawing.Point(242, 39);
            this.cbProcedures.Name = "cbProcedures";
            this.cbProcedures.Size = new System.Drawing.Size(145, 21);
            this.cbProcedures.TabIndex = 18;
            this.cbProcedures.SelectedIndexChanged += new System.EventHandler(this.cbProcedures_Validated);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // WhereUsed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 377);
            this.Controls.Add(this.cbProcedures);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tbWhereUsed);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUsedRecord);
            this.Name = "WhereUsed";
            this.Text = "WhereUsed";
            this.Load += new System.EventHandler(this.WhereUsed_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUsedRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbWhereUsed;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbProcedures;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        public System.Windows.Forms.ComboBox cbType;
    }
}