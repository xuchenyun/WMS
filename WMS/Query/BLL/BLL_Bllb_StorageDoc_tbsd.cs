using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.BLL
{
    public class BLL_Bllb_StorageDoc_tbsd
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Query(string strWhere)
        {
            string strSql = string.Format(" select *  from T_Bllb_StorageDoc_tbsd {0}", strWhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, strSql);
        }

        public static DataTable QueryData(string strWhere)
        {
            string strSql = string.Format(@"
SELECT  a.S_Doc_NO ,
        a.S_Doc_Type,
        CASE a.Creator
          WHEN b.UserID THEN b.UserName
        END 'Creator',
        a.Create_Time,
        a.Before_Doc_No,
        CASE a.IsAutoCreate
          WHEN 'N' THEN '人工开单'
          WHEN 'Y' THEN '自动生成'
          ELSE '人工开单'
        END 'IsAutoCreate'
FROM    T_Bllb_StorageDoc_tbsd AS a
        LEFT JOIN dbo.SysDatUser AS b ON a.Creator = b.UserID {0}", strWhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="listStorageDoc"></param>
        /// <param name="listMaterial"></param>
        /// <returns></returns>
        public static bool SaveStorageDoc(List<T_Bllb_StorageDoc_tbsd> listStorageDoc, List<T_Bllb_StorageDocMaterial_tsdm> listMaterial)
        {
            StringBuilder strbild = new StringBuilder();
            foreach (T_Bllb_StorageDoc_tbsd model_tbsd in listStorageDoc)
            {
                strbild.AppendFormat(@"
INSERT INTO T_Bllb_StorageDoc_tbsd( S_Doc_NO ,S_Doc_Type ,Create_Time ,Creator ) VALUES  ( '{0}' ,'{1}',GETDATE(),'{2}')",
model_tbsd.S_Doc_NO, model_tbsd.S_Doc_Type, model_tbsd.Creator);
            }
            foreach (T_Bllb_StorageDocMaterial_tsdm model_tsdm in listMaterial)
            {
                strbild.AppendFormat(@"
INSERT  INTO T_Bllb_StorageDocMaterial_tsdm( S_Doc_NO, MaterialCode, Plan_Qty ) VALUES  ( '{0}', '{1}', '{2}' )",
model_tsdm.S_Doc_NO, model_tsdm.MaterialCode, model_tsdm.Plan_Qty);
            }
            if (strbild.Length > 0)
            {
                return CIT.Wcf.Utils.NMS.ExecTransql(CIT.MES.PubUtils.uContext, strbild.ToString());
            }
            return true;
        }
        /// <summary>
        /// 获得流水
        /// </summary>
        /// <param name="type"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        public static DataTable GetFlow(string type, string head)
        {
            int count_head_Length = head.Length;
            string sqlcmd = string.Format(@"
DECLARE @flow VARCHAR(50)
IF NOT EXISTS ( SELECT  *
                FROM    dbo.T_Bllb_StorageDoc_tbsd
                WHERE   DATEDIFF(DAY, Create_Time, GETDATE()) = 0
                        AND S_Doc_Type = '{0}' )
    BEGIN 
		--当天不存在该类型订单
        SET @flow = CONVERT(VARCHAR, GETDATE(), 112) + '001'
        SELECT  1 ,
                @flow AS 'flow'
        RETURN
    END
ELSE
    BEGIN
		--当天存在该类型订单 
        SELECT TOP 1
                @flow = S_Doc_NO
        FROM    T_Bllb_StorageDoc_tbsd
        WHERE   S_Doc_Type = '{0}'
                AND DATEDIFF(DAY, Create_Time, GETDATE()) = 0
        ORDER BY Create_Time DESC
        SET @flow = CONVERT(VARCHAR, GETDATE(), 112) + RIGHT('000'
                                                             + CONVERT(VARCHAR, CONVERT(BIGINT, ISNULL(SUBSTRING(@flow,
                                                              {1}, {2}), 0))
                                                             + 1), 3)   
        SELECT  1 ,
                @flow AS 'flow'
        RETURN
    END", type, count_head_Length + 1, (count_head_Length + 1) + 8);
            return CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool Delete(string strWhere)
        {
            string strSql = string.Format(@" Delete from T_Bllb_StorageDoc_tbsd {0}
                                             Delete from T_Bllb_StorageDocMaterial_tsdm  {0}", strWhere);
            return CIT.Wcf.Utils.NMS.ExecTransql(CIT.MES.PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询单锯头
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable QueryDocType(string strWhere)
        {
            string sqlcmd = string.Format("SELECT *  FROM dbo.T_Bllb_DocType_tbdt {0}", strWhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 开立单据
        /// </summary>
        /// <param name="model_doc"></param>
        /// <param name="listMaterial"></param>
        /// <returns></returns>
        public static bool InsertStorageDocWithMaterial(T_Bllb_StorageDoc_tbsd model_doc, List<T_Bllb_StorageDocMaterial_tsdm> listMaterial)
        {
            StringBuilder strbild = new StringBuilder();
            strbild.AppendFormat(@"INSERT INTO T_Bllb_StorageDoc_tbsd( S_Doc_NO ,S_Doc_Type ,Create_Time ,Creator,Before_Doc_No,PLCode,WoCode,SfcNo )
VALUES ( '{0}' ,'{1}',GETDATE(),'{2}','{3}','{4}','{5}','{6}')", model_doc.S_Doc_NO, model_doc.S_Doc_Type, model_doc.Creator, model_doc.Before_Doc_NO, model_doc.PLCode, model_doc.WoCode, model_doc.SfcNo);
            foreach (T_Bllb_StorageDocMaterial_tsdm model_material in listMaterial)
            {
                strbild.AppendFormat(@"
INSERT  INTO T_Bllb_StorageDocMaterial_tsdm( S_Doc_NO, MaterialCode, Plan_Qty,RowNumber,Ver ) VALUES  ( '{0}', '{1}', '{2}','{3}','{4}' )",
model_material.S_Doc_NO, model_material.MaterialCode, model_material.Plan_Qty, model_material.RowNumber, model_material.Ver);
            }
            return CIT.Wcf.Utils.NMS.ExecTransql(CIT.MES.PubUtils.uContext, strbild.ToString());
        }
        /// <summary>
        /// 查询物料汇总表
        /// </summary>
        /// <param name="querywhere"></param>
        /// <returns></returns>

        public static DataTable QueryStorageMaterial(string querywhere)
        {
            string sqlcmd = string.Format("SELECT *  FROM  T_Bllb_StorageDocMaterial_tsdm {0}", querywhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 查询明细表
        /// </summary>
        /// <param name="querywhere"></param>
        /// <returns></returns>
        public static DataTable QueryStorageDetail(string querywhere)
        {
            string sqlcmd = string.Format(@"
SELECT a.S_Doc_NO,a.SerialNumber,a.MaterialCode,a.DateCode,a.MPN,CASE a.Creator WHEN b.UserID THEN b.UserName END 'Creator',
a.Create_Time FROM  T_Bllb_StorageDocDetail_tbsdd  AS a
LEFT JOIN dbo.SysDatUser AS b ON a.Creator = b.UserID {0}", querywhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sqlcmd);
        }

        public static DataTable GetStorageDocFlow(string type, string head)
        {
            int count_head_Length = head.Length;
            string sqlcmd = string.Format(@"
DECLARE @flow VARCHAR(50)
IF NOT EXISTS ( SELECT  *
                FROM    dbo.T_Bllb_StorageDoc_tbsd
                WHERE   DATEDIFF(DAY, Create_Time, GETDATE()) = 0
                        AND S_Doc_Type = '{0}' )
    BEGIN 
		--当天不存在该类型订单
        SET @flow = CONVERT(VARCHAR, GETDATE(), 12) + '0001'
        SELECT  1 ,
                @flow AS 'flow'
        RETURN
    END
ELSE
    BEGIN
		--当天存在该类型订单 
        SELECT TOP 1
                @flow = S_Doc_NO
        FROM    T_Bllb_StorageDoc_tbsd
        WHERE   S_Doc_Type = '{0}'
                AND DATEDIFF(DAY, Create_Time, GETDATE()) = 0
        ORDER BY Create_Time DESC
        SET @flow = CONVERT(VARCHAR, GETDATE(), 12) + RIGHT('0000'
                                                             + CONVERT(VARCHAR, CONVERT(BIGINT, ISNULL(SUBSTRING(@flow,
                                                              {1}, {2}), 0))
                                                             + 1), 4)   
        SELECT  1 ,
                @flow AS 'flow'
        RETURN
    END", type, count_head_Length + 9, count_head_Length + 11);
            return CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sqlcmd);
        }


        /// <summary>
        /// 成品单据
        /// </summary>
        /// <param name="model_doc"></param>
        /// <param name="listMaterial"></param>
        /// <returns></returns>
        public static bool InsertFinishStorageDoc(T_Bllb_StorageDoc_tbsd model_doc, List<T_Bllb_StorageDocMaterial_tsdm> listMaterial)
        {
            StringBuilder strbild = new StringBuilder();
            strbild.AppendFormat(@"INSERT INTO T_Bllb_StorageDoc_tbsd( S_Doc_NO ,S_Doc_Type ,Create_Time ,Creator,Before_Doc_No,PLCode,WoCode,SfcNo,Source_Storage )
VALUES ( '{0}' ,'{1}',GETDATE(),'{2}','{3}','{4}','{5}','{6}','{7}')", model_doc.S_Doc_NO, model_doc.S_Doc_Type, model_doc.Creator, model_doc.Before_Doc_NO,
model_doc.PLCode, model_doc.WoCode, model_doc.SfcNo, model_doc.Source_Storage);
            foreach (T_Bllb_StorageDocMaterial_tsdm model_material in listMaterial)
            {
                strbild.AppendFormat(@"
INSERT  INTO T_Bllb_StorageDocMaterial_tsdm( S_Doc_NO, MaterialCode, Plan_Qty,RowNumber ) VALUES  ( '{0}', '{1}', '{2}','{3}' )",
model_material.S_Doc_NO, model_material.MaterialCode, model_material.Plan_Qty, model_material.RowNumber);
            }
            return CIT.Wcf.Utils.NMS.ExecTransql(CIT.MES.PubUtils.uContext, strbild.ToString());
        }
    }
}
