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
using Common.Helper;

namespace Warehouse.UI
{
    public partial class ucBatchCutReel : UserControl
    {
        /// <summary>
        /// 旧的reelid
        /// </summary>
        string _old_reelid = string.Empty;
        /// <summary>
        /// 分盘数
        /// </summary>
        int dickNum = 0;
        /// <summary>
        /// 数据库表里存在的流水号
        /// </summary>
        string flowNum = string.Empty;
        /// <summary>
        /// 分盘次数（cutTimes=0时不进行分盘）
        /// </summary>
        int cutTimes = 0;
        /// <summary>
        /// 料盘信息
        /// </summary>
        DataTable dt_MaterialInfo = new DataTable();
        /// <summary>
        /// 库位
        /// </summary>
        string Location_SN = string.Empty;
        /// <summary>
        /// 料盘状态
        /// </summary>
        string Lock_Flag = string.Empty;

        public ucBatchCutReel()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="log">日志信息</param>
        public void WriteLogToControl(string log)
        {
            if (log != "")
            {
                string str = string.Format("姓名：{0},事件：{1},时间：{2}", PubUtils.uContext.UserName, log, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lbLogInfo.Items.Add(str);
            }
        }

        private void btnBeginCutReel_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;

            if (!CheckData(out msg))
            {
                new PubUtils().ShowNoteNGMsg(msg, 1, grade.OrdinaryError);
                return;
            }

            bool isCutDisk = ValidationBarcodeQty(txt_BarCode.Text.Trim(), Convert.ToInt32(txtSigleCount.Text.Trim()), Convert.ToInt32(txtDiskNum.Text.Trim()));
            if (isCutDisk)
            {
                dickNum = Convert.ToInt32(txtDiskNum.Text);
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
	end", dickNum));
                flowNum = dt_flow.Rows[0][0].ToString();
                cutTimes = dickNum;
                for (int i = 0; i < dickNum; i++)
                {
                    if (cutTimes == 0)
                        break;
                    PlayCutDiskMethod(cutTimes);
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
                lbLogInfo.Items.Add("日志大于1000条，清空");
            }
            if (txt_BarCode.Text == string.Empty)
            {
                msg = "料卷信息为空";
                return false;
            }
            if (txtSigleCount.Text == string.Empty)
            {
                msg = "单盘物料数量为空";
                return false;
            }
            if (txtDiskNum.Text == string.Empty)
            {
                msg = "分盘数量为空";
                return false;
            }
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, string.Format("SELECT *  FROM dbo.T_Bllb_StockInfo_tbsi WHERE SerialNumber='{0}'", txt_BarCode.Text.Trim()));
            if (dt.Rows.Count > 0)
            {
                Location_SN = SqlInput.ChangeNullToString(dt.Rows[0]["Location_SN"]);
                if (!string.IsNullOrEmpty(Location_SN))
                {
                    msg = "料盘上架中";
                    return false;
                }
                Lock_Flag = SqlInput.ChangeNullToString(dt.Rows[0]["Lock_Flag"]);
                if (!(Lock_Flag == "7" || Lock_Flag == "0"))
                {
                    msg = "料盘状态不允许分盘";
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

        #region  分盘前校验数量
        /// <summary>
        /// 分盘前校验数量
        /// </summary>
        /// <param name="varReelID">料卷ReelID</param>
        /// <param name="varCutNum">单盘数量</param>
        /// <param name="DiskNum">分盘数量</param>
        /// <returns></returns>
        public bool ValidationBarcodeQty(string varReelID, int varCutNum, int varDiskNum)
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
                WriteLogToControl(logInfo);
                new PubUtils().ShowNoteNGMsg("分盘数量不能为0或者小数，必须是大于0的整数！", 1, grade.OrdinaryError);
                txtDiskNum.Focus();
                return false;
            }
            //判断盘数量是否是小数，且是否小于等于0
            if (varDiskNum <= 0 || diskNum.Contains("."))
            {
                logInfo = string.Format("输入了0,或者小数的盘数", PubUtils.uContext.UserName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                WriteLogToControl(logInfo);
                new PubUtils().ShowNoteNGMsg("盘数不能为0或者小数，必须是大于0的整数！", 1, grade.OrdinaryError);
                txtSigleCount.Focus();
                return false;
            }
            //计算 分盘时 每盘料数*盘数 是否大于料卷总数
            int stockTotalQty = (int)Convert.ToDouble(txtRollNum.Text.Trim());
            int cutTotalQty = Convert.ToInt32(txtSigleCount.Text.Trim()) * Convert.ToInt32(txtDiskNum.Text.Trim());
            if (cutTotalQty > stockTotalQty)
            {
                new PubUtils().ShowNoteNGMsg(string.Format("分盘的数量大于库存数：{0}", stockTotalQty), 1, grade.OrdinaryError);
                return false;
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 分盘方法
        /// </summary>
        /// <param name="varLogInfo">日志信息</param>
        public void PlayCutDiskMethod(int cutTimes)
        {
            string queryBarcodeInfo = string.Format(@"
SELECT a.SerialNumber,a.QTY,a.Location_SN,a.Storage_SN,a.Area_SN,
b.Storage_Name,c.Area_Name,d.Location_Name, a.MaterialCode  
FROM dbo.T_Bllb_StockInfo_tbsi AS a
LEFT JOIN dbo.T_Bllb_Storage_tbs AS b ON a.Storage_SN=b.Storage_SN
LEFT JOIN dbo.T_Bllb_StorageArea_tbsa AS c ON c.Storage_SN=b.Storage_SN
LEFT JOIN dbo.T_Bllb_StorageLocation_tbsl AS d ON c.Area_SN=d.Area_SN
WHERE a.SerialNumber='{0}'", txt_Reelid.Text.Trim());
            DataTable dtInfo = NMS.QueryDataTable(PubUtils.uContext, queryBarcodeInfo);
            if (dtInfo.Rows.Count > 0)
            {
                txt_Reelid.Text = txt_Reelid.Text.Trim();
                txtHourseName.Text = dtInfo.Rows[0]["Storage_Name"].ToString();
                txtMaterialNo.Text = dtInfo.Rows[0]["MaterialCode"].ToString();
                txtRollNum.Text = dtInfo.Rows[0]["QTY"].ToString();
                string sql = GetCopySqlFromOldBarcode(txt_Reelid.Text);
                DataTable dt_temp = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sql);
                if (dt_temp.Rows.Count > 0)
                {
                    if (dt_temp.Rows[0][0].ToString() == "1")
                    {
                        //分盘插入后的新条码的GUID
                        string new_barcode_guid = dt_temp.Rows[0][1].ToString();
                        //流水号
                        string flowNumber = string.Format("{0}", (long.Parse(flowNum) + cutTimes).ToString().PadLeft(6, '0'));
                        //生成的新条码
                        string new_barcode = CreateNewBarCode(flowNumber);
                        //旧条码
                        DataRow[] drs = dt_MaterialInfo.Select(string.Format("SerialNumber='{0}'", txt_BarCode.Text.Trim()));
                        if (drs.Length == 0)
                        {
                            new PubUtils().ShowNoteNGMsg("条码不存在", 2, grade.OrdinaryError);
                            return;
                        }
                        Model.Model_MaterialBarCode bar = new Model.Model_MaterialBarCode();
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        dic.Clear();
                        bar.MaterialCode = txtMaterialNo.Text.Trim();//物料代码
                        dic.Add("MaterialCode", bar.MaterialCode);
                        bar.QTY = txtSigleCount.Text.ToString();//数量
                        dic.Add("QTY", bar.QTY.Trim());
                        bar.BEGIN_DATE = SqlInput.ChangeNullToString(drs[0]["DateCode"]);//生产日期
                        dic.Add("BEGIN_DATE", bar.BEGIN_DATE);
                        bar.PO = SqlInput.ChangeNullToString(drs[0]["PO"]);//采购订单号
                        dic.Add("PO", bar.PO);
                        bar.MPN = SqlInput.ChangeNullToString(drs[0]["MPN"]);//MPN
                        dic.Add("MPN", bar.MPN);
                        bar.SN = new_barcode;
                        dic.Add("SN", bar.SN);
                        bar.QRCODE = new_barcode;
                        dic.Add("QRCODE", bar.QRCODE);
                        if (Common.BLL.Bll_Print.PrintTemplet("安费诺来料打印", dic))
                        {
                            bool result = NMS.ExecTransql(CIT.MES.PubUtils.uContext, UpdateStockInfo(new_barcode, _old_reelid, new_barcode_guid, Convert.ToDecimal(txtSigleCount.Text)));
                            if (result == true)
                            {
                                lbLogInfo.Items.Add(string.Format("分盘成功！唯一码：{0}", new_barcode));
                                GetMaterialInfo(txt_Reelid.Text.Trim());
                            }
                            else
                            {
                                lbLogInfo.Items.Add("分盘失败！");
                                return;
                            }
                            bar = new Model.Model_MaterialBarCode();
                        }
                    }
                    else
                    {
                        //物料预注册失败
                        new PubUtils().ShowNoteNGMsg("物料预注册失败！", 1, grade.OrdinaryError);
                        return;
                    }
                }
            }
            else
            {
                new PubUtils().ShowNoteNGMsg("不存在该料卷！", 1, grade.OrdinaryError);
                WriteLogToControl(string.Format("输入了一个不存在的料卷：{0}", txt_BarCode.Text.Trim()));
                return;
            }
        }
        /// <summary>
        /// 生成新条码
        /// </summary>
        /// <param name="flowNumber">流水号</param>
        /// <returns></returns>
        private string CreateNewBarCode(string flowNumber)
        {
            string _old_barcode = txt_BarCode.Text.Trim();//旧条码
            string _new_barcode = string.Format("{0}-{1}", _old_barcode, flowNumber);
            return _new_barcode;
        }

        /// <summary>
        /// 获取当前的料卷信息
        /// </summary>
        /// <param name="reelid"></param>
        public void GetMaterialInfo(string reelid)
        {
            string querySql = string.Format(@"
SELECT a.SerialNumber,a.QTY,a.Location_SN,a.Storage_SN,a.Area_SN,a.DateCode,a.MPN,f.PO,a.Lock_Flag,
b.Storage_Name,c.Area_Name,d.Location_Name, a.MaterialCode 
FROM dbo.T_Bllb_StockInfo_tbsi AS a
LEFT JOIN dbo.T_Bllb_Storage_tbs AS b ON b.Storage_SN=a.Storage_SN
LEFT JOIN dbo.T_Bllb_StorageArea_tbsa AS c ON c.Area_SN=a.Area_SN
LEFT JOIN dbo.T_Bllb_StorageLocation_tbsl AS d ON d.Location_SN=a.Location_SN
LEFT JOIN dbo.T_Bllb_StorageDocDetail_tbsdd AS e ON   e.SerialNumber=a.SerialNumber
LEFT JOIN dbo.T_Bllb_StorageDoc_tbsd AS f ON f.S_Doc_NO=e.S_Doc_NO
WHERE a.SerialNumber='{0}'", reelid);
            dt_MaterialInfo = NMS.QueryDataTable(PubUtils.uContext, querySql);
            if (dt_MaterialInfo.Rows.Count > 0)
            {
                Location_SN = SqlInput.ChangeNullToString(dt_MaterialInfo.Rows[0]["Location_SN"]);
                if (!string.IsNullOrEmpty(Location_SN))
                {
                    txt_BarCode.SelectAll();
                    new PubUtils().ShowNoteNGMsg("料盘上架中", 1, grade.OrdinaryError);
                    return;
                }
                Lock_Flag = SqlInput.ChangeNullToString(dt_MaterialInfo.Rows[0]["Lock_Flag"]);
                if (!(Lock_Flag == "7" || Lock_Flag == "0"))
                {
                    txt_BarCode.SelectAll();
                    new PubUtils().ShowNoteNGMsg("料盘当前状态不允许分盘", 1, grade.OrdinaryError);
                    return;
                }
                txtHourseName.Text = dt_MaterialInfo.Rows[0]["Storage_Name"].ToString();
                txtRollNum.Text = dt_MaterialInfo.Rows[0]["QTY"].ToString();
                txtMaterialNo.Text = dt_MaterialInfo.Rows[0]["MaterialCode"].ToString();
                txt_Reelid.Text = reelid;
            }
            else
            {
                txt_BarCode.SelectAll();
                new PubUtils().ShowNoteNGMsg("料盘信息错误", 1, grade.OrdinaryError);
                return;
            }
        }
        private void txt_BarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(txt_BarCode.Text.Trim()))
                {
                    new PubUtils().ShowNoteNGMsg("请先输入料卷信息！", 1, grade.OrdinaryError);
                    return;
                }
                //获取当前的料卷信息
                _old_reelid = txt_BarCode.Text.Trim();
                GetMaterialInfo(txt_BarCode.Text.Trim());
            }
        }

        /// <summary>
        /// 分盘数据库操作
        /// </summary>
        /// <param name="new_reelid">新条码</param>
        /// <param name="old_reelid">旧条码</param>
        /// <param name="temp_guid">新条码的临时GUID</param>
        /// <param name="qty">数量</param>
        /// <returns></returns>
        private string UpdateStockInfo(string new_reelid, string old_reelid, string temp_guid, decimal qty)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat(@"		 
          DECLARE @WoCode NVARCHAR(50) --工单
		  DECLARE @sfcno NVARCHAR(50) --制令单
		  DECLARE @line NVARCHAR(50)--线体
		     --更新分盘后的新条码的数量和Reelid
             UPDATE dbo.T_Bllb_StockInfo_tbsi SET SerialNumber='{0}',QTY='{2}' WHERE SerialNumber='{4}'--fguid
             --更新旧盘的数量
             UPDATE T_Bllb_StockInfo_tbsi SET QTY= QTY-CAST('{2}' AS INT) WHERE SerialNumber='{1}' --old 
             --增加Log日志  
			 INSERT INTO dbo.T_Bllb_MaterialLog_tbml
			         ( SerialNumber ,
			           CreateTime ,
			           OperateType ,
			           MaterialCode ,
			           QTY ,
			           Creator ,
			           Memo ,
			           SfcNo ,
			           TBML_ID ,
			           PLCode
			         )
			 VALUES  ( N'{0}' , -- SerialNumber - nvarchar(200)
			           GETDATE() , -- CreateTime - datetime
			           N'分盘' , -- OperateType - nvarchar(50)
			           N'' , -- MaterialCode - nvarchar(50)
			           '{2}' , -- QTY - int
			           '{3}' , -- Creator - nvarchar(50)
			           N'' , -- Memo - nvarchar(500)
			           N'' , -- SfcNo - nvarchar(50)
			           N'' , -- TBML_ID - nvarchar(50)
			           N''  -- PLCode - nvarchar(50)
			         )
            DECLARE @lock_flag nvarchar(50)
            SELECT @lock_flag=Lock_Flag FROM T_Bllb_StockInfo_tbsi WHERE SerialNumber='{1}'
            IF @lock_flag='7'
            BEGIN
                SELECT @WoCode=b.WoCode,@sfcno=a.SfcNo,@line=b.Line
			    FROM dbo.T_Bllb_productInfo_tbpi AS a 
			    LEFT JOIN dbo.SfcDatProduct AS b ON a.SfcNo=b.SfcNo 
			    LEFT JOIN dbo.T_Bllb_StockInfo_tbsi AS c ON c.SerialNumber=a.SERIAL_NUMBER 
			    WHERE a.SERIAL_NUMBER='{1}'

                INSERT into PUB_UniqueCodeInLine(WorkOrderNo,MOrderNo,UniqueCode,MatrCode,Qty,Supplier,lotno)
			    SELECT @WoCode,@sfcno,a.SERIAL_NUMBER,c.MaterialCode,c.QTY,c.SupplierCode,c.Lot_No 
			    FROM dbo.T_Bllb_productInfo_tbpi AS a 
			    LEFT JOIN dbo.SfcDatProduct AS b ON a.SfcNo=b.SfcNo 
			    LEFT JOIN dbo.T_Bllb_StockInfo_tbsi AS c ON c.SerialNumber=a.SERIAL_NUMBER 
			    WHERE a.SERIAL_NUMBER='{0}'

                UPDATE PUB_UniqueCodeInLine SET qty=qty-CAST('{2}' AS int) WHERE UniqueCode='{1}'
                UPDATE JIT_BufferMaterial SET qty=qty-CAST('{2}' AS int) WHERE UniqueCode='{1}'

                INSERT INTO JIT_BufferMaterial(CallOrderNo,LineName,WorkOrderNo,MOrderNo,UniqueCode,MatrCode,Qty,SysOwner,CreateTime)
                --select '',line,wocode,sfcno,reelid,partnumber,qty,'{4}',getdate() from mdcdatvstorage where reelid='{0}'
			    SELECT  '',@line,@WoCode,@sfcno,SerialNumber,MaterialCode,QTY,'{3}',GETDATE() FROM dbo.T_Bllb_StockInfo_tbsi WHERE SerialNumber='{0}'

                UPDATE PVS_Busi_LoadingList SET leftqty=leftqty-CAST('{2}' AS INT) where UniqueCode='{1}'
                UPDATE PVS_Busi_LoadingList SET standbyqty=standbyqty-CAST('{2}' AS INT) where standbycode='{1}'
            END", new_reelid, old_reelid, qty, PubUtils.uContext.UserID, temp_guid);
            #region 
            //builder.Append(string.Format(@"
            //--更新分盘后的新条码的数量和Reelid
            //update MdcDatVStorage set reelid='{0}',[status]='1',GRTime = getdate(),qty={3},grqty={3},updatetime=getdate(),updator='{4}' where reelid='{1}'
            //--更新旧盘的数量
            //update MdcDatVStorage set qty=qty-{3} where reelid='{2}' 
            // --增加SyssystemLog日志 nancy 2017.07.27
            // insert SyssystemLog(Fguid,line,WoCode,SfcNo,ProuctCode,PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,Remarks,Creator)
            // select newid(),line,WoCode,SfcNo,'',PartNumber,ReelID,pocode,SupplierID,HouseCode,Qty,'MES料卷分盘,原始料盘:{2}','{4}'  from mdcdatvstorage where reelid='{0}'
            //insert into sfcdatcutlog(fguid,oldreelid,newreelid,creator,createtime) values(newid(),'{2}','{0}','{4}',getdate())         
            //declare @housecode nvarchar(50)
            //select @housecode=housecode from mdcdatvstorage where reelid='{2}'
            //if @housecode='003' or @housecode='006'
            //begin
            //insert into PUB_UniqueCodeInLine(WorkOrderNo,MOrderNo,UniqueCode,MatrCode,Qty,Supplier,lotno)
            //select wocode,sfcno,reelid,partnumber,qty,SupplierID,batch1 from mdcdatvstorage where reelid='{0}'

            //update PUB_UniqueCodeInLine set qty=qty-{3} where UniqueCode='{2}'
            //update JIT_BufferMaterial set qty=qty-{3} where UniqueCode='{2}'

            //insert into JIT_BufferMaterial(CallOrderNo,LineName,WorkOrderNo,MOrderNo,UniqueCode,MatrCode,Qty,SysOwner,CreateTime)
            //select '',line,wocode,sfcno,reelid,partnumber,qty,'{4}',getdate() from mdcdatvstorage where reelid='{0}'

            //update PVS_Busi_LoadingList set leftqty=leftqty-{3} where UniqueCode='{2}'

            //update PVS_Busi_LoadingList set standbyqty=standbyqty-{3} where standbycode='{2}'

            //end
            //", newReelid, CGUID, oldReelid, qty, CIT.MES.PubUtils.uContext.UserName)); 
            #endregion
            return builder.ToString();
        }
        /// <summary>
        /// 获得拷贝语句
        /// </summary>
        /// <param name="reelid"></param>
        /// <returns></returns>
        private string GetCopySqlFromOldBarcode(string reelid)
        {
            string str_pre_sql = string.Format(@"
BEGIN TRY
DECLARE @new_Barcode NVARCHAR(50)
SET @new_Barcode=NEWID()
	INSERT INTO dbo.T_Bllb_StockInfo_tbsi
	        ( Storage_SN ,Area_SN ,Location_SN ,MaterialCode ,QTY ,Lock_Flag , Enable ,In_Time ,SerialNumber ,Scrapt_Time ,Lock_Time ,
	          Status_Flag ,PLCode ,Reback_Flag ,DateCode ,Finally_Time,Out_Time ,Lot_No ,QC_Result ,MaterialModel ,SfcNo,SupplierCode,MPN ,
	          Version ,TBS_ID)
	SELECT Storage_SN ,Area_SN ,Location_SN ,MaterialCode ,QTY ,Lock_Flag , Enable ,In_Time ,@new_Barcode ,Scrapt_Time ,Lock_Time ,
	          Status_Flag ,PLCode ,Reback_Flag ,DateCode ,Finally_Time,Out_Time ,Lot_No ,QC_Result ,MaterialModel ,SfcNo,SupplierCode,MPN ,
	          Version ,TBS_ID FROM dbo.T_Bllb_StockInfo_tbsi WHERE SerialNumber='{0}'
SELECT '1',@new_Barcode return
END TRY
BEGIN CATCH
SELECT '0','参数错误' return
END CATCH", reelid);
            return str_pre_sql;
        }

    }
}
