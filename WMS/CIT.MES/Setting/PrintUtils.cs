//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Drawing;
//using System.Drawing.Printing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

//namespace CIT.MES.Setting
//{
//    public class PrintUtils
//    {
//        /// <summary>    
//        /// 指示是否进行打印预览，默认值为 true    
//        /// </summary>    
//        private bool m_bIsPreview;

//        /// <summary>    
//        /// 指示是否总是打印标题，默认值为 true    
//        /// </summary>    
//        private bool m_bIsAlwaysPrintHeader;

//        /// <summary>    
//        /// 需要打印的页首字符串    
//        /// </summary>    
//        private string m_sPrintHeaderString;

//        /// <summary>    
//        /// 标题的字体    
//        /// </summary>    
//        private Font m_oHeaderFont;

//        /// <summary>    
//        /// 正文字体    
//        /// </summary>    
//        private Font m_oBodyFont;

//        /// <summary>    
//        /// 页尾字体    
//        /// </summary>    
//        private Font m_oTailFont;

//        /// <summary>    
//        /// 正文部分的 ColumnHeader 字体，该字体为正文字体的加粗形式    
//        /// </summary>    
//        private Font m_oColumnHeaderFont;

//        /// <summary>    
//        /// 打印文档    
//        /// </summary>    
//        private PrintDocument m_oPrintDoc;

//        /// <summary>    
//        /// 行间距    
//        /// </summary>    
//        private int m_nLineSpace;

//        private int m_nPrintWidth;            // 打印区域宽度    

//        private int m_nPrintHeight;            // 打印区域长度    

//        private int m_nPageCount;            // 打印页数    

//        private int m_nCurPrintPage;         // 当前正在打印的页码    

//        private int m_nTotalPage;            // 共有的页数    

//        private int m_nFromPage;            // 用户选择的打印起始页    

//        private int m_nCurPrintItem;         // 当前正在打印的元素    

//        private Rectangle m_oHeaderRect;      // 打印页首的区域    

//        private Rectangle m_oBodyRect;         // 打印正文的区域    

//        private Rectangle m_oTailRect;         // 打印页尾的区域    

//        private Brush defaultBrush;

//        private Pen defaultPen;

//        private string m_name;                  //申请人姓名

//        private string m_department;            //申请人所属部门

//        private string m_time;                  //申请提出时间

//        public DataSet data_app;                  //审批信息数据表


//        int[] columnsWidth = new int[5] { 50, 100, 130, 130, 280 };                //定义存储每列宽度的数组

//        string[] columnsText = new string[5] { "No.", "处理人", "开始时间", "完成时间", "意见" };                //定义存储每列宽度的数组

//        /// <summary>    
//        /// 设置或获取是否进行打印预览    
//        /// </summary>    
//        public bool IsPreview
//        {
//            get { return m_bIsPreview; }
//            set { m_bIsPreview = value; }
//        }

//        /// <summary>    
//        /// 设置或获取是否总是打印标题    
//        /// </summary>    
//        public bool IsAlwaysPrintHeader
//        {
//            get { return m_bIsAlwaysPrintHeader; }
//            set { m_bIsAlwaysPrintHeader = value; }
//        }

//        /// <summary>    
//        /// 设置或获取打印的页首字符串    
//        /// </summary>    
//        public string PrintHeaderString
//        {
//            get { return m_sPrintHeaderString; }
//            set { if (value != null) m_sPrintHeaderString = value; }
//        }

//        /// <summary>    
//        /// 设置或获取页首字体    
//        /// </summary>    
//        public Font HeaderFont
//        {
//            set { m_oHeaderFont = value; }
//            get { return m_oHeaderFont; }
//        }

