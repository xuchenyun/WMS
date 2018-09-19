using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class T_Bllb_MaterialContainer_tbmc
    {
        /// <summary>
        /// 物料代码
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 容器类型
        /// </summary>
        public string Container_Type { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public string TBMC_ID { get; set; }

    }
}
