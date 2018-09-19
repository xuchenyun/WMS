using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CIT.MES;
using CIT.Wcf.Utils;
using Model;

namespace BaseData.BLL
{
    public class BLL_Bllb_MaterialContainer_tbmc
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Select(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select 'false' as 'CHK', MaterialCode,Container_Type,Qty,TBMC_ID from T_Bllb_MaterialContainer_tbmc");
            if (strWhere!=string.Empty)
            {
                strSql.Append(" Where "+ strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="Container"></param>
        /// <returns></returns>
        public bool Insert(T_Bllb_MaterialContainer_tbmc Container)
        {
            string strSql = string.Format("Insert into T_Bllb_MaterialContainer_tbmc(MaterialCode,Container_Type,Qty,TBMC_ID) Values('{0}','{1}','{2}','{3}')", Container.MaterialCode, Container.Container_Type, Container.Qty,Guid.NewGuid().ToString());
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Container"></param>
        /// <returns></returns>
        public bool Update(T_Bllb_MaterialContainer_tbmc Container)
        {
            string strSql = string.Format("Update T_Bllb_MaterialContainer_tbmc Set Container_Type='{0}',Qty='{1}' WHERE TBMC_ID='{2}'", Container.Container_Type,Container.Qty,Container.TBMC_ID);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Delete(string strWhere)
        {
            string strSql = string.Format("Delete T_Bllb_MaterialContainer_tbmc {0}", strWhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 检测物料代码与容器类型是否已经存在
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable IsExist(string strWhere)
        {
            string strSql = string.Format(" select * from T_Bllb_MaterialContainer_tbmc {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
