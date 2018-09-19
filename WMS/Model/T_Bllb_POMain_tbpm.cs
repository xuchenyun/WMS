/*
  版权:  @Zach.zhong
  生成日期:2018/4/26   
  说明: T_Bllb_POMain_tbpm表对象类                      
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    public class T_Bllb_POMain_tbpm
    {
        /// <summary>
        ///采购订单ID
        /// </summary>
		public string POID { get; set; }
        /// <summary>
        ///采购订单号
        /// </summary>
		public string PO { get; set; }
        /// <summary>
        ///供应商编码
        /// </summary>
		public string SupplierCode { get; set; }
        /// <summary>
        ///部门名称
        /// </summary>
		public string DepartmentName { get; set; }
        /// <summary>
        ///员工号
        /// </summary>
		public string EmployeeCode { get; set; }
        /// <summary>
        ///采购类型编码1：采购，2：生产入库，3：生产领用
        /// </summary>
		public string PO_TypeCode { get; set; }
        /// <summary>
        ///币种（人民币）
        /// </summary>
		public string MoneyType { get; set; }
        /// <summary>
        ///税率（%）
        /// </summary>
		public string TaxRate { get; set; }
        /// <summary>
        ///创建时间
        /// </summary>
		public DateTime CreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public DateTime UpdateTime { get; set; }
        /// <summary>
        ///部门代码
        /// </summary>
		public string DepartmentCode { get; set; }

        /// <summary>
        ///来料单
        /// </summary>
        public string InCode { get; set; }
    }
}
