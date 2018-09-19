using CIT.Client;
using Common.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class Form_SelectStation : Form
    {
        #region 变量
        /// <summary>
        /// 工位对象类集
        /// </summary>
        private List<Model_Bllb_station_tbs> _list_Station = new List<Model_Bllb_station_tbs>();
        /// <summary>
        /// 获取工位信息委托
        /// </summary>
        /// <param name="list_Station"></param>
        public delegate void StationHandler(List<Model_Bllb_station_tbs> list_Station);   //声明委托
        /// <summary>
        /// 获取工位信息事件
        /// </summary>
        public event StationHandler _stationEvent;        //声明事件
        /// <summary>
        /// 是否一次选择多个工位
        /// </summary>
        public bool _isMore = false;
        /// <summary>
        /// 附加查询条件
        /// </summary>
        public string _strWhere = string.Empty;
        #endregion
        #region 绑定数据
        private void DataBindToLine()
        {
            DataTable dt_Line = BLL.Bll_Common.GetListOfLine(string.Empty);
            DataRow dr = dt_Line.NewRow();
            dr["PLCODE"] = string.Empty;
            dr["PLNAME"] = string.Empty;
            dt_Line.Rows.InsertAt(dr, 0);
            cbx_Line.DataSource = dt_Line;
            cbx_Line.DisplayMember = "PLNAME";
            cbx_Line.ValueMember = "PLNAME";
        }
        #endregion
        #region 构造函数
        public Form_SelectStation()
        {
            InitializeComponent();
            dgv_Main.AutoGenerateColumns = false;
        }
        #endregion
        #region 查询
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            Query();
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        private void Query()
        {
            string strWhere = "WHERE 1=1" ;
            if (string.Empty != txt_WorkStation_SN.Text.Trim())//工位SN
            {
                strWhere += string.Format(" AND T.WORKSTATION_SN LIKE '{0}%'", txt_WorkStation_SN.Text.Trim());
            }
            if (string.Empty != txt_WorkStation_Name.Text.Trim())//工位名称
            {
                strWhere = string.Format(" AND T.WORKSTATION_NAME LIKE '{0}%'", txt_WorkStation_Name.Text.Trim());
            }
            if (string.Empty != cbx_Line.SelectedValue.ToString())
            {
                strWhere += string.Format(" AND T.PLCODE = '{0}'", cbx_Line.SelectedValue.ToString());
            }
            if (_strWhere != string.Empty)
            {
                strWhere += " AND " + _strWhere;
            }
            dgv_Main.DataSource = BLL.Bll_Common.GetListofStation(strWhere);
        }
        #endregion
        #region 选择
        /// <summary>
        /// 选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
           Model_Bllb_station_tbs obj_Station ;
            int iSelectedRows = 0;
            foreach (DataGridViewRow dgvr in dgv_Main.Rows)
            {
                if (dgvr.Cells[checkId.Name].EditedFormattedValue.ToString() == "True")//在获取datagridview中可编辑的列的值得时候 一定要用 EditedFormattedValue属性，此属性获取的是编辑以后数值 而value 和 FormattedValue返回的往往是编辑以前的数值
                {
                    obj_Station = new Model_Bllb_station_tbs();
                    obj_Station =PublicSetModel<Model_Bllb_station_tbs>.GetTByDataGridViewRow(dgvr);
                    _list_Station.Add(obj_Station);
                    iSelectedRows++;
                }
            }
            if (iSelectedRows == 0)
            {
                if (_isMore == true)
                {
                    MsgBox.Error("请选择工位");
                }
                else
                {
                    MsgBox.Error("请选择一个工位");
                }           
                return;
            }
            if (_stationEvent != null)
            {
                _stationEvent(_list_Station);
            }
        }

        #endregion
        #region 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_SelectStation_Load(object sender, EventArgs e)
        {
            DataBindToLine();
        }
        #endregion
    }
}
