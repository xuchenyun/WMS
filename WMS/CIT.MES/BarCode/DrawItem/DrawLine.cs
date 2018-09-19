using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CIT.MES.DrawItem
{
    [Serializable()]
    public class DrawLine:DrawItemBase,ISerializable
    {
        public DrawLine()
        {
            pfs = new Point(0, 0);
            pfe = new Point(1, 1);
            
        }

        public DrawLine(Point fs, Point fe)
        {
            pfs = fs;
            pfe = fe;
        }

        public override string Name
        {
            get { return "直线"; }
        }

        public override Image IconImage
        {
            get
            {
                return GetIconImage("line.png");
            }
        }

        /// <summary>
        /// 起始坐标
        /// </summary>
        private Point pfs = new Point();
        /// <summary>
        /// 结束坐标
        /// </summary>
        private Point pfe = new Point();
        /// <summary>
        /// 做图所在区域的路径
        /// 在选择是使用
        /// </summary>
        private GraphicsPath areaPath = null;
        /// <summary>
        /// 做图所在的区域
        /// 在选择是使用
        /// </summary>
        private Region areaRegion = null;
        /// <summary>
        /// 绘制区域的画笔
        /// 在选择是使用
        /// </summary>
        private Pen areaPen = null;

        private bool drawWithDatasource = false;
        private string valuecolumn = string.Empty;

        /// <summary>
        /// 是否和数据源中的行进行重复的画出来
        /// 如果值为True请不要修改ValueColumn的值,当ValueColumn的值不为空时才会重复画出来
        /// </summary>
        [Description("是否和数据源中的行进行重复的画出来")]
        public bool DrawWithDataSource
        {
            get
            {
                return drawWithDatasource;
            }
            set
            {
                if (value)
                {
                    valuecolumn = "Temp";
                }
                else
                {
                    valuecolumn = "";
                }
                drawWithDatasource = value;
            }
        }

        /// <summary>
        /// 因为不用从数据源中取数据所以不用显示
        /// 但不能显示,在DrawItemList中有通过检查此属性是否为空,如果为空则不会添加数源
        /// </summary>
        [Browsable(false)]
        public override string ValueColumn
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
        /// 直线的开始坐标
        /// </summary>
        [Description("直线的开始坐标")]
        public Point StartPoint
        {
            get
            {
                return pfs;
            }
            set
            {
                pfs = value;
            }
        }
        /// <summary>
        /// 直线的结束坐标
        /// </summary>
        [Description("直线的结束坐标")]
        public Point EndPoint
        {
            get
            {
                return pfe;
            }
            set
            {
                pfe = value;
            }
        }

        public override void Draw(Graphics g)
        {
            g.SmoothingMode = this.DrawSmoothingMode;

            if (GetDataSourceIsNotNullOrEmpty && DrawWithDataSource)
            {
                //根据当前的页数,找出在数据源中的第一条记录
                int i = (CurrentPage - 1) * PageRowsCount;
                int temp = 0;
                //依次画出数据源中的相应数据
                //TO DO
                for (; i < DataSource.Rows.Count; i++)
                {
                    //检查直线是不是垂直
                    //如果是垂直则设定线的高度为行高
                    Point temp1, temp2;
                    if (pfs.X == pfe.X)
                    {
                        temp1 = new Point(pfs.X, pfs.Y + temp * RowHeight);
                        temp2 = new Point(pfs.X, pfs.Y + temp * RowHeight + RowHeight);
                    }
                    else
                    {
                        temp1 = new Point(pfs.X, pfs.Y + temp * RowHeight);
                        temp2 = new Point(pfe.X, pfe.Y + temp * RowHeight);
                    }
                    DrawLineObject(g, temp1, temp2);
                    temp++;
                    //画出预先设置的数后退出
                    if (temp == PageRowsCount)
                    {
                        break;
                    }
                }
            }
            else
            {
                DrawLineObject(g, pfs, pfe);
            }
            
        }

        private void DrawLineObject(Graphics g,Point pointStart,Point pointEnd)
        {
            using (Pen linePen = new Pen(this.LineColor, LineWidth))
            {
                g.DrawLine(new Pen(new SolidBrush(this.LineColor), LineWidth), pointStart, pointEnd);
            }
        }

        //鼠标移动画线,移动的是哪个坐标
        public override void MoveHandleTo(Point point, int handleIndex)
        {
            if (handleIndex == 2)
            {
                pfe = point;
            }
            else
            {
                pfs = point;
            }
            ReleaseTempObject();
        }

        //获得对像有几个调节手柄
        public override int HandleCount
        {
            get { return 2; }
        }

        public override Point GetHandle(int handleNumber)
        {
            //如果是第一个坐标点则返回起始坐标
            if (handleNumber == 1)
            {
                return pfs;
            }
            return pfe;
        }

        public override int HitTest(Point point)
        {
           if(Selected)
           {
               for (int i = 1; i <= HandleCount; i++)
               {
                   if (GetHandleRectangle(i).Contains(point))
                   {
                       return i;
                   }
               }
           }
           if (PointInObject(point))
           {
               return 0;
           }
           return -1;
        }

        protected override bool PointInObject(Point point)
        {
            CreateObjects();
            return areaRegion.IsVisible(point);
        }

        public override bool IntersectsWith(Rectangle rectangle)
        {
            CreateObjects();
            return areaRegion.IsVisible(rectangle);
        }

        public override Cursor GetHandleCursor(int handleNumber)
        {
            switch (handleNumber)
            {
                case 1:
                case 2:
                    return Cursors.SizeAll;
                default:
                    return Cursors.Default;
            }
        }

        public override void Move(int deltaX, int deltaY)
        {
            pfs.X += deltaX;
            pfs.Y += deltaY;

            pfe.X += deltaX;
            pfe.Y += deltaY;
            ReleaseTempObject();
        }

        private void CreateObjects()
        {
           
            if (areaPath != null)
            {
                return;
            }
            //在设置选择路径时将直线加粗,方便选择
            using (areaPen = new Pen(Color.Blue, this.LineWidth + 7))
            {
                areaPath = new GraphicsPath();
                areaPath.AddLine(pfs, pfe);

                areaPath.Widen(areaPen);

                areaRegion = new Region(areaPath);
            }
        }

        /// <summary>
        /// 释放做图区域
        /// </summary>
        private void ReleaseTempObject()
        {
            if (areaPath != null)
            {
                areaPath.Dispose();
                areaPath = null;
            }
            //if (areaPen != null)
            //{
            //    areaPen.Dispose();
            //    areaPen = null;
            //}
            if (areaRegion != null)
            {
                areaRegion.Dispose();
                areaRegion = null;
            }
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("StartPoint", this.StartPoint);
            info.AddValue("EndPoint", this.EndPoint);
            info.AddValue("PenWidth", this.LineWidth);
            info.AddValue("LineColor", this.LineColor);
            info.AddValue("FillColor", this.FillColor);
            info.AddValue("DrawWithDataSource", DrawWithDataSource);

        }
        public DrawLine(SerializationInfo info, StreamingContext context)
            : this()
        {
            this.StartPoint = (Point)info.GetValue("StartPoint", typeof(Point));
            this.EndPoint = (Point)info.GetValue("EndPoint", typeof(Point));
            this.LineWidth = info.GetInt32("PenWidth");
            this.LineColor = (Color)info.GetValue("LineColor", typeof(Color));
            this.FillColor = (Color)info.GetValue("FillColor", typeof(Color));
            this.DrawWithDataSource = info.GetBoolean("DrawWithDataSource");
        }

        #endregion

    }
}
