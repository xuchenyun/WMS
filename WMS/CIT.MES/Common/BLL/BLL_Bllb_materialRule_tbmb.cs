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
    /// 物料条码规则业务层访问类
    /// </summary>
    public class BLL_Bllb_materialRule_tbmb
    {
        DAL_Bllb_materialRule_tbmb t_Bllb_materialRule_tbmb_DAL = new DAL_Bllb_materialRule_tbmb();
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="tbmb"></param>
        /// <returns></returns>
        public bool Insert(T_Bllb_materialRule_tbmb tbmb)
        {
            return t_Bllb_materialRule_tbmb_DAL.InsertEntity(tbmb);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="tbmb"></param>
        /// <returns></returns>
        public bool Update(T_Bllb_materialRule_tbmb tbmb)
        {
            return t_Bllb_materialRule_tbmb_DAL.UpdateEntity(tbmb);
        }
        /// <summary>
        /// 更新同一料号的是否默认为否
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="isDefault"></param>
        /// <returns></returns>
        public bool Update_default(string strWhere, string isDefault)
        {
            return t_Bllb_materialRule_tbmb_DAL.Update_default(strWhere, isDefault);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Delete(List<T_Bllb_materialRule_tbmb> list)
        {
            return t_Bllb_materialRule_tbmb_DAL.DeleteEntity(list);
        }
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="tbmb"></param>
        /// <returns></returns>
        public DataTable Select(string strWhere)
        {
            return t_Bllb_materialRule_tbmb_DAL.GetList(strWhere);
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public DataTable SelectTbmrID(T_Bllb_materialRule_tbmb tbmb)
        {
            return t_Bllb_materialRule_tbmb_DAL.GetTbmrID(tbmb);
        }
        /// <summary>
        /// 存在与否
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool IsExist(string strWhere)
        {
            return t_Bllb_materialRule_tbmb_DAL.IsExit(strWhere).Rows.Count > 0 ? true : false;
        }
    }
}
