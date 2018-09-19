using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Warehouse.BLL;
using CIT.MES;

namespace Warehouse.UI
{
    public partial class ucInventoryCollect : UserControl
    {
        public ucInventoryCollect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            QueryData();
            new PubUtils().ShowNoteOKMsg("查询成功！");
        }
        private void QueryData()
        {
            string strWhere = "where 1=1";
            if (txt_inventoryCode.Text != string.Empty)
            {
                strWhere += string.Format("And A.InventoryCode='{0}'", txt_inventoryCode.Text.Trim());
            }
            if (txt_InventoryNumber.Text != string.Empty)
            {
                strWhere += string.Format("And A.InventoryNumber='{0}'", txt_InventoryNumber.Text.Trim());
            }
            if (txt_PN.Text != string.Empty)
            {
                strWhere += string.Format("And B.PN='{0}'", txt_PN.Text.Trim());
            }
            if (cbo_flag.Text != string.Empty)
            {
                switch (cbo_flag.Text)
                {
                    case "盘盈":
                        strWhere += "And A.Flag='0'";
                        break;
                    case "盘亏":
                        strWhere += "And A.Flag='1'";
                        break;
                    default:
                        break;
                }
            }
            DataTable dtCollectInfo = Bll_Inventory_ti.QueryCollectInfo(strWhere);
            dgv_inventoryManager.DataSource = dtCollectInfo;
        }

        private void dgv_inventoryManager_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_inventoryManager, e);
        }
    }
}
