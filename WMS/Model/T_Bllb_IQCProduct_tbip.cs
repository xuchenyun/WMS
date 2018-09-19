using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
  public class T_Bllb_IQCProduct_tbip
    {
        //检验单产品表
        /// <summary>
        /// 检验单产品记录ID
        /// </summary>
        public string TBIP_ID { get; set; }
        /// <summary>
        /// 检验单
        /// </summary>
        public string IQC_NO { get; set; }
        /// <summary>
        /// 物料SN
        /// </summary>
        public string SERIAL_NUMBER { get; set; }
        /// <summary>
        /// OK/NG
        /// </summary>
        public string RESULT { get; set; }
        /// <summary>
        /// 检测人
        /// </summary>
        public string TEST_MAN { get; set; }
        /// <summary>
        /// 检测时间
        /// </summary>
        public DateTime TEST_TIME { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string STATUS { get; set; }
    }
}
