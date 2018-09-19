using Model;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CIT.MES;

namespace Query.DAL
{
    /// <summary>
    /// 过站统计数据层访问类
    /// </summary>
    public class T_Bllb_groupStatistics_tbgs_DAL
    {
        /// <summary>
        /// 查询过站统计数据
        /// </summary>
        /// <param name="tbgs"></param>
        /// <returns></returns>
        public DataTable GetTbgs(T_Bllb_groupStatistics_tbgs tbgs)
        {
            string strSql = string.Format(@"SELECT T.SfcNo,T.TBTG_ID,G.GROUP_NAME,T.PASS_NUM,T.ERROR_NUM
,SUM(CASE P.LAST_FLAG WHEN 'Y' THEN 1 ELSE 0 END) WIP_QTY
                              FROM T_Bllb_groupStatistics_tbgs T
                                  LEFT JOIN T_Bllb_technologyGroup_tbtg M ON M.TBTG_ID=T.TBTG_ID
                                  LEFT JOIN T_Bllb_group_tbg G ON M.TBG_ID=G.TBG_ID								 
                                  LEFT JOIN T_Bllb_productStatus_tbps S ON T.TBTG_ID=S.WIP_TBTG_ID AND T.SfcNo=S.SfcNo
								  LEFT JOIN T_Bllb_productInfo_tbpi P ON T.SfcNo=P.SfcNo AND S.TBPS_ID=P.TBPS_ID
                               WHERE T.SfcNo='{0}'
							   GROUP BY T.SfcNo,T.TBTG_ID,G.GROUP_NAME,T.PASS_NUM,T.ERROR_NUM", tbgs.SfcNo);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
