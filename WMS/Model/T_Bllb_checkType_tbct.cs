using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 检验方案实体操作类
    /// </summary>
    public partial class T_Bllb_checkType_tbct
    {
        /// <summary>
        /// 检验方案ID（全球唯一）
        /// </summary>
        public string TbctId { get; set; }
        /// <summary>
        /// 检验方案（一般检验、加严检验）
        /// </summary>
        public string TbctType { get; set; }
    }
}
