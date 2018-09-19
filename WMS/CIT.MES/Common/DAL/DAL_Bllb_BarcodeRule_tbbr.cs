using Model;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CIT.MES;

namespace Common.DAL
{
    /// <summary>
    /// 条码规则表数据层访问类
    /// </summary>
    public class DAL_T_Bllb_BarcodeRule_tbbr
    {
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool DeleteList(List<T_Bllb_BarcodeRule_tbbr> list)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (T_Bllb_BarcodeRule_tbbr tbbr in list)
            {
                strSql.Append(string.Format("DELETE T_Bllb_BarcodeRule_tbbr WHERE TBBR_ID='{0}'", tbbr.TBBR_ID));
            }
            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="tbbr"></param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT TBBR_ID,RULE_NAME,SN_LENGTH,SN_BEGIN,SAME_STRING,SAME_STRING_BEGIN,
                                            MATERIAL_FLAG,MATERIAL_LENGTH,MATERIAL_CODE_BEGIN,IS_CHECK_SN_LENGTH,IS_CHECK_SAME_STRING
                                                    FROM T_Bllb_BarcodeRule_tbbr");

            if (strWhere != string.Empty)
            {
                strSql.Append(" where" + strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="tbbr"></param>
        /// <returns></returns>
        public bool InsertEntity(T_Bllb_BarcodeRule_tbbr tbbr)
        {
            string strSql = string.Format(@"INSERT INTO T_Bllb_BarcodeRule_tbbr (RULE_NAME,SN_LENGTH,SN_BEGIN,SAME_STRING,SAME_STRING_BEGIN,
                           MATERIAL_FLAG,MATERIAL_CODE_BEGIN,MATERIAL_LENGTH,IS_CHECK_SN_LENGTH,IS_CHECK_SAME_STRING) VALUES
                            ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", tbbr.RULE_NAME, tbbr.SN_LENGTH, tbbr.SN_BEGIN,tbbr.SAME_STRING, tbbr.SAME_STRING_BEGIN,
                             tbbr.MATERIAL_FLAG, tbbr.MATERIAL_CODE_BEGIN, tbbr.MATERIAL_LENGTH,tbbr.IS_CHECK_SN_LENGTH,tbbr.IS_CHECK_SAME_STRING);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="tbbr"></param>
        /// <returns></returns>
        public bool UpdateEntity(T_Bllb_BarcodeRule_tbbr tbbr)
        {
            string strSql = string.Format(@"UPDATE T_Bllb_BarcodeRule_tbbr SET RULE_NAME='{0}',SN_LENGTH='{1}',SAME_STRING='{2}',SAME_STRING_BEGIN='{3}',
                                                                               MATERIAL_FLAG='{4}',MATERIAL_CODE_BEGIN='{5}',SN_BEGIN='{6}',MATERIAL_LENGTH='{7}',IS_CHECK_SN_LENGTH='{8}',IS_CHECK_SAME_STRING='{9}' WHERE TBBR_ID='{10}'",
                                                                               tbbr.RULE_NAME, tbbr.SN_LENGTH, tbbr.SAME_STRING, tbbr.SAME_STRING_BEGIN,
                                                                                tbbr.MATERIAL_FLAG, tbbr.MATERIAL_CODE_BEGIN, tbbr.SN_BEGIN,tbbr.MATERIAL_LENGTH,tbbr.IS_CHECK_SN_LENGTH,tbbr.IS_CHECK_SAME_STRING, tbbr.TBBR_ID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 获得初始化条码规则下拉框的数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetInitData(T_Bllb_BarcodeRule_tbbr tbbr)
        {
            string strSql = string.Empty;
            if (tbbr.TBBR_ID != null)
                strSql = string.Format("SELECT TBBR_ID,RULE_NAME FROM T_Bllb_BarcodeRule_tbbr WHERE TBBR_ID='{0}'", tbbr.TBBR_ID);
            else
                strSql = "SELECT TBBR_ID,RULE_NAME FROM T_Bllb_BarcodeRule_tbbr";
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 根据条码规则ID（TBBR_ID）获得tbmr_Id
        /// </summary>
        /// <param name="tbbr"></param>
        /// <returns></returns>
        public DataTable GetTbmrId(T_Bllb_BarcodeRule_tbbr tbbr)
        {
            string strSql = string.Format(@"SELECT tbmb.TBMR_ID FROM T_Bllb_BarcodeRule_tbbr AS TBBR 
                                              INNER JOIN 
                                                   T_Bllb_materialRule_tbmb  AS TBMB 
	                                               on TBBR.TBBR_ID=TBMB.TBBR_ID
	                                               WHERE TBBR.TBBR_ID='{0}'", tbbr.TBBR_ID);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
