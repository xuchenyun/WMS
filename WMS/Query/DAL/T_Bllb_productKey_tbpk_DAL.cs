using Model;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CIT.MES;
using Common.Helper;

namespace Query.DAL
{
    /// <summary>
    /// 产品关键件组装信息表数据层访问类
    /// </summary>
    public class T_Bllb_productKey_tbpk_DAL
    {
        /// <summary>
        /// 查询组建信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT Tbpi.SERIAL_NUMBER,Tbpk.KEY_SN,case Tbkt.KEY_TYPE WHEN 0 THEN '0' WHEN 1 THEN '关键件' WHEN 2 THEN '随机卡' END AS 'KEY_TYPE',SysUser.UserName,Tbpk.CREATE_TIME,Tbps.PLCode,ProLine.PLName, tbg.GROUP_NAME
                                  FROM T_Bllb_productKey_tbpk  AS Tbpk
                                    LEFT JOIN T_Bllb_productInfo_tbpi AS Tbpi
                                      ON Tbpi.TBPS_ID=Tbpk.TBPS_ID
                                    LEFT JOIN T_Bllb_keyType_tbkt  AS Tbkt
                                      ON Tbkt.TBKT_ID=Tbpk.TBKT_ID
                                    LEFT  JOIN SysDatUser AS SysUser
                                      ON SysUser.UserID=Tbpk.UserID
                                    LEFT JOIN T_Bllb_productStatus_tbps Tbps
                                      ON Tbps.TBPS_ID=Tbpk.TBPS_ID
                                    LEFT JOIN MdcDatProductLine AS ProLine
                                      ON ProLine.PLCode=Tbps.PLCode
                                    LEFT JOIN T_Bllb_Group_tbg  AS tbg
                                      ON tbg.TBG_ID=Tbpk.TBG_ID");

            if (strWhere != string.Empty)
            {
                strSql.Append(strWhere);
            }
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
        /// <summary>
        /// 通过关键件找到产品条码
        /// </summary>
        /// <param name="KeySN"></param>
        /// <returns></returns>
        public string GetSerialNumberByKeySN(string KeySN)
        {
            string strSql = string.Format(@"SELECT tbpi.SERIAL_NUMBER FROM T_Bllb_productInfo_tbpi tbpi left join T_Bllb_productKey_tbpk tbpk
on tbpi.TBPS_ID=tbpk.TBPS_ID WHERE tbpk.KEY_SN='{0}'",KeySN);
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
            if(dt.Rows.Count>0)
            {
                return SqlInput.ChangeNullToString(dt.Rows[0][0]);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
