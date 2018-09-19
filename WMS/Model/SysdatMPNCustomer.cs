/*
  版权:  @Zach.zhong
  生成日期:2018/4/25   
  说明: SysdatMPNCustomer表对象类                      
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
	public class SysdatMPNCustomer
	{
        /// <summary>
        /// 客户ID
        /// </summary>
		public string CustomerID { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
		public string CustomerName { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
		public string Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
		public DateTime CreateTime { get; set; }
        /// <summary>
        ///联系人
        /// </summary>
		public string Contact { get; set; }
        /// <summary>
        ///联系电话
        /// </summary>
		public string ContactNumber { get; set; }
        /// <summary>
        ///邮箱
        /// </summary>
		public string Email { get; set; }
        /// <summary>
        ///送货地址
        /// </summary>
		public string ShippingAddress { get; set; }
        /// <summary>
        /// 客户代码
        /// </summary>
        public string CustomerCode { get; set; }

    }
}
