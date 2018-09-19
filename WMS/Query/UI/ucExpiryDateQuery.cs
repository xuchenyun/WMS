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
using CIT.MES;

namespace Query.UI
{
    public partial class ucExpiryDateQuery : UserControl
    {

        DataTable dtExpriyDate;

        public ucExpiryDateQuery()
        {
            InitializeComponent();
            dgvBarCode.AutoGenerateColumns = false;
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            Query();
            new PubUtils().ShowNoteOKMsg("查询成功");
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void Query()
        {
            string strwhere = string.Empty;
            ///无条件处理超期条码
            BarCodeExpiryDateHandle(BLL_Bllb_StockInfo_tbsi.QueryExpiryDate(strwhere));
            if (!string.IsNullOrEmpty(txtMaterialCode.Text.Trim()))
            {
                strwhere += string.Format(" and a.MaterialCode='{0}'", txtMaterialCode.Text.Trim());
            }
            dtExpriyDate = BLL_Bllb_StockInfo_tbsi.QueryShowData(strwhere);
            dgvBarCode.DataSource = dtExpriyDate;
        }
        /// <summary>
        /// 处理超期条码
        /// </summary>
        /// <param name="dtHandle"></param>
        private void BarCodeExpiryDateHandle(DataTable dtHandle)
        {
            Dictionary<string, string> dicBarCode = new Dictionary<string, string>();//KEY-BarCode Value- flag 0-正常 1-超期 2-预警
            if (dtHandle.Rows.Count > 0)
            {
                foreach (DataRow dr in dtHandle.Rows)
                {
                    if (dicBarCode.ContainsKey(dr["SerialNumber"].ToString()))
                    {
                        continue;
                    }
                    if (dr["flag"].ToString() == "0")
                    {
                        dicBarCode.Add(dr["SerialNumber"].ToString(), "0");
                    }
                    else if (dr["flag"].ToString() == "1")
                    {
                        dicBarCode.Add(dr["SerialNumber"].ToString(), "1");
                    }
                    else if (dr["flag"].ToString() == "2")
                    {
                        dicBarCode.Add(dr["SerialNumber"].ToString(), "2");
                    }
                }
                BLL_Bllb_StockInfo_tbsi.UpdateBarCodeLockStatus(dicBarCode);
            }
        }

        private void dgvBarCode_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    if (dtExpriyDate.Rows.Count > 0)
                    {
                        foreach (DataRow _dr in dtExpriyDate.Rows)
                        {
                            //正常为绿色
                            if (_dr["flag"].ToString() == "0")
                            {
                                this.dgvBarCode.Rows[dtExpriyDate.Rows.IndexOf(_dr)].DefaultCellStyle.BackColor = Color.SpringGreen;
                            }
                            else if (_dr["flag"].ToString() == "1")//超期为红色
                            {
                                this.dgvBarCode.Rows[dtExpriyDate.Rows.IndexOf(_dr)].DefaultCellStyle.BackColor = Color.Red;
                            }
                            else if (_dr["flag"].ToString() == "2")//预警为黄色
                            {
                                this.dgvBarCode.Rows[dtExpriyDate.Rows.IndexOf(_dr)].DefaultCellStyle.BackColor = Color.Yellow;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void btn_sendCheck_Click(object sender, EventArgs e)
        {
            Form_SendToCheck f = new Form_SendToCheck();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Query();
                new PubUtils().ShowNoteOKMsg("送检成功");
            }
        }

        //private void dgvBarCode_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex == -1)
        //    {
        //        if (dtExpriyDate.Rows.Count > 0)
        //        {
        //            foreach (DataRow _dr in dtExpriyDate.Rows)
        //            {
        //                //正常为绿色
        //                if (_dr["flag"].ToString() == "0")
        //                {
        //                    this.dgvBarCode.Rows[dtExpriyDate.Rows.IndexOf(_dr)].DefaultCellStyle.BackColor = Color.SpringGreen;
        //                }
        //                else if (_dr["flag"].ToString() == "1")//超期为红色
        //                {
        //                    this.dgvBarCode.Rows[dtExpriyDate.Rows.IndexOf(_dr)].DefaultCellStyle.BackColor = Color.Red;
        //                }
        //                else if (_dr["flag"].ToString() == "2")//预警为黄色
        //                {
        //                    this.dgvBarCode.Rows[dtExpriyDate.Rows.IndexOf(_dr)].DefaultCellStyle.BackColor = Color.Yellow;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
