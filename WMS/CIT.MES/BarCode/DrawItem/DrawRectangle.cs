using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace CIT.MES.DrawItem
{
    [Serializable()]
    public class DrawRectangle : DrawItemBase, ISerializable
    {
        private Rectangle rectangle;

        public Rectangle Rectangle
        {
            get
            {
                return GetNormalizedRectangle(rectangle);
            }
            set
            {
                rectangle = GetNormalizedRectangle(value);
            }
        }

        public DrawRectangle()
        {
            rectangle = new Rectangle(0, 0, 50, 20);
            //IconImage = GetIconImage("rectangle.png");
        }


        public override string Name
        {
            get { return "矩形"; }
        }

        public override Image IconImage
        {
            get
            {
                return GetIconImage("rectangle.png");
            }
        }

        public DrawRectangle(int x, int y, int w, int h)
        {
            rectangle.X = x;
            rectangle.Y = y;
            rectangle.Width = w;
            rectangle.Height = h;
        }

        public override void Draw(Graphics g)
        {
            //如果选择则半透明填充
            if (Selected && (FillColor == Color.Transparent))
            {
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(60, Color.SkyBlue)))
                {//如果是选中状态画出虚线框
                    using (Pen pen = new Pen(Color.SkyBlue))
                    {
                        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        pen.DashPattern = new float[] { 3.0f, 3.0f };

                        g.DrawRectangle(pen, this.Rectangle);
                        g.DrawLine(pen, 0, Rectangle.Y, Rectangle.X, Rectangle.Y);
                        g.DrawLine(pen, Rectangle.X, 0, Rectangle.X, Rectangle.Y);
                        Point xyNotice;
                        int fontHeight = new Font("Verdana", 7).Height;
                        if (Rectangle.Y < fontHeight)
                        {
                            xyNotice = new Point(Rectangle.X, Rectangle.Y + Rectangle.Height + 2);
                        }
                        else
                        {
                            xyNotice = new Point(Rectangle.X + 2, Rectangle.Y - fontHeight - 2);
                        }
                        g.DrawString(string.Format("[X:{0} Y:{1}][W:{2} H:{3}]", (int)CommonSettings.PixelConvertMillimeter(Rectangle.X), (int)CommonSettings.PixelConvertMillimeter(Rectangle.Y), (int)CommonSettings.PixelConvertMillimeter(Rectangle.Width), (int)CommonSettings.PixelConvertMillimeter(Rectangle.Height)), new Font("Verdana", 7), Brushes.Blue, xyNotice);
                    }
                    g.FillRectangle(sb, rectangle);
                }


            }

            using (Pen rectPen = new Pen(LineColor, LineWidth))
            {
                using (SolidBrush sbh = new SolidBrush(FillColor))
                {
                    g.FillRectangle(sbh, GetNormalizedRectangle(rectangle));
                }
                g.DrawRectangle(rectPen, GetNormalizedRectangle(rectangle));
            }
        }

        /// <summary>
        /// 设置对像的大小
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        protected void SetRectangle(int x, int y, int width, int height)
        {
            rectangle.X = x;
            rectangle.Y = y;
            rectangle.Width = width <= 0 ? 100 : width;
            rectangle.Height = height <= 0 ? 40 : height;
        }

        /// <summary>
        /// 获取手柄数
        /// </summary>
        public override int HandleCount
        {
            get { return 8; }
        }

        /// <summary>
        /// 获取手柄所在的坐标
        /// 1--2--3
        /// |     |
        /// 4     5
        /// |     |
        /// 6--7--8
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Point GetHandle(int handleNumber)
        {
            int x, y, xCenter, yCenter;
            xCenter = rectangle.X + rectangle.Width / 2;
            yCenter = rectangle.Y + rectangle.Height / 2;
            x = rectangle.X;
            y = rectangle.Y;
            switch (handleNumber)
            {
                case 2:
                    x = xCenter;
                    break;
                case 3:
                    x = rectangle.Right;
                    break;
                case 4:
                    y = yCenter;
                    break;
                case 5:
                    x = rectangle.Right;
                    y = yCenter;
                    break;
                case 6:
                    y = rectangle.Bottom;
                    break;
                case 7:
                    x = xCenter;
                    y = rectangle.Bottom;
                    break;
                case 8:
                    x = rectangle.Right;
                    y = rectangle.Bottom;
                    break;
            }

            return new Point(x, y);
        }

        /// <summary>
        /// 测试鼠标的当前位置有没有在对像上
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override int HitTest(Point point)
        {
            if (Selected)
            {
                //是否在对像的手柄上
                for (int i = 1; i <= HandleCount; i++)
                {
                    if (GetHandleRectangle(i).Contains(point))
                    {
                        return i;
                    }
                }
            }
            //在对像上但不是在手柄上
            if (PointInObject(point))
            {
                return 0;
            }
            //不在对像上
            return -1;
        }

        /// <summary>
        /// 检查点是否在矩形上
        /// </summary>
        /// <param name="point">要检查的点</param>
        /// <returns></returns>
        protected override bool PointInObject(Point point)
        {
            return rectangle.Contains(point);
        }

        /// <summary>
        /// 获取鼠标把在手柄的光标
        /// 1--2--3
        /// |     |
        /// 4     5
        /// |     |
        /// 6--7--8
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Cursor GetHandleCursor(int handleNumber)
        {
            Cursor cursor = Cursors.Default;
            switch (handleNumber)
            {
                case 1:
                    cursor = Cursors.SizeNWSE;
                    break;
                case 2:
                    cursor = Cursors.SizeNS;
                    break;
                case 3:
                    cursor = Cursors.SizeNESW;
                    break;
                case 4:
                    cursor = Cursors.SizeWE;
                    break;
                case 5:
                    cursor = Cursors.SizeWE;
                    break;
                case 6:
                    cursor = Cursors.SizeNESW;
                    break;
                case 7:
                    cursor = Cursors.SizeNS;
                    break;
                case 8:
                    cursor = Cursors.SizeNWSE;
                    break;
            }
            return cursor;
        }

        /// <summary>
        /// 改变对像的大小
        /// 1--2--3
        /// |     |
        /// 4     5
        /// |     |
        /// 6--7--8
        /// </summary>
        /// <param name="point"></param>
        /// <param name="handleIndex"></param>
        public override void MoveHandleTo(Point point, int handleIndex)
        {
            int left = rectangle.Left, right = rectangle.Right, top = rectangle.Top, bottom = rectangle.Bottom;
            switch (handleIndex)
            {
                case 1:
                    left = point.X;
                    top = point.Y;
                    break;
                case 2:
                    top = point.Y;
                    break;
                case 3:
                    right = point.X;
                    top = point.Y;
                    break;
                case 4:
                    left = point.X;
                    break;
                case 5:
                    right = point.X;
                    break;
                case 6:
                    left = point.X;
                    bottom = point.Y;
                    break;
                case 7:
                    bottom = point.Y;
                    break;
                case 8:
                    right = point.X;
                    bottom = point.Y;
                    break;
            }
            SetRectangle(left, top, right - left, bottom - top);
        }

        /// <summary>
        /// 选择的矩形是否包含对像区域
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public override bool IntersectsWith(Rectangle selectRect)
        {
            return selectRect.Contains(rectangle);
        }

        /// <summary>
        /// 移动对像到坐标点上
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        public override void Move(int deltaX, int deltaY)
        {
            rectangle.X += deltaX;
            rectangle.Y += deltaY;
        }

        public override void Normalize()
        {
            GetNormalizedRectangle(rectangle);

        }

        public static Rectangle GetNormalizedRectangle(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1)
            {
                int tmp = x2;
                x2 = x1;
                x1 = tmp;
            }

            if (y2 < y1)
            {
                int tmp = y2;
                y2 = y1;
                y1 = tmp;
            }

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        public static Rectangle GetNormalizedRectangle(Point p1, Point p2)
        {
            return GetNormalizedRectangle(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static Rectangle GetNormalizedRectangle(Rectangle r)
        {
            return GetNormalizedRectangle(r.X, r.Y, r.X + r.Width, r.Y + r.Height);
        }


        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Rectangle", this.rectangle);
            info.AddValue("PenWidth", this.LineWidth);
            info.AddValue("LineColor", this.LineColor);
            info.AddValue("FillColor", this.FillColor);

        }
        public DrawRectangle(SerializationInfo info, StreamingContext context)
            : this()
        {
            this.rectangle = (Rectangle)info.GetValue("Rectangle", typeof(Rectangle));
            this.LineWidth = info.GetInt32("PenWidth");
            this.LineColor = (Color)info.GetValue("LineColor", typeof(Color));
            this.FillColor = (Color)info.GetValue("FillColor", typeof(Color));
        }

        #endregion
    }
}
