using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 不良类型表实体类
    /// </summary>
    public partial class T_Bllb_errorType_tbet
    {
        /// <summary>
        /// 不良类型ID（全球唯一码）
        /// </summary>
        public string TbetId { get; set; }
        /// <summary>
        /// 不良类型名称
        /// </summary>
        public string TbetName { get; set; }
        /// <summary>
        /// 不良类型描述
        /// </summary>
        public string TbetDesc { get; set; }
    }
}
