using CIT.Client;
using Query.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Query.UI
{
    public partial class Form_SendToCheck : Form
    {
        DataTable dtBarCode = new DataTable();

        public Form_SendToCheck()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (cboStatus.Text.Trim() == string.Empty)
            {
                MsgBox.Error("请先选择状态!");
                return;
            }
            //查询需要送检的条码
            dtBarCode = BLL_Bllb_StockInfo_tbsi.QuerySendToErCheckBarCode(cboStatus.Text.Trim());
            if (dtBarCode.Rows.Count == 0)
            {
                MsgBox.Error("该状态下无条码!");
                return;
            }
            try
            {
                string strwhere_materialcode = string.Empty;
                if (cboStatus.Text.Trim() == "预警")
                {
                    strwhere_materialcode += string.Format("and dateDiff(month,a.Finally_Time,getDate()) between -7 and 0  and (a.Lock_Flag='0' or a.Lock_Flag is null  or a.Lock_Flag='')");
                }
                else if (cboStatus.Text.Trim() == "超期")
                {
                    strwhere_materialcode += string.Format("and a.Finally_Time <= getDate() and a.Lock_Flag = '2'");
                }
                BLL_Bllb_StockInfo_tbsi.SendToErCheckBarCode(dtBarCode, strwhere_materialcode, cboStatus.Text.Trim());
            }
            catch (Exception ex)
            {
                MsgBox.Error(ex.Message.ToString());
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
