using CIT.Client.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CIT.Client
{
	public class IMainForm : BaseForm
	{
		private EnumControlState _RibbonBtnState = EnumControlState.Default;

		private EnumControlState _SkinBtnState = EnumControlState.Default;

		private Size _RibbonButtonSize;

		private Size _SkinBoxSize;

		protected Rectangle SkinBoxRect
		{
			get
			{
				if (base.ControlBox)
				{
					return new Rectangle(base.Width - 1 - base.ControlBoxSize.Width - base.MinimizeBoxRect.Width - base.MaximizeBoxRect.Width - base.CloseBoxRect.Width, 0, base.ControlBoxSize.Width, base.ControlBoxSize.Height);
				}
				return Rectangle.Empty;
			}
		}

		protected Rectangle RibbonBtnRect => new Rectangle(base.Offset.X, base.CaptionHeight / 2 - _RibbonButtonSize.Height / 2 + 1, _RibbonButtonSize.Width, _RibbonButtonSize.Height - 2);

		protected override Rectangle LogoRect
		{
			get
			{
				if (base.ShowIcon && base.CapitionLogo != null)
				{
					return new Rectangle(RibbonBtnRect.Right + base.Offset.X, base.CaptionHeight / 2 - base.LogoSize.Height / 2 + 1, base.LogoSize.Width, base.LogoSize.Height);
				}
				return Rectangle.Empty;
			}
		}

		[Description("当主窗口水晶图标按钮被点击后发生")]
		public event EventHandler<BtnEventArgs> OnRibbonButtonClick;

		[Description("当主窗口皮肤图标按钮被点击后发生")]
		public event EventHandler<BtnEventArgs> OnSkinButtonClick;

		public IMainForm()
		{
			_RibbonButtonSize = new Size(34, 34);
			base.CapitionLogo = null;
			base.LogoSize = new Size(32, 32);
			base.CaptionHeight = 31;
			_SkinBoxSize = new Size(14, 14);
			OnSkinButtonClick += MainForm_OnSkinButtonClick;
			base.FormBorderStyle = FormBorderStyle.None;
		}

		private void MainForm_OnSkinButtonClick(object sender, BtnEventArgs e)
		{
			frmSkinManager frmSkinManager = new frmSkinManager();
			frmSkinManager.ShowDialog();
			frmSkinManager.Dispose();
		}

		protected override void WmNcHitTest(ref Message m)
		{
			int value = m.LParam.ToInt32();
			Point p = new Point(Win32.LOWORD(value), Win32.HIWORD(value));
			p = PointToClient(p);
			if (RibbonBtnRect.Contains(p))
			{
				m.Result = new IntPtr(1);
			}
			else
			{
				if (base.ResizeEnable && base.CaptionHeight > 0)
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
				if (p.Y <= base.CaptionHeight)
				{
					if (!base.CloseBoxRect.Contains(p) && !base.MaximizeBoxRect.Contains(p) && !base.MinimizeBoxRect.Contains(p) && !SkinBoxRect.Contains(p) && !RibbonBtnRect.Contains(p))
					{
						m.Result = new IntPtr(2);
					}
					else
					{
						m.Result = new IntPtr(1);
					}
				}
				else if (base.CaptionHeight > 0)
				{
					m.Result = new IntPtr(2);
				}
			}
		}

		protected override void DrawControlBox(Graphics g)
		{
			base.DrawControlBox(g);
			DrawSkinControlBox(g);
		}

		protected override void DrawCaption(Graphics g)
		{
			base.DrawCaption(g);
			if (base.CaptionHeight > 0)
			{
				DrawRibbonBtn(g);
			}
		}

		protected override void ProcessMouseDown(Point p)
		{
			if (!RibbonBtnRect.IsEmpty && RibbonBtnRect.Contains(p))
			{
				_RibbonBtnState = EnumControlState.Focused;
			}
			if (!SkinBoxRect.IsEmpty && SkinBoxRect.Contains(p))
			{
				_SkinBtnState = EnumControlState.Focused;
			}
			base.ProcessMouseDown(p);
		}

		protected override void ProcessMouseUp(Point p)
		{
			if (!RibbonBtnRect.IsEmpty && RibbonBtnRect.Contains(p))
			{
				_RibbonBtnState = EnumControlState.Default;
				if (this.OnRibbonButtonClick != null)
				{
					BtnEventArgs e = new BtnEventArgs(RibbonBtnRect);
					this.OnRibbonButtonClick(null, e);
				}
			}
			if (!SkinBoxRect.IsEmpty && SkinBoxRect.Contains(p))
			{
				_SkinBtnState = EnumControlState.Default;
				if (this.OnSkinButtonClick != null)
				{
					BtnEventArgs e = new BtnEventArgs(SkinBoxRect);
					this.OnSkinButtonClick(null, e);
				}
			}
			base.ProcessMouseUp(p);
		}

		protected override void ProcessMouseLeave(Point p)
		{
			_SkinBtnState = EnumControlState.Default;
			_RibbonBtnState = EnumControlState.Default;
			base.ProcessMouseLeave(p);
		}

		protected override void ProcessMouseMove(Point p)
		{
			_SkinBtnState = EnumControlState.Default;
			if (!RibbonBtnRect.IsEmpty && RibbonBtnRect.Contains(p))
			{
				_RibbonBtnState = EnumControlState.HeightLight;
			}
			if (!SkinBoxRect.IsEmpty && SkinBoxRect.Contains(p))
			{
				_SkinBtnState = EnumControlState.HeightLight;
			}
			base.ProcessMouseMove(p);
		}

		private void DrawSkinControlBox(Graphics g)
		{
			if (!SkinBoxRect.IsEmpty)
			{
				ControlBoxRender.DrawControlBox(g, SkinBoxRect, _SkinBtnState);
				GDIHelper.DrawImage(g, SkinBoxRect, Resources.skin, _SkinBoxSize);
			}
		}

		protected void DrawRibbonBtn(Graphics g)
		{
			Rectangle rect = new Rectangle(0, base.CaptionHeight, base.Width, base.Height - base.CaptionHeight + 1);
			g.SetClip(rect, CombineMode.Exclude);
			GDIHelper.InitializeGraphics(g);
			Rectangle ribbonBtnRect = RibbonBtnRect;
			ribbonBtnRect.Inflate(-1, -1);
			GDIHelper.FillEllipse(g, ribbonBtnRect, Color.White);
			Color empty = Color.Empty;
			Color empty2 = Color.Empty;
			Color lightColor = Color.FromArgb(232, 246, 250);
			Blend blend = new Blend();
			blend.Positions = new float[5]
			{
				0f,
				0.3f,
				0.5f,
				0.8f,
				1f
			};
			blend.Factors = new float[5]
			{
				0.15f,
				0.55f,
				0.7f,
				0.8f,
				0.95f
			};
			switch (_RibbonBtnState)
			{
			case EnumControlState.HeightLight:
				empty = Color.FromArgb(225, 179, 27);
				empty2 = Color.FromArgb(255, 251, 232);
				break;
			case EnumControlState.Focused:
				empty = Color.FromArgb(191, 113, 5);
				empty2 = Color.FromArgb(248, 227, 222);
				break;
			default:
				empty = Color.FromArgb(239, 246, 249);
				empty2 = Color.FromArgb(224, 221, 231);
				blend.Positions = new float[5]
				{
					0f,
					0.3f,
					0.5f,
					0.85f,
					1f
				};
				blend.Factors = new float[5]
				{
					0.95f,
					0.7f,
					0.45f,
					0.3f,
					0.15f
				};
				break;
			}
			GDIHelper.DrawCrystalButton(g, ribbonBtnRect, empty, empty2, lightColor, blend);
			Color color = Color.FromArgb(65, 177, 199);
			GDIHelper.DrawEllipseBorder(g, ribbonBtnRect, color, 1);
			GDIHelper.DrawImage(imgSize: new Size(20, 20), g: g, rect: ribbonBtnRect, img: Resources.naruto);
			g.ResetClip();
		}

		private void InitializeComponent()
		{
			SuspendLayout();
			base.ClientSize = new System.Drawing.Size(516, 388);
			Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "IMainForm";
			ResumeLayout(performLayout: false);
		}
	}
}
