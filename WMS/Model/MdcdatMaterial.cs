using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class MdcdatMaterial
    {
        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public string Grade { get; set; }
        /// <summary>
        /// 抛料率
        /// </summary>
        public string DropRate { get; set; }
        /// <summary>
        /// 是否允许超发
        /// </summary>
        public byte Crinosity { get; set; }
        /// <summary>
        /// 先进先出
        /// </summary>
        public string Fifo { get; set; }
        /// <summary>
        /// 保质期
        /// </summary>
        public byte ShelfLife { get; set; }
        /// <summary>
        /// 保质时间
        /// </summary>
        public int ShelfLifeTime { get; set; }
        /// <summary>
        /// 包装类型
        /// </summary>
        public string PackageType { get; set; }
        /// <summary>
        /// 最大包装
        /// </summary>
        public string PackagingMax { get; set; }
        /// <summary>
        /// 最小包装
        /// </summary>
        public string PackagingMin { get; set; }
        /// <summary>
        /// 供料方式
        /// </summary>
        public string INCOMINGTYPE { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 安全库存
        /// </summary>
        public int SafeQty { get; set; }
        /// <summary>
        /// 是否多包装规格
        /// </summary>
        public byte MorePackage { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Spec{ get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit{ get; set; }
        /// <summary>
        /// 物料描述
        /// </summary>
        public string MPN { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string HouseCode { get; set; }
        /// <summary>
        /// 库位ID
        /// </summary>
        public string LocationID { get; set; }
        /// <summary>
        /// 是否送检
        /// </summary>
        public string IsSendCheck { get; set; }
        /// <summary>
        /// 是否MSD
        /// </summary>
        public string IsMSD { get; set; }
        /// <summary>
        /// 辅材等级
        /// </summary>
        public string SecondMaterialClass { get; set; }
        /// <summary>
        /// 备用仓库1
        /// </summary>
        public string HouseCode1 { get; set; }
        /// <summary>
        /// 备用仓库2
        /// </summary>
        public string HouseCode2 { get; set; }
    }
}