//        /// <summary>    
//        /// 设置或获取正文字体    
//        /// 如果对正文字体的 Bold 属性设置为 true ，则发生 Exception 类型的异常    
//        /// </summary>    
//        public Font BodyFont
//        {
//            set
//            {
//                if (value == null)
//                    return;
//                if (value.Bold == true)
//                {
//                    //throw new Exception ("正文字体不能进行 [加粗] 设置.");    
//                    MessageBox.Show("正文字体不能进行 [加粗] 设置.", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }
//                else
//                {
//                    m_oBodyFont = value;
//                }
//            }
//            get { return m_oBodyFont; }
//        }

//        /// <summary>    
//        /// 设置或获取页尾字体    
//        /// </summary>    
//        public Font TailFont
//        {
//            set { m_oTailFont = value; }
//            get { return m_oTailFont; }
//        }

//        /// <summary>    
//        /// 设置或获取行间距    
//        /// </summary>    
//        public int LineSpace
//        {
//            get { return m_nLineSpace; }
//            set
//            {
//                if (value < 0)
//                {
//                    m_nLineSpace = 0;
//                }
//                m_nLineSpace = value;
//            }
//        }

//        /// <summary>    
//        /// 设置申请人姓名   
//        /// </summary>    
//        public string name
//        {
//            get { return m_name; }
//            set { m_name = value; }
//        }
//        /// <summary>    
//        /// 设置申请人部门
//        /// </summary>    
//        public string department
//        {
//            get { return m_department; }
//            set { m_department = value; }
//        }
//        /// <summary>    
//        /// 设置申请人姓名   
//        /// </summary>    
//        public string time
//        {
//            get { return m_time; }
//            set { m_time = value; }
//        }

//        /// <summary>    
//        /// 构造函数，设置打印信息的一些默认值    
//        /// </summary>    
//        public void PrintListView()
//        {
//            m_bIsPreview = true;
//            m_bIsAlwaysPrintHeader = true;
//            IsAlwaysPrintHeader = true;
//            m_sPrintHeaderString = "";
//            m_oHeaderFont = null;
//            m_oTailFont = null;
//            m_oBodyFont = null;
//            m_oColumnHeaderFont = null;
//            m_oPrintDoc = null;
//            m_nPrintWidth = 0;
//            m_nPrintHeight = 0;
//            m_nPageCount = 0;
//            m_nCurPrintPage = 1;
//            m_nFromPage = 1;
//            m_nLineSpace = 0;
//            m_nCurPrintItem = 0;
//            defaultBrush = Brushes.Black;
//            defaultPen = new Pen(defaultBrush, 1);
//        }

//        /// <summary>    
//        /// 初始化打印文档的属性    
//        /// </summary>    
//        /// <returns></returns>    
//        private void InitPrintDocument()
//        {
//            m_oPrintDoc = new PrintDocument();
//            m_oPrintDoc.DocumentName = m_sPrintHeaderString;
//            if (m_oPrintDoc.PrinterSettings.PrinterName == "<no default printer>")
//            {
//                //throw new Exception ("未找到默认打印机.");    
//                MessageBox.Show("未找到默认打印机.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }
//            else
//            {
//                m_oPrintDoc.PrintPage += new PrintPageEventHandler(PrintPage);
//                m_oPrintDoc.BeginPrint += new PrintEventHandler(BeginPrint);
//                m_oPrintDoc.EndPrint += new PrintEventHandler(EndPrint);
//            }

//            /* 设置打印字体 */
//            if (m_oHeaderFont == null)
//            {
//                m_oHeaderFont = new Font("宋体", 24, FontStyle.Bold, GraphicsUnit.World);
//            }

//            if (m_oBodyFont == null)
//            {
//                m_oBodyFont = new Font("宋体", 18, FontStyle.Regular, GraphicsUnit.World);
//            }

//            m_oColumnHeaderFont = new Font(m_oBodyFont, FontStyle.Bold);

//            if (m_oTailFont == null)
//            {
//                m_oTailFont = new Font("宋体", 14, FontStyle.Regular, GraphicsUnit.World);
//            }

//        }

