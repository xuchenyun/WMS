using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIT.Client;

namespace CIT.uControl
{
    public partial class PagerControl : UserControl
    {
        public PagerControl()
        {
            InitializeComponent();
            displayCount = 0;
            perPage = 50;
            pageCount = 1;
            currentPage = 1;
            maxPerPage = 20000;
            this.panelEx1.Style.BackColor1.Color = Color.FromArgb(238, 245, 252);
            this.panelEx1.Style.BackColor2.Color = Color.FromArgb(238, 245, 252);

        }
        #region 参数
        private int displayCount;//总信息条数 
        private int perPage; //每页显示的信息条数 
        private int pageCount;//分页总数 
        private int currentPage;//当前页 
        private int maxPerPage;
        #endregion

        #region 事件
        public event EventHandler currentPageChange;//自定义事件 
        #endregion
        #region 属性
        /// <summary> 
        /// 总信息条数 
        /// </summary> 
        public int DisplayCount
        {
            set { displayCount = value; }
            get { return displayCount; }
        }

        /// <summary> 
        /// 每页显示条数 
        /// </summary> 
        public int PerPage
        {
            get { return perPage; }
        }

        /// <summary> 
        /// 分页总数 
        /// </summary> 
        public int PageCount
        {
            get { return pageCount; }
        }

        /// <summary> 
        /// 当前页码 
        /// </summary> 
        public int CurrentPage
        {
            get { return currentPage; }
        }
        #endregion


        /// <summary> 
        /// 页面初始化 
        /// </summary> 
        /// <param name="count">信息总条数</param> 
        /// <param name="perpage">每页显示条数</param> 
        public void Init(int count, int perpage)
        {
            #region
            if (!string.IsNullOrEmpty(this.txtperpage.Text))
            {
                try
                {
                    this.perPage = Convert.ToInt32(this.txtperpage.Text);
                }
                catch
                {
                    MsgBox.Info("请填写数字！", "提示");
                    return;
                }
                if (Convert.ToInt32(this.txtperpage.Text) > maxPerPage)
                {
                    this.txtperpage.Text = maxPerPage.ToString();
                    this.perPage = maxPerPage;
                    MsgBox.Info("最大只能是" + maxPerPage, "提示");
                }
            }

            displayCount = Math.Max(count, 1);
            perPage = Math.Min(this.perPage, perpage);
            txtperpage.Text = perpage.ToString();
            pageCount = displayCount / perPage;
            if (displayCount % perPage != 0)
            {
                pageCount++;
            }
            currentPage = 1;
            DrawControl();

            #endregion
        }

        private void DrawControl()
        {
            this.lblPageNum.Text = currentPage.ToString() + "/" + pageCount.ToString() + "页";
            this.labelCount.Text = "共" + displayCount.ToString() + "条";
            currentPageChange(this, null);

            if (currentPage == pageCount)
            {
                this.lnkNext.Enabled = false;
                this.lnkLast.Enabled = false;
            }
            else
            {
                this.lnkNext.Enabled = true;
                this.lnkLast.Enabled = true;
            }

            if (currentPage == 1)
            {
                this.lnkPrev.Enabled = false;
                this.lnkFirst.Enabled = false;
            }
            else
            {
                this.lnkPrev.Enabled = true;
                this.lnkFirst.Enabled = true;
            }
        }

        #region 当前页，只可正整数
        private void txtBxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        #region 第一页
        private void InkFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            DrawControl();
        }
        #endregion

        #region 前一页
        private void InkPrew_Click(object sender, EventArgs e)
        {
            currentPage--;
            DrawControl();
        }
        #endregion

        #region 下一页
        private void InkNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            DrawControl();
        }
        #endregion

        #region 最后一页
        private void InkLast_Click(object sender, EventArgs e)
        {
            currentPage = pageCount;
            DrawControl();
        }
        #endregion

        //页数只可数据整数 
        private void txtBxNumber_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //IsNumber：指定字符串中位于指定位置的字符是否属于数字类别 
            //IsPunctuation：指定字符串中位于指定位置的字符是否属于标点符号类别 
            //IsControl：指定字符串中位于指定位置的字符是否属于控制字符类别 
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true; //获取或设置一个值，指示是否处理过System.Windows.Forms.Control.KeyPress事件 
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 页数选择限制
        private void txtBxNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtBxNumber.Text.Length > 0 && int.Parse(this.txtBxNumber.Text) > pageCount)
                {
                    this.txtBxNumber.Text = pageCount.ToString();
                }
                else if (int.Parse(this.txtBxNumber.Text) == 0)
                {
                    this.txtBxNumber.Text = "1";
                }
            }
            catch
            { }
        }
        #endregion

        #region Go的事件
        private void btnGo_Click(object sender, EventArgs e)
        {
            if (this.txtBxNumber.Text.Length == 0 || int.Parse(this.txtBxNumber.Text) > pageCount)
            {
                return;
            }
            currentPage = int.Parse(this.txtBxNumber.Text);
            DrawControl();
        }
        #endregion

        #region 每页数据量改变的时候
        private void txtperpage_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtperpage.Text))
            {
                this.perPage = 50;
                this.txtperpage.Text = "50";
            }
            else
            {
                try
                {
                    this.perPage = Convert.ToInt32(this.txtperpage.Text);
                }
                catch
                {
                    MsgBox.Info("请填写数字！", "提示");
                    return;
                }
                if (Convert.ToInt32(this.txtperpage.Text) > maxPerPage)
                {
                    this.txtperpage.Text = maxPerPage.ToString();
                    this.perPage = maxPerPage;
                    MsgBox.Info("每页最大只能是" + maxPerPage, "提示");
                }
            }

            displayCount = Math.Max(DisplayCount, 1);
            perPage = Math.Min(this.perPage, displayCount);
            pageCount = displayCount / perPage;
            if (displayCount % perPage != 0)
            {
                pageCount++;
            }
            currentPage = 1;
        }

        #endregion

        private void txtperpage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true; //获取或设置一个值，指示是否处理过System.Windows.Forms.Control.KeyPress事件 
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(this.txtperpage.Text))
                {
                    this.perPage = 50;
                    this.txtperpage.Text = "50";
                }
                else
                {
                    try
                    {
                        this.perPage = Convert.ToInt32(this.txtperpage.Text);
                    }
                    catch
                    {
                        MsgBox.Info("请填写数字！", "提示");
                        return;
                    }
                    if (Convert.ToInt32(this.txtperpage.Text) > maxPerPage)
                    {
                        this.txtperpage.Text = maxPerPage.ToString();
                        this.perPage = maxPerPage;
                        MsgBox.Info("每页最大只能是" + maxPerPage, "提示");
                    }
                }

                displayCount = Math.Max(DisplayCount, 1);
                perPage = Math.Min(this.perPage, displayCount);
                pageCount = displayCount / perPage;
                if (displayCount % perPage != 0)
                {
                    pageCount++;
                }
                currentPage = 1;
                DrawControl();
            }
        }
    }
}
