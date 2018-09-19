using CIT.MES;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.BLL
{
    public class BLL_Bll_TestInfo_tbti
    {
        public static DataTable Select(string strWhere)
        {
            string sqlcmd = string.Format(@"   SELECT a.TBPS_ID,a.TBS_ID, Tbpi.SERIAL_NUMBER,d.WORKSTATION_NAME, a.TEST_ITEM,a.TEST_VALUE,a.TEST_TIME FROM T_Bllb_TestInfo_tbti a
  LEFT JOIN T_Bllb_productStatus_tbps b ON a.TBPS_ID=b.TBPS_ID
  LEFT JOIN T_Bllb_productInfo_tbpi Tbpi ON b.TBPS_ID=Tbpi.TBPS_ID
  LEFT JOIN T_Bllb_station_tbs d ON a.TBS_ID=d.TBS_ID {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, sqlcmd);
        }
    }
}
