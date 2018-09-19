using BaseData.BLL;
using Model;
using CIT.MES;
using Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Helper;

namespace BaseData.UI
{
    public partial class FormSuppliesEdit : Form
    {
        /// <summary>
        /// 供应商表实体
        /// </summary>
        public MdcDatSuppliesManage obj = new MdcDatSuppliesManage();
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperationType opetrationType;
        /// <summary>
        /// 编辑前的供应商代码
        /// </summary>
        private string oldSupplierCode = string.Empty;

        public FormSuppliesEdit()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string varMsg = string.Empty;

            if (!CheckData(out varMsg))
            {
                new PubUtils().ShowNoteNGMsg(varMsg, 2, grade.OrdinaryError);
                return;
            }
            obj.SupplierCode =txt_suppliesCode.Text.Trim();
            obj.SupplierName =txt_suppliesName.Text.Trim();
            if (opetrationType == OperationType.Add)
            {
                if (Bll_MdcDatSuppliesManage.Query(string.Format("where SupplierCode='{0}'", SqlInput.InputString(txt_suppliesCode.Text.Trim()))).Rows.Count > 0)
                {
                    new PubUtils().ShowNoteNGMsg("供应商代码已存在", 2, grade.OrdinaryError);
                    return;
                }
                if (Bll_MdcDatSuppliesManage.Insert(obj))
                {
                    this.DialogResult = DialogResult.OK;
                    obj = new MdcDatSuppliesManage();
                    this.Close();
                }
                else
                {
                    new PubUtils().ShowNoteNGMsg("添加失败", 2, grade.OrdinaryError);
                    return;
                }
            }
            else if (opetrationType == OperationType.Edit)
            {
                if (!txt_suppliesCode.Text.Trim().Equals(oldSupplierCode))
                {
                    if (Bll_MdcDatSuppliesManage.Query(string.Format("where SupplierCode='{0}'", SqlInput.InputString(txt_suppliesCode.Text.Trim()))).Rows.Count > 0)
                    {
                        new PubUtils().ShowNoteNGMsg("供应商代码已存在", 2, grade.OrdinaryError);
                        return;
                    }
                }
                if (Bll_MdcDatSuppliesManage.Update(obj, oldSupplierCode))
                {
                    this.DialogResult = DialogResult.OK;
                    obj = new MdcDatSuppliesManage();
                    this.Close();
                }
                else
                {
                    new PubUtils().ShowNoteNGMsg("修改失败", 2, grade.OrdinaryError);
                    return;
                }
            }
        }

        private bool CheckData(out string varMsg)
        {
            if (string.IsNullOrEmpty(txt_suppliesName.Text.Trim()))
            {
                varMsg = "供应商名称不能为空!";
                return false;
            }
            if (string.IsNullOrEmpty(txt_suppliesCode.Text.Trim()))
            {
                varMsg = "供应商代码不能为空!";
                return false;
            }
            varMsg = "OK";
            return true;
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuppliesEdit_Load(object sender, EventArgs e)
        {
            if (opetrationType == OperationType.Edit)
            {
                txt_suppliesCode.Text = obj.SupplierCode;
                oldSupplierCode = obj.SupplierCode;
                txt_suppliesName.Text = obj.SupplierName;
            }
        }
    }
}
