using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIT.Wcf.Utils;
using CIT.Client;
using CIT.MES;
using Warehouse.BLL;

namespace Warehouse.UI
{
    public partial class ucInventoryManager : UserControl
    {
        public ucInventoryManager()
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
            string strWhere = " Where 1=1";

            if (txt_inventoryCode.Text.Trim() != string.Empty)
            {
                strWhere += string.Format("And A.InventoryCode='{0}'", txt_inventoryCode.Text.Trim());
            }
            if (txt_PN.Text.Trim() != string.Empty)
            {
                strWhere += string.Format(" And A.PN='{0}'", txt_PN.Text.Trim());
            }
            if (cbo_houseName.Text != string.Empty)
            {
                strWhere += string.Format(" And A.HouseCode='{0}'", cbo_houseName.SelectedValue.ToString());
            }
            if (cbo_status.Text != "")
            {
                switch (cbo_status.Text)
                {
                    case "开立":
                        strWhere += "And A.Status='0'";
                        break;
                    case "盘点中":
                        strWhere += "And A.Status='1'";
                        break;
                    case "完成":
                        strWhere += "And A.Status='2'";
                        break;
                    default:
                        break;
                }
            }
            DataTable dt = Bll_Inventory_ti.Select(strWhere);
            dgv_inventory.DataSource = dt;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            Frm_InventoryAdd f = new Frm_InventoryAdd();
            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                QueryData();
                new PubUtils().ShowNoteOKMsg("新增成功");
            }
        }

        /// <summary>
        /// 盘点汇总
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_inventorycollect_Click(object sender, EventArgs e)
        {
            if (dgv_inventory.CurrentRow.Cells["Status"].Value.ToString() != "盘点中")
            {
                MsgBox.Error("仅盘点中的单据可进行汇总!");
                QueryData();
                return;
            }
            //盘点单据号
            string inventoryCode = dgv_inventory.CurrentRow.Cells["InventoryCode"].Value.ToString();
            //获得差异数
            DataTable dt_DifferQty = Bll_Inventory_ti.CalculateDifferQty(inventoryCode);
            //获得盘盈盘亏单号
            string inventoryNumber = Bll_Inventory_ti.GetInventoryNumber();

            foreach (DataRow row in dt_DifferQty.Rows)
            {
                string flag = string.Empty;
                string varDifferQty = string.Empty;
                if (Common.Helper.SqlInput.ChangeNullToInt(row["差异数"], 0) > 0)//盘盈 0
                {
                    flag = "0";
                    varDifferQty = row["差异数"].ToString();
                }
                else if (Common.Helper.SqlInput.ChangeNullToInt(row["差异数"], 0) == 0)//
                {
                    flag = "";
                    varDifferQty = row["差异数"].ToString();
                }
                else if (Common.Helper.SqlInput.ChangeNullToInt(row["差异数"], 0) < 0)//盘亏 1
                {
                    flag = "1";
                    varDifferQty = row["差异数"].ToString();
                }
                //盘点汇总
                if (!Bll_Inventory_ti.Update_Inventory_Status(varDifferQty, inventoryCode, row["PN"].ToString(), flag, inventoryNumber))
                {
                    MsgBox.Error("盘点汇总失败");
                    return;
                }
            }
            //删除未盘料盘的SerialNumber
            Bll_Inventory_ti.DeleteUnInventory(inventoryCode);
            QueryData();//刷新
            new PubUtils().ShowNoteOKMsg("汇总成功");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_inventory.CurrentRow == null)
            {
                MsgBox.Error("请先选中行！");
                return;
            }
            if (dgv_inventory.CurrentRow.Cells["Status"].Value.ToString() != "开立")
            {
                MsgBox.Error("仅【开立】中盘点单可以删除");
                return;
            }
            DialogResult result = MsgBox.Question("确认删除！");
            if (result == DialogResult.OK)
            {
                bool isSucess = Bll_Inventory_ti.Delete(dgv_inventory.CurrentRow.Cells["InventoryCode"].Value.ToString());
                if (isSucess)
                {
                    QueryData();
                    new PubUtils().ShowNoteOKMsg("删除成功！");
                }
            }
        }

        private void ucInventoryManager_Load(object sender, EventArgs e)
        {
            string strSql = "Select Storage_Name,Storage_SN from T_Bllb_Storage_tbs";
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, strSql);
            DataRow dr = dt.NewRow();
            dr["Storage_Name"] = "";
            dr["Storage_SN"] = "-1";
            dt.Rows.InsertAt(dr, 0);
            cbo_houseName.DataSource = dt;
            cbo_houseName.DisplayMember = "Storage_Name";
            cbo_houseName.ValueMember = "Storage_SN";
        }

        private void dgv_inventory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_inventory, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            QueryData();
        }
    }
}
