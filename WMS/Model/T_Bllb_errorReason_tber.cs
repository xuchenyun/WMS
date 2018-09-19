using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 不良原因表实体类
    /// </summary>
    public partial class T_Bllb_errorReason_tber
    {
        /// <summary>
        /// 不良原因ID
        /// </summary>
        public string TberId { get; set; }
        /// <summary>
        /// 不良原因代码
        /// </summary>
        public string TberCode { get; set; }
        /// <summary>
        /// 不良原因描述
        /// </summary>
        public string TberName { get; set; }
    }
}
