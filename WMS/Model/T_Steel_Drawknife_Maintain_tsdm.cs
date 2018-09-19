/*
  版权:  @joe.zeng
  生成日期:2018/8/13   
  说明: T_Steel_Drawknife_Maintain_tsdm表对象类                      
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
   [Serializable]
public	class T_Steel_Drawknife_Maintain_tsdm
	{
        /// <summary>
        ///全球唯一码
        /// </summary>
		public string GUID { get; set; }
        /// <summary>
        ///制具SN
        /// </summary>
		public string SerialNum { get; set; }
        /// <summary>
        ///(0-保养中、1-保养)
        /// </summary>
		public string Status { get; set; }
        /// <summary>
        ///保养内容
        /// </summary>
		public string Maintain { get; set; }
        /// <summary>
        ///创建人
        /// </summary>
		public string Creator { get; set; }
        /// <summary>
        ///创建时间
        /// </summary>
		public DateTime CreateTime { get; set; }
        /// <summary>
        ///备注
        /// </summary>
		public string Remark { get; set; }
	}
}
