using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIT.Wcf.Utils;
using CIT.MES.WMS;

namespace CIT.WMS.BRIO
{
    public partial class ucMateBinding : UserControl
    {
        public ucMateBinding()
        {
            InitializeComponent();
            pagerControl1.currentPageChange += pagerControl1_currentPageChange;

            // Orcale select count(*) from mdcdatmpn
            DataTable dt = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select count(*) from mdcdatmpn");
            pagerControl1.Init(int.Parse(dt.Rows[0][0].ToString()), 100);
            //InitData(pagerControl1.PerPage, 1);
            txt_search.Focus();
        }
        void pagerControl1_currentPageChange(object sender, EventArgs e)
        {
            uControl.PagerControl p = (uControl.PagerControl)sender;
            InitData(p.PerPage, p.CurrentPage);
        }
        private void InitData(int pagesize, int pageindex)
        {
            string sqlcmd = "";
            if (txt_search.Text.Length == 0)
            {
                //2018.02.27 Zach 增加是否送检列
                sqlcmd = string.Format(@"select w1.newPN as '新料号',w1.oldPN '旧料号',case m1.IsSendCheck when  '是' then '是' else '否' end as '是否送检',w1.MaterialMinCount as '最小包装数量',
w1.MorePack as '是否多包装',w1.IsBing as '是否Bing',w1.MSDLevel 'MSD等级',w1.ShelfType '料架类型',
w1.WarehouseLocation '库位',w1.IsEnable '是否禁用',w1.CustomerType as '客户编码',w1.SupplierName as '供应商名称',
w1.ManufacturerLocation as '供应商地址',w1.MaterialType as '物料类型',w1.Purchase as '来料方式',w1.PartCode1,w1.PartCode2,
w1.PartCode3,w1.PartCode4,w1.PartCode5,w1.PartCode6,w1.PartCode7,w1.PartCode8,w1.PartCode9,w1.PartCode10,w1.PartCode11,w1.PartCode12,w1.PartCode13,w1.PartCode14,w1.PartCode15,w1.ShelfLife '保质期',
w1.Creator as 用户名,w1.Recordtime as '创建时间' from mdcdatmpn w1 left join dbo.MdcdatMaterial as m1 on w1.newPN=m1.MaterialCode,
(SELECT row_number() OVER (ORDER BY Recordtime  DESC) n, newPN FROM MdcDatMPN ) w2 
WHERE w1.newPN = w2.newPN AND w2.n >={0} and w2.n<{1} order by Recordtime desc", (pageindex - 1) * pagesize, pageindex * pagesize);

                #region orcale
                //                sqlcmd = MES.Utils.GetPageSQL("1", @"newPN  新料号,
                //oldPN 旧料号,
                //MaterialMinCount 最小包装数量,
                //MorePack 是否多包装,
                //MSDLevel MSD等级,
                //ShelfType 料架类型,
                //WarehouseLocation 库位,
                //IsEnable 是否禁用,
                //CustomerType  客户编码,
                //SupplierName  供应商名称,
                //ManufacturerLocation 供应商地址,
                //MaterialType  物料类型,
                //Purchase  来料方式,PartCode1,PartCode2,PartCode3,PartCode4,PartCode5,PartCode6,PartCode7,
                //PartCode8,PartCode9,PartCode10,PartCode11,PartCode12,PartCode13,PartCode14,PartCode15,ShelfLife 保质期,Creator  用户名,
                //Recordtime  创建时间 ", "MdcDatMPN", "", "order by Recordtime desc", pageindex, pagesize);
                #endregion

                DataTable ds = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sqlcmd);
                dataGridView1.DataSource = ds;
            }
            else
            {
                StringBuilder str = new StringBuilder();
                for (int i = 1; i < 16; i++)
                {
                    str.Append(" w1.partcode" + i.ToString() + " like '%" + txt_search.Text + "%' or ");
                }
                str.Remove(str.Length - 3, 3);
                sqlcmd = string.Format(@"select top 100 w1.newPN as '新料号',oldPN '旧料号',MaterialMinCount as '最小包装数量',
MorePack as '是否多包装',IsBing as '是否Bing',MSDLevel MSD等级,ShelfType 料架类型,WarehouseLocation 库位,IsEnable 是否禁用,CustomerType as '客户编码',SupplierName as '供应商名称',ManufacturerLocation as '供应商地址',
MaterialType as '物料类型',Purchase as '来料方式',PartCode1,PartCode2,PartCode3,PartCode4,PartCode5,PartCode6,PartCode7,
PartCode8,PartCode9,PartCode10,PartCode11,PartCode12,PartCode13,PartCode14,PartCode15,ShelfLife '保质期',Creator as 用户名,
Recordtime as '创建时间' from mdcdatmpn w1,
(SELECT row_number() OVER (ORDER BY Recordtime  DESC) n, newPN FROM MdcDatMPN ) w2 
WHERE   (w1.newpn like '%" + txt_search.Text + "%' or " + str.ToString() + ") and w1.newPN = w2.newPN order by Recordtime desc", (pageindex - 1) * pagesize, pageindex * pagesize);
                #region orcale
                //                sqlcmd = MES.Utils.GetPageSQL("1", @"newPN  新料号,
                //oldPN 旧料号,
                //MaterialMinCount 最小包装数量,
                //MorePack 是否多包装,
                //MSDLevel MSD等级,
                //ShelfType 料架类型,
                //WarehouseLocation 库位,
                //IsEnable 是否禁用,
                //CustomerType  客户编码,
                //SupplierName  供应商名称,
                //ManufacturerLocation 供应商地址,
                //MaterialType  物料类型,
                //Purchase  来料方式,PartCode1,PartCode2,PartCode3,PartCode4,PartCode5,PartCode6,PartCode7,
                //PartCode8,PartCode9,PartCode10,PartCode11,PartCode12,PartCode13,PartCode14,PartCode15,ShelfLife 保质期,Creator  用户名,
                //Recordtime  创建时间 ", "MdcDatMPN", "WHERE   (w1.newpn like '%" + txt_search.Text + "%' or " + str.ToString() + ")", "order by Recordtime desc", pageindex, pagesize);
                #endregion

                DataTable dtt = NMS.QueryDataTable(CIT.MES.PubUtils.uContext, sqlcmd);
                dataGridView1.DataSource = dtt;
            }
        }

        private void tol_add_Click(object sender, EventArgs e)
        {
            FrmMetaBindingEdit frm = new FrmMetaBindingEdit();
            frm.ShowDialog();
            InitData(100, pagerControl1.CurrentPage);
        }

        private void tol_del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                CIT.Client.MsgBox.Info("请选择需要删除的数据.");
                return;
            }

