using Model;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CIT.MES;

namespace Query.DAL
{
    /// <summary>
    /// 产品过站记录表业务层访问类
    /// </summary>
    public class T_Bllb_productPass_tbpp_DAL
    {
        /// <summary>
        /// 查询过站记录数据
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
          
                strSql.Append(@"SELECT Tbpi.SERIAL_NUMBER,Product.WoCode,Product.SfcNo,Product.Line PLCode,ProLine.PLName,CASE  Tbpp.STATE_FLAG WHEN '0' THEN '正常' WHEN '1' THEN '不良' END AS 'STATE_FLAG',
                              CASE Tbpi.OVER_FLAG WHEN 'Y' THEN '是' WHEN 'N' THEN '否' END AS 'OVER_FLAG',SysUser.UserName,Tbpp.PASS_TIME,Tbpp.LogFileAddress,Tbg.GROUP_NAME 
                              FROM T_Bllb_productPass_tbpp AS Tbpp
                                 LEFT  JOIN T_Bllb_productInfo_tbpi AS Tbpi
                                   ON Tbpp.TBPS_ID=Tbpi.TBPS_ID
                                 LEFT JOIN SfcDatProduct AS Product
                                   ON Tbpi.SfcNo=Product.SfcNo
                                 LEFT JOIN MdcDatProductLine AS ProLine
                                  ON ProLine.PLCode=Product.Line
                                 LEFT JOIN SysDatUser AS SysUser
                                  ON  Tbpp.UserID=SysUser.UserID
                                 LEFT JOIN T_Bllb_Group_tbg AS Tbg
                                  ON Tbg.TBG_ID=Tbpp.TBG_ID");
                if (strWhere != string.Empty)
                {
                    strSql.Append(strWhere);
                }
            
           
            return NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
        }
    }
}
