using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIT.Client;
using System.IO;

namespace CIT.MES.BaseControl
{
    public partial class FrmSetColumns : BaseForm
    {
        public FrmSetColumns()
        {
            InitializeComponent();
        }

        private DataGridView dgv;
        private string FileName;
        public FrmSetColumns(string dgvName, DataGridView dgv, string FileName)
        {
            InitializeComponent();
            this.FileName = FileName;
            lab_tablename.Text = dgvName;
            this.dgv = dgv;
            bool flag = File.Exists(".\\temp\\" + FileName);
            string[] columns = FrmUtils.ReadTempFile(".\\temp\\" + FileName).Split(',');
            for (int i = 0; i < this.dgv.Columns.Count; i++)
            {
                chklist_columnsName.Items.Add(this.dgv.Columns[i].HeaderText);
                if (flag)
                {
                    for (int x = 0; x < columns.Length; x++)
                    {
                        if (columns[x] == this.dgv.Columns[i].HeaderText)
                        {
                            chklist_columnsName.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
                else
                {
                    if (dgv.Columns[i].Visible)
                    {
                        chklist_columnsName.SetItemChecked(i, true);
                    }
                    else
                    {
                        chklist_columnsName.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void chx_selectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_selectAll.Checked)
            {
                for (int i = 0; i < chklist_columnsName.Items.Count; i++)
                {
                    chklist_columnsName.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < chklist_columnsName.Items.Count; i++)
                {
                    chklist_columnsName.SetItemChecked(i, false);
                }
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            StringBuilder stringbuilder = new StringBuilder();
            for (int i = 0; i < this.dgv.Columns.Count; i++)
            {

                for (int x = 0; x < this.chklist_columnsName.Items.Count; x++)
                {
                    if (dgv.Columns[i].HeaderText == this.chklist_columnsName.Items[x].ToString())
                    {
                        if (chklist_columnsName.GetItemChecked(x))
                        {
                            stringbuilder.Append(dgv.Columns[i].HeaderText + ",");
                            this.dgv.Columns[i].Visible = true;
                            break;
                        }
                        else
                        {
                            this.dgv.Columns[i].Visible = false;
                            break;
                        }
                    }
                }
            }
            FrmUtils.WriteNewTempFile(FileName, stringbuilder.ToString());
            this.Close();
        }

    }
}
