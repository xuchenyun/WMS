using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 检测项目类型表实体操作类
    /// </summary>
    public partial class T_Bllb_checkItemType_tbcit
    {
        /// <summary>
        /// 检测项目类型ID（全球唯一码）
        /// </summary>
        public string TbcitId { get; set; }
        /// <summary>
        /// 检测项目类型名称
        /// </summary>
        public string TbcitName { get; set; }
    }
}
