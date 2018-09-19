using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIT.Client;
using Query.BLL;
using CIT.MES;
using CIT.Wcf.Utils;

namespace Query.UI
{
    public partial class ucMaterialSurplus : UserControl
    {
        /// <summary>
        /// 物料用料表业务操作对象
        /// </summary>
        T_Bllb_materialUsed_tbmu_BLL t_Bllb_materialUsed_tbmu_BLL = new T_Bllb_materialUsed_tbmu_BLL();
        public ucMaterialSurplus()
        {
            InitializeComponent();
            dgv_materialSurplus.AutoGenerateColumns = false;
        }
        /// <summary>
        /// 查询功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {

            string str_line = string.Empty;
            string msg = string.Empty;
            if (Common.BLL.Bll_Common.GetSysParameter("DZ", "DZ002", ref msg))
            {
                if (msg == "Y")
                {
                    str_line += "and LINE NOT LIKE 'SMT%' ";
                }
            }
            string strWhere1= " Where housecode='003' "+ str_line;
            string strWhere2 = " where 1=1";
            bool isWhere = false;
            if (txt_sfcNo.Text != "")//制令单
            {
                strWhere2 += string.Format(" AND sfc.SFCNO='{0}'", txt_sfcNo.Text.Trim());
                strWhere1 += string.Format(" AND SFCNO='{0}'", txt_sfcNo.Text.Trim());
                isWhere = true;
            }          
            if (txt_partNumber.Text != "")//料号
            {
                strWhere2 += string.Format(" AND tbwb.MaterialCode='{0}'", txt_partNumber.Text.Trim());
                strWhere1 += string.Format(" AND partnumber='{0}'", txt_partNumber.Text.Trim());
                isWhere = true;
            }
            //if(isWhere==false)
            //{
            //    new PubUtils().ShowNoteNGMsg("请输入查询条件",1,grade.OrdinaryError);
            //    return;
            //}
            string strSql = string.Format(@"SELECT sfc.wocode,sfc.sfcno,tbwb.MaterialCode,sdo.qty-isnull(sfc.ActQty*tbwb.BOM_QTY,0) as Surplus_Qty,sdo.qty
FROM SfcDatProduct sfc
left join T_Bllb_wocodeBom_tbwb tbwb on sfc.WoCode=tbwb.WoCode 
right join (SELECT sfcno,partnumber,sum(qty) qty from  mdcdatvstorage  {0}  group by sfcno,partnumber) sdo 
on sdo.sfcno=sfc.sfcno and sdo.partnumber=tbwb.MaterialCode  {1}
group by sfc.wocode,sfc.sfcno,tbwb.MaterialCode,sdo.qty,sfc.ActQty,tbwb.BOM_QTY", strWhere1, strWhere2);
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, strSql.ToString()); 
            dgv_materialSurplus.DataSource = dt;
            new PubUtils().ShowNoteOKMsg("查询完成");
        }
        /// <summary>
        /// 鼠标双击复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_materialUsed_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_materialSurplus, e);
        }
     
    }
}
