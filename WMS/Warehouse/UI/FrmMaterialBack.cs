using CIT.Client;
using CIT.MES;
using Common.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse.BLL;

namespace Warehouse.UI
{
    public partial class FrmMaterialBack : BaseForm
    {
        string _iqc_doc = string.Empty;

        string _before_Doc_NO = string.Empty;

        string _materialCode = string.Empty;
        //制令单
        string sfcNo = string.Empty;

        int _qty = 0;

        string _s_doc_no = string.Empty;
        /// <summary>
        /// 退料单
        /// </summary>
        DataTable dt_return_doc = new DataTable();
        public FrmMaterialBack()
        {
            InitializeComponent();
        }

        private void txt_Begin_LocationSN_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                //if (Bll_Bllb_StorageDocDetail_tbsdd.IsReturn(txt_Begin_LocationSN.Text.Trim()).Rows.Count > 0)
                //{
                //    new PubUtils().ShowNoteNGMsg("物料SN已退料", 1, grade.OrdinaryError);
                //    return;
                //}
                //校验物料SN是否在库
                string check_IsInStock = string.Format(" Where SerialNumber='{0}' and Lock_Flag='7'", txt_Begin_LocationSN.Text.Trim());
                DataTable dt_isInStock = Bll_Bllb_StockInfo_tbsi.QueryStock(check_IsInStock);
                if (dt_isInStock.Rows.Count > 0)
                {
                     sfcNo = SqlInput.ChangeNullToString(dt_isInStock.Rows[0]["SfcNo"]);
                    //输入物料SN生成退料单据号
                     dt_return_doc = Bll_Bllb_StorageDocDetail_tbsdd.Create_Return_Doc(txt_Begin_LocationSN.Text.Trim());
                    if (dt_return_doc.Rows[0]["Result"].ToString() == "0")
                    {
                        new PubUtils().ShowNoteNGMsg("物料SN不在发料单中", 1, grade.OrdinaryError);
                        return;
                    }
                    _s_doc_no = dt_return_doc.Rows[0]["S_Doc_NO"].ToString();
                    _before_Doc_NO = dt_return_doc.Rows[0]["Before_Doc_NO"].ToString();//发料单
                    _materialCode = dt_return_doc.Rows[0]["MaterialCode"].ToString();
                    //_iqc_doc = Bll_Bllb_IQCDoc_tbid.GetIqcDocByMaterialCode(_materialCode, _before_Doc_NO);//输入料号生成退料送检单(屏蔽生成送检单)
                    DataTable DIP_Qty = Bll_Bllb_StorageDocDetail_tbsdd.Query_SN_Qty(txt_Begin_LocationSN.Text.Trim(), _materialCode);
                    if (DIP_Qty.Rows.Count > 0)
                    {
                        txt_Qty.Text = DIP_Qty.Rows[0]["Qty"].ToString();
                        txt_Qty.Focus();
                        txt_Qty.ReadOnly = false;
                    }
                    else
                    {
                        DataTable SMT_Qty = Bll_Bllb_StockInfo_tbsi.Query_SN_Qty(txt_Begin_LocationSN.Text.Trim(), _materialCode);
                        if (SMT_Qty.Rows.Count > 0)
                        {
                            txt_Qty.Text = SMT_Qty.Rows[0]["Qty"].ToString();
                            txt_Qty.Focus();
                            txt_Qty.ReadOnly = false;
                        }
                    }
                  
                }
                else
                {
                    new PubUtils().ShowNoteNGMsg("物料状态不对或物料SN错误", 2, grade.OrdinaryError);
                    return;
                }
            }
        }       
        private void txt_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txt_Begin_LocationSN.Text == string.Empty)
                {
                    new PubUtils().ShowNoteNGMsg("物料SN不能为空", 2, grade.OrdinaryError);
                    return;
                }
                if (!(int.TryParse(txt_Qty.Text.Trim(), out _qty)))
                {
                    new PubUtils().ShowNoteNGMsg("数量只能为数字", 2, grade.OrdinaryError);
                    return;
                }

                //DataTable dt_Return_Doc = Bll_Bllb_StorageDocDetail_tbsdd.Create_Return_Doc(txt_Begin_LocationSN.Text.Trim());
                //_s_doc_no = dt_Return_Doc.Rows[0]["S_DOC_NO"].ToString();    
     
                if (dt_return_doc.Rows[0]["Flag"].ToString() == "0")//如果根据发料单当天存在退料单且没关闭则不用新增退料单
                {
                    if (Bll_Bllb_StorageDocDetail_tbsdd.Insert_Return_Doc(_s_doc_no, _materialCode, _qty, txt_Begin_LocationSN.Text.Trim(), _iqc_doc, _before_Doc_NO))
                    {                    
                        Bll_Bllb_StorageDocDetail_tbsdd.Write_Material_Log(txt_Begin_LocationSN.Text.Trim(), _materialCode, _qty, sfcNo);
                        new PubUtils().ShowNoteOKMsg("退料成功");
                    }
                }
                else if (dt_return_doc.Rows[0]["Flag"].ToString() == "1")
                {
                    if (Bll_Bllb_StorageDocDetail_tbsdd.Insert_S_Doc_No(_s_doc_no, _before_Doc_NO, _materialCode, _qty, txt_Begin_LocationSN.Text.Trim(), _iqc_doc))
                    {
                        Bll_Bllb_StorageDocDetail_tbsdd.Write_Material_Log(txt_Begin_LocationSN.Text.Trim(), _materialCode, _qty, sfcNo);
                        new PubUtils().ShowNoteOKMsg("退料成功");
                    }
                }
                txt_Begin_LocationSN.SelectAll();
                txt_Begin_LocationSN.Focus();
                //打印条码 注释掉
                #region
                //DataTable dt_storageInfo = Bll_Bllb_StockInfo_tbsi.QueryStockMatr(txt_Begin_LocationSN.Text.Trim());
                //string matrCode = string.Empty;
                //string dateCode = string.Empty;
                //string supplierCode = string.Empty;
                //if (dt_storageInfo.Rows.Count > 0)
                //{
                //    matrCode = SqlInput.ChangeNullToString( dt_storageInfo.Rows[0]["MaterialCode"]);
                //    dateCode = SqlInput.ChangeNullToString(dt_storageInfo.Rows[0]["DateCode"]);
                //    supplierCode = SqlInput.ChangeNullToString(dt_storageInfo.Rows[0]["MPN"]);
                //}
                //Model.Model_MaterialBarCode bar = new Model.Model_MaterialBarCode();
                //Dictionary<string, string> dic = new Dictionary<string, string>();
                //bar.QRCODE = txt_Begin_LocationSN.Text.Trim();//物料SN
                //dic.Add("QRCODE", bar.QRCODE);
                //bar.QTY = txt_Qty.Text.Trim();//数量
                //dic.Add("QTY", bar.QTY);
                //bar.MaterialCode = matrCode;//料号
                //dic.Add("MaterialCode", bar.MaterialCode);
                //bar.BEGIN_DATE = dateCode;//Datecode
                //dic.Add("BEGIN_DATE", bar.BEGIN_DATE);
                //bar.MPN = supplierCode;//供应商料号
                //dic.Add("MPN", bar.MPN);
                //Common.BLL.Bll_Print.PrintTemplet("安费诺来料打印", dic);
                //bar = new Model_MaterialBarCode();
                #endregion
                txt_Qty.Text = string.Empty;
                txt_Qty.ReadOnly = true;
                txt_Begin_LocationSN.Text = string.Empty;
            }
        }

        private void FrmMaterialBack_Load(object sender, EventArgs e)
        {
            txt_Qty.ReadOnly = true;
        }

        private void txt_Begin_LocationSN_TextChange(object sender, EventArgs e)
        {
            txt_Qty.Text = string.Empty;
        }
    }
}
