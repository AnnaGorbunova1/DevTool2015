using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DevTool2015
{
    public partial class Form1 : Form
    {
        //Toolkit toolkit1 = new Toolkit();
        Toolkit toolkit1;
        
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toolkit1 = new Toolkit();
            tbDirectory.Text = Properties.Settings.Default.DirectoryName;
            if (Properties.Settings.Default.StartingLoad)
            {
                //tbObjectList.Text = toolkit1.ImportObjects(tbDirectory.Text);
                //cbLoaded.Checked = (tbObjectList.Text.Trim() != "");
                backgroundWorker2.RunWorkerAsync(toolkit1);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFileName.Text = openFileDialog1.FileName;
                tbDirectory.Text = new DirectoryInfo(tbFileName.Text).Parent.FullName;
            }
            cbLoaded.Checked = false;
            cbFileLoaded.Checked = true;
        }

        private void btnCountProcedures_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Properties.Settings.Default.DirectoryName))
            {
                MessageBox.Show("Настройте папку для выгрузки файлов!");
                return;
            }
            if (tbFileName.Text.Trim() != "")
            {
                StreamReader sr = new StreamReader(tbFileName.Text);
                toolkit1.SetObject(sr.ReadToEnd());
                toolkit1.SetDirectory(Properties.Settings.Default.DirectoryName);
                tbNumProcedures.Text = toolkit1.CountProcedures().ToString();
                try
                {
                    System.Diagnostics.Process.Start(tbDirectory.Text + "\\ProceduresList.txt"); //показываем, что нашли
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось сформировать список: " + ex.Message);
                }
            }
            else
            {
                //тут можно потребовать сначала выбрать файл
                //MessageBox.Show("Выберите файл!");
            }
        }

        private void btnDivideObjects_Click(object sender, EventArgs e)
        {
            if (!cbFileLoaded.Checked)
            {
                MessageBox.Show("Загрузите файл, который нужно разобрать!");
                return;
            }
            if (!Directory.Exists(Properties.Settings.Default.DirectoryName))
            {
                MessageBox.Show("Настройте папку для выгрузки файлов! (меню Файл - Настройка)");
                return;
            }
            if (tbFileName.Text.Trim() != "")
            {

                //Toolkit toolkit1 = new Toolkit();
                string[] Files;
                Files = Directory.GetFiles(Properties.Settings.Default.DirectoryName);
                if (Files.Length != 0)
                {
                    DialogResult rsl = MessageBox.Show("В папке уже содержатся файлы, они будут удалены. Продолжить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // если пользователь нажал кнопку да 
                    if (rsl != DialogResult.Yes)
                    { // выходим из приложения 
                        return;
                    }
                }
                StreamReader sr = new StreamReader(tbFileName.Text);
                toolkit1.SetAllObjects(sr.ReadToEnd());
                toolkit1.SetDirectory(Properties.Settings.Default.DirectoryName);
                tbObjectList.Text = "";
                //toolkit1.DivideObjects();
                backgroundWorker1.RunWorkerAsync(toolkit1);
            }
            else
            {
                //тут можно потребовать сначала выбрать файл
            }
        }

        private void btnWhereRecordUsed_Click(object sender, EventArgs e)
        {
            if (cbLoaded.Checked /* && (tbUsedRecord.Text.Trim() != "") */ )
            {
                Form WhereUsd = new WhereUsed(toolkit1);
                WhereUsd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Объекты не загружены! Либо загрузите файл со всеми объектами, либо импортируйте файлы из папки");
                return;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var tool = (Toolkit)e.Argument;
            //var form = sender as Form1;
            //var b = form.backgroundWorker1;
            
            tool.DivideObjects((BackgroundWorker)sender);
            //b.ReportProgress(1);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            labelProgress.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("Process completed!");
            progressBar1.Value = 0;
            tbObjectList.Text = toolkit1.GetObjectList();
            cbLoaded.Checked = (tbObjectList.Text.Trim() != "");
            labelProgress.Text = "";
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rsl = MessageBox.Show("Вы действительно хотите выйти из приложения?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // если пользователь нажал кнопку да 
            if (rsl == DialogResult.Yes)
            { // выходим из приложения 
                Application.Exit();
            }
        }

        private void загрузитьФайлСОбъектамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFileName.Text = openFileDialog1.FileName;
                //tbDirectory.Text = new DirectoryInfo(tbFileName.Text).Parent.FullName;
                cbLoaded.Checked = false;
                cbFileLoaded.Checked = true;
                tbObjectList.Text = "";
            }
            
        }

        private void cbFileLoaded_Click(object sender, EventArgs e)
        {
            CheckBox chbx = sender as CheckBox;
            chbx.Checked = !chbx.Checked;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //открываем форму для выбора папки
            Form SettingForm = new SettingsForm();
            SettingForm.ShowDialog();
            tbDirectory.Text = Properties.Settings.Default.DirectoryName;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form About = new AboutForm();
            About.ShowDialog(); 
        }

        private void btnImportObjects_Click(object sender, EventArgs e)
        {
            //tbObjectList.Text = toolkit1.ImportObjects(tbDirectory.Text);
            backgroundWorker2.RunWorkerAsync(toolkit1);
            //cbLoaded.Checked = (tbObjectList.Text.Trim() != "");
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            var tool = (Toolkit)e.Argument;
            tool.ImportObjects(tbDirectory.Text, (BackgroundWorker)sender);
        }

        private void руководствоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Смотрите файл Справка, который вы получили вместе с приложением!");
        }
    }
}
