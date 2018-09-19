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
    public class BLL_Bllb_ProductFixture_tbpf
    {
        /// <summary>
        /// 查询治具在那些产品上使用的信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetList(string strWhere)
        {
            string strSql = string.Format(@"SELECT tbpf.FIXTURE_SN,tbpi.SERIAL_NUMBER,tbpi.SfcNo,sfc.WoCode,tbpf.CREATE_TIME FROM T_Bllb_ProductFixture_tbpf tbpf 
left join T_Bllb_productInfo_tbpi tbpi on tbpf.tbps_id=tbpi.TBPS_ID
left join SfcDatProduct sfc on sfc.sfcno=tbpi.SfcNo {0} ",strWhere);
            return NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
