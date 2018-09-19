using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public  class T_Bllb_MaterialQuality_tbmq
    {
        /// <summary>
        /// 物料代码
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 阶别
        /// </summary>
        public string Step { get; set; }
        /// <summary>
        /// 保质期
        /// </summary>
        public decimal QualityLength { get; set; }
    }
}
