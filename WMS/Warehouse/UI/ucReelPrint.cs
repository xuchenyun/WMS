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

namespace Warehouse.UI
{
    public partial class ucReelPrint : UserControl
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
        public ucReelPrint()
        {
            InitializeComponent();
            //加载页面
            Init();

            //初始化物料数据源

            DataTable dt_Material = BLL.Bll_Bllb_POMain_tbpm.DataBindPO();
            foreach (DataRow dr in dt_Material.Rows)
            {
                lstInit.Add(dr["PO"].ToString());
            }
            cbo_PO.Items.AddRange(lstInit.ToArray());
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //清除
            Reset();
        }

        //加载页面
        private void Init()
        {
            dtpProductionDate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");

        }

        //清除
        private void Reset()
        {
            txt_SUPPLIER_CODE.Text = "";
            txt_MaterialDesc.Text = "";
            cbo_MaterialCode.Text = "";
            txt_Qty.Text = "";
            txtSN.Text = "";
            dtpProductionDate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");

            txt_SUPPLIER_CODE.Focus();
        }

        //验证输入的资料是否有问题
        private bool Validation()
        {
            bool validation = true;

            if (string.IsNullOrEmpty(txt_SUPPLIER_CODE.Text.Trim()))
            {
                validation = false;
                txt_SUPPLIER_CODE.Focus();
                new PubUtils().ShowNoteNGMsg("请输入供应商代码！", 1, grade.SevereError);
                return validation;
            }
            //if (string.IsNullOrEmpty(txt_MaterialDesc.Text.Trim()))
            //{
            //    validation = false;
            //    txt_MaterialDesc.Focus();
            //    new PubUtils().ShowNoteNGMsg("未能获取物料描述！", 1, grade.SevereError);
            //    return validation;
            //}
            if (string.IsNullOrEmpty(cbo_MaterialCode.Text.Trim()))
            {
                validation = false;
                cbo_MaterialCode.Focus();
                new PubUtils().ShowNoteNGMsg("请输入物料编码！", 1, grade.SevereError);
                return validation;
            }
            if (string.IsNullOrEmpty(txt_MinPackage.Text.Trim()))
            {
                validation = false;
                new PubUtils().ShowNoteNGMsg("未获取最小包装数！", 1, grade.SevereError);
                return validation;
            }

            if (string.IsNullOrEmpty(dtpProductionDate.Text.Trim()))
            {
                validation = false;
                dtpProductionDate.Focus();
                new PubUtils().ShowNoteNGMsg("请输入生产日期！", 1, grade.SevereError);
                return validation;
            }

            if (string.IsNullOrEmpty(txt_Qty.Text.Trim()))
            {
                validation = false;
                txt_Qty.Focus();
                new PubUtils().ShowNoteNGMsg("请输入数量！", 1, grade.SevereError);
                return validation;
            }

            try
            {
                DateTime.Parse(dtpProductionDate.Text.Trim());

                Convert.ToInt32(txt_Qty.Text.Trim());
                validation = true;
                return validation;
            }
            catch (Exception ex)
            {
                validation = false;
                new PubUtils().ShowNoteNGMsg(ex.Message, 1, grade.SevereError);
                return validation;
            }

        }

        //执行打印
        private void Printing()
        {

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
                snString = getSN();
                if (string.IsNullOrEmpty(snString))
                {
                    new PubUtils().ShowNoteNGMsg("获取流水码失败！", 1, grade.SevereError);
                    return;
                }

                txtSN.Text = snString;

                barCodeString = snString + "|" + cbo_MaterialCode.Text.Trim() + "|" + txt_Qty.Text.Trim() + "|" + txt_SUPPLIER_CODE.Text.Trim() + "|" + DateTime.Parse(dtpProductionDate.Text.Trim()).ToString("yyyyMMdd");
                bar.SUPPLIER_CODE = txt_SUPPLIER_CODE.Text.Trim();//供应商代码
                dic.Add("SUPPLIER_CODE", bar.SUPPLIER_CODE);
                bar.MaterialCode = cbo_MaterialCode.Text.Split('*')[0];//物料代码
                dic.Add("MaterialCode", bar.MaterialCode);
                bar.RowNumber = cbo_MaterialCode.Text.Split('*')[1];//行号
                dic.Add("RowNumber", bar.RowNumber);
                bar.MaterialDesc = txt_MaterialDesc.Text.Trim();//型号规格
                dic.Add("MaterialDesc", bar.MaterialDesc);
                bar.QTY = MinQty.ToString();//数量
                if (i == packageQty)
                {
                    dic.Add("QTY", lastQty.ToString());
                }
                else
                {
                    dic.Add("QTY", MinQty.ToString());
                }

                bar.BEGIN_DATE = dtpProductionDate.Value.ToString("yyMMdd");//生产日期
                dic.Add("BEGIN_DATE", bar.BEGIN_DATE);
                bar.PO = cbo_PO.Text.Trim();//采购订单号
                dic.Add("PO", bar.PO + "|" + bar.RowNumber);
                bar.SN = snString;
                dic.Add("SN", bar.SN);
                bar.QRCODE = bar.SUPPLIER_CODE + "|" + bar.MaterialCode + "|" + bar.SN + "|Q" + bar.QTY + "|D" + bar.BEGIN_DATE + "|" + bar.PO + "|" + bar.RowNumber;
                dic.Add("QRCODE", bar.QRCODE);
                Common.BLL.Bll_Print.PrintTemplet("来料打印", dic);
            }

