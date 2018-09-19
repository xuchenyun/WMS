using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class T_Bllb_BaseBom_tbbb
    {
        /// <summary>
        /// 基础Bom的ID
        /// </summary>
        public string TBBB_ID { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public string TBPC_ID { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// Bom用量
        /// </summary>
        public decimal BOM_QTY { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Units { get; set; }
        /// <summary>
        /// 分子
        /// </summary>
        public int BaseQtyN { get; set; }
        /// <summary>
        /// 分母
        /// </summary>
        public int BaseQtyD { get; set; }










    }
}
