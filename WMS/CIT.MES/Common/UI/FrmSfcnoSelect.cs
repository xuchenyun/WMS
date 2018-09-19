using CIT.Client;
using CIT.MES;
using Common.BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Common.UI
{

    public partial class FrmSfcnoSelect : BaseForm
    {
        /// <summary>
        /// 委托
        /// </summary>
        /// <param name="dt"></param>
        public delegate void DelRowDataHandler(DataTable dt);
        /// <summary>
        ///委托变量
        /// </summary>
        public DelRowDataHandler _delRowDataHandler;
        /// <summary>
        /// /制令单业务层操作类
        /// </summary>
        BLL_SfcDatProduct sfcDatProduct_BLL = new BLL_SfcDatProduct();
        string strWhere = " line not like 'SMT%' ";
        public FrmSfcnoSelect()
        {
            InitializeComponent();
            dgv_sfnc.AutoGenerateColumns = false;
        }
        /// <summary>
        /// 窗体载入初始化制令单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSfcnoSelect_Load(object sender, EventArgs e)
        {
            DataTable dtSfcNo = sfcDatProduct_BLL.Select(strWhere);
            dgv_sfnc.DataSource = dtSfcNo;
            dgv_sfnc.ClearSelection();
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (dgv_sfnc.SelectedRows.Count == 0)
            {
                MsgBox.Error("请先选中行");
                return;
            }
            else if (dgv_sfnc.SelectedRows.Count > 1)
            {
                MsgBox.Error("请勿选择多行");
                return;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("FGuid");//唯一码
                dt.Columns.Add("SfcNo");//制令单
                dt.Columns.Add("TBT_ID");//工艺ID
                dt.Columns.Add("Product");//产品代码
                DataRow dr = dt.NewRow();
                dr["FGuid"] = dgv_sfnc.SelectedRows[0].Cells["FGuid"].Value.ToString();
                dr["SfcNo"] = dgv_sfnc.SelectedRows[0].Cells["SfcNo"].Value.ToString();
                dr["TBT_ID"] = dgv_sfnc.SelectedRows[0].Cells["TBT_ID"].Value.ToString();
                dr["Product"] = dgv_sfnc.SelectedRows[0].Cells["Product"].Value.ToString();
                dt.Rows.Add(dr);
                _delRowDataHandler(dt);
                this.Close();
            }
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_query_Click(object sender, EventArgs e)
        {
            string strWhere_2 = strWhere ;
            if (txt_sfcno.Text != "")
                strWhere_2 += string.Format(" and SfcNo like'{0}%'", txt_sfcno.Text);
            DataTable dt = sfcDatProduct_BLL.Select(strWhere_2);
            dgv_sfnc.DataSource = dt;
            new PubUtils().ShowNoteOKMsg("查询成功");
        }
        private void dgv_sfnc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_sfnc, e);
        }
    }
}
