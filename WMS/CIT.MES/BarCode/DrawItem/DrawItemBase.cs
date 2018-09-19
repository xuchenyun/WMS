using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Data;

namespace CIT.MES.DrawItem
{
    [Serializable()]
    public abstract class DrawItemBase : ICloneable
    {
        private bool selected = false;
        private int lineWidth = 1;
        private Color color = Color.Black;
        private Color fillColor = Color.Transparent;
        private SmoothingMode smoothingMode = SmoothingMode.Default;
        private DataTable datasource;
        private int rowscount = 5;
        private string valuecolumn = string.Empty;
        private int currentPage = 1;
        private int rowsHeight = 25;

        /// <summary>
        /// 获取数据源是否为空
        /// </summary>
        protected bool GetDataSourceIsNotNullOrEmpty
        {
            get
            {
                return CheckDataTabelIsNoteNullOrEmpty(DataSource);
            }
        }

        List<PrintItem> _printItem;
        [Category("Barcode Attribute"), Description("设置打印自项"), DisplayName("打印子项")]
        public List<PrintItem> printItem
        {
            get
            {
                if (_printItem == null)
                {
                    _printItem = new List<PrintItem>();
                }
                return _printItem;
            }
            set { _printItem = value; }
        }

        /// <summary>
        /// 获取或设置行高
        /// </summary>
        [Browsable(false)]
        public int RowHeight
        {
            get
            {
                return rowsHeight;
            }
            set
            {
                rowsHeight = value;
            }
        }

