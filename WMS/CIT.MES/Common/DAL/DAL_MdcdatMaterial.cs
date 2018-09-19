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
    public class DAL_MdcdatMaterial
    {
        #region 物料条码规则 根据条件进行连接查询
        /// <summary>
        ///物料条码规则 根据条件进行连接查询
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public DataTable GetList(params object[] objs)
        {
            MdcdatMaterial mdcMt = new MdcdatMaterial();
            T_Bllb_keyType_tbkt tbkt = new T_Bllb_keyType_tbkt();
            mdcMt = (MdcdatMaterial)objs[0];
            tbkt = (T_Bllb_keyType_tbkt)objs[1];
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" SELECT TBKM.TBKM_ID,TBKM.TBKT_ID,TBKM.MaterialCode,TBKT.KEY_NAME,TBKT.KEY_TYPE 
		                         FROM 
			                         T_Bllb_keyMaterial_tbkm AS TBKM 			                  
			                         INNER JOIN 
				                        T_Bllb_keyType_tbkt AS TBKT 
		                                 ON TBKM.TBKT_ID=TBKT.TBKT_ID");
            if (mdcMt.MaterialCode != null || tbkt.KeyName != null || tbkt.KeyType != null)
            {
                strSql.Append(" WHERE");
                if (mdcMt.MaterialCode != null)
                {
                    strSql.Append(string.Format(" TBKM.MaterialCode='{0}'", mdcMt.MaterialCode));
                    if (tbkt.KeyName != null)
                        strSql.Append(string.Format(" AND TBKT.KEY_NAME='{0}'", tbkt.KeyName));
                    if (tbkt.KeyType != null)
                        strSql.Append(string.Format(" AND TBKT.KEY_TYPE='{0}'", tbkt.KeyType));
                }
                else if (mdcMt.MaterialCode == null && tbkt.KeyName != null)
                {
                    strSql.Append(string.Format(" TBKT.KEY_NAME='{0}'", tbkt.KeyName));
                    if (tbkt.KeyType != null)
                        strSql.Append(string.Format(" AND TBKT.KEY_TYPE='{0}'", tbkt.KeyType));
                }
                else if (mdcMt.MaterialCode == null && tbkt.KeyName == null && tbkt.KeyType != null)
                    strSql.Append(string.Format(" TBKT.KEY_TYPE='{0}'", tbkt.KeyType));
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        #endregion
        /// <summary>
        /// 查询物料信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT MaterialCode,MaterialName,Spec FROM MdcdatMaterial ");
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 通过料号获得品名与规格
        /// </summary>
        /// <param name="MaterialCode"></param>
        /// <returns></returns>
        public DataTable GetNameAndSpec(string MaterialCode)
        {
            string strSql = string.Format("select MaterialName,Spec,PackagingMin from MdcdatMaterial where MaterialCode ='{0}'", MaterialCode);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询料号对应的条码规则
        /// </summary>
        /// <returns></returns>
        public DataTable GetCodeAndRule(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT TBMB.MaterialCode,TBBR.TBBR_ID,TBBR.RULE_NAME
                               FROM  T_Bllb_materialRule_tbmb AS TBMB                                     
                                 INNER JOIN
                                    T_Bllb_BarcodeRule_tbbr AS TBBR
                                        ON TBMB.TBBR_ID = TBBR.TBBR_ID");
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public bool InsertObj(List<MdcdatMaterial> lstObj)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (MdcdatMaterial _obj in lstObj)
            {
                strSql.Append(string.Format(@"insert into MdcdatMaterial ( MaterialCode,MaterialName,Spec)values('{0}','{1}','{2}')",
                    _obj.MaterialCode, _obj.MaterialName, _obj.Spec));
            }
            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
    }
}
