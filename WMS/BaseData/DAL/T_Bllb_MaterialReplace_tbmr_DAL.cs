using CIT.MES;
using CIT.Wcf.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData.DAL
{
    public partial class T_Bllb_MaterialReplace_tbmr_DAL
    {
        /// <summary>
        /// 查询替代料关系
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Query(string strWhere)
        {
            string strSql = string.Format(@"select a.MaterialCode,a.MaterialName,b.MaterialReplace,b.MaterialReplace1,b.MaterialReplace2,c.UserName,b.CreateTime from MdcdatMaterial a
inner join T_Bllb_MaterialReplace_tbmr b on a.MaterialCode=b.MaterialCode 
left join SysDatUser c on b.Creator=c.UserID {0}",strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="MR"></param>
        /// <returns></returns>
        public static bool Insert(T_Bllb_MaterialReplace_tbmr MR)
        {
            string strSql = string.Format("insert into T_Bllb_MaterialReplace_tbmr(MaterialCode,MaterialReplace,MaterialReplace1,MaterialReplace2,Creator,CreateTime) values('{0}','{1}','{2}','{3}','{4}',getdate())", MR.MaterialCode, MR.MaterialReplace, MR.MaterialReplace1, MR.MaterialReplace2, PubUtils.uContext.UserID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="MR"></param>
        /// <returns></returns>
        public static bool Update(T_Bllb_MaterialReplace_tbmr MR)
        {
            string strSql = string.Format("update T_Bllb_MaterialReplace_tbmr set MaterialReplace='{1}',MaterialReplace1='{2}',MaterialReplace2='{3}', Updator='{4}',UpdateTime=getdate()  where MaterialCode='{0}'", MR.MaterialCode, MR.MaterialReplace, MR.MaterialReplace1, MR.MaterialReplace2,PubUtils.uContext.UserID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public static bool Delete(string where)
        {
            string strSql = string.Format("delete T_Bllb_MaterialReplace_tbmr {0}",where);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 通过料号获得品名
        /// </summary>
        /// <param name="MaterCodeValue"></param>
        /// <returns></returns>
        public static DataTable  GetMaterialName(string MaterCodeValue)
        {
            string strSql = string.Format(@"select MaterialCode,MaterialName from MdcdatMaterial where MaterialCode='{0}'",MaterCodeValue);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
            
        }
    }
}
