/*
  版权:  @Zach.zhong
  生成日期:2018/6/30   
  说明: T_Bllb_Feeder_Maintain_tbfm表对象类                      
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
   [Serializable]
public	class T_Bllb_Feeder_Maintain_tbfm
	{
        /// <summary>
        ///料枪SN
        /// </summary>
		public string FeederCode { get; set; }
        /// <summary>
        ///保养内容
        /// </summary>
		public string Maintain { get; set; }
        /// <summary>
        ///状态 0-保养中 1-保养
        /// </summary>
		public string Status { get; set; }
        /// <summary>
        ///保养人
        /// </summary>
		public string Creator { get; set; }
        /// <summary>
        ///保养时间
        /// </summary>
		public string CreateTime { get; set; }
        /// <summary>
        ///备注
        /// </summary>
		public string Remark { get; set; }
	}
}
