using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIT.MES;
using Query.BLL;
using Model;
using CIT.Client;
using BaseData.BLL;

namespace Query.UI
{
    public partial class ucMaterialLog : UserControl
    {
        public ucMaterialLog()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 查询标签数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            Query();
            new PubUtils().ShowNoteOKMsg("查询成功");
        }
        private void Query()
        {
            string strWhere = " Where 1=1";
            if (txt_serialNumber.Text != string.Empty)
            {
                strWhere += string.Format(" And SerialNumber='{0}'", txt_serialNumber.Text.Trim());
            }
            if (txt_materialCode.Text != string.Empty)
            {
                strWhere += string.Format(" And MaterialCode='{0}'", txt_materialCode.Text.Trim());
            }
            if (cbo_operateType.SelectedValue.ToString() != string.Empty)
            {
                strWhere += string.Format(" AND OperateType='{0}'",cbo_operateType.SelectedValue.ToString());
            }
            DataTable dt_materialLog = BLL_Bllb_MaterialLog_tbml.Select(strWhere);
            dgv_materialLog.DataSource = dt_materialLog;
        }      
       

        private void ucMaterialLog_Load(object sender, EventArgs e)
        {
            DataTable dt = BLL_Bllb_MaterialLog_tbml.BindOperateType();
            DataRow dr = dt.NewRow();
            dr["OperateType"] = string.Empty;
            dr["OperateType"] = string.Empty;
            dt.Rows.InsertAt(dr,0);
            cbo_operateType.DataSource = dt;
            cbo_operateType.DisplayMember = "OperateType";
            cbo_operateType.ValueMember = "OperateType";
        }
        /// <summary>
        /// 双击复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_materialLog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_materialLog, e);
        }
    }
}
