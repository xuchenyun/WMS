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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIT.Wcf.Utils;

namespace BaseData.UI
{

    public partial class FormCustomerEdit : Form
    {

        /// <summary>
        /// 客户表实体
        /// </summary>
        public SysdatMPNCustomer obj = new SysdatMPNCustomer();
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperationType opetrationType;

        public FormCustomerEdit()
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
            obj.CustomerName = txt_customerName.Text.Trim();
            obj.CustomerCode = txt_customerCode.Text.Trim();
            obj.Contact = txt_contract.Text.Trim();
            obj.ContactNumber = txt_contractNum.Text.Trim();
            obj.Email = txt_email.Text.Trim();
            obj.ShippingAddress = txt_address.Text.Trim();
            if (opetrationType == OperationType.Add)
            {
                obj.CustomerID = Guid.NewGuid().ToString();
                obj.Creator = PubUtils.uContext.UserName;
                obj.CreateTime = DateTime.Now;
                if (Bll_SysdatMPNCustomer.Insert(obj))
                {
                    this.DialogResult = DialogResult.OK;
                    obj = new SysdatMPNCustomer();
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
                if (Bll_SysdatMPNCustomer.Update(obj))
                {
                    this.DialogResult = DialogResult.OK;
                    obj = new SysdatMPNCustomer();
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
            if (string.IsNullOrEmpty(txt_customerName.Text.Trim()))
            {
                varMsg = "客户名称不能为空!";
                return false;
            }
            if (string.IsNullOrEmpty(txt_customerCode.Text.Trim()))
            {
                varMsg = "客户代码不能为空!";
                return false;
            }
            if (string.IsNullOrEmpty(txt_contract.Text.Trim()))
            {
                varMsg = "联系人不能为空!";
                return false;
            }
            if (string.IsNullOrEmpty(txt_contractNum.Text.Trim()))
            {
                varMsg = "联系人电话不能为空!";
                return false;
            }
            if (opetrationType == OperationType.Add)
            {
                string strSql = string.Format("SELECT * FROM SysdatMPNCustomer WHERE CustomerCode='{0}'", txt_customerCode.Text.Trim());
                if (NMS.QueryDataTable(PubUtils.uContext, strSql).Rows.Count > 0)
                {
                    varMsg = "客户代码不能重复!";
                    return false;
                }
            }
               

            if (!string.IsNullOrEmpty(txt_email.Text.Trim()))
            {
                string regex = @"^[A-Za-z0-9\u4e00-\u9fa5]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$";
                if (!Regex.Match(txt_email.Text.Trim(), regex).Success)
                {
                    varMsg = "邮箱格式不正确!";
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txt_address.Text.Trim()))
            {
                varMsg = "送货地址不能为空!";
                return false;
            }
            varMsg = "OK";
            return true;
        }

        private void FormCustomerEdit_Load(object sender, EventArgs e)
        {
            if (opetrationType == OperationType.Edit)
            {
                if (obj != null)
                {
                    txt_customerCode.Text = obj.CustomerCode;
                    txt_customerName.Text = obj.CustomerName;
                    txt_email.Text = obj.Email;
                    txt_contract.Text = obj.Contact;
                    txt_contractNum.Text = obj.ContactNumber;
                    txt_address.Text = obj.ShippingAddress;
                }
            }
            txt_customerCode.Focus();
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
