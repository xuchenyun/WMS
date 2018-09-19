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
using CIT.Client;
using Common;
using CIT.MES;
using Common.BLL;

namespace Warehouse.UI
{
    public partial class ucStrorageDocQuery : UserControl
    {
        /// <summary>
        /// 仓库单表业务层操作数据
        /// </summary>
        Bll_Bllb_StorageDoc_tbsd t_Bllb_StorageDoc_tbsd_Bll = new Bll_Bllb_StorageDoc_tbsd();
        /// <summary>
        /// 仓库单数据源
        /// </summary>
        DataTable dtSDoc = new DataTable();
        /// <summary>
        /// 仓库单详细数据源
        /// </summary>
        DataTable dtSDoDetail = new DataTable();
        /// <summary>
        /// 初始化绑定物料（数据源来自数据库）
        /// </summary>
        private List<string> lstInit = new List<string>();
        /// <summary>
        /// 输入Key之后返回的物料信息
        /// </summary>
        private List<string> lstNew = new List<string>();
        public ucStrorageDocQuery()
        {
            InitializeComponent();
            dgv_SDocNoDetl.AutoGenerateColumns = false;
            dgv_SDoc_NO.AutoGenerateColumns = false;
            InitSDocType();
         
            DataBindToLine();
            dtp_CreateTimeMin.Value = DateTime.Now.AddDays(-1);
            //初始化物料数据源
            BLL_MdcdatMaterial bll_Material = new BLL_MdcdatMaterial();
            DataTable dt_Material = bll_Material.Select(string.Empty);
            foreach (DataRow dr in dt_Material.Rows)
            {
                lstInit.Add(dr["MaterialCode"].ToString());
            }
            cbo_MaterialCode.Items.AddRange(lstInit.ToArray());

            DataTable dt_storage = BLL.Bll_Bllb_Storage_tbs.GetListOfStorage(string.Empty);
            DataRow dr_storage = dt_storage.NewRow();
            dr_storage["Storage_SN"] = string.Empty;
            dr_storage["Storage_Name"] = string.Empty;
            dt_storage.Rows.InsertAt(dr_storage, 0);
            cbo_StorageSN.DataSource = dt_storage;
            cbo_StorageSN.ValueMember = "Storage_SN";
            cbo_StorageSN.DisplayMember = "Storage_Name";

          
        }
        /// <summary>
        /// 绑定线别数据源
        /// </summary>
        private void DataBindToLine()
        {
            DataTable dt_line = new DataTable();
            dt_line = Bll_Common.GetListOfLine(string.Empty);
            DataRow dr = dt_line.NewRow();
            dr["PLName"] = string.Empty;
            dr["PLCode"] = string.Empty;
            dt_line.Rows.InsertAt(dr, 0);
            cmb_Line.DisplayMember = "PLName";
            cmb_Line.ValueMember = "PLCode";
            cmb_Line.DataSource = dt_line;
        }

        /// <summary>
        /// 初始化单据类型
        /// </summary>
        private void InitSDocType()
        {
            DataTable dt = Common.BLL.Bll_Common.GetSysParameter("DJLX");
            S_Doc_Type.DataSource = dt.Copy();
            S_Doc_Type.DisplayMember = "DICT_VALUE";
            S_Doc_Type.ValueMember = "DICT_CODE";

            DataRow dr = dt.NewRow();
            dr["DICT_VALUE"] = string.Empty;
            dr["DICT_CODE"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);
            cbo_DocType.DataSource = dt;
            cbo_DocType.DisplayMember = "DICT_VALUE";
            cbo_DocType.ValueMember = "DICT_CODE";
        }
      
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            string strWhere = " Where 1=1";
            if (txt_Sdoc_No.Text != string.Empty)//单据号
            {
                strWhere += string.Format(" AND SD.S_Doc_NO='{0}'", txt_Sdoc_No.Text.Trim());
            }
            if (cbo_MaterialCode.Text != string.Empty)//料号
            {
                strWhere += string.Format(" AND M.MaterialCode = '{0}'", cbo_MaterialCode.Text.Trim());
            }
            if (cbo_DocType.SelectedValue.ToString() != string.Empty)
            {
                strWhere += string.Format(" AND SD.S_Doc_Type='{0}'", cbo_DocType.SelectedValue.ToString());
            }
            else
            {
                DataTable dt = (DataTable)S_Doc_Type.DataSource;
                string str = string.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                    str += str == string.Empty ? "'" + dr["DICT_CODE"].ToString() + "'" : ",'" + dr["DICT_CODE"].ToString() + "'";
                }
                strWhere += string.Format(" AND SD.S_Doc_Type in ({0})", str);
            }
            if (cmb_Line.SelectedValue.ToString() != string.Empty)//线别
            {
                strWhere += string.Format(" AND SD.PLCode='{0}'", cmb_Line.SelectedValue.ToString());
            }
          
            if (cbo_StorageSN.SelectedValue.ToString() != string.Empty)
            {
                strWhere += string.Format(" AND S.Storage_SN='{0}'", cbo_StorageSN.SelectedValue.ToString());
            }
          
            strWhere += string.Format(" AND SD.Create_Time >=convert(datetime,'{0}')", dtp_CreateTimeMin.Text.Trim());
            strWhere += string.Format(" AND SD.Create_Time <=convert(datetime,'{0}')", dtp_CreateTimeMax.Text.Trim());
            dtSDoc = Bll_Bllb_StorageDoc_tbsd.Query(strWhere);
            dgv_SDoc_NO.DataSource = dtSDoc;
            dtSDoDetail.Clear();
            new PubUtils().ShowNoteOKMsg("查询成功！");
        }
        /// <summary>
        /// 点击仓库单行查询仓库单详细数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_SDoc_NO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            string strWhere = string.Format(" where SD.S_Doc_NO='{0}'", dgv_SDoc_NO.Rows[e.RowIndex].Cells[S_Doc_NO.Name].Value.ToString());
            dtSDoDetail = t_Bllb_StorageDoc_tbsd_Bll.SelectSDoDetial(strWhere);
            dgv_SDocNoDetl.DataSource = dtSDoDetail;
        }
        /// <summary>
        /// 双击复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_SDoc_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_SDoc_NO, e);
        }

        private void btn_ExcelOut_Click(object sender, EventArgs e)
        {
            if (dgv_SDoc_NO.Rows.Count > 0)
            {
                string err = string.Empty;
                Dictionary<string, int> dic_Type = new Dictionary<string, int>();//列名|数据类型（1：Int;2:Decimal;3:string）
                dic_Type.Add("数量", 1);
                if (!Common.Helper.ExcelHelper.DataGridViewToExcel(dgv_SDoc_NO, dic_Type, out err))
                {
                    new PubUtils().ShowNoteOKMsg("导出失败");
                    return;
                }
                new PubUtils().ShowNoteOKMsg("导出成功");
            }
        }

        private void cbo_MaterialCode_TextUpdate(object sender, EventArgs e)
        {
            //清空控件数据
            this.cbo_MaterialCode.Items.Clear();
            //清空过滤数据
            lstNew.Clear();
            foreach (string var in lstInit)
            {
                if (var.Contains(cbo_MaterialCode.Text))
                {
                    lstNew.Add(var);
                }
            }
            //模糊查询结果绑定
            this.cbo_MaterialCode.Items.AddRange(lstNew.ToArray());
            //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒叙排序
            cbo_MaterialCode.SelectionStart = cbo_MaterialCode.Text.Length;
            //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置
            Cursor = Cursors.Default;
            //自动弹出下拉框
            cbo_MaterialCode.DroppedDown = true;

        }
    }
}
