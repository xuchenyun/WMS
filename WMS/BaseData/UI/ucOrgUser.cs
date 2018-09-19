using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIT.MES;
using BaseData.BLL;
using Model;
using CIT.Client;

namespace BaseData.UI
{
    public partial class ucOrgUser : UserControl
    {
        TreeNode _node;
        DataTable dtOrg;
        DataTable dtUser = new DataTable();
        public ucOrgUser()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 新增组织管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addOrg_Click(object sender, EventArgs e)
        {
            FrmOrganize frmO = new FrmOrganize();
            frmO.operationType = Common.Enum.OperationType.Add;
            frmO._current_orgID = trv_org.SelectedNode == null ? string.Empty : trv_org.SelectedNode.Tag.ToString();
            if (frmO.ShowDialog() == DialogResult.OK)
            {

                InitTreeRoot();
                new PubUtils().ShowNoteOKMsg("新增成功");
            }
        }
        /// <summary>
        /// 修改组织管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_editOrg_Click(object sender, EventArgs e)
        {
            if (trv_org.SelectedNode == null)
            {
                new PubUtils().ShowNoteNGMsg("请先选中节点", 1, grade.OrdinaryError);
                return;
            }
            FrmOrganize frmO = new FrmOrganize();
            frmO.operationType = Common.Enum.OperationType.Edit;
            frmO._current_orgID = trv_org.SelectedNode == null ? string.Empty : trv_org.SelectedNode.Tag.ToString();

            frmO._Parent_orgID = trv_org.SelectedNode == null ? string.Empty : (trv_org.SelectedNode.Parent == null ? "0" : trv_org.SelectedNode.Parent.Tag.ToString());

            if (frmO.ShowDialog() == DialogResult.OK)
            {
                InitTreeRoot();
                new PubUtils().ShowNoteOKMsg("修改成功");
            }
        }
        /// <summary>
        /// 删除组织管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_deleteOrg_Click(object sender, EventArgs e)
        {
            if (trv_org.SelectedNode == null)
            {
                new PubUtils().ShowNoteNGMsg("请先选中节点", 1, grade.OrdinaryError);
                return;
            }
            if (MsgBox.Question("确认删除?") == DialogResult.OK)
            {
                string ID = trv_org.SelectedNode.Tag.ToString();
                BLL_SysdatOrg.Delete(ID);
                InitTreeRoot();
                new PubUtils().ShowNoteOKMsg("删除成功");
            }

        }

        private void ucOrgUser_Load(object sender, EventArgs e)
        {
            InitTreeRoot();
        }
        private void InitTreeRoot()
        {
            dtOrg = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, @"select distinct ID,ParentID,text 
                                                     from SysdatOrg group by ID,ParentID,text");
            trv_org.Nodes.Clear();
            var lstOrg = (
                            from org in dtOrg.AsEnumerable()
                            orderby org.Field<int>("ParentID") ascending
                            select new
                            {
                                ID = org.Field<int>("ID"),
                                ParentID = org.Field<int>("ParentID"),
                                text = org.Field<string>("text")
                            }
                      ).Distinct().ToList();
            foreach (var comp in lstOrg.Where(t => t.ParentID == 0))//顶级节点
            {
                _node = new TreeNode();
                _node.Text = comp.text;
                _node.Tag = comp.ID;
                _node.Name = string.Format("{0}@{1}", comp.ID, comp.ParentID);
                trv_org.Nodes.Add(_node);
            }
        }

        private void trv_org_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trv_org.SelectedNode != null)
            {
                var treeNode = dtOrg.AsEnumerable().ToList().Where(t => t.Field<int>("ParentID") == Convert.ToInt32(trv_org.SelectedNode.Tag));
                if (treeNode != null)
                {
                    foreach (DataRow dr in treeNode)//选中节点下的子节点
                    {
                        _node = new TreeNode();
                        _node.Text = dr["text"].ToString();
                        _node.Tag = dr["ID"].ToString();
                        _node.Name = string.Format("{0}@{1}", dr["ID"].ToString(), dr["ParentID"].ToString());
                        if (trv_org.Nodes.Find(_node.Name, true).Count() > 0)
                        {
                            continue;
                        }
                        trv_org.SelectedNode.Nodes.Add(_node);
                    }
                    trv_org.SelectedNode.ExpandAll();
                }
                DataTable dtUser = CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, @"select a.UserID,a.UserName,c.text  from SysDatUser as a left join [MdcDatOrgUserMap] as b on a.UserID=b.UserID left join SysdatOrg as c on b.OrgID=c.ID where a.UserID in(select   UserID from [dbo].[MdcDatOrgUserMap] where OrgID='" + trv_org.SelectedNode.Tag.ToString() + "')");
                dgv_user.DataSource = dtUser;
            }
        }
        /// <summary>
        /// 新增人员管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            FrmUser frmU = new FrmUser();
            frmU.operationType = Common.Enum.OperationType.Add;
            if (frmU.ShowDialog() == DialogResult.OK)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("新增成功");
            }

        }
        /// <summary>
        /// 修改人员管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgv_user.CurrentRow == null || dgv_user.CurrentRow.Index == -1)
            {
                new PubUtils().ShowNoteNGMsg("请选中行", 1, grade.OrdinaryError);
                return;
            }
            FrmUser frmU = new FrmUser();
            frmU.operationType = Common.Enum.OperationType.Edit;
            frmU.user = Common.Helper.PublicSetModel<SysDatUser>.GetTByDataGridViewRow(dgv_user.CurrentRow);
            frmU.Org = Common.Helper.PublicSetModel<SysdatOrg>.GetTByDataGridViewRow(dgv_user.CurrentRow);
            if (frmU.ShowDialog() == DialogResult.OK)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("新增成功");
            }
        }
        /// <summary>
        /// 删除人员管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dgv_user.CurrentRow == null || dgv_user.CurrentRow.Index == -1)
            {
                new PubUtils().ShowNoteNGMsg("请选中行", 1, grade.OrdinaryError);
                return;
            }
            if (MsgBox.Question("确认删除") == DialogResult.OK)
            {
                string userID = dgv_user.CurrentRow.Cells["UserID"].Value.ToString();
                BLL_SysDatUser.DeleteUserOrg(userID);
                Query();
                new PubUtils().ShowNoteOKMsg("删除成功");
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {

            Query();
            new PubUtils().ShowNoteOKMsg("查询成功");

        }
        private void Query()
        {
            string strWhere = " Where 1=1";
            if (txt_userName.Text != string.Empty)
            {
                strWhere += string.Format(" AND a.UserName='{0}'", txt_userName.Text.Trim());
            }
            dtUser = BLL_SysDatUser.QueryUserOrg(strWhere);
            dgv_user.DataSource = dtUser;
        }
        /// <summary>
        /// 双击复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_user_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_user, e);
        }

  
    }
}

