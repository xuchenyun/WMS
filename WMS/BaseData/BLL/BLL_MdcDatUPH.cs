using CIT.MES;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData.BLL
{
    public class BLL_MdcDatUPH
    {
        public static DataTable Query(string strWhere)
        {
            string strSql = string.Format(@"SELECT Fguid,WoCode,SfcNo,ProductName,Line,BoardType,LaneNo,note,UPH,Creator,CreateTime,UpdateTime,
Updator,BoradCnt,status FROM MdcDatUPH {0}", strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }

        public static bool Insert(Model.MdcDatUPH model_UPH)
        {
            string strSql = string.Format(@"insert into MdcDatUPH(Fguid,ProductName,Line,BoardType,LaneNo,note,UPH,Creator,CreateTime,BoradCnt)
values(newid(),'{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate(),'{7}')", model_UPH.ProductName, model_UPH.Line, model_UPH.BoardType,
             model_UPH.LaneNo, model_UPH.note, model_UPH.UPH, model_UPH.Creator, model_UPH.BoradCnt);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }

        public static bool Delete(string strWhere)
        {
            string strSql = string.Format(@"delete from MdcDatUPH {0}", strWhere);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }

        public static bool Update(Model.MdcDatUPH model_UPH)
        {
            string strSql = string.Format(@"update MdcDatUPH set UPH='{0}',note='{1}',BoradCnt='{2}',Updator='{3}',UpdateTime=getdate()
where Fguid='{4}' ", model_UPH.UPH, model_UPH.note, model_UPH.BoradCnt,PubUtils.uContext.UserName, model_UPH.Fguid);
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }

        //检查uph产品长度是否限制
        public static void Checkuphlengtn(out int len)
        {
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, "select * from SysDatConfig where key1='uph'");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["val1"].ToString() == "1")
                {
                    len = Convert.ToInt32(dt.Rows[0]["val2"]);
                }
                else
                {
                    len = 0;
                }

            }
            else
            {
                string sql = "insert into SysDatConfig(CGuid,key1, key2,val1, val2) values(NEWID(),'uph','length','1','10')";
                bool flag = NMS.ExecTransql(PubUtils.uContext, sql);
                len = 1;
            }
        }
    }
}
