using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public partial class T_Bllb_IQCDoc_tbid
    {
        //检验单表
        /// <summary>
        /// IQC检验单号
        /// </summary>
        public string IQC_NO { get; set; }
        /// <summary>
        /// 物料
        /// </summary>
        public string MaterialCode { get; set; }
  
        /// <summary>
        /// 送检数
        /// </summary>
        public int QTY { get; set; }
     
        /// <summary>
        /// 判定结果
        /// </summary>
        public string RESULT { get; set; }
        /// <summary>
        /// 判定人
        /// </summary>
        public string RESULT_MAN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 送检时间
        /// </summary>
        public DateTime RESULT_TIME { get; set; }
        /// <summary>
        /// 检验单产品数已满（Y/N）
        /// </summary>
        public string OVER_FLAG { get; set; }
        /// <summary>
        /// 拒收数
        /// </summary>
        public int REJECT_QTY { get; set; }
        /// <summary>
        /// 送检日期最小值
        /// </summary>
        public DateTime CREATE_TIME_MIN { get; set; }
        /// <summary>
        /// 送检日期最大值
        /// </summary>
        public DateTime CREATE_TIME_MAX { get; set; }
        /// <summary>
        /// 审核结果
        /// </summary>
        public string CHECK_RESULT { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string MEMO { get; set; }

    }
}
