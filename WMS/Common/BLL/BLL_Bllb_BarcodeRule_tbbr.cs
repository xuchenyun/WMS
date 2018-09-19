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
    /// 条码规则业务访问类
    /// </summary>
    public class BLL_Bllb_BarcodeRule_tbbr
    {
        DAL_T_Bllb_BarcodeRule_tbbr t_Bllb_BarcodeRule_tbbr_DAL = new DAL_T_Bllb_BarcodeRule_tbbr();

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Delete(List<T_Bllb_BarcodeRule_tbbr> list)
        {
            return t_Bllb_BarcodeRule_tbbr_DAL.DeleteList(list);
        }
        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="tbbr"></param>
        /// <returns></returns>
        public DataTable Select(string strWhere)
        {
            return t_Bllb_BarcodeRule_tbbr_DAL.GetList(strWhere);
        }
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="tbbr"></param>
        /// <returns></returns>
        public bool Insert(T_Bllb_BarcodeRule_tbbr tbbr)
        {
            return t_Bllb_BarcodeRule_tbbr_DAL.InsertEntity(tbbr);
        }
        /// <summary>
        /// 编辑一条数据
        /// </summary>
        /// <returns></returns>
        public bool Update(T_Bllb_BarcodeRule_tbbr tbbr)
        {
            return t_Bllb_BarcodeRule_tbbr_DAL.UpdateEntity(tbbr);
        }
        /// <summary>
        /// 初始化条码规则下拉框控件
        /// </summary>
        /// <returns></returns>
        public DataTable InitControl(T_Bllb_BarcodeRule_tbbr tbbr)
        {
            return t_Bllb_BarcodeRule_tbbr_DAL.GetInitData(tbbr);
        }
        /// <summary>
        /// 根据条码规则ID（TBBR_ID）获得tbmr_Id
        /// </summary>
        /// <returns></returns>
        public DataTable GetTbmrId(T_Bllb_BarcodeRule_tbbr tbbr)
        {
            return t_Bllb_BarcodeRule_tbbr_DAL.GetTbmrId(tbbr);
        }
    }
}
