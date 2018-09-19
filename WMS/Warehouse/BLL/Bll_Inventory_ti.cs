using CIT.Interface;
using CIT.MES;
using Model;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Warehouse.BLL
{
    public class Bll_Inventory_ti
    {
        #region 开盘点单
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="varMsg"></param>
        /// <returns></returns>
        public static bool Insert(T_Inventory_ti obj, out string varMsg)
        {
            //1.开单
            DataTable dt_check = new DataTable();
            string msg = string.Empty;
            string inventoryCode = CheckIsOK(dt_check, obj, ref msg);
            if (msg == "OK")
            {
                obj.InventoryCode = inventoryCode;
            }
            else
            {
                varMsg = msg;
                return false;
            }
            //2.取出对应仓库 料号的 数量
            string querypnWhere = string.Format(" where 1=1 and Lock_Flag='0' and Storage_SN='{0}'", obj.HouseCode);
            if (obj.StorageArea != null)
                querypnWhere = string.Format("{0} and Area_SN='{1}'", querypnWhere, obj.StorageArea);
            if (obj.PN != null)
                querypnWhere = string.Format("{0} and MaterialCode='{1}'", querypnWhere, obj.PN);
            string sqlInsert = string.Format(@"
declare @Qty decimal
declare @PartNumber nvarchar(50)
--获得对应仓库 每个料号的数量
if not exists(select *  from T_Bllb_StockInfo_tbsi {8})
	begin
		select '0','仓库没有对应的料号' return
	end
else
	begin
        insert into T_Inventory_ti(InventoryCode,HouseCode,HouseName,PN,StorageArea,StorageLocation,Creator,CreateTime,Status) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', getdate(),'{7}')
		select MaterialCode,sum(QTY) as 'Qty' into #a from T_Bllb_StockInfo_tbsi {8} group by MaterialCode
		select '1',* from #a 
		drop table #a
		return
	end
", obj.InventoryCode, obj.HouseCode, obj.HouseName, obj.PN, obj.StorageArea == null ? string.Empty : obj.StorageArea, obj.StorageLocation == null ? string.Empty : obj.StorageLocation, PubUtils.uContext.UserName, 0, querypnWhere);
            DataTable dt_Insert = NMS.QueryDataTable(PubUtils.uContext, sqlInsert);
            if (dt_Insert.Rows.Count > 0)
            {
                //有对应的料号
                if (dt_Insert.Rows[0][0].ToString() == "1")
                {
                    foreach (DataRow dr in dt_Insert.Rows)
                    {
                        string sqlInsert_PnQty = string.Format(@"insert into T_Inventory_Detail (InventoryCode,PN,Qty,CurrentQty,UnQty,DifferQty) values('{0}','{1}','{2}',0,'{2}',0)", obj.InventoryCode, dr["MaterialCode"].ToString(), dr["QTY"].ToString());
                        NMS.ExecTransql(PubUtils.uContext, sqlInsert_PnQty);
                    }
                }
                else
                {
                    //仓库没有对应的料号
                    varMsg = "仓库没有对应的料号，开单失败!";
                    return false;
                }
            }
            //获取对应的料盘编码
            string sqlInsert_Reelid = string.Format(@"select SerialNumber,QTY from dbo.T_Bllb_StockInfo_tbsi {0} group by SerialNumber,QTY
                                                      select SerialNumber,QTY from #a 
                                                      drop table #a", querypnWhere);
            DataTable dt_reelidInsert = NMS.QueryDataTable(PubUtils.uContext, sqlInsert_Reelid);
            if (dt_reelidInsert.Rows.Count > 0)
            {
                foreach (DataRow dr in dt_reelidInsert.Rows)
                {
                    string sqlInsert_ReelidQty = string.Format(@"
INSERT INTO T_InventoryDetail_tid
            ( InventoryCode ,
              ReelId ,
              Qty ,
              CurrentQty ,
              UnQty ,
              DifferQty ,
              Creator ,
              CreateTime ,
              Status
            )
     VALUES ( '{0}' ,
              '{1}' ,
              '{2}' ,
              0 ,
              '{2}' ,
              0 ,
              '{3}' ,
              GETDATE() ,
              1
            )
     UPDATE T_Bllb_StockInfo_tbsi
     SET    Lock_Flag = '1'
     WHERE  SerialNumber = '{1}'", obj.InventoryCode, dr["SerialNumber"].ToString(), dr["QTY"].ToString(),
                    PubUtils.uContext.UserName);
                    NMS.ExecTransql(PubUtils.uContext, sqlInsert_ReelidQty);
                }
            }
            varMsg = "OK";
            return true;
        }
        #endregion

        /// <summary>
        /// 查询盘点单
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Select(string strWhere)
        {
            string strSql = string.Format(@"
SELECT  A.InventoryCode ,
        A.HouseCode ,
        A.HouseName ,
        A.PN ,
        CASE A.Status
          WHEN 0 THEN '开立'
          WHEN 1 THEN '盘点中'
          WHEN 2 THEN '完成'
        END AS 'Status' ,
        CASE A.StorageArea
          WHEN b.Area_SN THEN b.Area_Name
        END AS 'StorageArea' ,
        A.StorageLocation ,
        A.Creator ,
        A.CreateTime
FROM    T_Inventory_ti AS A
        LEFT JOIN dbo.T_Bllb_StorageArea_tbsa AS b ON A.StorageArea = b.Area_SN {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询盘点单明细
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Query(string strWhere)
        {
            string strSql = string.Format(@"
SELECT  A.InventoryCode ,
        A.HouseCode ,
        A.HouseName ,
        B.PN ,
        CASE A.Status
          WHEN 0 THEN '开立'
          WHEN 1 THEN '盘点中'
          WHEN 2 THEN '完成'
        END AS 'Status' ,
        CASE A.StorageArea
          WHEN C.Area_SN THEN C.Area_Name
        END 'StorageArea' ,
        A.StorageLocation ,
        B.Qty ,
        B.CurrentQty ,
        B.UnQty ,
        B.DifferQty
FROM    T_Inventory_ti AS A
        INNER JOIN T_Inventory_Detail AS B ON A.InventoryCode = B.InventoryCode
        LEFT JOIN dbo.T_Bllb_StorageArea_tbsa AS C ON C.Area_SN = A.StorageArea {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询盘点单明细管理
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable QueryDetail(string strWhere)
        {
            string strSql = string.Format(@"
SELECT  A.InventoryCode ,
        B.ReelId ,
        A.HouseCode ,
        A.HouseName ,
        CASE B.Status
          WHEN 0 THEN '已盘'
          WHEN 1 THEN '未盘'
        END AS 'Status' ,
        CASE A.StorageArea
          WHEN C.Area_SN THEN C.Area_Name
        END 'StorageArea' ,
        A.StorageLocation ,
        B.Qty ,
        B.CurrentQty ,
        B.UnQty ,
        B.DifferQty ,
        A.Creator ,
        A.CreateTime,
		D.Location_SN,
		D.MaterialCode
FROM    T_Inventory_ti AS A
        INNER JOIN T_InventoryDetail_tid AS B ON A.InventoryCode = B.InventoryCode
        LEFT JOIN dbo.T_Bllb_StorageArea_tbsa AS C ON C.Area_SN = A.StorageArea
		LEFT JOIN dbo.T_Bllb_StockInfo_tbsi AS D ON D.SerialNumber=B.ReelId {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除盘点单
        /// </summary>
        /// <param name="InventoryCode"></param>
        /// <returns></returns>
        public static bool Delete(string InventoryCode)
        {

            bool resultBool = false;
            StringBuilder sqlSbuilder = new StringBuilder();
            //删除盘点单表
            sqlSbuilder.Append("DELETE FROM T_Inventory_ti WHERE InventoryCode = '").Append(InventoryCode).Append("';");
            sqlSbuilder.Append("DELETE FROM T_Inventory_Detail WHERE InventoryCode = '").Append(InventoryCode).Append("';");
            //删除盘点单之前，要把库存表对应的 SerialNumber的Lock_Flag标识 置为0
            sqlSbuilder.Append("UPDATE T_Bllb_StockInfo_tbsi ");
            sqlSbuilder.Append("   SET Lock_Flag = '0' ");
            sqlSbuilder.Append(" WHERE SerialNumber IN ");
            sqlSbuilder.Append("       ( ");
            sqlSbuilder.Append("       SELECT ReelId ");
            sqlSbuilder.Append("         FROM T_InventoryDetail_tid ");
            sqlSbuilder.Append("        WHERE InventoryCode = '").Append(InventoryCode).Append("'");
            sqlSbuilder.Append("       ); ");
            //删除盘点表
            sqlSbuilder.Append("DELETE FROM T_InventoryDetail_tid WHERE InventoryCode = '").Append(InventoryCode).Append("';");
            resultBool = NMS.ExecTransql(PubUtils.uContext, sqlSbuilder.ToString());
            return resultBool;
        }
        #region 校验是否可以开单
        /// <summary>
        /// 校验是否可以开单，并返回检验单号
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="obj"></param>
        /// <param name="varMsg"></param>
        /// <returns></returns>
        public static string CheckIsOK(DataTable dt, T_Inventory_ti obj, ref string varMsg)
        {
            string where_housecode = string.Format(" and a.HouseCode='{0}'", obj.HouseCode);
            string strSQL = string.Format(@"     
            select a.InventoryCode,a.HouseCode,d.Area_SN,d.MaterialCode from dbo.T_Inventory_ti as a 
            inner join dbo.T_Inventory_Detail as b on a.InventoryCode=b.InventoryCode
			inner join dbo.T_InventoryDetail_tid as c on c.InventoryCode=a.InventoryCode
			inner join dbo.T_Bllb_StockInfo_tbsi as d on c.ReelId=d.SerialNumber
            where a.Status<>'2' {0} group by a.InventoryCode,a.HouseCode,d.Area_SN,d.MaterialCode ", where_housecode);
            DataTable dt_Code = NMS.QueryDataTable(PubUtils.uContext, strSQL);
            List<string> lstGroup = new List<string>();
            if (dt_Code.Rows.Count > 0)
            {
                foreach (DataRow dr in dt_Code.Rows)
                {
                    lstGroup.Add(string.Format("{0}{1}{2}", dr["HouseCode"].ToString() == string.Empty ? "0" : dr["HouseCode"].ToString(),
                    dr["Area_SN"].ToString() == string.Empty ? "0" : dr["Area_SN"].ToString(),
                    dr["MaterialCode"].ToString() == string.Empty ? "0" : dr["MaterialCode"].ToString()));
                }
                if (obj.StorageArea == null && obj.PN == null)//库区为空  料号为空
                {
                    foreach (string item in lstGroup)
                    {
                        if (item.StartsWith(obj.HouseCode))
                        {
                            varMsg = "开单失败，存在未完成的盘点单!";
                            return null;
                        }
                    }
                }
                else if (obj.StorageArea != null && obj.PN != null)//库区不为空  料号不为空
                {
                    foreach (string item in lstGroup)
                    {
                        if (item.StartsWith(string.Format("{0}00", obj.HouseCode))
                            || item.StartsWith(string.Format("{0}{1}", obj.HouseCode, obj.StorageArea))
                            || (item.StartsWith(string.Format("{0}", obj.HouseCode))
                            && item.EndsWith(string.Format("{0}", obj.PN))))
                        {
                            varMsg = "开单失败，存在未完成的盘点单!";
                            return null;
                        }
                    }
                }
                else if (obj.StorageArea != null && obj.PN == null)//库区不为空  料号为空
                {
                    foreach (string item in lstGroup)
                    {
                        if (item.StartsWith(string.Format("{0}00", obj.HouseCode))
                         || item.StartsWith(string.Format("{0}{1}", obj.HouseCode, obj.StorageArea)))
                        {
                            varMsg = "开单失败，存在未完成的盘点单!";
                            return null;
                        }
                    }
                }
                else if (obj.StorageArea == null && obj.PN != null)//库位为空  料号不为空
                {
                    foreach (string item in lstGroup)
                    {
                        if (item.StartsWith(string.Format("{0}00", obj.HouseCode))
                            || (item.StartsWith(string.Format("{0}", obj.HouseCode)) && item.EndsWith(string.Format("{0}", obj.PN))))
                        {
                            varMsg = "开单失败，存在未完成的盘点单!";
                            return null;
                        }
                    }
                }
            }
            varMsg = "OK";
            return GetSn();
        }

        //获取盘点单号
        public static string GetSn()
        {
            string snString = string.Empty;
            string yymmddString = DateTime.Now.ToString("yyyyMMdd");

            //执行存储过程，将流水码+1
            CmdParameter[] parms = {
                new CmdParameter(){ParameterName="@KEYNAME", Value="InvCounting"}
                                 };
            bool flag = CIT.Wcf.Utils.NMS.ExecProcedures(PubUtils.uContext, "ITCounter", CommandType.StoredProcedure, true, parms);

            //获取到流水码
            StringBuilder sqlSelect = new StringBuilder();
            sqlSelect.Append(" SELECT ");
            sqlSelect.Append("        RIGHT(CAST('000'+RTRIM(keycount) AS VARCHAR(20)), ");
            sqlSelect.Append("        CASE WHEN LEN(keycount)<3 THEN 3 ELSE LEN(keycount) END) keycount  ");
            sqlSelect.Append("   FROM dbo.Ncounter  ");
            sqlSelect.Append("  WHERE     keyyear = '").Append(yymmddString).Append("'");
            sqlSelect.Append("        AND keyname = 'InvCounting'  ");

            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, sqlSelect.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                snString = "P" + yymmddString + dt.Rows[0][0].ToString();
            }

            return snString;
        }
        #endregion

        /// <summary>
        /// 获得差异数
        /// </summary>
        /// <param name="InventoryCode"></param>
        /// <returns></returns>
        public static DataTable CalculateDifferQty(string InventoryCode)
        {
            //计算差异数
            string strSql = string.Format(@"
 SELECT m.PN ,
        n.MaterialCode ,
        m.PNQty ,
        n.CurrentQty ,
        CONVERT(DECIMAL, ( CONVERT(DECIMAL, n.CurrentQty)
                           - CONVERT(DECIMAL,m.PNQty ) )) AS '差异数'
 FROM   ( SELECT    SUM(Qty) AS 'PNQty' ,
                    PN
          FROM      T_Inventory_Detail AS I
          WHERE     InventoryCode = '{0}'
          GROUP BY  PN
        ) m
        INNER JOIN ( SELECT SUM(CONVERT(DECIMAL, c.CurrentQty)) AS CurrentQty ,
                            c.MaterialCode
                     FROM   ( SELECT    a.InventoryCode ,
                                        a.ReelId ,
                                        b.MaterialCode ,
                                        a.CurrentQty ,
                                        a.DifferQty
                              FROM      T_InventoryDetail_tid a
                                        LEFT  JOIN dbo.T_Bllb_StockInfo_tbsi b ON a.ReelId = b.SerialNumber
                              WHERE     a.InventoryCode = '{0}'
                            ) c
                            LEFT  JOIN T_Inventory_Detail d ON c.MaterialCode = d.PN
                                                              AND c.InventoryCode = d.InventoryCode
                     WHERE  c.InventoryCode = '{0}'
                     GROUP BY c.MaterialCode
                   ) n ON n.MaterialCode = m.PN", InventoryCode);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }

        /// <summary>
        /// 盘点汇总
        /// </summary>
        /// <param name="DifferQty"></param>
        /// <param name="InventoryCode"></param>
        /// <param name="varPN"></param>
        /// <param name="varFlag"></param>
        /// <param name="InvetoryNum"></param>
        /// <returns></returns>
        public static bool Update_Inventory_Status(string DifferQty, string InventoryCode, string varPN, string varFlag, string InvetoryNum)
        {
            string sqlcmd = string.Format(@"
DECLARE @flag NVARCHAR(50)
BEGIN TRY
    BEGIN TRAN
    SET @flag = '{4}'
	--更新盘点单明细对应盘点单  对应料号的差异数
    UPDATE  T_Inventory_Detail
    SET     DifferQty = '{0}'
    WHERE   InventoryCode = '{1}'
            AND PN = '{2}'
	--盘盈盘亏需要插入 汇总表  刚好不做任何操作 
    IF ( @flag = '0'
         OR @flag = '1'
       )
        BEGIN         
            INSERT  INTO T_InventoryCodeCollect_ticc
                    ( InventoryNumber ,
                      InventoryCode ,
                      PN ,
                      DifferQty ,
                      Flag ,
                      Creator ,
                      CreateTime
                    )
            VALUES  ( '{5}' ,
                      '{1}' ,
                      '{2}' ,
                      '{0}' ,
                      '{4}' ,
                      '{3}' ,
                      GETDATE()
                    )
        END	
    COMMIT TRAN
END TRY
BEGIN CATCH
    ROLLBACK TRAN
END CATCH
", DifferQty,
InventoryCode, varPN, PubUtils.uContext.UserName, varFlag, InvetoryNum);
            if (NMS.ExecTransql(PubUtils.uContext, sqlcmd))
            {
                //更新盘点单状态为完成，并将T_Bllb_StockInfo_tbsi的标识 flag 置0 
                string sqlGetReelid = string.Format(@"
--更新盘点单号状态为已汇总
UPDATE  T_Inventory_ti
SET     Status = '2'
WHERE   InventoryCode = '{0}'
--计算盘点单明细表该单据号下 每个料盘（未盘）的差异数
UPDATE  dbo.T_InventoryDetail_tid
SET     DifferQty = CONVERT(DECIMAL, CONVERT(DECIMAL,CurrentQty )
        - CONVERT(DECIMAL, Qty))
WHERE   InventoryCode = '{0}'
        AND Status = '1'
--获得每个料盘的Reelid
SELECT  *
FROM    T_InventoryDetail_tid
WHERE   InventoryCode = '{0}'", InventoryCode);
                //获得reelid
                DataTable dt_InventoryCode = NMS.QueryDataTable(PubUtils.uContext, sqlGetReelid);
                string sql_update_flag = string.Empty;
                //将每个SerialNumber的仓库标识还原为0
                foreach (DataRow dr in dt_InventoryCode.Rows)
                {
                    sql_update_flag += string.Format(@"
UPDATE  T_Bllb_StockInfo_tbsi
SET     Lock_Flag = '0',
        QTY = '{0}'
WHERE   SerialNumber = '{1}'", dr["CurrentQty"].ToString(), dr["ReelId"].ToString());
                }
                if (sql_update_flag != string.Empty)
                {
                    NMS.ExecTransql(PubUtils.uContext, sql_update_flag);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除未盘料盘的id（库存表）
        /// </summary>
        /// <param name="varInventoryCode"></param>
        /// <returns></returns>
        public static bool DeleteUnInventory(string varInventoryCode)
        {
            //将盘点明细管理表未盘的SerialNumber在T_Bllb_StockInfo_tbsi表里删除
            bool resultBool = false;
            StringBuilder sqlSbuilder = new StringBuilder();
            sqlSbuilder.Append("DELETE FROM T_Bllb_StockInfo_tbsi ");
            sqlSbuilder.Append(" WHERE SerialNumber IN ( ");
            sqlSbuilder.Append("       SELECT ReelId ");
            sqlSbuilder.Append("         FROM T_InventoryDetail_tid");
            sqlSbuilder.Append("        WHERE Status = '1' ");
            sqlSbuilder.Append("          AND InventoryCode = '").Append(varInventoryCode).Append("'");
            sqlSbuilder.Append("       );");
            sqlSbuilder.Append("UPDATE SysDatRack ");
            sqlSbuilder.Append("   SET ReelId = '' ");
            sqlSbuilder.Append(" WHERE ReelId IN ( ");
            sqlSbuilder.Append("       SELECT ReelId ");
            sqlSbuilder.Append("         FROM T_InventoryDetail_tid");
            sqlSbuilder.Append("        WHERE Status = '1' ");
            sqlSbuilder.Append("          AND InventoryCode = '").Append(varInventoryCode).Append("'");
            sqlSbuilder.Append("       );");

            resultBool = NMS.ExecTransql(PubUtils.uContext, sqlSbuilder.ToString());
            return resultBool;
        }
        /// <summary>
        /// 获得盘盈盘亏单号
        /// </summary>
        /// <returns></returns>
        public static string GetInventoryNumber()
        {
            string sqlcmd = string.Format(@"
DECLARE @InventoryNumber VARCHAR(50)
IF NOT EXISTS ( SELECT  *
                FROM    T_InventoryType_tit
                WHERE   DATEDIFF(DAY, CreateTime, GETDATE()) = 0
                        AND Type = '盘盈盘亏单' )
    BEGIN 
		--当天不存在盘盈盘亏单
        SET @InventoryNumber = 'C' + CONVERT(VARCHAR, GETDATE(), 112) + '001' 
        DELETE  T_InventoryType_tit
        WHERE   Type = '盘盈盘亏单'
                AND DATEDIFF(DAY, CreateTime, GETDATE()) <> 0
        INSERT  INTO T_InventoryType_tit
                ( InventoryCode ,
                  Type ,
                  CreateTime
                )
        VALUES  ( @InventoryNumber ,
                  '盘盈盘亏单' ,
                  GETDATE()
                );
        SELECT  1 ,
                @InventoryNumber AS 'InventoryNumber'
        RETURN
    END
ELSE
    BEGIN
		--当天存在盘盈盘亏单
        SELECT TOP 1
                @InventoryNumber = InventoryCode
        FROM    T_InventoryType_tit
        WHERE   Type = '盘盈盘亏单'
        ORDER BY CreateTime DESC
        SET @InventoryNumber = 'C' + CONVERT(VARCHAR, GETDATE(), 112)
            + RIGHT('000'
                    + CONVERT(VARCHAR, CONVERT(BIGINT, ISNULL(SUBSTRING(@InventoryNumber,
                                                              2, 11), 0)) + 1),
                    3)   
        UPDATE  T_InventoryType_tit
        SET     InventoryCode = @InventoryNumber
        WHERE   Type = '盘盈盘亏单';
        SELECT  1 ,
                @InventoryNumber AS 'InventoryNumber'
        RETURN
    END  ");
            return NMS.QueryDataTable(PubUtils.uContext, sqlcmd).Rows[0]["InventoryNumber"].ToString();
        }
        /// <summary>
        /// 查询汇总
        /// </summary>
        /// <returns></returns>
        public static DataTable QueryCollectInfo(string strWhere)
        {
            string strSql = string.Format(@"
SELECT  A.InventoryCode ,
        A.InventoryNumber ,
        B.PN ,
        CASE A.Flag
          WHEN 0 THEN '盘盈'
          WHEN 1 THEN '盘亏'
        END AS 'Flag' ,
        A.DifferQty ,
        A.Creator ,
        A.CreateTime
FROM    T_InventoryCodeCollect_ticc AS A
        INNER JOIN T_Inventory_Detail AS B ON A.InventoryCode = B.InventoryCode AND A.PN = B.PN 
        {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
