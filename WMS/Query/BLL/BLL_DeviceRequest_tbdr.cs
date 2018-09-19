using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.BLL
{
    public class BLL_DeviceRequest_tbdr
    {
        public static DataTable Query(string queryWhere)
        {
            string sql = string.Format(@"
SELECT a.ID,a.SerialNumber,a.DeviceCode,b.WORKSTATION_SN,b.WORKSTATION_NAME,a.JsonText,
CASE IsRequest WHEN 'Y' THEN '是' ELSE  '否' END 'IsRequest' ,a.CreateTime,a.RequestTime,
CASE a.UserID WHEN c.UserID THEN c.UserName END 'UserID'  FROM T_Bllb_DeviceRequest_tbdr  AS a
LEFT JOIN dbo.T_Bllb_station_tbs AS b ON b.WORKSTATION_SN = a.DeviceCode
LEFT JOIN dbo.SysDatUser AS c ON c.UserID = a.UserID  {0}", queryWhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sql);
        }
    }
}
