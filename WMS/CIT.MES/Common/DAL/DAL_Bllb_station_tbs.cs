using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Model;
using CIT.MES;

namespace Common.DAL
{
    /// <summary>
    /// 工位表数据层操作类
    /// </summary>
    public partial class DAL_Bllb_station_tbs
    {

        /// <summary>
        /// 查询工位信息
        /// </summary>
        /// <param name="tbs"></param>
        /// <returns></returns>
        public DataTable GetStation(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format(@"select t.TBS_ID,m.PLName,t.WORKSTATION_SN,t.WORKSTATION_NAME,t.PLCode,g.GROUP_NAME
		                                      from 
			                                    T_Bllb_station_tbs  as t
		                                     inner join
		                                        MdcDatProductLine as m 
												  on t.PLCode=m.PLCode
											 inner join 
											    T_Bllb_group_tbg as g
												  on g.TBG_ID=t.TBG_ID "));
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Bllb_station_tbs");
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(strSql);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
    }
}
