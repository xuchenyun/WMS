using CIT.MES;
using CIT.Wcf.Utils;
using Common.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.BLL
{
    public static class Bll_Bllb_productInfo_tbpi
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Query(string strWhere)
        {
            string strSql = string.Format(@"select s.WoCode,i.SfcNo as SFC_NO ,i.SERIAL_NUMBER as SN,i.Qty,i.INOUT_STATUS,i.TBPS_ID,'产品SN' as SN_TYPE  
                                            from T_Bllb_productInfo_tbpi as i 
                                            left join SfcDatProduct as s on i.SfcNo = s.SfcNo  {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 更新产品状态
        /// </summary>
        /// <param name="lstTBPSID"></param>
        /// <param name="statusValue"></param>
        /// <returns></returns>
        public static bool Update_INOUT_STATUS(List<T_Bllb_inOutLog_tbiol> lstTbiol, string statusValue)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (var tbiol in lstTbiol)
            {
                strSql.Append(string.Format(@"update T_Bllb_productInfo_tbpi set INOUT_STATUS='{0}' where TBPS_ID='{1}'", statusValue, tbiol.TBPS_ID));
            }
            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 更新产品状态
        /// </summary>
        /// <param name="TBPS_ID"></param>
        /// <param name="statusValue"></param>
        /// <returns></returns>
        public static bool Update_INOUT_STATUS(string TBPS_ID, string statusValue)
        {
            string strSql = string.Format(@"update T_Bllb_productInfo_tbpi set INOUT_STATUS='{0}' where TBPS_ID='{1}'", statusValue, TBPS_ID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }

        /// <summary>
        /// 通过关键件找到产品条码
        /// </summary>
        /// <param name="KeySN"></param>
        /// <returns></returns>
        public static string GetSerialNumberByKeySN(string KeySN)
        {
            string strSql = string.Format(@"SELECT tbpi.SERIAL_NUMBER FROM T_Bllb_productInfo_tbpi tbpi left join T_Bllb_productKey_tbpk tbpk
on tbpi.TBPS_ID=tbpk.TBPS_ID  WHERE tbpk.KEY_SN='{0}'", KeySN);
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                return SqlInput.ChangeNullToString(dt.Rows[0][0]);
            }
            else
            {
                return string.Empty;
            }
        }
      
          
        
    }
}
