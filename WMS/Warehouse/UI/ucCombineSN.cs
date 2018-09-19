using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse.BLL;
using CIT.MES;
using CIT.Wcf.Utils;
using Common.Helper;

namespace Warehouse.UI
{
    public partial class ucCombineSN : UserControl
    {
        Dictionary<string, int> dicTrvSn = new Dictionary<string, int>();

        private int currentQty = 0;
        public ucCombineSN()
        {
            InitializeComponent();
        }
        string materialcode = string.Empty;
        /// <summary>
        /// 检验主料盘
        /// </summary>
        /// <returns></returns>
        private bool CheckMSn()
        {
            string serialNumber = txtMsn.Text;
            DataTable dt_MainMaterial = Bll_Bllb_StockInfo_tbsi.ValidateSN(serialNumber);
            if (dt_MainMaterial.Rows.Count == 0)
            {
                new PubUtils().ShowNoteNGMsg("主料号不在库或数量为0", 1, grade.OrdinaryError);
                return false;
            }
            materialcode = dt_MainMaterial.Rows[0]["MaterialCode"].ToString();
            currentQty += SqlInput.ChangeNullToInt(dt_MainMaterial.Rows[0]["QTY"], 0);
            lblTotal.Text = currentQty.ToString();
            return true;
        }
        /// <summary>
        /// 校验附料盘
        /// </summary>
        /// <returns></returns>
        private bool CheckFSn(out string result_sn)
        {
            result_sn = string.Empty;
            if (txtMsn.Text == txtFsn.Text)
            {
                new PubUtils().ShowNoteNGMsg("附料盘与主料盘不能相同", 1, grade.OrdinaryError);
                return false;
            }
            string serialnumber = txtFsn.Text;
            DataTable dtval = Bll_Bllb_StockInfo_tbsi.ValidateSN(serialnumber);
            if (dtval.Rows.Count == 0)
            {
                new PubUtils().ShowNoteNGMsg("料盘编码不在库或数量为0", 1, grade.OrdinaryError);
                return false;
            }
            if (materialcode != dtval.Rows[0]["MaterialCode"].ToString())
            {
                new PubUtils().ShowNoteNGMsg("主料盘与该料盘的料号不一致", 1, grade.OrdinaryError);
                return false;
            }
            if (trv_node.Nodes.Find(result_sn, true).Length > 0)
            {
                new PubUtils().ShowNoteNGMsg("该料盘编码已存在", 1, grade.OrdinaryError);
                return false;
            }
            result_sn = dtval.Rows[0]["SerialNumber"].ToString();
            dicTrvSn.Add(result_sn, SqlInput.ChangeNullToInt(dtval.Rows[0]["Qty"], 0));
            currentQty += SqlInput.ChangeNullToInt(dtval.Rows[0]["Qty"], 0);
            lblTotal.Text = currentQty.ToString();
            return true;
        }

        private void txtMsn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (CheckMSn())
                {
                    txtMsn.ReadOnly = true;
                    txtFsn.Focus();
                }
                else
                {
                    txtMsn.Clear();
                }
            }
        }

        private void txtFsn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string serialnumber = string.Empty;
                if (CheckFSn(out serialnumber))
                {
                    TreeNode T_Node = new TreeNode();
                    T_Node.Text = serialnumber;
                    T_Node.Name = serialnumber;
                    trv_node.Nodes.Add(T_Node);
                    txtFsn.Text = string.Empty;
                    txtFsn.Focus();
                }
            }
        }
        /// <summary>
        /// 合盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_combine_Click(object sender, EventArgs e)
        {
            if (txtMsn.Text == string.Empty||txtMsn.ReadOnly==false||trv_node.Nodes.Count==0)
            {
                return;
            }
            if (Bll_Bllb_StockInfo_tbsi.Update_Combine_Action(dicTrvSn, txtMsn.Text.Trim(), materialcode))
            {
                new PubUtils().ShowNoteOKMsg("合盘成功");
                trv_node.Nodes.Clear();
                txtFsn.Text = string.Empty;
                txtMsn.ReadOnly = false;
                txtMsn.Text = string.Empty;
                lblTotal.Text = string.Empty;
                txtFsn.Focus();
            }
        }
    }
}
