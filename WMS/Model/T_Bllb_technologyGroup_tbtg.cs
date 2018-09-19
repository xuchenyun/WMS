using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 工艺工序表实体类
    /// </summary>
    public partial class T_Bllb_technologyGroup_tbtg
    {
        /// <summary>
        /// 工艺工序ID（全球唯一码）
        /// </summary>
        public string TBTG_ID { get; set; }
        /// <summary>
        /// 工艺ID（T_Bllb_technology_tbt）
        /// </summary>
        public string TBT_ID { get; set; }
        /// <summary>
        /// 工序ID（T_Bllb_group_tbg）
        /// </summary>
        public string TBG_ID { get; set; }
    }
}
