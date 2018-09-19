using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseData.BLL;
using CIT.MES;
using Model;
using Common.Helper;
using CIT.Client;

namespace BaseData.UI
{
    public partial class ucUserManage : UserControl
    {



        /// <summary>
        /// 操作标志位 新增--false 编辑--true
        /// </summary>
        bool Action_Type = false;
        public ucUserManage()
        {
            InitializeComponent();
            dgv_Menu.AutoGenerateColumns = false;
            dgv_User.AutoGenerateColumns = false;
        }

        #region 查询
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            Query();
            new PubUtils().ShowNoteOKMsg("查询完成");
        }
        private void Query()
        {
            //查询的时候先清空两个DataGridView表数据
            //清空物料代码表数据
            DataTable dt_User = (DataTable)dgv_User.DataSource;
            if (dt_User != null)
            {
                dt_User.Clear();
            }

            DataTable dt_Menu = (DataTable)dgv_Menu.DataSource;
            if (dt_Menu != null)
            {
                dt_Menu.Clear();
            }
            string strWhere = " WHERE 1=1";
            if (txt_MaterialCode.Text != string.Empty)//料号
            {
                strWhere += string.Format(" AND UserID='{0}'", txt_MaterialCode.Text.Trim());
            }
            DataTable dt = BLL_SysDatUser.Select(strWhere);
            dgv_User.DataSource = dt;
        } 
        #endregion
        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            Action_Type = false;
            FrmUserEdit frm = new FrmUserEdit(Action_Type);
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Query();
                string MaterialCode = string.Empty;
                QueryMenu(MaterialCode);
                new PubUtils().ShowNoteOKMsg("新增成功！");
            }
        }
        #endregion
        #region 编辑
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_edit_Click(object sender, EventArgs e)
        {
            string UserID = string.Empty;
            int iSelectedRow = 0;
            foreach (DataGridViewRow row in dgv_User.Rows)
            {
                if (row.Cells[CHK.Name].EditedFormattedValue.ToString() == "True")
                {
                    UserID = row.Cells["UserID"].EditedFormattedValue.ToString();
                    iSelectedRow++;
                }
            }
            if (iSelectedRow == 0)
            {
                MsgBox.Error("请选择要编辑的行！");
                return;
            }
            else if (iSelectedRow > 1)
            {
                MsgBox.Error("请勿选择多行！");
                return;
            }
            Action_Type = true;
            FrmUserEdit frm = new FrmUserEdit(Action_Type);
            frm._UserID = UserID;
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("修改成功！");
                QueryMenu(UserID);
            }
        }
        #endregion
        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_del_Click(object sender, EventArgs e)
        {
            string strWhere = string.Empty;
            int iSelectedRow = 0;
            bool b_DelOK = false;//是否删除过
            DialogResult result = MsgBox.Question("确认删除？");
            if (result == DialogResult.Cancel)
            {
                return;
            }
            int Count = 0;
            foreach (DataGridViewRow row in dgv_User.Rows)
            {
                if (row.Cells[CHK.Name].EditedFormattedValue.ToString() == "True")
                {
                    if (strWhere == string.Empty)
                    {
                        strWhere += string.Format("WHERE {0} in ('{1}'", UserID.Name, row.Cells[UserID.Name].Value.ToString());
                    }
                    else
                    {
                        strWhere += string.Format(",'{0}'", row.Cells[UserID.Name].Value.ToString());
                    }
                    Count++;
                    iSelectedRow++;
                    if (Count == 20)
                    {
                        strWhere += ")";
                        BLL_SysDatUser.Delete(strWhere);
                        BLL_SysDatUserMenuMap.Delete(strWhere);
                        strWhere = string.Empty;
                        Count = 0;
                        b_DelOK = true;
                    }
                }
            }
            if (strWhere != string.Empty)
            {
                strWhere += ")";
                BLL_SysDatUser.Delete(strWhere);
                BLL_SysDatUserMenuMap.Delete(strWhere);
                b_DelOK = true;
            }
            if (iSelectedRow == 0)
            {
                MsgBox.Error("请先选中行！");
                return;
            }
            if (b_DelOK)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("删除成功！");
                string MaterialCode = string.Empty;
            }
        }
        #endregion
        #region 点击用户查询其权限
        /// <summary>
        /// 点击用户查询其权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_User_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)//点击表头什么也不做
                return;
            string UserID = dgv_User.Rows[e.RowIndex].Cells[this.UserID.Name].Value.ToString();
            QueryMenu(UserID);
        }
        /// <summary>
        /// 用户权限
        /// </summary>
        /// <param name="UserID"></param>
        private void QueryMenu(string UserID)
        {
            string strWhere = string.Format(@"dmm.UserID='{0}'", UserID);
            DataTable dt =BLL_SysDatUserMenuMap.Select(strWhere);
            dgv_Menu.DataSource = dt;
            //dgv_Material.ClearSelection();
        } 
        #endregion
        #region 双击复制
        /// <summary>
        /// 物料代码表双击复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Material_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_User, e);
        }
        /// <summary>
        /// 阶别和保质期表双击复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_StepAndQulity_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_Menu, e);
        } 
        #endregion
    }
}
