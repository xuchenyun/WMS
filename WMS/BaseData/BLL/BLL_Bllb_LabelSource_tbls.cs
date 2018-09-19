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
    public class BLL_Bllb_LabelSource_tbls
    {
        /// <summary>
        /// 查询标签数据源
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Select(string strWhere)
        {
            string strSql = string.Format(" select a.LabelName,a.LabelSQL,b.UserName,a.CreateTime from T_Bllb_LabelSource_tbls a left join sysdatuser b on a.Creator=b.UserID  {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 新增标签数据源
        /// </summary>
        /// <param name="lableS"></param>
        /// <returns></returns>
        public static bool Insert(T_Bllb_LabelSource_tbls lableS)
        {
            string strSql = string.Format(@" insert into T_Bllb_LabelSource_tbls(LabelName,LabelSQL,Creator,CreateTime) values('{0}','{1}','{2}',getdate())", lableS.LabelName, lableS.LabelSQL, PubUtils.uContext.UserID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改标签数据源
        /// </summary>
        /// <param name="lableS"></param>
        /// <returns></returns>
        public static bool Update(T_Bllb_LabelSource_tbls lableS, string current_LabelName)
        {
            string strSql = string.Format(@"update T_Bllb_LabelSource_tbls set LabelName='{0}',LabelSQL='{1}',Updator='{2}',UpdateTime=getdate() where LabelName='{3}'", lableS.LabelName, lableS.LabelSQL, PubUtils.uContext.UserID, current_LabelName);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除标签数据源
        /// </summary>
        /// <param name="labelName"></param>
        /// <returns></returns>
        public static bool Delete(string labelName)
        {
            string strSql = string.Format("delete T_Bllb_LabelSource_tbls where LabelName='{0}'", labelName);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
    }
}
