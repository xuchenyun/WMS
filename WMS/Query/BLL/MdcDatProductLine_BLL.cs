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
    /// 线别表业务层访问类
    /// </summary>
    public class MdcDatProductLine_BLL
    {
        MdcDatProductLine_DAL mdcDatProductLine_DAL = new MdcDatProductLine_DAL();
        /// <summary>
        /// 查询产品在线数据
        /// </summary>
        /// <returns></returns>
        public DataTable Select(string strWhere)
        {
            return mdcDatProductLine_DAL.GetList(strWhere);
        }
     
    }
}
