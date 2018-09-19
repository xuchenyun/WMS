using CIT.MES;
using CIT.Wcf.Utils;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Common.BLL
{
    public class Bll_Common
    {
        #region 条码规则
        /// <summary>
        /// 校验容器条码规则
        /// </summary>
        /// <param name="ruleName">规则名称</param>
        /// <param name="ContainerSN">容器SN</param>
        /// <param name="productCode">容器内产品的产品代码</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool CheckContainerSNRule(string ruleName, string ContainerSN, string productCode, ref string msg)
        {
            string strSql = string.Format(@"SELECT IS_CHECK_SN_LENGTH, SN_LENGTH,IS_CHECK_SAME_STRING,SAME_STRING,SAME_STRING_BEGIN,
MATERIAL_FLAG,MATERIAL_LENGTH,MATERIAL_CODE_BEGIN,SN_BEGIN FROM T_Bllb_barcodeRule_tbbr T WHERE T.RULE_NAME ='{0}'", ruleName);
            DataTable dt_Rule = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
            if (dt_Rule.Rows.Count > 0)
            {
                //检验长度
                if (SqlInput.ChangeNullToString(dt_Rule.Rows[0]["IS_CHECK_SN_LENGTH"]) == "Y" & SqlInput.ChangeNullToInt(dt_Rule.Rows[0]["SN_LENGTH"], 0) != ContainerSN.Length)
                {
                    msg = "容器条码长度不正确";
                    return false;
                }
                //校验固定字符
                if (SqlInput.ChangeNullToString(dt_Rule.Rows[0]["IS_CHECK_SAME_STRING"]) == "Y")
                {
                    string sameString = SqlInput.ChangeNullToString(dt_Rule.Rows[0]["SAME_STRING"]);
                    int length = sameString.Length;
                    int begin = SqlInput.ChangeNullToInt(dt_Rule.Rows[0]["SAME_STRING_BEGIN"], 0) - 1;//数据库保存是从1开始，实际中位置编号是从0开始，故要减1
                    if (ContainerSN.Substring(begin, length) != sameString)
                    {
                        msg = "容器条码的固定字符不正确";
                        return false;
                    }
                }
                //校验产品代码
                if (SqlInput.ChangeNullToString(dt_Rule.Rows[0]["MATERIAL_FLAG"]) != "0")
                {
                    int length = SqlInput.ChangeNullToInt(dt_Rule.Rows[0]["MATERIAL_LENGTH"], 0);
                    int m_begin = SqlInput.ChangeNullToInt(dt_Rule.Rows[0]["MATERIAL_CODE_BEGIN"], 0) - 1;
                    int sn_begin = SqlInput.ChangeNullToInt(dt_Rule.Rows[0]["SN_BEGIN"], 0) - 1;
                    if (ContainerSN.Substring(sn_begin, length) != productCode.Substring(m_begin, length))
                    {
                        msg = "容器条码中的产品代码不正确";
                        return false;
                    }
                }

            }

            return true;
        }
        /// <summary>
        /// 汇总工单条码规则
        /// </summary>
        /// <param name="woCode"></param>
        /// <returns></returns>
        public static bool DealWoCodeRule(string woCode)
        {
            //删除工单解析中的条码规则
            string strSql = string.Format(@" DELETE FROM T_Bllb_projectRule_tbpr WHERE WoCode='{0}'", woCode);
            CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
            //获取产品条码规则
            strSql = string.Format(@"SELECT sfc.WoCode,sfc.SFCNO,sfc.Product,KM.MaterialCode,KM.TBKT_ID FROM 
 SfcdatProduct sfc left join T_Bllb_wocodeBom_tbwb WB  on sfc.wocode=wb.wocode
LEFT JOIN T_Bllb_keyMaterial_tbkm KM ON WB.MaterialCode=KM.MaterialCode 
WHERE sfc.WOCODE='{0}'", woCode);
            DataTable dt_sfc = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
            if (dt_sfc.Rows.Count == 0)
            {
                return false;
            }
            //指令单条码规则
            strSql = string.Format(@"INSERT INTO T_Bllb_projectRule_tbpr(WoCode,TBMR_ID,TBKT_ID,MaterialCode)
SELECT sfc.WoCode,SMR.TBMR_ID,KM.TBKT_ID,KM.MaterialCode FROM SfcdatProduct sfc 
INNER JOIN T_Bllb_keyMaterial_tbkm KM ON sfc.Product=KM.MaterialCode
INNER JOIN T_Bllb_specMaterialRule_tbsmr SMR ON SMR.MaterialCode=KM.MaterialCode
INNER JOIN T_Bllb_keyType_tbkt KT ON KT.TBKT_ID=KM.TBKT_ID WHERE KT.KEY_TYPE = '0' AND sfc.WoCode='{0}' AND SMR.TBSMR_TYPE='0' AND SMR.TBSMR_TYPE_VALUE='{1}' AND SMR.MaterialCode='{2}' ORDER BY SMR.TBSMR_TYPE ASC", woCode, dt_sfc.Rows[0]["sfcno"], dt_sfc.Rows[0]["product"]);
            CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
            string strSql_check = string.Format(@"SELECT COUNT(1) FROM T_Bllb_projectRule_tbpr T LEFT JOIN T_Bllb_materialRule_tbmb MR ON T.TBMR_ID = MR.TBMR_ID WHERE T.WoCode = '{0}' AND MR.MATERIALCODE = '{1}'", woCode, dt_sfc.Rows[0]["product"]);
            if (CIT.Wcf.Utils.NMS.GetTableCount(PubUtils.uContext, strSql_check) == 0)
            {
                ///工单条码规则
                strSql = string.Format(@"INSERT INTO T_Bllb_projectRule_tbpr(WoCode,TBMR_ID,TBKT_ID,MaterialCode)
SELECT sfc.WoCode,SMR.TBMR_ID,KM.TBKT_ID,KM.MaterialCode FROM SfcdatProduct sfc 
INNER JOIN T_Bllb_keyMaterial_tbkm KM ON sfc.Product=KM.MaterialCode
INNER JOIN T_Bllb_specMaterialRule_tbsmr SMR ON SMR.MaterialCode=KM.MaterialCode
INNER JOIN T_Bllb_keyType_tbkt KT ON KT.TBKT_ID=KM.TBKT_ID WHERE KT.KEY_TYPE = '0' AND sfc.WoCode='{0}' AND SMR.TBSMR_TYPE='1' AND SMR.TBSMR_TYPE_VALUE='{1}' AND SMR.MaterialCode='{2}' ORDER BY SMR.TBSMR_TYPE ASC", woCode, dt_sfc.Rows[0]["wocode"], dt_sfc.Rows[0]["product"]);
                CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);

                if (CIT.Wcf.Utils.NMS.GetTableCount(PubUtils.uContext, strSql_check) == 0)
                {
                    ///机种条码规则
                    strSql = string.Format(@"INSERT INTO T_Bllb_projectRule_tbpr(WoCode,TBMR_ID,TBKT_ID,MaterialCode)
SELECT sfc.WoCode,SMR.TBMR_ID,KM.TBKT_ID,KM.MaterialCode FROM SfcdatProduct sfc 
INNER JOIN T_Bllb_keyMaterial_tbkm KM ON sfc.Product=KM.MaterialCode
INNER JOIN T_Bllb_specMaterialRule_tbsmr SMR ON SMR.MaterialCode=KM.MaterialCode
INNER JOIN T_Bllb_keyType_tbkt KT ON KT.TBKT_ID=KM.TBKT_ID WHERE KT.KEY_TYPE = '0' AND sfc.WoCode='{0}' AND SMR.TBSMR_TYPE='2' AND SMR.TBSMR_TYPE_VALUE='{1}' AND SMR.MaterialCode='{1}' ORDER BY SMR.TBSMR_TYPE ASC", woCode, dt_sfc.Rows[0]["product"]);
                    CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
                    if (CIT.Wcf.Utils.NMS.GetTableCount(PubUtils.uContext, strSql_check) == 0)
                    {
                        //默认条码规则
                        strSql = string.Format(@"INSERT INTO T_Bllb_projectRule_tbpr(WoCode,TBMR_ID,TBKT_ID,MaterialCode)
SELECT  SFC.WoCode,MR.TBMR_ID,KM.TBKT_ID,KM.MaterialCode FROM SfcdatProduct SFC
INNER JOIN T_Bllb_keyMaterial_tbkm KM ON SFC.product=KM.MaterialCode
INNER JOIN T_Bllb_materialRule_tbmb MR ON MR.MaterialCode=KM.MaterialCode
INNER JOIN T_Bllb_keyType_tbkt KT ON KT.TBKT_ID=KM.TBKT_ID WHERE KT.KEY_TYPE = '0' AND MR.DEFAULT_FLAG='Y' AND SFC.WOCODE='{0}' AND MR.MaterialCode='{1}'", woCode, dt_sfc.Rows[0]["product"]);
                        CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
                    }

                }
            }
            //BOM物料条码规则
            foreach (DataRow dr in dt_sfc.Rows)
            {
                if (SqlInput.ChangeNullToString(dr["TBKT_ID"]) == string.Empty || SqlInput.ChangeNullToString(dr["Product"]) == SqlInput.ChangeNullToString(dr["MaterialCode"]))//若是没有BOM物料不是关键件或者料号与产品一致，则继续下一个
                {
                    continue;
                }
                //指令单条码规则
                strSql = string.Format(@"INSERT INTO T_Bllb_projectRule_tbpr(WoCode,TBMR_ID,TBKT_ID)
SELECT '{0}' WoCode,SMR.TBMR_ID,KM.TBKT_ID FROM T_Bllb_keyMaterial_tbkm KM 
INNER JOIN T_Bllb_specMaterialRule_tbsmr SMR ON SMR.MaterialCode=KM.MaterialCode
INNER JOIN T_Bllb_keyType_tbkt KT ON KT.TBKT_ID=KM.TBKT_ID WHERE KT.KEY_TYPE = '1' AND  SMR.TBSMR_TYPE='0' AND SMR.TBSMR_TYPE_VALUE='{1}' AND SMR.MaterialCode='{2}' ORDER BY SMR.TBSMR_TYPE ASC", woCode, dr["sfcno"], dr["MaterialCode"]);
                CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
                strSql_check = string.Format(@"SELECT COUNT(1) FROM T_Bllb_projectRule_tbpr T LEFT JOIN T_Bllb_materialRule_tbmb MR ON T.TBMR_ID = MR.TBMR_ID WHERE T.WoCode = '{0}' AND MR.MATERIALCODE = '{1}'", woCode, dr["MaterialCode"]);
                if (CIT.Wcf.Utils.NMS.GetTableCount(PubUtils.uContext, strSql_check) == 0)///指令单条码规则
                {
                    //工单条码规则
                    strSql = string.Format(@"INSERT INTO T_Bllb_projectRule_tbpr(WoCode,TBMR_ID,TBKT_ID)
SELECT '{0}' WoCode,SMR.TBMR_ID,KM.TBKT_ID FROM T_Bllb_keyMaterial_tbkm KM 
INNER JOIN T_Bllb_specMaterialRule_tbsmr SMR ON SMR.MaterialCode=KM.MaterialCode
INNER JOIN T_Bllb_keyType_tbkt KT ON KT.TBKT_ID=KM.TBKT_ID WHERE KT.KEY_TYPE = '1' AND SMR.TBSMR_TYPE='1' AND SMR.TBSMR_TYPE_VALUE='{1}' AND SMR.MaterialCode='{2}' ORDER BY SMR.TBSMR_TYPE ASC", woCode, dr["wocode"], dr["MaterialCode"]);
                    CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
                    if (CIT.Wcf.Utils.NMS.GetTableCount(PubUtils.uContext, strSql_check) == 0)///工单条码规则
                    {
                        //机种条码规则
                        strSql = string.Format(@"INSERT INTO T_Bllb_projectRule_tbpr(WoCode,TBMR_ID,TBKT_ID)
SELECT '{0}' WoCode,SMR.TBMR_ID,KM.TBKT_ID FROM T_Bllb_keyMaterial_tbkm KM
INNER JOIN T_Bllb_specMaterialRule_tbsmr SMR ON SMR.MaterialCode=KM.MaterialCode
INNER JOIN T_Bllb_keyType_tbkt KT ON KT.TBKT_ID=KM.TBKT_ID WHERE KT.KEY_TYPE = '1' AND SMR.TBSMR_TYPE='2' AND SMR.TBSMR_TYPE_VALUE='{1}' AND SMR.MaterialCode='{2}' ORDER BY SMR.TBSMR_TYPE ASC", woCode, dr["product"], dr["MaterialCode"]);
                        CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
                        if (CIT.Wcf.Utils.NMS.GetTableCount(PubUtils.uContext, strSql_check) == 0)///机种条码规则
                        {
                            //默认条码规则
                            strSql = string.Format(@"INSERT INTO T_Bllb_projectRule_tbpr(WoCode,TBMR_ID,TBKT_ID)
SELECT  '{0}' WoCode,MR.TBMR_ID,KM.TBKT_ID FROM T_Bllb_keyMaterial_tbkm KM 
INNER JOIN T_Bllb_materialRule_tbmb MR ON MR.MaterialCode=KM.MaterialCode
INNER JOIN T_Bllb_keyType_tbkt KT ON KT.TBKT_ID=KM.TBKT_ID WHERE KT.KEY_TYPE = '1' AND MR.DEFAULT_FLAG='Y' AND MR.MaterialCode='{1}'", woCode, dr["MaterialCode"]);
                            CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);//默认条码规则
                        }
                        else//无条码规则
                        {
                            strSql = string.Format(@"INSERT INTO T_Bllb_projectRule_tbpr(WoCode,TBMR_ID,TBKT_ID,MaterialCode) VALUES('{0}','','','{1}')", woCode, dr["MaterialCode"]);
                            CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
                        }
                    }

                }

            }


            return true;
        }
        #endregion
        #region 查询线体信息
        /// <summary>
        /// 查询线体信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetListOfLine(string strWhere)
        {
            //是否显示SMT线信息 Jason.Xue 2017.10.18
            strWhere = strWhere == string.Empty ? " WHERE 1=1 " : strWhere;
            string msg = string.Empty;
            if (Common.BLL.Bll_Common.GetSysParameter("DZ", "DZ002", ref msg))
            {
                if (msg == "Y")
                {
                    strWhere += "and PLCODE not like 'SMT%' ";
                }
            }

            string strSql = string.Format(@"SELECT PLCODE,PLNAME FROM MdcDatProductLine {0}", strWhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        #endregion
        #region 获取系统参数中下拉框的数据源
        /// <summary>
        /// 获取系统参数中下拉框的数据源
        /// </summary>
        /// <param name="father_Para_Code"></param>
        /// <returns></returns>
        public static DataTable GetSysParameter(string father_Para_Code)
        {
            string strSql = string.Format(@"select d.DICT_VALUE,d.DICT_CODE 
                                              from 
			                                    T_Sysc_dictionaryType_tsdt as t
                                             inner join 
	                                            T_Sysc_dictionary_tsd  as d 
	                                              on t.TSDT_ID=d.TSDT_ID 
                                                     WHERE T.D_TYPECODE='{0}'", father_Para_Code);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        #endregion
        #region 获取某个系统参数值
        /// <summary>
        /// 获取某个系统参数值
        /// </summary>
        /// <param name="father_Para_Code"></param>
        /// <param name="para_Code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetSysParameter(string father_Para_Code, string para_Code, ref string msg)
        {
            string strSql = string.Format(@"select d.DICT_VALUE,d.DICT_CODE 
                                                from 
			                                        T_Sysc_dictionaryType_tsdt as t
                                                inner join 
	                                                T_Sysc_dictionary_tsd  as d 
	                                                 on t.TSDT_ID=d.TSDT_ID 
                                                WHERE t.D_TYPECODE='{0}' and d.DICT_CODE='{1}'", father_Para_Code, para_Code);
            DataTable dt_sys = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
            if (dt_sys.Rows.Count != 0)
            {
                msg = dt_sys.Rows[0]["DICT_VALUE"].ToString();
                return true;
            }
            return false;
        }
        #endregion
        #region 查询工位信息
        /// <summary>
        /// 查询工位信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetListofStation(string strWhere)
        {
            string strSql = string.Format(@"SELECT 'False' CHECKID, T.TBS_ID
      ,T.WORKSTATION_SN,T.WORKSTATION_NAME,T.TBG_ID,T.PLCode,L.PLName,G.GROUP_NAME,G.GROUP_TYPE
  FROM T_Bllb_station_tbs T LEFT JOIN MdcDatProductLine L ON T.PLCode=L.PLCode
  LEFT JOIN T_Bllb_Group_tbg G ON T.TBG_ID=G.TBG_ID {0}", strWhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        #endregion
        #region 获取外包装打印信息
        /// <summary>
        /// 获取外包装打印信息
        /// </summary>
        /// <param name="productcode">产品代码</param>
        /// <returns></returns>
        public static DataTable QueryPrintInfo(string productcode)
        {
            string strSql = string.Format("select TBBP_ID,PRODUCTCODE,PARA1,CREATE_TIME,CREATOR,MODIFIER,MODIFY_TIME,PARTNUMBER,PARTNAME,PARTSPEC,GETDATE() SYSTIME from T_Bllb_barcodeProduct_tbbp WHERE PRODUCTCODE='{0}'", productcode);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        #endregion
        #region 获取打印标签数据源
        /// <summary>
        /// 获取打印标签数据源
        /// </summary>
        /// <returns></returns>
        public static DataTable GetListOfLableTemp()
        {
            string strSql = string.Format("select name from mdcdatbarcodetemplet");
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        #endregion
        #region 获取产品代码列表
        /// <summary>
        /// /获取产品代码列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetListOfProduct()
        {
            string strSql = string.Format(@"SELECT ProductCode,ProductName FROM MdcdatProduct order by ProductCode asc");
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }

        #endregion
        #region 判断输入是否为不良代码
        /// <summary>
        /// 判断输入是否为不良代码
        /// </summary>
        /// <param name="ErrorCode">不良代码</param>
        /// <returns></returns>
        public static bool IsErrorCode(string ErrorCode, ref string TBEC_ID)
        {
            string strSql = string.Format(@"SELECT TBEC_ID FROM T_Bllb_errorCode_tbec WHERE TBEC_CODE='{0}'", ErrorCode);
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, strSql);
            if (dt.Rows.Count > 0)
            {
                TBEC_ID = dt.Rows[0][0].ToString();
                return true;
            }
            return false;
        }
        #endregion
        #region 写物料操作日志 
        /// <summary>
        /// 写物料操作日志
        /// </summary>
        /// <param name="serialnumber">条码</param>
        /// <param name="operationType">操作类型</param>
        /// <param name="materialcode">料号</param>
        /// <param name="qty">数量 </param>
        public static void WriteMaterialLog(string serialnumber, string operationType, string materialcode, string qty)
        {
            string strLogsql = string.Format(@"
INSERT INTO dbo.T_Bllb_MaterialLog_tbml
        ( SerialNumber ,
          CreateTime ,
          OperateType ,
          MaterialCode ,
          QTY ,
          Creator ,
          TBML_ID 
        )
VALUES  ( '{0}' , -- SerialNumber - nvarchar(200)
          GETDATE() , -- CreateTime - datetime
          '{1}' , -- OperateType - nvarchar(50)
          '{2}' , -- MaterialCode - nvarchar(50)
          '{3}', -- QTY - int
          '{4}' , -- Creator - nvarchar(50)
          '{5}'  -- TBML_ID - nvarchar(50)
        )", serialnumber, operationType, materialcode, qty, PubUtils.uContext.UserID, Guid.NewGuid().ToString());
            NMS.ExecTransql(PubUtils.uContext, strLogsql);
        } 
        #endregion
    }
}
