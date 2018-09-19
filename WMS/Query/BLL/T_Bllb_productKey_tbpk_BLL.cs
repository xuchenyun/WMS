using Query.DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Query.BLL
{
    /// <summary>
    /// 产品关键件组装信息表业务层访问类
    /// </summary>
    public class T_Bllb_productKey_tbpk_BLL
    {
        T_Bllb_productKey_tbpk_DAL t_Bllb_productKey_tbpk_DAL = new T_Bllb_productKey_tbpk_DAL();

        /// <summary>
        /// 查询组建信息
        /// </summary>
        /// <returns></returns>
        public DataTable Select(string strWhere)
        {
            return t_Bllb_productKey_tbpk_DAL.GetList(strWhere);
        }

        /// <summary>
        /// 通过关键件找到产品条码
        /// </summary>
        /// <param name="KeySN"></param>
        /// <returns></returns>
        public string GetSerialNumberByKeySN(string KeySN)
        {
            return t_Bllb_productKey_tbpk_DAL.GetSerialNumberByKeySN(KeySN);
        }
    }
}
