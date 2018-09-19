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
    /// 系统参数表（字典表）数据层访问类
    /// </summary>
    public partial class T_Sysc_dictionaryType_tsdt_DAL
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Query(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select 'false' as CHK, TSDT_ID,D_TYPENAME,D_TYPECODE,D_TYPEDESC from  T_Sysc_dictionaryType_tsdt");
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="tsdt"></param>
        /// <returns></returns>
        public bool Insert(T_Sysc_dictionaryType_tsdt tsdt)
        {
            string strSql = string.Format(@"insert into T_Sysc_dictionaryType_tsdt (TSDT_ID,D_TYPENAME,D_TYPECODE,D_TYPEDESC) values ('{0}','{1}','{2}','{3}')", tsdt.TSDT_ID,
                                        tsdt.D_TYPENAME, tsdt.D_TYPECODE, tsdt.D_TYPEDESC);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="tsdt"></param>
        /// <returns></returns>
        public bool Update(T_Sysc_dictionaryType_tsdt tsdt)
        {
            string strSql = string.Format(@"update T_Sysc_dictionaryType_tsdt set D_TYPENAME='{0}',D_TYPECODE='{1}',D_TYPEDESC='{2}' where TSDT_ID='{3}'",
                                            tsdt.D_TYPENAME, tsdt.D_TYPECODE, tsdt.D_TYPEDESC, tsdt.TSDT_ID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Delete(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Sysc_dictionaryType_tsdt");
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);
            }
            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
    }
}
