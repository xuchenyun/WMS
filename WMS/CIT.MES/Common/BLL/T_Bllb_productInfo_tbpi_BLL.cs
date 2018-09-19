using CIT.MES;
using CIT.Wcf.Utils;
using Common.DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Common.BLL
{
    /// <summary>
    /// 产品信息表业务层访问类
    /// </summary>
    public class T_Bllb_productInfo_tbpi_BLL
    {
        T_Bllb_productInfo_tbpi_DAL t_Bllb_productInfo_tbpi_DAL = new T_Bllb_productInfo_tbpi_DAL();
        /// <summary>
        /// 更新入老化时间
        /// </summary>
        /// <param name="SerialNubmer">箱条码/小板条码</param>
        /// <returns></returns>
        public bool UpdateAGING_START_TIME(string SerialNubmer)
        {
            string strSql = string.Format(@"SELECT * FROM T_Bllb_packageOne_tbpo WHERE CONTAINER_SN_1='{0}'", SerialNubmer);
            if (NMS.QueryDataTable(PubUtils.uContext, strSql).Rows.Count > 0)
            {
                strSql = string.Format(@"UPDATE T_Bllb_productInfo_tbpi SET AGING_START_TIME=GETDATE() WHERE TBPS_ID IN (SELECT TBPS_ID FROM T_Bllb_packageOne_tbpo WHERE CONTAINER_SN_1='{0}')", SerialNubmer);
            }
            else
            {
                strSql = string.Format(@"UPDATE T_Bllb_productInfo_tbpi SET AGING_START_TIME=GETDATE() WHERE SERIAL_NUMBER='{0}'", SerialNubmer);
            }
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 设置出老化时间
        /// </summary>
        /// <param name="SerialNubmer">箱条码/小板条码</param
        /// <returns></returns>
        public bool UpdateAGING_END_TIME(string SerialNubmer)
        {
            string strSql = string.Format(@"SELECT * FROM T_Bllb_packageOne_tbpo WHERE CONTAINER_SN_1='{0}'", SerialNubmer);
            if (NMS.QueryDataTable(PubUtils.uContext, strSql).Rows.Count > 0)
            {
                strSql = string.Format(@"UPDATE T_Bllb_productInfo_tbpi SET AGING_END_TIME=GETDATE() WHERE TBPS_ID IN (SELECT TBPS_ID FROM T_Bllb_packageOne_tbpo WHERE CONTAINER_SN_1='{0}')", SerialNubmer);
            }
            else
            {
                strSql = string.Format(@"UPDATE T_Bllb_productInfo_tbpi SET AGING_END_TIME=GETDATE() WHERE SERIAL_NUMBER='{0}'", SerialNubmer);
            }
            return NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        /// <summary>
        /// 查询产品条码数据
        /// </summary>
        /// <returns></returns>
        public DataTable SelectSN(T_Bllb_productInfo_tbpi tbpi)
        {
            return t_Bllb_productInfo_tbpi_DAL.GetSN(tbpi);
        }
        /// <summary>
        /// 查询产品追溯基础数据
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable QueryBasicData(string strWhere)
        {
            return t_Bllb_productInfo_tbpi_DAL.GetBasicData(strWhere);
        }
        /// <summary>
        /// 查询最后过本工序的明细信息
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable SelectTBPI(string strWhere)
        {
            return t_Bllb_productInfo_tbpi_DAL.GetTBPI(strWhere);
        }

        /// <summary>
        /// 根据产品SN查找数据
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable SelectBySN(T_Bllb_productInfo_tbpi tbpi)
        {
            return t_Bllb_productInfo_tbpi_DAL.GetList(tbpi);
        }
        /// <summary>
        /// 根据产品SN查找检验单
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable SelectDocNoBySN(T_Bllb_productInfo_tbpi tbpi)
        {
            return t_Bllb_productInfo_tbpi_DAL.GetDocNoBySN(tbpi);
        }
     
        /// <summary>
        ///已检测产品SN查询检测项目数据
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable SelectCheckItem(string strWhere)
        {
            return t_Bllb_productInfo_tbpi_DAL.GetCheckItem(strWhere);
        }
        /// <summary>
        /// 维修查询中的查询产品基本信息
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public DataTable SelectProInfo(string strWhere)
        {
            return t_Bllb_productInfo_tbpi_DAL.GetProInfoList(strWhere);

        }
        /// <summary>
        /// 替换关键件日志查询
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable SelectreplaceKey(T_Bllb_productInfo_tbpi tbpi)
        {
            return t_Bllb_productInfo_tbpi_DAL.GetreplaceKeyList(tbpi);
        }
        /// <summary>
        /// 关键件SN日志选中单元格查询不良代码维修查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable SelecterrorRepair(string strWhere)
        {
            return t_Bllb_productInfo_tbpi_DAL.GeterrorRepair(strWhere);
        }
        /// <summary>
        /// 更新是否报废字段
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public bool Update(T_Bllb_productInfo_tbpi tbpi)
        {
            return t_Bllb_productInfo_tbpi_DAL.UpdateList(tbpi);
        }
        /// <summary>
        /// 查询产品SN是否已报废
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable SelectScrap(T_Bllb_productInfo_tbpi tbpi)
        {
            return t_Bllb_productInfo_tbpi_DAL.GetScrap(tbpi);
        }
        /// <summary>
        /// 通过连接查询获得数据（产品状态表和产品信息表进行连接，查找TBPS_ID,SfcNo）,通过产品条码进行过滤
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable Select(T_Bllb_productInfo_tbpi tbpi)
        {
            return t_Bllb_productInfo_tbpi_DAL.GetList(tbpi);
        }
        /// <summary>
        /// 查询（连接工单表和产品信息表，根据产品条码过滤）
        /// </summary>
        /// <param name="strWhere">连接表查询</param>
        /// <returns></returns>
        public DataTable QueryData(string strWhere)
        {
            return t_Bllb_productInfo_tbpi_DAL.Query(strWhere);
        }
        /// <summary>
        /// 通过产品条码，查询TBPI_ID
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable SelectBySerialNumber(T_Bllb_productInfo_tbpi tbpi)
        {
            return t_Bllb_productInfo_tbpi_DAL.GetBySerialNumber(tbpi);
        }
        /// <summary>
        /// 根据产品条码和制令单查询数据
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable SelectBySfcAndSN(T_Bllb_productInfo_tbpi tbpi)
        {
            return t_Bllb_productInfo_tbpi_DAL.GetBySfcAndSNr(tbpi);
        }
        /// <summary>
        /// 查询维修管理信息
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public DataTable SelectRepair(string strWhere)
        {
            return t_Bllb_productInfo_tbpi_DAL.GetRepair(strWhere);
        }
        /// <summary>
        /// 根据条件查询产品信息(单表)
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Select(string strWhere)
        {
            return t_Bllb_productInfo_tbpi_DAL.GetList(strWhere);
        }
        /// <summary>
        /// 更新产品信息是否报废字段为Y
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Update_SCRAP_FLAG(string strWhere)
        {
            return t_Bllb_productInfo_tbpi_DAL.Update_SCRAP_FLAG(strWhere);
        }
        /// <summary>
        /// 更新是否不良字段
        /// </summary>
        /// <param name="tbpi"></param>
        /// <returns></returns>
        public bool Update_ERROR_FLAG(T_Bllb_productInfo_tbpi tbpi)
        {
            return t_Bllb_productInfo_tbpi_DAL.Update_ERROR_FLAG(tbpi);
        }
    }
}
