using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class T_Bllb_SpecMaterialRule_tbsmr
    {
        /// <summary>
        /// 特殊物料条码规则ID（全球唯一码）
        /// </summary>
        public string TBSMR_ID { get; set; }
        /// <summary>
        /// 物料条码ID
        /// </summary>
        public string TBMR_ID { get; set; }
        /// <summary>
        /// 机种/工单/制令单
        /// </summary>
        public string TBSMR_TYPE_VALUE { get; set; }
        /// <summary>
        /// 机种代码（物料代码）
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 类型（0：制令单；1：工单；2：机种）
        /// </summary>
        public string TBSMR_TYPE { get; set; }

    }
}
