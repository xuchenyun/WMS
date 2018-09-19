using CIT.MES;

using CIT.Wcf.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData.BLL
{
    public class MdcdatProductDetail_BLL
    {
        public static bool Insert(List<MdcdatProductDetail> lstInsert)
            
        {
            StringBuilder strB = new StringBuilder();
            foreach (MdcdatProductDetail PD in lstInsert)
            {
                strB.Append(String.Format(@"insert into MdcdatProductDetail(Fguid,ProductCode,key1,key2,key3,Value1,Value2,Value3,Creator,CreateTime) Values('{0}','{1}','{2}','是否启用','单位标准用量','{3}','{4}','{5}','{6}',getdate())",PD.Fguid, PD.ProductCode, PD.key1, PD.Value1, PD.Value2, PD.Value3,PubUtils.uContext.UserID));
            }
            return NMS.ExecTransql(PubUtils.uContext, strB.ToString());            
        }
       
    }
}
