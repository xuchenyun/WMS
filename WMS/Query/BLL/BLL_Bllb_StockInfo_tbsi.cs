using CIT.MES;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.BLL
{
    public partial class BLL_Bllb_StockInfo_tbsi
    {
        /// <summary>
        /// 查询展示数据
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public static DataTable QueryShowData(string strwhere)
        {
            string strsql = string.Format(@"
--超期
select case a.Storage_SN when c.Storage_SN then c.Storage_Name end 'Storage_SN',
case a.Area_SN when d.Area_SN then d.Area_Name end 'Area_SN',
case a.Location_SN when e.Location_SN then e.Location_Name end 'Location_SN',
a.MaterialCode,a.QTY,case a.Lock_Flag when '1' then '盘点'  when '2' then '冻结' else '正常' end Lock_Flag,
a.DateCode,a.In_Time,a.SerialNumber,'1' as flag,a.Lock_Time from dbo.T_Bllb_StockInfo_tbsi as a
left join dbo.MdcdatMaterial as b on a.MaterialCode=b.MaterialCode
left join dbo.T_Bllb_Storage_tbs as c on a.Storage_SN=c.Storage_SN
left join dbo.T_Bllb_StorageArea_tbsa as d on d.Area_SN=a.Area_SN
left join dbo.T_Bllb_StorageLocation_tbsl as e on e.Location_SN =a.Location_SN
where a.Finally_Time<= getDate() and Lock_Flag='2' AND b.ShelfLifeTime IS NOT NULL AND b.ShelfLifeTime <>'0' {0}
union 
--预警
select case a.Storage_SN when c.Storage_SN then c.Storage_Name end 'Storage_SN',
case a.Area_SN when d.Area_SN then d.Area_Name end 'Area_SN',
case a.Location_SN when e.Location_SN then e.Location_Name end 'Location_SN',
a.MaterialCode,a.QTY,case a.Lock_Flag  when '1' then '盘点'  when '2' then '冻结' else '正常' end Lock_Flag,
a.DateCode,a.In_Time,a.SerialNumber,'2' as flag,a.Lock_Time from dbo.T_Bllb_StockInfo_tbsi as a
left join dbo.MdcdatMaterial as b on a.MaterialCode=b.MaterialCode
left join dbo.T_Bllb_Storage_tbs as c on a.Storage_SN=c.Storage_SN
left join dbo.T_Bllb_StorageArea_tbsa as d on d.Area_SN=a.Area_SN
left join dbo.T_Bllb_StorageLocation_tbsl as e on e.Location_SN =a.Location_SN
where dateDiff(day,a.Finally_Time,getDate()) between -7 and 0  and a.Lock_Flag='0' AND b.ShelfLifeTime IS NOT NULL AND b.ShelfLifeTime <>'0'  {0}", strwhere);
            return NMS.QueryDataTable(PubUtils.uContext, strsql);
        }

        /// <summary>
        /// 根据有效期和入库时间，获得条码有效期状态
        /// </summary>
        /// <returns></returns>
        public static DataTable QueryExpiryDate(string strwhere)
        {
            string strsql = string.Format(@"
--超期
select case a.Storage_SN when c.Storage_SN then c.Storage_Name end 'Storage_SN',
case a.Area_SN when d.Area_SN then d.Area_Name end 'Area_SN',
case a.Location_SN when e.Location_SN then e.Location_Name end 'Location_SN',
a.MaterialCode,a.QTY,case a.Lock_Flag when '1' then '盘点'  when '2' then '冻结' else '正常' end Lock_Flag,
a.DateCode,a.In_Time,a.SerialNumber,'1' as flag,a.Lock_Time from dbo.T_Bllb_StockInfo_tbsi as a
left join dbo.MdcdatMaterial as b on a.MaterialCode=b.MaterialCode
left join dbo.T_Bllb_Storage_tbs as c on a.Storage_SN=c.Storage_SN
left join dbo.T_Bllb_StorageArea_tbsa as d on d.Area_SN=a.Area_SN
left join dbo.T_Bllb_StorageLocation_tbsl as e on e.Location_SN =a.Location_SN
where getDate()>=Finally_Time and Lock_Flag='0' AND b.ShelfLifeTime IS NOT NULL AND b.ShelfLifeTime <>'0' {0}
union 
--预警
select case a.Storage_SN when c.Storage_SN then c.Storage_Name end 'Storage_SN',
case a.Area_SN when d.Area_SN then d.Area_Name end 'Area_SN',
case a.Location_SN when e.Location_SN then e.Location_Name end 'Location_SN',
a.MaterialCode,a.QTY,case a.Lock_Flag  when '1' then '盘点'  when '2' then '冻结' else '正常' end Lock_Flag,
a.DateCode,a.In_Time,a.SerialNumber,'2' as flag,a.Lock_Time from dbo.T_Bllb_StockInfo_tbsi as a
left join dbo.MdcdatMaterial as b on a.MaterialCode=b.MaterialCode
left join dbo.T_Bllb_Storage_tbs as c on a.Storage_SN=c.Storage_SN
left join dbo.T_Bllb_StorageArea_tbsa as d on d.Area_SN=a.Area_SN
left join dbo.T_Bllb_StorageLocation_tbsl as e on e.Location_SN =a.Location_SN
where dateDiff(day,Finally_Time,getDate()) between -7 and 0  and Lock_Flag='0' AND b.ShelfLifeTime IS NOT NULL AND b.ShelfLifeTime <>'0'{0}", strwhere);
            return NMS.QueryDataTable(PubUtils.uContext, strsql);
        }
        /// <summary>
        /// 锁定超期的料盘
        /// </summary>
        /// <param name="dicBarCode"></param>
        /// <returns></returns>
        public static bool UpdateBarCodeLockStatus(Dictionary<string, string> dicBarCode)
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach (var item in dicBarCode)
            {
                if (item.Value == "0" || item.Value == "2")//正常||预警 不做冻结操作
                    continue;
                else if (item.Value == "1")//超期 库存表冻结相应料号
                    strBuilder.AppendFormat("update T_Bllb_StockInfo_tbsi set Lock_Flag=2,Lock_Time=getDate() where SerialNumber='{0}'", item.Key);
            }
            if (strBuilder.Length > 0)
                return NMS.ExecTransql(PubUtils.uContext, strBuilder.ToString());
            return true;
        }
        /// <summary>
        /// 根据状态查询需要送检的条码 
        /// </summary>
        /// <param name="varStatus"></param>
        /// <returns></returns>
        public static DataTable QuerySendToErCheckBarCode(string varStatus)
        {
            StringBuilder strBuilder = new StringBuilder();
            if (varStatus == "超期")
            {
                strBuilder.AppendFormat(@"
--超期
select a.Storage_SN, a.Area_SN, a.Location_SN, a.MaterialCode, a.QTY,case a.Lock_Flag when '1' then '盘点'
when '2' then '冻结' else '正常' end Lock_Flag, a.DateCode, a.In_Time,
a.SerialNumber, '1' as flag, a.Lock_Time from dbo.T_Bllb_StockInfo_tbsi as a
left join dbo.MdcdatMaterial as b on a.MaterialCode = b.MaterialCode
where getDate()>=a.Finally_Time and a.Lock_Flag = '2' AND b.ShelfLifeTime IS NOT NULL AND b.ShelfLifeTime <>'0'");
            }
            else if (varStatus == "预警")
            {
                strBuilder.AppendFormat(@"--预警
SELECT  a.Storage_SN,a.Area_SN,a.Location_SN,a.MaterialCode,a.QTY,case a.Lock_Flag  when '1' then '盘点' 
when '2' then '冻结' else '正常' end Lock_Flag,a.DateCode,a.In_Time,a.Finally_Time,
a.SerialNumber,'2' as flag,a.Lock_Time from dbo.T_Bllb_StockInfo_tbsi as a
inner join dbo.MdcdatMaterial as b on a.MaterialCode=b.MaterialCode
where (dateDiff(DAY,a.Finally_Time,getDate()) between -7 and 0)  and 
a.Lock_Flag='0'
AND b.ShelfLifeTime IS NOT NULL AND b.ShelfLifeTime <>'0' ");
            }
            return NMS.QueryDataTable(PubUtils.uContext, strBuilder.ToString());
        }
        /// <summary>
        /// 查询对应料号的二次送检单号
        /// </summary>
        /// <param name="materialCode"></param>
        /// <param name="strwhere_materialcode"></param>
        /// <returns></returns>
        public static string QueryIqcNo(string materialCode, string strwhere_materialcode, string memo)
        {
            //查询料号二次送检单号
            string query_iqc_no = string.Format(@"
declare @IQC_NO nVarchar(50)
if not exists(select * from dbo.T_Bllb_IQCDoc_tbid where DATEDIFF(Day,CREATE_TIME,GETDATE())=0 and IQC_NO like 'TQC%')
   begin 
   --当天不存在二次送检订单
    set @IQC_NO='TQC'+CONVERT(varchar,GETDATE(),112)+'001'
	select 1,@IQC_NO as 'IQC_NO','notexists' return
   end
else
   begin
   --当天存在二次送检订单 
	 --当天存在二次送检订单 ，则取当前最大订单号+1
		select top 1 @IQC_NO=IQC_NO  from T_Bllb_IQCDoc_tbid where IQC_NO like 'TQC%' and DATEDIFF(Day,CREATE_TIME,GETDATE())=0  order by IQC_NO desc
		set @IQC_NO='TQC'+CONVERT(varchar,GETDATE(),112)+right('000'+convert(varchar,convert(bigInt,isNull(substring(@IQC_NO,5,11),0))+1 ),3)  
	    select 1,@IQC_NO as 'IQC_NO','notexists' return
   end");
            DataTable dt_iqc_no = NMS.QueryDataTable(PubUtils.uContext, query_iqc_no);
            string iqc_no = dt_iqc_no.Rows[0]["IQC_NO"].ToString();
            //--如果数据库当天该料号不存在二次送检订单 则插入
            if (dt_iqc_no.Rows[0][2].ToString() == "notexists")
            {
                string create_iqc_no = string.Format(@"
declare @Qty nVarchar(50)--料号数量
--获得对应料号的总数量
select @Qty = sum(a.QTY)
from dbo.T_Bllb_StockInfo_tbsi as a
left join dbo.MdcdatMaterial as b on a.MaterialCode = b.MaterialCode
where a.MaterialCode = '{1}' {2}
group by a.MaterialCode
--如果当天该料号不存在二次送检订单 则插入
insert into dbo.T_Bllb_IQCDoc_tbid(IQC_NO, MaterialCode, QTY, CREATE_TIME, OVER_FLAG, CHECK_FLAG,MEMO,Type)
values('{0}', --IQC_NO - nvarchar(50)
       '{1}', --MaterialCode - nvarchar(50)
        @Qty, --QTY - int
        getDate(), --CREATE_TIME - datetime
        'N', --OVER_FLAG - nvarchar(10)
        'N',-- CHECK_FLAG - nvarchar(10)
        '{3}',
        'TQC'
      )", iqc_no, materialCode, strwhere_materialcode, memo);
                NMS.ExecTransql(PubUtils.uContext, create_iqc_no);
            }
            else
            {
                //; 存在，不做任何操作
            }
            return iqc_no;
        }
        /// <summary>
        /// 将条码插入送检从表
        /// </summary>
        /// <param name="dtBarCode"></param>
        /// <param name="strwhere_materialcode"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public static bool SendToErCheckBarCode(DataTable dtBarCode, string strwhere_materialcode, string memo)
        {
            StringBuilder strSend = new StringBuilder();
            foreach (DataRow dr in dtBarCode.Rows)
            {
                if (dr["Storage_SN"] == DBNull.Value)
                {
                    dr["Storage_SN"] = string.Empty;
                }
            }
            //根据料号分组 一个料号挂一个单据号
            var query = from t in dtBarCode.AsEnumerable()
                        group t by new { t1 = t.Field<string>("MaterialCode"), t2 = t.Field<string>("Storage_SN") } into m
                        select new
                        {
                            materialCode = m.Key.t1,
                            qty = m.Sum(n => n.Field<int>("QTY")),
                            storage_sn = m.Key.t2
                        };
            if (query.ToList().Count > 0)
            {
                foreach (var item in query.ToList())
                {
                    //查询二次送检单号
                    string iqc_no = BLL_Bllb_StockInfo_tbsi.QueryIqcNo(item.materialCode, strwhere_materialcode, memo);
                    //将每个条码插入IQC明细
                    foreach (DataRow dr in dtBarCode.Select(string.Format("MaterialCode='{0}' and Storage_SN='{1}'", item.materialCode, item.storage_sn)))
                    {
                        strSend.AppendFormat(@"
                    insert into dbo.T_Bllb_IQCProduct_tbip
                            ( TBIP_ID ,
                              IQC_NO ,
                              CREATE_TIME, 
                              QTY ,
                              SERIAL_NUMBER,
                    		  STATUS,
                    		  ChooseFlag
                            )
                    values  ( newId() , -- TBIP_ID - nvarchar(50)
                              '{0}' , -- IQC_NO - nvarchar(50)
                              getDate() , -- CREATE_TIME - datetime
                              '{1}' , -- QTY - int
                              N'{2}',  -- SERIAL_NUMBER - nvarchar(200)
                    		  '0',--STATUS
                    		  N'N' --ChooseFlag
                            )", iqc_no, dr["QTY"].ToString(), dr["SerialNumber"].ToString());
                        if (memo == "预警")
                            strSend.AppendFormat("update dbo.T_Bllb_StockInfo_tbsi set Lock_Flag='3',Lock_Time=getDate() where SerialNumber='{0}'", dr["SerialNumber"].ToString());
                        else if (memo == "超期")
                            strSend.AppendFormat("update dbo.T_Bllb_StockInfo_tbsi set Lock_Flag='3' where SerialNumber='{0}'", dr["SerialNumber"].ToString());
                        //2018-07-02 09:44:19 Zach 新增日志
                        Common.BLL.Bll_Common.WriteMaterialLog(dr["SerialNumber"].ToString(), "有效期管理=>二检", item.materialCode, dr["QTY"].ToString());
                    }
                }
            }
            if (strSend.Length > 0)
            {
                NMS.ExecTransql(PubUtils.uContext, strSend.ToString());
            }
            return true;
        }
    }
}
