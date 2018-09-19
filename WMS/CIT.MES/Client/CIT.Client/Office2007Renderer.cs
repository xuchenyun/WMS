using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CIT.Client
{
	public class Office2007Renderer : ToolStripProfessionalRenderer
	{
		private static int MarginInset;

		private static Blend StatusStripBlend;

		static Office2007Renderer()
		{
			MarginInset = 2;
			StatusStripBlend = new Blend();
			StatusStripBlend.Positions = new float[6]
			{
				0f,
				0.2f,
				0.3f,
				0.4f,
				0.8f,
				1f
			};
			StatusStripBlend.Factors = new float[6]
			{
				0.3f,
				0.4f,
				0.5f,
				1f,
				0.8f,
				0.7f
			};
		}

		public Office2007Renderer()
			: base(new Office2007BlueColorTable())
		{
			base.ColorTable.UseSystemColors = false;
		}

		public Office2007Renderer(ProfessionalColorTable professionalColorTable)
			: base(professionalColorTable)
		{
		}

		protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
		{
			if (!base.ColorTable.UseSystemColors)
			{
				ProfessionalColorTable professionalColorTable = base.ColorTable as ProfessionalColorTable;
				if (professionalColorTable != null)
				{
					if (e.Item.Owner.GetType() == typeof(MenuStrip) && !e.Item.Selected && !e.Item.Pressed && professionalColorTable.MenuItemText != Color.Empty)
					{
						e.ArrowColor = professionalColorTable.MenuItemText;
					}
					if (e.Item.Owner.GetType() == typeof(StatusStrip) && !e.Item.Selected && !e.Item.Pressed && professionalColorTable.StatusStripText != Color.Empty)
					{
						e.ArrowColor = professionalColorTable.StatusStripText;
					}
				}
			}
			base.OnRenderArrow(e);
		}

		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
		{
			if (!base.ColorTable.UseSystemColors)
			{
				ProfessionalColorTable professionalColorTable = base.ColorTable as ProfessionalColorTable;
				if (professionalColorTable != null)
				{
					if (e.ToolStrip is MenuStrip && !e.Item.Selected && !e.Item.Pressed && professionalColorTable.MenuItemText != Color.Empty)
					{
						e.TextColor = professionalColorTable.MenuItemText;
					}
					if (e.ToolStrip is StatusStrip && !e.Item.Selected && !e.Item.Pressed && professionalColorTable.StatusStripText != Color.Empty)
					{
						e.TextColor = professionalColorTable.StatusStripText;
					}
				}
			}
			base.OnRenderItemText(e);
		}

		protected override void OnRenderToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
		{
			base.OnRenderToolStripContentPanelBackground(e);
			if (!base.ColorTable.UseSystemColors && e.ToolStripContentPanel.Width > 0 && e.ToolStripContentPanel.Height > 0)
			{
				using (LinearGradientBrush brush = new LinearGradientBrush(e.ToolStripContentPanel.ClientRectangle, base.ColorTable.ToolStripContentPanelGradientBegin, base.ColorTable.ToolStripContentPanelGradientEnd, LinearGradientMode.Vertical))
				{
					e.Graphics.FillRectangle(brush, e.ToolStripContentPanel.ClientRectangle);
				}
			}
		}

		protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
		{
			if (!base.ColorTable.UseSystemColors)
			{
				e.Item.ForeColor = base.ColorTable.RaftingContainerGradientBegin;
			}
			base.OnRenderSeparator(e);
		}

		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
		{
			if (base.ColorTable.UseSystemColors)
			{
				base.OnRenderToolStripBackground(e);
			}
			else if (e.ToolStrip is StatusStrip)
			{
				RectangleF rect = new RectangleF(0f, 0f, (float)e.ToolStrip.Width, (float)e.ToolStrip.Height);
				if (rect.Width > 0f && rect.Height > 0f)
				{
					using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, base.ColorTable.StatusStripGradientBegin, base.ColorTable.StatusStripGradientEnd, LinearGradientMode.Vertical))
					{
						linearGradientBrush.Blend = StatusStripBlend;
						e.Graphics.FillRectangle(linearGradientBrush, rect);
					}
				}
			}
			else
			{
				base.OnRenderToolStripBackground(e);
			}
		}

		protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
		{
			if (base.ColorTable.UseSystemColors)
			{
				base.OnRenderToolStripBackground(e);
			}
			else if (e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu)
			{
				Rectangle affectedBounds = e.AffectedBounds;
				bool flag = e.ToolStrip.RightToLeft == RightToLeft.Yes;
				affectedBounds.Y += MarginInset;
				affectedBounds.Height -= MarginInset * 2;
				if (!flag)
				{
					affectedBounds.X += MarginInset;
				}
				else
				{
					affectedBounds.X += MarginInset / 2;
				}
				using (SolidBrush brush = new SolidBrush(base.ColorTable.ImageMarginGradientBegin))
				{
					e.Graphics.FillRectangle(brush, affectedBounds);
				}
			}
			else
			{
				base.OnRenderImageMargin(e);
			}
		}
	}
}
