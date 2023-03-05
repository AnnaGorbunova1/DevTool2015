namespace DevTool2015
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbSettingDirectory = new System.Windows.Forms.TextBox();
            this.btnSelectDirectory = new System.Windows.Forms.Button();
            this.cbStartingLoad = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Папка для хранения объектов";
            // 
            // tbSettingDirectory
            // 
            this.tbSettingDirectory.Location = new System.Drawing.Point(15, 34);
            this.tbSettingDirectory.Name = "tbSettingDirectory";
            this.tbSettingDirectory.Size = new System.Drawing.Size(470, 20);
            this.tbSettingDirectory.TabIndex = 1;
            this.tbSettingDirectory.TextChanged += new System.EventHandler(this.tbSettingDirectory_TextChanged);
            // 
            // btnSelectDirectory
            // 
            this.btnSelectDirectory.Location = new System.Drawing.Point(491, 34);
            this.btnSelectDirectory.Name = "btnSelectDirectory";
            this.btnSelectDirectory.Size = new System.Drawing.Size(24, 23);
            this.btnSelectDirectory.TabIndex = 2;
            this.btnSelectDirectory.Text = "...";
            this.btnSelectDirectory.UseVisualStyleBackColor = true;
            this.btnSelectDirectory.Click += new System.EventHandler(this.btnSelectDirectory_Click);
            // 
            // cbStartingLoad
            // 
            this.cbStartingLoad.AutoSize = true;
            this.cbStartingLoad.Location = new System.Drawing.Point(15, 60);
            this.cbStartingLoad.Name = "cbStartingLoad";
            this.cbStartingLoad.Size = new System.Drawing.Size(321, 17);
            this.cbStartingLoad.TabIndex = 3;
            this.cbStartingLoad.Text = "Импортировать файлы из папки при запуске приложения";
            this.cbStartingLoad.UseVisualStyleBackColor = true;
            this.cbStartingLoad.CheckedChanged += new System.EventHandler(this.cbStartingLoad_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 93);
            this.Controls.Add(this.cbStartingLoad);
            this.Controls.Add(this.btnSelectDirectory);
            this.Controls.Add(this.tbSettingDirectory);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSettingDirectory;
        private System.Windows.Forms.Button btnSelectDirectory;
        private System.Windows.Forms.CheckBox cbStartingLoad;
    }
}