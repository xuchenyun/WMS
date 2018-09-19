/*
  版权:  @Zach.zhong
  生成日期:2018/4/26   
  说明: T_Bllb_POMain_tbpm表业务层操作类                      
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIT.Wcf.Utils;
using CIT.MES;
using Model;

namespace Query.BLL
{
    class BLL_Bllb_POMain_tbpm
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere">where条件</param>
        /// <returns></returns>
		public static DataTable Query(string strWhere)
        {
            string sqlcmd = string.Format(@" 
SELECT  a.POID ,b.PO_DetailID,
		a.InCode AS '来料单',
        a.PO AS 'PO订单编号' ,
        a.SupplierCode AS '供应商编码' ,
        CASE a.EmployeeCode
          WHEN d.UserID THEN d.UserName
        END AS '员工号' ,
        CASE a.PO_TypeCode
          WHEN c.TYPE_CODE THEN c.TYPE_NAME
        END 'PO类型编码' ,
        a.CreateTime AS '创建时间' ,
        a.UpdateTime AS '更新时间' ,
        b.MaterialCode AS '料号' ,
        b.Quantity AS '计划数量' ,
        b.CurrentReceiveQty AS '入库数' ,
        b.ClearQty AS '清点数' 
FROM    T_Bllb_POMain_tbpm AS a
        LEFT JOIN dbo.T_Bllb_PODetail_tbpd AS b ON b.POID = a.POID
        LEFT JOIN [dbo].[T_Bllb_DocType_tbdt] AS c ON a.PO_TypeCode = c.TYPE_CODE
        LEFT JOIN dbo.SysDatUser AS d ON d.UserID = a.EmployeeCode
        {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 获得供应商
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetSuppliers(string strWhere)
        {
            string sqlcmd = string.Format("select *  from [dbo].[MdcDatSuppliesManage] {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 获得料号
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetMaterialCode(string strWhere)
        {
            string sqlcmd = string.Format("select *  from [dbo].[MdcdatMaterial] {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 获得来料订单流水
        /// </summary>
        /// <returns></returns>
        public static DataTable QueryPocodeFlow(string varPoType)
        {
            string sqlcmd = string.Format(@"
DECLARE @PONumber VARCHAR(50)
IF NOT EXISTS ( SELECT  *
                FROM    dbo.T_Bllb_POMain_tbpm
                WHERE   DATEDIFF(DAY, CreateTime, GETDATE()) = 0
                        AND PO_TypeCode = '{0}' )
    BEGIN 
		--当天不存在来料订单
        SET @PONumber = CONVERT(VARCHAR, GETDATE(), 112) + '001'
        SELECT  1 ,
                @PONumber AS 'PONumber'
        RETURN
    END
ELSE
    BEGIN
		--当天存在来料订单 
        SELECT TOP 1
                @PONumber = InCode
        FROM    T_Bllb_POMain_tbpm
        WHERE   PO_TypeCode = '{0}'
                AND DATEDIFF(DAY, CreateTime, GETDATE()) = 0
        ORDER BY CreateTime DESC
        SET @PONumber = CONVERT(VARCHAR, GETDATE(), 112) + RIGHT('000'
                                                              + CONVERT(VARCHAR, CONVERT(BIGINT, ISNULL(SUBSTRING(@PONumber,
                                                              3, 11), 0)) + 1),
                                                              3)   
        SELECT  1 ,
                @PONumber AS 'PONumber'
        RETURN
    END", varPoType);
            return NMS.QueryDataTable(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 批量插入订单
        /// </summary>
        /// <param name="lstPoMain"></param>
        /// <param name="lstPoDetail"></param>
        /// <returns></returns>
        public static bool AddListPocode(List<T_Bllb_POMain_tbpm> lstPoMain, List<T_Bllb_PODetail_tbpd> lstPoDetail)
        {
            StringBuilder strSql = new StringBuilder();

            foreach (T_Bllb_POMain_tbpm tbpm_obj in lstPoMain)
            {
                strSql.AppendFormat(@"
INSERT  INTO [dbo].[T_Bllb_POMain_tbpm]
        ( [POID] ,
          [PO] ,
          [PO_TypeCode] ,
          [CreateTime] ,
          [EmployeeCode] ,
          [InCode]
        )
VALUES  ( '{0}' ,
          '{1}' ,
          '{2}' ,
          GETDATE() ,
          '{3}' ,
          '{4}'
        )", tbpm_obj.POID, tbpm_obj.PO, tbpm_obj.PO_TypeCode, tbpm_obj.EmployeeCode,tbpm_obj.InCode);
            }
            foreach (T_Bllb_PODetail_tbpd tbpd_obj in lstPoDetail)
            {
                strSql.AppendFormat(@"
INSERT  INTO [dbo].[T_Bllb_PODetail_tbpd]
        ( POID ,
          PO_DetailID ,
          MaterialCode ,
          Quantity ,
          RowNumber ,
          PO
        )
VALUES  ( '{0}' ,
          NEWID() ,
          '{1}' ,
          '{2}' ,
          '{3}' ,
          '{4}'
        )", tbpd_obj.POID, tbpd_obj.MaterialCode, tbpd_obj.Quantity, tbpd_obj.RowNumber, tbpd_obj.PO);
            }
            if (strSql.Length > 0)
            {
                return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
            }
            return true;
        }

        public static DataTable GetPostatus(string po)
        {
            string strsql = string.Format("select  * from dbo.T_Bllb_PODetail_tbpd  where POID in ( select POID  from T_Bllb_POMain_tbpm where PO='{0}')", po);
            return NMS.QueryDataTable(PubUtils.uContext, strsql);
        }
        /// <summary>
        /// 获得单据类型头
        /// </summary>
        /// <param name="type_code"></param>
        /// <returns></returns>
        public static DataTable GetDoctypeHead(string type_code)
        {
            string strsql = string.Format("select *  from T_Bllb_DocType_tbdt where TYPE_CODE='{0}'", type_code);
            return NMS.QueryDataTable(PubUtils.uContext, strsql);
        }
        /// <summary>
        /// 删除PO订单
        /// </summary>
        /// <param name="pocode"></param>
        /// <returns></returns>
        public static bool DeletePocode(string pocode)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.AppendFormat("delete T_Bllb_PODetail_tbpd where POID in ( select POID  from T_Bllb_POMain_tbpm where PO='{0}')", pocode);
            strsql.AppendFormat("delete T_Bllb_POMain_tbpm where PO='{0}'", pocode);
            return NMS.ExecTransql(PubUtils.uContext, strsql.ToString());
        }
        public static DataTable GetList(string PO)
        {
            string strSql = string.Format(@"select B.MaterialCode,B.RowNumber,A.SupplierCode from T_Bllb_POMain_tbpm A 
LEFT JOIN dbo.T_Bllb_PODetail_tbpd B ON A.PO=B.PO
WHERE A.PO='{0}'", PO);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }

        /// <summary>
        /// 绑定采购单(未关闭的单据)
        /// </summary>
        /// <returns></returns>
        public static DataTable DataBindPO()
        {
            string strSql = string.Format(@"SELECT PO,POID FROM dbo.T_Bllb_POMain_tbpm WHERE Status='1' AND PO_TypeCode='1'");
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool Delete(string strWhere)
        {
            string strSql = string.Format(@" DELETE FROM T_Bllb_POMain_tbpm {0}", strWhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="container_sn"></param>
        /// <param name="container_type"></param>
        /// <returns></returns>
        public static bool Insert(string container_sn, string container_type)
        {
            string strSql = string.Format(@" INSERT INTO T_Bllb_POMain_tbpm(Container_SN,Container_Type) VALUES('{0}','{1}')", container_sn, container_type);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="PO"></param>
        /// <returns></returns>
        public static bool IsExist(string PO)
        {
            string strSql = string.Format("Select count(1) from T_Bllb_POMain_tbpm where PO='{0}'", PO);
            return NMS.GetTableCount(PubUtils.uContext, strSql) > 0 ? true : false;
        }
    }
}
