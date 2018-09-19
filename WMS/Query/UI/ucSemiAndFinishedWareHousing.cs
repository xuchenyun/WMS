using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Query.DAL;

namespace Query.UI
{
    public partial class ucSemiAndFinishedWareHousing : UserControl
    {
        public ucSemiAndFinishedWareHousing()
        {
            InitializeComponent();            
        }

        private void ucSemiAndFinishedWareHousing_Load(object sender, EventArgs e)
        {
            this.cbo_BillType.SelectedValue = "成品入库单";
            cbo_BillType.Items.Add("半成品入库单");
            cbo_BillType.SelectedIndex = 0;
            cbo_BillType.Items.Add("成品入库单");
            cbo_BillType.SelectedIndex = 1;
            //DataBind();
        }

        public string QueryBarCode()
        {
            string strWhere = " Where 1=1";
            //单据号
            if (txt_BillNo.Text != string.Empty)
            {
                strWhere += string.Format(" AND No='{0}'", txt_BillNo.Text.Trim());
            }
            //入库单号
            if (txt_InstockNo.Text != string.Empty)
            {
                strWhere += string.Format(" AND InstockNo='{0}'", txt_InstockNo.Text.Trim());
            }
            //单据类型
            if (cbo_BillType.SelectedItem.ToString() != string.Empty)
            {
                strWhere += string.Format(" ANd BillType='{0}'", cbo_BillType.SelectedItem.ToString());
            }
            //时间（从）
            if (!string.IsNullOrEmpty(dtp_TimeMin.Text.Trim()))
            {
                strWhere += string.Format(" and CreateTime>=CONVERT(DATETIME,'{0}')", dtp_TimeMin.Text.Trim());
            }
            //结束时间（到）
            if (!string.IsNullOrEmpty(dtp_TimeMax.Text.Trim()))
            {
                strWhere += string.Format(" and CreateTime<=CONVERT(DATETIME,'{0}')", dtp_TimeMax.Text.Trim());
            }
            return strWhere;
        }

        public string QueryInStockRows()
        {
            string strWhere = " Where 1=1";
            //单据号
            if (txt_BillNo.Text != string.Empty)
            {
                strWhere += string.Format(" AND No='{0}'", txt_BillNo.Text.Trim());
            }           
            return strWhere;
        }

        public string InStockRowDetails()
        {
            string strWhere = " Where 1=1";
            //单据号
            if (txt_BillNo.Text != string.Empty)
            {
                strWhere += string.Format(" AND BillNo='{0}'", txt_BillNo.Text.Trim());
            }
                        
            //时间（从）
            if (!string.IsNullOrEmpty(dtp_TimeMin.Text.Trim()))
            {
                strWhere += string.Format(" and CreateTime>=CONVERT(DATETIME,'{0}')", dtp_TimeMin.Text.Trim());
            }
            //结束时间（到）
            if (!string.IsNullOrEmpty(dtp_TimeMax.Text.Trim()))
            {
                strWhere += string.Format(" and CreateTime<=CONVERT(DATETIME,'{0}')", dtp_TimeMax.Text.Trim());
            }
            return strWhere;
        }

        private void DataBind()
        {
            //绑定表1
            string strWhere1 = QueryBarCode();
            DataTable dt1 = Wms_T_InStockDAL.Query(strWhere1);
            dgv_barCode.DataSource = dt1;
            //绑定表2
            string strWhere2 = QueryInStockRows();
            DataTable dt2 = Wms_T_InStockRows_DAL.Query(strWhere2);
            dgv_InStockRows.DataSource = dt2;
            //绑定表3
            string strWhere3 = InStockRowDetails();
            DataTable dt3 = Wms_T_InStockRowDetails_DAL.Query(strWhere3);
            dgv_InStockRowDetails.DataSource = dt3;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            DataBind();
        }
        
    }
}
