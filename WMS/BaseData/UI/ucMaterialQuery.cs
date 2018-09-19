using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIT.Wcf.Utils;
using BaseData.DAL;
using CIT.MES;
using Model;
using CIT.Client;

namespace BaseData.UI
{
    public partial class ucMaterialQuery : UserControl
    {
        public bool isAddOrEdit = true; // --新增 false --编辑 true

        public ucMaterialQuery()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
             isAddOrEdit = false;
            frmMaterialManager frm = new frmMaterialManager(isAddOrEdit);
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("新增成功！");
            }
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_edit_Click(object sender, EventArgs e)
        {

            if (dgv_Material.CurrentRow == null || dgv_Material.CurrentRow.Index == -1)
            {
                new PubUtils().ShowNoteNGMsg("请选中行", 2, grade.OrdinaryError);
                return;
            }

            isAddOrEdit = true;
            frmMaterialManager frm = new frmMaterialManager(isAddOrEdit);
            frm.obj = Common.Helper.PublicSetModel<MdcdatMaterial>.GetTByDataGridViewRow(dgv_Material.CurrentRow);
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("修改成功！");
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dgv_Material.CurrentRow == null || dgv_Material.CurrentRow.Index == -1)
            {
                new PubUtils().ShowNoteNGMsg("请选中行", 2, grade.OrdinaryError);
                return;
            }
            if (MsgBox.Question("确定要删除？") == DialogResult.OK)
            {
                MdcdatMaterial_DAL.Delete(string.Format(" where MaterialCode='{0}'", dgv_Material.CurrentRow.Cells["MaterialCode"].Value.ToString()));
                Query();
                new PubUtils().ShowNoteOKMsg("删除成功");
            }

        }
        /// <summary>
        /// 查询料号
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
            string strWhere = " Where 1=1";
            if (txt_materialCode.Text != string.Empty)
            {
                strWhere += string.Format(" And X.MaterialCode='{0}'", txt_materialCode.Text.Trim());
            }
            if (cbo_houseName.SelectedValue.ToString() != "-1")
            {
                strWhere += string.Format(" And X.HouseCode='{0}'", cbo_houseName.Text.ToString());
            }
            if (cbo_TYPE.SelectedValue.ToString() != "-1")
            {
                strWhere += string.Format(" And X.Type='{0}'", cbo_TYPE.Text.ToString().Trim());
            }
            DataTable dt_Material = MdcdatMaterial_DAL.QueryMaterialInfo(strWhere);
            dgv_Material.DataSource = dt_Material;       
        }

        private void ucMaterialQuery_Load(object sender, EventArgs e)
        {
            DataTable dt = MdcdatMaterial_DAL.QueryHouseCode();
            DataRow dr = dt.NewRow();
            dr["Storage_Name"] = "";
            dr["Storage_SN"] = -1;
            dt.Rows.InsertAt(dr, 0);
            cbo_houseName.DataSource = dt;
            cbo_houseName.DisplayMember = "Storage_Name";
            cbo_houseName.ValueMember = "Storage_SN";

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("DisplayValue");
            dt2.Columns.Add("Value");
            DataRow dr2 = dt2.NewRow();
            dr2["DisplayValue"] = "";
            dr2["Value"] = -1;
            dt2.Rows.InsertAt(dr2, 0);
            dr2 = dt2.NewRow();
            dr2["DisplayValue"] = "红胶";
            dr2["Value"] = "0";
            dt2.Rows.Add(dr2);
            dr2 = dt2.NewRow();
            dr2["DisplayValue"] = "锡膏";
            dr2["Value"] = "1";
            dt2.Rows.Add(dr2);
            dr2 = dt2.NewRow();
            dr2["DisplayValue"] = "MSD";
            dr2["Value"] = "2";
            dt2.Rows.Add(dr2);
            dr2 = dt2.NewRow();
            dr2["DisplayValue"] = "普通";
            dr2["Value"] = "3";
            dt2.Rows.Add(dr2);
            cbo_TYPE.DataSource = dt2;
            cbo_TYPE.DisplayMember = "DisplayValue";
            cbo_TYPE.ValueMember = "Value";
        }
        /// <summary>
        /// 双击复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Material_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_Material, e);
        }
    }
}
