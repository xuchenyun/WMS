using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIT.Client;

namespace CIT.MES.Setting
{
    public partial class FrmSetting : BaseForm
    {

        SysSetting setting;
        public FrmSetting()
        {
            InitializeComponent();
            int SH = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            int SW = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Location = new Point(SW, SH);

            setting = new SysSetting();

            chbIsCheckErpWoState.Checked = setting.IsCheckErpWoState;
            txtMSlotCut.Text = setting.MSlotCut.ToString();



            tabPage1.Controls.Clear();
            ucPrint ucprint = new ucPrint();
            tabPage1.Controls.Add(ucprint);
            ucprint.Dock = DockStyle.Fill;
            ucprint.Show();
        }

        private void BtnInitialize_Click(object sender, EventArgs e)
        {
            if (CIT.Client.MsgBox.Question("确定是否初始化货架") == DialogResult.OK)
            {
                if (CIT.Client.MsgBox.Question("确定是否初始化货架") == DialogResult.OK)
                {
                    if (!CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, @"update MdcDatVStorage set LockStatus=0 where LockStatus=1"))
                    {
                        new PubUtils().ShowNoteNGMsg("初始化货架失败", 2, grade.OrdinaryError);
                        return;
                    }
                    new PubUtils().ShowNoteOKMsg("初始化货架完成");
                }
            }
        }

        #region 2017.06.14 by simon.li 新增常规设置
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMSlotCut.Text.Length != 1)
            {
                CIT.Client.MsgBox.Error("请设置【料站表分割符】");
                return;
            }

            setting.IsCheckErpWoState = chbIsCheckErpWoState.Checked;
            setting.MSlotCut = txtMSlotCut.Text[0];

            setting.Save();
            CIT.Client.MsgBox.Info("保存成功");
        }
        #endregion
    }
}
