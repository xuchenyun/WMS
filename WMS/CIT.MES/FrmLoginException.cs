using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CIT.Client;
using System.Runtime.InteropServices;

namespace CIT.MES
{
    public partial class FrmLoginException : BaseForm
    {
        public FrmLoginException(string text, string info)
        {
            InitializeComponent();
            int SH = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            int SW = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Location = new Point(SW, SH);
            label2.Text = text;
            label3.Text = info;
        }

        private void FrmLoginException_Load(object sender, EventArgs e)
        {
            label2.Left = (this.Width - label2.Width) / 2;
            label3.Left = (this.Width - label3.Width) / 2;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
