using CIT.MES;
using Common.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.UI
{
    public partial class Frm_PrintBoxLable : Form
    {
        public string _lableName = "包装条码";
        public Frm_PrintBoxLable()
        {
            InitializeComponent();
        }

        private void txt_sn_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                string msg = string.Empty;
                if(Bll_PrintInfo.PrintContain_1_Info(txt_sn.Text.Trim(), _lableName, ref msg))
                {
                    new PubUtils().ShowNoteNGMsg(msg, 1,grade.OrdinaryError);
                }
                txt_sn.SelectAll();
            }
        }
    }
}
