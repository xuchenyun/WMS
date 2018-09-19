/*
  版权:  @Zach.zhong
  生成日期:2018/6/30   
  说明: MdcDatFeederManage表对象类                      
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    [Serializable]
    public class MdcDatFeederManage
    {
        /// <summary>
        /// FeederSN
        /// </summary>
		public string FeederSN { get; set; }
        /// <summary>
        /// Feeder代码
        /// </summary>
		public string FeederCode { get; set; }
        /// <summary>
        /// Feeder名
        /// </summary>
		public string FeederName { get; set; }
        /// <summary>
        /// Feeder宽
        /// </summary>
		public int FeederWidth { get; set; }
        /// <summary>
        ///0：维修 1：使用 2：损坏 3：保养 4：正常
        /// </summary>
		public int FeederStatus { get; set; }
        /// <summary>
        ///0：单边 1：双边 2：多边
        /// </summary>
		public string FeederType { get; set; }
        /// <summary>
        /// 阈值
        /// </summary>
		public int MaxNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public int TotalNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public int Value1 { get; set; }
        /// <summary>
        /// 打点数
        /// </summary>
		public int Value2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public decimal Value3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string FeederAprover { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public DateTime FeederBuyTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string FeederBaozhiqi { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string FeederAbPerson { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string FeederPTel { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string FeederBaoyangzq { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string Creator { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public DateTime CreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string Updator { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public DateTime Updateime { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string PrecisionX { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string PrecisionY { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string PrecisionQ { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string FeederRepairNote { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string Line { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string BCT { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string MachineID { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string TrolleyID { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string StationID { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string TrackID { get; set; }
        public int Division { get; set; }
        /// <summary>
        /// 预警
        /// </summary>
        public int EarlyWaring { get; set; }
    }
}
