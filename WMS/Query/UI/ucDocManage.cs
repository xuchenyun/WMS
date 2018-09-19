using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Query.BLL;
using Common.Helper;
using Common.BLL;

namespace Query.UI
{
    public partial class ucDocManage : UserControl
    {
        DataTable dtType = new DataTable();

        DataTable dt_StorageDoc = new DataTable();

        DataTable dtStorageMaterial = new DataTable();

        DataTable dtStorageDetail = new DataTable();

        SysDatUser_BLL user_bll = new SysDatUser_BLL();
        public ucDocManage()
        {
            InitializeComponent();
            DataBindType();
            dgv_StorageDoc.AutoGenerateColumns = false;
            dgv_StorageMaterial.AutoGenerateColumns = false;
            dgvStorageDetail.AutoGenerateColumns = false;
            dtp_TimeMax.Text = DateTime.Now.AddDays(1).ToShortDateString();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Form_CreateDocEdit f = new Form_CreateDocEdit();
            if (f.ShowDialog() == DialogResult.OK)
            {
                QueryData();
                new CIT.MES.PubUtils().ShowNoteOKMsg("操作成功");
            }
        }

        private void DataBindType()
        {
            dtType = BLL_Bllb_StorageDoc_tbsd.QueryDocType(string.Empty);
            DataRow dr = dtType.NewRow();
            dr["TYPE_NAME"] = string.Empty;
            dr["TYPE_CODE"] = "-1";
            dtType.Rows.InsertAt(dr, 0);
            cbo_Type.DataSource = dtType;
            cbo_Type.DisplayMember = "TYPE_NAME";
            cbo_Type.ValueMember = "TYPE_CODE";
            cbo_Type.SelectedIndex = 0;
            S_Doc_Type.DataSource = dtType;
            S_Doc_Type.DisplayMember = "TYPE_NAME";
            S_Doc_Type.ValueMember = "TYPE_CODE";
            //DataTable dtUser = user_bll.Select();
            //Creator.DataSource = dtUser;
            //Creator.DisplayMember = "UserName";
            //Creator.ValueMember = "UserID";
            //Creator_Detail.DataSource = dtUser;
            //Creator_Detail.DisplayMember = "UserName";
            //Creator_Detail.ValueMember = "UserID";
        }

        private void QueryData()
        {
            try
            {
                StringBuilder strbild = new StringBuilder(" where 1=1 ");
                if (!string.IsNullOrEmpty(txt_Doc_NO.Text.Trim()))
                {
                    strbild.AppendFormat(" and a.S_Doc_NO='{0}'", txt_Doc_NO.Text.Trim());
                }
                if (!string.IsNullOrEmpty(dtp_TimeMin.Text.Trim()))
                {
                    strbild.AppendFormat(" and a.Create_Time>=CONVERT(DATETIME,'{0}')", dtp_TimeMin.Text.Trim());
                }
                if (cbo_Type.SelectedValue.ToString() != "-1")
                {
                    strbild.AppendFormat(" and a.S_Doc_Type='{0}'", cbo_Type.SelectedValue.ToString());
                }
                if (!string.IsNullOrEmpty(dtp_TimeMax.Text.Trim()))
                {
                    strbild.AppendFormat(" and a.Create_Time<=CONVERT(DATETIME,'{0}')", dtp_TimeMax.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtBeforeDoc.Text.Trim()))
                {
                    strbild.AppendFormat(" and a.Before_Doc_No='{0}'", txtBeforeDoc.Text.Trim());
                }
                dt_StorageDoc = BLL_Bllb_StorageDoc_tbsd.QueryData(strbild.ToString());
                dgv_StorageDoc.DataSource = dt_StorageDoc;
                dgv_StorageMaterial.DataSource = null;
                dgvStorageDetail.DataSource = null;
            }
            catch
            {
                CIT.Client.MsgBox.Error("请输入正确的时间格式=>yyyy-mm-dd");
                return;
            }
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            QueryData();
            new CIT.MES.PubUtils().ShowNoteOKMsg("查询成功");
        }

        private void dgv_StorageDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_StorageDoc.CurrentCell == null || dgv_StorageDoc.CurrentCell.RowIndex == -1)
            {
                return;
            }
            dgv_StorageMaterial.DataSource = null;
            dgvStorageDetail.DataSource = null;
            string queryWhere = string.Format(@" where  S_Doc_NO='{0}'",
            SqlInput.ChangeNullToString(dgv_StorageDoc.Rows[dgv_StorageDoc.CurrentCell.RowIndex].Cells[S_Doc_NO.Name].Value));
            dtStorageMaterial = BLL_Bllb_StorageDoc_tbsd.QueryStorageMaterial(queryWhere);
            dgv_StorageMaterial.DataSource = dtStorageMaterial;
        }

        private void dgv_StorageMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_StorageMaterial.CurrentCell == null || dgv_StorageMaterial.CurrentCell.RowIndex == -1)
            {
                return;
            }
            dgvStorageDetail.DataSource = null;
            string queryWhere = string.Format(@" where  a.S_Doc_NO='{0}' and a.MaterialCode='{1}'",
SqlInput.ChangeNullToString(dgv_StorageMaterial.Rows[dgv_StorageMaterial.CurrentCell.RowIndex].Cells[S_Doc_NO_Material.Name].Value),
SqlInput.ChangeNullToString(dgv_StorageMaterial.Rows[dgv_StorageMaterial.CurrentCell.RowIndex].Cells[MaterialCode.Name].Value));
            dtStorageDetail = BLL_Bllb_StorageDoc_tbsd.QueryStorageDetail(queryWhere);
            dgvStorageDetail.DataSource = dtStorageDetail;
        }
    }
}
