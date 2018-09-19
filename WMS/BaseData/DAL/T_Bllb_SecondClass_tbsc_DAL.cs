using CIT.MES;
using CIT.Wcf.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData.DAL
{
    public partial class T_Bllb_SecondClass_tbsc_DAL
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Query(string strWhere)
        {
            string strSql = string.Format(@"select a.Type,a.Class,a.OrderNum,a.TemperatureMaxTime,a.TemperatureMinTime,a.InHouseTime,a.ExposeTime,a.SplitTime,a.RoastMaxTemperature,a.RoastMinTemperature,a.RoastTime,b.UserName,a.CreateTime,a.Remark from T_Bllb_SecondClass_tbsc a
left join SysDatUser b on a.Creator=b.UserID {0}",strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool Delete(string strWhere)
        {
            string strSql = string.Format(@"delete from T_Bllb_SecondClass_tbsc {0}",strWhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }

        public static string GetClassValue(string typevalue)
        {
            string strSql = string.Format(@"
declare @Type nvarchar(50)
declare @Class nvarchar(50)
set @Type ='{0}'
if(@Type='红胶' or @Type='锡膏')
begin
	if not exists (select Class from T_Bllb_SecondClass_tbsc where [Type]='红胶' or [Type]='锡膏' )
	   begin    
		  select @Class='X01'
		end
	else  
		begin  
		  select  TOP 1   @Class=Class from T_Bllb_SecondClass_tbsc where [Type]='红胶' or [Type]='锡膏'  ORDER BY CreateTime DESC 
		  set  @Class='X'+right('00' + convert(varchar, convert(bigInt, isNull(substring(@Class, 2, 2), 0)) + 1), 2)
		end
end
else
begin
	if not exists (select Class from T_Bllb_SecondClass_tbsc where [Type]='MSD' )
	   begin    
		  select @Class='M01'
		end
	else  
		begin  
		  select TOP 1  @Class=Class from T_Bllb_SecondClass_tbsc where [Type]='MSD' ORDER BY CreateTime DESC 
		  set  @Class='M'+right('00' + convert(varchar, convert(bigInt, isNull(substring(@Class, 2, 2), 0)) + 1), 2)
		end
end
select @Class as 'Class' 
", typevalue);
            return NMS.QueryDataTable(PubUtils.uContext, strSql).Rows[0]["Class"].ToString();
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public static bool Insert(List<T_Bllb_SecondClass_tbsc> lstAddEntity)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (T_Bllb_SecondClass_tbsc SC in lstAddEntity)
            {
                strSql.Append (string.Format(@"insert into T_Bllb_SecondClass_tbsc(Type,Class,OrderNum,TemperatureMaxTime,TemperatureMinTime,ExposeTime,InHouseTime,SplitTime,RoastMaxTemperature,RoastMinTemperature,RoastTime,Remark,Creator,CreateTime,Condition) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',getdate(),'{13}')", SC.Type, SC.Class, SC.OrderNum, SC.TemperatureMaxTime, SC.TemperatureMinTime, SC.ExposeTime, SC.InHouseTime, SC.SplitTime, SC.RoastMaxTemperature, SC.RoastMinTemperature, SC.RoastTime, SC.Remark, PubUtils.uContext.UserID,SC.Condition));
            
            }
            return NMS.ExecTransql(PubUtils.uContext, strSql.ToString());

        }
      
    }
}