        /// <summary>
        /// 当前是哪一页
        /// </summary>
        [Browsable(false)]
        public int CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
            }
        }
        /// <summary>
        /// 从datasource中哪一列中取值
        /// </summary>
        [Description("从DataTable中哪个Columns中取值"), DisplayName("列名")]
        public virtual string ValueColumn
        {
            get
            {
                return valuecolumn;
            }
            set
            {
                valuecolumn = value;
            }
        }





        /// <summary>
        /// 如果是列表,对像所在重复的次数
        /// </summary>
        [Browsable(false)]
        public int PageRowsCount
        {
            get
            {
                return rowscount;
            }
            set
            {
                rowscount = value;
            }
        }
        /// <summary>
        /// 设置对像的数据源
        /// 只支持DataTable数据源
        /// 待修改成为支持IList接口的数据源
        /// </summary>
        [Browsable(false)]
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
        /// 对像是否选择
        /// </summary>
        [Browsable(false)]
        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                //如果选中,则不做操作
                selected = value;
            }
        }

        /// <summary>
        /// 设置对像的外观线的宽度
        /// </summary>
        [Description("设置对像外观线的宽度"), DisplayName("线条宽度")]
        public virtual int LineWidth
        {
            get
            {
                return lineWidth;
            }
            set
            {
                lineWidth = value;
            }
        }
        /// <summary>
        /// 设置对像颜色
        /// </summary>
        [Description("设置对像颜色"), DisplayName("颜色")]
        public Color LineColor
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("设置对像的填充颜色"), DisplayName("填充颜色")]
        public Color FillColor
        {
            get
            {
                return fillColor;
            }
            set
            {
                fillColor = value;
            }
        }

        /// <summary>
        /// 设置对像的呈现质量
        /// </summary>
        [Description("设置对像的呈现质量,如果是条码则不受影响!"), DisplayName("做图质量")]
        public SmoothingMode DrawSmoothingMode
        {
            get
            {
                return smoothingMode;
            }
            set
            {
                if (value != SmoothingMode.Invalid)
                {
                    smoothingMode = value;
                }
            }
        }

        /// <summary>
        /// 检查DataTable是否为空
        /// </summary>
        /// <param name="dt">要检查的DataTable</param>
        /// <returns>False:为空 True:不为空</returns>
        protected bool CheckDataTabelIsNoteNullOrEmpty(DataTable dt)
        {
            bool IsNotNull = true;
            if (DataSource == null)
            {
                IsNotNull = false;
            }
            else if (DataSource.Rows.Count == 0)
            {
                IsNotNull = false;
            }
            return IsNotNull;
        }

        /// <summary>
        /// 从资源文件中获取图标文件
        /// </summary>
        /// <param name="imageName">图标文件的名称,不加扩展名</param>
        /// <returns></returns>
        protected Image GetIconImage(string imageName)
        {
            using (Stream fs = Assembly.GetAssembly(typeof(DrawItemBase)).GetManifestResourceStream("CIT.MES.Resources." + imageName))
            {
                Image image = Image.FromStream(fs);
                return image;
            }
        }


        /// <summary>
        /// 鼠标移动到什么地方
        /// </summary>
        /// <param name="point">鼠标移动到的坐标</param>
        /// <param name="handleIndex">鼠标的焦点在哪一个手柄上</param>
        public virtual void MoveHandleTo(Point point, int handleIndex)
        {
        }

        /// <summary>
        /// 获得手柄的坐点
        /// </summary>
        /// <param name="handleNumber">哪一个手柄</param>
        /// <returns></returns>
        public virtual Point GetHandle(int handleNumber)
        {
            return new Point(0, 0);
        }

        /// <summary>
        /// 获得手柄矩形大小
        /// </summary>
        /// <param name="handleNumber">哪一个手柄</param>
        /// <returns></returns>
        public virtual Rectangle GetHandleRectangle(int handleNumber)
        {
            Point point = GetHandle(handleNumber);

            return new Rectangle(point.X - 3, point.Y - 3, 7, 7);
        }

        /// <summary>
        /// 画出手柄
        /// </summary>
        /// <param name="g"></param>
        public virtual void DrawTracker(Graphics g)
        {
            if (!Selected)
                return;

            for (int i = 1; i <= HandleCount; i++)
            {
                g.DrawRectangle(Pens.SkyBlue, GetHandleRectangle(i));
            }
        }

        /// <summary>
        /// 是否被点击
        /// 如返回大于1则是被点击并返回手柄数!
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public virtual int HitTest(Point point)
        {
            return -1;
        }

        /// <summary>
        /// 点是否是对像中
        /// </summary>
        /// <param name="point">在返回true</param>
        /// <returns></returns>
        protected virtual bool PointInObject(Point point)
        {
            return false;
        }

        /// <summary>
        /// 是否在传来的矩型中
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public virtual bool IntersectsWith(Rectangle rectangle)
        {
            return false;
        }

        /// <summary> 
        /// 将对像移动到哪个点上
        /// </summary>
        /// <param name="deltaX">X坐标点</param>
        /// <param name="deltaY">Y坐标点</param>
        public virtual void Move(int deltaX, int deltaY)
        {
        }

        /// <summary>
        /// 调用此功能结束放大或缩小
        /// </summary>
        public virtual void Normalize()
        {
        }

        /// <summary>
        /// 获进手柄光标
        /// </summary>
        /// <param name="handleNumber">哪一个手柄</param>
        /// <returns></returns>
        public virtual Cursor GetHandleCursor(int handleNumber)
        {
            return Cursors.Default;
        }

        /// <summary>
        /// 设置选中后对像有几个调节手柄
        /// 例：线２个，矩型８个等
        /// </summary>
        [Browsable(false)]
        public abstract int HandleCount
        {
            get;
        }

        /// <summary>
        /// 在对像列表中显示的名称
        /// </summary>
        [Browsable(false)]
        public virtual string Name
        {
            get { return "NULL"; }
        }
        /// <summary>
        /// 在对像列表中显示的图标
        /// </summary>
        [Browsable(false)]
        public virtual Image IconImage
        {
            get { return null; }
        }

        public virtual void Draw(Graphics g)
        {

        }

        #region ICloneable Members

        public virtual object Clone()
        {
            return base.MemberwiseClone();
        }
        #endregion
    }

    [Serializable()]
    public class PrintItem
    {
        /// <summary>
        /// 设置对像颜色
        /// </summary>
        [Description("设置打印子项ID"), DisplayName("ID")]
        public string ID { get; set; }
        [Description("设置打印子项开始字符串"), DisplayName("开始字符串")]
        public string StartStr { get; set; }
        [Description("设置打印子项结尾字符串"), DisplayName("结尾字符串")]
        public string EndStr { get; set; }
        [Description("设置打印子项值"), DisplayName("打印值")]
        public string Value { get; set; }
    }

}
