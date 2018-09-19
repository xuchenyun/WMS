using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIT.Wcf.Utils;
using CIT.Interface;
using CIT.MES;
using Common.Helper;
using CIT.Client;
using System.Text.RegularExpressions;

namespace Query.UI
{
    public partial class Form_ReelPrint : BaseForm
    {
        /// <summary>
        /// 初始化绑定采购单（数据源来自数据库）
        /// </summary>
        private List<string> lstInit = new List<string>();
        /// <summary>
        /// 输入Key之后返回的采购单
        /// </summary>
        private List<string> lstNew = new List<string>();

        /// <summary>
        /// 初始化绑定物料（数据源来自数据库）
        /// </summary>
        private List<string> lstInitMaterial = new List<string>();
        /// <summary>
        /// 输入Key之后返回的物料
        /// </summary>
        private List<string> lstNewMaterial = new List<string>();
        /// <summary>
        /// 物料信息
        /// </summary>
        Common.BLL.BLL_MdcdatMaterial bll_Material = new Common.BLL.BLL_MdcdatMaterial();
        /// <summary>
        /// 选中行
        /// </summary>
        public DataGridViewRow dgvrSelected { get; set; }
        /// <summary>
        /// PO DetailID
        /// </summary>
        string po_detailid = string.Empty;
        /// <summary>
        /// PO ID
        /// </summary>
        string poid = string.Empty;
        /// <summary>
        /// IQC检验单号    
        /// </summary>
        string iqc_no = string.Empty;
        /// <summary>
        /// 是否送检
        /// </summary>
        bool IsSendCheck = false;

        public Form_ReelPrint()
        {
            InitializeComponent();
        }

