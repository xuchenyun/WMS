using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIT.Client;
using CIT.Wcf.Utils;

namespace CIT.MES.BarCode.Control
{
    public partial class FrmSelTemplet : BaseForm
    {
        public FrmSelTemplet()
        {
            InitializeComponent();
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, "select ROW_NUMBER() over (order by createtime desc) as '序号',Name as '模板名称' from MdcdatBarcodeTemplet");
            dataGridView1.DataSource = dt;
        }
        public byte[] Val;
        public string Name = "";
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = null;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                dr = (dataGridView1.SelectedRows[i].DataBoundItem as DataRowView).Row;
                if (dr != null)
                {
                    DataTable dt = NMS.QueryDataTable(PubUtils.uContext, "select * from mdcdatbarcodetemplet where name='" + dr["模板名称"].ToString() + "'");
                    if (dt.Rows.Count > 0)
                    {
                        Val = (byte[])dt.Rows[0]["context"];
                        Name = dt.Rows[0]["name"].ToString();
                        this.DialogResult = DialogResult.Yes;
                    }
                    else
                    {
                        new PubUtils().ShowNoteNGMsg("请刷新模板列表",1,grade.OrdinaryError);
                    }
                }
            }
        }
    }
}
