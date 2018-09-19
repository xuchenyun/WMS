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
    public class Bllb_ProductPrintInfo_tbpp
    {
        /// <summary>
        /// 查询产品打印标签
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Select(string strWhere)
        {
            string sqlcmd = string.Format(@" 
SELECT  a.ProductCode ,
        a.ProductSN ,
        a.Print1 ,
        a.Print2 ,
        a.Print3 ,
        a.Print4 ,
        a.Print5 ,
        CASE a.Creator
          WHEN b.UserID THEN b.UserName
        END AS 'Creator',
        a.CreateTime,
        PackLabel,
        ProductLabel,
        TankPack,
        SmallInPack
FROM    T_Bllb_ProductPrintInfo_tbpp a
        LEFT JOIN SysDatUser b ON a.Creator = b.UserID {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, sqlcmd);
         }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Insert(T_Bllb_ProductPrintInfo_tbpp obj)
        {
            string sqlcmd = string.Format(@"INSERT  INTO T_Bllb_ProductPrintInfo_tbpp
        ( ProductCode ,
          ProductSN ,
          Print1 ,
          Print2 ,
          Print3 ,
          Print4 ,
          Print5 ,
          Creator ,
          CreateTime,
          PackLabel,
          ProductLabel,
          TankPack,
          SmallInPack
        )
VALUES  ( '{0}' ,
          '{1}' ,
          '{2}' ,
          '{3}' ,
          '{4}' ,
          '{5}' ,
          '{6}' ,
          '{7}',
          GETDATE(),
          '{8}',
          '{9}',
          '{10}',
          '{11}'

        )", obj.ProductCode,obj.ProductSN,obj.Print1,obj.Print2,obj.Print3,obj.Print4,obj.Print5,PubUtils.uContext.UserID,obj.PackLabel,obj.ProductLabel,obj.TankPack,obj.SmallInPack);
            return NMS.ExecTransql(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Update(T_Bllb_ProductPrintInfo_tbpp obj)
        {
            string sqlcmd = string.Format(@"UPDATE T_Bllb_ProductPrintInfo_tbpp SET Print1 = '{0}', Print2 = '{1}', Print3 = '{2}', Print4 = '{3}', Print5 = '{4}',TankPack='{6}', PackLabel='{7}', ProductLabel='{8}',
                  SmallInPack='{9}',ProductSN='{10}' WHERE ProductCode = '{5}'", obj.Print1,obj.Print2,obj.Print3,obj.Print4,obj.Print5,obj.ProductCode,obj.TankPack,obj.PackLabel,obj.ProductLabel,obj.SmallInPack,obj.ProductSN);
            return NMS.ExecTransql(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="productcode"></param>
        /// <returns></returns>
        public static bool Delete(string productcode)
        {
            string sqlcmd = string.Format(@"DELETE T_Bllb_ProductPrintInfo_tbpp WHERE ProductCode='{0}'",productcode);
            return NMS.ExecTransql(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 校验产品代码是否存在
        /// </summary>
        /// <returns></returns>
        public static DataTable IsExist(string strWhere)
        {
            string sqlcmd = string.Format(" SELECT * FROM T_Bllb_ProductPrintInfo_tbpp {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 获得产品信息
        /// </summary>
        /// <param name="sfcno"></param>
        /// <returns></returns>
        public static DataTable GetProductInfo(string sfcno)
        {
            string sqlcmd = string.Format(@"
SELECT  a.SfcNo ,
        a.Product ,
        b.ProductSN ,
        b.Print1 ,
        b.Print2 ,
        b.Print3 ,
        b.Print4 ,
        b.Print5 ,
        b.ProductLabel,
        b.CreateTime
FROM    SfcDatProduct a
        INNER JOIN T_Bllb_ProductPrintInfo_tbpp b ON a.Product = b.ProductCode WHERE SfcNo='{0}'", sfcno);
            return NMS.QueryDataTable(PubUtils.uContext, sqlcmd);
        }

    }
}
