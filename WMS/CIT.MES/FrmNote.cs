using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CIT.MES
{
    public partial class FrmNote : Form
    {
        public FrmNote(string text)
        {
            InitializeComponent();
            if (text.Length > 16)
            {
                label1.Text = "复制完成";
                this.label1.Width = 100;
                this.Width = 300;
            }
            else
            {
                label1.Text = text + " 复制完成";
            }
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - 200));
            label1.Left = (this.Width - label1.Width) / 2;
            label1.Top = (this.Height - label1.Height) / 2;
            timer1.Start();
        }
        public FrmNote(string text,Color _ForeColor, Color BackColor, int CloseTime = 1)
        {
            InitializeComponent();

            this.BackColor = BackColor;
            label1.ForeColor = _ForeColor;
            if (text.Length > 17)
            {
                this.label1.Width = 100;
                this.Width = 300;
            }
            else
            {
                label1.Text = text;
            }
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - 250));
            label1.Left = (this.Width - label1.Width) / 2;
            label1.Top = (this.Height - label1.Height) / 2;
            timer1.Interval = CloseTime * 1000;
            timer1.Start();
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 163 && this.ClientRectangle.Contains(this.PointToClient(new Point(m.LParam.ToInt32()))) && m.WParam.ToInt32() == 2)
                m.WParam = (IntPtr)1;
            base.WndProc(ref m);
            if (m.Msg == 132 && m.Result.ToInt32() == 1)
                m.Result = (IntPtr)2;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }
        /// <summary>
        /// 圆角：radius=圆角弧度   rect是要做圆角的矩形
        /// </summary>
        public void SetWindowRegion(int width, int height)
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, width, height);
            FormPath = GetRoundedRectPath(rect, 8);
            this.Region = new Region(FormPath);
        }
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            //   左上角      
            path.AddArc(arcRect, 180, 90);
            //   右上角      
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            //   右下角      
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            //   左下角      
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }


        private void Type(System.Windows.Forms.Control sender, int p_1, double p_2)
        {
            GraphicsPath oPath = new GraphicsPath();
            oPath.AddClosedCurve(
                new Point[] {
            new Point(0, sender.Height / p_1),
            new Point(sender.Width / p_1, 0), 
            new Point(sender.Width - sender.Width / p_1, 0), 
            new Point(sender.Width, sender.Height / p_1),
            new Point(sender.Width, sender.Height - sender.Height / p_1), 
            new Point(sender.Width - sender.Width / p_1, sender.Height), 
            new Point(sender.Width / p_1, sender.Height),
            new Point(0, sender.Height - sender.Height / p_1) },

                (float)p_2);

            sender.Region = new Region(oPath);
        }

        private void FrmNote_Paint(object sender, PaintEventArgs e)
        {
            Form form = ((Form)sender);
            List<Point> list = new List<Point>();
            int width = form.Width;
            int height = form.Height;

            //左上
            list.Add(new Point(0, 5));
            list.Add(new Point(1, 5));
            list.Add(new Point(1, 3));
            list.Add(new Point(2, 3));
            list.Add(new Point(2, 2));
            list.Add(new Point(3, 2));
            list.Add(new Point(3, 1));
            list.Add(new Point(5, 1));
            list.Add(new Point(5, 0));
            //右上
            list.Add(new Point(width - 5, 0));
            list.Add(new Point(width - 5, 1));
            list.Add(new Point(width - 3, 1));
            list.Add(new Point(width - 3, 2));
            list.Add(new Point(width - 2, 2));
            list.Add(new Point(width - 2, 3));
            list.Add(new Point(width - 1, 3));
            list.Add(new Point(width - 1, 5));
            list.Add(new Point(width - 0, 5));
            //右下
            list.Add(new Point(width - 0, height - 5));
            list.Add(new Point(width - 1, height - 5));
            list.Add(new Point(width - 1, height - 3));
            list.Add(new Point(width - 2, height - 3));
            list.Add(new Point(width - 2, height - 2));
            list.Add(new Point(width - 3, height - 2));
            list.Add(new Point(width - 3, height - 1));
            list.Add(new Point(width - 5, height - 1));
            list.Add(new Point(width - 5, height - 0));
            //左下
            list.Add(new Point(5, height - 0));
            list.Add(new Point(5, height - 1));
            list.Add(new Point(3, height - 1));
            list.Add(new Point(3, height - 2));
            list.Add(new Point(2, height - 2));
            list.Add(new Point(2, height - 3));
            list.Add(new Point(1, height - 3));
            list.Add(new Point(1, height - 5));
            list.Add(new Point(0, height - 5));

            Point[] points = list.ToArray();

            GraphicsPath shape = new GraphicsPath();
            shape.AddPolygon(points);

            //将窗体的显示区域设为GraphicsPath的实例 
            form.Region = new System.Drawing.Region(shape);
        }
    }

}
