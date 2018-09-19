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
    /// 系统参数表（字典表）业务层访问类
    /// </summary>
    public partial class T_Sysc_dictionaryType_tsdt_BLL
    {
        /// <summary>
        /// 系统参数表（字典表）数据层访问对象
        /// </summary>
        T_Sysc_dictionaryType_tsdt_DAL t_Sysc_dictionaryType_tsdt_DAL = new T_Sysc_dictionaryType_tsdt_DAL();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Select(string strWhere)
        {
            return t_Sysc_dictionaryType_tsdt_DAL.Query(strWhere);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="tsdt"></param>
        /// <returns></returns>
        public bool Insert(T_Sysc_dictionaryType_tsdt tsdt)
        {
            return t_Sysc_dictionaryType_tsdt_DAL.Insert(tsdt);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="tsdt"></param>
        /// <returns></returns>
        public bool Update(T_Sysc_dictionaryType_tsdt tsdt)
        {
            return t_Sysc_dictionaryType_tsdt_DAL.Update(tsdt);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Delete(string strWhere)
        {
            return t_Sysc_dictionaryType_tsdt_DAL.Delete(strWhere);
        }
    }
}
