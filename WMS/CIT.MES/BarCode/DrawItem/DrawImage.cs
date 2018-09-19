using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace CIT.MES.DrawItem
{
    [Serializable()]
    public class DrawImage:DrawRectangle,ISerializable
    {
        public DrawImage()
        {
        }

        public DrawImage(int x, int y, int w, int h)
            : base(x, y, w, h)
        { }

        private Image image;

        /// <summary>
        /// 所要显示的图片
        /// </summary>
        public Image ImageObject
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }


        public override string Name
        {
            get { return "图片"; }
        }

        public override Image IconImage
        {
            get
            {
                return GetIconImage("image.gif");
            }
        }

        /// <summary>
        /// 将图片画到佛定位置
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            if (Selected)
            {
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
            else
            {
                //如果没有选中,但是没有图片
                //则画出虚线框
                if (image == null)
                {
                    using (Pen pen = new Pen(Color.SkyBlue))
                    {
                        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        pen.DashPattern = new float[] { 3.0f, 3.0f };

                        g.DrawRectangle(pen, this.Rectangle);
                    }
                }
            }
            if (image != null)
            {
                //有图片则画出图片
                g.DrawImage(image, this.Rectangle);
            }
            else
            {
                //没有图片在指定的区域画出提示信息
                GraphicsState state = g.Save();
                g.SetClip(this.Rectangle);//提示信息不能超出图片所在的区域
                g.DrawString("请选择图片!", new Font("Verdana", 9), Brushes.DarkRed, this.Rectangle.X + 8, this.Rectangle.Y + 8);
                g.Restore(state);//恢复做图区域
            }
        }

         new public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Image", this.image);
            info.AddValue("ImageRectangle", this.Rectangle);

        }
        public DrawImage(SerializationInfo info, StreamingContext context)
            : this()
        {
            this.image = info.GetValue("Image", typeof(Image)) == null ? null : info.GetValue("Image", typeof(Image)) as Image ;
            this.Rectangle = (Rectangle)info.GetValue("ImageRectangle", typeof(Rectangle));
        }
    }
}
