using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CIT.MES.Control
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void lkBlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            string notice = @"    本程序为开源程序。所有代码可以任意复制和使用，请您在使用的时候请保留版权信息，以示对我支持！谢谢！！同时要感谢AnsenYu支持！！！

    如果有任何关于程序方面的问题和意见请联系我！QQ群:47717908 Mail:9658258@qq.com我将会在第一时间内解答您的问题！

    如果您觉得我写的程序不错，欢迎您捐助：
    支付宝：
          帐号：xutongchun@163.com
          姓名：徐春晓
    银行帐号：
          开户行：招商银行苏州园区支行
          帐  号：６２２５  ８８５１  ２３６７  ５８２９
          开户名：徐春晓
          
          开户行：农业银行苏州干将路支行
          帐  号：６２２８４  ８０４０  ０３７８９  ３２９１９
          开户名：徐春晓

    如果您的网站提供本源程序的下载请不要修改此信息！谢谢合作！";
            tbDesc.Text = notice;
        }
    }
}
