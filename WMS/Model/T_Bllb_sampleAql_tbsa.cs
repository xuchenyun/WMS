using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 样本与AQL关系表实体类
    /// </summary>
    public partial class T_Bllb_sampleAql_tbsa
    {
        /// <summary>
        /// 唯一码
        /// </summary>
        public string TbsaId { get; set; }
        /// <summary>
        /// AQL值
        /// </summary>
        public string AqlValue { get; set; }
        /// <summary>
        /// 样本数量ID（T_Bllb_sampleQty_tbsq）
        /// </summary>
        public string TbsqId { get; set; }
    }
}
