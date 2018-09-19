using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CIT.MES.Setting.PrintView
{
    public partial class FrmBackReport : Form
    {
        string sqlstr = "";
        string Dept = "";
        string Line = "";
        string Product = "";
        string WOCode = "";
        string outWareHouse = "";
        string inWareHouse = "";
        public FrmBackReport()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 退料单打印datatable PN:料号 qty 数量 errornote 物料描述
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="dept">部门</param>
        /// <param name="line">线别</param>
        /// <param name="product">产品</param>
        /// <param name="wocode">工单</param>
        /// <param name="outwarehouse">转出库</param>
        /// <param name="inwarehouse">转入库</param>
        public FrmBackReport(string sql,string dept,string line,string product,string wocode,string outwarehouse,string inwarehouse)
        {
            InitializeComponent();
            sqlstr = sql;
            Dept = dept;
            Line = line;
            Product = product;
            WOCode = wocode;
            outWareHouse = outwarehouse;
            inWareHouse = inwarehouse;
        }

        private void FrmBackReport_Load(object sender, EventArgs e)
        {
            ReportParameter dept = new ReportParameter("Dept", Dept);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { dept });

            ReportParameter line = new ReportParameter("line", Line);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { line });

            ReportParameter product = new ReportParameter("product", Product);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { product });

            ReportParameter wocode = new ReportParameter("wocode", WOCode);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { wocode });

            ReportParameter outWarehouse = new ReportParameter("outWarehouse", outWareHouse);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { outWarehouse });

            ReportParameter inWarehouse = new ReportParameter("inWarehouse", inWareHouse);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { inWarehouse });

            ReportParameter backdate = new ReportParameter("backdate", DateTime.Now.ToString("yyyy/MM/dd"));
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { backdate });
           
            DataTable dt = CIT.Wcf.Utils.NMS.QueryDataTable(PubUtils.uContext, sqlstr);
            ///---向报表绑定数据源  
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ///---向报表绑定数据源  
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            ///---向报表查看器指定显示的报表  
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
