/*
  版权:  @Zach.zhong
  生成日期:2018/4/27   
  说明: T_Bllb_LocationContainer_tblc表对象类                      
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    public class T_Bllb_LocationContainer_tblc
    {
        /// <summary>
        ///库位SN
        /// </summary>
		public string Location_SN { get; set; }
        /// <summary>
        ///容器类型（数据来源系统参数）
        /// </summary>
		public string Container_Type { get; set; }
        /// <summary>
        ///数量
        /// </summary>
		public int QTY { get; set; }
    }
}
