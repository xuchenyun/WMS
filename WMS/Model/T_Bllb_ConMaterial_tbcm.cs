/*
  版权:  @Zach.zhong
  生成日期:2018/6/2   
  说明: T_Bllb_ConMaterial_tbcm表对象类                      
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    [Serializable]
    public class T_Bllb_ConMaterial_tbcm
    {
        /// <summary>
        ///机种
        /// </summary>
		public string TBCM_Product { get; set; }
        /// <summary>
        ///机种名
        /// </summary>
		public string TBCM_ProductName { get; set; }
        /// <summary>
        ///料号
        /// </summary>
		public string TBCM_MaterialCode { get; set; }
        /// <summary>
        ///物料描述
        /// </summary>
		public string TBCM_MaterialName { get; set; }
        /// <summary>
        ///类型
        /// </summary>
		public string TBCM_Type { get; set; }
        /// <summary>
        ///备注
        /// </summary>
		public string TBCM_Remark { get; set; }
        /// <summary>
        ///id唯一码
        /// </summary>
		public string TBCM_ID { get; set; }
    }
}
