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
    public partial class FrmSetName : BaseForm
    {
        public FrmSetName()
        {
            InitializeComponent();
            int SH = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            int SW = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Location = new Point(SW, SH);
        }
        public FrmSetName(string name)
        {
            InitializeComponent();
            int SH = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            int SW = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Location = new Point(SW, SH);
            txt_tmpname.Text = name;
        }
        public string Name = "";
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_tmpname.Text.Trim().Length == 0)
            {
                new PubUtils().ShowNoteNGMsg("模板名称不可为空",1,grade.OrdinaryError); return;
            }
            else
            {
                //去数据库判断是否已经存在当前名称
                DataTable dt = NMS.QueryDataTable(PubUtils.uContext, "   select *from mdcdatbarcodetemplet where name='" + txt_tmpname.Text + "'");
                if (dt != null && dt.Rows.Count == 0)
                {
                    Name = txt_tmpname.Text;
                }
                else
                {
                    new PubUtils().ShowNoteNGMsg("不可创建重复的名称",1,grade.OrdinaryError); return;
                }
            }
            this.DialogResult = DialogResult.Yes;
        }
    }
}
