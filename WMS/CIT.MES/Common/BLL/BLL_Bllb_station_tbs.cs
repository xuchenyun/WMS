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
    /// 工位表业务层操作类
    /// </summary>
    public partial class BLL_Bllb_station_tbs
    {
        DAL_Bllb_station_tbs t_Bllb_station_tbs_DAL = new DAL_Bllb_station_tbs();
        /// <summary>
        /// 查询工位信息
        /// </summary>
        /// <returns></returns>
        public DataTable Query(string strWhere)
        {
            return t_Bllb_station_tbs_DAL.GetStation(strWhere);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Select(string strWhere)
        {
            return t_Bllb_station_tbs_DAL.GetList(strWhere);
        }
    }
}
