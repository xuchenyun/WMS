using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CIT.Wcf.Utils;
using CIT.MES;
using Model;

namespace Warehouse.BLL
{
    public class Bll_Bllb_StorageDocDetail_tbsdd
    {

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Insert(Model.T_Bllb_StorageDocDetail_tbsdd obj)
        {
            //string strSql = string.Format(@"INSERT INTO T_Bllb_StorageDocDetail_tbsdd(S_Doc_NO,PLCode,MaterialCode,QTY,Create_Time,Creator,Container_SN,Container_Type,Location_SN,Status_Flag) VALUES('{0}','{1}','{2}',{3},getdate(),'{4}','{5}','{6}','{7}','{8}')",
            //    obj.S_Doc_NO, obj.PLCode, obj.MaterialCode, obj.QTY, obj.Creator, obj.Container_SN, obj.Container_Type, obj.Location_SN, obj.Status_Flag);
            string strSql = string.Format(@"INSERT INTO T_Bllb_StorageDocDetail_tbsdd(S_Doc_NO,MaterialCode,QTY,Create_Time,Creator) VALUES('{0}','{1}','{2}',getdate(),'{3}')",
             obj.S_Doc_NO, obj.MaterialCode, obj.QTY, obj.Creator);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }

        /// <summary>
        /// 发料/退料时新增明细信息(明细中添加首次入库时间)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        //public static bool Insert2(Model.T_Bllb_StorageDocDetail_tbsdd obj)
        //{
        //    string strSql = string.Format(@"INSERT INTO T_Bllb_StorageDocDetail_tbsdd(S_Doc_NO,PLCode,MaterialCode,QTY,Create_Time,Creator,First_In_Stock_Time,Container_SN,Container_Type,Location_SN,Status_Flag) VALUES('{0}','{1}','{2}',{3},getdate(),'{4}',cast('{5}' AS datetime),'{6}','{7}','{8}','{9}')",
        //        obj.S_Doc_NO, obj.PLCode, obj.MaterialCode, obj.QTY, obj.Creator, obj.First_In_Stock_Time, obj.Container_SN, obj.Container_Type, obj.Location_SN, obj.Status_Flag);
        //    return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        //}
        /// <summary>
        /// 修改发料单明细中物料的退料标志
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        //public static bool UpdateRebackFlag(Model.T_Bllb_StorageDocDetail_tbsdd obj)
        //{
        //    string strSql = string.Format(@"UPDATE T_Bllb_StorageDocDetail_tbsdd SET Reback_Flag='Y'  WHERE S_Doc_NO='{0}' AND Container_SN='{1}'",
        //        obj.S_Doc_NO, obj.Container_SN);
        //    return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        //}

