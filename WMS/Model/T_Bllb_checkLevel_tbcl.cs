using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 检验水准表实体操作类
    /// </summary>
    public partial class T_Bllb_checkLevel_tbcl
    {
        /// <summary>
        /// 检验水准ID（全球唯一码）
        /// </summary>
        public string TbclId { get; set; }
        /// <summary>
        /// 检验水准名称
        /// </summary>
        public string TbclName { get; set; }
    }
}
