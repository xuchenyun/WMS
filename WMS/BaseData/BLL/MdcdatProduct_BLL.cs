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
    public class MdcdatProduct_BLL
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public static DataTable Query(string strwhere)
        {
            string strSql = string.Format(" select a.ProductCode,a.ProductName,a.Remark,b.UserName,a.CreateTime,a.UPH from MdcdatProduct a left join SysdatUser b on a.Creator=b.UserID {0}", strwhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insert(MdcdatProduct p)
        {
            string strSql = string.Format("insert into MdcdatProduct(Fguid,ProductCode,ProductName,Remark,Creator,CreateTime,UPH) values(newid(),'{0}','{1}','{2}','{3}',getdate(),'{4}')",
                p.ProductCode, p.ProductName, p.Remark, PubUtils.uContext.UserID, p.UPH);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Update(MdcdatProduct p)
        {
            string strSql = string.Format(@"
UPDATE  MdcdatProduct
SET      UPH = '{1}' ,
        Remark = '{2}' ,
        Updator = '{3}' ,
        UpdateTime = GETDATE()
WHERE   ProductCode = '{0}'",p.ProductCode,p.UPH,p.Remark,PubUtils.uContext.UserID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool Delete(string strWhere)
        {
            string strSql = string.Format(" delete from 　MdcdatProduct　{0}", strWhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
    }
}
