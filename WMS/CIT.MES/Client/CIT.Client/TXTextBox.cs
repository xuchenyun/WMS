using CIT.Client.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(TextBox))]
	public class TXTextBox : UserControl
	{
		public delegate void ImageButtonClickEventHandler(object sender, EventArgs e);

		private int _CornerRadius = 1;

		private TextBox _TextBox;

		private Color _BorderColor = SkinManager.CurrentSkin.BorderColor;

		private Color _HeightLightBolorColor = SkinManager.CurrentSkin.HeightLightControlColor.First;

		private ToolStripItemAlignment _ImageAlignment = ToolStripItemAlignment.Left;

		private Size _Offset = new Size(2, 1);

		private static readonly object _ImageButton = new object();

		private PictureBox _pictureBox;

		private string _Text = string.Empty;

		private EnumControlState _ControlState = EnumControlState.Default;

		private bool _Required = false;

		public new EventHandler OnTextChanged;

		public KeyPressEventHandler OnKeyPressed;

		public KeyEventHandler OnKeyUped;

		public KeyEventHandler OnKeyDowned;

		private IContainer components = null;

		[Description("圆角的半径值")]
		[Browsable(true)]
		[Category("TXProperties")]
		[DefaultValue(1)]
		public int CornerRadius
		{
			get
			{
				return _CornerRadius;
			}
			set
			{
				_CornerRadius = value;
				if (value > _Offset.Width * 3)
				{
					Offset = new Size(value / 3, Offset.Height);
				}
				else
				{
					Invalidate();
				}
			}
		}

		[Browsable(false)]
		public new BorderStyle BorderStyle
		{
			get
			{
				return BorderStyle.None;
			}
		}

		[Browsable(true)]
		[Category("TXProperties")]
		[Description("边框颜色")]
		public Color BorderColor
		{
			get
			{
				return _BorderColor;
			}
			set
			{
				_BorderColor = value;
				Invalidate();
			}
		}

		[Category("TXProperties")]
		[Browsable(true)]
		[Description("必填")]
		public bool Required
		{
			get
			{
				return _Required;
			}
			set
			{
				_Required = value;
				if (value)
				{
					Image = (string.IsNullOrEmpty(Text) ? Resources.requried : Resources.check);
					ImageAlignment = ToolStripItemAlignment.Right;
					ImageSize = new Size(14, 14);
					OnImageButtonClick += TXTextBox_OnImageButtonClick;
				}
				else
				{
					OnImageButtonClick -= TXTextBox_OnImageButtonClick;
				}
				Invalidate();
			}
		}

		[Description("边框的高亮色")]
		[Category("TXProperties")]
		[Browsable(true)]
		public Color HeightLightBolorColor
		{
			get
			{
				return _HeightLightBolorColor;
			}
			set
			{
				_HeightLightBolorColor = value;
			}
		}

		[Description("图标")]
		[Category("TXProperties")]
		[Browsable(true)]
		public Image Image
		{
			get
			{
				return _pictureBox.Image;
			}
			set
			{
				_pictureBox.Image = value;
				if (value != null)
				{
					_pictureBox.Size = new Size(16, 16);
				}
				ResetControlSize();
				Invalidate();
			}
		}

		[Category("TXProperties")]
		[DefaultValue(typeof(Size), "18,18")]
		[Browsable(true)]
		[Description("图标的大小")]
		public Size ImageSize
		{
			get
			{
				return _pictureBox.Size;
			}
			set
			{
				_pictureBox.Size = value;
				Invalidate();
			}
		}

		[Description("图标的安放位置")]
		[Category("TXProperties")]
		[DefaultValue(typeof(ToolStripItemAlignment), "Left")]
		[Browsable(true)]
		public ToolStripItemAlignment ImageAlignment
		{
			get
			{
				return _ImageAlignment;
			}
			set
			{
				_ImageAlignment = value;
				ResetControlSize();
				Invalidate();
			}
		}

		[Description("控件内部的偏移量")]
		[DefaultValue(typeof(Size), "2,1")]
		[Browsable(true)]
		[Category("TXProperties")]
		public Size Offset
		{
			get
			{
				return _Offset;
			}
			set
			{
				_Offset = value;
				ResetControlSize();
				Invalidate();
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(true)]
		[Category("TXProperties")]
		public new Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
				_TextBox.Font = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Category("TXProperties")]
		[Browsable(true)]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
				_TextBox.ForeColor = value;
			}
		}

		[Category("TXProperties")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public new RightToLeft RightToLeft
		{
			get
			{
				return base.RightToLeft;
			}
			set
			{
				base.RightToLeft = value;
				_TextBox.RightToLeft = value;
			}
		}

		[Category("TXProperties")]
		[Browsable(true)]
		[Description("这个，你懂的！")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				base.Dock = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[DefaultValue("")]
		[Browsable(true)]
		[Category("TXProperties")]
		public new string Text
		{
			get
			{
				return _TextBox.Text;
			}
			set
			{
				_TextBox.Text = ((string.IsNullOrEmpty(value) || value.Contains("txTextBox")) ? string.Empty : value);
				if (Required)
				{
					Image = (string.IsNullOrEmpty(value) ? Resources.requried : Resources.check);
				}
			}
		}

		[Category("TXProperties")]
		[DefaultValue(32767)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(true)]
		[Description("最大输入字符数")]
		public int MaxLength
		{
			get
			{
				return _TextBox.MaxLength;
			}
			set
			{
				_TextBox.MaxLength = ((value > 0) ? value : 0);
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(true)]
		[DefaultValue(false)]
		[Description("是否支持多行输入")]
		[Category("TXProperties")]
		public bool Multiline
		{
			get
			{
				return _TextBox.Multiline;
			}
			set
			{
				_TextBox.Multiline = value;
				if (value)
				{
					base.Size = new Size(250, 45);
				}
				else
				{
					base.Size = new Size(180, 25);
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("密码字符")]
		[Category("TXProperties")]
		[DefaultValue("")]
		[Browsable(true)]
		public char PasswordChar
		{
			get
			{
				return _TextBox.PasswordChar;
			}
			set
			{
				_TextBox.PasswordChar = value;
			}
		}

		[Description("是否只读")]
		[DefaultValue(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(true)]
		[Category("TXProperties")]
		public bool ReadOnly
		{
			get
			{
				return _TextBox.ReadOnly;
			}
			set
			{
				_TextBox.ReadOnly = value;
				Invalidate();
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(true)]
		[DefaultValue(typeof(ScrollBars), "None")]
		[Description("多行输入时的滚动条显示")]
		[Category("TXProperties")]
		public ScrollBars ScrollBars
		{
			get
			{
				return _TextBox.ScrollBars;
			}
			set
			{
				_TextBox.ScrollBars = value;
			}
		}

		[Browsable(true)]
		[Category("TXProperties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public new bool Enabled
		{
			get
			{
				return _TextBox.Enabled;
			}
			set
			{
				_TextBox.Enabled = value;
			}
		}

		[Description("当图标按钮被点击时发生")]
		[Category("TXEvents")]
		public event ImageButtonClickEventHandler OnImageButtonClick
		{
			add
			{
				base.Events.AddHandler(_ImageButton, value);
			}
			remove
			{
				base.Events.RemoveHandler(_ImageButton, value);
			}
		}

		public event EventHandler TextChange;

		public new event KeyPressEventHandler KeyPress;

		public new event KeyEventHandler KeyUp;

		public new event KeyEventHandler KeyDown;

		private void OnTextChange()
		{
			if (this.TextChange != null)
			{
				this.TextChange(this, EventArgs.Empty);
			}
		}

		private void OnKeyPress(object sender, KeyPressEventArgs e)
		{
			if (this.KeyPress != null)
			{
				this.KeyPress(sender, e);
			}
		}

		private void OnKeyUp(object sender, KeyEventArgs e)
		{
			if (this.KeyUp != null)
			{
				this.KeyUp(sender, e);
			}
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (this.KeyDown != null)
			{
				this.KeyDown(sender, e);
			}
		}

		public TXTextBox()
		{
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			UpdateStyles();
			InitializeComponent();
			base.BorderStyle = BorderStyle.None;
			base.Size = new Size(180, 22);
			_TextBox.GotFocus += _TextBox_GotFocus;
			_TextBox.LostFocus += _TextBox_LostFocus;
			_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			Text = string.Empty;
		}

		private void _TextBox_LostFocus(object sender, EventArgs e)
		{
			_ControlState = EnumControlState.Default;
			Invalidate();
		}

		private void _TextBox_GotFocus(object sender, EventArgs e)
		{
			_ControlState = EnumControlState.HeightLight;
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			DrawBorder(e.Graphics);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			ResetControlSize();
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			ResetControlSize();
			Text = ((Text == base.Name) ? string.Empty : Text);
		}

		private void _pictureBox_Click(object sender, EventArgs e)
		{
			(base.Events[_ImageButton] as ImageButtonClickEventHandler)?.Invoke(Text, e);
		}

		private void _TextBox_TextChanged(object sender, EventArgs e)
		{
			if (Required)
			{
				Image = (string.IsNullOrEmpty(Text.Trim()) ? Resources.requried : Resources.check);
			}
			if (OnTextChanged != null)
			{
				OnTextChanged(sender, e);
			}
			OnTextChange();
		}

		private void _TextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (OnKeyPressed != null)
			{
				OnKeyPressed(sender, e);
			}
			OnKeyPress(sender, e);
		}

		private void _TextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (OnKeyUped != null)
			{
				OnKeyUped(sender, e);
			}
			OnKeyUp(sender, e);
		}

		private void _TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (OnKeyDowned != null)
			{
				OnKeyDowned(sender, e);
			}
			OnKeyDown(sender, e);
		}

		private void TXTextBox_OnImageButtonClick(object sender, EventArgs e)
		{
			MessageBox.Show("亲，该项为必填哦！");
		}

		public void SelectAll()
		{
			_TextBox.SelectAll();
		}

		public new void Focus()
		{
			_TextBox.Focus();
		}

		public new void Select()
		{
			_TextBox.Select();
		}

		public void Select(int start, int length)
		{
			_TextBox.Select(start, length);
		}

		private void ResetControlSize()
		{
			if (_pictureBox.Image == null)
			{
				_pictureBox.Size = Size.Empty;
			}
			int num = base.Height / 2;
			switch (_ImageAlignment)
			{
			case ToolStripItemAlignment.Left:
				_pictureBox.Location = new Point(_Offset.Width + 1, num - ImageSize.Height / 2);
				_TextBox.Size = new Size(base.Width - _pictureBox.Right - _Offset.Width * 2 - 3, base.Height - _Offset.Height * 2 - 6);
				_TextBox.Location = new Point(_pictureBox.Width + _Offset.Width * 2 + 1, num - _TextBox.Height / 2);
				break;
			case ToolStripItemAlignment.Right:
				_pictureBox.Location = new Point(base.Width - _Offset.Width - _pictureBox.Width - 2, num - _pictureBox.Height / 2);
				_TextBox.Size = new Size(base.Width - _pictureBox.Width - _Offset.Width * 3 - 3, base.Height - _Offset.Height * 2 - 6);
				_TextBox.Location = new Point(_Offset.Width + 2, num - _TextBox.Height / 2);
				break;
			}
		}

		private void DrawBorder(Graphics g)
		{
			GDIHelper.InitializeGraphics(g);
			Rectangle rect = new Rectangle(1, 1, base.Width - 3, base.Height - 3);
			RoundRectangle roundRect = new RoundRectangle(rect, _CornerRadius);
			Color color = (!_TextBox.Enabled || _TextBox.ReadOnly) ? Color.FromArgb(215, 250, 243) : Color.White;
			_TextBox.BackColor = color;
			GDIHelper.FillPath(g, roundRect, color, color);
			GDIHelper.DrawPathBorder(g, roundRect, _BorderColor);
			if (_ControlState == EnumControlState.HeightLight)
			{
				GDIHelper.DrawPathBorder(g, roundRect, SkinManager.CurrentSkin.HeightLightControlColor.Second);
				GDIHelper.DrawPathOuterBorder(g, roundRect, SkinManager.CurrentSkin.HeightLightControlColor.First);
			}
		}

		private void InitializeComponent()
		{
			_TextBox = new System.Windows.Forms.TextBox();
			_pictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)_pictureBox).BeginInit();
			SuspendLayout();
			_TextBox.BackColor = System.Drawing.Color.White;
			_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_TextBox.Location = new System.Drawing.Point(32, 4);
			_TextBox.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
			_TextBox.Name = "_TextBox";
			_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_TextBox.Size = new System.Drawing.Size(223, 14);
			_TextBox.TabIndex = 0;
			_TextBox.TextChanged += new System.EventHandler(_TextBox_TextChanged);
			_TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(_TextBox_KeyDown);
			_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(_TextBox_KeyPress);
			_TextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(_TextBox_KeyUp);
			_pictureBox.Location = new System.Drawing.Point(6, 0);
			_pictureBox.Name = "_pictureBox";
			_pictureBox.Size = new System.Drawing.Size(20, 20);
			_pictureBox.TabIndex = 1;
			_pictureBox.TabStop = false;
			_pictureBox.Click += new System.EventHandler(_pictureBox_Click);
			BackColor = System.Drawing.Color.Transparent;
			base.Controls.Add(_pictureBox);
			base.Controls.Add(_TextBox);
			Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			ForeColor = System.Drawing.SystemColors.WindowText;
			base.Name = "TXTextBox";
			base.Padding = new System.Windows.Forms.Padding(2);
			base.Size = new System.Drawing.Size(333, 21);
			((System.ComponentModel.ISupportInitialize)_pictureBox).EndInit();
			ResumeLayout(performLayout: false);
			PerformLayout();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