//        /// <summary>    
//        /// 初始化打印纸张设置    
//        /// </summary>    
//        private bool InitPrintPage(out Margins margins)
//        {
//            margins = null;
//            /* 获取当前 listview 的分辨率 */
//            Graphics g = this.CreateGraphics();
//            float x = g.DpiX;
//            g.Dispose();
//            /* 显示纸张设置对话框 */
//            PageSetupDialog ps = new PageSetupDialog();
//            ps.Document = m_oPrintDoc;

//            if (ps.ShowDialog() == DialogResult.Cancel)
//            {
//                return false;
//            }
//            else
//            {  // 根据用户设置的纸张信息计算打印区域，计算结果的单位为 1/100 Inch    
//                m_nPrintWidth = ps.PageSettings.Bounds.Width - ps.PageSettings.Margins.Left - ps.PageSettings.Margins.Right;
//                m_nPrintHeight = ps.PageSettings.Bounds.Height - ps.PageSettings.Margins.Top - ps.PageSettings.Margins.Bottom;
//                margins = ps.PageSettings.Margins;
//            }

//            if (m_nPrintWidth <= 0 || m_nPrintHeight <= 0)
//            {
//                //throw new Exception ("纸张设置错误.");    
//                MessageBox.Show("纸张设置错误.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return false;
//            }

//            /* 将当前 listview 的各column的长度和转换为英寸，判断打印范围是否越界 */
//            int listViewWidth = 0;
//            for (int i = 0; i < this.Columns.Count; i++)
//            {
//                listViewWidth += this.Columns[i].Width;
//            }
//            if (Convert.ToInt32(listViewWidth / x * 100) > m_nPrintWidth)
//            {
//                //throw new Exception ("打印内容超出纸张范围 ！\r\n请尝试调整纸张或纸张边距；\r\n或缩小表格各列的宽度。");    
//                MessageBox.Show("打印内容超出纸张范围 ！\r\n请尝试调整纸张或纸张边距；\r\n或缩小表格各列的宽度。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return false;
//            }
//            m_oPrintDoc.DefaultPageSettings = ps.PageSettings;
//            return true;
//        }

