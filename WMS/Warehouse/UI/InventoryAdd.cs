using CIT.Client;
using CIT.MES;
using Model;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Warehouse.BLL;

namespace Warehouse.UI
{
    public partial class Frm_InventoryAdd : BaseForm
    {
        /// <summary>
        /// 盘点单表实体
        /// </summary>
        T_Inventory_ti obj;
        /// <summary>
        /// 模态窗口形式调用此窗口，此窗口关闭时的返回值
        /// </summary>
        DialogResult result = DialogResult.Cancel;

        public Frm_InventoryAdd()
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
            obj = new T_Inventory_ti();
            if (cbo_houseName.SelectedValue.ToString() != string.Empty)//仓库
            {
                obj.HouseCode = cbo_houseName.SelectedValue.ToString().Trim();
                obj.HouseName = cbo_houseName.Text.Trim();
            }
            if (cbo_areaName.SelectedValue.ToString() != "-1")//库区
            {
                obj.StorageArea = cbo_areaName.SelectedValue.ToString();
            }
            if (cbo_PN.Text.ToString() != string.Empty)//料号
            {
                obj.PN = cbo_PN.Text.ToString().Trim();
            }
            string varMsg = string.Empty;
            bool isSucess = Bll_Inventory_ti.Insert(obj, out varMsg);
            if (isSucess)
            {
                this.result = DialogResult.OK;
                this.Close();
            }
            else
            {
                MsgBox.Error(varMsg);
                return;
            }
        }

        private void Frm_InventoryAdd_Load(object sender, EventArgs e)
        {
            string strSql = "Select Storage_Name,Storage_SN from T_Bllb_Storage_tbs";
            DataTable dt_HouseName = NMS.QueryDataTable(PubUtils.uContext, strSql);
            cbo_houseName.DataSource = dt_HouseName;
            cbo_houseName.DisplayMember = "Storage_Name";
            cbo_houseName.ValueMember = "Storage_SN";


            string strArea = "Select Area_SN,Area_Name from T_Bllb_StorageArea_tbsa";
            DataTable dt_Area = NMS.QueryDataTable(PubUtils.uContext, strArea);
            DataRow dr = dt_Area.NewRow();
            dr["Area_SN"] = "-1";
            dr["Area_Name"] = string.Empty;
            dt_Area.Rows.InsertAt(dr, 0);
            cbo_areaName.DataSource = dt_Area;
            cbo_areaName.DisplayMember = "Area_Name";
            cbo_areaName.ValueMember = "Area_SN";

        }
        /// <summary>
        /// 料号模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbo_PN_TextUpdate(object sender, EventArgs e)
        {
            GetPN();
            cbo_PN.Items.Clear();
            cbo_PN.Items.Add(string.Empty);

            var query_PN = (from PartNumber in lstPN where PartNumber.Contains(cbo_PN.Text.Trim().ToUpper()) select PartNumber).Distinct();
            foreach (var item in query_PN)
            {
                cbo_PN.Items.Add(item.ToString());
            }
            this.cbo_PN.DroppedDown = true;
            Cursor = Cursors.Default;
            this.cbo_PN.SelectionStart = this.cbo_PN.Text.Length;
        }

        /// <summary>
        /// 绑定料号信息的集合
        /// </summary>
        List<string> lstPN = new List<string>();
        /// <summary>
        /// 料号模糊查询
        /// </summary>
        public void GetPN()
        {
            lstPN.Clear();
            DataTable dt = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select distinct MaterialCode from T_Bllb_StockInfo_tbsi");
            foreach (DataRow _dr in dt.Rows)
            {
                lstPN.Add(_dr["MaterialCode"].ToString());
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_InventoryAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = this.result;
        }
    }
}
