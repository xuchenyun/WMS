/*
  版权:  @Zach.zhong
  生成日期:2018/4/25   
  说明: MdcDatSuppliesManage表业务层操作类                      
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIT.Wcf.Utils;
using CIT.MES;
using CIT.Interface;
using Model;

namespace BaseData.BLL
{
    class Bll_MdcDatSuppliesManage
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere">where条件</param>
        /// <returns></returns>
		public static DataTable Query(string strWhere)
        {

            string sqlcmd = string.Format(@" select SupplierName,SupplierCode,AboutPerson,Address,Number,Tel,Fax,Email,Note,Statur,ReginTime,FinanlTime,Creator,CreateTmie,
Updater,UpdateTime from MdcDatSuppliesManage {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="model">MdcDatSuppliesManage表实体</param>
        /// <returns></returns>
		public static bool Insert(MdcDatSuppliesManage model)
        {
            string sqlcmd = @"insert into MdcDatSuppliesManage(SupplierName,SupplierCode)values (@SupplierName,@SupplierCode)";
            CmdParameter[] cps = new CmdParameter[] {
                new CmdParameter { ParameterName="SupplierName",Value= model.SupplierName },
                new CmdParameter { ParameterName="SupplierCode",Value=model.SupplierCode },
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
            string sqlcmd = string.Format("delete from MdcDatSuppliesManage {0}", where);
            return NMS.ExecTransql(PubUtils.uContext, sqlcmd);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">MdcDatSuppliesManage表实体</param>
        /// <returns></returns>
		public static bool Update(MdcDatSuppliesManage model, string oldSupplierCode)
        {
            string sqlcmd = @"
                update MdcDatSuppliesManage set 
				SupplierName=@SupplierName,
				SupplierCode=@SupplierCode
				where SupplierCode=@oldSupplierCode";
            CmdParameter[] cps = new CmdParameter[] {
                new CmdParameter { ParameterName="SupplierName",Value= model.SupplierName },
                new CmdParameter { ParameterName="SupplierCode",Value=model.SupplierCode },
                new CmdParameter { ParameterName="oldSupplierCode",Value=oldSupplierCode }
              };
            return NMS.ExecTransql(PubUtils.uContext, sqlcmd, cps);
        }
    }
}