//        /// <summary>    
//        /// 初始化打印页码设置    
//        /// </summary>    
//        private bool InitPrintPageNumber(Margins margins)
//        {
//            /* 计算页数 */
//            int headerFontHeight = m_oHeaderFont.Height;
//            int columnHeaderFontHeight = m_oColumnHeaderFont.Height;
//            int bodyFontHeight = m_oBodyFont.Height;
//            int tailFontHeight = m_oTailFont.Height;
//            // 页首区域打印 页首字符串 以及一条横线    
//            m_oHeaderRect = new Rectangle(margins.Left, margins.Top, m_nPrintWidth, headerFontHeight * 2 + m_nLineSpace * 2 + 3);
//            int tailHeight = tailFontHeight + m_nLineSpace + 3;
//            // 页尾区域打印 一条横线，页码和打印时间（在同一行）    
//            m_oTailRect = new Rectangle(margins.Left, margins.Top + m_nPrintHeight - tailHeight, m_nPrintWidth, tailHeight);
//            //正文区域为去掉页首和页尾区域的部分    
//            m_oBodyRect = new Rectangle(margins.Left, m_oHeaderRect.Bottom + 2, m_nPrintWidth, m_oTailRect.Top - m_oHeaderRect.Bottom - 4);
//            /* 计算第一页能打印的元素个数 */
//            int printItemPerPage = 0;
//            int firstPageItem = Convert.ToInt32((m_oBodyRect.Height - columnHeaderFontHeight - m_nLineSpace) / (bodyFontHeight + m_nLineSpace));
//            if (firstPageItem >= this.Items.Count + 5)
//            {   // 需打印的元素只有一页    
//                m_nPageCount = 1;
//            }
//            else
//            {  // 需要打印的元素有多页    
//                printItemPerPage = firstPageItem;
//                int leftItems = this.Items.Count + 5 - firstPageItem;
//                if (m_bIsAlwaysPrintHeader == false)
//                {
//                    printItemPerPage = (m_oBodyRect.Height + m_oHeaderRect.Height + 2 - columnHeaderFontHeight - m_nLineSpace) / (bodyFontHeight + m_nLineSpace);
//                }
//                if (leftItems % printItemPerPage == 0)
//                {
//                    m_nPageCount = leftItems / printItemPerPage + 1;
//                }
//                else
//                {
//                    m_nPageCount = leftItems / printItemPerPage + 2;
//                }
//            }
//            m_nTotalPage = m_nPageCount;
//            /* 显示打印对话框 */
//            PrintDialog pd = new PrintDialog();
//            pd.Document = m_oPrintDoc;
//            pd.PrinterSettings.MinimumPage = 1;
//            pd.PrinterSettings.MaximumPage = m_nPageCount;
//            pd.PrinterSettings.FromPage = 1;
//            pd.PrinterSettings.ToPage = m_nPageCount;
//            pd.AllowPrintToFile = false;      // 不设置打印到文件    
//            if (m_nPageCount > 1)
//            {
//                pd.AllowSelection = true;
//            }
//            else
//            {
//                pd.AllowSelection = false;
//            }
//            pd.AllowSomePages = true;
//            if (pd.ShowDialog() == DialogResult.OK)
//            {
//                m_nPageCount = pd.PrinterSettings.ToPage - pd.PrinterSettings.FromPage + 1;
//                if (pd.PrinterSettings.FromPage > 1)
//                {
//                    m_nCurPrintItem = firstPageItem + (pd.PrinterSettings.FromPage - 2) * printItemPerPage;
//                }
//                else
//                {
//                    m_nCurPrintItem = 0;
//                }
//                m_nFromPage = pd.PrinterSettings.FromPage;
//                m_oPrintDoc.DocumentName = m_nPageCount.ToString();
//                m_oPrintDoc.PrinterSettings = pd.PrinterSettings;
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        /// <summary>    
//        /// 启动 ListView 的打印工作    
//        /// </summary>    
//        public virtual void DoPrint()
//        {
//            if (this.Items.Count <= 0)
//            {
//                //throw new Exception ("没有需要打印的元素.");    
//                MessageBox.Show("没有需要打印的元素.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            InitPrintDocument();
//            Margins margins = null;
//            if (InitPrintPage(out margins) == false)
//                return;

//            if (InitPrintPageNumber(margins) == false)
//                return;

//            if (m_bIsPreview == false)
//            {
//                m_oPrintDoc.Print();
//            }
//            else
//            {
//                PrintPreviewDialog pd = new PrintPreviewDialog();
//                pd.Document = m_oPrintDoc;
//                pd.PrintPreviewControl.Zoom = 1.0;
//                pd.WindowState = FormWindowState.Maximized;
//                pd.ShowInTaskbar = true;
//                pd.ShowDialog();
//            }
//        }

//        /// <summary>    
//        /// 打印页首    
//        /// </summary>    
//        /// <param name="g"></param>    
//        protected virtual void PrintPageHeader(Graphics g)
//        {
//            RectangleF textRect = new RectangleF(m_oHeaderRect.X, m_oHeaderRect.Y, m_oHeaderRect.Width, (m_oHeaderRect.Height - 3) / 2);
//            CenterText(g, m_sPrintHeaderString, m_oHeaderFont, defaultBrush, textRect);
//            /* 打印标题*/
//            RectangleF HeaderRect = new RectangleF(m_oHeaderRect.X, m_oHeaderRect.Y + (m_oHeaderRect.Height - 3) / 2, m_oHeaderRect.Width, (m_oHeaderRect.Height - 3) / 2);
//            LeftText(g, "申请人   " + m_name, m_oBodyFont, defaultBrush, HeaderRect);
//            CenterText(g, "部门   " + m_department, m_oBodyFont, defaultBrush, HeaderRect);
//            RightText(g, "时间   " + m_time, m_oBodyFont, defaultBrush, HeaderRect);
//            g.DrawLine(defaultPen, m_oHeaderRect.X, m_oHeaderRect.Bottom - 2, m_oHeaderRect.Right, m_oHeaderRect.Bottom - 2);
//        }

