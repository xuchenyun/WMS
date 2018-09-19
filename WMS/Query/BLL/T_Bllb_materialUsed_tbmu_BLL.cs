using Query.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.BLL
{
    public class T_Bllb_materialUsed_tbmu_BLL
    {
        T_Bllb_materialUsed_tbmu_DAL t_Bllb_materialUsed_tbmu_DAL = new T_Bllb_materialUsed_tbmu_DAL();
        /// <summary>
        /// 产品追溯组装物料消耗
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable SelectMaterialUsed(string strWhere)
        {
            return t_Bllb_materialUsed_tbmu_DAL.GetMaterialUsed(strWhere);
        }
        /// <summary>
        /// 物料消耗
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable QueryMaterialUsed(string strWhere)
        {
            return t_Bllb_materialUsed_tbmu_DAL.MaterialUsed(strWhere);
        }
        public DataTable SelectSMTMtrUse(string strWhere)
        {
            return t_Bllb_materialUsed_tbmu_DAL.GetSMTMtrUse(strWhere);
        }
    }
}
