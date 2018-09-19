using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 不良因素表实体类
    /// </summary>
    public partial class T_Bllb_errorFactor_tbef
    {
        /// <summary>
        /// 不良因素ID
        /// </summary>
        public string TbefId { get; set; }
        /// <summary>
        /// 不良因素代码
        /// </summary>
        public string TbefCode { get; set; }
        /// <summary>
        /// 不良因素描述
        /// </summary>
        public string TbefName { get; set; }
    }
}