//        /// <summary>    
//        /// 打印正文    
//        /// </summary>    
//        /// <param name="g"></param>    
//        protected virtual void PrintPageBody(Graphics g)
//        {
//            Rectangle textRect = m_oBodyRect;
//            if (m_bIsAlwaysPrintHeader == false && m_nCurPrintPage != 1)
//            {
//                textRect = new Rectangle(m_oHeaderRect.X, m_oHeaderRect.Y, m_oHeaderRect.Width, m_oHeaderRect.Height + 2 + m_oBodyRect.Height);
//            }

//            /* 打印标题,也就是 columnHeader */
//            int columnHeaderFontHeight = m_oColumnHeaderFont.Height;
//            int bodyFontHeight = m_oBodyFont.Height;
//            Rectangle columnHeaderRect = new Rectangle(textRect.X, textRect.Y, textRect.Width, columnHeaderFontHeight + m_nLineSpace);
//            DrawColumnHeader(g, m_oColumnHeaderFont, defaultBrush, columnHeaderRect);
//            /* 打印元素 */
//            int itemHeight = bodyFontHeight + m_nLineSpace;
//            Rectangle itemRect;
//            int yPos = columnHeaderRect.Bottom;
//            int printItemPerPage = (textRect.Height - columnHeaderRect.Height) / (bodyFontHeight + m_nLineSpace);
//            for (int i = 0; (i < printItemPerPage) && (m_nCurPrintItem < this.Items.Count); i++)
//            {
//                itemRect = new Rectangle(textRect.X, yPos, textRect.Width, itemHeight);
//                DrawItem(g, m_oBodyFont, defaultBrush, itemRect);
//                m_nCurPrintItem++;
//                yPos += itemHeight;
//            }
//            if (m_nCurPrintPage == m_nPageCount)
//            {
//                PrintApprove(g, yPos);
//            }
//        }

//        /// <summary>    
//        /// 打印页尾    
//        /// </summary>    
//        /// <param name="g"></param>    
//        protected virtual void PrintPageTail(Graphics g)
//        {
//            g.DrawLine(defaultPen, m_oTailRect.X, m_oTailRect.Top + 1, m_oTailRect.Right, m_oTailRect.Top + 1);
//            RectangleF textRect = new RectangleF(m_oTailRect.X, m_oTailRect.Y + 3, m_oTailRect.Width, m_oTailRect.Height - 3);
//            string text = "第 " + m_nFromPage.ToString() + " 页  共 " + m_nTotalPage.ToString() + " 页";
//            m_nFromPage++;
//            CenterText(g, text, m_oTailFont, defaultBrush, textRect);
//            string time = "打印时间：" + DateTime.Now.ToLongDateString() + "   ";
//            RightText(g, time, m_oTailFont, defaultBrush, textRect);
//        }
//        /// <summary>    
//        /// 打印审批流程
//        /// </summary>    
//        /// <param name="g"></param>    
//        protected virtual void PrintApprove(Graphics g, int y)
//        {
//            int itemHeight = m_oBodyFont.Height + m_nLineSpace;
//            //g.DrawLine (defaultPen,m_oTailRect.X,m_oTailRect.Top  +1,m_oTailRect.Right ,m_oTailRect.Top  +1);   
//            RectangleF textRect = new RectangleF(m_oHeaderRect.X, y + 3, m_oHeaderRect.Width, itemHeight);
//            LeftText(g, "审批流程：", m_oBodyFont, defaultBrush, textRect);

