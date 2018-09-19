using CIT.Client.Docking;
using CIT.Client.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(Form))]
	public class BaseForm : DockContent
	{
		private enum ClassStyle
		{
			CS_DropSHADOW = 0x20000
		}

		private delegate void WorkThreadExceptionHandler(Exception ex);

		public delegate void WorkThreadExceptionEventHanlder(Exception ex);

		private delegate void MyDelegate(Control control, int alpha, bool isShowLoadingImage);

		private EnumControlState _MinBoxState;

		private EnumControlState _MaxBoxState;

		private EnumControlState _CloseBoxState;

		private int _CornerRadius = 3;

		private int _CaptionHeight = 27;

		private Font _CaptionFont = SystemFonts.CaptionFont;

		private Color _CaptionColor = Color.Black;

		private int _BorderWidth = 1;

		private bool _ResizeEnable = true;

		private Size _ControlBoxSize = new Size(32, 18);

		private Point _Offset = new Point(3, 0);

		private Size _LogoSize = new Size(26, 26);

		private Padding _Padding = new Padding(2, 1, 2, 2);

		private Image _CapitionLogo;

		private bool _inPosChanged;

		internal FormControlBoxRender ControlBoxRender;

		private IContainer components = null;

		private Panel waitingBox;

		public static string[] iWaittingMessage = new string[23]
		{
			"请稍等......",
			"亲，我们正努力的处理，请稍等... ",
			"The request is being processed,please wait...",
			"有时候，等待也是一种幸福...",
			"您的指令已收到，正在非常努力的执行...",
			"请稍等，让我来见证那奇迹的诞生...",
			"有一种等待，叫做望穿秋水...",
			"生命是一个奋斗的过程，也是等待的过程...",
			"有一种幸福，叫做等待...",
			"等待，本身也是一种勇气！",
			"星云大师：在等待的日子里，刻苦读书，谦卑做人，养得深根，日后才能枝叶茂盛！",
			"有些人注定是等待别人的，有些人是注定被人等候的。",
			"听说雪会来，于是，我等待，一场倾城的飞扬。",
			"缘分是需要需要耐心等待的！要相信，在遇见Ta之前所经历的一切都是为等待",
			"你一定要等，不要失望，不要犹疑。这么大的世界，这么长的人生，总有一个人让你想温柔的对待。",
			"生活是一场漫长的旅行，不要浪费时间，去等待那些不愿与你携手同行的人。",
			"人生只有走出来的美丽，没有等出来的辉煌。",
			"其实，我不是一定要等你，只是等上了，就等不了别人了。——《朝露若颜》",
			"只要我们能梦想的，我们就能实现。",
			"驾驭生活，不要被生活所驾驭。",
			"不为失败找理由，要为成功找方法。",
			"人生的烦恼，多在于知道的太多，而做的太少。",
			"你是爱，是暖，是希望，你是人间的四月天！"
		};

		private TXPanel waitingBoxInnerPanel;

		private Label waitingBoxLab;

		private bool _IsWaitingBoxCreated = false;

		private IButtonControl _btnAcceptOfKeyboard;

		private IButtonControl _btnCancelOfKeyboard;

		private bool _isOnWaiting = false;

		private PictureBox _waitPicBox;

		private int TimeOut = 30;

		public WorkThreadExceptionEventHanlder OnWorkThreadException;

		private OpaqueCommand cmd = new OpaqueCommand();

		private EnumControlState MinBoxState
		{
			get
			{
				return _MinBoxState;
			}
			set
			{
				_MinBoxState = value;
			}
		}

		private EnumControlState MaxBoxState
		{
			get
			{
				return _MaxBoxState;
			}
			set
			{
				_MaxBoxState = value;
			}
		}

		private EnumControlState CloseBoxState
		{
			get
			{
				return _CloseBoxState;
			}
			set
			{
				_CloseBoxState = value;
			}
		}

		[Category("TXProperties")]
		[Description("标题栏的Logo")]
		public Image CapitionLogo
		{
			get
			{
				return _CapitionLogo;
			}
			set
			{
				_CapitionLogo = value;
				Invalidate(new Rectangle(0, 0, base.Width, CaptionHeight));
			}
		}

		[Description("图标大小")]
		[Category("TXProperties")]
		[DefaultValue(typeof(Size), "26,26")]
		public Size LogoSize
		{
			get
			{
				return _LogoSize;
			}
			set
			{
				_LogoSize = value;
				Invalidate(LogoRect);
			}
		}

		[DefaultValue(3)]
		[Description("窗体圆角值")]
		[Category("TXProperties")]
		public int CornerRadius
		{
			get
			{
				return _CornerRadius;
			}
			set
			{
				_CornerRadius = ((value > 0) ? value : 0);
				Invalidate();
			}
		}

		[Description("是否允许客户调整窗体大小")]
		[Category("TXProperties")]
		[DefaultValue(true)]
		public bool ResizeEnable
		{
			get
			{
				return _ResizeEnable;
			}
			set
			{
				_ResizeEnable = value;
			}
		}

		[Description("窗口标题高度，为0则为无标题栏窗体")]
		[Category("TXProperties")]
		[DefaultValue(25)]
		public int CaptionHeight
		{
			get
			{
				return _CaptionHeight;
			}
			set
			{
				if (value == 0)
				{
					_CaptionHeight = 0;
					base.ControlBox = false;
				}
				else
				{
					_CaptionHeight = ((value > _BorderWidth) ? value : _BorderWidth);
				}
				Invalidate();
			}
		}

		[Description("窗口标题字体")]
		[Category("TXProperties")]
		[DefaultValue(typeof(Font), "CaptionFont")]
		public Font CaptionFont
		{
			get
			{
				return _CaptionFont;
			}
			set
			{
				if (value == null)
				{
					_CaptionFont = new Font("微软雅黑", 18f);
				}
				else
				{
					_CaptionFont = value;
				}
				Invalidate(new Rectangle(0, 0, base.Width, CaptionHeight));
			}
		}

		[Description("窗口标题字体颜色")]
		[DefaultValue(typeof(Color), "White")]
		[Category("TXProperties")]
		public Color CaptionColor
		{
			get
			{
				return _CaptionColor;
			}
			set
			{
				_CaptionColor = value;
				Invalidate(new Rectangle(0, 0, base.Width, CaptionHeight));
			}
		}

		[DefaultValue(typeof(Size), "32, 18")]
		[Description("窗体控制按钮大小")]
		[Category("TXProperties")]
		public Size ControlBoxSize
		{
			get
			{
				return _ControlBoxSize;
			}
			set
			{
				_ControlBoxSize = value;
				Invalidate(new Rectangle(0, 0, base.Width, CaptionHeight));
			}
		}

		[Description("窗体标题栏内容与边框的偏移量")]
		[DefaultValue(typeof(Point), "8,0")]
		[Category("TXProperties")]
		public Point Offset
		{
			get
			{
				return _Offset;
			}
			set
			{
				_Offset = value;
				Invalidate(new Rectangle(0, 0, base.Width, CaptionHeight));
			}
		}

		[DefaultValue(3)]
		[Category("TXProperties")]
		[Description("边框宽度")]
		public int BorderWidth
		{
			get
			{
				return _BorderWidth;
			}
			set
			{
				_BorderWidth = ((value <= 1) ? 1 : value);
			}
		}

		[DefaultValue(typeof(Padding), "0")]
		[Category("TXProperties")]
		public new Padding Padding
		{
			get
			{
				return _Padding;
			}
			set
			{
				_Padding = value;
				base.Padding = new Padding(_BorderWidth + _Padding.Left, _CaptionHeight + _Padding.Top, _BorderWidth + _Padding.Right, _BorderWidth + _Padding.Bottom);
				Invalidate();
			}
		}

		[Category("TXProperties")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				Invalidate(new Rectangle(0, 0, base.Width, _CaptionHeight + 1));
			}
		}

		protected Rectangle CaptionRect => new Rectangle(0, 0, base.Width - Offset.X, CaptionHeight);

		protected Rectangle WorkRectangle => new Rectangle(Padding.Left, CaptionHeight + Padding.Top, base.Width - Padding.Left - Padding.Right, base.Height - CaptionHeight - Padding.Top - Padding.Bottom);

		protected override Padding DefaultPadding => new Padding(_BorderWidth, _CaptionHeight, _BorderWidth, _BorderWidth);

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				if (!base.DesignMode)
				{
					createParams.Style |= 262144;
					if (base.ControlBox)
					{
						createParams.Style |= 524288;
					}
					if (base.MinimizeBox)
					{
						createParams.Style |= 131072;
					}
					if (!base.MaximizeBox)
					{
						createParams.Style &= -65537;
					}
					if (_inPosChanged)
					{
						createParams.Style &= -786433;
						createParams.ExStyle &= -258;
					}
				}
				return createParams;
			}
		}

		public string WaintingBoxMessage
		{
			set
			{
				Invoke(new Action<string>(SetWaitingMessage), value);
			}
		}

		internal Exception AscException
		{
			get;
			set;
		}

		protected virtual Rectangle LogoRect
		{
			get
			{
				Rectangle result = default(Rectangle);
				if (base.ShowIcon && CapitionLogo != null)
				{
					int width = _LogoSize.Width;
					int height = _LogoSize.Height;
					result = new Rectangle(_Offset.X, _CaptionHeight / 2 - height / 2 + 1, width, height - 1);
				}
				return result;
			}
		}

		protected Rectangle CloseBoxRect
		{
			get
			{
				if (base.ControlBox)
				{
					return new Rectangle(base.Width - 1 - _ControlBoxSize.Width, 0, _ControlBoxSize.Width, _ControlBoxSize.Height);
				}
				return Rectangle.Empty;
			}
		}

		protected Rectangle MaximizeBoxRect
		{
			get
			{
				if (base.ControlBox && base.MaximizeBox)
				{
					return new Rectangle(base.Width - 1 - _ControlBoxSize.Width - CloseBoxRect.Width, 0, _ControlBoxSize.Width, _ControlBoxSize.Height);
				}
				return Rectangle.Empty;
			}
		}

		protected Rectangle MinimizeBoxRect
		{
			get
			{
				if (base.ControlBox && base.MinimizeBox)
				{
					return new Rectangle(base.Width - 1 - _ControlBoxSize.Width - CloseBoxRect.Width - MaximizeBoxRect.Width, 0, _ControlBoxSize.Width, _ControlBoxSize.Height);
				}
				return Rectangle.Empty;
			}
		}

		private void InitializeControlBoxInfo()
		{
			_MinBoxState = EnumControlState.Default;
			_MaxBoxState = EnumControlState.Default;
			_CloseBoxState = EnumControlState.Default;
			base.FormBorderStyle = FormBorderStyle.None;
		}

		protected virtual void ProcessMouseMove(Point p)
		{
			CloseBoxState = EnumControlState.Default;
			MaxBoxState = EnumControlState.Default;
			MinBoxState = EnumControlState.Default;
			if (CloseBoxRect.Contains(p))
			{
				CloseBoxState = EnumControlState.HeightLight;
			}
			if (MinimizeBoxRect.Contains(p))
			{
				MinBoxState = EnumControlState.HeightLight;
			}
			if (MaximizeBoxRect.Contains(p))
			{
				MaxBoxState = EnumControlState.HeightLight;
			}
			Invalidate(CaptionRect);
		}

		protected virtual void ProcessMouseDown(Point p)
		{
			Rectangle closeBoxRect = CloseBoxRect;
			Rectangle maximizeBoxRect = MaximizeBoxRect;
			Rectangle minimizeBoxRect = MinimizeBoxRect;
			if (!closeBoxRect.IsEmpty && closeBoxRect.Contains(p))
			{
				CloseBoxState = EnumControlState.Focused;
			}
			if (!maximizeBoxRect.IsEmpty && maximizeBoxRect.Contains(p))
			{
				MaxBoxState = EnumControlState.Focused;
			}
			if (!minimizeBoxRect.IsEmpty && minimizeBoxRect.Contains(p))
			{
				MinBoxState = EnumControlState.Focused;
			}
			Invalidate(CaptionRect);
		}

		protected virtual void ProcessMouseUp(Point p)
		{
			Rectangle closeBoxRect = CloseBoxRect;
			Rectangle maximizeBoxRect = MaximizeBoxRect;
			Rectangle minimizeBoxRect = MinimizeBoxRect;
			if (!closeBoxRect.IsEmpty && closeBoxRect.Contains(p))
			{
				Close();
				CloseBoxState = EnumControlState.Default;
			}
			if (!maximizeBoxRect.IsEmpty && maximizeBoxRect.Contains(p))
			{
				FormWindowState formWindowState = FormWindowState.Normal;
				switch (base.WindowState)
				{
				case FormWindowState.Maximized:
					formWindowState = FormWindowState.Normal;
					break;
				default:
					formWindowState = FormWindowState.Maximized;
					break;
				}
				base.WindowState = formWindowState;
				MaxBoxState = EnumControlState.Default;
			}
			if (!minimizeBoxRect.IsEmpty && minimizeBoxRect.Contains(p))
			{
				base.WindowState = FormWindowState.Minimized;
				MinBoxState = EnumControlState.Default;
			}
			Invalidate(CaptionRect);
		}

		protected virtual void ProcessMouseLeave(Point p)
		{
			Rectangle closeBoxRect = CloseBoxRect;
			Rectangle maximizeBoxRect = MaximizeBoxRect;
			Rectangle minimizeBoxRect = MinimizeBoxRect;
			if (!closeBoxRect.IsEmpty)
			{
				CloseBoxState = EnumControlState.Default;
			}
			if (!maximizeBoxRect.IsEmpty)
			{
				MaxBoxState = EnumControlState.Default;
			}
			if (!minimizeBoxRect.IsEmpty)
			{
				MinBoxState = EnumControlState.Default;
			}
			Invalidate(CaptionRect);
		}

		protected virtual void WmNcHitTest(ref Message m)
		{
			int value = m.LParam.ToInt32();
			Point p = new Point(Win32.LOWORD(value), Win32.HIWORD(value));
			p = PointToClient(p);
			if (LogoRect.Contains(p))
			{
				m.Result = new IntPtr(3);
			}
			else
			{
				if (_ResizeEnable && _CaptionHeight > 0)
				{
					int num = 4;
					if (p.X <= num && p.Y <= num)
					{
						m.Result = new IntPtr(13);
						return;
					}
					if (p.X >= base.Width - num && p.Y <= num)
					{
						m.Result = new IntPtr(14);
						return;
					}
					if (p.X >= base.Width - num && p.Y >= base.Height - num)
					{
						m.Result = new IntPtr(17);
						return;
					}
					if (p.X <= num && p.Y >= base.Height - num)
					{
						m.Result = new IntPtr(16);
						return;
					}
					if (p.Y <= num)
					{
						m.Result = new IntPtr(12);
						return;
					}
					if (p.Y >= base.Height - num)
					{
						m.Result = new IntPtr(15);
						return;
					}
					if (p.X <= num)
					{
						m.Result = new IntPtr(10);
						return;
					}
					if (p.X >= base.Width - num)
					{
						m.Result = new IntPtr(11);
						return;
					}
				}
				if (p.Y <= _CaptionHeight)
				{
					if (!CloseBoxRect.Contains(p) && !MaximizeBoxRect.Contains(p) && !MinimizeBoxRect.Contains(p))
					{
						m.Result = new IntPtr(2);
					}
					else
					{
						m.Result = new IntPtr(1);
					}
				}
				else if (_CaptionHeight > 0)
				{
					m.Result = new IntPtr(2);
				}
			}
		}

		private void WmMinMaxInfo(ref Message m)
		{
			MINMAXINFO mINMAXINFO = (MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));
			if (MaximumSize != Size.Empty)
			{
				mINMAXINFO.maxTrackSize = base.MaximumSize;
			}
			else
			{
				Rectangle workingArea = Screen.GetWorkingArea(this);
				mINMAXINFO.maxPosition = new Point(workingArea.X - _BorderWidth, workingArea.Y);
				mINMAXINFO.maxTrackSize = new Size(workingArea.Width + _BorderWidth * 2, workingArea.Height + _BorderWidth);
			}
			if (MinimumSize != Size.Empty)
			{
				mINMAXINFO.minTrackSize = base.MinimumSize;
			}
			else
			{
				mINMAXINFO.minTrackSize = new Size(CloseBoxRect.Width + MinimizeBoxRect.Width + MaximizeBoxRect.Width + _Offset.X * 2 + _LogoSize.Width, _CaptionHeight);
			}
			Marshal.StructureToPtr((object)mINMAXINFO, m.LParam, fDeleteOld: false);
		}

		public BaseForm()
		{
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UseTextForAccessibility, value: true);
			UpdateStyles();
			base.FormBorderStyle = FormBorderStyle.None;
			base.Padding = DefaultPadding;
			base.StartPosition = FormStartPosition.CenterParent;
			base.Size = new Size(500, 350);
			ResetRegion();
			base.Icon = CIT.Client.Properties.Resources.logo32;
			_CapitionLogo = CIT.Client.Properties.Resources.naruto;
			InitializeControlBoxInfo();
			TXToolStripRenderer tXToolStripRenderer = (TXToolStripRenderer)(ToolStripManager.Renderer = new TXToolStripRenderer());
			base.KeyPreview = true;
			ControlBoxRender = new FormControlBoxRender();
			UpdateStyles();
		}

		protected override void OnDeactivate(EventArgs e)
		{
			base.OnDeactivate(e);
			Refresh();
		}

		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
			Refresh();
		}

		protected override void OnCreateControl()
		{
			ResetRegion();
			base.OnCreateControl();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (base.Created)
			{
				ResetRegion();
				Invalidate();
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			ProcessMouseMove(e.Location);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			ProcessMouseDown(e.Location);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			ProcessMouseUp(e.Location);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			ProcessMouseLeave(PointToClient(Control.MousePosition));
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			if (e.KeyChar == '\u001b')
			{
				Close();
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			Graphics graphics = e.Graphics;
			GDIHelper.InitializeGraphics(graphics);
			DrawFormBackGround(graphics);
			DrawCaption(graphics);
			DrawFormBorder(graphics);
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 131:
			case 133:
				break;
			case 132:
				WmNcHitTest(ref m);
				break;
			case 71:
				_inPosChanged = true;
				base.WndProc(ref m);
				_inPosChanged = false;
				break;
			case 36:
				WmMinMaxInfo(ref m);
				break;
			default:
				base.WndProc(ref m);
				break;
			}
		}

		private void ResetRegion()
		{
			if (base.Region != null)
			{
				base.Region.Dispose();
			}
			int hRgn = Win32.CreateRoundRectRgn(0, 0, base.Size.Width, base.Size.Height, _CornerRadius + 1, _CornerRadius);
			Win32.SetWindowRgn(base.Handle, hRgn, bRedraw: true);
		}

		private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
		{
			Rectangle rect2 = new Rectangle(rect.Location, new Size(radius, radius));
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(rect2, 180f, 90f);
			rect2.X = rect.Right - radius;
			graphicsPath.AddArc(rect2, 270f, 90f);
			rect2.Y = rect.Bottom - radius;
			graphicsPath.AddArc(rect2, 0f, 90f);
			rect2.X = rect.Left;
			graphicsPath.AddArc(rect2, 90f, 90f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		private void InitializeComponent()
		{
			SuspendLayout();
			base.ClientSize = new System.Drawing.Size(292, 273);
			Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "BaseForm";
			ResumeLayout(performLayout: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void Waiting(MethodInvoker method, string message)
		{
			if (!_isOnWaiting)
			{
				_isOnWaiting = true;
				CreateWaitingBox();
				Random random = new Random(DateTime.Now.Millisecond);
				message = (string.IsNullOrEmpty(message) ? iWaittingMessage[random.Next(0, iWaittingMessage.Length)] : message);
				SetWaitingMessage(message);
				waitingBox.Visible = true;
				waitingBox.BringToFront();
				_btnAcceptOfKeyboard = base.AcceptButton;
				_btnCancelOfKeyboard = base.CancelButton;
				base.AcceptButton = null;
				base.CancelButton = null;
				IAsyncResult asyncResult = method.BeginInvoke(WorkComplete, method);
			}
		}

		public void Waiting(MethodInvoker method, string message, int timeout)
		{
			if (!_isOnWaiting)
			{
				_isOnWaiting = true;
				CreateWaitingBox();
				Random random = new Random(DateTime.Now.Millisecond);
				message = (string.IsNullOrEmpty(message) ? iWaittingMessage[random.Next(0, iWaittingMessage.Length)] : message);
				SetWaitingMessage(message);
				waitingBox.Visible = true;
				waitingBox.BringToFront();
				_btnAcceptOfKeyboard = base.AcceptButton;
				_btnCancelOfKeyboard = base.CancelButton;
				base.AcceptButton = null;
				base.CancelButton = null;
				IAsyncResult asyncResult = method.BeginInvoke(WorkComplete, method);
			}
		}

		public void Waiting(MethodInvoker method)
		{
			Waiting(method, string.Empty);
		}

		private void WorkComplete(IAsyncResult results)
		{
			if (waitingBox.Visible && base.IsHandleCreated)
			{
				if (waitingBox.InvokeRequired)
				{
					Invoke(new Action<IAsyncResult>(WorkComplete), results);
				}
				else
				{
					try
					{
						((MethodInvoker)results.AsyncState).EndInvoke(results);
					}
					catch (Exception ex)
					{
						new WorkThreadExceptionHandler(ThrowException).BeginInvoke(ex, null, null);
					}
					finally
					{
						Invoke((MethodInvoker)delegate
						{
							waitingBox.Visible = false;
							base.AcceptButton = _btnAcceptOfKeyboard;
							base.CancelButton = _btnCancelOfKeyboard;
							_isOnWaiting = false;
						});
					}
				}
			}
		}

		private void ThrowException(Exception ex)
		{
			if (OnWorkThreadException != null)
			{
				OnWorkThreadException(ex);
			}
		}

		private void CreateWaitingBox()
		{
			if (!_IsWaitingBoxCreated)
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
				waitingBoxInnerPanel.Controls.Add(waitingBoxLab);
				PictureBox pictureBox = new PictureBox();
				pictureBox.Dock = DockStyle.Left;
				pictureBox.Size = new Size(72, 70);
				pictureBox.Image = CIT.Client.Properties.Resources.loading;
				pictureBox.Margin = new Padding(3, 3, 20, 3);
				pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
				_waitPicBox = pictureBox;
				waitingBoxInnerPanel.Controls.Add(pictureBox);
				waitingBox.Controls.Add(waitingBoxInnerPanel);
				waitingBox.BringToFront();
				if (!base.Controls.Contains(waitingBox))
				{
					base.Controls.Add(waitingBox);
				}
				waitingBox.Show();
				_IsWaitingBoxCreated = true;
			}
			Rectangle workRectangle = WorkRectangle;
			waitingBox.Width = workRectangle.Width;
			waitingBox.Height = workRectangle.Height;
			waitingBox.Location = new Point(workRectangle.X, workRectangle.Y);
			_waitPicBox.Image = CIT.Client.Properties.Resources.loading;
			waitingBox.BackgroundImage = CreateBacgroundImage();
			waitingBox.BackgroundImageLayout = ImageLayout.Stretch;
		}

		private void SetWaitingMessage(string message)
		{
			message = " " + message.Trim();
			if (waitingBoxLab != null && waitingBoxInnerPanel != null)
			{
				using (Graphics graphics = CreateGraphics())
				{
					int num = Convert.ToInt32(graphics.MeasureString(message, waitingBoxLab.Font).Width);
					num = ((num >= 200) ? num : 200);
					num = ((base.Width - 100 >= num) ? num : (base.Width - 100));
					waitingBoxInnerPanel.Width = num + 60;
					waitingBoxInnerPanel.Location = new Point(waitingBox.Bounds.X + waitingBox.Width / 2 - waitingBoxInnerPanel.Width / 2, waitingBox.Bounds.Y + waitingBox.Height / 2 - waitingBoxInnerPanel.Height);
				}
				waitingBoxLab.Text = message;
			}
		}

		private Bitmap CreateBacgroundImage()
		{
			Rectangle workRectangle = WorkRectangle;
			int width = workRectangle.Width;
			int height = workRectangle.Height;
			Point point = new Point(base.Location.X + Padding.Left, base.Location.Y + CaptionHeight + Padding.Top);
			Point upperLeftSource = (base.Parent == null) ? point : PointToScreen(point);
			Bitmap bitmap = new Bitmap(width, height);
			try
			{
				Bitmap bitmap2 = new Bitmap(width, height);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.CopyFromScreen(upperLeftSource, new Point(0, 0), new Size(width, height));
				}
				using (Graphics graphics = Graphics.FromImage(bitmap2))
				{
					GDIHelper.DrawImage(graphics, new Rectangle(0, 0, width, height), bitmap, 0.36f);
				}
				return bitmap2;
			}
			catch
			{
				return null;
			}
			finally
			{
				bitmap.Dispose();
			}
		}

		private void DrawFormBackGround(Graphics g)
		{
			Rectangle rect = new Rectangle(0, 0, base.Width - 2, base.Height - 2);
			if (SkinManager.CurrentSkin.BackGroundImageEnable)
			{
				GDIHelper.DrawImage(g, rect, SkinManager.CurrentSkin.BackGroundImage, SkinManager.CurrentSkin.BackGroundImageOpacity);
			}
			else
			{
				GDIHelper.FillRectangle(g, rect, SkinManager.CurrentSkin.ThemeColor);
			}
		}

		public static void DrawFromAlphaMainPart(Form form, Graphics g)
		{
			Color[] array = new Color[6]
			{
				Color.FromArgb(5, Color.White),
				Color.FromArgb(30, Color.White),
				Color.FromArgb(150, Color.White),
				Color.FromArgb(180, Color.White),
				Color.FromArgb(30, Color.White),
				Color.FromArgb(5, Color.White)
			};
			float[] positions = new float[6]
			{
				0f,
				0.05f,
				0.15f,
				0.85f,
				0.99f,
				1f
			};
			ColorBlend colorBlend = new ColorBlend(6);
			colorBlend.Colors = array;
			colorBlend.Positions = positions;
			RectangleF rect = new RectangleF(0f, 0f, (float)form.Width, (float)form.Height);
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, array[0], array[5], LinearGradientMode.Vertical))
			{
				linearGradientBrush.InterpolationColors = colorBlend;
				g.FillRectangle(linearGradientBrush, rect);
			}
		}

		private void DrawFormBorder(Graphics g)
		{
			if (base.WindowState != FormWindowState.Maximized)
			{
				Rectangle rect = new Rectangle(0, 0, base.Width - 2, base.Height - 2);
				RoundRectangle roundRectangle = new RoundRectangle(rect, new CornerRadius(CornerRadius));
				GDIHelper.DrawPathBorder(g, roundRectangle);
				using (GraphicsPath path = (_CornerRadius == 0) ? roundRectangle.ToGraphicsBezierPath() : roundRectangle.ToGraphicsArcPath())
				{
					using (Pen pen = new Pen(SkinManager.CurrentSkin.BorderColor))
					{
						g.DrawPath(pen, path);
					}
				}
			}
		}

		protected virtual void DrawCaption(Graphics g)
		{
			if (_CaptionHeight > 0)
			{
				DrawCaptionBackGround(g);
				DrawCaptionLogo(g);
				DrawCaptionText(g);
				DrawControlBox(g);
			}
		}

		protected void DrawCaptionLogo(Graphics g)
		{
			if (base.ShowIcon && CapitionLogo != null)
			{
				GDIHelper.DrawImage(g, LogoRect, _CapitionLogo, LogoSize);
			}
		}

		private void DrawCaptionText(Graphics g)
		{
			TextRenderer.DrawText(bounds: new Rectangle(0, 0, base.Width, _CaptionHeight), dc: g, text: Text, font: _CaptionFont, foreColor: SkinManager.CurrentSkin.CaptionFontColor, flags: TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.WordEllipsis);
		}

		private void DrawCaptionBackGround(Graphics g)
		{
			Rectangle rect = new Rectangle(0, 0, base.Width, CaptionHeight);
			Rectangle rect2 = new Rectangle(rect.Left, rect.Bottom, rect.Width, 1);
			g.SetClip(rect2, CombineMode.Exclude);
			GDIHelper.FillRectangle(g, rect, SkinManager.CurrentSkin.CaptionColor);
			g.ResetClip();
		}

		protected virtual void DrawControlBox(Graphics g)
		{
			Rectangle closeBoxRect = CloseBoxRect;
			Rectangle maximizeBoxRect = MaximizeBoxRect;
			Rectangle minimizeBoxRect = MinimizeBoxRect;
			DrawCloseBox(g, closeBoxRect, maximizeBoxRect, minimizeBoxRect);
			DrawMaxBox(g, maximizeBoxRect, minimizeBoxRect);
			DrawMinBox(g, minimizeBoxRect);
		}

		private void DrawCloseBox(Graphics g, Rectangle closeRect, Rectangle rectMax, Rectangle rectMin)
		{
			if (closeRect != Rectangle.Empty)
			{
				ControlBoxRender.DrawCloseBox(g, closeRect, _CloseBoxState, CornerRadius);
				using (Pen pen = new Pen(SkinManager.CurrentSkin.ControlBoxFlagColor, 2f))
				{
					PointF pointF = new PointF((float)closeRect.X + (float)closeRect.Width / 2f, (float)closeRect.Y + (float)closeRect.Height / 2f);
					g.DrawLine(pen, pointF.X - 5f, pointF.Y - 4f, pointF.X + 3f, pointF.Y + 4f);
					g.DrawLine(pen, pointF.X - 5f, pointF.Y + 4f, pointF.X + 3f, pointF.Y - 4f);
				}
			}
		}

		private void DrawMaxBox(Graphics g, Rectangle maxRect, Rectangle rectMin)
		{
			if (maxRect != Rectangle.Empty)
			{
				ControlBoxRender.DrawControlBox(g, maxRect, _MaxBoxState);
				using (Brush brush = new SolidBrush(SkinManager.CurrentSkin.ControlBoxFlagColor))
				{
					g.FillPath(brush, ControlBoxRender.CreateMaximizeFlafPath(maxRect, (base.WindowState == FormWindowState.Maximized) ? true : false));
				}
			}
		}

		private void DrawMinBox(Graphics g, Rectangle minRect)
		{
			if (minRect != Rectangle.Empty)
			{
				ControlBoxRender.DrawControlBox(g, minRect, _MinBoxState);
				using (Brush brush = new SolidBrush(SkinManager.CurrentSkin.ControlBoxFlagColor))
				{
					g.FillPath(brush, ControlBoxRender.CreateMinimizeFlagPath(minRect));
				}
			}
		}

		public void WaitCtr(Control ctr, MethodInvoker meth)
		{
			cmd.HideOpaqueLayer();
			cmd.ShowOpaqueLayer(ctr, 125, isShowLoadingImage: true, meth);
		}

		public void Show(Control ctr, int count)
		{
			cmd.ShowOpaqueLayer(ctr, count, isShowLoadingImage: true, null);
		}

		public void Show(Control ctr, int count, bool IsShow, MethodInvoker meth)
		{
			cmd.ShowOpaqueLayer(ctr, count, IsShow, meth);
		}

		public new void Hide()
		{
			cmd.HideOpaqueLayer();
		}
	}
}
