using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CIT.Wcf.Utils;
using CIT.MES;
using Model;
using Common.Helper;
namespace Warehouse.BLL
{
    public class Bll_Bllb_StockInfo_tbsi
    {
        /// <summary>
        /// 历史库存查询（现有库存减去时间点到当前的出入库数据）
        /// </summary>
        /// <param name="MaterialCode"></param>
        /// <param name="StockTime"></param>
        /// <param name="Storage_SN"></param>
        /// <returns></returns>
        public static DataTable HistoryQuery(string MaterialCode, DateTime StockTime, string Storage_SN, string Spec)
        {
            string strWhere1 = string.Empty;
            string strWhere2 = string.Empty;
            string strWhere3 = string.Empty;
            if (MaterialCode != string.Empty)
            {
                strWhere1 += string.Format(@" AND A.MaterialCode='{0}' ", MaterialCode);
                strWhere2 += string.Format(@" AND T.MaterialCode='{0}' ", MaterialCode);
            }
            if (Storage_SN != string.Empty)
            {
                strWhere1 += string.Format(@" AND R.Storage_SN='{0}' ", Storage_SN);
                strWhere2 += string.Format(@" AND R.Storage_SN='{0}' ", Storage_SN);
            }
            if (Spec != string.Empty)
            {
                strWhere2 += string.Format(@" AND MDC.SPEC='{0}' ", Spec);
                strWhere3 += string.Format(@" AND MDC.SPEC='{0}' ", Spec);
            }
            string strSql = string.Format(@"SELECT TBSI.MaterialCode,NOW_QTY-ISNULL(QTY,0) AS QTY,tbsi.Storage_SN,tbsi.Storage_Name,tbsi.Status_Flag,MDC.SPEC FROM 
(SELECT A.MaterialCode,SUM(QTY) NOW_QTY,M.Storage_SN,R.Storage_Name,A.Status_Flag FROM T_Bllb_StockInfo_tbsi A 
LEFT JOIN T_Bllb_StorageLocation_tbsl L ON L.Location_SN=A.Location_SN
LEFT JOIN T_Bllb_StorageArea_tbsa  M  ON L.AREA_SN=M.Area_SN
LEFT JOIN T_Bllb_Storage_tbs R ON M.Storage_SN=R.Storage_SN Where A.In_Time <= CONVERT(DATETIME,'{0}') {1}
GROUP BY A.MaterialCode,M.Storage_SN,R.Storage_Name,A.Status_Flag) tbsi 
LEFT JOIN 
--处理现有库存中存在的物料
(SELECT T.MaterialCode,SUM(CASE M.S_DOC_TYPE WHEN '1' THEN T.QTY 
WHEN '2' THEN -T.QTY WHEN '3' THEN T.QTY WHEN '4' THEN T.QTY ELSE 0 END) AS QTY,S.Storage_SN,R.Storage_Name,T.Status_Flag
FROM T_Bllb_StorageDocDetail_tbsdd T
LEFT JOIN T_Bllb_StorageDoc_tbsd M ON T.S_Doc_NO=M.S_Doc_NO
LEFT JOIN T_Bllb_StorageLocation_tbsl L ON L.Location_SN=T.Location_SN
LEFT JOIN T_Bllb_StorageArea_tbsa  S ON L.AREA_SN=S.Area_SN
LEFT JOIN T_Bllb_Storage_tbs R ON S.Storage_SN=R.Storage_SN
 WHERE T.Create_Time > CONVERT(DATETIME,'{0}')
 GROUP BY T.MaterialCode,S.Storage_SN,R.Storage_Name,T.Status_Flag) N 
 ON N.MaterialCode=tbsi.MaterialCode  AND tbsi.Storage_SN=N.Storage_SN AND tbsi.Status_Flag=N.Status_Flag
LEFT JOIN MdcdatMaterial MDC ON MDC.MATERIALCODE=TBSI.MATERIALCODE
 WHERE tbsi.NOW_QTY>ISNULL(QTY,0) {3}
 UNION
--处理现有库存中不存在的物料
 SELECT * FROM (
SELECT T.MaterialCode,SUM(CASE M.S_DOC_TYPE WHEN '1' THEN -T.QTY 
WHEN '2' THEN T.QTY WHEN '3' THEN -T.QTY ELSE 0 END) AS QTY,S.Storage_SN,R.Storage_Name,T.Status_Flag,MDC.SPEC
FROM T_Bllb_StorageDocDetail_tbsdd T
LEFT JOIN T_Bllb_StorageDoc_tbsd M ON T.S_Doc_NO=M.S_Doc_NO
LEFT JOIN T_Bllb_StorageLocation_tbsl L ON L.Location_SN=T.Location_SN
LEFT JOIN T_Bllb_StorageArea_tbsa  S ON L.AREA_SN=S.Area_SN
LEFT JOIN T_Bllb_Storage_tbs R ON S.Storage_SN=R.Storage_SN
LEFT JOIN MdcdatMaterial MDC ON MDC.MATERIALCODE=T.MATERIALCODE
 WHERE T.Create_Time > CONVERT(DATETIME,'{0}') {2} AND
 T.MaterialCode NOT IN (SELECT DISTINCT MaterialCode FROM T_Bllb_StockInfo_tbsi) 
 GROUP BY T.MaterialCode,S.Storage_SN,R.Storage_Name,T.Status_Flag,MDC.SPEC) B WHERE B.QTY>0", StockTime, strWhere1, strWhere2, strWhere3);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }

        /// <summary>
        /// 出库查询是否有可发物料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Query(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT case when si.In_Time>= GETDATE()-tbmq.QualityLength then '否' else '是' end as Quality_Flag, S.Storage_SN,S.Storage_Name,A.Area_SN,A.Area_Name,SI.Location_SN,
                                    L.Location_Name,SI.MaterialCode,SI.QTY,SI.Is_Locked,SI.Enable,
                                    SI.In_Time ,SI.Container_Type,SI.CONTAINER_SN,si.Status_Flag,g.InActiveLength,
            CASE WHEN GETDATE()<=SI.IN_TIME+G.InActiveLength THEN 'N' ELSE 'Y' END AS TIME_STATUS
                                    FROM T_Bllb_StockInfo_tbsi AS SI
                                    LEFT JOIN T_Bllb_StorageLocation_tbsl AS L
                                    ON SI.Location_SN=L.Location_SN 
                                    LEFT JOIN T_Bllb_StorageArea_tbsa AS A
                                    ON L.Area_SN=A.Area_SN 
                                    LEFT JOIN T_Bllb_Storage_tbs AS S
                                    ON A.Storage_SN=S.Storage_SN
                                    LEFT JOIN  T_Bllb_MaterialQuality_tbmq  tbmq 
									on s.Step=tbmq.Step and tbmq.MaterialCode=si.MaterialCode
                                    LEFT JOIN MdcdatMaterial as g 
									on g.MaterialCode=si.MaterialCode");

            if (strWhere != string.Empty)
            {
                strSql.Append(strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 库存查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable QueryStockInfo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"SELECT S.Storage_SN,S.Storage_Name,A.Area_SN,A.Area_Name,SI.Location_SN,
                                L.Location_Name,SI.MaterialCode,SI.QTY,SI.Is_Locked,SI.Enable,
                                SI.In_Time ,SI.Container_Type,SI.CONTAINER_SN,si.Status_Flag,g.InActiveLength,
								CASE WHEN GETDATE()<=SI.IN_TIME+G.InActiveLength THEN 'N' ELSE 'Y' END AS TIME_STATUS,
                                ISNULL(tbmq.QualityLength,9999) AS QualityLength,CASE WHEN GETDATE()<=SI.IN_TIME+ ISNULL(tbmq.QualityLength,9999) THEN 'N' ELSE 'Y' END AS Quality_Status,
                                DATEDIFF(DAY,SI.IN_TIME,GETDATE()) as in_lengthTime,g.Spec,SI.PLCode,SI.Reback_Flag
                                FROM T_Bllb_StockInfo_tbsi AS SI
                                LEFT JOIN T_Bllb_StorageLocation_tbsl AS L
                                ON SI.Location_SN=L.Location_SN 
                                LEFT JOIN T_Bllb_StorageArea_tbsa AS A
                                ON L.Area_SN=A.Area_SN 
                                LEFT JOIN T_Bllb_Storage_tbs AS S
                                ON A.Storage_SN=S.Storage_SN
                                LEFT JOIN T_Bllb_MaterialQuality_tbmq  tbmq 
								on tbmq.MaterialCode=si.MaterialCode and tbmq.Step=s.step collate Chinese_PRC_90_CI_AS
								LEFT JOIN MdcdatMaterial as g on g.MaterialCode=si.MaterialCode ");
            if (strWhere != string.Empty)
            {
                strSql.Append(strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 获取库位上的物料（包括报废）
        /// </summary>
        /// <param name="LocationSN"></param>
        /// <returns></returns>
        public static DataTable QueryMaterialByLocationSN(string LocationSN)
        {
            string strSql = string.Format(@"SELECT  S.Storage_SN,S.Storage_Name,A.Area_SN,A.Area_Name,SI.Location_SN,
                                L.Location_Name,SI.MaterialCode,SI.QTY,SI.Is_Locked,SI.Enable,SI.Scrapt_Time,
                                SI.In_Time ,SI.Container_Type,SI.CONTAINER_SN,'0' as flag
                                FROM T_Bllb_StockInfo_tbsi AS SI
                                LEFT JOIN T_Bllb_StorageLocation_tbsl AS L
                                ON SI.Location_SN=L.Location_SN 
                                LEFT JOIN T_Bllb_StorageArea_tbsa AS A
                                ON L.Area_SN=A.Area_SN 
                                LEFT JOIN T_Bllb_Storage_tbs AS S
                                ON A.Storage_SN=S.Storage_SN
                                where SI.Location_SN='{0}'", LocationSN);
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 查询库存中容器SN相关信息
        /// </summary>
        /// <param name="Container_SN"></param>
        /// <returns></returns>
        public static DataTable QueryByContainer_SN(string Container_SN)
        {
            string strSql = string.Format(@"SELECT  SI.Storage_SN,SI.Area_SN,SI.Location_SN,
                                SI.MaterialCode,SI.QTY,SI.Is_Locked,SI.Enable,SI.Scrapt_Time,SI.PLCode,
                                SI.In_Time ,SI.Container_Type,SI.CONTAINER_SN,'0' as flag,status_flag
                                FROM T_Bllb_StockInfo_tbsi SI where SI.CONTAINER_SN='{0}'", Container_SN);
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 库存中是否存在某种物料
        /// </summary>
        /// <param name="MaterialCode"></param>
        /// <returns></returns>
        public static bool CheckMaterial(string MaterialCode)
        {
            string strSql = string.Format(" Select COUNT(1) FROM T_Bllb_StockInfo_tbsi where MaterialCode='{0}'", MaterialCode);
            return NMS.GetTableCount(PubUtils.uContext, strSql) > 0 ? true : false;
        }

        /// <summary>
        /// 锁定
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool Locked(string strwhere)
        {
            string strSql = string.Format(@" Update T_Bllb_StockInfo_tbsi set  Is_Locked='Y' {0}", strwhere);

            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool OffLock(string strwhere)
        {
            string strSql = string.Format(@" Update T_Bllb_StockInfo_tbsi set  Is_Locked='N' {0}", strwhere);

            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Insert(Model.T_Bllb_StockInfo_tbsi obj)
        {
            string strSql = string.Format(@"INSERT INTO T_Bllb_StockInfo_tbsi(Storage_SN,Area_SN,Location_SN,MaterialCode,QTY,Is_Locked,Enable,In_Time,Container_Type,SerialNumber,Status_Flag,PLCode) VALUES('{0}','{1}','{2}','{3}',{4},'N','Y',GETDATE(),'{5}','{6}','{7}','{8}')", obj.Storage_SN, obj.Area_SN, obj.Location_SN, obj.MaterialCode, obj.QTY, obj.Container_Type, obj.SerialNumber, obj.Status_Flag, obj.PLCode);
            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 退料入库
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool RebackInsert(Model.T_Bllb_StockInfo_tbsi obj)
        {
            string strSql = string.Format(@"INSERT INTO T_Bllb_StockInfo_tbsi(Storage_SN,Area_SN,Location_SN,MaterialCode,QTY,Is_Locked,Enable,In_Time,Container_Type,SerialNumber,Status_Flag,PLCode,Reback_Flag) VALUES('{0}','{1}','{2}','{3}',{4},'N','Y',CAST('{5}' AS DATETIME),'{6}','{7}','{8}','{9}','Y')", obj.Storage_SN, obj.Area_SN, obj.Location_SN, obj.MaterialCode, obj.QTY, obj.In_Time, obj.Container_Type, obj.SerialNumber, obj.Status_Flag, obj.PLCode);
            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 删除物料库存信息
        /// </summary>
        /// <param name="container_sn"></param>
        /// <returns></returns>
        public static bool Delete(string container_sn)
        {
            string strSql = string.Format(@"DELETE FROM  T_Bllb_StockInfo_tbsi WHERE CONTAINER_SN='{0}'", container_sn);
            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 修改物料数量
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool UpdateQty(T_Bllb_StockInfo_tbsi obj)
        {
            string strSql = string.Format(@" Update T_Bllb_StockInfo_tbsi set QTY={1} WHERE SerialNumber='{0}'", obj.SerialNumber, obj.QTY);

            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 盘点
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool UpdateByCheckMaterial(T_Bllb_StockInfo_tbsi obj)
        {
            string strSql = string.Format(@" Update T_Bllb_StockInfo_tbsi set QTY={1},Location_SN='{2}',Status_Flag='{3}',MaterialCode='{4}',PLCode='{5}' WHERE SerialNumber='{0}'", obj.SerialNumber, obj.QTY, obj.Location_SN, obj.Status_Flag, obj.MaterialCode, obj.PLCode);

            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 调拨
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool UpdateLoacation(T_Bllb_StockInfo_tbsi obj)
        {

            string strSql = string.Format(@" Update T_Bllb_StockInfo_tbsi set Location_SN='{1}',Area_SN='{2}',Storage_SN='{3}' WHERE SerialNumber='{0}'", obj.SerialNumber, obj.Location_SN, obj.Area_SN, obj.Storage_SN);

            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 报废
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Scapt(T_Bllb_StockInfo_tbsi obj)
        {
            string strSql = string.Format(@" Update T_Bllb_StockInfo_tbsi set Enable='N',Scrapt_Time=getdate() WHERE SerialNumber='{0}'", obj.SerialNumber);

            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 通过原仓库和料号获得库存量
        /// </summary>
        /// <param name="Source_Storage"></param>
        /// <param name="MaterialCode"></param>
        /// <returns></returns>
        public static string GetQty(string Source_Storage, string MaterialCode)
        {
            string strSql = string.Format("select sum (QTY) as QTY from T_Bllb_StockInfo_tbsi where Storage_SN='{0}' and MaterialCode='{1}' and Lock_Flag='0'", Source_Storage, MaterialCode);
            string value = NMS.QueryDataTable(PubUtils.uContext, strSql).Rows[0]["QTY"].ToString();
            return value == string.Empty ? "0" : value;//如果找不到带出库存数量0
        }
        /// <summary>
        /// 库存汇总
        /// </summary>
        /// <param name="querywhere"></param>
        /// <returns></returns>
        public static DataTable SelectAll(string querywhere, string querycolumn, string group)
        {
            string strSql = string.Format(@"
SELECT  sum(a.QTY) as QTY  {1} from T_Bllb_StockInfo_tbsi  a
LEFT join T_Bllb_Storage_tbs b on a.Storage_SN=b.Storage_SN
LEFT JOIN T_Bllb_StorageArea_tbsa c ON a.Area_SN=c.Area_SN
LEFT JOIN T_Bllb_StorageLocation_tbsl d ON a.Location_SN=d.Location_SN
where a.Lock_Flag IN ('0','1','2') {0}  group by {2}
", querywhere, querycolumn, group);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 库存查询去除空库位
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        ///  /// <summary>
        /// 查询库存汇总
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable SelectStock(string strWhere)
        {
            string strSql = string.Format(@"
SELECT b.Storage_Name,c.Area_Name,d.Location_Name,a.MaterialCode,SUM(a.QTY) AS 'QTY' FROM dbo.T_Bllb_StockInfo_tbsi a
LEFT JOIN [dbo].[T_Bllb_Storage_tbs] b ON a.Storage_SN=b.Storage_SN
LEFT JOIN [dbo].[T_Bllb_StorageArea_tbsa] c ON a.Area_SN=c.Area_SN
LEFT JOIN [dbo].[T_Bllb_StorageLocation_tbsl] d ON a.Location_SN=d.Location_SN  {0} AND a.Lock_Flag IN ('0','1','2') And a.Location_SN <>'' And a.Area_SN <>'' 
GROUP BY b.Storage_Name,c.Area_Name,d.Location_Name,a.MaterialCode", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        public static DataTable Select(string strWhere)
        {
            string strSql = string.Format(@"
SELECT  b.Storage_Name ,
        a.MaterialCode ,
		c.Area_Name,
		d.Location_Name,
        a.QTY ,
        a.In_Time ,
        a.SerialNumber ,
        a.DateCode ,
        Finally_Time,
        CASE a.Lock_Flag
          WHEN 0 THEN '正常'
          WHEN 1 THEN '盘点'
          WHEN 2 THEN '库内冻结'
          --WHEN 3 THEN '二次送检'
 --         WHEN 4 THEN '报废'
 --         WHEN 5 THEN '二次送检NG'
 --         WHEN 6 THEN '备料'
 --         WHEN 7 THEN '出库中'
 --         WHEN '8' THEN '合盘'
 --         WHEN '9' THEN '库外冻结'
 --         WHEN '10' THEN '退料
        END AS 'Lock_Flag' ,
        a.Lot_No ,
        CASE ( a.QC_Result )
          WHEN 1 THEN '允收'
          WHEN 2 THEN '拒收'
          WHEN 3 THEN '让步接收'
          WHEN 5 THEN '挑选'
        END AS 'QC_Result'
FROM    T_Bllb_StockInfo_tbsi a
        left JOIN T_Bllb_Storage_tbs b ON a.Storage_SN = b.Storage_SN
		left JOIN dbo.T_Bllb_StorageArea_tbsa c ON a.Area_SN=c.Area_SN
		left JOIN  dbo.T_Bllb_StorageLocation_tbsl AS d ON a.Location_SN=d.Location_SN
WHERE   a.Lock_Flag IN ('0','1','2') and a.Location_SN <>'' And a.Area_SN <>'' {0} ", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }

        /// <summary>
        /// 库存查询全部
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable SelectAll(string strWhere)
        {
            string strSql = string.Format(@"
SELECT  b.Storage_Name ,
        a.MaterialCode ,
		c.Area_Name,
		d.Location_Name,
        a.QTY ,
        a.In_Time ,
        a.SerialNumber ,
        a.DateCode ,
        Finally_Time,
        CASE a.Lock_Flag
          WHEN 0 THEN '正常'
          WHEN 1 THEN '盘点'
          WHEN 2 THEN '库内冻结'
          WHEN 3 THEN '二次送检'
         WHEN 4 THEN '报废'
         WHEN 5 THEN '二次送检NG'
          WHEN 6 THEN '备料'
          WHEN 7 THEN '出库中'
          WHEN '8' THEN '合盘'
          WHEN '9' THEN '库外冻结'
          WHEN '10' THEN '退料'
        END AS 'Lock_Flag' ,
        a.Lot_No ,
        CASE ( a.QC_Result )
          WHEN 1 THEN '允收'
          WHEN 2 THEN '拒收'
          WHEN 3 THEN '让步接收'
          WHEN 5 THEN '挑选'
        END AS 'QC_Result'
FROM    T_Bllb_StockInfo_tbsi a
        left JOIN T_Bllb_Storage_tbs b ON a.Storage_SN = b.Storage_SN
		left JOIN dbo.T_Bllb_StorageArea_tbsa c ON a.Area_SN=c.Area_SN
		left JOIN  dbo.T_Bllb_StorageLocation_tbsl AS d ON a.Location_SN=d.Location_SN
WHERE   1=1 {0} ", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }

        /// <summary>
        /// 校验料盘是否在库状态
        /// </summary>
        /// <param name="mainMaterial"></param>
        /// <returns></returns>
        public static DataTable ValidateSN(string SerialNumber)
        {
            string strSql = string.Format("select * from T_Bllb_StockInfo_tbsi where SerialNumber='{0}' and Lock_Flag='0' and QTY>0 ", SerialNumber);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 合盘
        /// </summary>
        /// <param name="dicTrvSn"></param>
        /// <param name="M_Sn"></param>
        /// <param name="materialcode"></param>
        /// <returns></returns>
        public static bool Update_Combine_Action(Dictionary<string, int> dicTrvSn, string M_Sn, string materialcode)
        {
            int add_totalQty = 0;
            foreach (KeyValuePair<string, int> item in dicTrvSn)
            {
                add_totalQty += item.Value;
            }
            StringBuilder str_builder = new StringBuilder();
            str_builder.AppendFormat(@"
update T_Bllb_StockInfo_tbsi set QTY=QTY+'{1}' where SerialNumber='{0}'", M_Sn, add_totalQty);
            StringBuilder snwhere_builder = new StringBuilder();
            foreach (KeyValuePair<string, int> item in dicTrvSn)
            {
                if (snwhere_builder.Length == 0)
                {
                    snwhere_builder.AppendFormat("'{0}'", item.Key);
                }
                else if (snwhere_builder.Length != 0)
                {
                    snwhere_builder.AppendFormat(",'{0}'", item.Key);
                }
                str_builder.AppendFormat(@"
insert into T_Bllb_MaterialLog_tbml(
SerialNumber,OperateType,MaterialCode,QTY,Creator,CreateTime) values('{0}','{1}','{2}','{3}','{4}',getdate())",
item.Key, "合盘", materialcode, item.Value, PubUtils.uContext.UserID);
            }
            str_builder.AppendFormat("update T_Bllb_StockInfo_tbsi set QTY='0',Lock_Flag=8 where SerialNumber in ({0})", snwhere_builder);
            return NMS.ExecTransql(PubUtils.uContext, str_builder.ToString());
        }
        /// <summary>
        /// 校验物料SN状态是否在库
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable QueryStock(string strWhere)
        {
            string strSql = string.Format("Select * from T_Bllb_StockInfo_tbsi {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }/// <summary>
         /// 查询SMT段数量
         /// </summary>
         /// <param name="strWhere"></param>
         /// <returns></returns>
        public static DataTable Query_SN_Qty(string strWhere, string materialCode)
        {
            string strSql = string.Format("Select QTY from T_Bllb_StockInfo_tbsi where SerialNumber='{0}'", strWhere, materialCode);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询要打印的物料信息
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public static DataTable QueryStockMatr(string SN)
        {
            string strSq = string.Format("Select * from T_Bllb_StockInfo_tbsi a left join T_Bllb_StorageDocDetail_tbsdd b on a.SerialNumber=b.SerialNumber where a.SerialNumber='{0}'", SN);
            return NMS.QueryDataTable(PubUtils.uContext, strSq);
        }

        /// <summary>
        /// 库存查询导出
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable QueryExportDetail(string strWhere)
        {
            string strSql = string.Format(@"
SELECT  b.Storage_Name as '仓库',
        a.MaterialCode as '料号' ,
		c.Area_Name as '库区',
		d.Location_Name as '库位',
        a.QTY as '数量' ,
        a.In_Time as '入库时间' ,
        a.SerialNumber  as '条码',
        a.DateCode ,
        CASE a.Lock_Flag
          WHEN 0 THEN '正常'
          WHEN 1 THEN '盘点'
          WHEN 2 THEN '库内冻结'
          WHEN 3 THEN '二次送检'
          WHEN 4 THEN '报废'
          WHEN 5 THEN '二次送检NG'
          WHEN 6 THEN '备料'
          WHEN 7 THEN '出库中'
          WHEN '8' THEN '合盘'
          WHEN '9' THEN '库外冻结'
          WHEN '10' THEN '退料中'
        END AS '状态' ,
        a.Lot_No as '批次' ,
        CASE ( a.QC_Result )
          WHEN 1 THEN '允收'
          WHEN 2 THEN '拒收'
          WHEN 3 THEN '让步接收'
          WHEN 5 THEN '挑选'
        END AS '品质检验结果'
FROM    T_Bllb_StockInfo_tbsi a
        left JOIN T_Bllb_Storage_tbs b ON a.Storage_SN = b.Storage_SN
		left JOIN dbo.T_Bllb_StorageArea_tbsa c ON a.Area_SN=c.Area_SN
		left JOIN  dbo.T_Bllb_StorageLocation_tbsl AS d ON a.Location_SN=d.Location_SN
WHERE   a.Lock_Flag IN ('0','1','2') and a.Location_SN <>'' And a.Area_SN <>''  {0} ", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }


        /// <summary>
        /// 库存查询导出
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable QueryExportDetailAll(string strWhere)
        {
            string strSql = string.Format(@"
SELECT  b.Storage_Name as '仓库',
        a.MaterialCode as '料号' ,
		c.Area_Name as '库区',
		d.Location_Name as '库位',
        a.QTY as '数量' ,
        a.In_Time as '入库时间' ,
        a.SerialNumber  as '条码',
        a.DateCode ,
        CASE a.Lock_Flag
          WHEN 0 THEN '正常'
          WHEN 1 THEN '盘点'
          WHEN 2 THEN '库内冻结'
          WHEN 3 THEN '二次送检'
          WHEN 4 THEN '报废'
          WHEN 5 THEN '二次送检NG'
          WHEN 6 THEN '备料'
          WHEN 7 THEN '出库中'
          WHEN '8' THEN '合盘'
          WHEN '9' THEN '库外冻结'
          WHEN '10' THEN '退料中'
        END AS '状态' ,
        a.Lot_No as '批次' ,
        CASE ( a.QC_Result )
          WHEN 1 THEN '允收'
          WHEN 2 THEN '拒收'
          WHEN 3 THEN '让步接收'
          WHEN 5 THEN '挑选'
        END AS '品质检验结果'
FROM    T_Bllb_StockInfo_tbsi a
        left JOIN T_Bllb_Storage_tbs b ON a.Storage_SN = b.Storage_SN
		left JOIN dbo.T_Bllb_StorageArea_tbsa c ON a.Area_SN=c.Area_SN
		left JOIN  dbo.T_Bllb_StorageLocation_tbsl AS d ON a.Location_SN=d.Location_SN
WHERE   1=1  {0} ", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }

        /// <summary>
        /// 库存汇总导出
        /// </summary>
        /// <param name="querywhere"></param>
        /// <param name="querycolumn"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public static DataTable QueryExportAll(string querywhere, string querycolumn, string group)
        {
            string strSql = string.Format(@"
SELECT  sum(a.QTY) as QTY  {1} from T_Bllb_StockInfo_tbsi  a
LEFT join T_Bllb_Storage_tbs b on a.Storage_SN=b.Storage_SN
LEFT JOIN T_Bllb_StorageArea_tbsa c ON a.Area_SN=c.Area_SN
LEFT JOIN T_Bllb_StorageLocation_tbsl d ON a.Location_SN=d.Location_SN
where a.Lock_Flag IN ('0','1','2') {0}  group by {2}
", querywhere, querycolumn, group);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        public static DataTable StockExportAll(string strWhere)
        {
            string strSql = string.Format(@"
SELECT b.Storage_Name as '仓库',c.Area_Name as '库区',d.Location_Name as '库位',a.MaterialCode as '料号',SUM(a.QTY) AS '数量' FROM dbo.T_Bllb_StockInfo_tbsi a
LEFT JOIN [dbo].[T_Bllb_Storage_tbs] b ON a.Storage_SN=b.Storage_SN
LEFT JOIN [dbo].[T_Bllb_StorageArea_tbsa] c ON a.Area_SN=c.Area_SN
LEFT JOIN [dbo].[T_Bllb_StorageLocation_tbsl] d ON a.Location_SN=d.Location_SN  {0} AND a.Lock_Flag IN ('0','1','2') And a.Location_SN <>'' And a.Area_SN <>''
GROUP BY b.Storage_Name,c.Area_Name,d.Location_Name,a.MaterialCode", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 根据仓库查询库区（联动查询）
        /// </summary>
        /// <returns></returns>
        public static DataTable QueryStorage(string strWhere)
        {
            string strSql = string.Format(@"SELECT Distinct a.Area_SN,  b.Area_Name FROM  T_Bllb_StockInfo_tbsi a
LEFT JOIN T_Bllb_StorageArea_tbsa  b ON a.Area_SN = b.Area_SN
  {0}  AND b.Area_SN is not null and b.Area_SN<>'' ORDER BY a.Area_SN asc", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 根据仓库库区查询库位
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable QueryLocation(string strWhere)
        {
            string strSql = string.Format(@"SELECT DISTINCT a.Location_SN, c.Location_Name FROM  T_Bllb_StockInfo_tbsi a
LEFT JOIN T_Bllb_StorageArea_tbsa  b ON a.Area_SN=b.Area_SN
LEFT JOIN T_Bllb_StorageLocation_tbsl  c ON a.Location_SN=c.Location_SN
 {0}  and a.Location_SN is not null and a.Location_SN<>''", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
       
    }
}
