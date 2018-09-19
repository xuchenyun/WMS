using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

namespace CIT.MES.DrawItem
{
    [Serializable()]
    public class DrawPolygon:DrawRectangle,ISerializable
    {
        public DrawPolygon()
        { 
        }

        public DrawPolygon(int x, int y, int w, int h)
            : base(x, y, w, h)
        { }

        public override string Name
        {
            get { return "棱形"; }
        }

        public override Image IconImage
        {
            get
            {
                return GetIconImage("polygon.gif");
            }
        }

        public override void Draw(Graphics g)
        {
            g.SmoothingMode = this.DrawSmoothingMode;
            if (Selected)
            {
                //选中画出矩形框
                using (Pen pen = new Pen(Color.SkyBlue))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    pen.DashPattern = new float[] { 3.0f, 3.0f };
                    g.DrawRectangle(pen, this.Rectangle);
                }
                //如果是选中状态画出虚线框
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
            }

            //如果不是透明则填充
            if (FillColor != Color.Transparent)
            {
                using (SolidBrush sb = new SolidBrush(FillColor))
                {
                    g.FillPolygon(sb, new Point[] { new Point(Rectangle.X + Rectangle.Width / 2, Rectangle.Y), new Point(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height / 2), new Point(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height), new Point(Rectangle.X, Rectangle.Y + Rectangle.Height / 2) });
                }
            }
            using (Pen dpen = new Pen(LineColor, LineWidth))
            {
                g.DrawPolygon(dpen, new Point[] { new Point(Rectangle.X + Rectangle.Width / 2, Rectangle.Y), new Point(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height / 2), new Point(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height), new Point(Rectangle.X, Rectangle.Y + Rectangle.Height / 2) });
            }
        }

        new public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PolygonRectangle", this.Rectangle);
        }

        public DrawPolygon(SerializationInfo info, StreamingContext context)
            : this()
        {
            this.Rectangle = (Rectangle)info.GetValue("PolygonRectangle", typeof(Rectangle));
        }

    }
}
