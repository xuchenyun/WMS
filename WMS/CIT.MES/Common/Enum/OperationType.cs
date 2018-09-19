using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enum
{
    public enum OperationType
    {
        /// <summary>
        /// 新增
        /// </summary>
        Add = 0,
        /// <summary>
        /// 编辑
        /// </summary>
        Edit = 1,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 2,
        /// <summary>
        /// 查询
        /// </summary>
        Query = 3,
        /// <summary>
        /// 只读
        /// </summary>
        ReadOnly = 4
    }
}
