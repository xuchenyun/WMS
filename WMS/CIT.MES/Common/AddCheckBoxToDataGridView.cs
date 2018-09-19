using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Common.Control
{
    /// <summary>
    /// 给DataGridView添加全选  
    /// </summary>
    public class AddCheckBoxToDataGridView
    {
        public static System.Windows.Forms.DataGridView dgv;
        public static void AddFullSelect(System.Windows.Forms.DataGridView dgv)
        {
            DrawCkBox(dgv);
        }
        private static void DrawCkBox(System.Windows.Forms.DataGridView dgv)
        {
            System.Windows.Forms.CheckBox ckBox = new System.Windows.Forms.CheckBox();
            System.Drawing.Point p = dgv.GetCellDisplayRectangle(0, -1, true).Location;
            ckBox.Size = new System.Drawing.Size(18, 18);
            p.Offset(((dgv.Columns[0].Width - ckBox.Width) / 2) + 4, 2);
            ckBox.Location = p;
            ckBox.Visible = true;
            ckBox.BringToFront();
            ckBox.BackColor = System.Drawing.Color.White;
            ckBox.ThreeState = false;
            ckBox.Checked = false;
            ckBox.CheckedChanged += new EventHandler(ckBox_CheckedChanged);
            dgv.Controls.Add(ckBox);
        }
        static void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.DataGridView dgvParent = (System.Windows.Forms.DataGridView)(((System.Windows.Forms.CheckBox)sender).Parent);
                foreach (DataGridViewRow dgvr in dgvParent.Rows)
                {
                    dgvr.Cells[0].Value = ((System.Windows.Forms.CheckBox)sender).Checked;
                    if (dgvr.Cells[0].Value.ToString() == "True")
                    {
                        dgvParent.Rows[dgvr.Index].Selected = true;
                    }
                    else
                    {
                        dgvParent.Rows[dgvr.Index].Selected = false;
                    }
                }
                dgvParent.EndEdit();
            }
            catch (Exception ee)
            {


            }

        }
    }
}
