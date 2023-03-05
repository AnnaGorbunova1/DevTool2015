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
    public partial class WhereUsed : Form
    {
        Toolkit MyToolkit;
        int rectype;
        string SelectedProcedure;

        public WhereUsed(Toolkit p_toolkit)
        {
            MyToolkit = p_toolkit;
            InitializeComponent();
        }

        private void WhereUsed_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if ((MyToolkit != null) && (tbUsedRecord.Text.Trim() != "") && (cbType.SelectedIndex >= 0))
            {
                //tbWhereUsed.Text = MyToolkit.WhereRecordUsed(int.Parse(tbUsedRecord.Text));
                rectype = cbType.SelectedIndex;
                labelProgress.Text = "";
                if (cbProcedures.SelectedIndex >= 0)
                {
                    SelectedProcedure = cbProcedures.SelectedItem.ToString();
                    backgroundWorker2.RunWorkerAsync(MyToolkit);
                }
                else backgroundWorker1.RunWorkerAsync(MyToolkit);
            }
        }

        private void tbUsedRecord_KeyPress(object sender, KeyPressEventArgs e)
       {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var tool = (Toolkit)e.Argument;
            tool.WhereUsed(rectype, int.Parse(tbUsedRecord.Text), (BackgroundWorker)sender);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            labelProgress.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tbWhereUsed.Text = MyToolkit.strWhereUsed;
            //progressBar1.Value = 0;
            //labelProgress.Text = "";
        }

        private void tbUsedRecord_TextChanged(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            labelProgress.Text = "";
        }

        private void FindProcedures()
        {
            string[] PrList;
            PrList = MyToolkit.ProceduresList(rectype, int.Parse(tbUsedRecord.Text));
            //cbProcedures.SelectedText = "";
            cbProcedures.SelectedIndex = -1;
            cbProcedures.Items.Clear(); 
            for (int i = 0; i < PrList.Length; i++)
            {
                cbProcedures.Items.Add(PrList[i]);
            }
        }

        private void tbUsedRecord_Validated(object sender, EventArgs e)
        {
            tbWhereUsed.Text = "";
            //подбираем список процедур, которые есть в этом объекте
            if ((tbUsedRecord.Text.Trim() != "") && (cbType.SelectedIndex >= 0))
            {
                rectype = cbType.SelectedIndex;
                FindProcedures();
            }
        }

        private void cbType_Validated(object sender, EventArgs e)
        {
            tbWhereUsed.Text = "";
            //подбираем список процедур, которые есть в этом объекте
            if ((tbUsedRecord.Text.Trim() != "") && (cbType.SelectedIndex >= 0))
            {
                rectype = cbType.SelectedIndex;
                FindProcedures();
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            var tool = (Toolkit)e.Argument;
            tool.WhereProcedureUsed(rectype, int.Parse(tbUsedRecord.Text), SelectedProcedure, (BackgroundWorker)sender);
        }

        private void cbProcedures_Validated(object sender, EventArgs e)
        {
            //if (cbProcedures.se)
                tbWhereUsed.Text = "";
        }
    }
}
