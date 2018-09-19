using Model;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using CIT.MES;

namespace BaseData.DAL
{
    /// <summary>
    /// 参数明细表（字典明细表）数据层访问类
    /// </summary>
    public partial class T_Sysc_dictionary_tsd_DAL
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 'false' as CHK2, TSD_ID,TSDT_ID,DICT_CODE,DICT_VALUE,SORT,DICT_DESC from T_Sysc_dictionary_tsd ");
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by SORT ");
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="lstAddEntity"></param>
        /// <returns></returns>
        public bool Insert(List<T_Sysc_dictionary_tsd> lstAddEntity)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (T_Sysc_dictionary_tsd tsd in lstAddEntity)
            {
                strSql.Append(string.Format(@"insert into T_Sysc_dictionary_tsd(TSDT_ID,DICT_CODE,DICT_VALUE,DICT_DESC,SORT) values(
                                                '{0}','{1}','{2}','{3}','{4}')", tsd.TSDT_ID, tsd.DICT_CODE, tsd.DICT_VALUE, tsd.DICT_DESC, tsd.SORT));
            }
            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="lstDeleteTsd"></param>
        /// <returns></returns>
        public bool Delete(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Sysc_dictionary_tsd");
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);
            }
            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="lstUpdateTsd"></param>
        /// <returns></returns>
        public bool Update(List<T_Sysc_dictionary_tsd> lstUpdateTsd)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (T_Sysc_dictionary_tsd tsd in lstUpdateTsd)
            {
                strSql.Append(string.Format(@"update T_Sysc_dictionary_tsd set DICT_CODE='{0}',DICT_VALUE='{1}',SORT='{2}',DICT_DESC='{3}' where TSD_ID='{4}'",
                                            tsd.DICT_CODE, tsd.DICT_VALUE, tsd.SORT, tsd.DICT_DESC, tsd.TSD_ID));
            }
            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
    }
}