        //输入完毕，开始打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                //验证通过
                //执行打印
                Printing();
            }
        }

        //输入完毕，开始打印
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (Validation())
                {
                    //验证通过
                    //执行打印
                    Printing();
                }
            }
        }

        /// <summary>
        /// 验证输入的资料是否有问题
        /// </summary>
        /// <returns></returns>
        private bool Validation()
        {
            #region 校验输入
            if (string.IsNullOrEmpty(txt_MaterialCode.Text.Trim()))
            {
                new PubUtils().ShowNoteNGMsg("请输入物料编码！", 1, grade.SevereError);
                return false;
            }
            if (string.IsNullOrEmpty(txt_MinPackage.Text.Trim()))
            {
                new PubUtils().ShowNoteNGMsg("未获取最小包装数！", 1, grade.SevereError);
                return false;
            }
            if (string.IsNullOrEmpty(txt_Qty.Text.Trim()))
            {
                txt_Qty.Focus();
                new PubUtils().ShowNoteNGMsg("请输入数量！", 1, grade.SevereError);
                return false;
            }
            if (txt_PO.Text == string.Empty)
            {
                new PubUtils().ShowNoteNGMsg("请选择采购单", 1, grade.SevereError);
                return false;
            }
            //if (string.IsNullOrEmpty(txtLotNo.Text.Trim()))
            //{
            //    new PubUtils().ShowNoteNGMsg("请输入LotNo", 1, grade.SevereError);
            //    return false;
            //}
            if (string.IsNullOrEmpty(txt_MPN.Text.Trim()))
            {
                new PubUtils().ShowNoteNGMsg("请输入MPN", 1, grade.SevereError);
                return false;
            }
            int Qty;
            if (!int.TryParse(txt_Qty.Text.Trim(), out Qty))
            {
                new PubUtils().ShowNoteNGMsg("来料数量为数字", 1, grade.SevereError);
                return false;
            }
            if (Qty <= 0)
            {
                new PubUtils().ShowNoteNGMsg("来料数量为正整数", 1, grade.SevereError);
                return false;
            }
            if (txt_Qty.Text.Trim().Contains('.'))
            {
                new PubUtils().ShowNoteNGMsg("来料数量不能为小数", 1, grade.SevereError);
                return false;
            }
            if (txt_DateCode.Text.Trim().Length != 8)
            {
                new PubUtils().ShowNoteNGMsg("DateCode八位有效", 1, grade.SevereError);
                return false;
            }
            if (!Regex.IsMatch(txt_DateCode.Text.Trim(), @"(([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})(((0[13578]|1[02])(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)(0[1-9]|[12][0-9]|30))|(02(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))0229)"))
            {
                //new PubUtils().ShowNoteNGMsg("DateCode格式yyyyMMdd", 1, grade.SevereError);
                MsgBox.Error("DateCode格式yyyyMMdd");
                return false;
            }
            string sql_check_mpn = string.Format(@"
SELECT  LocalMaterialCode ,
        SupplyMaterialCode,
        Supply,
        Remark,
        TBMR_ID
FROM[dbo].[T_Bllb_MaterialRelation_Tbmr] {0}", string.Format(" where SupplyMaterialCode='{0}' and LocalMaterialCode='{1}' ", txt_MPN.Text.Trim(), txt_MaterialCode.Text.Trim()));
            if (NMS.QueryDataTable(PubUtils.uContext, sql_check_mpn).Rows.Count == 0)
            {
                new PubUtils().ShowNoteNGMsg("物料关系不存在", 1, grade.SevereError);
                return false;
            }
            #endregion
            #region 校验采购单是否关闭、 清点数量
            DataTable dt_po = NMS.QueryDataTable(PubUtils.uContext, "select Status,POID from T_Bllb_POMain_tbpm where PO='" + txt_PO.Text.Trim() + "'");
            if (SqlInput.ChangeNullToString(dt_po.Rows[0][0]) == "2")
            {
                new PubUtils().ShowNoteNGMsg("来料所属采购单已关闭", 1, grade.SevereError);
                return false;
            }
            else
            {
                poid = SqlInput.ChangeNullToString(dt_po.Rows[0]["POID"]);
            }
            string strSql = string.Format(@"
SELECT  PO_DetailID ,
        Quantity ,
        ClearQty
FROM    dbo.T_Bllb_PODetail_tbpd
WHERE   PO_DetailID = '{0}'", dgvrSelected.Cells["PO_DetailID"].Value.ToString());
            DataTable dt_podetail = NMS.QueryDataTable(PubUtils.uContext, strSql);
            if (dt_podetail.Rows.Count == 0)
            {
                new PubUtils().ShowNoteNGMsg("采购单中不存在此物料", 1, grade.SevereError);
                return false;
            }
            else
            {
                if (SqlInput.ChangeNullToInt(dt_podetail.Rows[0]["Quantity"], 0) < SqlInput.ChangeNullToInt(dt_podetail.Rows[0]["ClearQty"], 0) + SqlInput.ChangeNullToInt(txt_Qty.Text.Trim(), 0))
                {
                    //new PubUtils().ShowNoteNGMsg(string.Format("采购订单{0}清点数量将会超过计划数", txt_MaterialCode.Text.Trim()), 1, grade.SevereError);
                    MsgBox.Error(string.Format("采购订单{0}清点数量将会超过计划数", txt_MaterialCode.Text.Trim()));
                    return false;
                }
                po_detailid = dt_podetail.Rows[0][0].ToString();
            }
            #endregion
            //return false;//测试用
            return true;//正式用
        }

        //执行打印
        private void Printing()
        {

            #region 采购清点
            string doc_no = string.Empty;//清点单号
            string MaterialCode = txt_MaterialCode.Text.Trim(); //料号
            int qty = 0;
            qty = SqlInput.ChangeNullToInt(txt_Qty.Text, 0);//数量
            //判断清点单是否已生成，若无则自动生成清点单
            DataTable dt_doc = NMS.QueryDataTable(PubUtils.uContext, string.Format("SELECT S_Doc_NO  FROM T_Bllb_StorageDoc_tbsd WHERE PO='{0}'and DATEDIFF(DAY,GETDATE(),Create_Time)=0 AND S_Doc_Type='1' AND Close_Flag='N' ORDER BY Create_Time DESC", txt_PO.Text.Trim()));
            if (dt_doc.Rows.Count == 0)
            {
                dt_doc = NMS.QueryDataTable(PubUtils.uContext, "SELECT  TOP 1 RIGHT(S_Doc_NO,4)+1  FROM T_Bllb_StorageDoc_tbsd WHERE DATEDIFF(DAY,GETDATE(),Create_Time)=0  AND S_Doc_Type='1' ORDER BY Create_Time DESC");
                if (dt_doc.Rows.Count > 0)
                {
                    doc_no = "QD" + DateTime.Now.ToString("yyMMdd") + SqlInput.ChangeNullToInt(dt_doc.Rows[0][0], 0).ToString("0000");
                }
                else
                {
                    doc_no = "QD" + DateTime.Now.ToString("yyMMdd") + "0001";
                }

                string sql_qd_insert = string.Format(@"INSERT INTO dbo.T_Bllb_StorageDoc_tbsd
                                                    ( S_Doc_NO ,
                                                      S_Doc_Type ,
                                                      Create_Time ,
                                                      Creator ,
                                                      PO ,
                                                      POID
                                                    )
                                            VALUES  ( '{0}' , -- S_Doc_NO - nvarchar(50)
                                                      '1' , -- S_Doc_Type - nvarchar(10)
                                                      GETDATE() , -- Create_Time - datetime
                                                      '{1}' , -- Creator - nvarchar(50)
                                                      '{2}' , -- PO - nvarchar(50)
                                                      '{3}' -- POID - nvarchar(50)      
                                                    )", doc_no, PubUtils.uContext.UserID, txt_PO.Text.Trim(), poid);

                NMS.ExecTransql(PubUtils.uContext, sql_qd_insert);
            }
            else
            {
                doc_no = dt_doc.Rows[0][0].ToString();
            }
            int totalQty = 0;
            string sql_exist = string.Format(@"SELECT S_Doc_NO,QTY FROM T_Bllb_StorageDocMaterial_tsdm WHERE S_Doc_NO='{0}' and MaterialCode='{1}'", doc_no, txt_MaterialCode.Text.Trim());
            //判断清点单中是否已存在某物料
            DataTable dt_doc_material = NMS.QueryDataTable(PubUtils.uContext, sql_exist);
            if (dt_doc_material.Rows.Count == 0)
            {
                string sql_insert = string.Format(@"INSERT INTO dbo.T_Bllb_StorageDocMaterial_tsdm
                                                    ( S_Doc_NO ,
                                                      MaterialCode ,
                                                      QTY ,
                                                      PO_DetailID 
                                                    )
                                            VALUES  ( '{0}' , -- S_Doc_NO - nvarchar(50)
                                                      '{1}' , -- MaterialCode - nvarchar(50)
                                                       {2} , -- QTY - int
                                                      '{3}'  -- PO_DetailID - nvarchar(50) 
                                                    )", doc_no, MaterialCode, qty, po_detailid);

                NMS.ExecTransql(PubUtils.uContext, sql_insert);
                totalQty = qty;
            }
            else
            {
                string sql_update = string.Format(@"UPDATE T_Bllb_StorageDocMaterial_tsdm SET QTY=QTY+{1} WHERE S_Doc_NO='{0}' and MaterialCode='{2}'", doc_no, qty, txt_MaterialCode.Text.Trim());
                NMS.ExecTransql(PubUtils.uContext, sql_update);
                totalQty = SqlInput.ChangeNullToInt(dt_doc_material.Rows[0]["QTY"].ToString(), 0) + qty;
            }
            if (IsSendCheck)
            {
                //判断是否存在IQC单据若无，则新增
                iqc_no = string.Empty;//IQC检验单号                 
                string sql_iqc_no = string.Format(@"
SELECT  [IQC_NO]
FROM    T_Bllb_IQCDoc_tbid
WHERE   S_DOC_NO = '{0}'
        AND OVER_FLAG = 'N'
        AND CREATE_TIME >= CONVERT(CHAR(10), GETDATE(), 120)
        AND Type = 'IQC' AND MaterialCode='{1}'", doc_no, txt_MaterialCode.Text.Trim());
                DataTable dt_IQC = NMS.QueryDataTable(PubUtils.uContext, sql_iqc_no);
                if (dt_IQC.Rows.Count > 0)//修改送检数量
                {
                    iqc_no = dt_IQC.Rows[0][0].ToString();
                    string sql_iqc_update = string.Format(@"UPDATE T_Bllb_IQCDoc_tbid SET QTY=QTY+{1} WHERE IQC_NO='{0}' AND MaterialCode='{2}'", iqc_no, txt_Qty.Text.Trim(), txt_MaterialCode.Text.Trim());
                    NMS.ExecTransql(PubUtils.uContext, sql_iqc_update);
                }
                else//新增IQC单据
                {
                    DataTable dt_iqcwater = NMS.QueryDataTable(PubUtils.uContext, @"
SELECT TOP 1
        RIGHT(IQC_NO, 4) + 1
FROM    T_Bllb_IQCDoc_tbid
WHERE   CREATE_TIME >= CONVERT(CHAR(10), GETDATE(), 120)
        AND Type = 'IQC'
ORDER BY IQC_NO DESC ");
                    if (dt_iqcwater.Rows.Count > 0)
                    {
                        iqc_no = "IQC" + DateTime.Now.ToString("yyMMdd") + SqlInput.ChangeNullToInt(dt_iqcwater.Rows[0][0], 0).ToString("0000");
                    }
                    else
                    {
                        iqc_no = "IQC" + DateTime.Now.ToString("yyMMdd") + "0001";//IQC检验单号
                    }
                    string sql_iql_insert = string.Format(@"INSERT INTO dbo.T_Bllb_IQCDoc_tbid
                                                    ( IQC_NO ,
                                                      MaterialCode ,         
                                                      QTY ,     
                                                      CREATE_TIME ,   
		                                              S_DOC_NO,
		                                              PO
                                                    )
                                            VALUES  ( '{0}' , 
                                                      '{1}' ,  
                                                      {2} ,      
                                                      GETDATE() ,
		                                              '{3}',
		                                              '{4}' 
                                                    )", iqc_no, MaterialCode, qty, doc_no, txt_PO.Text.Trim());
                    NMS.ExecTransql(PubUtils.uContext, sql_iql_insert);
                }
            }
            //采购单物料清点数累计
            string sql_qd = string.Format(@" UPDATE T_Bllb_PODetail_tbpd SET ClearQty= ISNULL(ClearQty,0)+{2}  WHERE PO='{0}'  and MaterialCode='{1}'", txt_PO.Text.Trim(), MaterialCode, qty);
            NMS.ExecTransql(PubUtils.uContext, sql_qd);
            #endregion

            int MinQty = SqlInput.ChangeNullToInt(txt_MinPackage.Text.Trim(), 0);
            int TotalQty = SqlInput.ChangeNullToInt(txt_Qty.Text.Trim(), 0);
            int packageQty = TotalQty / MinQty;
            int lastQty = TotalQty % MinQty;
            if (lastQty > 0)
            {
                packageQty++;
            }
            string snString = string.Empty;
            string barCodeString = string.Empty;
            Model.Model_MaterialBarCode bar = new Model.Model_MaterialBarCode();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 1; i <= packageQty; i++)//循环打印条码
            {
                dic.Clear();
                snString = GetSnNumber(); //getSN();
                if (string.IsNullOrEmpty(snString))
                {
                    new PubUtils().ShowNoteNGMsg("获取流水码失败！", 1, grade.SevereError);
                    return;
                }
                bar.MaterialCode = txt_MaterialCode.Text.Trim();//物料代码
                dic.Add("MaterialCode", bar.MaterialCode);
                if (i == packageQty && lastQty != 0)
                {
                    bar.QTY = lastQty.ToString();//数量
                    dic.Add("QTY", lastQty.ToString());
                }
                else
                {
                    bar.QTY = MinQty.ToString();//数量
                    dic.Add("QTY", MinQty.ToString());
                }
                bar.BEGIN_DATE = txt_DateCode.Text.Trim();//生产日期
                dic.Add("BEGIN_DATE", bar.BEGIN_DATE);
                bar.PO = txt_PO.Text.Trim();//采购订单号
                dic.Add("PO", bar.PO);
                bar.MPN = txt_MPN.Text.Trim();//MPN
                dic.Add("MPN", bar.MPN);
                bar.SN = snString;
                dic.Add("SN", bar.SN);
                bar.QRCODE = snString;
                dic.Add("QRCODE", bar.QRCODE);
                string sql_detail_insert = string.Format(@"
                                        INSERT INTO dbo.T_Bllb_StorageDocDetail_tbsdd
                                                ( S_Doc_NO ,
                                                  MaterialCode ,
                                                  QTY ,
                                                  Create_Time ,
                                                  Creator ,
                                                  SerialNumber ,  
                                                  PO_DetailID,
                                                  Lot_No,
                                                  MPN,
                                                  DateCode,
                                                  Version
                                                )
                                        VALUES  ( '{0}' , -- S_Doc_NO - nvarchar(50)
                                                  '{1}' , -- MaterialCode - nvarchar(50)
                                                  {2} , -- QTY - int
                                                  GETDATE() , -- Create_Time - datetime
                                                  '{3}' , -- Creator - nvarchar(50)
                                                  '{4}' , -- SerialNumber - nvarchar(50)   
                                                  '{5}',  -- PO_DetailID - nvarchar(50)
                                                  '{6}',
                                                  '{7}',
                                                  '{8}',
                                                  '{9}'
                                                )", doc_no, MaterialCode, bar.QTY, PubUtils.uContext.UserID, bar.QRCODE, po_detailid, txtLotNo.Text.Trim(), txt_MPN.Text.Trim(), txt_DateCode.Text.Trim(), txtVersion.Text.Trim());
                NMS.ExecTransql(PubUtils.uContext, sql_detail_insert);
                string sql_barcode_log = string.Format(@"
INSERT INTO dbo.T_Bllb_MaterialLog_tbml
        ( SerialNumber ,
          CreateTime ,
          OperateType ,
          MaterialCode ,
          QTY ,
          Creator ,
          TBML_ID 
        )
VALUES  ( '{0}' , -- SerialNumber - nvarchar(200)
          GETDATE() , -- CreateTime - datetime
          '清点' , -- OperateType - nvarchar(50)
          '{1}' , -- MaterialCode - nvarchar(50)
          '{2}', -- QTY - int
          '{3}' , -- Creator - nvarchar(50)
          '{4}'  -- TBML_ID - nvarchar(50)
        )", bar.QRCODE, txt_MaterialCode.Text.Trim(), bar.QTY, PubUtils.uContext.UserID, Guid.NewGuid().ToString());
                NMS.ExecTransql(PubUtils.uContext, sql_barcode_log);
                if (IsSendCheck)
                {
                    //保存物料SN到IQC单据中
                    string sql_sn_iqc = string.Format(@"
                INSERT INTO T_Bllb_IQCProduct_tbip(
                                        TBIP_ID,
                                        IQC_NO,
                                        SERIAL_NUMBER,
                                        QTY)
                                        VALUES( 
                                        '{0}',
                                        '{1}',
                                        '{2}',{3})",
                                   Guid.NewGuid(), iqc_no, bar.QRCODE, bar.QTY
                                    );
                    NMS.ExecTransql(PubUtils.uContext, sql_sn_iqc);
                }
                Common.BLL.Bll_Print.PrintTemplet("安费诺来料打印", dic);
                bar = new Model.Model_MaterialBarCode();
            }
            new PubUtils().ShowNoteOKMsg("打印成功");
            ClearControl();
            txt_MPN.Focus();
        }

        //获取SN
        private string getSN()
        {
            string snString = string.Empty;
            string yymmddString = DateTime.Now.ToString("yyyyMMdd");

            //执行存储过程，将流水码+1
            CmdParameter[] parms = {
                new CmdParameter(){ ParameterName="@KEYNAME", Value="ReelPrt"}
                                 };
            bool flag = CIT.Wcf.Utils.NMS.ExecProcedures(PubUtils.uContext, "ITCounter", CommandType.StoredProcedure, true, parms);

            //获取到流水码
            StringBuilder sqlSelect = new StringBuilder();
            sqlSelect.Append(" SELECT ");
            sqlSelect.Append("        RIGHT(CAST('00000'+RTRIM(keycount) AS VARCHAR(20)), ");
            sqlSelect.Append("        CASE WHEN LEN(keycount)<6 THEN 6 ELSE LEN(keycount) END) keycount  ");
            sqlSelect.Append("   FROM dbo.Ncounter  ");
            sqlSelect.Append("  WHERE     keyyear = '").Append(yymmddString).Append("'");
            sqlSelect.Append("        AND keyname = 'ReelPrt'  ");

            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, sqlSelect.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                snString = yymmddString + dt.Rows[0][0].ToString();
            }
            return snString;
        }
        public string GetSnNumber()
        {

            string sqlNumber = string.Format(@"
                begin TRAN
	                DECLARE @KEYYEAR NVARCHAR(8);--YMD
		            DECLARE @KEYNAME NVARCHAR(50);
		            DECLARE @KEYNUMBER NVARCHAR(50);
		            SELECT @KEYNAME ='ReelPrt'
                    SELECT @KEYYEAR = CONVERT(NVARCHAR(8), GETDATE(),112);
                --删除小于当天的资料
                    DELETE FROM dbo.Ncounter WHERE keyname = @KEYNAME AND CONVERT(DATETIME,keyyear) < CONVERT(DATETIME,@KEYYEAR)
    
                    IF exists(
                    SELECT TOP 1 keycount FROM dbo.Ncounter  WHERE keyyear = @KEYYEAR AND keyname = @KEYNAME
                    )
	                BEGIN
                        UPDATE dbo.Ncounter 
                        SET keycount = keycount  + 1 
                        WHERE keyyear = @KEYYEAR AND keyname = @KEYNAME
	                END
                    ELSE
	                BEGIN
                        INSERT INTO dbo.Ncounter
                        (keyname , keyyear , keycount)
                        VALUES
                        (@KEYNAME , @KEYYEAR ,1 )
	                END
		
	                SELECT @KEYNUMBER = keycount2 FROM (
	                SELECT  RIGHT(CAST('00000'+RTRIM(keycount) AS VARCHAR(20)), CASE WHEN LEN(keycount)<6 THEN 6 ELSE LEN(keycount) END) keycount2
	                FROM dbo.Ncounter WHERE keyyear = @KEYYEAR AND keyname = @KEYNAME ) T
	                SELECT @KEYYEAR + @KEYNUMBER
              
                commit tran
                                            ");
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, sqlNumber);
            return dt.Rows[0][0].ToString();
        }

        #region
        private void txtCusCode_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtItemDes_KeyPress(object sender, KeyPressEventArgs e)
        {

        }




        private void dtpEffectiveDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_Qty.Focus();
            }
        }

        #endregion

        private void Form_ReelPrint_Load(object sender, EventArgs e)
        {
            if (dgvrSelected != null)
            {
                txt_PO.Text = SqlInput.ChangeNullToString(dgvrSelected.Cells["PO订单编号"].Value);
                txt_MaterialCode.Text = SqlInput.ChangeNullToString(dgvrSelected.Cells["料号"].Value);
            }
            string sql_isSendCheck = string.Format(@"SELECT *  FROM dbo.MdcdatMaterial WHERE MaterialCode='{0}'", txt_MaterialCode.Text.Trim());
            DataTable dtCheck = NMS.QueryDataTable(PubUtils.uContext, sql_isSendCheck);
            if (dtCheck.Rows.Count > 0)
            {
                IsSendCheck = SqlInput.ChangeNullToString(dtCheck.Rows[0]["IsSendCheck"]) == "是" ? true : false;
            }
            txt_MPN.Focus();
        }

        private void txt_DateCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符  
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || this.txt_DateCode.Text.Length == 0)//小数点  
                {
                    e.Handled = true;
                }
                if (txt_DateCode.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
            if (!e.Handled)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    SendKeys.Send("\t");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        void ClearControl()
        {
            txt_MPN.Text = string.Empty;
            txt_MinPackage.Text = string.Empty;
            txt_DateCode.Text = string.Empty;
            txtLotNo.Text = string.Empty;
            txt_Qty.Text = string.Empty;
            txtVersion.Text = string.Empty;
            txt_MPN.Focus();
        }

        private void txt_MPN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }

        private void txt_MinPackage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }

        private void txtLotNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }

        private void txtVersion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }
    }
}
