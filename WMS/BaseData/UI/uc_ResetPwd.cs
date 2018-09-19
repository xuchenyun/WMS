using CIT.Client;
using CIT.MES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseData.UI
{
    public partial class uc_ResetPwd : UserControl
    {
        public uc_ResetPwd()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (BLL.BLL_SysDatUser.IsExist(string.Format(@" WHERE USERID='{0}' AND PASSWORD='{1}'", PubUtils.uContext.UserID,Common.Helper.Encrypt.Encryption(txt_oldPwd.Text.Trim() + PubUtils.uContext.UserID))))
            {
                if(txt_newPwd.Text.Trim()==string.Empty)
                {
                    new PubUtils().ShowNoteNGMsg("新密码不能为空", 1, grade.OrdinaryError);
                    return;
                }
                else if(txt_newPwd.Text.Trim()!=txt_reNewPwd.Text.Trim())
                {
                    new PubUtils().ShowNoteNGMsg("确认密码与新密码不一致", 1, grade.OrdinaryError);
                    return;
                }
                BLL.BLL_SysDatUser.UpdatePassword(PubUtils.uContext.UserID, txt_newPwd.Text.Trim());
                new PubUtils().ShowNoteOKMsg("密码设置成功");
                txt_newPwd.Text = string.Empty;
                txt_oldPwd.Text = string.Empty;
                txt_reNewPwd.Text = string.Empty;
            }
            else
            {
                new PubUtils().ShowNoteNGMsg("原密码错误", 1, grade.OrdinaryError);
            }
        }
    }
}
