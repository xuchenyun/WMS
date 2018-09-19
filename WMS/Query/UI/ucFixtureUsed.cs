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

namespace Query.UI
{
    public partial class ucFixtureUsed : UserControl
    {
        /// <summary>
        /// 物料用料表业务操作对象
        /// </summary>
        T_Bllb_materialUsed_tbmu_BLL t_Bllb_materialUsed_tbmu_BLL = new T_Bllb_materialUsed_tbmu_BLL();
        public ucFixtureUsed()
        {
            InitializeComponent();
            dgv_materialUsed.AutoGenerateColumns = false;
        }
        /// <summary>
        /// 查询功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            string strWhere = " Where 1=1";
            if (txt_sfcNo.Text.Trim() != "")//制令单
            {
                strWhere += string.Format(" AND TBPI.SFCNO='{0}'", txt_sfcNo.Text.Trim());
            }
            if (txt_Wocode.Text.Trim() != "")//工单
            {
                strWhere += string.Format(" AND sfc.WoCode='{0}'", txt_Wocode.Text.Trim());
            }
            if (txt_serialNumber.Text.Trim() != "")//产品条码
            {
                strWhere += string.Format(" AND TBPI.SERIAL_NUMBER='{0}'", txt_serialNumber.Text.Trim());
            }
            if (txt_partSN.Text.Trim() != "")//物料SN
            {
                strWhere += string.Format(" AND TBPF.FIXTURE_SN='{0}'", txt_partSN.Text.Trim());
            }        
            if (txt_workTimeMin.Text.Trim() != "")//开始时间
            {
                DateTime time = DateTime.MinValue;//校验输入的时间格式是否正确
                bool b = DateTime.TryParse(txt_workTimeMin.Text, out time);
                if (b == false)
                {
                    MsgBox.Error("请输入正确的时间格式!yyyy-mm-dd");
                    return;
                }
                strWhere += string.Format(" AND TBPF.CREATE_TIME >=convert(datetime,'{0}')", txt_workTimeMin.Text.Trim());
               
            }
            if (txt_workTimeMax.Text.Trim() != "")//结束时间
            {
                DateTime time = DateTime.MinValue;//校验输入的时间格式是否正确
                bool b = DateTime.TryParse(txt_workTimeMax.Text, out time);
                if (b == false)
                {
                    MsgBox.Error("请输入正确的时间格式!yyyy-mm-dd");
                    return;
                }
                strWhere+=string.Format(" AND TBPF.CREATE_TIME <=convert(datetime,'{0}')", txt_workTimeMax.Text.Trim());
            }
            DataTable dt = BLL_Bllb_ProductFixture_tbpf.GetList(strWhere);
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
    }
}
