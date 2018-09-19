using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Query.BLL;
using CIT.Client;

namespace Query.UI
{
    public partial class ucDeviceRequestManage : UserControl
    {
        public ucDeviceRequestManage()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            DataBindToRequest();
        }

        private void DataBindToRequest()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", Type.GetType("System.String"));
            dt.Columns.Add("Value", Type.GetType("System.String"));
            dt.Rows.Add(string.Empty, "-1");
            dt.Rows.Add("是", "Y");
            dt.Rows.Add("否", "N");
            cmb_isRequest.DataSource = dt;
            cmb_isRequest.DisplayMember = "Text";
            cmb_isRequest.ValueMember = "Value";
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            try
            {
                QueryData();
                new CIT.MES.PubUtils().ShowNoteOKMsg("查询成功");
            }
            catch
            {
                MsgBox.Error("请输入正确的时间格式=>yyyy-mm-dd");
                return;
            }
        }


        private void QueryData()
        {
            StringBuilder strBild = new StringBuilder(" where 1=1 ");
            if (!string.IsNullOrEmpty(txt_StationSN.Text.Trim()))
            {
                strBild.AppendFormat(" and b.WORKSTATION_SN='{0}'", txt_StationSN.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtSerialNumber.Text.Trim()))
            {
                strBild.AppendFormat(" and a.SerialNumber='{0}'", txtSerialNumber.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txt_TimeMin.Text.Trim()))
            {
                strBild.AppendFormat(" and a.CreateTime>convert(datetime,'{0}')", txt_TimeMin.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txt_TimeMax.Text.Trim()))
            {
                strBild.AppendFormat(" and a.CreateTime<convert(datetime,'{0}')", txt_TimeMax.Text.Trim());
            }
            if (cmb_isRequest.SelectedValue.ToString() != "-1")
            {
                strBild.AppendFormat(" and a.IsRequest='{0}'", cmb_isRequest.SelectedValue.ToString().Trim());
            }
            DataTable dtRequest = BLL_DeviceRequest_tbdr.Query(strBild.ToString());
            dgvData.DataSource = dtRequest;
        }

        private void dtp_TimeMin_CloseUp(object sender, EventArgs e)
        {
            txt_TimeMin.Text = dtp_TimeMin.Text.Trim();
        }

        private void dtp_TimeMax_CloseUp(object sender, EventArgs e)
        {
            txt_TimeMax.Text = dtp_TimeMax.Text.Trim();
        }
    }
}
