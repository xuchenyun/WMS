/*
  版权:  @Zach.zhong
  生成日期:2018/6/30   
  说明: T_Bllb_Feeder_Repair_tbfr表对象类                      
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
   [Serializable]
public	class T_Bllb_Feeder_Repair_tbfr
	{
        /// <summary>
        ///料枪SN
        /// </summary>
		public string FeederCode { get; set; }
        /// <summary>
        ///维修内容
        /// </summary>
		public string Repair { get; set; }
        /// <summary>
        ///状态 0-维修中 1-维修  2-报废（损坏）
        /// </summary>
		public string Status { get; set; }
        /// <summary>
        ///维修人
        /// </summary>
		public string Creator { get; set; }
        /// <summary>
        ///维修时间
        /// </summary>
		public DateTime CreateTime { get; set; }
        /// <summary>
        ///备注
        /// </summary>
		public string Remark { get; set; }
	}
}
