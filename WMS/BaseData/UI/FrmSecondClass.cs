using BaseData.DAL;
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

namespace BaseData.UI
{
    public partial class FrmSecondClass : BaseForm
    {
        /// <summary>
        /// 辅材等级表数据源表格
        /// </summary>
        DataTable dt_SecondClass = new DataTable();
        /// <summary>
        /// 对话框结果返回值
        /// </summary>
        DialogResult result = DialogResult.Cancel;
        /// <summary>
        /// 新增辅材等级表集合
        /// </summary>
        List<T_Bllb_SecondClass_tbsc> lstInsert = new List<T_Bllb_SecondClass_tbsc>();

        public FrmSecondClass()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            T_Bllb_SecondClass_tbsc SC = new T_Bllb_SecondClass_tbsc();
            lstInsert.Clear();
            foreach (DataGridViewRow row in dgv_SencondClass.Rows)
            {
                if (!ValidataInput(row))
                {
                    return;
                }
                if (cbo_Type.SelectedValue.ToString() != string.Empty)//类型
                {
                    SC.Type = cbo_Type.Text.ToString();
                }
                if (txt_Class.Text.Trim() != string.Empty)//等级
                {
                    SC.Class = txt_Class.Text.Trim();
                }
                if (row.Cells["OrderNum"].Value != null)//序号
                {
                    SC.OrderNum = SqlInput.ChangeNullToString(row.Cells["OrderNum"].Value);
                }
                if (row.Cells["Condition"].Value != null)//条件
                {
                    SC.Condition = SqlInput.ChangeNullToString(row.Cells["Condition"].Value);
                }

                if (row.Cells["TemperatureMaxTime"].Value != null)//最大回温时间
                {
                    SC.TemperatureMaxTime = SqlInput.ChangeNullToInt(row.Cells["TemperatureMaxTime"].Value, 0);
                }

                if (row.Cells["TemperatureMinTime"].Value != null)//最小回温时间
                {
                    SC.TemperatureMinTime = SqlInput.ChangeNullToInt(row.Cells["TemperatureMinTime"].Value, 0);
                }

                if (row.Cells["ExposeTime"].Value != null)//暴露时间
                {
                    SC.ExposeTime = SqlInput.ChangeNullToInt(row.Cells["ExposeTime"].Value, 0);

                }

                if (row.Cells["InHouseTime"].Value != null)//冷藏时间
                {
                    SC.InHouseTime = SqlInput.ChangeNullToInt(row.Cells["InHouseTime"].Value, 0);
                }
                if (row.Cells["SplitTime"].Value != null)//拆分次数
                {
                    SC.SplitTime = SqlInput.ChangeNullToString(row.Cells["SplitTime"].Value);
                }

                if (row.Cells["RoastMaxTemperature"].Value != null)//最大烘烤温度
                {
                    SC.RoastMaxTemperature = SqlInput.ChangeNullToDecimal(row.Cells["RoastMaxTemperature"].Value, 0);
                }

                if (row.Cells["RoastMinTemperature"].Value != null)//最小烘烤温度
                {
                    SC.RoastMinTemperature = SqlInput.ChangeNullToDecimal(row.Cells["RoastMinTemperature"].Value, 0);
                }
                if (row.Cells["RoastTime"].Value != null)//烘烤时间
                {
                    SC.RoastTime = SqlInput.ChangeNullToInt(row.Cells["RoastTime"].Value, 0);
                }
                if (row.Cells["Remark"].Value != null)//备注
                {
                    //SC.Remark = row.Cells["Remark"].Value.ToString();
                    SC.Remark = SqlInput.ChangeNullToString(row.Cells["Remark"].Value);
                }
                lstInsert.Add(SC);
                SC = new T_Bllb_SecondClass_tbsc();
            }
            if (lstInsert.Count > 0)
            {
                isSuccess = T_Bllb_SecondClass_tbsc_DAL.Insert(lstInsert);
            }
            if (isSuccess)
            {
                new PubUtils().ShowNoteOKMsg("保存成功！");
                this.result = DialogResult.OK;
                this.Close();
            }
        }
        private bool ValidataInput(DataGridViewRow row)
        {
            string msg = string.Empty;

            if (txt_Class.Text == string.Empty)
            {
                new PubUtils().ShowNoteNGMsg("等级不能为空", 2, grade.RepeatedError);
                return false;
            }
            string sqlcmd = string.Format("SELECT * FROM T_Bllb_SecondClass_tbsc WHERE Type='{0}' AND Class='{1}'", cbo_Type.Text, txt_Class.Text.Trim());
            if (NMS.QueryDataTable(PubUtils.uContext, sqlcmd).Rows.Count > 0)
            {
                new PubUtils().ShowNoteNGMsg("该类型的等级已存在", 2, grade.RepeatedError);
                return false;
            }

            //if (/*row.Cells["TemperatureMaxTime"].Value == null && row.Cells["TemperatureMinTime"].Value == null &&*/ /*row.Cells["ExposeTime"].Value == null && */row.Cells["InHouseTime"].Value == null && row.Cells["SplitTime"].Value == null/* && row.Cells["RoastMaxTemperature"].Value == null && row.Cells["RoastMinTemperature"].Value == null && row.Cells["RoastTime"].Value == null */&& row.Cells["Remark"].Value == null)
            //    continue;
            if (cbo_Type.SelectedValue.ToString() == "2")
            {
                if (!CheckTime(row, out msg))
                {
                    MsgBox.Error(msg);
                    return false;
                }
            }
            if (cbo_Type.SelectedValue.ToString() == "0" || cbo_Type.SelectedValue.ToString() == "1")
            {
                if (row.Cells["TemperatureMinTime"].Value == null)
                {
                    new PubUtils().ShowNoteNGMsg("最小回温时间不能为空", 2, grade.RepeatedError);
                    return false;
                }
                if (row.Cells["TemperatureMaxTime"].Value == null)
                {
                    new PubUtils().ShowNoteNGMsg("最大回温时间不能为空", 2, grade.RepeatedError);
                    return false;
                }

            }
            if (cbo_Type.SelectedValue.ToString() == "2")
            {
                if (row.Cells["RoastMinTemperature"].Value == null)
                {
                    new PubUtils().ShowNoteNGMsg("最小烘烤温度不能为空", 2, grade.RepeatedError);
                    return false;
                }
                if (row.Cells["RoastMaxTemperature"].Value == null)
                {
                    new PubUtils().ShowNoteNGMsg("最大烘烤温度不能为空", 2, grade.RepeatedError);
                    return false;
                }
                if (row.Cells["RoastTime"].Value == null)
                {
                    new PubUtils().ShowNoteNGMsg("烘烤时间不能为空", 2, grade.RepeatedError);
                    return false;
                }
                if (row.Cells["ExposeTime"].Value == null || SqlInput.ChangeNullToInt(row.Cells["ExposeTime"].Value, 0) == 0)
                {
                    new PubUtils().ShowNoteNGMsg("暴露时间不能为空", 2, grade.RepeatedError);
                    return false;
                }
            }
            if ((row.Cells["TemperatureMinTime"].Value != null && row.Cells["TemperatureMaxTime"].Value != null) && SqlInput.ChangeNullToInt(row.Cells["TemperatureMinTime"].Value, 0) >= SqlInput.ChangeNullToInt(row.Cells["TemperatureMaxTime"].Value, 0))
            {
                new PubUtils().ShowNoteNGMsg("最小回温时间必须小于最大回温时间", 2, grade.RepeatedError);
                return false;
            }
            if ((row.Cells["RoastMinTemperature"].Value != null && row.Cells["RoastMaxTemperature"].Value != null) && SqlInput.ChangeNullToDecimal(row.Cells["RoastMinTemperature"].Value, 0) >= SqlInput.ChangeNullToDecimal(row.Cells["RoastMaxTemperature"].Value, 0))
            {
                new PubUtils().ShowNoteNGMsg("最小烘烤温度必须小于最大烘烤温度", 2, grade.RepeatedError);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 校验回温时间和烘烤温度不能为空
        /// </summary>
        /// <param name="curDgvr"></param>
        /// <param name="checkMsg"></param>
        /// <returns></returns>
        private bool CheckTime(DataGridViewRow curDgvr, out string checkMsg)
        {
            foreach (DataGridViewRow dgvr in dgv_SencondClass.Rows)
            {
                if (dgvr.Index == curDgvr.Index)
                {
                    continue;
                }
                if (!(dgvr.Cells["TemperatureMaxTime"].Value == null && dgvr.Cells["TemperatureMinTime"].Value == null))
                {
                    if (SqlInput.ChangeNullToInt(dgvr.Cells["TemperatureMaxTime"].Value, 0) >= SqlInput.ChangeNullToInt(curDgvr.Cells["TemperatureMaxTime"].Value, 0)
    && SqlInput.ChangeNullToInt(dgvr.Cells["TemperatureMinTime"].Value, 0) <= SqlInput.ChangeNullToInt(curDgvr.Cells["TemperatureMaxTime"].Value, 0)
    || SqlInput.ChangeNullToInt(dgvr.Cells["TemperatureMaxTime"].Value, 0) >= SqlInput.ChangeNullToInt(curDgvr.Cells["TemperatureminTime"].Value, 0)
    && SqlInput.ChangeNullToInt(dgvr.Cells["TemperatureMinTime"].Value, 0) <= SqlInput.ChangeNullToInt(curDgvr.Cells["TemperatureminTime"].Value, 0))
                    {
                        checkMsg = "回温时间不能交叉";
                        return false;
                    }
                }
    //            if (!(dgvr.Cells["RoastMaxTemperature"].Value == null && dgvr.Cells["RoastMinTemperature"].Value == null))
    //            {
    //                if (SqlInput.ChangeNullToInt(dgvr.Cells["RoastMaxTemperature"].Value, 0) >= SqlInput.ChangeNullToInt(curDgvr.Cells["RoastMaxTemperature"].Value, 0)
    //&& SqlInput.ChangeNullToInt(dgvr.Cells["RoastMinTemperature"].Value, 0) <= SqlInput.ChangeNullToInt(curDgvr.Cells["RoastMaxTemperature"].Value, 0)
    //|| SqlInput.ChangeNullToInt(dgvr.Cells["RoastMaxTemperature"].Value, 0) >= SqlInput.ChangeNullToInt(curDgvr.Cells["RoastMinTemperature"].Value, 0)
    //&& SqlInput.ChangeNullToInt(dgvr.Cells["RoastMinTemperature"].Value, 0) <= SqlInput.ChangeNullToInt(curDgvr.Cells["RoastMinTemperature"].Value, 0))
    //                {
    //                    checkMsg = "烘烤温度不能交叉";
    //                    return false;
    //                }
    //            }
            }
            checkMsg = "OK";
            return true;
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

        private void FrmSecondClass_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DisplayValue");
            dt.Columns.Add("Value");
            DataRow dr = dt.NewRow();
            //dr["DisplayValue"] = "";
            //dr["Value"] = -1;
            //dt.Rows.InsertAt(dr, 0);
            //dr = dt.NewRow();
            dr["DisplayValue"] = "红胶";
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["DisplayValue"] = "锡膏";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["DisplayValue"] = "MSD";
            dr["Value"] = 2;
            dt.Rows.Add(dr);
            cbo_Type.DataSource = dt;
            cbo_Type.DisplayMember = "DisplayValue";
            cbo_Type.ValueMember = "Value";

            //dgv_SencondClass.Rows.Clear();
            //txt_Class.Text = T_Bllb_SecondClass_tbsc_DAL.GetClassValue(cbo_Type.Text.ToString());
        }
        /// <summary>
        /// 类型下拉框选中自动带出等级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbo_Type_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //dgv_SencondClass.Rows.Clear();
            //txt_Class.Text = T_Bllb_SecondClass_tbsc_DAL.GetClassValue(cbo_Type.Text.ToString());
        }
        string expose_time = string.Empty;

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbo_Type.SelectedValue.ToString() == "-1")
            {
                MsgBox.Error("请选择类型");
                return;
            }
            string sqlcmd = string.Format("SELECT * FROM T_Bllb_SecondClass_tbsc WHERE Type='{0}' AND Class='{1}'", cbo_Type.Text, txt_Class.Text.Trim());
            if (NMS.QueryDataTable(PubUtils.uContext, sqlcmd).Rows.Count > 0)
            {
                new PubUtils().ShowNoteNGMsg("该类型的等级已存在", 2, grade.RepeatedError);
                return ;
            }

