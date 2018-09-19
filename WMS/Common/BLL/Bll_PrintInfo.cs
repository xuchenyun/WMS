using CIT.MES;
using CIT.Wcf.Utils;
using Common.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BLL
{
    public class Bll_PrintInfo
    {
        /// <summary>
        /// 打印外包装标签
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public static bool PrintContain_1_Info(string SN,string lableName,ref string msg)
        {
            if(SN==string.Empty)
            {
                msg = "箱条码不能为空";
                return false;
            }
            else if (lableName==string.Empty)
            {
                msg = "打印标签不能为空";
                return false;
            }
            Model.Model_PackageInfo _obj_PackageInfo = new Model_PackageInfo();
            T_Bllb_packageOne_tbpo tbpo = new T_Bllb_packageOne_tbpo();
            string strSql = string.Format(@"select isnull(SUM(tbpi.QTY),0) as QTY,sfc.PO,tbpo.CONTAINER_SN_1 AS BOXID,
SFC.Product AS PRODUCTCODE,'12个月' as ACTIVE_LENGTH 
from T_Bllb_packageOne_tbpo as tbpo     
inner join T_Bllb_productInfo_tbpi as tbpi on tbpo.TBPS_ID=tbpi.TBPS_ID
inner join SfcDatProduct sfc on sfc.SfcNo=tbpi.SfcNo                                
where tbpo.CONTAINER_SN_1='{0}' GROUP BY sfc.PO,tbpo.CONTAINER_SN_1,SFC.Product", SN);
            DataTable dt_qty = NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
            if(dt_qty.Rows.Count==0)
            {
                msg = "条码不是箱条码";
                return false;
            }

            _obj_PackageInfo.QTY =SqlInput.ChangeNullToInt(dt_qty.Rows[0]["QTY"], 0).ToString();//容器实装数量
            if (_obj_PackageInfo.QTY == "0")
            {
                msg = "箱子中没有产品";
                return false;
            }
            _obj_PackageInfo.PO= SqlInput.ChangeNullToString(dt_qty.Rows[0]["PO"]);
            _obj_PackageInfo.PRODUCTCODE = SqlInput.ChangeNullToString(dt_qty.Rows[0]["PRODUCTCODE"]);
            _obj_PackageInfo.P1 = SqlInput.ChangeNullToString(dt_qty.Rows[0]["PRODUCTCODE"]);
            _obj_PackageInfo.ACTIVE_LENGTH = "12个月";
            _obj_PackageInfo.BEGIN_DATE = DateTime.Now.ToString("yyyyMMdd");
            _obj_PackageInfo.END_DATE = DateTime.Now.AddMonths(12).ToString("yyyyMMdd");
            _obj_PackageInfo.E1 = DateTime.Now.AddMonths(12).ToString("yyyyMMdd");
            _obj_PackageInfo.BOXID = SqlInput.ChangeNullToString(dt_qty.Rows[0]["BOXID"]);
         
            if (Bll_Common.GetSysParameter("DZ", "DZ006", ref msg))
            {
                string[] strs = msg.Split('|');
                if (strs.Length >= 2)
                {
                    _obj_PackageInfo.SUPPLIER = strs[0];
                    _obj_PackageInfo.SUPPLIER_CODE = strs[1];
                }
                else
                {
                    msg="在系统参数【单值】中的【DZ006】配置供应商信息";
                    return false;
                }
            }
            else
            {
                msg="在系统参数【单值】中的【DZ006】配置供应商信息";
                return false;
            }

            if (_obj_PackageInfo.PrintOwn(lableName))
            {
                //标识为已打印外包装标签
                strSql = string.Format("update T_Bllb_packageOne_tbpo set PRINT_FLAG='Y' where CONTAINER_SN_1='{0}'", tbpo.CONTAINER_SN_1);
                NMS.ExecTransql(PubUtils.uContext, strSql);
            }
            return true;
        }
        /// <summary>
//        /// 打印外包装标签
//        /// </summary>
//        /// <param name="SN"></param>
//        /// <returns></returns>
//        public static bool PrintContain_1_Info(string SN,string LableName, ref string msg)
//        {
//            Model.Model_PackageInfo _obj_PackageInfo = new Model_PackageInfo();
//            T_Bllb_packageOne_tbpo tbpo = new T_Bllb_packageOne_tbpo();
//            string strSql = string.Format(@"select isnull(SUM(tbpi.QTY),0) as QTY,tbpi.SFCNO,tbpo.CONTAINER_SN_1 from
//T_Bllb_packageOne_tbpo as tbpo     
//inner join T_Bllb_productInfo_tbpi as tbpi on tbpo.TBPS_ID=tbpi.TBPS_ID                                
//where tbpo.CONTAINER_SN_1='{0}' GROUP BY tbpi.SFCNO,tbpo.CONTAINER_SN_1", SN);
//            DataTable dt_qty = NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
//            if (dt_qty.Rows.Count == 0)
//            {
//                msg = "条码不是箱条码";
//                return false;
//            }
//            _obj_PackageInfo.QTY = SqlInput.ChangeNullToInt(dt_qty.Rows[0]["QTY"], 0).ToString();//容器实装数量 
//            tbpo.CONTAINER_SN_1 = SqlInput.ChangeNullToString(dt_qty.Rows[0]["CONTAINER_SN_1"]);//容器条码
//            strSql = string.Format(@"select TBBP.TBBP_ID,TBBP.PRODUCTCODE,TBBP.PARA1,TBBP.CREATE_TIME,TBBP.CREATOR,TBBP.MODIFIER,TBBP.MODIFY_TIME,
//TBBP.PARTNUMBER,TBBP.PARTNAME,TBBP.PARTSPEC,GETDATE() SYSTIME,SUPPLIER,RECEIVER
//from T_Bllb_barcodeProduct_tbbp TBBP
//LEFT JOIN SFCDATPRODUCT SFC ON SFC.PRODUCT = TBBP.PRODUCTCODE
// WHERE SFC.SFCNO = '{0}'", SqlInput.ChangeNullToString(dt_qty.Rows[0]["SFCNO"]));
//            DataTable dt_print = NMS.QueryDataTable(PubUtils.uContext, strSql.ToString());
//            _obj_PackageInfo.PRODUCTCODE = SqlInput.ChangeNullToString(dt_print.Rows[0]["PRODUCTCODE"]);
//            _obj_PackageInfo.SUPPLIER = SqlInput.ChangeNullToString(dt_print.Rows[0]["SUPPLIER"]);//供货方
//            _obj_PackageInfo.RECEIVER = SqlInput.ChangeNullToString(dt_print.Rows[0]["RECEIVER"]);//收货方
//            _obj_PackageInfo.PARTNAME = SqlInput.ChangeNullToString(dt_print.Rows[0]["PARTNAME"]);
//            _obj_PackageInfo.PARTNUMBER = SqlInput.ChangeNullToString(dt_print.Rows[0]["PARTNUMBER"]);
//            _obj_PackageInfo.PARTSPEC = SqlInput.ChangeNullToString(dt_print.Rows[0]["PARTSPEC"]);
//            _obj_PackageInfo.LOTNO = SqlInput.ChangeDateTimeToValue(dt_print.Rows[0]["SYSTIME"], DateTime.Now).ToString("yyyyMMdd");
//            _obj_PackageInfo.QRCODE =
//                          "零件编号:" + _obj_PackageInfo.PARTNUMBER
//                      + "|项目编号:" + _obj_PackageInfo.PRODUCTCODE
//                      + "|零件名称:" + _obj_PackageInfo.PARTNAME
//                      + "|产品批次:" + _obj_PackageInfo.LOTNO
//                      + "|数量:" + _obj_PackageInfo.QTY;
//            //+ "|型号规格:" + _obj_PackageInfo.PARTSPEC
//            if (_obj_PackageInfo.PrintOwn(LableName))
//            {
//                //标识为已打印外包装标签
//                strSql = string.Format("update T_Bllb_packageOne_tbpo set PRINT_FLAG='Y' where CONTAINER_SN_1='{0}'", tbpo.CONTAINER_SN_1);
//                NMS.ExecTransql(PubUtils.uContext, strSql);
//            }
//            return true;
//        }
    }
}