            Reset();

        }

        //获取SN
        private string getSN()
        {
            string snString = string.Empty;
            string yymmddString = DateTime.Now.ToString("yyyyMMdd");

            //执行存储过程，将流水码+1
            CmdParameter[] parms = {
                new CmdParameter(){ParameterName="@KEYNAME", Value="ReelPrt"}
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
                snString = "YX" + yymmddString + dt.Rows[0][0].ToString();
            }

            return snString;
        }

        #region
        private void txtCusCode_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtItemDes_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtItems_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dtpProductionDate.Focus();
            }
        }

        private void dtpProductionDate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbo_PO_TextChanged(object sender, EventArgs e)
        {

            ////清空控件数据
            //this.cbo_PO.Items.Clear();
            ////清空过滤数据
            //lstNew.Clear();
            //foreach (string var in lstInit)
            //{
            //    if (var.Contains(cbo_PO.Text))
            //    {
            //        lstNew.Add(var);
            //    }
            //}
            ////模糊查询结果绑定
            //this.cbo_PO.Items.AddRange(lstNew.ToArray());
            ////设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒叙排序
            //cbo_PO.SelectionStart = cbo_PO.Text.Length;
            ////保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置
            //Cursor = Cursors.Default;
            ////自动弹出下拉框
            //cbo_PO.DroppedDown = true;

        }

        private void cbo_PO_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_MaterialDesc.Text = string.Empty;
            //初始化物料数据源
            lstInitMaterial.Clear();
            cbo_MaterialCode.Items.Clear();
            lstNewMaterial.Clear();
            DataTable dt_Material = BLL.Bll_Bllb_POMain_tbpm.GetList(cbo_PO.Text);
            if (dt_Material.Rows.Count > 0)
            {
                foreach (DataRow dr in dt_Material.Rows)
                {
                    lstInitMaterial.Add(dr["MaterialCode"].ToString() + "*" + dr["RowNumber"].ToString());
                }

                txt_SUPPLIER_CODE.Text = SqlInput.ChangeNullToString(dt_Material.Rows[0]["SupplierCode"]);//供应商代码
            }
            else
            {
                txt_SUPPLIER_CODE.Text = string.Empty;
            }
            cbo_MaterialCode.Items.AddRange(lstInitMaterial.ToArray());

        }

        private void cbo_MaterialCode_TextChanged(object sender, EventArgs e)
        {

            ////清空控件数据
            //this.cbo_MaterialCode.Items.Clear();
            ////清空过滤数据
            //lstNew.Clear();
            //foreach (string var in lstInitMaterial)
            //{
            //    if (var.Contains(cbo_MaterialCode.Text))
            //    {
            //        lstNew.Add(var);
            //    }
            //}
            ////模糊查询结果绑定
            //this.cbo_MaterialCode.Items.AddRange(lstNewMaterial.ToArray());
            ////设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒叙排序
            //cbo_MaterialCode.SelectionStart = cbo_MaterialCode.Text.Length;
            ////保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置
            //Cursor = Cursors.Default;
            ////自动弹出下拉框
            //cbo_MaterialCode.DroppedDown = true;
        }

        private void cbo_MaterialCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbo_MaterialCode.TextChanged -= cbo_MaterialCode_TextChanged;
            txt_MaterialDesc.Text = string.Empty;
            if (cbo_MaterialCode.Text != string.Empty)
            {
                DataTable dt_Spec = bll_Material.SelectNameAndSpec(cbo_MaterialCode.Text.Split('*')[0]);
                if (dt_Spec.Rows.Count == 0)
                {
                    new PubUtils().ShowNoteNGMsg("未维护该物料基础信息！", 1, grade.OrdinaryError);
                    cbo_PO_SelectedIndexChanged(null, null);
                    return;
                }
                else
                {
                    txt_MaterialDesc.Text = SqlInput.ChangeNullToString(dt_Spec.Rows[0]["Spec"]);
                    txt_MinPackage.Text = SqlInput.ChangeNullToInt(dt_Spec.Rows[0]["PackagingMin"], 1).ToString();
                }
            }
            //cbo_MaterialCode.TextChanged += cbo_MaterialCode_TextChanged;
        }
    }
}
