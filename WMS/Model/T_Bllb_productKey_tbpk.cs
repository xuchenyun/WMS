using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
  public partial   class T_Bllb_productKey_tbpk
    {
        //产品关键件组装信息表

        /// <summary>
        /// 产品关键件ID（全球唯一码）
        /// </summary>
        public string TBPK_ID { get; set; }
        /// <summary>
        /// 产品状态ID（T_Bllb_productStatus_tbps）
        /// </summary>
        public string TBPS_ID { get; set; }
        /// <summary>
        /// 产品条码条码（产品SN）
        /// </summary>
        public string Product_SN { get; set; }
        /// <summary>
        /// 关键件条码（关键件SN）
        /// </summary>
        public string KEY_SN { get; set; }
        /// <summary>
        /// 关键件类型ID（T_Bllb_keyType_tbkt）
        /// </summary>
        public string TBKT_ID { get; set; }
        /// <summary>
        /// 过站工序ID（T_Bllb_Group_tbg）
        /// </summary>
        public string TBG_ID { get; set; }
        /// <summary>
        /// 组装时间
        /// </summary>
        public DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 组装人
        /// </summary>
        public string UserID { get; set; }

    }
}
