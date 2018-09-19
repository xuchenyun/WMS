using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse.BLL;
using CIT.MES;
using CIT.Wcf.Utils;

namespace Warehouse.UI
{
    public partial class ucMaterialBack : UserControl
    {
        public ucMaterialBack()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            Query();
            //dgv_Material.DataSource = null;
            //dgv_Detail.DataSource = null;
            new PubUtils().ShowNoteOKMsg("查询成功！");
        }
        private void Query()
        {
            string strWhere = "";
            if (txt_Sdoc_No.Text.Trim() != string.Empty)//单据号
            {
                strWhere += string.Format(" AND a.S_Doc_NO='{0}'", txt_Sdoc_No.Text.Trim());
            }
            if (txt_MaterialCode.Text.Trim() != string.Empty)//料号
            {
                strWhere += string.Format(" AND b.MaterialCode = '{0}'", txt_MaterialCode.Text.Trim());
            }
            strWhere += string.Format(" AND a.Create_Time >=convert(datetime,'{0}')", dtp_CreateTimeMin.Text.Trim());
            strWhere += string.Format(" AND a.Create_Time <=convert(datetime,'{0}')", dtp_CreateTimeMax.Text.Trim());
            if (dgv_Detail.DataSource != null)//查询退料单据前先把物料SN信息删除
            {
                DataTable dt = (DataTable)dgv_Detail.DataSource;
                dt.Rows.Clear();
                dgv_Detail.DataSource = dt;
            }

            DataTable dtSDocMatr = Bll_Bllb_StorageDoc_tbsd.Query(strWhere);
            dgv_Material.DataSource = dtSDocMatr;
        }

        private void dgv_Material_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            string strWhere = string.Format(" where S_Doc_NO='{0}' and MaterialCode='{1}'", dgv_Material.Rows[e.RowIndex].Cells[S_Doc_NO2.Name].Value.ToString(), dgv_Material.Rows[e.RowIndex].Cells[MaterialCode2.Name].Value.ToString());
            dgv_Detail.DataSource = Bll_Bllb_StorageDocDetail_tbsdd.QuerySDocDetail(strWhere);
        }
        /// <summary>
        /// 退料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_back_Click(object sender, EventArgs e)
        {
            FrmMaterialBack frm = new FrmMaterialBack();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                new PubUtils().ShowNoteOKMsg("退料成功！");
            }
        }

        private void dgv_Material_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_Material, e);
        }

        private void dgv_Detail_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_Detail, e);
        }
        #region 按Enter键查询
        private void txt_MaterialCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Query();             
                new PubUtils().ShowNoteOKMsg("查询成功！");
            }
        }

        private void txt_Sdoc_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("查询成功！");
            }
        }
        #endregion
    }
}
