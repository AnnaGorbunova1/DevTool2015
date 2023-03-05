using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevTool2015
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnSelectDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                tbSettingDirectory.Text = FBD.SelectedPath;
                Properties.Settings.Default.DirectoryName = FBD.SelectedPath;
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            tbSettingDirectory.Text = Properties.Settings.Default.DirectoryName;
            cbStartingLoad.Checked = Properties.Settings.Default.StartingLoad;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void tbSettingDirectory_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DirectoryName = tbSettingDirectory.Text;
        }

        private void cbStartingLoad_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StartingLoad = cbStartingLoad.Checked;
        }
    }
}
