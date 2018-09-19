using CIT.MES;
using CIT.Wcf.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.BLL
{
    public class Bll_Bllb_IQCDoc_tbid
    {
        public static string GetIqcDocByMaterialCode(string materialCode,string before_Doc_NO)
        {
            string strSql = string.Format(@"

DECLARE @F_SDoC_NO nvarchar(50)
DECLARE @QC_NO nvarchar(50)
DECLARE @MaterialCode nvarchar(50)
SET @MaterialCode='{0}'
SET @F_SDoC_NO='{1}'
--IF NOT EXISTS( SELECT * FROM T_Bllb_IQCDoc_tbid a  LEFT JOIN T_Bllb_StorageDocDetail_tbsdd b ON a.MaterialCode=b.MaterialCode  WHERE a.MaterialCode=@MaterialCode AND a.S_DOC_NO=@F_SDoC_NO AND DATEDIFF(DAY,GETDATE(),a.Create_Time)=0 )
--  BEGIN 
--    SET @QC_NO='QC'+CONVERT(varchar,GETDATE(),112)+'001'  
--	SELECT @QC_NO AS 'QC'
--	RETURN     
--  END
--ELSE
  BEGIN
	IF NOT EXISTS( SELECT * FROM T_Bllb_IQCDoc_tbid WHERE MaterialCode=@MaterialCode AND S_DOC_NO=@F_SDoC_NO   AND DATEDIFF(DAY,GETDATE(),Create_Time)=0 AND OVER_FLAG='N' AND Type='QC')
      BEGIN
		SELECT TOP 1 @QC_NO=IQC_NO FROM T_Bllb_IQCDoc_tbid WHERE   DATEDIFF(DAY,GETDATE(),Create_Time)=0 AND Type='QC' ORDER BY Create_Time DESC 
		SET @QC_NO = 'QC'+CONVERT(varchar,GETDATE(),112)+right('0000'+convert(varchar,convert(bigInt,isNull(substring(@QC_NO,11,14),0))+1 ),4) 
		SELECT @QC_NO AS 'QC' RETURN 
      END
	ELSE
	 BEGIN
	    SELECT TOP 1 @QC_NO=IQC_NO FROM T_Bllb_IQCDoc_tbid WHERE MaterialCode=@MaterialCode AND S_DOC_NO=@F_SDoC_NO  AND DATEDIFF(DAY,GETDATE(),Create_Time)=0 AND OVER_FLAG='N' AND Type='QC' ORDER BY Create_Time DESC 
		SELECT @QC_NO AS 'QC' RETURN 
	 END  
  END   ", materialCode, before_Doc_NO);
            return NMS.QueryDataTable(PubUtils.uContext, strSql).Rows[0]["QC"].ToString();
        }
    }
}
