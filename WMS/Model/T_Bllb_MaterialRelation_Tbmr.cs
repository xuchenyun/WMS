/*
  版权:  @Zach.zhong
  生成日期:2018/6/14   
  说明: T_Bllb_MaterialRelation_Tbmr表对象类                      
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    [Serializable]
    public class T_Bllb_MaterialRelation_Tbmr
    {
        /// <summary>
        ///本厂料号
        /// </summary>
		public string LocalMaterialCode { get; set; }
        /// <summary>
        ///供应商料号
        /// </summary>
		public string SupplyMaterialCode { get; set; }
        /// <summary>
        ///供应商
        /// </summary>
		public string Supply { get; set; }
        /// <summary>
        ///备注
        /// </summary>
		public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string TBMR_ID { get; set; }
    }
}
