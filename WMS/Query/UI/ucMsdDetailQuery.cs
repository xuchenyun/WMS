using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Query.UI
{
    public partial class ucMsdDetailQuery : UserControl
    {
        public ucMsdDetailQuery()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryData();
            new CIT.MES.PubUtils().ShowNoteOKMsg("查询成功");
        }

        private void QueryData()
        {
            StringBuilder strBildWhere = new StringBuilder(" where 1=1 ");
            if (!string.IsNullOrEmpty(txtSerialNumber.Text.Trim()))
            {
                strBildWhere.AppendFormat(" and SerialNumber='{0}'", txtSerialNumber.Text.Trim());
            }
            string sqlcmd = string.Format(@"
SELECT  SerialNumber AS '条码' ,
        Action_Time AS '操作时间' ,
        Expose_Time_Length AS '暴露时长' ,
        Baking_Time_Length AS '烘烤时长' ,
        In_Drying_Time AS '进干燥时间' ,
        Out_Dtying_Time AS '出干燥时间' ,
        Begin_Bake_Time AS '开始烘烤时间' ,
        End_Bake_Time AS '结束烘烤时间' ,
        Open_Time AS '拆封时间' ,
        Close_Time AS '密封时间' ,
        CASE Status
          WHEN '1' THEN '在干燥箱中'
          WHEN '2' THEN '在烘烤中'
          WHEN '3' THEN '正常'
          WHEN '4' THEN '暴露超时'
        END '状态'
FROM    dbo.T_Bllb_MSDDetail_tbmd {0}
ORDER BY Action_Time DESC 
 ", strBildWhere.ToString());
            DataTable dtData = CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sqlcmd);
            dgvData.DataSource = dtData;
        }
    }
}
