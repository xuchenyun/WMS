/*
  版权:  @Zach.zhong
  生成日期:2018/4/27   
  说明: T_Bllb_Storage_tbs表对象类                      
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    public class T_Bllb_Storage_tbs
    {
        /// <summary>
        ///仓库SN
        /// </summary>
		public string Storage_SN { get; set; }
        /// <summary>
        ///仓库名称
        /// </summary>
		public string Storage_Name { get; set; }
        /// <summary>
        ///仓库类型（1原料仓、2半成品仓、3成品仓、4报废仓）
        /// </summary>
		public string Storage_Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string Step { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string Respons_Person { get; set; }
        public string Before_Doc_NO { get; set; }
    }
}