            DataRow dr = null;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                dr = (dataGridView1.SelectedRows[i].DataBoundItem as DataRowView).Row;
                if (dr != null)
                {
                    if (CIT.Client.MsgBox.Question("是否删除当前选中数据【" + dataGridView1.SelectedRows[0].Cells[0].Value + "】？") == DialogResult.OK)
                    {
                        // orcale delete from mdcdatmpn where newpn='" + dr[0].ToString() + "'
                        NMS.ExecTransql(CIT.MES.PubUtils.uContext, @"delete from mdcdatmpn where newpn='" + dr[0].ToString() + "'");
                        pagerControl1.Init(Convert.ToInt32(NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select count(*) from mdcdatmpn").Rows[0][0].ToString()), 100);
                        InitData(pagerControl1.PerPage, 1);
                    }
                }
            }
        }

        private void tol_edit_Click(object sender, EventArgs e)
        {
            DataRow dr = null;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                dr = (dataGridView1.SelectedRows[i].DataBoundItem as DataRowView).Row;
                if (dr != null)
                {
                    FrmMetaBindingEdit frm = new FrmMetaBindingEdit(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    frm.ShowDialog();
                    InitData(100, pagerControl1.CurrentPage);
                    dataGridView1.Focus();
                }
            }
        }

        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                StringBuilder str = new StringBuilder();
                for (int i = 1; i < 16; i++)
                {
                    str.Append(" partcode" + i.ToString() + " like '%" + txt_search.Text + "%' or ");
                }
                str.Remove(str.Length - 3, 3);
                pagerControl1.Init(int.Parse(NMS.QueryDataTable(CIT.MES.PubUtils.uContext, "select count(*) from mdcdatmpn where newpn like '%" + txt_search.Text + "%' or " + str.ToString()).Rows[0][0].ToString()), 100);
                InitData(100, 1);
                dataGridView1.Focus();
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataRow dr = null;
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    dr = (dataGridView1.SelectedRows[i].DataBoundItem as DataRowView).Row;
                    if (dr != null)
                    {
                        if (dataGridView1.CurrentRow.Index != 0)
                            dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Selected = true;
                        FrmMetaBindingEdit frm = new FrmMetaBindingEdit(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        frm.ShowDialog();
                        dataGridView1.Focus();
                    }
                    break;
                }
            }
        }

        private void tol_Import_Click(object sender, EventArgs e)
        {
            #region 2017.03.24 by Simon.Li 修正导入功能不能使用
            ImportExcel import = new ImportExcel();
            DataSet ds = import.ReadExcel();
            if (ds != null)
            {
                import.ImportSql(ds);
                InitData(100, 1);
            }
            #endregion
        }

    }
}
