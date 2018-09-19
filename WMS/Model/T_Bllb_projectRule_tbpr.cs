using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
  public partial   class T_Bllb_projectRule_tbpr
    {
        /// <summary>
        /// 工单解析ID（全球唯一码）
        /// </summary>
        public string TBPR_ID { get; set; }
        /// <summary>
        /// 工单
        /// </summary>
        public string WoCode { get; set; }
        /// <summary>
        /// 物料条码ID（T_Bllb_materialRule_tbmb）
        /// </summary>
        public string TBMR_ID { get; set; }
        /// <summary>
        /// 关键件类型ID（T_Bllb_keyType_tbkt）
        /// </summary>
        public string TBKT_ID { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialCode { get; set; }



    }
}
