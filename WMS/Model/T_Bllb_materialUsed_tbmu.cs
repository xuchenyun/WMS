using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class T_Bllb_materialUsed_tbmu
    {
        /// <summary>
        /// 制令单
        /// </summary>
        public string SFCNO { get; set; }
        /// <summary>
        /// 工位ID
        /// </summary>
        public string TBS_ID { get; set; }
        /// <summary>
        /// 产品SN
        /// </summary>
        public string SERIALNUMBER { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string PARTNUMBER { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 员工号
        /// </summary>
        public string CREATOR { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal QTY { get; set; }
        /// <summary>
        /// 物料SN
        /// </summary>
        public string PART_SN { get; set; }
    }
}
