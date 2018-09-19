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
    /// 物料条码规则表数据层访问类
    /// </summary>
    public class DAL_Bllb_materialRule_tbmb
    {
        /// <summary>
        /// 根据条件进行连接查询
        /// </summary>
        /// <param name="tbmb"></param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT TBMB.TBMR_ID,TBBR.TBBR_ID,TBKT.TBKT_ID,MdcM.MaterialCode,MdcM.MaterialName,MdcM.Spec,TBBR.RULE_NAME,TBKT.KEY_NAME,TBMB.DEFAULT_FLAG 
	                        FROM T_Bllb_materialRule_tbmb AS TBMB 
		                        INNER JOIN MdcdatMaterial AS MdcM 
				                    ON TBMB.MaterialCode=MdcM.MaterialCode 
		                        INNER JOIN  T_Bllb_keyType_tbkt AS TBKT 
				                    ON TBKT.TBKT_ID=TBMB.TBKT_ID
		                        INNER JOIN T_Bllb_BarcodeRule_tbbr AS TBBR 
				                    ON TBBR.TBBR_ID=TBMB.TBBR_ID");
            if (strWhere != string.Empty)
            {
                strSql.Append(strWhere);
            }
            
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTbmrID(T_Bllb_materialRule_tbmb tbmb)
        {
            string strSql = string.Format("SELECT TBMR_ID FROM  T_Bllb_materialRule_tbmb WHERE MaterialCode='{0}' AND TBBR_ID='{1}' ", tbmb.MaterialCode, tbmb.TBBR_ID);
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="tbmb"></param>
        /// <returns></returns>
        public bool InsertEntity(T_Bllb_materialRule_tbmb tbmb)
        {
            string strSql = string.Format("INSERT INTO T_Bllb_materialRule_tbmb (TBBR_ID,MaterialCode,TBKT_ID,DEFAULT_FLAG)VALUES('{0}','{1}','{2}','{3}')", tbmb.TBBR_ID, tbmb.MaterialCode, tbmb.TBKT_ID, tbmb.DEFAULT_FLAG);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="tbmb"></param>
        /// <returns></returns>
        public bool UpdateEntity(T_Bllb_materialRule_tbmb tbmb)
        {
            string strSql = string.Format("UPDATE T_Bllb_materialRule_tbmb SET TBBR_ID = '{0}',MaterialCode='{1}',TBKT_ID='{2}',DEFAULT_FLAG='{3}'  WHERE TBMR_ID='{4}'", tbmb.TBBR_ID, tbmb.MaterialCode, tbmb.TBKT_ID, tbmb.DEFAULT_FLAG, tbmb.TBMR_ID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 更新同一料号的是否默认为否
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="isDefault"></param>
        /// <returns></returns>
        public bool Update_default(string strWhere, string isDefault)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format(@" update T_Bllb_materialRule_tbmb set DEFAULT_FLAG='{0}'", isDefault));
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);
            }
            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="tbmb"></param>
        /// <returns></returns>
        public bool DeleteEntity(List<T_Bllb_materialRule_tbmb> list)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (T_Bllb_materialRule_tbmb tbmb in list)
            {
                strSql.Append(string.Format("DELETE T_Bllb_materialRule_tbmb WHERE TBMR_ID='{0}'", tbmb.TBMR_ID));

            }
            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 存在与否
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable IsExit(string strWhere)
        {
            string strSql = string.Format(" select * from T_Bllb_materialRule_tbmb {0} ", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
