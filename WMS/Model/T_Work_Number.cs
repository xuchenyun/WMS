/*
  版权:  @Zach.zhong
  生成日期:2018/1/17   
  说明: T_Work_Number表对象类                      
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    /// <summary>
    /// 工单管理实体类 
    /// </summary>
    [Serializable]
    public class T_Work_Number
    {
        /// <summary>
        ///工单
        /// </summary>
		public string WoCode { get; set; }
        /// <summary>
        ///机种
        /// </summary>
		public string ProductCode { get; set; }
        /// <summary>
        ///机种名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        ///计划量
        /// </summary>
		public string PlanQty { get; set; }
        /// <summary>
        ///单面板数量
        /// </summary>
		public string AQty { get; set; }
        /// <summary>
        ///B面板数量
        /// </summary>
		public string BQty { get; set; }
        /// <summary>
        ///T面板数量
        /// </summary>
		public string TQty { get; set; }
        /// <summary>
        ///状态：0---开立，1---生产中，2---完工
        /// </summary>
		public string Status { get; set; }
        /// <summary>
        ///物料模式：0---客供料，1---自购料
        /// </summary>
		public string MaterialModel { get; set; }
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
        /// <summary>
        /// 客户料号
        /// </summary>
        public string C_PartNumber { get; set; }
        public string Version { get; set; }
    }
}