//            /* 打印标题,也就是 columnHeader */
//            int columnHeaderFontHeight = m_oColumnHeaderFont.Height;
//            int bodyFontHeight = m_oBodyFont.Height;
//            Rectangle columnHeaderRect = new Rectangle((int)textRect.X, (int)textRect.Y + itemHeight + m_nLineSpace, (int)textRect.Width, itemHeight + m_nLineSpace);
//            DrawColumnHeader_app(g, m_oColumnHeaderFont, defaultBrush, columnHeaderRect);
//            /* 打印元素 */
//            Rectangle itemRect;
//            int yPos = columnHeaderRect.Bottom;
//            //int printItemPerPage = (textRect.Height - columnHeaderRect.Height) / (bodyFontHeight + m_nLineSpace);
//            for (int i = 0; i < this.data_app.Tables[0].Rows.Count; i++)
//            {
//                itemRect = new Rectangle((int)textRect.X, yPos, (int)textRect.Width, itemHeight);
//                DrawItem_app(g, m_oBodyFont, defaultBrush, itemRect, i);
//                m_nCurPrintItem++;
//                yPos += itemHeight;
//            }
//        }

//        /// <summary>    
//        /// 打印一页    
//        /// </summary>    
//        /// <param name="sender"></param>    
//        /// <param name="e"></param>    
//        private void PrintPage(object sender, PrintPageEventArgs e)
//        {
//            e.Graphics.PageUnit = GraphicsUnit.Inch;
//            e.Graphics.PageScale = .01f;
//            if (m_bIsAlwaysPrintHeader == true)
//            {
//                PrintPageHeader(e.Graphics);
//            }
//            else
//            {
//                if (m_nCurPrintPage == 1)
//                {
//                    PrintPageHeader(e.Graphics);
//                }
//            }

//            PrintPageBody(e.Graphics);
//            PrintPageTail(e.Graphics);
//            if (m_nCurPrintPage == m_nPageCount)
//            {
//                e.HasMorePages = false;
//            }
//            else
//            {
//                e.HasMorePages = true;
//            }
//            m_nCurPrintPage++;
//        }

//        /// <summary>    
//        /// 打印前的初始化设置    
//        /// </summary>    
//        /// <param name="sender"></param>    
//        /// <param name="e"></param>    
//        private void BeginPrint(object sender, PrintEventArgs e)
//        {
//            m_nCurPrintPage = 1;
//        }

//        /// <summary>    
//        /// 打印结束后的资源释放    
//        /// </summary>    
//        /// <param name="sender"></param>    
//        /// <param name="e"></param>    
//        private void EndPrint(object sender, PrintEventArgs e)
//        {

//        }

//        /// <summary>    
//        /// 居中显示文本信息    
//        /// </summary>    
//        private void CenterText(Graphics g, string t, Font f, Brush b, RectangleF rect)
//        {
//            StringFormat sf = new StringFormat();
//            sf.Alignment = StringAlignment.Center;
//            sf.LineAlignment = StringAlignment.Center;
//            g.DrawString(t, f, b, rect, sf);
//        }

//        /// <summary>    
//        /// 居右显示文本信息    
//        /// </summary>    
//        private void RightText(Graphics g, string t, Font f, Brush b, RectangleF rect)
//        {
//            StringFormat sf = new StringFormat();
//            sf.Alignment = StringAlignment.Far;
//            sf.LineAlignment = StringAlignment.Center;
//            g.DrawString(t, f, b, rect, sf);
//        }

//        /// <summary>    
//        /// 居左显示文本信息    
//        /// </summary>    
//        private void LeftText(Graphics g, string t, Font f, Brush b, RectangleF rect)
//        {
//            StringFormat sf = new StringFormat();
//            sf.Alignment = StringAlignment.Near;
//            sf.LineAlignment = StringAlignment.Center;
//            g.DrawString(t, f, b, rect, sf);
//        }

