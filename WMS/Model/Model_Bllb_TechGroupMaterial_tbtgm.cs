using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Model_Bllb_TechGroupMaterial_tbtgm
    {
        /// <summary>
        /// ID
        /// </summary>
        public string TBTGM_ID { get; set; }
        /// <summary>
        /// 工艺ID
        /// </summary>
        public string TBT_ID { get; set; }
        /// <summary>
        /// 工艺工序ID
        /// </summary>
        public string TBTG_ID { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string PARTNUMBER { get; set; }
        /// <summary>
        /// 用量
        /// </summary>
        public decimal QTY { get; set; }
    }
}
