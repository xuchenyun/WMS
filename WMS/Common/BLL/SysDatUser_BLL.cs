using Common.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Common.BLL
{
    /// <summary>
    /// 用户表业务层访问类
    /// </summary>
    public class SysDatUser_BLL
    {
        /// <summary>
        /// 用户表数据层操作对象
        /// </summary>
        SysDatUser_DAL sysDatUser_DAL = new SysDatUser_DAL();
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public DataTable Select()
        {
            return sysDatUser_DAL.GetList();
        }
    }
}
