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
    public class Bll_Bllb_StorageDoc_tbsd
    {
        public static DataTable GetListofDocNo(string strWhere)
        {
            string strSql = string.Format(@"SELECT top 50 S_Doc_NO FROM T_Bllb_StorageDoc_tbsd {0}", strWhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Query(string strWhere)
        {
            //   StringBuilder strSql = new StringBuilder();
            //   strSql.Append(@"SELECT SD.S_Doc_NO,SD.S_Doc_Type,SD.PLCode,M.MaterialCode,M.QTY, SD.Memo,
            //                           SD.Create_Time,U.UserName,MDC.Spec ,S.Storage_SN,S.Storage_Name,S.Status_Flag  FROM dbo.T_Bllb_StorageDoc_tbsd AS SD
            //                           LEFT JOIN dbo.T_Bllb_StorageDocMaterial_tsdm AS M
            //                           ON M.S_Doc_NO = SD.S_Doc_NO
            //                           LEFT JOIN dbo.SysDatUser AS U
            //                           ON U.UserID=SD.Creator
            //LEFT JOIN MdcdatMaterial MDC ON MDC.MATERIALCODE=M.MATERIALCODE
            //                           LEFT JOIN (SELECT DISTINCT A.S_Doc_NO,D.Storage_SN,D.Storage_Name ,A.Status_Flag 
            //FROM T_Bllb_StorageDocDetail_tbsdd A
            //LEFT JOIN T_Bllb_StorageLocation_tbsl B ON A.Location_SN=B.Location_SN
            // LEFT JOIN T_Bllb_StorageArea_tbsa C ON C.Area_SN=B.Area_SN
            //LEFT JOIN T_Bllb_Storage_tbs D ON C.Storage_SN=D.Storage_SN ) S
            //   ON SD.S_Doc_NO=S.S_DOC_NO");
           
           string strSql=string.Format(@"SELECT a.S_Doc_NO,b.MaterialCode,b.QTY,a.Create_Time, c.UserName FROM dbo.T_Bllb_StorageDoc_tbsd a
LEFT JOIN dbo.T_Bllb_StorageDocMaterial_tsdm b ON a.S_DOC_NO=b.S_Doc_NO
LEFT JOIN sysdatuser c ON a.Creator=c.UserID WHERE a.S_Doc_Type='6' {0}", strWhere);
            
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        ///单击右边datagridview 查询仓库单据详细信息数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable SelectSDoDetial(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT D.S_Doc_NO,D.PLCode,D.MaterialCode,D.Container_Type,D.QTY,D.Create_Time,D.Creator,D.Location_SN,D.Container_SN,CASE D.Status_Flag WHEN '1' THEN '正常品' ELSE '样品' END AS Status_Flag_Name FROM T_Bllb_StorageDocDetail_tbsdd  AS D
				LEFT JOIN T_Bllb_StorageDoc_tbsd AS SD
				ON SD.S_Doc_NO=D.S_Doc_NO");
            if (strWhere != string.Empty)
            {
                strSql.Append(strWhere);

            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Insert(Model.T_Bllb_StorageDoc_tbsd obj)
        {

            string strSql = string.Format(@"INSERT INTO T_Bllb_StorageDoc_tbsd(S_Doc_NO,S_Doc_Type,Create_Time,Creator,Memo,PLCode,LotNo) VALUES('{0}','{1}',GETDATE(),'{2}','{3}','{4}','{5}')", obj.S_Doc_NO, obj.S_Doc_Type, obj.Creator, obj.Memo, obj.PLCode, obj.LotNo);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }

        /// <summary>
        /// 退料结束
        /// </summary>
        /// <param name="S_Doc_NO"></param>
        /// <returns></returns>
        public static bool UpdateReback_Over(string S_Doc_NO)
        {
            string strSql = string.Format(@"UPDATE T_Bllb_StorageDoc_tbsd SET Reback_Over='Y' WHERE  S_Doc_NO='{0}'", S_Doc_NO);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        public static int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  count(1) FROM dbo.T_Bllb_StorageDoc_tbsd");
            if (strWhere != string.Empty)
            {
                strSql.Append(strWhere);
            }
            return NMS.GetTableCount(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 查询容器最后一次所在单据
        /// </summary>
        /// <param name="S_Doc_Typ"></param>
        /// <param name="container_SN"></param>
        /// <returns></returns>
        public static DataTable QueryByContainer_SN(string S_Doc_Typ, string container_SN)
        {
            string strSql = string.Format(@"SELECT D.S_Doc_NO, D.PLCode, D.MaterialCode, 
                 D.Container_Type, D.QTY, D.Create_Time, D.Creator ,D.First_In_Stock_Time,D.status_flag
                 FROM T_Bllb_StorageDocDetail_tbsdd  AS D
                LEFT JOIN T_Bllb_StorageDoc_tbsd AS SD
                ON SD.S_Doc_NO = D.S_Doc_NO WHERE container_SN='{0}' AND S_DOC_TYPE='{1}' order by Create_Time desc", container_SN, S_Doc_Typ);
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 修改单据线别信息
        /// </summary>
        /// <param name="S_Doc_NO">单据号</param>
        /// <param name="PLCode">线别代码</param>
        /// <returns></returns>
        public static bool UpdatePLCode(string S_Doc_NO, string PLCode)
        {
            string strSql = string.Format(@"UPDATE T_Bllb_StorageDoc_tbsd SET PLCode='{1}'  WHERE S_Doc_NO='{0}'",
                S_Doc_NO, PLCode);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 获得调拨单据号
        /// </summary>
        /// <returns></returns>
        public static string Get_MaterialMove_Doc()
        {
            string strSql = string.Format(@"declare @Doc_NO varchar(50)
if not exists(select * from T_Bllb_StorageDoc_tbsd where DATEDIFF(DAY, Create_Time, GETDATE()) = 0 and S_Doc_NO like 'DB%')
begin
   select @Doc_NO='DB'+CONVERT(varchar,GETDATE(),112)+'001'
   select @Doc_NO as 'Doc_NO'
end
else
begin
   select top 1 @Doc_NO = S_Doc_NO  from T_Bllb_StorageDoc_tbsd WHERE S_Doc_NO like 'DB%' order by Create_Time desc
      set  @Doc_NO = 'DB'+ CONVERT(varchar, GETDATE(), 112) + right('000' + convert(varchar, convert(bigInt, isNull(substring(@Doc_NO,3, 11), 0)) + 1), 3)
	  select @Doc_NO as 'Doc_NO'
end");
            return NMS.QueryDataTable(PubUtils.uContext, strSql).Rows[0]["Doc_NO"].ToString();
        }
        /// <summary>
        /// 新增物料调拨
        /// </summary>
        /// <param name="SC"></param>
        /// <param name="SCD"></param>
        /// <returns></returns>
        public static bool InsertDoc(T_Bllb_StorageDoc_tbsd SC)
        {
            string strSql = string.Format(@"insert into T_Bllb_StorageDoc_tbsd(S_Doc_NO,Source_Storage,Target_Storage,Memo,Creator,Create_Time) Values('{0}','{1}','{2}','{3}','{4}',getdate())
update T_Bllb_StorageDoc_tbsd set S_Doc_Type=6 where S_Doc_NO='{0}'", SC.S_Doc_NO, SC.Source_Storage, SC.Target_Storage, SC.Memo,PubUtils.uContext.UserID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询物料调拨
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable QueryMaterialDoc(string strWhere)
        {
            string strSql = string.Format(@"select a.S_Doc_NO,b.MaterialCode,b.Plan_Qty,b.QTY,case a.Source_Storage when (select Storage_SN  from T_Bllb_Storage_tbs where Storage_SN=a.Source_Storage) then (select Storage_Name from T_Bllb_Storage_tbs where Storage_SN=a.Source_Storage) end  Source_Storage,case a.Target_Storage when (select Storage_SN  from T_Bllb_Storage_tbs where Storage_SN=a.Target_Storage) then (select Storage_Name  from T_Bllb_Storage_tbs where Storage_SN=a.Target_Storage) end  Target_Storage,c.UserName,a.Create_Time,a.Memo from  T_Bllb_StorageDoc_tbsd a
left join  T_Bllb_StorageDocMaterial_tsdm b on a.S_Doc_NO=b.S_Doc_NO
left join SysDatUser c on  a.Creator=c.UserID where S_Doc_Type=6 {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除调拨数据
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public static bool Delete(string strwhere)
        {
            string strSql = string.Format(@"delete T_Bllb_StorageDoc_tbsd {0}
delete T_Bllb_StorageDocMaterial_tsdm {0}", strwhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        public static DataTable Select_S_Doc(T_Bllb_StorageDoc_tbsd s_Doc)
        {
            string strSql = string.Format("select * from T_Bllb_StorageDoc_tbsd where S_Doc_NO='{0}'", s_Doc.S_Doc_NO);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }



    }
}
