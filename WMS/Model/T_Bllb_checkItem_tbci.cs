using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 检测项目表实体操作类
    /// </summary>
    public partial class T_Bllb_checkItem_tbci
    {
        /// <summary>
        /// 检测项目ID（全球唯一码）
        /// </summary>
        public string TbciId { get; set; }
        /// <summary>
        /// 检测项目名称
        /// </summary>
        public string TbciName { get; set; }
        /// <summary>
        /// 检测项目类型ID（T_Bllb_checkItemType_tbcit）
        /// </summary>
        public string TbcitId { get; set; }
        /// <summary>
        /// 抽检阶（IQC、FQC等）
        /// </summary>
        public string QcStep { get; set; }
        /// <summary>
        /// 值域（1、单值；2、范围值；3、状态值）
        /// </summary>
        public string ValueType { get; set; }
        /// <summary>
        /// 下限值
        /// </summary>
        public string DownValue { get; set; }
        /// <summary>
        /// 上限值
        /// </summary>
        public string UpValue { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public string OrderNum { get; set; }
    }
}
