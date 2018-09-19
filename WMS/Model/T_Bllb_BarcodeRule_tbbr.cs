using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class T_Bllb_BarcodeRule_tbbr
    {
        /// <summary>
        /// 条码规则ID（全球唯一码）
        /// </summary>
        public string TBBR_ID { get; set; }
        /// <summary>
        /// 条码规则名称
        /// </summary>
        public string RULE_NAME { get; set; }
        /// <summary>
        /// 是否校验条码长度
        /// </summary>
        public string IS_CHECK_SN_LENGTH { get; set; }
        /// <summary>
        /// 条码长度
        /// </summary>
        public int SN_LENGTH { get; set; }
        /// <summary>
        /// 是否校验固定字符
        /// </summary>
        public string IS_CHECK_SAME_STRING { get; set; }
        /// <summary>
        /// 固定字符
        /// </summary>
        public string SAME_STRING { get; set; }
        /// <summary>
        /// 固定字符开始位（从1开始）
        /// </summary>
        public int SAME_STRING_BEGIN { get; set; }       
        /// <summary>
        /// 0：不比对，1：比对物料，2：比对产品机种
        /// </summary>
        public string MATERIAL_FLAG { get; set; }
        /// <summary>
        /// 要与条码比较的位置的物料开始位（从1开始）
        /// </summary>
        public int MATERIAL_CODE_BEGIN { get; set; }        
        /// <summary>
        /// 要与物料比较的位置的条码开始位（从1开始）
        /// </summary>
        public int SN_BEGIN { get; set; }
        /// <summary>
        /// 物料长度
        /// </summary>
        public int MATERIAL_LENGTH { get; set; }

    }
}
