using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Query.UI
{
    public partial class ucMsdQuery : UserControl
    {
        public ucMsdQuery()
        {
            InitializeComponent();
            DataBindToStatus();
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryData();
            new CIT.MES.PubUtils().ShowNoteOKMsg("查询成功");
        }

        void DataBindToStatus()
        {
            DataTable dtStatus = new DataTable();
            dtStatus.Columns.Add("value", Type.GetType("System.String"));
            dtStatus.Columns.Add("text", Type.GetType("System.String"));
            DataRow row = dtStatus.NewRow();
            row["value"] = "1";
            row["text"] = "拆封";
            dtStatus.Rows.Add(row);

            row = dtStatus.NewRow();
            row["value"] = "2";
            row["text"] = "密封";
            dtStatus.Rows.Add(row);

            row = dtStatus.NewRow();
            row["value"] = "3";
            row["text"] = "进干燥箱";
            dtStatus.Rows.Add(row);

            row = dtStatus.NewRow();
            row["value"] = "4";
            row["text"] = "出干燥箱";
            dtStatus.Rows.Add(row);

            row = dtStatus.NewRow();
            row["value"] = "5";
            row["text"] = "开始烘烤";
            dtStatus.Rows.Add(row);

            row = dtStatus.NewRow();
            row["value"] = "6";
            row["text"] = "结束烘烤";
            dtStatus.Rows.Add(row);

            row = dtStatus.NewRow();
            row["value"] = "7";
            row["text"] = "暴露超时";
            dtStatus.Rows.Add(row);

            row = dtStatus.NewRow();
            row["value"] = "8";
            row["text"] = "报废";
            dtStatus.Rows.Add(row);

            row = dtStatus.NewRow();
            row["value"] = "-1";
            row["text"] = string.Empty;
            dtStatus.Rows.InsertAt(row, 0);

            cmb_status.DataSource = dtStatus;
            cmb_status.DisplayMember = "text";
            cmb_status.ValueMember = "value";
        }

        private void QueryData()
        {
            StringBuilder strbid_where = new StringBuilder(" where 1=1 ");
            if (!string.IsNullOrEmpty(txtSerialNumber.Text.Trim()))
            {
                strbid_where.AppendFormat(" and a.SerialNumber = '{0}'", txtSerialNumber.Text.Trim());
            }
            if (cmb_status.SelectedValue.ToString() != "-1")
            {
                strbid_where.AppendFormat(" and a.Status = '{0}'", cmb_status.SelectedValue.ToString());
            }
            string strSqlQuery = string.Format(@"
SELECT  a.SerialNumber AS '条码' ,
        a.OpenNum AS '拆封次数' ,
        a.MaterialCode AS '料号' ,
        b.Bake_OrderNumber AS '烘烤序号' ,
        CASE b.IsEnable
          WHEN '0' THEN '不可用'
          WHEN '1' THEN '可用'
          ELSE '不可用'
        END AS '是否可用', 
        CASE a.Status
          WHEN '1' THEN '拆封'
          WHEN '2' THEN '密封'
          WHEN '3' THEN '进干燥箱'
          WHEN '4' THEN '出干燥箱'
          WHEN '5' THEN '开始烘烤'
          WHEN '6' THEN '结束烘烤'
          WHEN '7' THEN '暴露超时'
          WHEN '8' THEN '报废'
        END '状态' ,
        b.Expose_Time_Length AS '暴露时长(分钟)' ,
        b.Baking_Time_Length AS '烘烤时长(分钟) ' ,
        b.LifeCycle AS '生命周期(分钟)' ,
        b.Dry_time_length AS '干燥时长(分钟)',
        b.In_Drying_Time AS '进干燥箱时间' ,
        b.Out_Dtying_Time AS '出干燥箱时间' ,
        b.Begin_Bake_Time AS '开始烘烤时间' ,
        b.End_Bake_Time AS '结束烘烤时间' ,
        b.Open_Time AS '拆封时间' ,
        b.Close_Time AS '密封时间' ,  
        a.Remark AS '备注'  
FROM    dbo.T_Bllb_MSDMain_tbmm AS a
        LEFT JOIN dbo.T_Bllb_MSDResult_tbmr AS b ON a.SerialNumber = b.SerialNumber {0}", strbid_where.ToString());
            DataTable dtData = CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, strSqlQuery);
            dgvData.DataSource = dtData;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            QueryData();
        }
    }
}
