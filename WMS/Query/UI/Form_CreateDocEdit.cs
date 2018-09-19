using CIT.Client;
using CIT.MES;
using Common.BLL;
using Common.Helper;
using Model;
using Query.BLL;
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
    public partial class Form_CreateDocEdit : Form
    {
        /// <summary>
        /// 单据类型
        /// </summary>
        DataTable dtType = new DataTable();
        /// <summary>
        /// 业务层操作类
        /// </summary>
        BLL_MdcdatMaterial bll_material = new BLL_MdcdatMaterial();
        /// <summary>
        /// 扫描的数据源
        /// </summary>
        DataTable dtScan = new DataTable();
        /// <summary>
        /// 工单号
        /// </summary>
        string _WoCode = string.Empty;
        /// <summary>
        /// 线别代码
        /// </summary>
        string _PLCode = string.Empty;
        /// <summary>
        /// 制令单
        /// </summary>
        string _SfcNo = string.Empty;

        public Form_CreateDocEdit()
        {
            InitializeComponent();
            dtScan.Columns.Add("S_Doc_NO", Type.GetType("System.String"));
            dtScan.Columns.Add("MaterialCode", Type.GetType("System.String"));
            dtScan.Columns.Add("QTY", Type.GetType("System.String"));
            dtScan.Columns.Add("TYPE_CODE", Type.GetType("System.String"));
            dtScan.Columns.Add("TYPE_NAME", Type.GetType("System.String"));
            dtScan.Columns.Add("Before_Doc_No", Type.GetType("System.String"));
            dtScan.Columns.Add("RowNumber", Type.GetType("System.String"));
            dtScan.Columns.Add("Ver", Type.GetType("System.String"));
            dgvData.DataSource = dtScan;
            DataBind();
        }

        #region DataHandler
        private void DataBind()
        {
            dtType = BLL_Bllb_StorageDoc_tbsd.QueryDocType("where TYPE_CODE='7'");//暂时只有发料单
            DataRow dr = dtType.NewRow();
            dr["TYPE_NAME"] = string.Empty;
            dr["TYPE_CODE"] = "-1";
            dtType.Rows.InsertAt(dr, 0);
            cbo_Type.DataSource = dtType;
            cbo_Type.DisplayMember = "TYPE_NAME";
            cbo_Type.ValueMember = "TYPE_CODE";
            cbo_Type.SelectedIndex = 0;
        }

        private void RefreshRowNumber()
        {
            foreach (DataRow dr in dtScan.Rows)
            {
                dr["RowNumber"] = dtScan.Rows.IndexOf(dr) + 1;
            }
            txtQty.Text = string.Empty;
            txtBeforeDoc.SelectAll();
            txtBeforeDoc.Focus();
        }
        #endregion

        #region KeyPress
        private void txtBeforeDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string msg = string.Empty;
                if (!ValidateDocHead(out msg))
                {
                    txtBeforeDoc.SelectAll();
                    txtBeforeDoc.Focus();
                    new CIT.MES.PubUtils().ShowNoteNGMsg(msg, 2, CIT.MES.grade.OrdinaryError);
                    return;
                }
                //txtMaterialCode.SelectAll();
                //txtMaterialCode.Focus();
                txtVer.SelectAll();
                txtVer.Focus();
            }
        }

        private void txtVer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMaterialCode.SelectAll();
                txtMaterialCode.Focus();
            }
        }

        private void txtMaterialCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string msg = string.Empty;
                if (!ValidateDocHead(out msg))
                {
                    txtBeforeDoc.SelectAll();
                    txtBeforeDoc.Focus();
                    new CIT.MES.PubUtils().ShowNoteNGMsg(msg, 2, CIT.MES.grade.OrdinaryError);
                    return;
                }
                if (!ValidateMaterialCode(out msg))
                {
                    txtMaterialCode.SelectAll();
                    new CIT.MES.PubUtils().ShowNoteNGMsg(msg, 2, CIT.MES.grade.OrdinaryError);
                    return;
                }
                txtQty.Focus();
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string msg = string.Empty;
                if (!ValidateDocHead(out msg))
                {
                    txtBeforeDoc.SelectAll();
                    txtBeforeDoc.Focus();
                    new CIT.MES.PubUtils().ShowNoteNGMsg(msg, 2, CIT.MES.grade.OrdinaryError);
                    return;
                }
                if (!ValidateMaterialCode(out msg))
                {
                    txtMaterialCode.SelectAll();
                    new CIT.MES.PubUtils().ShowNoteNGMsg(msg, 2, CIT.MES.grade.OrdinaryError);
                    return;
                }
                if (!ValidateQty(out msg))
                {
                    MsgBox.Error(msg);
                    return;
                }
                DataRow dr = dtScan.NewRow();
                dr["S_Doc_NO"] = txtDocNO.Text.Trim();
                dr["MaterialCode"] = txtMaterialCode.Text.Trim();
                dr["QTY"] = txtQty.Text.Trim();
                dr["TYPE_CODE"] = cbo_Type.SelectedValue.ToString();
                dr["TYPE_NAME"] = cbo_Type.Text.Trim();
                dr["Before_Doc_No"] = txtBeforeDoc.Text.Trim();
                dr["Ver"] = txtVer.Text.Trim().ToUpper();
                dtScan.Rows.Add(dr);
                RefreshRowNumber();
            }
        }
        #endregion

        #region Validate
        private bool ValidateMaterialCode(out string msg)
        {
            if (string.IsNullOrEmpty(txtMaterialCode.Text.Trim()))
            {
                msg = "料号不能为空";
                return false;
            }
            DataTable dtMaterial = bll_material.Select(string.Format(" MaterialCode='{0}'", txtMaterialCode.Text.Trim()));
            if (dtMaterial.Rows.Count == 0)
            {
                msg = "料号错误";
                return false;
            }
            msg = "OK";
            return true;
        }

        private bool ValidateDocHead(out string msg)
        {
            if (cbo_Type.SelectedValue.ToString() == "-1")
            {
                msg = "请先选择单据类型";
                return false;
            }
            if (string.IsNullOrEmpty(txtBeforeDoc.Text.Trim()))
            {
                msg = "请输入上游单据";
                return false;
            }
            string sqlcmd = string.Format("SELECT FGuid,SfcNo,WoCode,TBT_ID,Product,Line FROM SfcDatProduct WHERE SfcNo='{0}'", txtBeforeDoc.Text.Trim());
            DataTable dt_sfcno = CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sqlcmd);
            if (dt_sfcno.Rows.Count == 0)
            {
                msg = "上游单据错误";
                return false;
            }
            _PLCode = SqlInput.ChangeNullToString(dt_sfcno.Rows[0]["Line"]);//线别代码
            _WoCode = SqlInput.ChangeNullToString(dt_sfcno.Rows[0]["WoCode"]);//工单
            _SfcNo = SqlInput.ChangeNullToString(dt_sfcno.Rows[0]["SfcNo"]);//制令单
            msg = "OK";
            return true;
        }

        private bool ValidateQty(out string msg)
        {
            if (string.IsNullOrEmpty(txtQty.Text.Trim()))
            {
                msg = "数量不能为空";
                return false;
            }
            try
            {
                if (Convert.ToInt32(txtQty.Text.Trim()) <= 0)
                {
                    msg = "数量为大于0的整数";
                    return false;
                }
                if (txtQty.Text.Contains('.'))
                {
                    msg = "数量不能为小数";
                    return false;
                }
            }
            catch
            {
                msg = "数量只能为数字,不能包含其他字符";
                return false;
            }
            msg = "OK";
            return true;
        }
        #endregion



        private void cbo_Type_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtDocNO.Text = string.Empty;
            string var_head = string.Empty;
            if (cbo_Type.SelectedValue.ToString() == "-1") return;
            if (dtType.Rows.Count > 0)
            {
                var_head = (from h in dtType.AsEnumerable() where h.Field<string>("TYPE_CODE") == cbo_Type.SelectedValue.ToString() select h.Field<string>("TYPE_HEAD")).Distinct().ToList().FirstOrDefault();
            }
            if (cbo_Type.SelectedValue.ToString() != "-1")
            {
                DataTable dtFlow = BLL_Bllb_StorageDoc_tbsd.GetStorageDocFlow(cbo_Type.SelectedValue.ToString(), var_head.Trim());
                txtDocNO.Text = string.Format("{0}{1}", var_head.Trim(), dtFlow.Rows[0]["flow"].ToString());
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentCell == null || dgvData.CurrentCell.RowIndex == -1)
            {
                new CIT.MES.PubUtils().ShowNoteNGMsg("请先选中行", 2, CIT.MES.grade.OrdinaryError);
                return;
            }
            dtScan.Rows.RemoveAt(dgvData.CurrentCell.RowIndex);
            RefreshRowNumber();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0)
            {
                new CIT.MES.PubUtils().ShowNoteNGMsg("记录行为零，无需保存", 2, CIT.MES.grade.OrdinaryError);
                return;
            }
            while (true)//校验单据是否已被占用
            {
                if (BLL_Bllb_StorageDoc_tbsd.Query(string.Format(" WHERE S_Doc_NO='{0}'", txtDocNO.Text.Trim())).Rows.Count > 0)
                {
                    cbo_Type_SelectionChangeCommitted(null, null);
                    continue;
                }
                else
                {
                    break;
                }
            }
            var stroage_doc = new T_Bllb_StorageDoc_tbsd()
            {
                S_Doc_NO = txtDocNO.Text.Trim(),
                S_Doc_Type = cbo_Type.SelectedValue.ToString(),
                Creator = PubUtils.uContext.UserID,
                Before_Doc_NO = txtBeforeDoc.Text.Trim(),
                PLCode = _PLCode,
                WoCode = _WoCode,
                SfcNo = _SfcNo

            };
            var listStorageMaterial = (from u in dtScan.AsEnumerable()
                                       select new T_Bllb_StorageDocMaterial_tsdm()
                                       {
                                           MaterialCode = u.Field<string>("MaterialCode"),
                                           S_Doc_NO = txtDocNO.Text.Trim(),
                                           Plan_Qty = Convert.ToInt32(u.Field<string>("QTY")),
                                           RowNumber = Convert.ToInt32(u.Field<string>("RowNumber")),
                                           Ver = u.Field<string>("Ver")
                                       }).Distinct().ToList();
            if (BLL_Bllb_StorageDoc_tbsd.InsertStorageDocWithMaterial(stroage_doc, listStorageMaterial))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                new PubUtils().ShowNoteNGMsg("开立单据失败", 2, grade.OrdinaryError);
                return;
            }
        }

    }
}