//        /// <summary>    
//        /// 打印 listview 的 columnheader    
//        /// </summary>    
//        private new void DrawColumnHeader(Graphics g, Font f, Brush b, Rectangle rect)
//        {
//            StringFormat sf = new StringFormat();
//            sf.Alignment = StringAlignment.Center;
//            sf.LineAlignment = StringAlignment.Center;
//            Rectangle itemRect;
//            Point location = new Point(rect.Location.X, rect.Location.Y);
//            Size itemSize;
//            for (int i = 0; i < this.Columns.Count; i++)
//            {
//                itemSize = new Size(this.Columns[i].Width, rect.Height);
//                itemRect = new Rectangle(location, itemSize);
//                g.DrawRectangle(defaultPen, itemRect);
//                itemRect = new Rectangle(location.X, location.Y + 2, this.Columns[i].Width, rect.Height);
//                g.DrawString(this.Columns[i].Text, f, b, itemRect, sf);
//                location.X += this.Columns[i].Width;
//            }
//        }
//        /// <summary>    
//        /// 打印 审批流程 的 columnheader    
//        /// </summary>    
//        private void DrawColumnHeader_app(Graphics g, Font f, Brush b, Rectangle rect)
//        {
//            StringFormat sf = new StringFormat();
//            sf.Alignment = StringAlignment.Center;
//            sf.LineAlignment = StringAlignment.Center;
//            Rectangle itemRect;
//            Point location = new Point(rect.Location.X, rect.Location.Y);
//            Size itemSize;
//            //columnsWidth = new int[data_app.Tables[0].Columns.Count];
//            int a = this.data_app.Tables[0].Columns.Count - 1;
//            for (int i = 0; i < a; i++)
//            {
//                itemSize = new Size(this.columnsWidth[i], rect.Height);
//                itemRect = new Rectangle(location, itemSize);
//                g.DrawRectangle(defaultPen, itemRect);
//                itemRect = new Rectangle(location.X, location.Y + 2, this.columnsWidth[i], rect.Height);
//                g.DrawString(columnsText[i], f, b, itemRect, sf);
//                location.X += this.columnsWidth[i];
//            }
//        }

//        /// <summary>    
//        /// 打印 listview 的 item    
//        /// </summary>    
//        private new void DrawItem(Graphics g, Font f, Brush b, Rectangle rect)
//        {
//            StringFormat sf = new StringFormat();
//            sf.Alignment = StringAlignment.Near;
//            sf.LineAlignment = StringAlignment.Center;
//            Rectangle itemRect;
//            Point location = new Point(rect.Location.X, rect.Location.Y);
//            Size itemSize;
//            for (int i = 0; i < this.Columns.Count; i++)
//            {
//                itemSize = new Size(this.Columns[i].Width, rect.Height);
//                itemRect = new Rectangle(location, itemSize);
//                g.DrawRectangle(defaultPen, itemRect);
//                itemRect = new Rectangle(location.X, location.Y + 2, this.Columns[i].Width, rect.Height);
//                g.DrawString(this.Items[m_nCurPrintItem].SubItems[i].Text, f, b, itemRect, sf);
//                location.X += this.Columns[i].Width;
//            }
//        }
//        /// <summary>    
//        /// 打印 审批流程 的 item    
//        /// </summary>    
//        private new void DrawItem_app(Graphics g, Font f, Brush b, Rectangle rect, int j)
//        {
//            StringFormat sf = new StringFormat();
//            sf.Alignment = StringAlignment.Center;
//            sf.LineAlignment = StringAlignment.Center;
//            Rectangle itemRect;
//            Point location = new Point(rect.Location.X, rect.Location.Y);
//            Size itemSize;
//            int a = this.data_app.Tables[0].Columns.Count - 1;
//            for (int i = 0; i < a; i++)
//            {
//                itemSize = new Size(this.columnsWidth[i], rect.Height);
//                itemRect = new Rectangle(location, itemSize);
//                g.DrawRectangle(defaultPen, itemRect);
//                itemRect = new Rectangle(location.X, location.Y + 2, this.columnsWidth[i], rect.Height);
//                g.DrawString(this.data_app.Tables[0].Rows[j][i].ToString(), f, b, itemRect, sf);
//                location.X += this.columnsWidth[i];
//            }
//        }


//    }
//}
