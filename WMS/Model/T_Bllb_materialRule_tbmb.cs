using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class T_Bllb_materialRule_tbmb
    {
        /// <summary>
        /// 物料条码ID（全球唯一码）
        /// </summary>
        public string TBMR_ID { get; set; }
        /// <summary>
        /// 条码规则ID
        /// </summary>
        public string TBBR_ID { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 关键件类型ID
        /// </summary>
        public string TBKT_ID { get; set; }
        /// <summary>
        /// 是否默认（Y/N）
        /// </summary>
        public string DEFAULT_FLAG { get; set; }

    }
}
