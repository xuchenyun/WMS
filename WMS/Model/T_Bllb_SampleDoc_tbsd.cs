using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public partial class T_Bllb_SampleDoc_tbsd
    {
        //检验单表
        /// <summary>
        /// 检验单号
        /// </summary>
        public string DOC_NO { get; set; }
        /// <summary>
        /// 机种
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 机种抽样方案ID
        /// </summary>
        public string TBMS_ID { get; set; }
        /// <summary>
        /// 送检数
        /// </summary>
        public int DOC_QTY { get; set; }
        /// <summary>
        /// 应抽数
        /// </summary>
        public int PLAN_SAMPLE_QTY { get; set; }
        /// <summary>
        /// 已抽数
        /// </summary>
        public int SAMPLE_QTY { get; set; }
        /// <summary>
        /// 线别
        /// </summary>
        public string PLCode { get; set; }
        /// <summary>
        /// 判定结果
        /// </summary>
        public string RESULT { get; set; }
        /// <summary>
        /// 判定人
        /// </summary>
        public string RESULT_MAN { get; set; }
        /// <summary>
        /// 制令单
        /// </summary>
        public string SfcNo { get; set; }
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
        /// 不良数
        /// </summary>
        public int ERROR_QTY { get; set; }
        /// <summary>
        /// 送检日期最小值
        /// </summary>
        public DateTime CREATE_TIME_MIN { get; set; }
        /// <summary>
        /// 送检日期最大值
        /// </summary>
        public DateTime CREATE_TIME_MAX { get; set; }
        /// <summary>
        /// 批退备注
        /// </summary>
        public string Reback_Memo { get; set; }
    }
}
