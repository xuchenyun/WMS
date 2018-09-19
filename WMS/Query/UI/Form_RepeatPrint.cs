using CIT.Client;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Query.UI
{
    public partial class Form_RepeatPrint : Form
    {
        public Form_RepeatPrint()
        {
            InitializeComponent();
        }

        private void txtQrcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(txtQrcode.Text.Trim()))
                {
                    new CIT.MES.PubUtils().ShowNoteNGMsg("SN不能为空", 2, CIT.MES.grade.OrdinaryError);
                    return;
                }
                string strSql = string.Format(@"
IF NOT EXISTS ( SELECT  *
                FROM    dbo.T_Bllb_StorageDocDetail_tbsdd
                WHERE   SerialNumber = '{0}' )
    BEGIN
        SELECT  '0' ,
                'Reelid未清点过，无法重打'
        RETURN
    END
ELSE
    BEGIN
        IF NOT EXISTS ( SELECT  *
                        FROM    dbo.T_Bllb_StockInfo_tbsi
                        WHERE   SerialNumber = '{0}'
                                AND Lock_Flag IN ( '0', '7' ) )
            BEGIN
                SELECT  '0' ,
                        '此Reelid不允许重打'
                RETURN
            END
        SELECT  1 ,
                a.PO ,
                c.*,D.QTY NOW_QTY
        FROM    dbo.T_Bllb_POMain_tbpm AS a
                INNER JOIN dbo.T_Bllb_PODetail_tbpd AS b ON a.POID = b.POID
                INNER JOIN T_Bllb_StorageDocDetail_tbsdd AS c ON c.PO_DetailID = b.PO_DetailID
	            INNER JOIN T_Bllb_StockInfo_tbsi D ON D.SerialNumber=C.SerialNumber
        WHERE   c.SerialNumber = '{0}'
        RETURN
    END 
    ", txtQrcode.Text.Trim());
                DataTable dtQRCode = CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, strSql);
                if (dtQRCode.Rows.Count == 0)
                {
                    MsgBox.Error("DB数据异常");
                    txtQrcode.SelectAll();
                    return;
                }
                if (dtQRCode.Rows[0][0].ToString() == "0")
                {
                    MsgBox.Error(dtQRCode.Rows[0][1].ToString());
                    txtQrcode.SelectAll();
                    return;
                }
                Model.Model_MaterialBarCode bar = new Model.Model_MaterialBarCode();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                bar.MaterialCode = SqlInput.ChangeNullToString(dtQRCode.Rows[0]["MaterialCode"]);//料号
                dic.Add("MaterialCode", bar.MaterialCode);
                bar.QTY = SqlInput.ChangeNullToString(dtQRCode.Rows[0]["NOW_QTY"]);//数量
                dic.Add("QTY", SqlInput.ChangeNullToString(dtQRCode.Rows[0]["NOW_QTY"]));
                bar.MPN = SqlInput.ChangeNullToString(dtQRCode.Rows[0]["MPN"]);//MPN
                dic.Add("MPN", bar.MPN);
                bar.PO = SqlInput.ChangeNullToString(dtQRCode.Rows[0]["PO"]);//采购订单号
                dic.Add("PO", bar.PO);
                bar.QRCODE = SqlInput.ChangeNullToString(dtQRCode.Rows[0]["SerialNumber"]);//条码
                dic.Add("QRCODE", bar.QRCODE);
                bar.BEGIN_DATE = SqlInput.ChangeNullToString(dtQRCode.Rows[0]["DateCode"]);//DateCode
                dic.Add("BEGIN_DATE", bar.BEGIN_DATE);
                Common.BLL.Bll_Print.PrintTemplet("安费诺来料打印", dic);
                string str_qcode_log = string.Format(@"
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
          '重打标签' , -- OperateType - nvarchar(50)
          '{1}' , -- MaterialCode - nvarchar(50)
          '{2}', -- QTY - int
          '{3}' , -- Creator - nvarchar(50)
          '{4}'  -- TBML_ID - nvarchar(50)
        )", bar.QRCODE, bar.MaterialCode, bar.QTY, CIT.MES.PubUtils.uContext.UserID, Guid.NewGuid().ToString());
                CIT.Wcf.Utils.NMS.ExecTransql(CIT.MES.PubUtils.uContext, str_qcode_log);
                bar = new Model.Model_MaterialBarCode();
                new CIT.MES.PubUtils().ShowNoteOKMsg("打印成功");
                txtQrcode.SelectAll();
            }
        }
    }
}
