using CIT.MES;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.DAL
{
    public class T_Bllb_materialUsed_tbmu_DAL
    {
        /// <summary>
        /// 查询物料用料数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetMaterialUsed(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT p.WoCode,MU.SFCNO,MU.SERIALNUMBER,S.WORKSTATION_SN,S.WORKSTATION_NAME,PL.PLName,                           
                                   QTY,MU.CREATOR,MU.CREATE_TIME,MU.PARTNUMBER ,MU.PART_SN
                                           from  T_Bllb_materialUsed_tbmu AS  MU
                                                 INNER JOIN SfcDatProduct AS P
                                                       ON MU.SFCNO=P.SfcNo
                                                 INNER JOIN MdcDatProductLine AS PL
                                                 ON PL.PLCode=P.Line
                                                 INNER JOIN T_Bllb_station_tbs AS  S
                                                 ON S.TBS_ID=MU.TBS_ID
                                                 left JOIN SysDatUser AS U
                                                 ON U.UserID=MU.CREATOR");
            if (strWhere != string.Empty)
            {
                strSql.Append(strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 查询物料消耗
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable MaterialUsed(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT p.WoCode,MU.SFCNO,MU.SERIALNUMBER,S.WORKSTATION_SN,S.WORKSTATION_NAME,PL.PLName,
                            CASE  WHEN PL.PLName  LIKE 'SMT%' THEN 'SMT'  ELSE '组装' END AS 'Step',
                                   QTY,MU.CREATOR,MU.CREATE_TIME,MU.PARTNUMBER ,MU.PART_SN
                                           from  T_Bllb_materialUsed_tbmu AS  MU
                                                 INNER JOIN SfcDatProduct AS P
                                                       ON MU.SFCNO=P.SfcNo
                                                 INNER JOIN MdcDatProductLine AS PL
                                                 ON PL.PLCode=P.Line
                                                 INNER JOIN T_Bllb_station_tbs AS  S
                                                 ON S.TBS_ID=MU.TBS_ID
                                                 left JOIN SysDatUser AS U
                                                 ON U.UserID=MU.CREATOR");
            if (strWhere != string.Empty)
            {
                strSql.Append(strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        public DataTable GetSMTMtrUse(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT a.WorkOrderNo,a.MOrderNo,b.PCBCode,a.UniqueCode,a.MatrCode,D.MachineName,a.TableNo,
a.PickPos,a.LineName,a.LotNo,a.DateCode,a.Supplier,a.CreateTime FROM TRS_TrailInfo_View a
left JOIN dbo.TRS_Base_PCBCode b
ON a.PCBCode=b.PanelCode
left join PVS_Base_Machine d
on d.MachineCode = a.MachineCode AND d.LineID = a.LineID");
            if (strWhere != string.Empty)
            {
                strSql.Append(strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
    }
}
