using BaseData.DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BaseData.BLL
{
    /// <summary>
    /// 参数明细表（字典明细表）业务层访问类
    /// </summary>
    public partial class T_Sysc_dictionary_tsd_BLL
    {
        /// <summary>
        /// 参数明细表（字典明细表）数据层访问对象
        /// </summary>
        T_Sysc_dictionary_tsd_DAL t_Sysc_dictionary_tsd_DAL = new T_Sysc_dictionary_tsd_DAL();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Select(string strWhere)
        {
            return t_Sysc_dictionary_tsd_DAL.GetList(strWhere);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="lstAddEntity"></param>
        /// <returns></returns>
        public bool Insert(List<T_Sysc_dictionary_tsd> lstInserttsd)
        {
            return t_Sysc_dictionary_tsd_DAL.Insert(lstInserttsd);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="lsdDeleteTsd"></param>
        /// <returns></returns>
        public bool Delete(string strWhere)
        {
            return t_Sysc_dictionary_tsd_DAL.Delete(strWhere);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public bool Update(List<T_Sysc_dictionary_tsd> lstUpdateTsd)
        {
            return t_Sysc_dictionary_tsd_DAL.Update(lstUpdateTsd);
        }
    }
}
