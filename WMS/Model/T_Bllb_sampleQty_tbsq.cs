using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 样本代码--样品数范围表实体类
    /// </summary>
    public partial class T_Bllb_sampleQty_tbsq
    {
        /// <summary>
        /// 样品数范围ID（全球唯一码）
        /// </summary>
        public string TbsqId { get; set; }
        /// <summary>
        /// 抽检阶（IQC、FQC等）
        /// </summary>
        public string QcStep { get; set; }
        /// <summary>
        /// 开始数值
        /// </summary>
        public string TbspqBeginQty { get; set; }
        /// <summary>
        /// 结束数值
        /// </summary>
        public int TbsqpEndQty { get; set; }

    }
}
