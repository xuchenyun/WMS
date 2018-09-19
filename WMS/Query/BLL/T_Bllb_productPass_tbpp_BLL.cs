using Query.DAL;
using Model;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Query.BLL
{
    /// <summary>
    /// 产品过站记录业务层访问类
    /// </summary>
    public class T_Bllb_productPass_tbpp_BLL
    {
        T_Bllb_productPass_tbpp_DAL t_Bllb_productPass_tbpp_DAL = new T_Bllb_productPass_tbpp_DAL();
        /// <summary>
        /// 查询过站记录数据
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable Select(string strWhere)
        {
            return t_Bllb_productPass_tbpp_DAL.GetList(strWhere);
        }
    }
}
