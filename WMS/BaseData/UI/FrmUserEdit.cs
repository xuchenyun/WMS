using BaseData.BLL;
using CIT.Client;
using Common.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CIT.MES;
using CIT.Wcf.Utils;

namespace BaseData.UI
{
    public partial class FrmUserEdit : BaseForm
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string _UserID = string.Empty;
        /// <summary>
        /// 操作标志位
        /// </summary>
        bool _Action_Type;
        /// <summary>
        /// 对话框返回结果
        /// </summary>
        DialogResult result = DialogResult.Cancel;
        /// <summary>
        /// 物料信息表数据源表格
        /// </summary>
        DataTable dt_Menu = new DataTable();
  

        public FrmUserEdit(bool Action_Type)
        {
            this._Action_Type = Action_Type;
            InitializeComponent();
            dgv_Menu.AutoGenerateColumns = false;

        }
  
        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            txt_UserID.Focus();
            if (!CheckData())
            {
                return;
            }
            bool isSucess = false;        
            if (_Action_Type == false)
            {
                //1、保存用户信息
                BLL_SysDatUser.Insert(txt_UserID.Text.Trim(), txt_UserName.Text.Trim(), txt_Password.Text.Trim());
                //2、用户菜单信息
                foreach(DataRow dr in dt_Menu.Rows)
                {
                    if (dr["flag"].ToString() == "2")//新增
                    {
                        BLL_SysDatUserMenuMap.Insert(dr[MenuCode.Name].ToString(), txt_UserID.Text.Trim());
                    }                      
                }
                isSucess = true;
            }      
            else
            {
                //1、保存用户信息
                BLL_SysDatUser.UpdateUserName(txt_UserID.Text.Trim(), txt_UserName.Text.Trim());
                //2、用户菜单信息
                foreach (DataRow dr in dt_Menu.Rows)
                {     
                    if (dr["flag"].ToString() == "2")//新增
                    {
                        BLL.BLL_SysDatUserMenuMap.Insert(dr[MenuCode.Name].ToString(), txt_UserID.Text.Trim());
                    }
                    else if (dr["flag"].ToString() == "3")//删除
                    {
                        BLL.BLL_SysDatUserMenuMap.Delete(string.Format(@" WHERE MenuCode='{0}' AND UserID='{1}'",dr[MenuCode.Name].ToString(),txt_UserID.Text.Trim()));
                    }
                }
                isSucess = true;
            }
            if (isSucess)
            {
                new PubUtils().ShowNoteOKMsg("保存成功！");
                this.result = DialogResult.OK;
                this.Close();
            }
        } 
        #endregion

        private bool CheckData()
        {
            if (txt_UserID.Text == string.Empty)
            {
                MsgBox.Error("请填写用户ID");
                return false;
            }
            if (txt_UserName.Text == string.Empty)
            {
                MsgBox.Error("请填写名称");
                return false;
            }
            if (_Action_Type == false & txt_Password.Text == string.Empty)
            {
                MsgBox.Error("请填写密码");
                return false;
            }
            return true;
        }

     
        private void FrmUserEdit_Load(object sender, EventArgs e)
        {
            if (_Action_Type == true)
            {
                txt_Password.Visible = false;
                lbl_Pwd.Visible = false;
                DataTable dt = BLL_SysDatUser.Select(string.Format(" Where UserID='{0}'", _UserID));
                if (dt.Rows.Count > 0)
                {
                    txt_UserID.Text = _UserID;
                    txt_UserName.Text = dt.Rows[0]["UserName"].ToString();
                    //txt_Password.Text = dt.Rows[0]["Password"].ToString();
                    dt_Menu = BLL_SysdatMenu.Select(_UserID);
                    dgv_Menu.DataSource = dt_Menu;
                }          
            } 
            else
            {
                dt_Menu = BLL_SysdatMenu.Select(_UserID);//空值
                dgv_Menu.DataSource = dt_Menu;
            }     
        }
      
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmUserEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = this.result;
        }
   

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_Menu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dgv_Menu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Menu.Columns[e.ColumnIndex].Name == CHK.Name & e.RowIndex >= 0)
            {
                string container_type = dgv_Menu.Rows[e.RowIndex].Cells[MenuCode.Name].Value.ToString();
                DataRow[] drs = dt_Menu.Select(string.Format("MenuCode='{0}'", container_type));
                if (drs.Length > 0)
                {
                    bool isCheck = SqlInput.ChangeBoolToValue(dgv_Menu.Rows[e.RowIndex].Cells[CHK.Name].FormattedValue, false);

                    if (isCheck == true)
                    {
                        switch (drs[0]["flag"].ToString())
                        {
                            case "0":
                                drs[0]["flag"] = "2";//新增（只有状态0才能变成2）
                                break;
                            case "3":
                                drs[0]["flag"] = "1";//有（ 只有状态3才能变成1）（状态0和1都不对数据库进行操作）
                                break;
                        }
                    }
                    else
                    {
                        switch (drs[0]["flag"].ToString())
                        {
                            case "2":
                                drs[0]["flag"] = "0";//无（只有状态2才能变成0）（状态0和1都不对数据库进行操作）
                                break;
                            case "1":
                                drs[0]["flag"] = "3";//删除（只有状态1才能变成3）
                                break;
                        }
                    }
                    dgv_Menu.DataSource = dt_Menu;
                }
            }
        }
    }
}
