using CIT.MES;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.BLL
{
    public static class Bll_Bllb_inOutLog_tbiol
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="tbiol"></param>
        /// <returns></returns>
        public static bool Insert(T_Bllb_inOutLog_tbiol tbiol)
        {
            string strSql = string.Format(@"insert into T_Bllb_inOutLog_tbiol (SFCNO,TBPS_ID,ACTION_TYPE,CREATE_TIME,USERID)values
                ('{0}','{1}','{2}','{3}','{4}')", tbiol.SFCNO, tbiol.TBPS_ID, tbiol.ACTION_TYPE, tbiol.CREATE_TIME, tbiol.USERID);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="lstTbiol"></param>
        /// <returns></returns>
        public static bool Insert(List<T_Bllb_inOutLog_tbiol> lstTbiol)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (var tbiol in lstTbiol)
            {
                strSql.Append(string.Format(@"insert into T_Bllb_inOutLog_tbiol (SFCNO,TBPS_ID,ACTION_TYPE,CREATE_TIME,USERID)values
                ('{0}','{1}','{2}','{3}','{4}')", tbiol.SFCNO, tbiol.TBPS_ID, tbiol.ACTION_TYPE, tbiol.CREATE_TIME, tbiol.USERID));
            }
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable Query(string strWhere)
        {
            string strSql = string.Format(@"select i.SfcNo as 制令单,i.SERIAL_NUMBER as 产品条码 ,i.QTY as 数量 ,case  l.ACTION_TYPE when 1 then '入库' when 2 then '出库'end as 操作类型 ,l.CREATE_TIME as 操作时间 ,case l.USERID when s.USERID then s.UserName end  as 操作人员 from T_Bllb_inOutLog_tbiol as l
                            left join  T_Bllb_productInfo_tbpi as i on l.TBPS_ID=i.TBPS_ID
                            left join SysDatUser as s on l.USERID =s.UserID {0}", strWhere);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
    }
}
