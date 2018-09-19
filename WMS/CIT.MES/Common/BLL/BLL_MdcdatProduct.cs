using Common.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Common.BLL
{
    /// <summary>
    /// 机种表业务层操作类
    /// </summary>
    public class BLL_MdcdatProduct
    {
        DAL_MdcdatProduct mdcdatProduct_DAL = new DAL_MdcdatProduct();
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public DataTable Select(string strWhere)
        {
            return mdcdatProduct_DAL.GetList(strWhere);
        }
    }
}
