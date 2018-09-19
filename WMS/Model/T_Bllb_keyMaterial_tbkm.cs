using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public class T_Bllb_keyMaterial_tbkm
    {
        /// <summary>
        /// 关键件物料ID（全球唯一码）
        /// </summary>
        public string TBKM_ID { get; set; }
        /// <summary>
        /// 关键件类型ID
        /// </summary>
        public string TBKT_ID { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        public string MaterialCode { get; set; }
    }
}
