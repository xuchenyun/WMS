using CIT.Client;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse.UI
{
    public partial class Frm_LocationLotAdd : BaseForm
    {
        //public DataTable _dt_container = null;
        public Frm_LocationLotAdd()
        {
            InitializeComponent();
        }

        private void Frm_LocationLotAdd_Load(object sender, EventArgs e)
        {
            DataTable dt = BLL.Bll_Bllb_StorageArea_tbsa.GetListOfArea();//获取所有库位信息
            cbo_ParentStorage.DisplayMember = "Area_Name";
            cbo_ParentStorage.ValueMember = "Area_SN";
            cbo_ParentStorage.DataSource = dt;


            //_dt_container = BLL.Bll_Bllb_LocationContainer_tblc.GetListByLocatin_SN(string.Empty);
            //dgv_Container.DataSource = _dt_container;
        }

        //private void dgv_Container_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dgv_Container.Columns[e.ColumnIndex].Name == checkId.Name & e.RowIndex >= 0)
        //    {
        //        string container_type = dgv_Container.Rows[e.RowIndex].Cells[DICT_VALUE.Name].Value.ToString();
        //        DataRow[] drs = _dt_container.Select(string.Format("DICT_VALUE='{0}'", container_type));
        //        if (drs.Length > 0)
        //        {
        //            bool isCheck = SqlInput.ChangeBoolToValue(dgv_Container.Rows[e.RowIndex].Cells[checkId.Name].Value, false);

        //            if (isCheck == true)
        //            {
        //                switch (drs[0]["flag"].ToString())
        //                {
        //                    case "0":
        //                        drs[0]["flag"] = "2";//新增（只有状态0才能变成2）
        //                        break;
        //                    case "3":
        //                        drs[0]["flag"] = "1";//有（ 只有状态3才能变成1）（状态0和1都不对数据库进行操作）
        //                        break;
        //                }
        //            }
        //            else
        //            {
        //                switch (drs[0]["flag"].ToString())
        //                {
        //                    case "2":
        //                        drs[0]["flag"] = "0";//无（只有状态2才能变成0）（状态0和1都不对数据库进行操作）
        //                        break;
        //                    case "1":
        //                        drs[0]["flag"] = "3";//删除（只有状态1才能变成3）
        //                        break;
        //                }
        //            }
        //            dgv_Container.DataSource = _dt_container;
        //        }
        //    }
        //    else if (dgv_Container.Columns[e.ColumnIndex].Name == QTY.Name & e.RowIndex >= 0)//输入数量
        //    {
        //        string container_type = dgv_Container.Rows[e.RowIndex].Cells[DICT_VALUE.Name].Value.ToString();
        //        DataRow[] drs = _dt_container.Select(string.Format("DICT_VALUE='{0}'", container_type));
        //        if (drs.Length > 0)
        //        {
        //            int res = 1;
        //            if (int.TryParse(dgv_Container.Rows[e.RowIndex].Cells[QTY.Name].Value.ToString(), out res))
        //            {
        //                if (res <= 0)
        //                {
        //                    MessageBox.Show("请输入大于0的整数");
        //                }                       
        //            }
        //            else
        //            {
        //              MessageBox.Show("请输入大于0的整数");
        //            }
        //        }
        //    }
        //}

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_Begin_LocationSN.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入开始库位SN");
                return;
            }
            else if (txt_End_LocationSN.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入结束库位SN");
                return;
            }
            //else if (txt_Begin_LocationSN.Text.Trim().Length != txt_End_LocationSN.Text.Trim().Length)
            //{
            //    MessageBox.Show("开始库位SN与结束库位SN长度不一致");
            //    return;
            //}
            int begin = 0;
            int end = 0;
            try
            {
                begin = int.Parse(txt_Begin_LocationSN.Text.Trim());
                end = int.Parse(txt_End_LocationSN.Text.Trim());
                if (begin > end)
                {
                    MessageBox.Show("开始库位SN必须小于或者等于结束库位SN");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("开始库位SN与结束库位SN必须是数字");
                return;
            }
            #region MyRegion
            //if (_dt_container != null)
            //{
            //    DataRow[] drs = _dt_container.Select("flag='2'");
            //    if (drs.Length == 0)
            //    {
            //        MessageBox.Show("请选择可存放的容器");
            //        return;
            //    }
            //    foreach (DataRow dr in drs)
            //    {
            //        int res = 1;
            //        if (int.TryParse(dr[QTY.Name].ToString(), out res))
            //        {
            //            if (res == 0)
            //            {
            //                MessageBox.Show("请输入大于0的整数");
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("请输入大于0的整数");
            //            return;
            //        }
            //    }
            //} 
            #endregion
            while (begin <= end)
            {
                #region 库位数据操作
                Model.T_Bllb_StorageLocation_tbsl tbsl = new Model.T_Bllb_StorageLocation_tbsl();
                //tbsl.Location_SN = lbl_Begin_LocationSN.Text.Trim() + begin.ToString("00");
                //tbsl.Location_Name = "库位" + lbl_Begin_LocationSN.Text.Trim() + begin.ToString("00");
                tbsl.Location_SN = string.Format("{0}{1}", txt_fixChar.Text.Trim(), begin.ToString("00"));
                tbsl.Location_Name = string.Format("库位{0}{1}", txt_fixChar.Text.Trim(), begin.ToString("00"));
                tbsl.Area_SN = cbo_ParentStorage.SelectedValue.ToString();
                tbsl.Enable_Flag = "Y";
                if (BLL.Bll_Bllb_StorageLocation_tbsl.IsExist(tbsl.Location_SN))
                {
                    MessageBox.Show("库位" + tbsl.Location_SN + "已存在");
                    return;
                }
                BLL.Bll_Bllb_StorageLocation_tbsl.Insert(tbsl);
                #endregion
                #region 库位容器信息
                //Model.T_Bllb_LocationContainer_tblc obj = new Model.T_Bllb_LocationContainer_tblc();
                //foreach (DataRow dr in _dt_container.Rows)
                //{
                //    if (dr["flag"].ToString() == "2")//新增库位容器信息
                //    {
                //        obj.Location_SN = tbsl.Location_SN;
                //        obj.Container_Type = dr["DICT_CODE"].ToString();
                //        obj.QTY = SqlInput.ChangeNullToInt(dr["QTY"], 1);
                //        BLL.Bll_Bllb_LocationContainer_tblc.Insert(obj);
                //    }                 
                //}
                #endregion
                begin++;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cbo_ParentStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lbl_Begin_LocationSN.Text = cbo_ParentStorage.SelectedValue.ToString()+"-";
            //lbl_End_LocationSN.Text= cbo_ParentStorage.SelectedValue.ToString()+"-";
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
