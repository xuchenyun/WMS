using CIT.Client;
using CIT.MES;
using CIT.Wcf.Utils;
using Common.Helper;
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
using Warehouse.BLL;

namespace Warehouse.UI
{
    public partial class FrmMaterialMoveAdd : BaseForm
    {
        bool _IsAddOrEdit = false; //操作标志位 新增--false 修改--true
        /// <summary>
        /// 对话框结果返回值
        /// </summary>
        DialogResult result = DialogResult.Cancel;
        DataTable dt_MaterialMove = new DataTable();
        /// <summary>
        /// 要新增的物料单据号的集合
        /// </summary>
        List<T_Bllb_StorageDocMaterial_tsdm> lstMaterial = new List<T_Bllb_StorageDocMaterial_tsdm>();
        /// <summary>
        /// 要删除的物料单据的集合
        /// </summary>
        List<T_Bllb_StorageDocMaterial_tsdm> lstDelMaterial = new List<T_Bllb_StorageDocMaterial_tsdm>();
        public T_Bllb_StorageDocMaterial_tsdm DocM = new T_Bllb_StorageDocMaterial_tsdm();
        public T_Bllb_StorageDoc_tbsd Doc = new T_Bllb_StorageDoc_tbsd();
        public FrmMaterialMoveAdd(bool isAddOrEdit)
        {
            this._IsAddOrEdit = isAddOrEdit;
            InitializeComponent();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            T_Bllb_StorageDoc_tbsd SC = new T_Bllb_StorageDoc_tbsd();
            T_Bllb_StorageDocMaterial_tsdm SCD = new T_Bllb_StorageDocMaterial_tsdm();
            bool isSucess = false;
            if (_IsAddOrEdit == false)//新增
            {
                if (txt_DOC_NO.Text != string.Empty)
                {
                    SC.S_Doc_NO = txt_DOC_NO.Text.Trim();//单据号                
                }
                if (cbo_SourceStorage.SelectedValue.ToString() != string.Empty)
                {
                    SC.Source_Storage = cbo_SourceStorage.SelectedValue.ToString();//原仓库
                }
                if (cbo_TargetStorage.SelectedValue.ToString() != string.Empty)
                {
                    SC.Target_Storage = cbo_TargetStorage.SelectedValue.ToString();//目的仓库
                }
                if (txt_memo.Text != string.Empty)
                {
                    SC.Memo = txt_memo.Text.Trim();//备注
                }
                if (cbo_SourceStorage.SelectedValue.ToString() == cbo_TargetStorage.SelectedValue.ToString())
                {
                    new PubUtils().ShowNoteNGMsg("原仓库不能跟目的仓库相同", 2, grade.OrdinaryError);
                    return;
                }
                lstMaterial.Clear();
                foreach (DataGridViewRow row in dgv_MaterialMoveAdd.Rows)
                {
                    if (!ValiMaterialCode(row))
                    {
                        return;
                    }
                    SCD.S_Doc_NO = txt_DOC_NO.Text.Trim();
                    SCD.RowNumber = SqlInput.ChangeNullToInt(row.Cells["RowNumber"].Value, 0);//行号
                    SCD.MaterialCode = SqlInput.ChangeNullToString(row.Cells["MaterialCode"].Value);//料号             
                    row.Cells["StorageQTY"].Value = Bll_Bllb_StockInfo_tbsi.GetQty(cbo_SourceStorage.SelectedValue.ToString(), SqlInput.ChangeNullToString(row.Cells["MaterialCode"].Value));
                    SCD.QTY = SqlInput.ChangeNullToInt(row.Cells["StorageQTY"].Value, 0);//库存量
                    SCD.Plan_Qty = SqlInput.ChangeNullToInt(row.Cells["Plan_Qty"].Value, 0);//计划数量                
                    lstMaterial.Add(SCD);
                    SCD = new T_Bllb_StorageDocMaterial_tsdm();
                }
                if (lstMaterial.Count > 0)
                {
                    if (Bll_Bllb_StorageDoc_tbsd.InsertDoc(SC))
                    {
                        isSucess = Bll_Bllb_StorageDocMaterial_tsdm.InsertMaterial(lstMaterial);
                    }
                }
            }
            else//修改
            {
                lstMaterial.Clear();
                foreach (DataGridViewRow row in dgv_MaterialMoveAdd.Rows)
                {
                    if (!ValiMaterialCode(row))
                    {
                        return;
                    }
                    SCD.S_Doc_NO = txt_DOC_NO.Text.Trim();
                    SCD.RowNumber = SqlInput.ChangeNullToInt(row.Cells["RowNumber"].Value, 0);//行号
                    SCD.MaterialCode = SqlInput.ChangeNullToString(row.Cells["MaterialCode"].Value);//料号             
                    row.Cells["StorageQTY"].Value = Bll_Bllb_StockInfo_tbsi.GetQty(cbo_SourceStorage.SelectedValue.ToString(), SqlInput.ChangeNullToString(row.Cells["MaterialCode"].Value));
                    SCD.QTY = SqlInput.ChangeNullToInt(row.Cells["StorageQTY"].Value, 0);//库存量
                    SCD.Plan_Qty = SqlInput.ChangeNullToInt(row.Cells["Plan_Qty"].Value, 0);//计划数量                
                    lstMaterial.Add(SCD);
                    SCD = new T_Bllb_StorageDocMaterial_tsdm();
                }
                if (lstMaterial.Count > 0)
                {
                    string strWhere = string.Format("S_Doc_NO ='{0}'", txt_DOC_NO.Text.Trim());
                    if (Bll_Bllb_StorageDocMaterial_tsdm.DeleteMaterial(strWhere))
                    {
                        isSucess = Bll_Bllb_StorageDocMaterial_tsdm.InsertMaterial(lstMaterial);
                    }

                }
            }
            if (isSucess)
            {
                new PubUtils().ShowNoteOKMsg("保存成功！");
                this.result = DialogResult.OK;
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
        string Qty = string.Empty;
        /// <summary>
        /// 右键新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_MaterialMoveAdd.Rows.Count != 0)
            {
                if (!ValiMaterialCode(dgv_MaterialMoveAdd.Rows[dgv_MaterialMoveAdd.Rows.Count - 1]))
                {
                    return;
                }
            }
            if (_IsAddOrEdit == false)//新增时右键新增
            {
                dgv_MaterialMoveAdd.Rows.Add();
            }
            else//编辑时右键新增
            {
                DataRow dr = dt_MaterialMove.NewRow();
                dt_MaterialMove.Rows.Add(dr);
            }
            ///生成行号
            int rowindex = dgv_MaterialMoveAdd.Rows.Count - 1;
            dgv_MaterialMoveAdd.Rows[rowindex].Cells["RowNumber"].Value = rowindex + 1;
        }
        /// <summary>
        /// 右键删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_MaterialMoveAdd.Rows.Count == 0)
            {
                return;
            }
            dgv_MaterialMoveAdd.Rows.Remove(dgv_MaterialMoveAdd.CurrentRow);
            foreach (DataGridViewRow dgvr in dgv_MaterialMoveAdd.Rows)
            {
                dgvr.Cells["RowNumber"].Value = dgvr.Index + 1;
            }
        }
        private bool ValiMaterialCode(DataGridViewRow row)
        {
            if (row.Cells["MaterialCode"].EditedFormattedValue.ToString() == string.Empty)
            {
                new PubUtils().ShowNoteNGMsg("料号不能为空", 2, grade.RepeatedError);
                return false;
            }

            string strSql = string.Format("select * from T_Bllb_StockInfo_tbsi where MaterialCode='{0}'", row.Cells["MaterialCode"].EditedFormattedValue);
            DataTable dt_MaterialExist = NMS.QueryDataTable(PubUtils.uContext, strSql);
            if (dt_MaterialExist.Rows.Count == 0)
            {
                new PubUtils().ShowNoteNGMsg("料号不存在", 2, grade.OrdinaryError);
                return false;
            }
            if (_IsAddOrEdit == true && dgv_MaterialMoveAdd.Rows.Count == 1)
            {
                return true;
            }
            if (_IsAddOrEdit == false)
            {
                string str_Exist = string.Format("select * from T_Bllb_StorageDocMaterial_tsdm where MaterialCode='{0}' and S_Doc_NO='{1}'", row.Cells["MaterialCode"].EditedFormattedValue, txt_DOC_NO.Text.Trim());
                DataTable dt_Exist = NMS.QueryDataTable(PubUtils.uContext, str_Exist);
                if (dt_Exist.Rows.Count > 0)
                {
                    new PubUtils().ShowNoteNGMsg("单据不能添加重复的料号", 2, grade.OrdinaryError);
                    return false;
                }
            }

            foreach (DataGridViewRow dgvr in dgv_MaterialMoveAdd.Rows)
            {
                if (dgvr.Index == row.Index)
                {
                    continue;
                }
                if (SqlInput.ChangeNullToString(dgvr.Cells["MaterialCode"].EditedFormattedValue) == SqlInput.ChangeNullToString(row.Cells["MaterialCode"].EditedFormattedValue))
                {
                    new PubUtils().ShowNoteNGMsg("料号不能重复添加", 2, grade.OrdinaryError);
                    return false;
                }
            }
            if (row.Cells["StorageQTY"].Value != null)
            {
                if (row.Cells["Plan_Qty"].EditedFormattedValue == null)
                {
                    new PubUtils().ShowNoteNGMsg("计划数量不能为空", 2, grade.OrdinaryError);
                    return false;
                }
            }

            if (!(row.Cells["Plan_Qty"].Value == null && row.Cells["StorageQTY"].Value == null))
            {
                if (SqlInput.ChangeNullToInt(row.Cells["Plan_Qty"].EditedFormattedValue, 0) > SqlInput.ChangeNullToInt(row.Cells["StorageQTY"].Value, 0))
                {
                    new PubUtils().ShowNoteNGMsg("计划数量必须小于库存数量", 2, grade.OrdinaryError);
                    return false;
                }
            }

            return true;

        }
        /// <summary>
        /// 料号和原仓库带出库存数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_MaterialMoveAdd_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_MaterialMoveAdd.Columns["MaterialCode"].Index)
            {
                GetQty();
            }

        }
        private void GetQty()
        {
            if (dgv_MaterialMoveAdd.CurrentRow.Cells["MaterialCode"].EditedFormattedValue != null || dgv_MaterialMoveAdd.CurrentRow.Cells["MaterialCode"].EditedFormattedValue.ToString() != string.Empty)
            {
                dgv_MaterialMoveAdd.CurrentRow.Cells["StorageQTY"].Value = Bll_Bllb_StockInfo_tbsi.GetQty(cbo_SourceStorage.SelectedValue.ToString(), dgv_MaterialMoveAdd.CurrentRow.Cells["MaterialCode"].EditedFormattedValue.ToString());
                StorageQTY.ReadOnly = true;

                if (dgv_MaterialMoveAdd.CurrentRow.Cells["StorageQTY"].Value.ToString() == "0")//库存数量如果是0，带出计划数量0
                {
                    dgv_MaterialMoveAdd.CurrentRow.Cells["Plan_Qty"].Value = 0;
                }
            }
        }
        private void FrmMaterialMoveAdd_Load(object sender, EventArgs e)
        {
            string strSql = string.Format(" select Storage_SN,Storage_Name from  T_Bllb_Storage_tbs");
            DataTable dt_Storage = NMS.QueryDataTable(PubUtils.uContext, strSql);
            cbo_SourceStorage.DataSource = dt_Storage;
            cbo_SourceStorage.DisplayMember = "Storage_Name";
            cbo_SourceStorage.ValueMember = "Storage_SN";

            string strTarget = string.Format(" select Storage_SN,Storage_Name from  T_Bllb_Storage_tbs");
            DataTable dt_TargetS = NMS.QueryDataTable(PubUtils.uContext, strTarget);
            cbo_TargetStorage.DataSource = dt_TargetS;
            cbo_TargetStorage.DisplayMember = "Storage_Name";
            cbo_TargetStorage.ValueMember = "Storage_SN";

            txt_DOC_NO.Text = Bll_Bllb_StorageDoc_tbsd.Get_MaterialMove_Doc();
            if (_IsAddOrEdit)
            {
                txt_DOC_NO.Text = Doc.S_Doc_NO;//单据号
                cbo_SourceStorage.Text = Doc.Source_Storage;//原仓库
                cbo_TargetStorage.Text = Doc.Target_Storage;//目的仓库
                txt_memo.Text = Doc.Memo;//备注
                string materialCode = DocM.MaterialCode;//料号

                //string strWhere = string.Format("Where b.S_Doc_NO ='{0}' AND Storage_SN='{1}' AND a.MaterialCode='{2}'", txt_DOC_NO.Text.Trim(), cbo_SourceStorage.SelectedValue, materialCode);
                ////dt_MaterialMove = Bll_Bllb_StorageDocMaterial_tsdm.Select(strWhere);
                //DataTable dt = Bll_Bllb_StorageDocMaterial_tsdm.Select(strWhere);
                //    if (dt.Rows.Count > 0)
                //{
                //    dgv_MaterialMoveAdd.DataSource = dt;
                //    dgv_MaterialMoveAdd.ClearSelection();
                //}
                //else
                //{
                //    string strcmd = string.Format("S_Doc_NO='{0}' AND MaterialCode='{1}'", txt_DOC_NO.Text.Trim(),materialCode);
                //    dt_MaterialMove = Bll_Bllb_StorageDocMaterial_tsdm.Query(strcmd);
                //    dgv_MaterialMoveAdd.DataSource = dt_MaterialMove;
                //    dgv_MaterialMoveAdd.ClearSelection();

                //}
                string strcmd = string.Format("S_Doc_NO='{0}' ", txt_DOC_NO.Text.Trim());
                dt_MaterialMove = Bll_Bllb_StorageDocMaterial_tsdm.Query(strcmd);
                dgv_MaterialMoveAdd.DataSource = dt_MaterialMove;
                dgv_MaterialMoveAdd.ClearSelection();

                txt_DOC_NO.ReadOnly = true;
                cbo_SourceStorage.Enabled = false;
                cbo_TargetStorage.Enabled = false;
                txt_memo.ReadOnly = true;

                GetQty();
            }

        }

        private void dgv_MaterialMoveAdd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)//点击表头或者行头什么也不做
                return;
            if (_IsAddOrEdit)
            {
                dgv_MaterialMoveAdd.CurrentRow.Cells["StorageQTY"].ReadOnly = true;
            }
            
            this.dgv_MaterialMoveAdd.CurrentCell = this.dgv_MaterialMoveAdd.Rows[e.RowIndex].Cells[e.ColumnIndex];
            this.dgv_MaterialMoveAdd.BeginEdit(true);
        }

        private void FrmMaterialMoveAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = this.result;
        }

    }
}
