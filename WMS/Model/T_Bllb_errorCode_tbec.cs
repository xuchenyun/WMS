using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
  public partial   class T_Bllb_errorCode_tbec
    {
        //不良代码
        /// <summary>
        /// 不良代码ID（全球唯一码）
        /// </summary>
        public string TBEC_ID { get; set; }
        /// <summary>
        /// 不良代码
        /// </summary>
        public string TBEC_CODE { get; set; }
        /// <summary>
        /// 不良描述
        /// </summary>
        public string TBEC_DESC { get; set; }
        /// <summary>
        /// 不良类型ID（T_Bllb_errorType_tbet）
        /// </summary>
        public string TBET_ID { get; set; }
        /// <summary>
        /// 不良标准分数ID
        /// </summary>
        public string TBES_ID { get; set; }
    }
}
