using BaseData.BLL;
using CIT.Client;
using CIT.MES;
using CIT.Wcf.Utils;
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
    public partial class FrmUser : BaseForm
    {
        /// <summary>
        /// 新增修改操作标志
        /// </summary>
        public OperationType operationType;
        /// <summary>
        /// 组织表
        /// </summary>
        DataTable dtOrg = new DataTable();
        /// <summary>
        /// 用户表
        /// </summary>
        DataTable dtUser = new DataTable();
        /// <summary>
        ///用户组织 Datagridview选中的对象
        /// </summary>
        public SysDatUser user = new SysDatUser();
        /// <summary>
        /// 用户组织 Datagridview选中的对象
        /// </summary>
        public SysdatOrg Org = new SysdatOrg();
        public FrmUser()
        {
            InitializeComponent();
            DataBindToControl();
        }
        private void DataBindToControl()
        {
            dtOrg = CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select ID,text from SysdatOrg");
            DataRow dr = dtOrg.NewRow();
            dr["text"] = string.Empty;
            dr["ID"] = "-1";
            dtOrg.Rows.InsertAt(dr, 0);
            cbo_Org.DataSource = dtOrg;
            cbo_Org.DisplayMember = "text";
            cbo_Org.ValueMember = "ID";
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            SysDatUser user = new SysDatUser();//用户表对象
            SysdatOrg Org = new SysdatOrg();//用户部门表对象
            if (txt_userID.Text == string.Empty)
            {
                new PubUtils().ShowNoteNGMsg("用户ID不能为空", 2, grade.RepeatedError);
                return;
            }
            if (txt_userName.Text == string.Empty)
            {
                new PubUtils().ShowNoteNGMsg("用户名不能为空", 2, grade.RepeatedError);
                return;
            }
            if (cbo_Org.Text == string.Empty)
            {
                new PubUtils().ShowNoteNGMsg("所属部门不能为空", 2, grade.RepeatedError);
                return;
            }
            bool isSuccess = false;
            user.UserID = txt_userID.Text.Trim();//用户ID
            user.UserName = txt_userName.Text.Trim();//用户名
            Org.ID = Convert.ToInt32(cbo_Org.SelectedValue);//部门
            if (operationType == OperationType.Add)
            {
                string strSql = string.Format("select * from SysDatUser where UserID='{0}'", txt_userID.Text.Trim());
                dtUser = NMS.QueryDataTable(PubUtils.uContext, strSql);
                if (dtUser.Rows.Count > 0)
                {
                    new PubUtils().ShowNoteNGMsg("用户ID不能重复", 2, grade.RepeatedError);
                    return;
                }
                isSuccess = BLL_SysDatUser.InsertUserOrg(user, Org);
            }
            else
            {
                isSuccess = BLL_SysDatUser.UpdateUserOrg(user, Org);
            }
            if (isSuccess)
            {
                new PubUtils().ShowNoteOKMsg("保存成功");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmUser_Load(object sender, EventArgs e)
        {
            if (operationType == OperationType.Edit)
            {
                txt_userID.Text = user.UserID;
                txt_userName.Text = user.UserName;
                cbo_Org.Text = Org.text;
                txt_userID.ReadOnly = true;               
            }
        }
    }
}
