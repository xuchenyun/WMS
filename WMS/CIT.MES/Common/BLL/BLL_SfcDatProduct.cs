using Common.DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Common.BLL
{
    /// <summary>
    /// 制令单业务层操作类
    /// </summary>
    public class BLL_SfcDatProduct
    {
        DAL_SfcDatProduct sfcDatProduct_DAL = new DAL_SfcDatProduct();
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public DataTable Select(string strWhere)
        {
            return sfcDatProduct_DAL.GetList(strWhere);
        }
        /// <summary>
        /// 根据制令单号查询产品信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectProBySfcno(SfcDatProduct sfcDatPro)
        {
            return sfcDatProduct_DAL.GetProInfoBySfcno(sfcDatPro);
        }
    }
}
