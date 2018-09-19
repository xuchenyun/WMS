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
    public partial class ucMaterialUsed : UserControl
    {
        /// <summary>
        /// 物料用料表业务操作对象
        /// </summary>
        T_Bllb_materialUsed_tbmu_BLL t_Bllb_materialUsed_tbmu_BLL = new T_Bllb_materialUsed_tbmu_BLL();
        public ucMaterialUsed()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 查询功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            string strWhere = " Where 1=1";
            if (txt_wocode.Text != "")//工单
            {
                strWhere += string.Format(" AND P.WoCode='{0}'", txt_wocode.Text.Trim());
            }
            if (txt_sfcNo.Text != "")//制令单
            {
                strWhere += string.Format(" AND MU.SFCNO='{0}'",txt_sfcNo.Text.Trim());
            }
            if (txt_serialNumber.Text != "")//产品条码
            {
                strWhere += string.Format(" AND MU.SERIALNUMBER='{0}'", txt_serialNumber.Text.Trim());
            }
            if (txt_partSN.Text != "")//物料SN
            {
                strWhere += string.Format(" AND MU.PART_SN='{0}'", txt_partSN.Text.Trim());
            }
            if (txt_workStationSN.Text != "")//工位SN
            {
                strWhere += string.Format(" AND S.WORKSTATION_SN like '{0}%'", txt_workStationSN.Text.Trim());
            }          
            if (cbo_PLName.SelectedValue.ToString() != "")//线别
            {
                strWhere += string.Format(" AND  PL.PLName = '{0}'", cbo_PLName.Text.Trim());
            }           
            if (txt_workTimeMin.Text != "")//开始时间
            {
                DateTime time = DateTime.MinValue;//校验输入的时间格式是否正确
                bool b = DateTime.TryParse(txt_workTimeMin.Text, out time);
                if (b == false)
                {
                    MsgBox.Error("请输入正确的时间格式!yyyy-mm-dd");
                    return;
                }
                strWhere += string.Format(" AND MU.CREATE_TIME >=convert(datetime,'{0}')", txt_workTimeMin.Text.Trim());
               
            }
            if (txt_workTimeMax.Text != "")//结束时间
            {
                DateTime time = DateTime.MinValue;//校验输入的时间格式是否正确
                bool b = DateTime.TryParse(txt_workTimeMax.Text, out time);
                if (b == false)
                {
                    MsgBox.Error("请输入正确的时间格式!yyyy-mm-dd");
                    return;
                }
                strWhere+=string.Format(" AND MU.CREATE_TIME <=convert(datetime,'{0}')", txt_workTimeMax.Text.Trim());
            }
            DataTable dt = t_Bllb_materialUsed_tbmu_BLL.QueryMaterialUsed(strWhere);
            dgv_materialUsed.DataSource = dt;
            lbl_ProductCount.Text = dt.Rows.Count.ToString();
            new PubUtils().ShowNoteOKMsg("查询完成");
        }
        /// <summary>
        /// 鼠标双击复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_materialUsed_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_materialUsed, e);
        }

        private void dtp_workTimeMin_CloseUp(object sender, EventArgs e)
        {
            txt_workTimeMin.Text = dtp_workTimeMin.Text;
        }

        private void dtp_workTimeMax_CloseUp(object sender, EventArgs e)
        {
            txt_workTimeMax.Text = dtp_workTimeMax.Text;
        }

        private void ucMaterialUsed_Load(object sender, EventArgs e)
        {
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, "select distinct * from MdcDatProductLine");
            DataRow dr = dt.NewRow();
            dr["PLName"] = "";
            dr["PLCode"] ="";
            dt.Rows.InsertAt(dr, 0);
            cbo_PLName.DataSource = dt;
            cbo_PLName.DisplayMember = "PLName";
            cbo_PLName.ValueMember = "PLCode";
           
        }
    }
}
