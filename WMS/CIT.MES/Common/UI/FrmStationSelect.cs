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


    public partial class FrmStationSelect : BaseForm
    {
        public delegate void DelRowDataHandler(DataTable dt);
        #region 变量
        /// <summary>
        /// 选中行委托
        /// </summary>
        public DelRowDataHandler _delStationRowDataHandler;
        /// <summary>
        /// 工位表业务层操作对象
        /// </summary>
        BLL_Bllb_station_tbs t_Bllb_station_tbs_BLL = new BLL_Bllb_station_tbs();

        /// <summary>
        /// 对话框结果
        /// </summary>
        DialogResult result = DialogResult.Cancel;
        /// <summary>
        /// 工序类型
        /// </summary>
        public string group_type = string.Empty;
        #endregion
        public FrmStationSelect()
        {
            InitializeComponent();
            dgv_workStation.AutoGenerateColumns = false;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (dgv_workStation.SelectedRows.Count == 0)
            {
                MsgBox.Error("请先选中行！");
                return;
            }
            else if (dgv_workStation.SelectedRows.Count > 1)
            {
                MsgBox.Error("请勿选择多行！");
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("TBS_ID");
            dt.Columns.Add("PLName");
            dt.Columns.Add("WORKSTATION_SN");
            dt.Columns.Add("WORKSTATION_NAME");
            dt.Columns.Add("PLCode");
            DataRow dr = dt.NewRow();
            dr["TBS_ID"] = dgv_workStation.SelectedRows[0].Cells[0].Value.ToString().Trim();
            dr["PLName"] = dgv_workStation.SelectedRows[0].Cells[1].Value.ToString().Trim();//线别名称
            dr["WORKSTATION_SN"] = dgv_workStation.SelectedRows[0].Cells[2].Value.ToString().Trim();//工位SN
            dr["WORKSTATION_NAME"] = dgv_workStation.SelectedRows[0].Cells[3].Value.ToString().Trim();//工位名称
            dr["PLCode"] = dgv_workStation.SelectedRows[0].Cells[4].Value.ToString().Trim();//线别代码
            dt.Rows.Add(dr);
            _delStationRowDataHandler(dt);
            this.result = DialogResult.OK;
            this.Close();
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmStationSelect_Load(object sender, EventArgs e)
        {
            //初始化线别下拉框
            DataTable dt_pl = Bll_Common.GetListOfLine(string.Empty);
            DataRow dr_pl = dt_pl.NewRow();
            dr_pl["PLName"] = string.Empty;
            dr_pl["PLCode"] = "-1";
            dt_pl.Rows.InsertAt(dr_pl, 0);
            cbo_plCode.DataSource = dt_pl;
            cbo_plCode.DisplayMember = "PLName";
            cbo_plCode.ValueMember = "PLCode";

            //初始化datagridview数据源
            string strWhere = " 1=1";
            if (this.group_type != string.Empty)
            {
                strWhere += string.Format(@"and g.GROUP_TYPE='{0}'", group_type);
            }
            DataTable dt = t_Bllb_station_tbs_BLL.Query(strWhere);
            dgv_workStation.DataSource = dt;
        }
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            GetStationInfo();
        }
        private void GetStationInfo()
        {
            T_Bllb_station_tbs tbs = new T_Bllb_station_tbs();
            string strWhere = " 1=1";
            if (txt_stationName.Text != "")//工位名
                strWhere += string.Format(@"and WORKSTATION_NAME like'{0}%'", txt_stationName.Text);
            if (txt_stationSn.Text != "")//工位SN
                strWhere += string.Format(@"and WORKSTATION_SN like'{0}%'", txt_stationSn.Text);
            if (cbo_plCode.SelectedValue.ToString() != "-1")//线别
                strWhere += string.Format(@"and m.PLCode like'{0}%'", cbo_plCode.SelectedValue.ToString().Trim());
            if (this.group_type != string.Empty)//工序类型
                strWhere += string.Format(@"and g.GROUP_TYPE='{0}'", group_type);
            DataTable dt = t_Bllb_station_tbs_BLL.Query(strWhere);
            dgv_workStation.DataSource = dt;
            new PubUtils().ShowNoteOKMsg("查询成功");
        }
        private void txt_stationName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetStationInfo();
            }
        }
        private void txt_stationSn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetStationInfo();
            }
        }
        private void FrmStationSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = this.result;
        }

        private void dgv_workStation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_workStation, e);
        }
    }
}
