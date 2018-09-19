using BaseData.BLL;
using CIT.MES;
using Common.BLL;
using Common.Enum;
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

namespace BaseData.UI
{
    public partial class Form_MaterialRelManage : Form
    {
        BLL_MdcdatMaterial BLL_Material = new BLL_MdcdatMaterial();

        public T_Bllb_MaterialRelation_Tbmr obj_tbmr;

        public OperationType _operationType = OperationType.Add;

        public string TBMR_ID = string.Empty;

        public Form_MaterialRelManage()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string varMsg = string.Empty;
            if (!ValidateInput(out varMsg))
            {
                new PubUtils().ShowNoteNGMsg(varMsg, 2, grade.OrdinaryError);
                return;
            }
            obj_tbmr = new T_Bllb_MaterialRelation_Tbmr();
            obj_tbmr.LocalMaterialCode = txtLocalMaterial.Text.Trim();
            obj_tbmr.SupplyMaterialCode = txtSupplyMaterial.Text.Trim();
            obj_tbmr.Supply = txtSupply.Text.Trim();
            obj_tbmr.Remark = txtRemark.Text.Trim();
            if (_operationType == OperationType.Add)
            {
                obj_tbmr.TBMR_ID = Guid.NewGuid().ToString();
                if (BLL_Bllb_MaterialRelation_Tbmr.Insert(obj_tbmr))
                {
                    ClearControl();
                    new PubUtils().ShowNoteOKMsg("新增成功");
                }
            }
            else if (_operationType == OperationType.Edit)
            {
                obj_tbmr.TBMR_ID = TBMR_ID;
                if (BLL_Bllb_MaterialRelation_Tbmr.Update(obj_tbmr))
                {
                    new PubUtils().ShowNoteOKMsg("编辑成功");
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        void ClearControl()
        {
            txtLocalMaterial.Text = string.Empty;
            txtSupplyMaterial.Text = string.Empty;
            txtSupply.Text = string.Empty;
            txtRemark.Text = string.Empty;
        }

        private bool ValidateInput(out string msg)
        {
            if (string.IsNullOrEmpty(txtLocalMaterial.Text.Trim()))
            {
                msg = "本厂料号必填";
                return false;
            }
            if (string.IsNullOrEmpty(txtSupplyMaterial.Text.Trim()))
            {
                msg = "供应商料号必填";
                return false;
            }
            //if (string.IsNullOrEmpty(txtSupply.Text.Trim()))
            //{
            //    msg = "供应商编码错误";
            //    return false;
            //}
            if (BLL_Material.Select(string.Format("MaterialCode='{0}'", txtLocalMaterial.Text.Trim())).Rows.Count == 0)
            {
                msg = "本厂料号错误";
                return false;
            }
            //if (Bll_MdcDatSuppliesManage.Query(string.Format(" where SupplierCode='{0}'", txtSupply.Text.Trim())).Rows.Count == 0)
            //{
            //    msg = "供应商代码错误";
            //    return false;
            //}
            if (BLL_Bllb_MaterialRelation_Tbmr.Query(string.Format("WHERE  SupplyMaterialCode='{0}' {1}",txtSupplyMaterial.Text.Trim(),
                TBMR_ID == string.Empty ? string.Empty : string.Format("AND TBMR_ID<>'{0}'", TBMR_ID))).Rows.Count > 0)
            {
                msg = "供应商料号已存在";
                return false;
            }
            msg = "OK";
            return true;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_MaterialRelManage_Load(object sender, EventArgs e)
        {
            if (_operationType == OperationType.Edit)
            {
                txtLocalMaterial.Text = obj_tbmr.LocalMaterialCode;
                txtSupplyMaterial.Text = obj_tbmr.SupplyMaterialCode;
                txtRemark.Text = obj_tbmr.Remark;
                txtSupply.Text = obj_tbmr.Supply;
                TBMR_ID = obj_tbmr.TBMR_ID;
            }
        }
    }
}
