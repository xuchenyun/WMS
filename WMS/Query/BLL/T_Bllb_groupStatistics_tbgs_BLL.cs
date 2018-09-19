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
    /// 过站统计业务层访问类
    /// </summary>
    public class T_Bllb_groupStatistics_tbgs_BLL
    {
        T_Bllb_groupStatistics_tbgs_DAL t_Bllb_groupStatistics_tbgs_DAL = new T_Bllb_groupStatistics_tbgs_DAL();
        /// <summary>
        /// 查询过站统计数据
        /// </summary>
        /// <param name="tbgs"></param>
        /// <returns></returns>
        public DataTable SelectTbgs(T_Bllb_groupStatistics_tbgs tbgs)
        {
            return t_Bllb_groupStatistics_tbgs_DAL.GetTbgs(tbgs);
        }
    }
}
