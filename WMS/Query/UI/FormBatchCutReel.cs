using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIT.Wcf.Utils;
using CIT.Client;
using CIT.MES;
using System.Text.RegularExpressions;
using CIT.MES.Common.Helper;

namespace Query.UI
{
    public partial class FormBatchCutReel : UserControl
    {
        #region 变量
        /// <summary>
        /// 对象
        /// </summary>
        BarObject barobject = new BarObject();
        /// <summary>
        /// 旧的reelid
        /// </summary>
        string old_reelid = string.Empty;
        /// <summary>
        /// 分盘数
        /// </summary>
        int dicknum = 0;
        /// <summary>
        /// 数据库表里存在的流水号
        /// </summary>
        string flownum = string.Empty;
        /// <summary>
        /// 分盘次数（cutTimes=0时不进行分盘）
        /// </summary>
        int cutTimes = 0;
        /// <summary>
        /// 当前日期
        /// </summary>
        string currentDate = string.Empty;
        #endregion

        #region 窗体初始化
        public FormBatchCutReel()
        {
            InitializeComponent();
        }
        #endregion

        #region 记录操作日志
        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="varLogInfo">日志信息</param>
        public void SaveLogInfo(string varLogInfo)
        {
            if (varLogInfo != "")
            {
                string str = string.Format("姓名：{0},事件：{1},时间：{2}", PubUtils.uContext.UserName, varLogInfo, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lbLogInfo.Items.Add(str);
            }
        }
        #endregion

        #region 开始分盘
        private void btnBeginCutReel_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;

            if (!CheckData(out msg))
            {
                new PubUtils().ShowNoteNGMsg(msg, 1, grade.OrdinaryError);
                return;
            }

            bool isCanBeginCut = CheckReelCount(txt_Reelid.Text.Trim(), Convert.ToInt32(txtSigleCount.Text.Trim()), Convert.ToInt32(txtDiskNum.Text.Trim()));
            if (isCanBeginCut)
            {
                dicknum = Convert.ToInt32(txtDiskNum.Text);
                //开始分盘
                DataTable dt_flow = NMS.QueryDataTable(PubUtils.uContext, string.Format(@"
declare @newflow nVarchar(50)
if not exists(select * from dbo.T_Split_Disc where dateDiff(day,CreateTime,getDate())=0)
	begin
		delete dbo.T_Split_Disc
        insert into T_Split_Disc(flownumber,createTime) values('{0}',getdate())
		select '0' return
	end
else
	begin
		select @newflow=FlowNumber  from dbo.T_Split_Disc
        update T_Split_Disc set FlowNumber=(convert(int,@newflow)+{0}) where dateDiff(day,CreateTime,getDate())=0
        select @newflow return
	end", dicknum));
                flownum = dt_flow.Rows[0][0].ToString();
                cutTimes = dicknum;
                currentDate = DateTime.Now.ToString("yyyyMMdd");
                for (int i = 0; i < dicknum; i++)
                {
                    if (cutTimes == 0)
                        break;
                    Panels(cutTimes);
                    cutTimes = cutTimes - 1;
                }
            }
            else
            {
                return;
            }
        }

        private bool CheckData(out string msg)
        {
            msg = "OK";
            if (lbLogInfo.Items.Count >= 1000)
            {
                //数据项太多了--清除
                lbLogInfo.Items.Clear();
                lbLogInfo.Items.Add("日志大于1000条，清空！");
            }
            //if (txtHourseName.Text != "原料仓(主仓)")
            //{
            //    msg = "仅原料仓（主仓）的料盘可以进行分盘";
            //    return false;
            //}
            if (txt_BarCode.Text == string.Empty)
            {
                msg = "料卷信息为空!";
                return false;
            }
            if (txtSigleCount.Text == string.Empty)
            {
                msg = "单盘物料数量为空!";
                return false;
            }
            if (txtDiskNum.Text == string.Empty)
            {
                msg = "分盘数量为空!";
                return false;
            }
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, string.Format("select *  from T_Bllb_StockInfo_tbsi where SerialNumber='{0}'", txt_Reelid.Text.Trim()));
            if (dt.Rows.Count > 0)
            {
                string ShelfID = StringChange.ChangeNullToString(dt.Rows[0]["Location_SN"]);
                if (ShelfID != "")
                {
                    msg = "料盘上架中!";
                    return false;
                }
            }
            else
            {
                msg = "料盘编号错误!";
                return false;
            }
            return true;
        }
        #endregion

        #region  分盘前校验数量
        /// <summary>
        /// 分盘前校验数量
        /// </summary>
        /// <param name="varReelID">料卷ReelID</param>
        /// <param name="varCutNum">单盘数量</param>
        /// <param name="DiskNum">分盘数量</param>
        /// <returns></returns>
        public bool CheckReelCount(string varReelID, int varCutNum, int varDiskNum)
        {
            //日志信息
            string logInfo = string.Empty;

            //每盘物料数量 因为 IsMatch是静态方法 不能在里面使用类型转换
            string cutNum = Convert.ToString(varCutNum);
            //盘数
            string diskNum = Convert.ToString(varDiskNum);
            //判断每盘数量是否是小数，且是否小于等于0
            if (varCutNum <= 0 || cutNum.Contains("."))
            {
                logInfo = string.Format("输入了0,或者小数的每盘料卷数量");
                SaveLogInfo(logInfo);
                txtDiskNum.Focus();
                MsgBox.Error("分盘数量不能为0或者小数，必须是大于0的整数！");
                return false;
            }
            //判断盘数量是否是小数，且是否小于等于0
            if (varDiskNum <= 0 || diskNum.Contains("."))
            {
                logInfo = string.Format("输入了0,或者小数的盘数", PubUtils.uContext.UserName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                SaveLogInfo(logInfo);
                txtSigleCount.Focus();
                MsgBox.Error("盘数不能为0或者小数，必须是大于0的整数！");
                return false;
            }
            //计算 分盘时 每盘料数*盘数 是否大于料卷总数
            int stockCount = (int)Convert.ToDouble(txtRollNum.Text.Trim());
            int cutCount = Convert.ToInt32(txtSigleCount.Text.Trim()) * Convert.ToInt32(txtDiskNum.Text.Trim());
            if (cutCount > stockCount)
            {
                MsgBox.Error(string.Format("分盘的数量大于库存数：{0}", stockCount));
                return false;
            }
            return true;
        }
        #endregion

        #region 分盘方法
        /// <summary>
        /// 分盘方法
        /// </summary>
        /// <param name="varLogInfo">日志信息</param>
        public void Panels(int cutTimes)
        {
            string sqlSelectRollInfo = string.Format(@"
SELECT  a.Storage_SN ,
        a.QTY ,
        a.MaterialCode ,
        a.Location_SN ,
        a.SerialNumber ,
        a.DateCode ,
        a.MPN
FROM    dbo.T_Bllb_StockInfo_tbsi AS a
        LEFT JOIN dbo.T_Bllb_Storage_tbs AS b ON a.Storage_SN = b.Storage_SN
WHERE   a.SerialNumber = '{0}'", txt_Reelid.Text.Trim());
            DataTable dtRollInfo = NMS.QueryDataTable(PubUtils.uContext, sqlSelectRollInfo);
            if (dtRollInfo.Rows.Count > 0)
            {
                txt_Reelid.Text = txt_Reelid.Text.Trim();
                txtHourseName.Text = dtRollInfo.Rows[0]["Storage_SN"].ToString();
                txtMaterialNo.Text = dtRollInfo.Rows[0]["MaterialCode"].ToString();
                txtRollNum.Text = dtRollInfo.Rows[0]["QTY"].ToString();
                string sql = GetPreNotPreStandardInsert(txt_Reelid.Text);
                DataTable dt_temp = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sql);
                if (dt_temp.Rows.Count > 0)
                {
                    if (dt_temp.Rows[0][0].ToString() == "1")
                    {
                        int index = int.Parse(dt_temp.Rows[0][1].ToString());
                        //分盘插入后的新条码的GUID
                        string fguid = dt_temp.Rows[0][2].ToString();
                        //流水号
                        string flowNumber = string.Format("{0}{1}", currentDate, (long.Parse(flownum) + cutTimes).ToString().PadLeft(6, '0'));
                        //生成的新条码
                        string newBarCode = CreateNewBarCode(flowNumber);
                        //新的ReelId
                        string newReelid = newBarCode;
                        //最后要更新的条码规则的Reelid
                        Model.Model_MaterialBarCode bar = new Model.Model_MaterialBarCode();
                        bar.MaterialCode = txtMaterialNo.Text.Trim();//物料代码
                        bar.QTY = Convert.ToString(txtSigleCount.Text);//数量


                        barobject.BarCode = newBarCode;//打印的条码
                        barobject.partNo = txtMaterialNo.Text;
                        barobject.SingleNumber = Convert.ToInt32(txtSigleCount.Text);
                        if (barobject.PrintOwn("002"))
                        {
                            bool result = NMS.ExecTransql(CIT.MES.PubUtils.uContext, GetUpdateMdcDatVStorage(newReelid, fguid, txt_Reelid.Text, Convert.ToDecimal(txtSigleCount.Text)));
                            if (result == true)
                            {
                                lbLogInfo.Items.Add(string.Format("分盘成功！唯一码：{0}", newReelid));
                                GetMaterialInfo(txt_Reelid.Text.Trim());
                            }
                            else
                            {
                                lbLogInfo.Items.Add("分盘失败！");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    //物料预注册失败
                    new PubUtils().ShowNoteNGMsg("物料预注册失败！", 1, grade.OrdinaryError);
                    return;
                }
            }
            else
            {
                new PubUtils().ShowNoteNGMsg("不存在该料卷！", 1, grade.OrdinaryError);
                SaveLogInfo(string.Format("输入了一个不存在的料卷：{0}", txt_BarCode.Text.Trim()));
                return;
            }

        }
        /// <summary>
        /// 生成新条码
        /// </summary>
        /// <param name="varFlowNumber">流水号</param>
        /// <returns></returns>
        private string CreateNewBarCode(string varFlowNumber)
        {
            string oldBarCode = txt_BarCode.Text.Trim();//旧条码
            string newBarCode = string.Format("{0}-{1}", oldBarCode, varFlowNumber);//新条码
            return newBarCode;
        }
        #endregion

        #region 获取分盘料卷信息
        /// <summary>
        /// 获取当前的料卷信息
        /// </summary>
        /// <param name="varReelID"></param>
        public void GetMaterialInfo(string varReelID)
        {
            string strQuery = string.Format(@"
SELECT  a.Storage_SN ,
        a.QTY ,
        a.MaterialCode ,
        a.Location_SN ,
        a.SerialNumber ,
        a.DateCode ,
        a.MPN
FROM    dbo.T_Bllb_StockInfo_tbsi AS a
        LEFT JOIN dbo.T_Bllb_Storage_tbs AS b ON a.Storage_SN = b.Storage_SN
WHERE   a.SerialNumber = '{0}'", varReelID);
            DataTable dt_MaterialInfo = NMS.QueryDataTable(PubUtils.uContext, strQuery);
            if (dt_MaterialInfo.Rows.Count > 0)
            {
                txtHourseName.Text = dt_MaterialInfo.Rows[0]["Storage_SN"].ToString();
                txtRollNum.Text = dt_MaterialInfo.Rows[0]["QTY"].ToString();
                txtMaterialNo.Text = dt_MaterialInfo.Rows[0]["MaterialCode"].ToString();
                txt_Reelid.Text = varReelID;
            }
            else
            {
                new PubUtils().ShowNoteNGMsg("该料卷不存在！", 1, grade.OrdinaryError);
                return;
            }
        }
        private void txt_BarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txt_BarCode.Text.Trim() == "")
                {
                    new PubUtils().ShowNoteNGMsg("请先输入料卷信息！", 1, grade.OrdinaryError);
                    return;
                }
                //获取当前的料卷信息
                string reelid = txt_BarCode.Text.Trim();
                old_reelid = reelid;
                GetMaterialInfo(reelid);
            }
        }
        #endregion

        #region 分盘数据库操作
        /// <summary>
        /// 分盘数据库操作
        /// </summary>
        /// <param name="newReelid">新的Reelid</param>
        /// <param name="CGUID"></param>
        /// <param name="oldReelid">旧的Reelid</param>
        /// <param name="qty"></param>
        /// <returns></returns>
        private string GetUpdateMdcDatVStorage(string newReelid, string CGUID, string oldReelid, decimal qty)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(string.Format(@"
            --更新分盘后的新条码的数量和Reelid
            update MdcDatVStorage set reelid='{0}',[status]='1',GRTime = getdate(),qty={3},grqty={3},updatetime=getdate(),updator='{4}' where reelid='{1}'
            --更新旧盘的数量
            update MdcDatVStorage set qty=qty-{3} where reelid='{2}' 
             --增加SyssystemLog日志 nancy 2017.07.27
             insert SyssystemLog(Fguid,line,WoCode,SfcNo,ProuctCode,PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,Remarks,Creator)
             select newid(),line,WoCode,SfcNo,'',PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,'MES料卷分盘,原始料盘:{2}','{4}'  from mdcdatvstorage where reelid='{0}'
            insert into sfcdatcutlog(fguid,oldreelid,newreelid,creator,createtime) values(newid(),'{2}','{0}','{4}',getdate())         
            declare @housecode nvarchar(50)
            select @housecode=housecode from mdcdatvstorage where reelid='{2}'
            if @housecode='003' or @housecode='006'
            begin
            insert into PUB_UniqueCodeInLine(WorkOrderNo,MOrderNo,UniqueCode,MatrCode,Qty,Supplier,lotno)
            select wocode,sfcno,reelid,partnumber,qty,SupplierID,batch1 from mdcdatvstorage where reelid='{0}'

            update PUB_UniqueCodeInLine set qty=qty-{3} where UniqueCode='{2}'
            update JIT_BufferMaterial set qty=qty-{3} where UniqueCode='{2}'

            insert into JIT_BufferMaterial(CallOrderNo,LineName,WorkOrderNo,MOrderNo,UniqueCode,MatrCode,Qty,SysOwner,CreateTime)
            select '',line,wocode,sfcno,reelid,partnumber,qty,'{4}',getdate() from mdcdatvstorage where reelid='{0}'

            update PVS_Busi_LoadingList set leftqty=leftqty-{3} where UniqueCode='{2}'

            update PVS_Busi_LoadingList set standbyqty=standbyqty-{3} where standbycode='{2}'

            end
            ", newReelid, CGUID, oldReelid, qty, CIT.MES.PubUtils.uContext.UserName));
            return builder.ToString();
        }

        private string GetPreNotPreStandardInsert(string reelID)
        {
            string strSql = string.Format(@"
DECLARE @newBarCode NVARCHAR(50)--临时的条码=》用GUID代替
SET @newBarCode=NEWID()
BEGIN TRY
INSERT INTO dbo.T_Bllb_StockInfo_tbsi	
        ( Storage_SN ,
          Area_SN ,
          Location_SN ,
          MaterialCode ,
          QTY ,
          Lock_Flag ,
          Enable ,
          In_Time ,
          SerialNumber ,
          Scrapt_Time ,
          Lock_Time ,
          Status_Flag ,
          PLCode ,
          Reback_Flag ,
          DateCode ,
          Finally_Time ,
          Out_Time ,
          Lot_No ,
          QC_Result ,
          MaterialModel ,
          SfcNo ,
          SupplierCode ,
          MPN ,
          Version ,
          TBS_ID
        )
SELECT  Storage_SN,Area_SN,Location_SN,MaterialCode,'0',Lock_Flag,Enable,In_Time,@newBarCode,Scrapt_Time,Lock_Time,Status_Flag,PLCode,Reback_Flag,DateCode,
GETDATE(),Out_Time,Lot_No,QC_Result,MaterialModel,SfcNo,SupplierCode,MPN,Version,TBS_ID FROM dbo.T_Bllb_StockInfo_tbsi WHERE SerialNumber='{0}'
SELECT '1',@newBarCode RETURN
END TRY
BEGIN CATCH
	SELECT '0','Error' RETURN 
END CATCH", reelID);
            return strSql;
        }
        #endregion


    }
}
