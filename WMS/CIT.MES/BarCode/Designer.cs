using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Data;
using System.Drawing.Printing;
using CIT.MES.DrawItem;
using CIT.MES.ToolBox;
using CIT.MES.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace CIT.MES
{
    //在documentspace中显示出所选的对像
    public delegate void ShowProperityInfo(DrawItemBase item);
    //在documentspace中更改工具选择
    public delegate void ActiveToolChange(ToolBase tool);
    // 触发item更改事件在documentspace中更新对像列表
    public delegate void ItemChange();
    [Serializable()]
    public class Designer : UserControl
    {
        public Designer()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.ResizeRedraw, true);
            this.BorderStyle = BorderStyle.FixedSingle;
            InitializeComponent();
            //设计文本编辑时textbox的属性
            textBox.Visible = false;
            textBox.Enabled = false;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Multiline = true;
            this.Controls.Add(textBox);

            this.BackColor = Color.White;
            activeTool = new ToolBase();
            _items = new DrawItemList();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Designer
            // 
            this.Name = "Designer";
            this.MouseLeave += new System.EventHandler(this.Designer_MouseLeave);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Designer_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Designer_MouseMove);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Designer_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Designer_MouseDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Designer_KeyPress);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Designer_MouseUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Designer_KeyDown);
            this.KeyUp += new KeyEventHandler(Designer_KeyUp);
            this.ResumeLayout(false);

        }


        /// <summary>
        /// 显示出选择中的对像属性,又击才显示
        /// </summary>
        public event ShowProperityInfo OnShowProperityInfo;
        /// <summary>
        /// 工具变换选择提示事件
        /// </summary>
        public event ActiveToolChange OnActiveToolChange;
        /// <summary>
        /// 当设计器中item变换时触发
        /// </summary>
        public event ItemChange OnItemChange;
        /// <summary>
        /// 文本编辑控件输入文本框
        /// </summary>
        public TextBox textBox = new TextBox();
        //设计器中所包含的对像
        public DrawItemList _items;
        //当前的工具
        private ToolBase activeTool;
        //选择的区域
        private Rectangle selectRectangle;
        //是否画选择区域
        private bool isdrawSelectRectangel = false;
        //在关闭时检查是否被修改过
        private bool changeFlag = false;
        /// <summary>
        /// 获取系统默认的鼠标工作区域
        /// </summary>
        private static Rectangle tempCursorPos = Cursor.Clip;
        //是否画出鼠标的位置
        private bool isdrawMousePosition = false;
        //画出鼠标位置
        private Point mouseXs = Point.Empty, mouseXe = Point.Empty, mouseYs = Point.Empty, mouseYe = Point.Empty;
        //在拖动画对像时的起始位置
        private Point mouseStartPos = Point.Empty;
        /// <summary>
        /// 打印设置
        /// </summary>
        private PrintConfig printerConfig = new PrintConfig();
        /// <summary>
        /// 获取当前选中的文本编辑对像
        /// </summary>
        private DrawText drawTextObject;
        /// <summary>
        /// 设计器中对像的数据源
        /// </summary>
        [NonSerialized()]
        private DataTable datasource = new DataTable();
        /// <summary>
        /// 设计器中对像如果是从数据源中取得数据
        /// 如果需要重复画出设置每页有多少数据
        /// </summary>
        private int pagerows = 5;
        /// <summary>
        /// 设置行高
        /// </summary>
        private int rowheight = 15;
        /// <summary>
        /// 是否可以选择对像
        /// </summary>
        private bool canSelectItem = true;
        /// <summary>
        /// 是否显示表格
        /// </summary>
        private bool showGrid = false;


        public bool ShowGrid
        {
            get
            {
                return showGrid;
            }
            set
            {
                showGrid = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 设计器中的对像可否被选择
        /// </summary>
        public bool CanSelectItem
        {
            get
            {
                return canSelectItem;
            }
            set
            {
                canSelectItem = value;
            }
        }
        /// <summary>
        /// 取得或设置页面中的行高
        /// </summary>
        public int RowHeight
        {
            get
            {
                return rowheight;
            }
            set
            {
                rowheight = value;
            }
        }

        /// <summary>
        /// 取得或设置每页有多少行
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PageRows
        {
            get
            {
                return pagerows;
            }
            set
            {
                pagerows = value;
            }
        }


        /// <summary>
        /// 取得或设置数据源
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTable DataSource
        {
            get
            {
                return datasource;
            }
            set
            {
                datasource = value;
            }
        }

        /// <summary>
        /// 取得或设置打印设置
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PrintConfig PrinterConfig
        {
            get
            {
                return printerConfig;
            }
            set
            {
                printerConfig = value;
            }
        }
        /// <summary>
        /// 对像集合
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DrawItemList Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }

        /// <summary>
        ///当前选中的是哪个工具
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolBase ActiveTool
        {
            get
            {
                return activeTool;
            }
            set
            {
                activeTool = value;
                //换了工具则取清空起始位置
                mouseStartPos = Point.Empty;
            }
        }
        /// <summary>
        /// 选择的区域
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle SelectRectangle
        {
            get
            {
                return selectRectangle;
            }
            set
            {
                selectRectangle = value;
            }
        }
        /// <summary>
        /// 是否画选择区域
        /// </summary>
        public bool IsDrawSelectRectangle
        {
            get
            {
                return isdrawSelectRectangel;
            }
            set
            {
                isdrawSelectRectangel = value;
            }
        }

        /// <summary>
        /// 是否画出鼠标在设计器的当前位置
        /// </summary>
        public bool IsDrawMousePosition
        {
            get
            {
                return isdrawMousePosition;
            }
            set
            {
                isdrawMousePosition = value;
            }
        }

        /// <summary>
        /// 关闭是检查对像是否被修改过
        /// 在新建或是保存的时候,检查设计有没有被理改
        /// True: 更改过
        /// False:没有更改过
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ChangeFlage
        {
            get
            {
                return changeFlag;
            }
            set
            {
                changeFlag = value;
            }
        }
        /// <summary>
        /// 取得或设置当前处在编辑状态的对像
        /// 在对像进行切换时判断是否要隐藏textbox
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DrawText SelectDrawText
        {
            get
            {
                return drawTextObject;
            }
            set
            {
                drawTextObject = value;
            }
        }

        private void Designer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ActiveTool != null && CanSelectItem)
            {
                activeTool.OnMouseDown(this, e);
                //当活动的工具不是"选择"工具和事件绑定的情况下触发
                if ((activeTool.GetType().Name != typeof(ToolSelector).Name) && (OnItemChange != null))
                {
                    OnItemChange();
                }

                //取得鼠标在拖拽对像是的活动区域
                //Cursor.Clip = new Rectangle(Cursor.Position.X - e.X, Cursor.Position.Y - e.Y, this.Width, this.Height);                
            }
            if (isdrawMousePosition)
            {
                //拖拽时记录起始位置
                mouseStartPos = new Point(e.X, e.Y);
                mouseXs = new Point(0, e.Y);
                mouseXe = new Point(e.X, e.Y);
                mouseYs = new Point(e.X, 0);
                mouseYe = new Point(e.X, e.Y);
                //this.Refresh();
            }
            //如果文本选择区域没有被选择则隐藏文本输入框
            if (SelectDrawText != null && !SelectDrawText.Selected && textBox.Visible)
            {
                SelectDrawText.TextValue = textBox.Text;
                textBox.Visible = false;
                textBox.Enabled = false;
                textBox.Text = "";
            }

        }
        /// <summary>
        /// 设计器的鼠标移动事件,
        /// 在画标尺时画出鼠标的位置
        /// </summary>
        public MouseEventHandler DesignerMouseMove;
        private void Designer_MouseMove(object sender, MouseEventArgs e)
        {
            //if (ptOld != new Point(e.X, e.Y))
            //{
            //如果ActiveTool 不空NULL则触发鼠标移动事件
            if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.None) && ActiveTool != null && CanSelectItem)
            {
                activeTool.OnMouseMove(this, e);
            }

            if (DesignerMouseMove != null)
            {
                DesignerMouseMove(sender, e);
            }
            if (isdrawMousePosition)
            {
                //如果起始位置不为空说明在拖拽对像则出画起即始坐标
                //if (mouseStartPos == Point.Empty)
                //{
                mouseXs = new Point(0, e.Y);
                mouseXe = new Point(e.X, e.Y);
                mouseYs = new Point(e.X, 0);
                mouseYe = new Point(e.X, e.Y);
                //}
                this.Refresh();
            }
            //}
            //ptOld = new Point(e.X, e.Y);
        }

        private void Designer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ActiveTool != null && CanSelectItem)
            {
                activeTool.OnMouseUp(this, e);
                //恢复鼠标的工作区域
                Cursor.Clip = tempCursorPos;
                //拖拽完成后设置这个值为空,程序将不会在画出鼠标坐标线
                mouseXs = Point.Empty;
                if (ActiveTool.GetType().Name != typeof(ToolSelector).Name)
                {
                    activeTool = new ToolSelector();
                    if (OnActiveToolChange != null)
                    {
                        OnActiveToolChange(activeTool);
                    }
                }
            }

        }


        private void Designer_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (showGrid)
            {
                //计算出标尺所在的宽和高
                float width_mm = CommonSettings.PixelConvertMillimeter(this.Width);
                float height_mm = CommonSettings.PixelConvertMillimeter(this.Height);

                DrawGrid(g, (int)width_mm, Orientation.Vertical, this.Width / width_mm);
                DrawGrid(g, (int)height_mm, Orientation.Horizontal, this.Height / height_mm);
            }

            //g.ScaleTransform(1.5f, 1.5f, MatrixOrder.Append);
            //设计器画出对像
            //if (this.Items != null && this.Items.Count > 0)
            //{
            Items.Draw(g);
            //} 

            //是否画出选择的矩形
            if (isdrawSelectRectangel)
            {
                DrawSelectorRectangel(e.Graphics);
            }
            //是否画出鼠标的位置线
            if (isdrawMousePosition)
            {
                if (mouseXs != Point.Empty)
                {
                    e.Graphics.DrawLine(Pens.SkyBlue, mouseXs, mouseXe);
                    e.Graphics.DrawLine(Pens.SkyBlue, mouseYs, mouseYe);
                }
            }
        }

        /// <summary>
        /// 画标尺刻度
        /// </summary>
        /// <param name="g"></param>
        private void DrawGrid(Graphics g, int whidth, Orientation gridOrientation, float percent)
        {

            PointF ps, pe;
            int scale = -1;
            for (int i = 0; i < whidth; i += 5)
            {
                if (i % 10 == 0)
                {
                    scale = 10;
                }
                else
                {
                    scale = 5;
                }

                if (gridOrientation == Orientation.Horizontal)
                {
                    ps = new PointF(0, i * percent);
                    pe = new PointF(this.Width, i * percent);
                }
                else
                {
                    ps = new PointF(i * percent, 0);
                    pe = new PointF(i * percent, this.Height);
                }
                if (scale == 5)
                {
                    //选中画出矩形框
                    using (Pen pen = new Pen(Color.SkyBlue))
                    {
                        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        pen.DashPattern = new float[] { 3.0f, 3.0f };
                        g.DrawLine(pen, ps, pe);
                    }
                }
                else
                {
                    g.DrawLine(Pens.SkyBlue, ps, pe);
                }
            }
        }

        /// <summary>
        /// 打印设计器的内容
        /// </summary>
        /// <param name="printcopys">打印多少份副本</param>
        public void PrintPage(int printcopys)
        {
            PrintDocument pd = LoadPrintSetting();
            //pd.DefaultPageSettings.PrinterSettings.PrinterName = "pdfFactory Pro";
            pd.Print();
        }

        /// <summary>
        /// 预览设计器的内容
        /// </summary>
        public void PrintView()
        {
            PrintDocument pd = LoadPrintSetting();
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            //pd.DefaultPageSettings.PrinterSettings.PrinterName = "pdfFactory Pro";

            ppd.Document = pd;
            ppd.ShowDialog();

        }

        /// <summary>
        /// 数据源中的数据可以分多少页打印
        /// </summary>
        int pages = 0;
        private PrintDocument LoadPrintSetting()
        {
            ///计算出总面数
            pages = datasource.Rows.Count % pagerows == 0 ? datasource.Rows.Count % pagerows : datasource.Rows.Count / pagerows + 1;
            //指定数据源
            this.Items.DataSource = datasource;
            //指定行高
            this.Items.RowsHeight = rowheight;
            //指定每页有多少条记录
            this.Items.PageRowsCount = pagerows;
            PrintDocument pd = new PrintDocument();
            //自定义页面的大小
            PaperSize ps = new PaperSize("MyPage", this.Width, this.Height);
            pd.DefaultPageSettings.PaperSize = ps;
            //pd.PrinterSettings.PrinterName = printerConfig.PrintName;
            pd.PrinterSettings.Copies = (short)printerConfig.Copies;
            //使用自定义页面设置
            pd.DefaultPageSettings.PaperSize.RawKind = 256;
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            return pd;

        }

        /// <summary>
        /// 当前是哪一页
        /// </summary>
        int currentpage = 1;
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            this.Items.UnSelectAll();
            e.Graphics.TranslateTransform(printerConfig.XOFFSET, printerConfig.YOFFSET);
            //首先打印的是第一页
            this.Items.CurrentPage = currentpage;
            this.Items.Draw(e.Graphics);
            //判断当前面是否小于总页数
            if (currentpage < pages)
            {
                //如果小于总页数则当前页+1并且设置有更多的页为true
                currentpage++;
                e.HasMorePages = true;
            }
            else
            {
                //如果当前页>=总页数则设设置是否有更多的页为false结束打印
                e.HasMorePages = false;
            }
            e.Graphics.ResetTransform();

        }

        private void DrawSelectorRectangel(Graphics g)
        {
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(50, Color.SkyBlue)))
            {
                g.FillRectangle(sb, selectRectangle);
            }
            //使用完画笔后及时的释放资源
            using (Pen pen = new Pen(Color.SkyBlue))
            {
                pen.DashStyle = DashStyle.Dash;
                pen.DashPattern = new float[] { 3.0f, 3.0f };

                g.DrawRectangle(pen, selectRectangle);
            }
        }

        private void Designer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //如果用户按下DELETE键,删除所选对像
                case Keys.Delete:
                    DeleteSelectedItem();
                    break;
                case Keys.Left:
                    int n = Items.SelectionCount;
                    for (int i = 0; i < n; i++)
                    {
                        Items.GetSelectItem(i).Move(-1, 0);
                    }
                    Refresh();
                    break;

            }
        }

        /// <summary>
        /// 删除设计器选中的对像
        /// </summary>
        public void DeleteSelectedItem()
        {
            //获取设计器中的对像数量
            DrawItemBase[] drawitems = new DrawItemBase[Items.Count];
            Items.CopyTo(drawitems, 0);//将对像复制一份删除时使用
            foreach (DrawItemBase dib in drawitems)
            {
                //如果对像选择删除
                if (dib.Selected)
                {
                    //Items.UnSelectAll();
                   
                    Items.Remove(dib);
                    //if (dib is DrawText)
                    //{
                    //    textBox.Text = "";
                    //    textBox.Visible = false;
                    //}
                }
            }
            //更新对像
            this.Refresh();
            //删除时触发item更改事件在documentspace中更新对像列表
            if (OnItemChange != null)
            {
                OnItemChange();
            }
        }

        private void Designer_MouseLeave(object sender, EventArgs e)
        {
            //如果鼠标离开设计器
            //如果是画鼠标位置则将坐标清空
            if (isdrawMousePosition)
            {
                mouseXs = Point.Empty;
                mouseXe = Point.Empty;
                mouseYs = Point.Empty;
                mouseYe = Point.Empty;
                this.Refresh();
            }
        }

        private void Designer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //如果是鼠标左键和当前工具是"选择"才执行显示属性或编辑(文本)操作
            if (e.Button == MouseButtons.Left && (activeTool.GetType().Name == typeof(ToolSelector).Name))
            {
                //由于在鼠标点击时控制了鼠标工作区域,如果是双击则不需要控制
                //恢复鼠标的工作区域
                Cursor.Clip = tempCursorPos;
                if (this.Items != null && this.Items.Count > 0)
                {
                    //取消所有选择
                    this.Items.UnSelectAll();
                    int count = this.Items.Count;
                    DrawItemBase item = null;
                    for (int i = 0; i < count; i++)
                    {
                        //检查是否有选中的对像
                        if (this.Items[i].HitTest(new Point(e.X, e.Y)) == 0)
                        {
                            item = this.Items[i];//获取选中的对像
                            item.Selected = true;//设置为选中状态
                            //如果绑定了显示属性事件则触发事件
                            if (OnShowProperityInfo != null)
                            {
                                OnShowProperityInfo(item);
                            }
                            //如果是文本编辑则显示出textbox
                            if (item.GetType().Name == typeof(DrawText).Name)
                            {
                                DrawText dt = item as DrawText;
                                textBox.Location = new Point(dt.Rectangle.X + 8, dt.Rectangle.Y + 7);
                                textBox.Size = new Size(dt.Rectangle.Width - 14, dt.Rectangle.Height - 14);
                                textBox.Font = dt.TextFont;
                                textBox.Text = dt.TextValue;
                                textBox.Focus();
                                textBox.Enabled = true;
                                textBox.Visible = true;
                            }
                            this.Refresh();
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 在选择和添加对像时及时更新属性显示器中的内容
        /// </summary>
        /// <param name="item">要显示属性的对像</param>
        public void SelectedItem(DrawItemBase item)
        {
            if (OnShowProperityInfo != null)
            {
                OnShowProperityInfo(item);
            }
        }

        private void Designer_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void Designer_KeyUp(object sender, KeyEventArgs e)
        {
            int n = 0;
            switch (e.KeyCode)
            {
                //如果用户按下DELETE键,删除所选对像
                case Keys.Left:
                    n = Items.SelectionCount;
                    for (int i = 0; i < n; i++)
                    {
                        Items.GetSelectItem(i).Move(-1, 0);
                    }
                    Refresh();
                    break;
                case Keys.Up:
                    n = Items.SelectionCount;
                    for (int i = 0; i < n; i++)
                    {
                        Items.GetSelectItem(i).Move(0, -1);
                    }
                    Refresh();
                    break;
                case Keys.Down:
                    n = Items.SelectionCount;
                    for (int i = 0; i < n; i++)
                    {
                        Items.GetSelectItem(i).Move(0, 1);
                    }
                    Refresh();
                    break;
                case Keys.Right:
                    n = Items.SelectionCount;
                    for (int i = 0; i < n; i++)
                    {
                        Items.GetSelectItem(i).Move(1, 0);
                    }
                    Refresh();
                    break;

            }
        }


        //public override void Refresh()
        //{
        //    //Graphics g = this.CreateGraphics();
        //    //g.Clear(BackColor);
        //    //if (BackgroundImage != null)
        //    //{
        //    //    g.DrawImage(BackgroundImage, this.ClientRectangle);
        //    //}
        //    //PaintEventArgs pe = new PaintEventArgs(g, this.ClientRectangle);
        //    //OnPaint(pe);
        //    base.Refresh();
        //}       
    }
}
