using CIT.MES;
using CIT.Wcf.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData.BLL
{
    public class Bll_Bllb_ProductCode_tbpc
    {
        /// <summary>
        /// 查询产品表数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Select(string strWhere)
        {
            string strSql = string.Format(@"select a.TBPC_ID, a.ProductCode,a.Version,b.UserName,a.CreateTime from T_Bllb_ProductCode_tbpc a left join sysdatuser b on a.Creator=b.UserID {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 新增产品代码
        /// </summary>
        /// <param name="PC"></param>
        /// <returns></returns>
        public static bool Insert (T_Bllb_ProductCode_tbpc PC)
        {
            string strSql=string.Format(@"insert into T_Bllb_ProductCode_tbpc(TBPC_ID,ProductCode,Version,Creator,CreateTime) Values('{0}','{1}','{2}','{3}',getdate())", PC.TBPC_ID, PC.ProductCode,PC.Version,PubUtils.uContext.UserID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除产品代码表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool Delete(string TBPC_ID,string productCode)
        {
            string strSql = string.Format(@"delete T_Bllb_ProductCode_tbpc WHERE ProductCode='{1}'
             DELETE dbo.T_Bllb_BaseBom_tbbb WHERE TBPC_ID='{0}'
             DELETE MdcdatProductDetail WHERE ProductCode='{1}'", TBPC_ID, productCode);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        public static DataTable  Exist(string strWhere)
        {
            string strSql = string.Format(@"  select * from T_Bllb_ProductCode_tbpc a
left join T_Bllb_BaseBom_tbbb b 
on a.TBPC_ID = b.TBPC_ID {0}",strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询产品属性
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable SelectAttribute(string strWhere)
        {
            string strSql = string.Format("SELECT key1,Value2,Value1,Value3 FROM MdcdatProductDetail where {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除产品属性
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool DeleteAttribute(string strWhere)
        {
            string strSql = string.Format("Delete MdcdatProductDetail where {0}", strWhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询产品属性
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable SelectAttr(string strWhere)
        {
            string strSql = string.Format("SELECT CASE  key1 WHEN 'PCB' THEN 'PCB' WHEN 'SteelNet' THEN '钢网' WHEN 'SolderPaste' THEN '锡膏' WHEN 'FixTure' THEN '工装夹具' WHEN 'FrontScrape' THEN '前刮刀' WHEN 'RearScraper' THEN '后刮刀' END AS 'key1',CASE  Value2 WHEN '是' THEN '是' WHEN '否' THEN '否' END AS 'Value2',Value1,Value3 FROM MdcdatProductDetail  where {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
