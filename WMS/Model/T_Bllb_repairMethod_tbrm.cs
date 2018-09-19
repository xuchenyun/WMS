using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 维修方法表实体类
    /// </summary>
    public partial class T_Bllb_repairMethod_tbrm
    {
        /// <summary>
        /// 维修方法ID
        /// </summary>
        public string TbrmId { get; set; }
        /// <summary>
        /// 维修方法代码
        /// </summary>
        public string TbrmCode { get; set; }
        /// <summary>
        /// 维修方法名称
        /// </summary>
        public string TbrmName { get; set; }
    }
}
