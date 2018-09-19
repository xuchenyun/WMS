using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 样品范围与检验水准关系实体类
    /// </summary>
    public partial class T_Bllb_sampleTestLevel_tbstt
    {
        /// <summary>
        /// 唯一码
        /// </summary>
        public string TbsttId { get; set; }
        /// <summary>
        /// 样品数范围ID（T_Bllb_sampleQty_tbsq）
        /// </summary>
        public string TbsqId { get; set; }
        /// <summary>
        /// 检验水准ID（T_Bllb_checkLevel_tbcl）
        /// </summary>
        public string TbclId { get; set; }
        /// <summary>
        /// 检验(水平)
        /// </summary>
        public string TbclLevel { get; set; }
    }
}
