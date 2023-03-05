namespace DevTool2015
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btnCountProcedures = new System.Windows.Forms.Button();
            this.tbNumProcedures = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.btnDivideObjects = new System.Windows.Forms.Button();
            this.btnWhereRecordUsed = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLoaded = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьФайлСОбъектамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.руководствоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbFileLoaded = new System.Windows.Forms.CheckBox();
            this.btnImportObjects = new System.Windows.Forms.Button();
            this.tbObjectList = new System.Windows.Forms.TextBox();
            this.labelProgress = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(453, 38);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(25, 20);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Visible = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tbFileName
            // 
            this.tbFileName.Enabled = false;
            this.tbFileName.Location = new System.Drawing.Point(125, 38);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(322, 20);
            this.tbFileName.TabIndex = 1;
            // 
            // btnCountProcedures
            // 
            this.btnCountProcedures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCountProcedures.Location = new System.Drawing.Point(12, 464);
            this.btnCountProcedures.Name = "btnCountProcedures";
            this.btnCountProcedures.Size = new System.Drawing.Size(241, 21);
            this.btnCountProcedures.TabIndex = 2;
            this.btnCountProcedures.Text = "Сколько в файле процедур?";
            this.btnCountProcedures.UseVisualStyleBackColor = true;
            this.btnCountProcedures.Visible = false;
            this.btnCountProcedures.Click += new System.EventHandler(this.btnCountProcedures_Click);
            // 
            // tbNumProcedures
            // 
            this.tbNumProcedures.AcceptsReturn = true;
            this.tbNumProcedures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbNumProcedures.Location = new System.Drawing.Point(259, 465);
            this.tbNumProcedures.Name = "tbNumProcedures";
            this.tbNumProcedures.Size = new System.Drawing.Size(48, 20);
            this.tbNumProcedures.TabIndex = 3;
            this.tbNumProcedures.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Папка с объектами";
            // 
            // tbDirectory
            // 
            this.tbDirectory.Enabled = false;
            this.tbDirectory.Location = new System.Drawing.Point(125, 61);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.Size = new System.Drawing.Size(322, 20);
            this.tbDirectory.TabIndex = 5;
            // 
            // btnDivideObjects
            // 
            this.btnDivideObjects.Location = new System.Drawing.Point(11, 125);
            this.btnDivideObjects.Name = "btnDivideObjects";
            this.btnDivideObjects.Size = new System.Drawing.Size(272, 23);
            this.btnDivideObjects.TabIndex = 6;
            this.btnDivideObjects.Text = "Разобрать файл на объекты";
            this.btnDivideObjects.UseVisualStyleBackColor = true;
            this.btnDivideObjects.Click += new System.EventHandler(this.btnDivideObjects_Click);
            // 
            // btnWhereRecordUsed
            // 
            this.btnWhereRecordUsed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWhereRecordUsed.Location = new System.Drawing.Point(12, 435);
            this.btnWhereRecordUsed.Name = "btnWhereRecordUsed";
            this.btnWhereRecordUsed.Size = new System.Drawing.Size(272, 23);
            this.btnWhereRecordUsed.TabIndex = 8;
            this.btnWhereRecordUsed.Text = "Где используется?";
            this.btnWhereRecordUsed.UseVisualStyleBackColor = true;
            this.btnWhereRecordUsed.Click += new System.EventHandler(this.btnWhereRecordUsed_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Файл с объектами";
            // 
            // cbLoaded
            // 
            this.cbLoaded.AutoSize = true;
            this.cbLoaded.Location = new System.Drawing.Point(348, 154);
            this.cbLoaded.Name = "cbLoaded";
            this.cbLoaded.Size = new System.Drawing.Size(131, 17);
            this.cbLoaded.TabIndex = 10;
            this.cbLoaded.Text = "Объекты загружены";
            this.cbLoaded.UseVisualStyleBackColor = true;
            this.cbLoaded.Click += new System.EventHandler(this.cbFileLoaded_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 87);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(295, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(491, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьФайлСОбъектамиToolStripMenuItem,
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // загрузитьФайлСОбъектамиToolStripMenuItem
            // 
            this.загрузитьФайлСОбъектамиToolStripMenuItem.Name = "загрузитьФайлСОбъектамиToolStripMenuItem";
            this.загрузитьФайлСОбъектамиToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.загрузитьФайлСОбъектамиToolStripMenuItem.Text = "Загрузить файл с объектами";
            this.загрузитьФайлСОбъектамиToolStripMenuItem.Click += new System.EventHandler(this.загрузитьФайлСОбъектамиToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(232, 22);
            this.toolStripMenuItem1.Text = "Настройка";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.руководствоToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // руководствоToolStripMenuItem
            // 
            this.руководствоToolStripMenuItem.Name = "руководствоToolStripMenuItem";
            this.руководствоToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.руководствоToolStripMenuItem.Text = "Смотреть справку";
            this.руководствоToolStripMenuItem.Click += new System.EventHandler(this.руководствоToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // cbFileLoaded
            // 
            this.cbFileLoaded.AutoSize = true;
            this.cbFileLoaded.Location = new System.Drawing.Point(348, 131);
            this.cbFileLoaded.Name = "cbFileLoaded";
            this.cbFileLoaded.Size = new System.Drawing.Size(106, 17);
            this.cbFileLoaded.TabIndex = 13;
            this.cbFileLoaded.Text = "Файл загружен";
            this.cbFileLoaded.UseVisualStyleBackColor = true;
            this.cbFileLoaded.Click += new System.EventHandler(this.cbFileLoaded_Click);
            // 
            // btnImportObjects
            // 
            this.btnImportObjects.Location = new System.Drawing.Point(13, 150);
            this.btnImportObjects.Name = "btnImportObjects";
            this.btnImportObjects.Size = new System.Drawing.Size(270, 23);
            this.btnImportObjects.TabIndex = 14;
            this.btnImportObjects.Text = "Импортировать объекты из папки";
            this.btnImportObjects.UseVisualStyleBackColor = true;
            this.btnImportObjects.Click += new System.EventHandler(this.btnImportObjects_Click);
            // 
            // tbObjectList
            // 
            this.tbObjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbObjectList.Location = new System.Drawing.Point(12, 179);
            this.tbObjectList.Multiline = true;
            this.tbObjectList.Name = "tbObjectList";
            this.tbObjectList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbObjectList.Size = new System.Drawing.Size(466, 250);
            this.tbObjectList.TabIndex = 15;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(330, 96);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(0, 13);
            this.labelProgress.TabIndex = 16;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 497);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.tbObjectList);
            this.Controls.Add(this.btnImportObjects);
            this.Controls.Add(this.cbFileLoaded);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cbLoaded);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnWhereRecordUsed);
            this.Controls.Add(this.btnDivideObjects);
            this.Controls.Add(this.tbDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNumProcedures);
            this.Controls.Add(this.btnCountProcedures);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Developers Toolkit";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btnCountProcedures;
        private System.Windows.Forms.TextBox tbNumProcedures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDivideObjects;
        private System.Windows.Forms.Button btnWhereRecordUsed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbLoaded;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьФайлСОбъектамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem руководствоToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbFileLoaded;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.Button btnImportObjects;
        private System.Windows.Forms.TextBox tbObjectList;
        private System.Windows.Forms.Label labelProgress;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

