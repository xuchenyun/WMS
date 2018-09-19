using CIT.Client.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(MyOpaqueLayer))]
	internal class MyOpaqueLayer : Control
	{
		private bool _transparentBG = true;

		private int _alpha = 125;

		private Control Ctr = null;

		private Container components = new Container();

		private Label waitingBoxLab = null;

		private Panel waitingBox = null;

		private TXPanel waitingBoxInnerPanel = null;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle |= 32;
				return createParams;
			}
		}

		[Category("MyOpaqueLayer")]
		[Description("是否使用透明,默认为True")]
		public bool TransparentBG
		{
			get
			{
				return _transparentBG;
			}
			set
			{
				_transparentBG = value;
				Invalidate();
			}
		}

		[Category("MyOpaqueLayer")]
		[Description("设置透明度")]
		public int Alpha
		{
			get
			{
				return _alpha;
			}
			set
			{
				_alpha = value;
				Invalidate();
			}
		}

		internal MyOpaqueLayer()
		{
		}

		internal MyOpaqueLayer(Control ctr, int Alpha, bool IsShowLoadingImage, string msg)
		{
			Ctr = ctr;
			SetStyle(ControlStyles.Opaque, value: true);
			CreateControl();
			_alpha = Alpha;
			if (IsShowLoadingImage)
			{
				waitingBox = new Panel();
				waitingBox.BackColor = Color.FromArgb(234, 244, 252);
				waitingBoxInnerPanel = new TXPanel();
				waitingBoxInnerPanel.Width = 280;
				waitingBoxInnerPanel.Height = 80;
				waitingBoxInnerPanel.CornerRadius = 6;
				waitingBoxInnerPanel.BackBeginColor = Color.White;
				waitingBoxInnerPanel.BackEndColor = Color.White;
				waitingBoxInnerPanel.Padding = new Padding(8, 5, 5, 5);
				waitingBoxLab = new Label();
				waitingBoxLab.TextAlign = ContentAlignment.MiddleLeft;
				waitingBoxLab.AutoEllipsis = true;
				waitingBoxLab.Dock = DockStyle.Fill;
				waitingBoxLab.Text = msg;
				waitingBoxInnerPanel.Controls.Add(waitingBoxLab);
				PictureBox value = new PictureBox
				{
					Dock = DockStyle.Left,
					Size = new Size(72, 70),
					Image = Resources.loading,
					Margin = new Padding(3, 3, 20, 3),
					SizeMode = PictureBoxSizeMode.CenterImage
				};
				waitingBoxInnerPanel.Controls.Add(value);
				waitingBox.Controls.Add(waitingBoxInnerPanel);
				waitingBox.BringToFront();
				if (!base.Controls.Contains(waitingBox))
				{
					base.Controls.Add(waitingBox);
				}
				waitingBox.Height = waitingBoxInnerPanel.Height;
				using (Graphics graphics = CreateGraphics())
				{
					int num = Convert.ToInt32(graphics.MeasureString(msg, waitingBoxLab.Font).Width);
					num = ((num >= 200) ? num : 200);
					num = ((Ctr.Width - 100 >= num) ? num : (Ctr.Width - 100));
					waitingBoxInnerPanel.Width = num + 80;
					waitingBox.Width = waitingBoxInnerPanel.Width;
				}
				waitingBox.Left = (Ctr.Width - waitingBox.Width) / 2;
				waitingBox.Top = (Ctr.Height - waitingBox.Height) / 2;
				waitingBox.Show();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Pen pen;
			SolidBrush brush;
			if (_transparentBG)
			{
				Color color = Color.FromArgb(_alpha, BackColor);
				pen = new Pen(color, 0f);
				brush = new SolidBrush(color);
			}
			else
			{
				pen = new Pen(BackColor, 0f);
				brush = new SolidBrush(BackColor);
			}
			base.OnPaint(e);
			float width = 400f;
			float height = 200f;
			e.Graphics.DrawRectangle(pen, 0f, 0f, width, height);
			e.Graphics.FillRectangle(brush, 0f, 0f, width, height);
		}
	}
}
