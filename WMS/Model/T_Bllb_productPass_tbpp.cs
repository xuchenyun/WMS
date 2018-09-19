using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    //产品过站记录表
    public partial  class T_Bllb_productPass_tbpp
    {
        /// <summary>
        ///  产品过站记录ID（全球唯一码）
        /// </summary>
        public string TBPP_ID { get; set; }
        /// <summary>
        /// 产品状态ID（T_Bllb_productStatus_tbps）
        /// </summary>
        public string TBPS_ID { get; set; }
        /// <summary>
        /// 过站工序ID（T_Bllb_Group_tbg）
        /// </summary>
        public string TBG_ID { get; set; }
        /// <summary>
        /// 过站时间
        /// </summary>
        public DateTime PASS_TIME { get; set; }
        /// <summary>
        /// 产品状态（0：正常；1：不良）
        /// </summary>

        public string STATE_FLAG { get; set; }
        /// <summary>
        ///  线别
        /// </summary>
        public string PLCode { get; set; }
    }
}
