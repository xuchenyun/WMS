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
using CIT.MES;
using BaseData.DAL;
using System.IO;
using Common.Helper;
using CIT.Wcf.Utils;

namespace Warehouse.UI
{
    public partial class ucAreaType : UserControl
    {

        DataTable dtSource = new DataTable();
        DataTable dt_area = new DataTable();
        DataTable dt_location = new DataTable();
        public ucAreaType()
        {
            InitializeComponent();
        }

        private void Query()
        {
            string sql = "SELECT Guid, TypeSN, TypeName, Remark, Ext1, Ext2, Ext3, Ext4 FROM [dbo].[wms_B_AreaType]";
            DataTable dt = NMS.QueryDataTable(PubUtils.uContext, sql);
            dgv_stockAll.DataSource = dt;
        }

        private void ucStockAll_Load(object sender, EventArgs e)
        {
            Query();
        }
        /// <summary>
        /// 双击复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_stockAll_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new PubUtils().ShowMsg(dgv_stockAll, e);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

            string strSql = string.Format(@"INSERT INTO [dbo].[wms_B_AreaType] (Guid, TypeSN, TypeName, Remark) VALUES('{0}','{1}','{2}','{3}')",
                                            txt_TypeSN.Text, txt_TypeSN.Text, txt_TypeSN.Text);
            CIT.Wcf.Utils.NMS.ExecTransql(PubUtils.uContext, strSql);
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }
    }
}
