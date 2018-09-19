using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CIT.MES.Setting
{
    public partial class ucPrint : UserControl
    {
        [DllImport("winspool.drv")]
        public static extern bool SetDefaultPrinter(String Name); //调用win api将指定名称的打印机设置为默认打印机
        public ucPrint()
        {
            InitializeComponent();
            cbx_print.Text = Common.DefaultPrinter();
            foreach (var item in Common.GetLocalPrinters())
            {
                cbx_print.Items.Add(item);
            }
        }

        private void cbx_print_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbx_print_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SetDefaultPrinter(cbx_print.Text))
            {
                new PubUtils().ShowNoteOKMsg("默认打印机设置成功");
            }
            else
            {
                new PubUtils().ShowNoteNGMsg("默认打印机设置失败",1,grade.OrdinaryError);
            }
        }
    }
}