            if (cbo_Type.SelectedValue.ToString() != "2")
            {
                if (dgv_SencondClass.Rows.Count == 1)
                {
                    MsgBox.Error("红胶或锡膏只允行添加一行数据");
                    return;
                }
            }
            if (dgv_SencondClass.Rows.Count != 0)
            {
                if (!ValidataInput(dgv_SencondClass.Rows[dgv_SencondClass.Rows.Count - 1]))
                {
                    return;
                }
            }
            dgv_SencondClass.Rows.Add();
            int rowindex = dgv_SencondClass.Rows.Count - 1;
            dgv_SencondClass.Rows[rowindex].Cells["OrderNum"].Value = rowindex + 1;
            if (dgv_SencondClass.Rows.Count == 2)
            {
                expose_time = SqlInput.ChangeNullToString(dgv_SencondClass.Rows[0].Cells["ExposeTime"].Value);
                ExposeTime.ReadOnly = true;
            }
            dgv_SencondClass.Rows[rowindex].Cells["ExposeTime"].Value = expose_time;
        }

        private void dgv_SencondClass_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)//点击表头或者行头什么也不做
                return;
            this.dgv_SencondClass.CurrentCell = this.dgv_SencondClass.Rows[e.RowIndex].Cells[e.ColumnIndex];
            this.dgv_SencondClass.BeginEdit(true);
        }

        private void FrmSecondClass_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = this.result;
        }


        private void dgv_SencondClass_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dgv_SencondClass.CurrentCellAddress.X == 2 || this.dgv_SencondClass.CurrentCellAddress.X == 3 || this.dgv_SencondClass.CurrentCellAddress.X == 4|| this.dgv_SencondClass.CurrentCellAddress.X == 5)//获取当前处于活动状态的单元格索引
            {
                CellEdit = (DataGridViewTextBoxEditingControl)e.Control;
                CellEdit.SelectAll();
                CellEdit.KeyPress += Cells_KeyPress; //绑定事件
            }
        }

        public DataGridViewTextBoxEditingControl CellEdit = null;
        private void Cells_KeyPress(object sender, KeyPressEventArgs e) //自定义事件
        {
            if ((this.dgv_SencondClass.CurrentCellAddress.X == 2) || (this.dgv_SencondClass.CurrentCellAddress.X == 3) || (this.dgv_SencondClass.CurrentCellAddress.X == 4) || (this.dgv_SencondClass.CurrentCellAddress.X == 5))//获取当前处于活动状态的单元格索引
            {
                if (!(e.KeyChar >= '0' && e.KeyChar <= '9')) e.Handled = true;
                if (e.KeyChar == '\b') e.Handled = false;
            }
        }

        private void 删除toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgv_SencondClass.CurrentRow != null)
            {
                dgv_SencondClass.Rows.Remove(dgv_SencondClass.CurrentRow);
            }
        }
    }
}
