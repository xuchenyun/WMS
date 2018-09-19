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
    public partial class FrmOrganize : BaseForm
    {
        /// <summary>
        /// 新增修改操作标志位
        /// </summary>
        public OperationType operationType;
        /// <summary>
        /// 当前节点ID
        /// </summary>
        public string _current_orgID = string.Empty;
        /// <summary>
        /// 父节点ID
        /// </summary>
        public string _Parent_orgID = string.Empty;
        public SysdatOrg Org = new SysdatOrg();
        DataTable dtOrg;

        public FrmOrganize()
        {
            InitializeComponent();
            DataBindToControl();
        }
        private void DataBindToControl()
        {
            dtOrg = CIT.Wcf.Utils.NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select ID,text from SysdatOrg");
            DataRow dr = dtOrg.NewRow();
            dr["text"] = string.Empty;
            dr["ID"] = "0";
            dtOrg.Rows.InsertAt(dr, 0);
            cbo_ParentOrg.DataSource = dtOrg;
            cbo_ParentOrg.DisplayMember = "text";
            cbo_ParentOrg.ValueMember = "ID";
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            SysdatOrg Org = new SysdatOrg();
            bool isSuccess = false;
            if (txtCurrentOrg.Text == string.Empty)
            {
                new PubUtils().ShowNoteNGMsg("节点名称不能为空", 2, grade.RepeatedError);
                return;
            }
            Org.ParentID = Common.Helper.SqlInput.ChangeNullToInt(cbo_ParentOrg.SelectedValue, 0);
            Org.text = txtCurrentOrg.Text.Trim();
            Org.ID =Common.Helper.SqlInput.ChangeNullToInt(_current_orgID,0);
            if (operationType == OperationType.Add)
            {
                string strSql=string.Format("select * from SysdatOrg where text='{0}' and ParentID='{1}'", txtCurrentOrg.Text.Trim(), Common.Helper.SqlInput.ChangeNullToInt(cbo_ParentOrg.SelectedValue, 0));
                dtOrg = NMS.QueryDataTable(PubUtils.uContext, strSql);
                if (dtOrg.Rows.Count > 0)
                {
                    new PubUtils().ShowNoteNGMsg("节点名称已存在",2,grade.RepeatedError);
                    return;
                }               
                isSuccess = BLL_SysdatOrg.InsertOrg(Org);
            }
            else
            {
                isSuccess = BLL_SysdatOrg.UpdateOrg(Org);
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

        private void FrmOrganize_Load(object sender, EventArgs e)
        {
            if (operationType == OperationType.Add)
            {
                if (!string.IsNullOrEmpty(_current_orgID))
                {
                    cbo_ParentOrg.SelectedValue = _current_orgID;
                    cbo_ParentOrg.Enabled = false;
                }
             
            }

            else
            {
                if (!string.IsNullOrEmpty(_current_orgID))
                {
                    cbo_ParentOrg.SelectedValue = _Parent_orgID;
                    txtCurrentOrg.Text = (from u in dtOrg.AsEnumerable()
                                          where u.Field<int>("ID") == Convert.ToInt32(_current_orgID)
                                          select u.Field<string>("text")).FirstOrDefault();
                    cbo_ParentOrg.Enabled = false;
                }
            }
        }
    }
}
