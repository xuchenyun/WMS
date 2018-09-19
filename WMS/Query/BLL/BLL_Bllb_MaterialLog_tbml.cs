using CIT.MES;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData.BLL
{
    public class BLL_Bllb_MaterialLog_tbml
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static  DataTable Select(string strWhere)
        {
            string strSql = string.Format(@"select a.SerialNumber,a.MaterialCode,a.OperateType, a.QTY,b.UserName, a.CreateTime,a.Memo,c.WoCode from T_Bllb_MaterialLog_tbml a
                LEFT JOIN dbo.SfcDatProduct c ON a.SfcNo=c.SfcNo
				left join sysdatuser b on a.Creator=b.UserID  {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 绑定操作名称
        /// </summary>
        /// <returns></returns>
        public static DataTable BindOperateType()
        {
            string strSql = string.Format("select distinct OperateType from T_Bllb_MaterialLog_tbml");
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
