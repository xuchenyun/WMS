using CIT.MES;
using CIT.MES.Common.Helper;
using CIT.Wcf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BLL
{
    public class Bll_Print
    {
        /// <summary>
        /// 打印标签
        /// </summary>
        /// <param name="printTemplateName">标签名</param>
        /// <param name="Value">关键值</param>
        /// <param name="msg">返回信息</param>
        /// <returns></returns>
        public static bool PrintTemplet(string printTemplateName,string Value,ref string msg)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string strSql = string.Format(@"SELECT LabelSQL FROM T_Bllb_LabelSource_tbls WHERE LabelName='{0}'", printTemplateName);
            DataTable dt_LabelSQL= NMS.QueryDataTable(PubUtils.uContext, strSql);//获取标签的SQL语句
            if (dt_LabelSQL.Rows.Count > 0)
            {
                DataTable dt_lableSource = NMS.QueryDataTable(PubUtils.uContext, string.Format(SqlInput.ChangeNullToString(dt_LabelSQL.Rows[0][0]), Value));//执行获取数据SQL语句
                foreach (DataColumn dc in dt_lableSource.Columns)
                {
                    dic.Add(dc.ColumnName, dt_lableSource.Rows[0][dc.ColumnName].ToString());
                }
            }
            else
            {
                msg = "标签"+printTemplateName+"没有SQL语句";
                return false;
            }           
            return CIT.MES.IO.InOutPut.PrintTemplet(printTemplateName, dic);
        }
        /// <summary>
        /// 本地打印
        /// </summary>
        /// <param name="printTemplateName"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static bool PrintTemplet(string printTemplateName, Dictionary<string, string> dic)
        {
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //string strSql = string.Format(@"SELECT LabelSQL FROM T_Bllb_LabelSource_tbls WHERE LabelName='{0}'", printTemplateName);
            //DataTable dt_LabelSQL = NMS.QueryDataTable(PubUtils.uContext, strSql);//获取标签的SQL语句
            //if (dt_LabelSQL.Rows.Count > 0)
            //{
            //    DataTable dt_lableSource = NMS.QueryDataTable(PubUtils.uContext, string.Format(SqlInput.ChangeNullToString(dt_LabelSQL.Rows[0][0]), Value));//执行获取数据SQL语句
            //    foreach (DataColumn dc in dt_lableSource.Columns)
            //    {
            //        dic.Add(dc.ColumnName, dt_lableSource.Rows[0][dc.ColumnName].ToString());
            //    }
            //}
            //else
            //{
            //    msg = "标签" + printTemplateName + "没有SQL语句";
            //    return false;
            //}
            return CIT.MES.IO.InOutPut.PrintTemplet(printTemplateName, dic);
        }
    }
}
