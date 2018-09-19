using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public partial  class MdcDatProductLine
    {
        //产线表
        /// <summary>
        /// 线别代码
        /// </summary>
        public string PLCode { get; set; }
        /// <summary>
        /// 线别名称
        /// </summary>
        public string PLName { get; set; }
        /// <summary>
        /// 厂区代码
        /// </summary>
        public string FactoryCode { get; set; }
        /// <summary>
        /// 区域代码
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Descrition { get; set; }
        /// <summary>
        /// 轨道类型
        /// </summary>
        public int PLguidaoType { get; set; }
        /// <summary>
        /// 停线等级
        /// </summary>
        public int  StopLeavl { get; set; }
        /// <summary>
        /// 对料时间
        /// </summary>
        public DateTime CheckTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public string Updater { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime Updateime { get; set; }
        /// <summary>
        /// 阶别
        /// </summary>
        public string Step { get; set; }
    }
}
