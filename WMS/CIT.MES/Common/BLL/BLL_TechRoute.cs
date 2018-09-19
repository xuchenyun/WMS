
using CIT.MES;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class BLL_TechRoute
    {
        #region 通过制令单查询工艺，并获取工位信息
        /// <summary>
        /// 通过制令单和工位ID查询工艺，并获取首站信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetTechFirtstGroupInfo(string sfcno, string TBS_ID)
        {
            string strSql = string.Format(@"SELECT B.TBTG_ID,D.TBTG_ID AS WIP_TBTG_ID FROM  SfcDatProduct sfc
LEFT JOIN T_Bllb_techGroupStation_tbtgs B ON SFC.TBT_ID=B.TBT_ID
LEFT JOIN T_Bllb_station_tbs C ON C.TBS_ID=B.TBS_ID
LEFT JOIN T_Bllb_technologyGroup_tbtg A ON A.TBTG_ID=B.TBTG_ID
LEFT JOIN T_Bllb_techGroupRelation_tbtgr D ON D.F_TBTG_ID=B.TBTG_ID
WHERE sfc.SfcNO='{0}'  AND B.TBS_ID='{1}' AND A.INOUT_TYPE='0'", sfcno, TBS_ID);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        #endregion

        #region 获取返工/维修回流的工艺工序ID
        /// <summary>
        /// 获取返工/维修回流的工艺工序ID
        /// </summary>
        /// <param name="SerialNumber"></param>
        /// <returns></returns>
        public static string  GetNextRe_TBTG_ID(string SerialNumber,string TBS_ID,ref string msg)
        {
            string strSql = string.Format(@"SELECT RE_TBTG_ID,tbtgs.TBTG_ID  FROM 
T_Bllb_productInfo_tbpi tbbi left join t_bllb_productStatus_tbps tbps on tbbi.tbps_id=tbps.tbps_id
LEFT JOIN SfcDatProduct sfc on tbbi.sfcno=sfc.sfcno
left join T_Bllb_techGroupStation_tbtgs tbtgs on tbtgs.TBT_ID=sfc.TBT_ID
left join T_Bllb_station_tbs tbs on tbs.TBS_ID=tbtgs.TBS_ID
 where tbbi.last_flag='Y' and tbbi.serial_number='{0}' and tbs.TBS_ID='{1}'", SerialNumber, TBS_ID);
            DataTable dt = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
            if (dt.Rows.Count > 0)
            {
                string re_tbtg_id = SqlInput.ChangeNullToString(dt.Rows[0]["RE_TBTG_ID"]);
                if (re_tbtg_id != string.Empty & re_tbtg_id == SqlInput.ChangeNullToString(dt.Rows[0]["TBTG_ID"]))
                {
                    msg = "OK";
                    return re_tbtg_id;
                }
                else
                {
                    if(re_tbtg_id != string.Empty)
                    {
                        strSql = string.Format(@"SELECT TBG.GROUP_NAME FROM T_Bllb_technologyGroup_tbtg TBTG LEFT JOIN T_Bllb_group_tbg TBG ON TBG.TBG_ID=TBTG.TBG_ID WHERE TBTG.TBTG_ID='{0}'", re_tbtg_id);
                        DataTable dt_g = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
                        if (dt_g.Rows.Count > 0)
                        {
                            msg = "下一个工序为" + SqlInput.ChangeNullToString(dt_g.Rows[0][0]);

                        }              
                    }                   
                    return string.Empty;
                }             

            }
            else
            {
                msg = "工位不在产品工艺中";
                return string.Empty;
            }
        }
        /// <summary>
        ///  获取返工/维修回流的工艺工序ID
        /// </summary>
        /// <param name="TBPS_ID"></param>
        /// <param name="TBS_ID"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string GetNextRe_TBTG_ID_BY_TBPS_ID(string TBPS_ID, string TBS_ID, ref string msg)
        {
            string strSql = string.Format(@"SELECT tbps.RE_TBTG_ID,tbtgs.TBTG_ID  FROM 
T_Bllb_productInfo_tbpi tbbi left join t_bllb_productStatus_tbps tbps on tbbi.tbps_id=tbps.tbps_id
LEFT JOIN SfcDatProduct sfc on tbbi.sfcno=sfc.sfcno
left join T_Bllb_techGroupStation_tbtgs tbtgs on tbtgs.TBT_ID=sfc.TBT_ID
left join T_Bllb_station_tbs tbs on tbs.TBS_ID=tbtgs.TBS_ID
 where tbbi.last_flag='Y' and tbbi.TBPS_ID='{0}' and tbs.TBS_ID='{1}'", TBPS_ID, TBS_ID);
            DataTable dt = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
            if (dt.Rows.Count > 0)
            {
                string re_tbtg_id = SqlInput.ChangeNullToString(dt.Rows[0]["RE_TBTG_ID"]);
                if (re_tbtg_id != string.Empty & re_tbtg_id == SqlInput.ChangeNullToString(dt.Rows[0]["TBTG_ID"]))
                {
                    msg = "OK";
                    return re_tbtg_id;
                }
                else
                {
                    if (re_tbtg_id != string.Empty)
                    {
                        strSql = string.Format(@"SELECT TBG.GROUP_NAME FROM T_Bllb_technologyGroup_tbtg TBTG LEFT JOIN T_Bllb_group_tbg TBG ON TBG.TBG_ID=TBTG.TBG_ID WHERE TBTG.TBTG_ID='{0}'", re_tbtg_id);
                        DataTable dt_g = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
                        if (dt_g.Rows.Count > 0)
                        {
                            msg = "下一个工序为" + SqlInput.ChangeNullToString(dt_g.Rows[0][0]);

                        }
                    }
                    return string.Empty;
                }

            }
            else
            {
                msg = "工位不在产品工艺中";
                return string.Empty;
            }
        }
        #endregion
        #region 获取默认回流工序
        /// <summary>
        /// 获取默认回流工序
        /// </summary>
        /// <param name="productSN">产品SN</param>
        /// <returns></returns>
        public static DataTable GetListofRebackGroup(string productSN)
        {
            DataTable dt_SN = QueryProductSN(productSN);
            if (dt_SN.Rows.Count == 0)
                return null;
            string TBPS_ID = dt_SN.Rows[0]["TBPS_ID"].ToString();
            //获取工位ID对应的工艺工序ID
            //DataTable dt_TBTG_ID = QueryTechGroup(dt_SN.Rows[0]["TBT_ID"].ToString(), TBTG_ID);
            //if (dt_TBTG_ID.Rows.Count == 0)//工位不在当前产品所在的工艺中
            //{
            //    return null;
            //}
            //寻找维修的工艺工序ID的父级工艺工序信息
            string strSql = string.Format(@"SELECT C.TBTG_ID,C_TBG.GROUP_NAME FROM T_Bllb_productStatus_tbps T
LEFT JOIN T_Bllb_techGroupRelation_tbtgr B ON T.TBTG_ID=B.F_TBTG_ID
 LEFT JOIN T_Bllb_technologyGroup_tbtg TB ON B.TBTG_ID=TB.TBTG_ID
  LEFT JOIN T_Bllb_group_tbg TBG ON TBG.TBG_ID=TB.TBG_ID 
  LEFT JOIN T_Bllb_techGroupRelation_tbtgr C ON B.TBTG_ID=C.F_TBTG_ID
   LEFT JOIN T_Bllb_technologyGroup_tbtg C_TB ON C.TBTG_ID=C_TB.TBTG_ID
  LEFT JOIN T_Bllb_group_tbg C_TBG ON C_TBG.TBG_ID=C_TB.TBG_ID WHERE T.TBPS_ID='{0}' AND TBG.GROUP_TYPE='1'", TBPS_ID);
            DataTable dt = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
            if (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
            {
                return dt;
            }
            strSql = string.Format(@"SELECT T.TBTG_ID,TBG.GROUP_NAME FROM T_Bllb_productStatus_tbps T LEFT JOIN T_Bllb_technologyGroup_tbtg TB ON T.TBTG_ID=TB.TBTG_ID
  LEFT JOIN T_Bllb_group_tbg TBG ON TBG.TBG_ID=TB.TBG_ID WHERE T.TBPS_ID='{0}'", TBPS_ID);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        #endregion
        #region 回流到指定工序的数据源
        /// <summary>
        /// 回流到指定工序的数据源
        /// </summary>
        /// <param name="TBTG_ID">工艺工序ID</param>
        /// <param name="productSN">产品SN</param>
        /// <returns></returns>
        public static DataTable GetListofRebackOldGroup(string TBTG_ID, string productSN)
        {
            DataTable dt_SN = QueryProductSN(productSN);
            if (dt_SN.Rows.Count == 0)
                return null;
            DataTable dt_OldGroup = new DataTable();
            dt_OldGroup.Columns.Add("TBTG_ID");
            dt_OldGroup.Columns.Add("GROUP_NAME");
            DataTable dt_Route = GetListofRoute(dt_SN.Rows[0]["TBT_ID"].ToString());
            DataRow[] drs = dt_Route.Select();
            DataRow[] drs_TBS= dt_Route.Select(string.Format("TBTG_ID='{0}'", TBTG_ID));
            if (drs_TBS.Length == 0)
                return null;
            else
            {
                GetFatherGroup(drs_TBS[0]["TBTG_ID"].ToString(), drs, ref dt_OldGroup);
                //判断是否有目检工艺

                return dt_OldGroup;
            }

        }
        #endregion
        #region 获取指定工序数据源
        /// <summary>
        /// 获取指定工序数据源
        /// </summary>
        /// <param name="TBTG_ID"></param>
        /// <param name="drs"></param>
        /// <param name="dt_OldGroup"></param>
        private static void GetFatherGroup(string TBTG_ID, DataRow[] drs,ref DataTable dt_OldGroup)
        {
            string return_Info = string.Empty;
            foreach (DataRow dr in drs)//循环工艺工序关系信息（正常工序）
            {
                if (dr["TBTG_ID"].ToString() == TBTG_ID)//判断关系中子级工序ID是否为所要查询的
                {
                    if (dt_OldGroup.Select(string.Format("TBTG_ID='{0}'", TBTG_ID)).Length > 0)
                    {
                        return;
                    }
                    if (dr["GROUP_TYPE"].ToString() == "0")
                    {
                        DataRow dr_oldGroup = dt_OldGroup.NewRow();
                        dr_oldGroup["TBTG_ID"] = dr["TBTG_ID"];
                        dr_oldGroup["GROUP_NAME"] = dr["GROUP_NAME"];
                        dt_OldGroup.Rows.Add(dr_oldGroup);
                        GetFatherGroup(dr["F_TBTG_ID"].ToString(), drs, ref dt_OldGroup);
                    }   
                    else
                    {
                        continue;
                    }                
                
                }
            }
      
        }
        #endregion
        #region 流程校验
        /// <summary>
        /// 流程校验
        /// </summary>
        /// <param name="serial_Number"></param>
        /// <param name="TBS_ID"></param>
        /// <returns></returns>
        public static string CheckRoute(string serial_Number, string TBS_ID,ref string TBTG_ID)
        {
            string msg = string.Empty;//返回信息
            string TBT_ID = string.Empty;//工艺ID
            bool is_error = false;
            string F_TBTG_ID = string.Empty;//产品最后过的工艺工序ID
            DataTable dt_Product = QueryProductSN(serial_Number);
            if (dt_Product.Rows.Count > 0)//已投产的产品（在制品）
            {
                #region 已投产的产品
                //if (SqlInput.ChangeNullToString(dt_Product.Rows[0]["OVER_FLAG"]) == "Y")
                //{
                //    msg = "产品已流程结束";
                //    return msg;
                //}
                TBT_ID = SqlInput.ChangeNullToString(dt_Product.Rows[0]["TBT_ID"]);//工艺ID
                if (TBT_ID == string.Empty)
                {
                    msg = "制令单未配置工艺";
                    return msg;
                }
                F_TBTG_ID = dt_Product.Rows[0]["TBTG_ID"].ToString();//产品最后过的工艺工序ID
                if (dt_Product.Rows[0]["ERROR_FLAG"].ToString() == "Y")
                {
                    is_error = true;
                }
                //获取工位ID对应的工艺工序ID
                DataTable dt_TBTG_ID = QueryTechGroup(TBT_ID, TBS_ID);
                if (dt_TBTG_ID.Rows.Count == 0)
                {
                    msg = "工位不在当前产品所在的工艺中";
                    return msg;
                }
                //流程校验
                msg = CheckRoute(TBT_ID, F_TBTG_ID, TBS_ID, is_error, ref TBTG_ID);
                if (msg != "OK")
                {
                    return msg;
                }
                return "OK";
                #endregion
            }
            else
            {                
                 return "非首站不能进行产品投入";               
            }
          
        }
        /// <summary>
        /// 流程校验
        /// </summary>
        /// <param name="serial_Number"></param>
        /// <param name="TBS_ID"></param>
        /// <returns></returns>
        public static string CheckRoute(string serial_Number, string TBS_ID, ref string TBTG_ID,ref string WIP_TBTG_ID)
        {
            string msg = string.Empty;//返回信息
            string TBT_ID = string.Empty;//工艺ID
            bool is_error = false;
            string F_TBTG_ID = string.Empty;//产品最后过的工艺工序ID
            DataTable dt_Product = QueryProductSN(serial_Number);
            if (dt_Product.Rows.Count > 0)//已投产的产品（在制品）
            {
                #region 已投产的产品
                //if (SqlInput.ChangeNullToString(dt_Product.Rows[0]["OVER_FLAG"]) == "Y")
                //{
                //    msg = "产品已流程结束";
                //    return msg;
                //}
                TBT_ID = SqlInput.ChangeNullToString(dt_Product.Rows[0]["TBT_ID"]);//工艺ID
                if (TBT_ID == string.Empty)
                {
                    msg = "制令单未配置工艺";
                    return msg;
                }
                F_TBTG_ID = dt_Product.Rows[0]["TBTG_ID"].ToString();//产品最后过的工艺工序ID
                if (dt_Product.Rows[0]["ERROR_FLAG"].ToString() == "Y")
                {
                    is_error = true;
                }
                //获取工位ID对应的工艺工序ID
                DataTable dt_TBTG_ID = QueryTechGroup(TBT_ID, TBS_ID);
                if (dt_TBTG_ID.Rows.Count == 0)
                {
                    msg = "工位不在当前产品所在的工艺中";
                    return msg;
                }
                //流程校验
                //msg = CheckRoute(TBT_ID, F_TBTG_ID, TBS_ID, is_error, ref TBTG_ID);
                msg = CheckRoute(TBT_ID, F_TBTG_ID, TBS_ID, is_error, ref TBTG_ID,ref WIP_TBTG_ID);
                if (msg != "OK")
                {
                    return msg;
                }
                return "OK";
                #endregion
            }
            else
            {
                return "非首站不能进行产品投入";
            }

        }
        #endregion
        #region 查询产品SN
        /// <summary>
        /// 查询产品SN
        /// </summary>
        /// <param name="productSN"></param>
        /// <returns></returns>
        public static DataTable QueryProductSN(string productSN)
        {
            string strSql = string.Format(@"SELECT P.TBT_ID,T.SFCNO,P.WOCODE,P.Product,T.TBPS_ID,T.ONCE_OVER_FLAG,T.OVER_FLAG,TBPS.TBTG_ID,T.ERROR_FLAG 
FROM T_Bllb_productInfo_tbpi T LEFT JOIN SfcDatProduct P ON T.SFCNO=P.SFCNO LEFT JOIN T_Bllb_productStatus_tbps TBPS ON T.TBPS_ID=TBPS.TBPS_ID 
WHERE T.SERIAL_NUMBER='{0}' AND T.LAST_FLAG='Y'", productSN);
            DataTable dt = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
            return dt;
        }
        #endregion
        #region 获取工艺流程信息（工艺工序关系信息）
        /// <summary>
        /// 获取工艺流程信息（工艺工序关系信息）
        /// </summary>
        /// <param name="TBT_ID">工艺ID</param>
        /// <returns></returns>
        public static DataTable GetListofRoute(string TBT_ID)
        {
            //获取当前产品的下一个工序（可能有多个，0正常、1维修）
            string strSql = string.Format(@"SELECT R.F_TBTG_ID,R.TBTGR_ID,R.TBTG_ID,G.ISMUSTPASS,G.GROUP_TYPE,TBG.GROUP_NAME,TGS.TBS_ID
 FROM T_Bllb_techGroupRelation_tbtgr R LEFT JOIN T_Bllb_technologyGroup_tbtg G ON R.TBTG_ID=G.TBTG_ID
LEFT JOIN T_Bllb_group_tbg TBG ON TBG.TBG_ID=G.TBG_ID
LEFT JOIN T_Bllb_techGroupStation_tbtgs TGS ON TGS.TBTG_ID=G.TBTG_ID WHERE R.TBT_ID='{0}'", TBT_ID);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        #endregion
        #region 查询工位所在工艺工序信息
        /// <summary>
        /// 查询工位所在工艺工序信息
        /// </summary>
        /// <param name="TBT_ID"></param>
        /// <param name="TBG_ID"></param>
        /// <returns></returns>
        public static DataTable QueryTechGroup(string TBT_ID, string TBS_ID)
        {
            string strSql = string.Format(@"SELECT T.INOUT_TYPE,T.ISMUSTPASS,T.GROUP_TYPE,T.TBTG_ID,T.QA_FLAG
FROM T_Bllb_technologyGroup_tbtg T LEFT JOIN T_Bllb_techGroupStation_tbtgs S
ON T.TBTG_ID=S.TBTG_ID WHERE T.TBT_ID='{0}' AND S.TBS_ID='{1}'", TBT_ID, TBS_ID);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);

        }
        #endregion
        #region 工艺流程校验
        /// <summary>
        /// 工艺流程校验
        /// </summary>
        /// <param name="TBT_ID"></param>
        /// <param name="F_TBTG_ID"></param>
        /// <param name="TBS_ID"></param>
        /// <param name="errorFlag"></param>
        /// <returns></returns>
        public static string CheckRoute(string TBT_ID, string F_TBTG_ID, string TBS_ID, bool errorFlag,ref string  next_TBTG_ID)
        {
            //获取当前产品的下一个工序（可能有多个，0正常、1维修）
            string GROUP_TYPE = errorFlag == true ? "1" : "0";
            DataTable dt_Route = GetListofRoute(TBT_ID);
            string next_GroupName = string.Empty;
            DataRow[] drs_tbtg_id = dt_Route.Select(string.Format("TBS_ID='{0}'", TBS_ID));
            #region 遍历查询下一个工序（比如：有时需要两个或者多个相同的维修工序，其中有些需要默认回流，有些需要指定回流）
            string str_tbtg_id = string.Empty;
            foreach (DataRow dr_tbtg_id in drs_tbtg_id)//获取工位所在的工艺工序ID，（相同工序名称，不同工艺工序ID）
            {
                str_tbtg_id += "[" + dr_tbtg_id["TBTG_ID"].ToString() + "]";
            }
            #endregion
            //string str_tbtg_id = drs_tbtg_id[0]["TBTG_ID"].ToString();
            if (errorFlag == true)
            {
                DataRow[] drs = dt_Route.Select(string.Format("F_TBTG_ID='{0}' AND GROUP_TYPE='{1}'", F_TBTG_ID, GROUP_TYPE));
                //判断当前要过的工艺工序是否是正确
                foreach (DataRow dr in drs)
                {
                    if (!str_tbtg_id.Contains("[" + dr["TBTG_ID"].ToString() + "]"))//若是工艺工序ID属于当前工位对应的工艺工序ID，则说明流程正确
                    {
                        next_GroupName += "【" + dr["GROUP_NAME"] + "】";
                    }
                    else
                    {
                        next_TBTG_ID = dr["TBTG_ID"].ToString();

                        return "OK";
                    }
                }
                if (next_GroupName == string.Empty)
                {
                    return string.Format("本产品找不到下一个工序");
                }
                else
                {
                    return string.Format("本产品下一个工序为{0}", next_GroupName);
                }     

            }
            else
            {
                DataRow[] drs = dt_Route.Select(string.Format("GROUP_TYPE='{0}'", GROUP_TYPE));//获取非维修工序
                next_GroupName += GetNextGroup(F_TBTG_ID, str_tbtg_id, drs,ref next_TBTG_ID);
            }
            if (next_GroupName.Contains("OK") == true)
            {
                return "OK";
            }
            else
            {
                if (next_GroupName == string.Empty)
                {
                    return string.Format("本产品找不到下一个工序");
                }
                return string.Format("本产品下一个工序为{0}", next_GroupName);
            }

        }
        /// <summary>
        /// 工艺流程校验
        /// </summary>
        /// <param name="TBT_ID"></param>
        /// <param name="F_TBTG_ID"></param>
        /// <param name="TBS_ID"></param>
        /// <param name="errorFlag"></param>
        /// <returns></returns>
        public static string CheckRoute(string TBT_ID, string F_TBTG_ID, string TBS_ID, bool errorFlag, ref string next_TBTG_ID,ref string wip_tbtg_id)
        {
            //获取当前产品的下一个工序（可能有多个，0正常、1维修）
            string GROUP_TYPE = errorFlag == true ? "1" : "0";
            DataTable dt_Route = GetListofRoute(TBT_ID);
            string next_GroupName = string.Empty;
            DataRow[] drs_tbtg_id = dt_Route.Select(string.Format("TBS_ID='{0}'", TBS_ID));
            #region 遍历查询下一个工序（比如：有时需要两个或者多个相同的维修工序，其中有些需要默认回流，有些需要指定回流）
            string str_tbtg_id = string.Empty;
            foreach (DataRow dr_tbtg_id in drs_tbtg_id)//获取工位所在的工艺工序ID，（相同工序名称，不同工艺工序ID）
            {
                if (!str_tbtg_id.Contains("[" + dr_tbtg_id["TBTG_ID"].ToString() + "]"))
                    str_tbtg_id += "[" + dr_tbtg_id["TBTG_ID"].ToString() + "]";
            }
            #endregion
            //string str_tbtg_id = drs_tbtg_id[0]["TBTG_ID"].ToString();
            if (errorFlag == true)
            {
                DataRow[] drs = dt_Route.Select(string.Format("F_TBTG_ID='{0}' AND GROUP_TYPE='{1}'", F_TBTG_ID, GROUP_TYPE));
                //判断当前要过的工艺工序是否是正确
                foreach (DataRow dr in drs)
                {
                    if (!str_tbtg_id.Contains("[" + dr["TBTG_ID"].ToString() + "]"))//若是工艺工序ID属于当前工位对应的工艺工序ID，则说明流程正确
                    {
                        if (!next_GroupName.Contains("【" + dr["GROUP_NAME"] + "】"))
                            next_GroupName += "【" + dr["GROUP_NAME"] + "】";
                    }
                    else
                    {
                        next_TBTG_ID = dr["TBTG_ID"].ToString();
                        return "OK";
                    }
                }
                if (next_GroupName == string.Empty)
                {
                    return string.Format("本产品找不到下一个工序");
                }
                else
                {
                    return string.Format("本产品下一个工序为{0}", next_GroupName);
                }

            }
            else
            {
                DataRow[] drs = dt_Route.Select(string.Format("GROUP_TYPE='{0}'", GROUP_TYPE));//获取非维修工序
                next_GroupName += GetNextGroup(F_TBTG_ID, str_tbtg_id, drs, ref next_TBTG_ID);
                wip_tbtg_id = GetNextTechGroupID(str_tbtg_id, drs);//wip工艺工序ID
            }
            if (next_GroupName.Contains("OK") == true)
            {
                return "OK";
            }
            else
            {
                if (next_GroupName == string.Empty)
                {
                    return string.Format("本产品找不到下一个工序");
                }
                return string.Format("本产品下一个工序为{0}", next_GroupName);
            }

        }
        #endregion
        #region 获取下一个工序（自循环）
        /// <summary>
        /// 获取下一个工序（自循环）
        /// </summary>
        /// <param name="F_TBTG_ID">父级工艺工序ID</param>
        /// <param name="TBTG_ID">工艺工序ID</param>
        /// <param name="drs"></param>
        /// <returns></returns>
        public static string GetNextGroup(string F_TBTG_ID, string TBTG_ID, DataRow[] drs,ref string next_TBTG_ID)
        {
            string return_Info = string.Empty;
            foreach (DataRow dr in drs)//循环工艺工序关系信息（正常工序）
            {
                if (dr["F_TBTG_ID"].ToString() == F_TBTG_ID)//判断关系中父级工序ID是否为所要查询的
                {
                    if (TBTG_ID.Contains("[" + dr["TBTG_ID"].ToString() + "]"))//若是工艺工序ID属于当前工位对应的工艺工序ID，则说明流程正确
                    {
                        next_TBTG_ID = dr["TBTG_ID"].ToString();
                        return "【OK】";
                    }
                    else if (dr["ISMUSTPASS"].ToString() == "N")//判断是否为非必过工序
                    {
                        return_Info += "【" + dr["GROUP_NAME"].ToString() + "】";
                        return_Info += GetNextGroup(dr["TBTG_ID"].ToString(), TBTG_ID, drs,ref next_TBTG_ID);
                        break;
                    }
                    else if (dr["ISMUSTPASS"].ToString() == "Y")//若是比过工序，并且工位ID不属于这个工序，则提示产品下一个工序
                    {
                        return_Info += "【" + dr["GROUP_NAME"].ToString() + "】";
                        return return_Info;
                    }
                }


            }
            return return_Info;
        }
        #endregion
        #region 获取下个工艺工序ID
        /// <summary>
        /// 获取下一个工艺工序ID
        /// </summary>
        /// <param name="F_TBTG_ID"></param>
        /// <param name="drs">工艺工序集合</param>
        /// <returns></returns>
        public static string GetNextTechGroupID(string F_TBTG_ID, DataRow[] drs)
        {
            string return_Info = string.Empty;          
            foreach (DataRow dr in drs)//循环工艺工序关系信息（正常工序）
            {
                if ("["+dr["F_TBTG_ID"].ToString()+"]" == F_TBTG_ID)//判断关系中父级工序ID是否为所要查询的
                {
                    return dr["TBTG_ID"].ToString();
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// 获取下一个工艺工序ID
        /// </summary>
        /// <param name="F_TBTG_ID">父级工艺工序ID</param>
        /// <param name="isNormalGroup">是否为未正常工序（非维修工序）</param>
        /// <returns></returns>
        public static string GetNextTechGroupID(string F_TBTG_ID,bool isNormalGroup)
        {
            string strSql = string.Format(@"SELECT A.TBTG_ID FROM T_Bllb_techGroupRelation_tbtgr A LEFT JOIN T_Bllb_technologyGroup_tbtg B ON A.F_TBTG_ID=B.TBTG_ID
LEFT JOIN T_Bllb_group_tbg C ON B.TBG_ID=C.TBG_ID
 WHERE  A.TBTG_ID='{0}' AND  C.GROUP_TYPE='{1}'",F_TBTG_ID,isNormalGroup==true?"0":"1");
            DataTable dt = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
            if(dt.Rows.Count>0)
            {
                return SqlInput.ChangeNullToString(dt.Rows[0][0]);
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion
    }
}
