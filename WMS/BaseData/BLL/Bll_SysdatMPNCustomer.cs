/*
  版权:  @Zach.zhong
  生成日期:2018/4/25   
  说明: SysdatMPNCustomer表业务层操作类                      
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using CIT.Wcf.Utils;
using CIT.MES;
using CIT.Interface;

namespace BaseData.BLL
{
    class Bll_SysdatMPNCustomer
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere">where条件</param>
        /// <returns></returns>
		public static DataTable Query(string strWhere)
        {

            string sqlcmd = string.Format(@" select CustomerID,CustomerName,CustomerCode,Creator,CreateTime,Contact,ContactNumber,Email,ShippingAddress from 
SysdatMPNCustomer {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="model">SysdatMPNCustomer表实体</param>
        /// <returns></returns>
		public static bool Insert(SysdatMPNCustomer model)
        {
            string sqlcmd = @"insert into SysdatMPNCustomer(CustomerID,CustomerCode,CustomerName,Creator,CreateTime,Contact,ContactNumber,Email,ShippingAddress)
values (@CustomerID,@CustomerCode,@CustomerName,@Creator,@CreateTime,@Contact,@ContactNumber,@Email,@ShippingAddress)";
            CmdParameter[] cps = new CmdParameter[] {
                new CmdParameter {ParameterName= "CustomerID",Value= model.CustomerID },
                new CmdParameter {ParameterName= "CustomerCode",Value= model.CustomerCode },
                new CmdParameter {ParameterName=  "CustomerName",Value= model.CustomerName },
                new CmdParameter {ParameterName=  "Creator",Value= model.Creator },
                new CmdParameter { ParameterName = "CreateTime",Value=  model.CreateTime },
                new CmdParameter { ParameterName= "Contact",Value= model.Contact },
                new CmdParameter { ParameterName= "ContactNumber",Value= model.ContactNumber },
                new CmdParameter { ParameterName= "Email",Value= model.Email },
                new CmdParameter { ParameterName= "ShippingAddress",Value= model.ShippingAddress }
              };
            return NMS.ExecTransql(PubUtils.uContext, sqlcmd, cps);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
		public static bool Delete(string where)
        {
            string sqlcmd = string.Format("delete from SysdatMPNCustomer {0}", where);
            return NMS.ExecTransql(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">SysdatMPNCustomer表实体</param>
        /// <returns></returns>
		public static bool Update(SysdatMPNCustomer model)
        {
            string sqlcmd = @"
                update SysdatMPNCustomer set 
				CustomerID=@CustomerID,
                CustomerCode=@CustomerCode,
				CustomerName=@CustomerName,
				Creator=@Creator,
				CreateTime=@CreateTime,
				Contact=@Contact,
				ContactNumber=@ContactNumber,
				Email=@Email,
				ShippingAddress=@ShippingAddress
				where CustomerID=@CustomerID";
            CmdParameter[] cps = new CmdParameter[] {
                new CmdParameter {ParameterName= "CustomerID",Value= model.CustomerID },
                new CmdParameter {ParameterName= "CustomerCode",Value= model.CustomerCode },
                new CmdParameter {ParameterName=  "CustomerName",Value= model.CustomerName },
                new CmdParameter {ParameterName=  "Creator",Value= model.Creator },
                new CmdParameter { ParameterName = "CreateTime",Value=  model.CreateTime },
                new CmdParameter { ParameterName= "Contact",Value= model.Contact },
                new CmdParameter { ParameterName= "ContactNumber",Value= model.ContactNumber },
                new CmdParameter { ParameterName= "Email",Value= model.Email },
                new CmdParameter { ParameterName= "ShippingAddress",Value= model.ShippingAddress }
              };
            return NMS.ExecTransql(PubUtils.uContext, sqlcmd, cps);
        }
    }
}