        /// <summary>
        /// 获取单据明细信息
        /// </summary>
        /// <param name="S_Doc_NO"></param>
        /// <returns></returns>
        public static DataTable GetListByS_Doc_NO(string S_Doc_NO, string reback_flag)
        {
            string strSql = string.Format(@"SELECT * FROM T_Bllb_StorageDocDetail_tbsdd WHERE S_Doc_NO='{0}' and Reback_Flag='{1}' order by create_time desc", S_Doc_NO, reback_flag);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 获取最后一次线体所发的物料的信息
        /// </summary>
        /// <param name="PLCode"></param>
        /// <param name="Status_Flag"></param>
        /// <param name="MaterialCode"></param>
        /// <returns></returns>
        public static DataTable GetListMaxTime(string PLCode, string Status_Flag, string MaterialCode)
        {
            string strSql = string.Format(@"SELECT TOP 1 T.* FROM T_Bllb_StorageDocDetail_tbsdd T LEFT JOIN
T_Bllb_StorageDoc_tbsd AS SD ON T.S_DOC_NO=SD.S_DOC_NO WHERE SD.S_Doc_Type='2' AND T.PLCode='{0}' and T.Status_Flag='{1}' and T.MaterialCode='{2}' order by create_time desc", PLCode, Status_Flag, MaterialCode);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 通过容器SN获取最后一次入库单或退料单
        /// </summary>
        /// <param name="Container_SN"></param>
        /// <returns></returns>
        public static DataTable GetListMaxDOC(string Container_SN)
        {
            string strSql = string.Format(@"SELECT TOP 1 T.S_DOC_NO FROM T_Bllb_StorageDocDetail_tbsdd T  LEFT JOIN
T_Bllb_StorageDoc_tbsd AS SD ON T.S_DOC_NO=SD.S_DOC_NO WHERE SD.S_Doc_Type in ('1','3') AND T.Container_SN='{0}' order by T.create_time desc", Container_SN);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改单据明细中的线别信息
        /// </summary>
        /// <param name="S_Doc_NO">单据号</param>
        /// <param name="Container_SN">容器SN</param>
        /// <param name="PLCode">线别代码</param>
        /// <returns></returns>
        public static bool UpdatePLCode(string S_Doc_NO, string Container_SN, string PLCode)
        {
            string strSql = string.Format(@"UPDATE T_Bllb_StorageDocDetail_tbsdd SET PLCode='{2}'  WHERE S_Doc_NO='{0}' AND Container_SN='{1}'",
                S_Doc_NO, Container_SN, PLCode);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }


        public static DataTable Query(string strWhere)
        {
            string sqlcmd = string.Format(@"
SELECT [S_Doc_NO]
      ,[PLCode]
      ,[MaterialCode]
      ,[QTY]
      ,[Create_Time]
      ,[Creator]
      ,[First_In_Stock_Time]
      ,[Container_SN]
      ,[Location_SN]
      ,[Reback_Flag]
      , case [Status_Flag] when '1' then '正常品' when '2' then '样品' end as 'Status_Flag'
  FROM [dbo].[T_Bllb_StorageDocDetail_tbsdd] {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 输入物料SN生成退料单
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public static DataTable Create_Return_Doc(string SN)
        {
            string strSql = string.Format(@"
DECLARE @SerialNumber nvarchar(50)
DECLARE @S_Doc_NO NVARCHAR(50)
DECLARE @Before_Doc_NO NVARCHAR(50)
DECLARE @MaterialCode nvarchar(50)
SET @SerialNumber='{0}' 
SELECT  TOP 1  @Before_Doc_NO= a.S_Doc_NO,@MaterialCode=b.MaterialCode   from T_Bllb_StorageDoc_tbsd a
LEFT JOIN T_Bllb_StorageDocDetail_tbsdd b on a.S_Doc_NO=b.S_Doc_NO  WHERE b.SerialNumber=@SerialNumber AND a.S_Doc_Type='7'  order by a.Create_Time DESC
IF (@Before_Doc_NO='' or @Before_Doc_NO is null)
BEGIN
 SELECT '0' as 'Result','条码不在发料单中' RETURN
END

--IF NOT EXISTS( SELECT * FROM T_Bllb_StorageDoc_tbsd WHERE Before_Doc_NO=@Before_Doc_NO  AND DATEDIFF(DAY,GETDATE(),Create_Time)=0 AND S_Doc_Type='6')
--  BEGIN 
--    SET @S_DOC_NO='TL'+CONVERT(VARCHAR,GETDATE(),112)+'001'  
--	SELECT '1' AS 'Result', @S_DOC_NO AS 'S_DOC_NO',@Before_Doc_NO AS 'Before_Doc_NO', @MaterialCode AS 'MaterialCode', '1' AS 'Flag'
--	RETURN     
--  END
--ELSE
  BEGIN
	IF NOT EXISTS(SELECT * FROM T_Bllb_StorageDoc_tbsd WHERE Before_Doc_NO=@Before_Doc_NO  AND DATEDIFF(DAY,GETDATE(),Create_Time)=0  AND S_Doc_Type='6' AND Close_Flag='N')
      BEGIN
		SELECT TOP 1 @S_DOC_NO=S_Doc_NO FROM T_Bllb_StorageDoc_tbsd WHERE  DATEDIFF(DAY,GETDATE(),Create_Time)=0  AND S_Doc_Type='6' ORDER BY Create_Time DESC 
		SET @S_DOC_NO = 'TL'+CONVERT(varchar,GETDATE(),112)+right('000'+convert(varchar,convert(bigInt,isNull(substring(@S_DOC_NO,3,11),0))+1 ),3) 
		SELECT '1' AS 'Result', @S_DOC_NO AS 'S_DOC_NO' ,@Before_Doc_NO AS 'Before_Doc_NO', @MaterialCode AS 'MaterialCode', '1' AS 'Flag' RETURN 
      END
    ELSE	
	  BEGIN
	    SELECT TOP 1 @S_DOC_NO=S_Doc_NO FROM T_Bllb_StorageDoc_tbsd WHERE Before_Doc_NO=@Before_Doc_NO AND DATEDIFF(DAY,GETDATE(),Create_Time)=0  AND S_Doc_Type='6' AND Close_Flag='N' ORDER BY Create_Time DESC 
	
		SELECT '1' AS 'Result', @S_DOC_NO AS 'S_DOC_NO' ,@Before_Doc_NO AS 'Before_Doc_NO', @MaterialCode AS 'MaterialCode', '0' AS 'Flag' RETURN 
      END     
  END   ", SN);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询条码数量
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public static DataTable Query_SN_Qty(string SN,string materialCode)
        {
            string strSql = string.Format("select Qty from Pub_UniquecodeInLine where UniqueCode='{0}' and MatrCode='{1}'", SN, materialCode);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 新增退料单据
        /// </summary>
        /// <param name="s_doc_no"></param>
        /// <param name="before_doc_no"></param>
        /// <param name="materialCode"></param>
        /// <param name="qty"></param>
        /// <param name="serialNumber"></param>
        /// <param name="iqc_doc"></param>
        /// <returns></returns>
        public static bool Insert_S_Doc_No(string s_doc_no, string before_doc_no, string materialCode, int qty, string serialNumber, string iqc_doc)
        {
            string strSql = string.Format(@"
INSERT  INTO T_Bllb_StorageDoc_tbsd
        ( S_Doc_NO ,
          S_Doc_Type ,
          Create_Time ,
          Creator ,
          Before_Doc_No
        )
VALUES  ( '{0}' ,
          '6' ,
          GETDATE() ,
          '{1}' ,
          '{2}'
        )", s_doc_no, PubUtils.uContext.UserID, before_doc_no, materialCode, serialNumber, qty);
            NMS.ExecTransql(PubUtils.uContext, strSql);
            return Insert_Return_Doc(s_doc_no, materialCode, qty, serialNumber, iqc_doc, before_doc_no);
        }
        /// <summary>
        /// 新增退料单据
        /// </summary>
        /// <param name="s_doc_no"></param>
        /// <param name="materialCode"></param>
        /// <param name="qty"></param>
        /// <param name="serialNumber"></param>
        /// <param name="iqc_doc"></param>
        /// <returns></returns>
        public static bool Insert_Return_Doc(string s_doc_no, string materialCode, int qty, string serialNumber, string iqc_doc,string before_doc_no)
        {
            string strSql = string.Format(@"
IF NOT EXISTS(SELECT *  FROM T_Bllb_StorageDocDetail_tbsdd WHERE S_Doc_NO='{0}'  AND SerialNumber='{4}' )
BEGIN
INSERT  INTO T_Bllb_StorageDocDetail_tbsdd
        ( S_Doc_NO ,
          MaterialCode ,
          QTY ,
          Create_Time ,
          Creator ,
          SerialNumber ,
          Reback_Flag
        )
VALUES  ( '{0}' ,
          '{1}' ,
          '{2}' ,
          GETDATE() ,
          '{3}' ,
          '{4}' ,
          'N'
        )
END
ELSE
BEGIN
    UPDATE T_Bllb_StorageDocDetail_tbsdd SET QTY=QTY +CAST('{2}' AS int) WHERE S_Doc_NO='{0}'  AND SerialNumber='{4}'
END

IF NOT EXISTS(SELECT *  FROM T_Bllb_StorageDocMaterial_tsdm WHERE S_Doc_NO='{0}' AND MaterialCode='{1}' )
BEGIN
     INSERT  INTO T_Bllb_StorageDocMaterial_tsdm
        ( S_Doc_NO, MaterialCode, QTY )
     VALUES  ( '{0}', '{1}', '{2}' )
END
ELSE
BEGIN
     UPDATE T_Bllb_StorageDocMaterial_tsdm SET QTY=QTY +CAST('{2}' AS int) WHERE S_Doc_NO='{0}' AND MaterialCode='{1}'   
END
-- IF NOT EXISTS(SELECT *  FROM T_Bllb_IQCDoc_tbid WHERE MaterialCode='{1}' AND IQC_NO='{5}' )
--BEGIN
--    INSERT  INTO T_Bllb_IQCDoc_tbid
--            ( IQC_NO, MaterialCode, QTY, Type,CREATE_TIME,S_DOC_NO )
--    VALUES  ( '{5}', '{1}', '{2}', 'QC',getdate(),'{6}' )
--END
--ELSE
--BEGIN
--    UPDATE T_Bllb_IQCDoc_tbid SET QTY=QTY +CAST('{2}' AS int) WHERE MaterialCode='{1}' AND IQC_NO='{5}'
--END
--INSERT  INTO T_Bllb_IQCProduct_tbip
--        ( TBIP_ID, IQC_NO, CREATE_TIME, SERIAL_NUMBER )
--VALUES  ( newid(), '{5}', getdate(), '{4}')
DELETE  PUB_UniqueCodeInLine
WHERE   UniqueCode = '{4}'
UPDATE T_Bllb_StockInfo_tbsi SET Lock_Flag='10',QTY={2} WHERE SerialNumber='{4}'
", s_doc_no, materialCode, qty, PubUtils.uContext.UserID, serialNumber, iqc_doc, before_doc_no);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 根据物料SN查询料号
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public static DataTable GetMaterialCodeBySN(string serialNumber)
        {
            string strSql = string.Format(" select MaterialCode from T_Bllb_StorageDocDetail_tbsdd where SerialNumber='{0}'", serialNumber);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 新增退料物料操作日志
        /// </summary>
        /// <param name="s_Doc_Detail"></param>
        /// <returns></returns>
        public static bool Write_Material_Log(string serialnumber, string materialCodee, int qty,string sfcNo)
        {
            string strSql = string.Format(@"
INSERT  INTO T_Bllb_MaterialLog_tbml
        (SerialNumber,
          CreateTime,
          OperateType,
          MaterialCode,
          QTY,
          Creator,
          sfcNo
        )
VALUES('{0}',
          GETDATE(),
          '退料',
          '{1}',
          '{2}',
          '{3}',
          '{4}'
        )", serialnumber, materialCodee, qty, PubUtils.uContext.UserID,sfcNo);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 退料信息
        /// </summary>
        /// <param name="serialnumber"></param>
        /// <returns></returns>
        public static DataTable IsReturn(string serialnumber)
        {
            string strSql = string.Format(@"
SELECT  *
FROM    dbo.T_Bllb_StorageDoc_tbsd AS a
        INNER JOIN dbo.T_Bllb_StorageDocDetail_tbsdd AS b ON a.S_Doc_NO = b.S_Doc_NO
WHERE   a.S_Doc_Type = '6'
        AND a.Close_Flag = 'N'
        AND b.SerialNumber = '{0}'", serialnumber);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询退料单据物料SN明细
        /// </summary>
        /// <returns></returns>
        public static DataTable QuerySDocDetail(string strWhere)
        {
            string strSql = string.Format("SELECT S_Doc_NO,MaterialCode,QTY,SerialNumber,case Receive_Flag WHEN 'Y' THEN '已退料' WHEN 'N' THEN '退料中' END AS 'Receive_Flag' FROM  T_Bllb_StorageDocDetail_tbsdd {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
