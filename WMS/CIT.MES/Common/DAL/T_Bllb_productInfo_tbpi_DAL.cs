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
    /// 产品信息数据层访问类
    /// </summary>
    public class T_Bllb_productInfo_tbpi_DAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SerialNubmer"></param>
        /// <returns></returns>
        public bool UpdateAGING_START_TIME(string SerialNubmer)
        {
            string strSql = string.Format(@"SELECT * FROM T_Bllb_packageOne_tbpo WHERE CONTAINER_SN_1='{0}'", SerialNubmer);
            if (NMS.QueryDataTable(PubUtils.uContext, strSql).Rows.Count > 0)
            {
                strSql = string.Format(@"UPDATE T_Bllb_productInfo_tbpi SET AGING_START_TIME=GETDATE() WHERE TBPS_ID IN (SELECT TBPS_ID FROM T_Bllb_packageOne_tbpo WHERE CONTAINER_SN_1='{0}')", SerialNubmer);
            }
            else
            {
                strSql = string.Format(@"UPDATE T_Bllb_productInfo_tbpi SET AGING_START_TIME=GETDATE() WHERE SERIAL_NUMBER='{0}'", SerialNubmer);
            }
           return  NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询产品条码数据
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable GetSN(T_Bllb_productInfo_tbpi tbpi)
        {
            string strSql = string.Format(@"SELECT TBPS_ID FROM T_Bllb_productInfo_tbpi WHERE SERIAL_NUMBER='{0}' AND LAST_FLAG='Y'", tbpi.SERIAL_NUMBER);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }

        /// <summary>
        /// 查询产品追溯基础数据
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable GetBasicData(string strWhere)
        {
            string strSql = string.Format(@" SELECT Tbpi.AGING_START_TIME,Tbpi.AGING_END_TIME,Tbpi.INOUT_STATUS,Product.WoCode,Product.SfcNo,Tbps.PLCode,ProLine.PLName,PanelCode,
                                Tbpi.OVER_FLAG,Tbpi.ERROR_FLAG,Tbpi.REPAIR_FLAG,Tbpi.SCRAP_FLAG,Product.Product,Product.ProductName,G.Group_Name,Two.CONTAINER_SN_2,One.CONTAINER_SN_1 
                                FROM T_Bllb_productInfo_tbpi AS Tbpi
                                LEFT JOIN SfcDatProduct AS Product ON Product.SfcNo=Tbpi.SfcNo
                                LEFT JOIN T_Bllb_productStatus_tbps AS Tbps ON Tbps.TBPS_ID=Tbpi.TBPS_ID
                                LEFT JOIN T_Bllb_technologyGroup_tbtg AS T ON T.TBTG_ID=Tbps.TBTG_ID
                                LEFT JOIN T_Bllb_group_tbg  AS G ON G.TBG_ID=T.TBG_ID
                                LEFT JOIN MdcDatProductLine AS ProLine ON ProLine.PLCode=Tbps.PLCode
                                LEFT JOIN T_Bllb_packageOne_tbpo AS One ON Tbpi.TBPS_ID=One.TBPS_ID
                                LEFT JOIN T_Bllb_packageTwo_tbpt AS Two ON One.CONTAINER_SN_1=Two.CONTAINER_SN_1 {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 最后过本工序的明细信息
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable GetTBPI(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT tbpi.SERIAL_NUMBER,Tbps.PASS_TIME,tbpi.ERROR_FLAG,Tbpi.QTY
                                                 from 
                                                   T_Bllb_productInfo_tbpi as tbpi	                                           
		                                         left join 
                                                   T_Bllb_productStatus_tbps AS Tbps
		                                              on Tbps.TBPS_ID=tbpi.TBPS_ID and Tbps.SfcNo=tbpi.SfcNo ");
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);

            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 根据产品SN查找数据
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        //public DataTable GetList(T_Bllb_productInfo_tbpi tbpi)
        //{
        //    string strSql = string.Format("select * from T_Bllb_productInfo_tbpi where SERIAL_NUMBER='{0}'", tbpi.SERIAL_NUMBER);
        //    return NMS.QueryDataTable(PubUtils.uContext, strSql);
        //}
        /// <summary>
        /// 根据产品SN查找检验单
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable GetDocNoBySN(T_Bllb_productInfo_tbpi tbpi)
        {
            string strSql = string.Format(@"select tbpi.SERIAL_NUMBER,tbap.DOC_NO,tbap.STATUS
                                                   from
                                                      T_Bllb_productInfo_tbpi as tbpi
                                                     inner join
                                                      T_Bllb_sampleProduct_tbap as tbap
                                                       on tbpi.TBPS_ID = tbap.TBPS_ID
                                                       LEFT JOIN T_Bllb_sampleDoc_tbsd tbsd on tbsd.DOC_NO=tbap.DOC_NO
                                                        where tbpi.SERIAL_NUMBER = '{0}' AND tbpi.LAST_FLAG='Y' ORDER BY tbsd.CREATE_TIME DESC", tbpi.SERIAL_NUMBER);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }

        /// <summary>
        ///已检测产品SN查询检测项目数据
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable GetCheckItem(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format(@"SELECT c.TBCI_NAME,c.VALUE_TYPE,c.DOWN_VALUE,c.UP_VALUE, s.TEST_VALUE,s.IS_OK FROM T_Bllb_checkItem_tbci AS c
                                            INNER JOIN T_Bllb_sampleCheckItem_tbsci As s
                                            ON c.TBCI_ID=s.TBCI_ID
                                            INNER JOIN T_Bllb_productInfo_tbpi AS tbpi
                                            ON tbpi.TBPS_ID=s.TBPS_ID {0}", strWhere));
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 维修查询中的查询产品基础信息
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public DataTable GetProInfoList(string strWere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT SP.SfcNo,L.PLName,Tbpi.SERIAL_NUMBER,SP.Product,SP.ProductName 
                                    FROM SfcDatProduct AS SP
                                            LEFT JOIN MdcDatProductLine AS L
                                            ON L.PLCode=SP.Line
                                            LEFT JOIN T_Bllb_productInfo_tbpi AS Tbpi
                                            ON Tbpi.SfcNo=SP.SfcNo ");
            if (strWere != string.Empty)
            {
                strSql.Append(strWere + " and  Tbpi.LAST_FLAG='Y'");
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        ///  替换关键件日志查询
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable GetreplaceKeyList(T_Bllb_productInfo_tbpi tbpi)
        {
            string strSql = string.Format(@"SELECT Tbpi.TBPS_ID,OLD_KEY_SN,NEW_KEY_SN,REPLACE_MAN,REPLACE_TIME FROM T_Bllb_productInfo_tbpi AS Tbpi
                                                INNER JOIN T_Bllb_replaceKeyLog_tbrkl AS R
                                                ON Tbpi.TBPS_ID=R.TBPS_ID
                                                WHERE SERIAL_NUMBER='{0}'", tbpi.SERIAL_NUMBER);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 关键件SN日志选中单元格查询不良代码维修查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GeterrorRepair(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT EC.TBEC_CODE,EC.TBEC_DESC,G.GROUP_NAME,PE.ERROR_MAN,PE.ERROR_TIME,PE.REPAIR_MAN,PE.REPAIR_TIME,R.TBER_NAME,M.TBRM_NAME,NO_ERROR,EP.TBEP_NAME,PE.PART_NUM   
                                                   FROM  T_Bllb_productError_tbpe  AS PE   
												    LEFT JOIN T_Bllb_productInfo_tbpi AS Tbpi
                                                    ON Tbpi.TBPS_ID=PE.TBPS_ID                                                  
                                                    LEFT JOIN T_Bllb_errorCode_tbec AS EC
                                                    ON PE.TBEC_ID=EC.TBEC_ID
                                                    LEFT JOIN T_Bllb_group_tbg  AS G
                                                    ON G.TBG_ID=PE.TBG_ID
                                                    LEFT JOIN T_Bllb_errorReason_tber AS R
                                                    ON R.TBER_ID=PE.TBER_ID
                                                    LEFT JOIN T_Bllb_repairMethod_tbrm  AS M
                                                    ON M.TBRM_ID=PE.TBRM_ID
                                                    LEFt JOIN T_Bllb_errorParts_tbep  AS EP
                                                    ON EP.TBEP_ID=PE.TBEP_ID ");
            if (strWhere != string.Empty)
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 更新是否报废字段
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public bool UpdateList(T_Bllb_productInfo_tbpi tbpi)
        {
            string strSql = string.Format("update T_Bllb_productInfo_tbpi   set SCRAP_FLAG='Y',SERIAL_NUMBER=SERIAL_NUMBER+'-BF' where TBPS_ID='{0}'", tbpi.TbpsId);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询产品SN是否已经报废
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable GetScrap(T_Bllb_productInfo_tbpi tbpi)
        {
            string strSql = string.Format(@"SELECT S.TBPS_ID   FROM T_Bllb_productInfo_tbpi AS Tbpi
                                                LEFT JOIN T_Bllb_scrap_tbs AS S
                                                ON S.TBPS_ID=Tbpi.TBPS_ID
                                                WHERE Tbpi.TBPS_ID='{0}' ", tbpi.TbpsId);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 通过连接查询获得数据（产品状态表和产品信息表进行连接，查找TBPS_ID,SfcNo,通过产品条码进行过滤
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable GetList(T_Bllb_productInfo_tbpi tbpi)
        {
            string strSql = string.Format(@"SELECT TBPI.TBPI_ID,TBPI.TBPS_ID,TBPI.SERIAL_NUMBER,TBPS.SfcNo FROM T_Bllb_productInfo_tbpi  AS TBPI
                                               INNER JOIN T_Bllb_productStatus_tbps AS TBPS
                                               ON TBPI.TBPS_ID = TBPS.TBPS_ID
                                               WHERE SERIAL_NUMBER = '{0}' and LAST_FLAG='Y'", tbpi.SERIAL_NUMBER);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 通过条件查询数据(单表)
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format(@"select TBPI_ID,TBPS_ID,SERIAL_NUMBER,QTY,OVER_FLAG,LAST_FLAG,ERROR_FLAG,REPAIR_FLAG,SCRAP_FLAG,SfcNo
                                ONCE_OVER_FLAG,AUXILIARY_FLAG from T_Bllb_productInfo_tbpi"));
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 查询（连接工单表和产品信息表，根据产品条码过滤）
        /// </summary>
        /// <returns></returns>
        public DataTable Query(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select t.SERIAL_NUMBER,t.TBPS_ID,t.SfcNo,s.Product,s.ProductName
                              from 
                                T_Bllb_productInfo_tbpi as t
                              left join
                                SfcDatProduct as s
	                             on t.SfcNo=s.SfcNo");
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 通过产品条码，查询TBPI_ID
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable GetBySerialNumber(T_Bllb_productInfo_tbpi tbpi)
        {
            string strSql = string.Format(@"select TBPI_ID,QTY,TBPS_ID from T_Bllb_productInfo_tbpi where SERIAL_NUMBER='{0}' and LAST_FLAG='Y'", tbpi.SERIAL_NUMBER);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 通过产品条码和制令单查询数据
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable GetBySfcAndSNr(T_Bllb_productInfo_tbpi tbpi)
        {
            string strSql = string.Format("select * from T_Bllb_productInfo_tbpi where SERIAL_NUMBER='{0}' and SfcNo='{1}' and LAST_FLAG='Y'", tbpi.SERIAL_NUMBER, tbpi.SfcNo);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 维修管理信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetRepair(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select tbps.PLCode,tbpi.TBPS_ID,tbpi.SERIAL_NUMBER,tbpi.SfcNo,SfcPro.Product,SfcPro.ProductName,tbg.TBG_ID,tbg.GROUP_NAME
                                                from 
                                                     T_Bllb_productInfo_tbpi as tbpi
			                                          left join 
				                                        SfcDatProduct as SfcPro
				                                        on tbpi.SfcNo=SfcPro.SfcNo
			                                          left join
				                                        T_Bllb_productStatus_tbps as tbps
				                                        on tbpi.TBPS_ID=tbps.TBPS_ID 
			                                          left join
				                                        T_Bllb_technologyGroup_tbtg as tbtg
				                                        on tbps.TBTG_ID=tbtg.TBTG_ID
			                                          left join 
				                                        T_Bllb_group_tbg as tbg
				                                        on tbg.TBG_ID=tbtg.TBG_ID");
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 更新产品信息是否报废字段为Y
        /// </summary>
        /// <returns></returns>
        public bool Update_SCRAP_FLAG(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Bllb_productInfo_tbpi set SCRAP_FLAG='Y',SERIAL_NUMBER=SERIAL_NUMBER+'-BF'");
            if (strWhere != string.Empty)
            {
                strSql.Append(" where " + strWhere);
            }
            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 更新是否不良
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public bool Update_ERROR_FLAG(T_Bllb_productInfo_tbpi tbpi)
        {
            string strSql = string.Format(@"update T_Bllb_productInfo_tbpi set ERROR_FLAG='{1}' where  SERIAL_NUMBER='{1}'
                and LAST_FLAG='Y'", tbpi.SERIAL_NUMBER, tbpi.ERROR_FLAG);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
    }
}
