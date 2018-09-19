using CIT.MES;
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
    public class BLL_Save_Pass_SN
    {

        #region 产品过站
        /// <summary>
        /// 产品过站
        /// </summary>
        /// <param name="serialNumber">小板条码</param>
        /// <param name="TBS_ID">工位ID</param>
        /// <param name="TBTG_ID">工艺工序ID</param>
        /// <param name="lst_error">不良代码</param>
        /// <param name="msg">返回信息</param>
        /// <returns></returns>
        public static bool PassGroup(string sfcNo, string serialNumber, string TBS_ID, string TBTG_ID, string WIP_TBTG_ID, List<string> lst_error, ref string msg)
        {
            //获取TBPS_ID(产品状态ID)、TBG_ID(工序ID)、PLCODE(线别代码)
            //string UseId = PubUtils.uContext.UserID;//员工号
            //string UseId = UserID;//员工号
            bool newInput = false;//是否新投入的产品  
            string TBPS_ID = string.Empty;//产品状态ID(在产品信息表中不是唯一)
            string once_Over_Flag = string.Empty;//是否曾经流程结束（Y/N）（针对流程结束又原单返工情况）
            string TBT_ID = string.Empty;//工艺ID
            string PLCode = string.Empty;//线别代码  
            #region 查询产品信息
            DataTable dt_Product = BLL_Save_Pass_SN.QueryProductSN(serialNumber);//查询产品信息
            if (dt_Product.Rows.Count == 0)
            {
                newInput = true;
                BLL_SfcDatProduct bll = new BLL_SfcDatProduct();
                SfcDatProduct sfcDatPro = new SfcDatProduct();
                sfcDatPro.SfcNo = sfcNo;
                DataTable dt_sfcno= bll.SelectProBySfcno(sfcDatPro);
                if(dt_sfcno.Rows.Count>0)
                {
                    TBT_ID = dt_sfcno.Rows[0]["TBT_ID"].ToString();
                    PLCode = dt_sfcno.Rows[0]["Line"].ToString();
                }
                else
                {
                    msg = "制令单不存在";
                    return false;
                }
            }
            else
            {
                sfcNo = dt_Product.Rows[0]["SFCNO"].ToString();//制令单       
                TBPS_ID = dt_Product.Rows[0]["TBPS_ID"].ToString();//产品状态ID(在产品信息表中不是唯一)
                once_Over_Flag = dt_Product.Rows[0]["ONCE_OVER_FLAG"].ToString();//是否曾经流程结束（Y/N）（针对流程结束又原单返工情况）
                TBT_ID = dt_Product.Rows[0]["TBT_ID"].ToString();//工艺ID
                PLCode = SqlInput.ChangeNullToString(dt_Product.Rows[0]["LINE"]);//线别代码
            }

            #endregion
            #region 工艺信息
            string TBG_ID = string.Empty;//工序ID
               
            string inout_Type = string.Empty;//工艺工序类型
            //string TBTG_ID = string.Empty;//工艺工序ID
            //获取工艺工序ID对应的工艺工序信息
            DataTable dt_TBTG_ID = BLL_Save_Pass_SN.QueryTechGroup(TBT_ID, TBTG_ID);
            if (dt_TBTG_ID.Rows.Count == 0)
            {
                msg = "工位不在当前产品所在的工艺中";
                return false;
            }
            else
            {
                inout_Type = SqlInput.ChangeNullToString(dt_TBTG_ID.Rows[0]["INOUT_TYPE"]);//投入产出标识
                //TBTG_ID = SqlInput.ChangeNullToString(dt_TBTG_ID.Rows[0]["TBTG_ID"]);//工艺工序ID

                TBG_ID = SqlInput.ChangeNullToString(dt_TBTG_ID.Rows[0]["TBG_ID"]);//工序ID
            }
            #endregion
            #region 新增/修改产品状态信息表
            //1.1、新增/修改产品状态信息表
            Model_Bllb_productStatus_tbps obj_Status = new Model_Bllb_productStatus_tbps();
            obj_Status.PLCode = PLCode;//线别代码
            obj_Status.SfcNo = sfcNo;//制令单
            obj_Status.TBTG_ID = TBTG_ID;//工艺工序ID
            obj_Status.WIP_TBTG_ID = WIP_TBTG_ID;//下一个工艺工序ID
            if (newInput == true)//新投入产品
            {
                obj_Status.TBPS_ID = Guid.NewGuid().ToString();//产品状态ID
                TBPS_ID = obj_Status.TBPS_ID;
                BLL_Save_Pass_SN.InsertProductStatus(obj_Status);//新增产品状态信息
            }
            else//在制品
            {
                obj_Status.TBPS_ID = TBPS_ID;//产品状态ID
                BLL_Save_Pass_SN.UpdateProductStatus(obj_Status);
            }
            #endregion
            #region 过站记录
            Model.Model_Bllb_productPass_tbpp obj_Pass = new Model.Model_Bllb_productPass_tbpp();
            obj_Pass.TBG_ID = TBG_ID;//工序ID
            obj_Pass.TBPP_ID = Guid.NewGuid().ToString();//过站记录ID
            obj_Pass.TBPS_ID = TBPS_ID;//产品状态ID
            obj_Pass.PLCode = PLCode;//线别代码
            //1.2、添加产品过站记录表
            if (lst_error!=null & lst_error.Count > 0)
            {
                obj_Pass.STATE_FLAG = "1";//不良品
                BLL_Save_Pass_SN.InsertProductPass(obj_Pass);//不良品过站记录
                foreach (string str_TBEC_ID in lst_error)
                {
                    //1.3、添加不良信息
                    Model.Model_Bllb_productError_tbpe obj_pe = new Model.Model_Bllb_productError_tbpe();
                    obj_pe.ERROR_MAN = PubUtils.uContext.UserID;//打不良人
                    obj_pe.TBEC_ID = str_TBEC_ID;//不良代码ID
                    obj_pe.TBPE_ID = Guid.NewGuid().ToString();//不良记录ID
                    obj_pe.TBPS_ID = TBPS_ID;//产品状态ID
                    obj_pe.TBS_ID = TBS_ID;//工位ID
                    obj_pe.TBG_ID = TBG_ID;//工序ID
                    BLL_Save_Pass_SN.InsertProductError(obj_pe);
                }
                //1.4、产品标识为不良
                BLL_Save_Pass_SN.UpdateErrorFlag(serialNumber);//产品标识为不良
            }
            else
            {
                obj_Pass.STATE_FLAG = "0";//良品
                BLL_Save_Pass_SN.InsertProductPass(obj_Pass);//良品过站记录
            }
            //1.4、新增产品信息
            Model.Model_Bllb_productInfo_tbpi obj_Info = new Model.Model_Bllb_productInfo_tbpi();
            obj_Info.QTY = 1;//数量
            obj_Info.SERIAL_NUMBER = serialNumber;//产品SN
            if (lst_error != null & lst_error.Count > 0)
            {
                obj_Info.ERROR_FLAG = "Y";//是否不良
            }
            else
            {
                obj_Info.ERROR_FLAG = "N";//是否不良
            }
            obj_Info.LAST_FLAG = "Y";//是否最新记录
            obj_Info.OVER_FLAG = "N";//是否流程结束
            obj_Info.REPAIR_FLAG = "N";//是否维修过
            obj_Info.SCRAP_FLAG = "N";//是否报废
            obj_Info.ONCE_OVER_FLAG = "N";//是否曾经流程结束过（是针对原单返工的情况）
            obj_Info.SfcNo = sfcNo;//制令单
            obj_Info.TBPI_ID = Guid.NewGuid().ToString();//唯一码
            obj_Info.TBPS_ID = TBPS_ID;//产品状态ID
            if (inout_Type == "0" || inout_Type == "3")//主线投入或者主线投入产出标识
            {
                obj_Info.AUXILIARY_FLAG = "N";
            }
            else if (inout_Type == "2")//辅助线投入
            {
                obj_Info.SERIAL_NUMBER = string.Empty;
                obj_Info.AUXILIARY_FLAG = "Y";
            }
            else if (inout_Type == "1")//产出工序
            {
                if (lst_error != null & lst_error.Count > 0)//是否不良
                {
                    obj_Info.OVER_FLAG = "N";//是否流程结束
                    obj_Info.ONCE_OVER_FLAG = once_Over_Flag;//是否曾经流程结束（Y/N）（针对流程结束又原单返工情况）
                }
                else
                {
                    obj_Info.OVER_FLAG = "Y";//是否流程结束
                    obj_Info.ONCE_OVER_FLAG = "Y";//是否曾经流程结束（Y/N）（针对流程结束又原单返工情况）
                }
            }
            if (inout_Type == "0")//投入工序(注意考虑回流情况)
            {
                if (newInput == true)//新投入产品
                {
                    //1.4、新增产品信息                   
                    BLL_Save_Pass_SN.InsertProdcutInfo(obj_Info);
                }
            }
            else if (inout_Type == "1")//1:产出工序
            {
                //1.4、修改产品信息表()
                BLL_Save_Pass_SN.UpdateOverTech(obj_Info);//新增产品信息
                if (once_Over_Flag == "N" || obj_Info.ERROR_FLAG == "N")//是否是流程结束后又原单返工
                {
                    //1.5、修改制令单的产出数（是否流程结束过，若是则不增加制令单产出数）（注意流程结束后隔天返工情况）
                    BLL_Save_Pass_SN.UpdateSfcNo_ActQty(sfcNo, 1);
                }
            }
            else if (inout_Type == "2")//辅助投入工序
            {
                //1.4、修改产品信息表
                if (newInput == true)//新投入产品
                {
                    BLL_Save_Pass_SN.InsertProdcutInfo(obj_Info);//辅助投入时，产品SN设置为空，可用于验证辅助产品是否被组合到主线产品上，为空是还没被组合，组合后为空的辅助产品条码赋值为主线产品条码
                }
            }
            else if (inout_Type == "3")//投入产出工序
            {
                //1.4、新增产品信息表
                if (newInput == true)//新投入产品
                {
                    BLL_Save_Pass_SN.InsertProdcutInfo(obj_Info);
                }
                if (once_Over_Flag == "N")//是否是流程结束后又原单返工
                {
                    //1.5、修改制令单的产出数（是否流程结束过，若是则不增加制令单产出数）（注意流程结束后隔天返工情况）
                    BLL_Save_Pass_SN.UpdateSfcNo_ActQty(sfcNo, 1);
                }
            }
            #endregion
            //if (lst_error.Count == 0)
            //{
            //    BLL_Save_Pass_SN.AUTO_QA();
            //}

            #region 数据统计
            Model_Bllb_groupStatistics_tbgs obj = new Model_Bllb_groupStatistics_tbgs();
            if (lst_error != null & lst_error.Count > 0)
            {
                obj.ERROR_NUM = 1;//打不良次数
            }
            else
            {
                obj.ERROR_NUM = 0;//打不良次数
            }
            obj.PASS_NUM = 1;//过站次数
            obj.SfcNo = sfcNo;//制令单
            obj.TBTG_ID = TBTG_ID;//工艺工序ID
            InsertOrUpdateGroupStatistics(obj);//统计过站次数和打不良次数
            if(WIP_TBTG_ID!=string.Empty)//下一个工序的统计信息
            {
                obj.PASS_NUM = 0;
                obj.TBTG_ID = WIP_TBTG_ID;
                obj.ERROR_NUM = 0;
                InsertOrUpdateWipGroupStatistics(obj);//判断下一个工序是否有统计数据，若是没有则新增一个
            }
            #endregion
            return true;
        }
        #endregion
        #region 产品过站
        /// <summary>
        /// 产品过站
        /// </summary>
        /// <param name="serialNumber">小板条码</param>
        /// <param name="TBS_ID">工位ID</param>
        /// <param name="TBTG_ID">工艺工序ID</param>
        /// <param name="lst_error">不良代码</param>
        /// <param name="msg">返回信息</param>
        /// <returns></returns>
        public static bool PassGroup(string serialNumber,string TBS_ID,string TBTG_ID, List<string> lst_error,ref string msg)
        {
            //获取TBPS_ID(产品状态ID)、TBG_ID(工序ID)、PLCODE(线别代码)
            string UseId = PubUtils.uContext.UserID;//员工号
            bool newInput = false;//是否新投入的产品

            #region 查询产品信息
            DataTable dt_Product = BLL_Save_Pass_SN.QueryProductSN(serialNumber);//查询产品信息
            if (dt_Product.Rows.Count == 0)
            {
                msg = "不存在条码"+serialNumber;
                return false;
            }
            string sfcNo = dt_Product.Rows[0]["SFCNO"].ToString();//制令单       
            string TBPS_ID = dt_Product.Rows[0]["TBPS_ID"].ToString();//产品状态ID(在产品信息表中不是唯一)
            string once_Over_Flag = dt_Product.Rows[0]["ONCE_OVER_FLAG"].ToString();//是否曾经流程结束（Y/N）（针对流程结束又原单返工情况）
            string TBT_ID = dt_Product.Rows[0]["TBT_ID"].ToString();//工艺ID
            string PLCode = SqlInput.ChangeNullToString(dt_Product.Rows[0]["LINE"]);//线别代码

            #endregion
            #region 工艺信息
            string TBG_ID = string.Empty;//工序ID
            string inout_Type = string.Empty;//工艺工序类型
            //string TBTG_ID = string.Empty;//工艺工序ID
            //获取工艺工序ID对应的工艺工序信息
            DataTable dt_TBTG_ID = BLL_Save_Pass_SN.QueryTechGroup(TBT_ID, TBTG_ID);
            if (dt_TBTG_ID.Rows.Count == 0)
            {
                msg = "工位不在当前产品所在的工艺中";
                return false;
            }
            else
            {
                inout_Type = SqlInput.ChangeNullToString(dt_TBTG_ID.Rows[0]["INOUT_TYPE"]);//投入产出标识
                //TBTG_ID = SqlInput.ChangeNullToString(dt_TBTG_ID.Rows[0]["TBTG_ID"]);//工艺工序ID
                TBG_ID = SqlInput.ChangeNullToString(dt_TBTG_ID.Rows[0]["TBG_ID"]);//工序ID
            }
            #endregion
            #region 新增/修改产品状态信息表
            //1.1、新增/修改产品状态信息表
            Model_Bllb_productStatus_tbps obj_Status = new Model_Bllb_productStatus_tbps();
            obj_Status.PLCode = PLCode;//线别代码
            obj_Status.SfcNo = sfcNo;//制令单
            obj_Status.TBTG_ID = TBTG_ID;//工艺工序ID
            if (newInput == true)//新投入产品
            {
                obj_Status.TBPS_ID = Guid.NewGuid().ToString();//产品状态ID
                TBPS_ID= obj_Status.TBPS_ID;
                BLL_Save_Pass_SN.InsertProductStatus(obj_Status);//新增产品状态信息
            }
            else//在制品
            {
                obj_Status.TBPS_ID = TBPS_ID;//产品状态ID
                BLL_Save_Pass_SN.UpdateProductStatus(obj_Status);
            }
            #endregion
            #region 过站记录
            Model.Model_Bllb_productPass_tbpp obj_Pass = new Model.Model_Bllb_productPass_tbpp();
            obj_Pass.TBG_ID = TBG_ID;//工序ID
            obj_Pass.TBPP_ID = Guid.NewGuid().ToString();//过站记录ID
            obj_Pass.TBPS_ID = TBPS_ID;//产品状态ID
            obj_Pass.PLCode = PLCode;//线别代码
            //1.2、添加产品过站记录表
            if (lst_error.Count > 0)
            {
                obj_Pass.STATE_FLAG = "1";//不良品
                BLL_Save_Pass_SN.InsertProductPass(obj_Pass);//不良品过站记录
                foreach (string str_TBEC_ID in lst_error)
                {
                    //1.3、添加不良信息
                    Model.Model_Bllb_productError_tbpe obj_pe = new Model.Model_Bllb_productError_tbpe();
                    obj_pe.ERROR_MAN = UseId;//打不良人
                    obj_pe.TBEC_ID = str_TBEC_ID;//不良代码ID
                    obj_pe.TBPE_ID = Guid.NewGuid().ToString();//不良记录ID
                    obj_pe.TBPS_ID = TBPS_ID;//产品状态ID
                    obj_pe.TBS_ID = TBS_ID;//工位ID
                    obj_pe.TBG_ID = TBG_ID;//工序ID
                    BLL_Save_Pass_SN.InsertProductError(obj_pe);
                }
                //1.4、产品标识为不良
                BLL_Save_Pass_SN.UpdateErrorFlag(serialNumber);//产品标识为不良
            }
            else
            {
                obj_Pass.STATE_FLAG = "0";//良品
                BLL_Save_Pass_SN.InsertProductPass(obj_Pass);//良品过站记录
            }
            //1.4、新增产品信息
            Model.Model_Bllb_productInfo_tbpi obj_Info = new Model.Model_Bllb_productInfo_tbpi();
            obj_Info.QTY = 1;//数量
            obj_Info.SERIAL_NUMBER = serialNumber;//产品SN
            if (lst_error.Count > 0)
            {
                obj_Info.ERROR_FLAG = "Y";//是否不良
            }
            else
            {
                obj_Info.ERROR_FLAG = "N";//是否不良
            }
            obj_Info.LAST_FLAG = "Y";//是否最新记录
            obj_Info.OVER_FLAG = "N";//是否流程结束
            obj_Info.REPAIR_FLAG = "N";//是否维修过
            obj_Info.SCRAP_FLAG = "N";//是否报废
            obj_Info.ONCE_OVER_FLAG = "N";//是否曾经流程结束过（是针对原单返工的情况）
            obj_Info.SfcNo = sfcNo;//制令单
            obj_Info.TBPI_ID = Guid.NewGuid().ToString();//唯一码
            obj_Info.TBPS_ID = TBPS_ID;//产品状态ID
            if (inout_Type == "0" || inout_Type == "3")//主线投入或者主线投入产出标识
            {
                obj_Info.AUXILIARY_FLAG = "N";
            }
            else if (inout_Type == "2")//辅助线投入
            {
                obj_Info.SERIAL_NUMBER = string.Empty;
                obj_Info.AUXILIARY_FLAG = "Y";
            }
            else if (inout_Type == "1")//产出工序
            {
                if (lst_error.Count > 0)//是否不良
                {
                    obj_Info.OVER_FLAG = "N";//是否流程结束
                    obj_Info.ONCE_OVER_FLAG = once_Over_Flag;//是否曾经流程结束（Y/N）（针对流程结束又原单返工情况）
                }
                else
                {
                    obj_Info.OVER_FLAG = "Y";//是否流程结束
                    obj_Info.ONCE_OVER_FLAG = "Y";//是否曾经流程结束（Y/N）（针对流程结束又原单返工情况）
                }
            }
            if (inout_Type == "0")//投入工序(注意考虑回流情况)
            {
                if (newInput == true)//新投入产品
                {
                    //1.4、新增产品信息                   
                    BLL_Save_Pass_SN.InsertProdcutInfo(obj_Info);
                }
            }
            else if (inout_Type == "1")//1:产出工序
            {
                //1.4、修改产品信息表()
                BLL_Save_Pass_SN.UpdateOverTech(obj_Info);//新增产品信息
                if (once_Over_Flag == "N" || obj_Info.ERROR_FLAG == "N")//是否是流程结束后又原单返工
                {
                    //1.5、修改制令单的产出数（是否流程结束过，若是则不增加制令单产出数）（注意流程结束后隔天返工情况）
                    BLL_Save_Pass_SN.UpdateSfcNo_ActQty(sfcNo, 1);
                }
            }
            else if (inout_Type == "2")//辅助投入工序
            {
                //1.4、修改产品信息表
                if (newInput == true)//新投入产品
                {
                    BLL_Save_Pass_SN.InsertProdcutInfo(obj_Info);//辅助投入时，产品SN设置为空，可用于验证辅助产品是否被组合到主线产品上，为空是还没被组合，组合后为空的辅助产品条码赋值为主线产品条码
                }
            }
            else if (inout_Type == "3")//投入产出工序
            {
                //1.4、新增产品信息表
                if (newInput == true)//新投入产品
                {
                    BLL_Save_Pass_SN.InsertProdcutInfo(obj_Info);
                }
                if (once_Over_Flag == "N")//是否是流程结束后又原单返工
                {
                    //1.5、修改制令单的产出数（是否流程结束过，若是则不增加制令单产出数）（注意流程结束后隔天返工情况）
                    BLL_Save_Pass_SN.UpdateSfcNo_ActQty(sfcNo, 1);
                }
            }
            #endregion
            //if (lst_error.Count == 0)
            //{
            //    BLL_Save_Pass_SN.AUTO_QA();
            //}

            #region 数据统计
            Model_Bllb_groupStatistics_tbgs obj = new Model_Bllb_groupStatistics_tbgs();
            if (lst_error.Count > 0)
            {
                obj.ERROR_NUM = 1;//打不良次数
            }
            else
            {
                obj.ERROR_NUM = 0;//打不良次数
            }
            obj.PASS_NUM = 1;//过站次数
            obj.SfcNo = sfcNo;//制令单
            obj.TBTG_ID = TBTG_ID;//工艺工序ID
            InsertOrUpdateGroupStatistics(obj);//统计过站次数和打不良次数

            #endregion
            return true;
        }
        /// <summary>
        /// 产品过站
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <param name="TBS_ID"></param>
        /// <param name="TBTG_ID"></param>
        /// <param name="WIP_TBTG_ID"></param>
        /// <param name="lst_error"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool PassGroup(string serialNumber, string TBS_ID, string TBTG_ID,string WIP_TBTG_ID, List<string> lst_error, ref string msg)
        {
            //获取TBPS_ID(产品状态ID)、TBG_ID(工序ID)、PLCODE(线别代码)
            string UseId = PubUtils.uContext.UserID;//员工号
            bool newInput = false;//是否新投入的产品

            #region 查询产品信息
            DataTable dt_Product = BLL_Save_Pass_SN.QueryProductSN(serialNumber);//查询产品信息
            if (dt_Product.Rows.Count == 0)
            {
                msg = "不存在条码" + serialNumber;
                return false;
            }

            string sfcNo = dt_Product.Rows[0]["SFCNO"].ToString();//制令单       
            string TBPS_ID = dt_Product.Rows[0]["TBPS_ID"].ToString();//产品状态ID(在产品信息表中不是唯一)
            string once_Over_Flag = dt_Product.Rows[0]["ONCE_OVER_FLAG"].ToString();//是否曾经流程结束（Y/N）（针对流程结束又原单返工情况）
            string TBT_ID = dt_Product.Rows[0]["TBT_ID"].ToString();//工艺ID
            string PLCode = SqlInput.ChangeNullToString(dt_Product.Rows[0]["LINE"]);//线别代码
            #endregion
            #region 工艺信息
            string TBG_ID = string.Empty;//工序ID
            string inout_Type = string.Empty;//工艺工序类型
            //string TBTG_ID = string.Empty;//工艺工序ID
            //获取工艺工序ID对应的工艺工序信息
            DataTable dt_TBTG_ID = BLL_Save_Pass_SN.QueryTechGroup(TBT_ID, TBTG_ID);
            if (dt_TBTG_ID.Rows.Count == 0)
            {
                msg = "工位不在当前产品所在的工艺中";
                return false;
            }
            else
            {
                inout_Type = SqlInput.ChangeNullToString(dt_TBTG_ID.Rows[0]["INOUT_TYPE"]);//投入产出标识
                //TBTG_ID = SqlInput.ChangeNullToString(dt_TBTG_ID.Rows[0]["TBTG_ID"]);//工艺工序ID
             
                TBG_ID = SqlInput.ChangeNullToString(dt_TBTG_ID.Rows[0]["TBG_ID"]);//工序ID
            }
            #endregion
            #region 新增/修改产品状态信息表
            //1.1、新增/修改产品状态信息表
            Model_Bllb_productStatus_tbps obj_Status = new Model_Bllb_productStatus_tbps();
            obj_Status.PLCode = PLCode;//线别代码
            obj_Status.SfcNo = sfcNo;//制令单
            obj_Status.TBTG_ID = TBTG_ID;//工艺工序ID
            obj_Status.WIP_TBTG_ID = WIP_TBTG_ID;//下一个工艺工序ID
            if (newInput == true)//新投入产品
            {
                obj_Status.TBPS_ID = Guid.NewGuid().ToString();//产品状态ID
                TBPS_ID = obj_Status.TBPS_ID;
                BLL_Save_Pass_SN.InsertProductStatus(obj_Status);//新增产品状态信息
            }
            else//在制品
            {
                obj_Status.TBPS_ID = TBPS_ID;//产品状态ID
                BLL_Save_Pass_SN.UpdateProductStatus(obj_Status);
            }
            #endregion
            #region 过站记录
            Model.Model_Bllb_productPass_tbpp obj_Pass = new Model.Model_Bllb_productPass_tbpp();
            obj_Pass.TBG_ID = TBG_ID;//工序ID
            obj_Pass.TBPP_ID = Guid.NewGuid().ToString();//过站记录ID
            obj_Pass.TBPS_ID = TBPS_ID;//产品状态ID
            obj_Pass.PLCode = PLCode;//线别代码
            //1.2、添加产品过站记录表
            if (lst_error.Count > 0)
            {
                obj_Pass.STATE_FLAG = "1";//不良品
                BLL_Save_Pass_SN.InsertProductPass(obj_Pass);//不良品过站记录
                foreach (string str_TBEC_ID in lst_error)
                {
                    //1.3、添加不良信息
                    Model.Model_Bllb_productError_tbpe obj_pe = new Model.Model_Bllb_productError_tbpe();
                    obj_pe.ERROR_MAN = UseId;//打不良人
                    obj_pe.TBEC_ID = str_TBEC_ID;//不良代码ID
                    obj_pe.TBPE_ID = Guid.NewGuid().ToString();//不良记录ID
                    obj_pe.TBPS_ID = TBPS_ID;//产品状态ID
                    obj_pe.TBS_ID = TBS_ID;//工位ID
                    obj_pe.TBG_ID = TBG_ID;//工序ID
                    BLL_Save_Pass_SN.InsertProductError(obj_pe);
                }
                //1.4、产品标识为不良
                BLL_Save_Pass_SN.UpdateErrorFlag(serialNumber);//产品标识为不良
            }
            else
            {
                obj_Pass.STATE_FLAG = "0";//良品
                BLL_Save_Pass_SN.InsertProductPass(obj_Pass);//良品过站记录
            }
            //1.4、新增产品信息
            Model.Model_Bllb_productInfo_tbpi obj_Info = new Model.Model_Bllb_productInfo_tbpi();
            obj_Info.QTY = 1;//数量
            obj_Info.SERIAL_NUMBER = serialNumber;//产品SN
            if (lst_error.Count > 0)
            {
                obj_Info.ERROR_FLAG = "Y";//是否不良
            }
            else
            {
                obj_Info.ERROR_FLAG = "N";//是否不良
            }
            obj_Info.LAST_FLAG = "Y";//是否最新记录
            obj_Info.OVER_FLAG = "N";//是否流程结束
            obj_Info.REPAIR_FLAG = "N";//是否维修过
            obj_Info.SCRAP_FLAG = "N";//是否报废
            obj_Info.ONCE_OVER_FLAG = "N";//是否曾经流程结束过（是针对原单返工的情况）
            obj_Info.SfcNo = sfcNo;//制令单
            obj_Info.TBPI_ID = Guid.NewGuid().ToString();//唯一码
            obj_Info.TBPS_ID = TBPS_ID;//产品状态ID
            if (inout_Type == "0" || inout_Type == "3")//主线投入或者主线投入产出标识
            {
                obj_Info.AUXILIARY_FLAG = "N";
            }
            else if (inout_Type == "2")//辅助线投入
            {
                obj_Info.SERIAL_NUMBER = string.Empty;
                obj_Info.AUXILIARY_FLAG = "Y";
            }
            else if (inout_Type == "1")//产出工序
            {
                if (lst_error.Count > 0)//是否不良
                {
                    obj_Info.OVER_FLAG = "N";//是否流程结束
                    obj_Info.ONCE_OVER_FLAG = once_Over_Flag;//是否曾经流程结束（Y/N）（针对流程结束又原单返工情况）
                }
                else
                {
                    obj_Info.OVER_FLAG = "Y";//是否流程结束
                    obj_Info.ONCE_OVER_FLAG = "Y";//是否曾经流程结束（Y/N）（针对流程结束又原单返工情况）
                }
            }
            if (inout_Type == "0")//投入工序(注意考虑回流情况)
            {
                if (newInput == true)//新投入产品
                {
                    //1.4、新增产品信息                   
                    BLL_Save_Pass_SN.InsertProdcutInfo(obj_Info);
                }
            }
            else if (inout_Type == "1")//1:产出工序
            {
                //1.4、修改产品信息表()
                BLL_Save_Pass_SN.UpdateOverTech(obj_Info);//新增产品信息
                if (once_Over_Flag == "N" || obj_Info.ERROR_FLAG == "N")//是否是流程结束后又原单返工
                {
                    //1.5、修改制令单的产出数（是否流程结束过，若是则不增加制令单产出数）（注意流程结束后隔天返工情况）
                    BLL_Save_Pass_SN.UpdateSfcNo_ActQty(sfcNo, 1);
                }
            }
            else if (inout_Type == "2")//辅助投入工序
            {
                //1.4、修改产品信息表
                if (newInput == true)//新投入产品
                {
                    BLL_Save_Pass_SN.InsertProdcutInfo(obj_Info);//辅助投入时，产品SN设置为空，可用于验证辅助产品是否被组合到主线产品上，为空是还没被组合，组合后为空的辅助产品条码赋值为主线产品条码
                }
            }
            else if (inout_Type == "3")//投入产出工序
            {
                //1.4、新增产品信息表
                if (newInput == true)//新投入产品
                {
                    BLL_Save_Pass_SN.InsertProdcutInfo(obj_Info);
                }
                if (once_Over_Flag == "N")//是否是流程结束后又原单返工
                {
                    //1.5、修改制令单的产出数（是否流程结束过，若是则不增加制令单产出数）（注意流程结束后隔天返工情况）
                    BLL_Save_Pass_SN.UpdateSfcNo_ActQty(sfcNo, 1);
                }
            }
            #endregion
            //if (lst_error.Count == 0)
            //{
            //    BLL_Save_Pass_SN.AUTO_QA();
            //}

            #region 数据统计
            Model_Bllb_groupStatistics_tbgs obj = new Model_Bllb_groupStatistics_tbgs();
            if (lst_error.Count > 0)
            {
                obj.ERROR_NUM = 1;//打不良次数
            }
            else
            {
                obj.ERROR_NUM = 0;//打不良次数
            }
            obj.PASS_NUM = 1;//过站次数
            obj.SfcNo = sfcNo;//制令单
            obj.TBTG_ID = TBTG_ID;//工艺工序ID
            InsertOrUpdateGroupStatistics(obj);//统计过站次数和打不良次数
            if (WIP_TBTG_ID != string.Empty)//下一个工序的统计信息
            {
                obj.PASS_NUM = 0;
                obj.TBTG_ID = WIP_TBTG_ID;
                obj.ERROR_NUM = 0;
                InsertOrUpdateWipGroupStatistics(obj);//判断下一个工序是否有统计数据，若是没有则新增一个
            }
            #endregion
            return true;
        }

        
        #endregion
        #region 统计过站次数和打不良次数
        /// <summary>
        /// 统计过站次数和打不良次数
        /// </summary>
        /// <param name="obj"></param>
        public static void InsertOrUpdateGroupStatistics(Model_Bllb_groupStatistics_tbgs obj)
        {
            //判断记录是否存在
            string strSql = string.Format(@"SELECT COUNT(1) FROM T_Bllb_groupStatistics_tbgs WHERE SfcNo='{0}' AND TBTG_ID='{1}'", obj.SfcNo, obj.TBTG_ID);
            if (SqlInput.ChangeNullToInt(CIT.Wcf.Utils.NMS.GetTableCount(PubUtils.uContext, strSql), 0) == 0)//新增
            {
                strSql = string.Format(@"INSERT INTO T_Bllb_groupStatistics_tbgs(SFCNO,TBTG_ID,PASS_NUM,ERROR_NUM) VALUES('{0}','{1}',{2},{3})", obj.SfcNo, obj.TBTG_ID, obj.PASS_NUM, obj.ERROR_NUM);
                CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
            }
            else
            {
                strSql = string.Format(@"UPDATE T_Bllb_groupStatistics_tbgs SET PASS_NUM=PASS_NUM+{2} , ERROR_NUM=ERROR_NUM+{3} WHERE SfcNo='{0}' AND TBTG_ID='{1}'", obj.SfcNo, obj.TBTG_ID, obj.PASS_NUM, obj.ERROR_NUM);
                CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
            }
        }
        public static void InsertOrUpdateWipGroupStatistics(Model_Bllb_groupStatistics_tbgs obj)
        {
            //判断记录是否存在
            string strSql = string.Format(@"SELECT COUNT(1) FROM T_Bllb_groupStatistics_tbgs WHERE SfcNo='{0}' AND TBTG_ID='{1}'", obj.SfcNo, obj.TBTG_ID);
            if (SqlInput.ChangeNullToInt(CIT.Wcf.Utils.NMS.GetTableCount(PubUtils.uContext, strSql), 0) == 0)//新增
            {
                strSql = string.Format(@"INSERT INTO T_Bllb_groupStatistics_tbgs(SFCNO,TBTG_ID,PASS_NUM,ERROR_NUM) VALUES('{0}','{1}',{2},{3})", obj.SfcNo, obj.TBTG_ID, obj.PASS_NUM, obj.ERROR_NUM);
                CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
            }
        }
        #endregion

        #region 查询工艺工序ID所在工艺工序信息
        /// <summary>
        /// 查询工艺工序ID所在工艺工序信息
        /// </summary>
        /// <param name="TBT_ID"></param>
        /// <param name="TBTG_ID">工艺工序ID</param>
        /// <returns></returns>
        private static DataTable QueryTechGroup(string TBT_ID, string TBTG_ID)
        {
            string strSql = string.Format(@"SELECT T.INOUT_TYPE,T.ISMUSTPASS,T.GROUP_TYPE,T.TBTG_ID,T.QA_FLAG,TBS.PLCODE,TBS.TBG_ID
FROM T_Bllb_technologyGroup_tbtg T LEFT JOIN T_Bllb_techGroupStation_tbtgs S ON T.TBTG_ID=S.TBTG_ID
LEFT JOIN T_Bllb_STATION_TBS TBS ON TBS.TBS_ID=S.TBS_ID WHERE T.TBT_ID='{0}' AND T.TBTG_ID='{1}'", TBT_ID, TBTG_ID);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);

        }
        #endregion
        #region 查询产品SN
        /// <summary>
        /// 查询产品SN
        /// </summary>
        /// <param name="productSN"></param>
        /// <returns></returns>
        private static DataTable QueryProductSN(string productSN)
        {
            string strSql = string.Format(@"SELECT P.TBT_ID,T.SFCNO,P.WOCODE,P.Product,T.TBPS_ID,T.ONCE_OVER_FLAG,T.OVER_FLAG,TBPS.TBTG_ID,T.ERROR_FLAG ,P.LINE
FROM T_Bllb_productInfo_tbpi T LEFT JOIN SfcDatProduct P ON T.SFCNO=P.SFCNO LEFT JOIN T_Bllb_productStatus_tbps TBPS ON T.TBPS_ID=TBPS.TBPS_ID 
WHERE T.SERIAL_NUMBER='{0}' AND T.LAST_FLAG='Y'", productSN);
            return CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, strSql);
        }
        #endregion
              
        #region 修改制令单产出数
        /// <summary>
        /// 修改制令单产出数
        /// </summary>
        /// <param name="SfcNo">制令单</param>
        /// <param name="qty">产品个数</param>
        /// <returns></returns>
        private static bool UpdateSfcNo_ActQty(string SfcNo, int qty)
        {
            string strSql = string.Format(@"UPDATE SfcDatProduct SET
                                        ActQty=ActQty+{1}
                                        where
                                        SfcNo='{0}'
                                        ",
                                      SfcNo,
                                     qty);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        #endregion
        #region 流程结束
        /// <summary>
        /// 流程结束
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool UpdateOverTech(Model_Bllb_productInfo_tbpi obj)
        {
            //用于处理非条码转换指令的情况,对为空的参数进行赋值
            if (obj.OLD_SERIAL_NUMBER == string.Empty)
            {
                obj.OLD_SERIAL_NUMBER = obj.SERIAL_NUMBER;
            }
            if (obj.SERIAL_NUMBER == string.Empty)
            {
                obj.SERIAL_NUMBER = obj.OLD_SERIAL_NUMBER;
            }
            string strSql = string.Format(@"UPDATE T_Bllb_productInfo_tbpi SET
                                        OVER_FLAG='{1}',ONCE_OVER_FLAG='Y',SERIAL_NUMBER='{2}'
                                        where
                                        SERIAL_NUMBER='{0}'
                                        ",
                                      obj.OLD_SERIAL_NUMBER,
                                      obj.OVER_FLAG,
                                      obj.SERIAL_NUMBER);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        #endregion
        #region 产品标识为不良
        /// <summary>
        /// 产品标识为不良
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool UpdateErrorFlag(string SERIAL_NUMBER)
        {
            string strSql = string.Format(@"UPDATE T_Bllb_productInfo_tbpi SET
                                        ERROR_FLAG='Y'
                                        where
                                        SERIAL_NUMBER='{0}'
                                        ",
                                      SERIAL_NUMBER);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        #endregion
        #region 添加产品状态表
        /// <summary>
        /// 添加产品状态表
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool InsertProductStatus(Model_Bllb_productStatus_tbps obj)
        {
            string strSql = string.Format(@"INSERT INTO T_Bllb_productStatus_tbps(
                                        TBTG_ID,
                                        PLCode,
                                        SfcNo,
                                        PASS_TIME,
                                        TBPS_ID,WIP_TBTG_ID)
                                        VALUES( 
                                        '{0}',
                                        '{1}',
                                        '{2}',                                        
                                        GETDATE(),
                                        '{3}','{4}')",
                                         obj.TBTG_ID,
                                         obj.PLCode,
                                         obj.SfcNo,
                                         obj.TBPS_ID,obj.WIP_TBTG_ID);
            CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
            strSql = string.Format(@"UPDATE SFCDATPRODUCT SET InputQty=isnull(InputQty,0)+1 where SfcNo='{0}'",obj.SfcNo);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        #endregion
        #region 新增/修改产品状态信息表
        /// <summary>
        /// 新增/修改产品状态信息表
        /// </summary>
        private static bool UpdateProductStatus(Model_Bllb_productStatus_tbps obj)
        {
                string strSql = string.Format(@"UPDATE T_Bllb_productStatus_tbps SET
                                        TBTG_ID='{1}',
                                        PLCode='{2}',
                                        SfcNo='{3}',
                                        PASS_TIME=GETDATE(),WIP_TBTG_ID='{4}'
                                        where
                                        TBPS_ID='{0}'
                                        ",
                                   obj.TBPS_ID,
                                   obj.TBTG_ID,
                                   obj.PLCode,
                                   obj.SfcNo,obj.WIP_TBTG_ID);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        #endregion
        #region 解箱时设置下一个工序
        /// <summary>
        /// 解箱时设置下一个工序
        /// </summary>
        /// <param name="TBPS_ID">产品状态ID</param>
        /// <returns></returns>
        public static bool UnpackageSetNextGroup(String TBPS_ID)
        {
            string strSql = string.Format(@"UPDATE T_Bllb_productStatus_tbps SET
                                        RE_TBTG_ID=TBTG_ID
                                        where
                                        TBPS_ID='{0}'
                                        ",
                                    TBPS_ID);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        #endregion
        #region 设置下一个要过的工序
        /// <summary>
        /// 设置下一个要过的工序
        /// </summary>
        /// <param name="TBPS_ID"></param>
        /// <param name="RE_TBTG_ID"></param>
        /// <returns></returns>
        public static bool SetNextGroup(String TBPS_ID,string RE_TBTG_ID)
        {
            string strSql = string.Format(@"UPDATE T_Bllb_productStatus_tbps SET
                                        RE_TBTG_ID='{1}'，WIP_TBTG_ID='{1}'
                                        where
                                        TBPS_ID='{0}'
                                        ",
                                    TBPS_ID, RE_TBTG_ID);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        #endregion
        #region 设置检验的重新投入工序
        /// <summary>
        /// 设置检验的重新投入工序
        /// </summary>
        /// <param name="Doc_No"></param>
        /// <param name="RE_TBTG_ID"></param>
        /// <returns></returns>
        public static bool SetDocRebackGroup(string Doc_No,string RE_TBTG_ID)
        {
            string strSql = string.Format(@"  UPDATE T_Bllb_productStatus_tbps SET  RE_TBTG_ID='{1}'
   where  TBPS_ID in (select T.TBPS_ID from T_Bllb_sampleProduct_tbap T WHERE T.DOC_NO='{0}')",
                                    Doc_No, RE_TBTG_ID);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        #endregion
        #region 一级容器向下解箱时设置下一个工序
        /// <summary>
        /// 一级容器向下解箱时设置下一个工序
        /// </summary>
        /// <param name="ContainerSN">容器SN</param>
        /// <returns></returns>
        public static bool UnpackageSetNextGroup2(String ContainerSN)
        {
            string strSql = string.Format(@"UPDATE T_Bllb_productStatus_tbps SET
                                        RE_TBTG_ID=TBTG_ID
                                        where
                                        TBPS_ID IN (SELECT TBPS_ID FROM T_Bllb_packageOne_tbpo WHERE CONTAINER_SN_1='{0}')
                                        ",
                                    ContainerSN);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        #endregion

        #region 新增产品过站记录
        /// <summary>
        /// 新增产品过站记录
        /// </summary>
        /// <param name="error"></param>
        private static bool InsertProductPass(Model_Bllb_productPass_tbpp obj)
        {
            string strSql = string.Format(@"INSERT INTO T_Bllb_productPass_tbpp(
                                        TBPS_ID,
                                        TBG_ID,
                                        PASS_TIME,
                                        STATE_FLAG,
                                        PLCode,
                                        UserID)
                                        VALUES( 
                                        '{0}',
                                        '{1}',
                                        GETDATE(),
                                        '{2}',
                                        '{3}',
                                        '{4}')",
                                        obj.TBPS_ID,
                                        obj.TBG_ID,
                                        obj.STATE_FLAG,
                                        obj.PLCode, 
                                        PubUtils.uContext.UserID
                                        );
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);

        }
        #endregion
        #region 新增产品信息记录
        /// <summary>
        /// 新增产品信息记录
        /// </summary>
        /// <param name="str">产品条码</param>
        private static bool InsertProdcutInfo(Model_Bllb_productInfo_tbpi obj)
        {

           string strSql = string.Format(@"INSERT INTO T_Bllb_productInfo_tbpi(
                                        TBPS_ID,
                                        SERIAL_NUMBER,
                                        QTY,
                                        OVER_FLAG,
                                        LAST_FLAG,
                                        ERROR_FLAG,
                                        REPAIR_FLAG,
                                        SCRAP_FLAG,
                                        SfcNo,
                                        AUXILIARY_FLAG,
                                        ONCE_OVER_FLAG)
                                        VALUES( 
                                        '{0}',
                                        '{1}',
                                        '{2}',
                                        '{3}',
                                        '{4}',
                                        '{5}',
                                        '{6}',
                                        '{7}',
                                        '{8}',
                                        '{9}',
                                        '{10}')",
                                       obj.TBPS_ID,
                                       obj.SERIAL_NUMBER,
                                       obj.QTY,
                                       obj.OVER_FLAG,
                                       obj.LAST_FLAG,
                                       obj.ERROR_FLAG,
                                       obj.REPAIR_FLAG,
                                       obj.SCRAP_FLAG,
                                       obj.SfcNo,
                                       obj.AUXILIARY_FLAG,
                                       obj.ONCE_OVER_FLAG);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        #endregion        
        #region 新增产品不良信息记录
        /// <summary>
        /// 新增产品不良信息记录
        /// </summary>
        private static bool InsertProductError(Model_Bllb_productError_tbpe obj)
        {

            string strSql = string.Format(@"INSERT INTO T_Bllb_productError_tbpe(
                                        TBPS_ID,
                                        TBEC_ID,
                                        ERROR_MAN,
                                        ERROR_TIME,
                                        TBPE_ID,
                                        TBS_ID,
                                        TBG_ID                                       
                                        )
                                        VALUES( 
                                        '{0}',
                                        '{1}',
                                        '{2}',
                                        GETDATE(),
                                        '{3}',
                                        '{4}',
                                        '{5}')",
                                         obj.TBPS_ID,
                                         obj.TBEC_ID,
                                         obj.ERROR_MAN,
                                         obj.TBPE_ID,
                                         obj.TBS_ID,
                                         obj.TBG_ID);
            return CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }
        #endregion
     
    }
}
