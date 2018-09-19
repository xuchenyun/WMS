using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(StatusStrip))]
	public class TXStatusStrip : StatusStrip
	{
		private Color _BeginBackColor = SkinManager.CurrentSkin.BaseColor;

		private Color _EndBackColor = SkinManager.CurrentSkin.BaseColor;

		[Category("TXProperties")]
		[Browsable(false)]
		[Description("背景色")]
		public new Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
				Invalidate();
			}
		}

		[DefaultValue(typeof(ToolStripRenderMode), "ManagerRenderMode")]
		[Category("TXProperties")]
		public new ToolStripRenderMode RenderMode
		{
			get
			{
				return base.RenderMode;
			}
			set
			{
				base.RenderMode = value;
				Invalidate();
			}
		}

		[Category("TXProperties")]
		[Description("开始部分背景色")]
		public Color BeginBackColor
		{
			get
			{
				return _BeginBackColor;
			}
			set
			{
				_BeginBackColor = value;
				Invalidate();
			}
		}

		[Category("TXProperties")]
		[Description("后面部分背景色")]
		public Color EndBackColor
		{
			get
			{
				return _EndBackColor;
			}
			set
			{
				_EndBackColor = value;
				Invalidate();
			}
		}

		public TXStatusStrip()
		{
			base.BackColor = SkinManager.CurrentSkin.BaseColor;
			base.RenderMode = ToolStripRenderMode.ManagerRenderMode;
		}
	}
}
