using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 机种抽样方案实体类
    /// </summary>
    public partial class T_Bllb_modelSample_tbms
    {
        /// <summary>
        /// 机种抽样方案ID（全球唯一）
        /// </summary>
        public string TbmsId { get; set; }
        /// <summary>
        /// 抽检阶
        /// </summary>
        public string QcStep { get; set; }
        /// <summary>
        /// 产品代码
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 是否为默认抽样方案
        /// </summary>
        public string IsDefault { get; set; }
        /// <summary>
        /// 检验水准ID（T_Bllb_checkLevel_tbcl）
        /// </summary>
        public string TbclId { get; set; }
        /// <summary>
        /// 检验水准等级（I、II）
        /// </summary>
        public string TbclLevel { get; set; }
        /// <summary>
        /// 检验方案ID（T_Bllb_checkType_tbct）
        /// </summary>
        public string TbctId { get; set; }
        /// <summary>
        /// AQL值
        /// </summary>
        public string AqlValue { get; set; }
        /// <summary>
        /// 是否全检
        /// </summary>
        public string IsAllCheck { get; set; }
        /// <summary>
        /// 全检阈值
        /// </summary>
        public string AllCheckValue { get; set; }
    }
}
