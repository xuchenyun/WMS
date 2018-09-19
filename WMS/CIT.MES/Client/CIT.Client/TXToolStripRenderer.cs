using CIT.Client.Properties;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CIT.Client
{
	public class TXToolStripRenderer : ToolStripRenderer
	{
		private readonly int _OffsetMargin;

		public Color BackColor
		{
			get;
			set;
		}

		public int MenuCornerRadius
		{
			get;
			set;
		}

		public int ItemCornerRadius
		{
			get;
			set;
		}

		public Color MenuImageMarginBackColor
		{
			get;
			set;
		}

		public Image MenuImageBackImage
		{
			get;
			set;
		}

		public float MenuImageBackImageOpacity
		{
			get;
			set;
		}

		public bool ShowMenuBackImage
		{
			get;
			set;
		}

		public Color MenuBorderColor
		{
			get;
			set;
		}

		public TXToolStripRenderer()
		{
			_OffsetMargin = 24;
			MenuCornerRadius = 0;
			MenuImageMarginBackColor = SkinManager.CurrentSkin.DefaultControlColor.First;
			MenuImageBackImage = Resources.logo_mini;
			MenuImageBackImageOpacity = 0.16f;
			ShowMenuBackImage = true;
			MenuBorderColor = SkinManager.CurrentSkin.BorderColor;
			BackColor = SkinManager.CurrentSkin.BaseColor;
			ItemCornerRadius = 1;
		}

		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
		{
			ToolStrip toolStrip = e.ToolStrip;
			Graphics graphics = e.Graphics;
			GDIHelper.InitializeGraphics(graphics);
			Rectangle affectedBounds = e.AffectedBounds;
			RoundRectangle roundRect = new RoundRectangle(cornerRadius: new CornerRadius(MenuCornerRadius), rect: affectedBounds);
			if (toolStrip is ToolStripDropDown || toolStrip is ContextMenuStrip)
			{
				CreateToolStripRegion(toolStrip, roundRect);
				GDIHelper.FillPath(graphics, roundRect, BackColor, BackColor);
			}
			else if (toolStrip is TXMenuStrip)
			{
				TXMenuStrip tXMenuStrip = toolStrip as TXMenuStrip;
				Color beginBackColor = tXMenuStrip.BeginBackColor;
				Color endBackColor = tXMenuStrip.EndBackColor;
				GDIHelper.FillPath(graphics, new RoundRectangle(affectedBounds, new CornerRadius(0)), beginBackColor, endBackColor);
			}
			else if (toolStrip is TXToolStrip)
			{
				affectedBounds.Inflate(1, 1);
				TXToolStrip tXToolStrip = toolStrip as TXToolStrip;
				Color beginBackColor = tXToolStrip.BeginBackColor;
				Color endBackColor = tXToolStrip.EndBackColor;
				GDIHelper.FillPath(graphics, new RoundRectangle(affectedBounds, new CornerRadius(0)), beginBackColor, endBackColor);
			}
			else if (toolStrip is TXStatusStrip)
			{
				TXStatusStrip tXStatusStrip = toolStrip as TXStatusStrip;
				Color beginBackColor = tXStatusStrip.BeginBackColor;
				Color endBackColor = tXStatusStrip.EndBackColor;
				GDIHelper.FillPath(graphics, new RoundRectangle(affectedBounds, new CornerRadius(0)), beginBackColor, endBackColor);
			}
		}

		protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
		{
			ToolStrip toolStrip = e.ToolStrip;
			Graphics graphics = e.Graphics;
			GDIHelper.InitializeGraphics(graphics);
			Rectangle affectedBounds = e.AffectedBounds;
			affectedBounds.Width--;
			affectedBounds.Height--;
			if (toolStrip is ToolStripDropDown)
			{
				affectedBounds.Width = _OffsetMargin;
				Color menuImageMarginBackColor = MenuImageMarginBackColor;
				RoundRectangle roundRectangle = new RoundRectangle(cornerRadius: new CornerRadius(MenuCornerRadius), rect: affectedBounds);
				GDIHelper.FillPath(graphics, new RoundRectangle(affectedBounds, new CornerRadius(MenuCornerRadius, 0, MenuCornerRadius, 0)), menuImageMarginBackColor, menuImageMarginBackColor);
				Image menuImageBackImage = MenuImageBackImage;
				if (menuImageBackImage != null && ShowMenuBackImage)
				{
					ImageAttributes imageAttributes = new ImageAttributes();
					GDIHelper.SetImageOpacity(imageAttributes, MenuImageBackImageOpacity);
					graphics.DrawImage(Resources.logo_mini, new Rectangle(affectedBounds.X + 1, affectedBounds.Y + 2, menuImageBackImage.Width, menuImageBackImage.Height), 0, 0, menuImageBackImage.Width, menuImageBackImage.Height, GraphicsUnit.Pixel, imageAttributes);
				}
				Point pt = new Point(affectedBounds.X + _OffsetMargin, affectedBounds.Y + 3);
				Point pt2 = new Point(affectedBounds.X + _OffsetMargin, affectedBounds.Bottom - 3);
				using (Pen pen = new Pen(SkinManager.CurrentSkin.BorderColor))
				{
					graphics.DrawLine(pen, pt, pt2);
				}
			}
			else
			{
				base.OnRenderImageMargin(e);
			}
		}

		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
		{
			ToolStrip toolStrip = e.ToolStrip;
			Graphics graphics = e.Graphics;
			GDIHelper.InitializeGraphics(graphics);
			Rectangle affectedBounds = e.AffectedBounds;
			if (toolStrip is ToolStripDropDown)
			{
				affectedBounds.Width--;
				affectedBounds.Height--;
				RoundRectangle roundRect = new RoundRectangle(cornerRadius: new CornerRadius(MenuCornerRadius), rect: affectedBounds);
				GDIHelper.DrawPathBorder(graphics, roundRect, MenuBorderColor);
			}
			else
			{
				base.OnRenderToolStripBorder(e);
			}
		}

		protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
		{
			ToolStripItem item = e.Item;
			Graphics graphics = e.Graphics;
			GDIHelper.InitializeGraphics(graphics);
			Rectangle rect = new Rectangle(2, -1, item.Width - 4, item.Height + 1);
			RoundRectangle roundRectangle = new RoundRectangle(rect, new CornerRadius(0));
			if (item.Selected || item.Pressed)
			{
				Color baseColor = Color.FromArgb(200, SkinManager.CurrentSkin.HeightLightControlColor.First);
				Color color = Color.FromArgb(250, baseColor);
				GDIHelper.FillRectangle(graphics, rect, SkinManager.CurrentSkin.HeightLightControlColor);
			}
		}

		protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
		{
			ToolStripItem item = e.Item;
			Graphics graphics = e.Graphics;
			GDIHelper.InitializeGraphics(graphics);
			if (item.Tag != null && item.Tag.Equals("Vicky"))
			{
				int num = (item.Width >= item.Height) ? item.Height : item.Width;
				Rectangle rect = new Rectangle(0, 0, num, num);
				rect.Inflate(-1, -1);
				Color empty = Color.Empty;
				Color empty2 = Color.Empty;
				Color lightColor = Color.FromArgb(255, 220, 102);
				Blend blend = new Blend();
				blend.Positions = new float[3]
				{
					0f,
					0.5f,
					1f
				};
				blend.Factors = new float[3]
				{
					0.25f,
					0.75f,
					1f
				};
				Color color = (item.Selected || item.Pressed) ? Color.FromArgb(24, 116, 205) : SkinManager.CurrentSkin.BorderColor;
				float width = 1f;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				if (item.Selected || item.Pressed)
				{
					width = 2f;
					empty = Color.FromArgb(255, 226, 48);
					empty2 = Color.FromArgb(255, 220, 102);
					GDIHelper.DrawCrystalButton(graphics, rect, empty, empty2, lightColor, blend);
				}
				using (Pen pen = new Pen(color, width))
				{
					graphics.DrawEllipse(pen, rect);
				}
			}
			else
			{
				Rectangle rect = new Rectangle(1, 1, item.Width - 4, item.Height - 3);
				RoundRectangle roundRect = new RoundRectangle(rect, ItemCornerRadius);
				if (item.Selected || item.Pressed)
				{
					GDIHelper.FillRectangle(graphics, roundRect, SkinManager.CurrentSkin.HeightLightControlColor);
					GDIHelper.DrawPathBorder(graphics, roundRect);
				}
			}
		}

		protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
		{
			ToolStripItem item = e.Item;
			Graphics graphics = e.Graphics;
			GDIHelper.InitializeGraphics(graphics);
			Rectangle rect = new Rectangle(0, 0, item.Width - 1, item.Height - 1);
			RoundRectangle roundRect = new RoundRectangle(rect, ItemCornerRadius);
			if (item.Selected || item.Pressed)
			{
				GDIHelper.FillRectangle(graphics, roundRect, SkinManager.CurrentSkin.HeightLightControlColor);
				GDIHelper.DrawPathBorder(graphics, roundRect);
			}
		}

		protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
		{
			Size arrowSize = new Size(8, 8);
			Graphics graphics = e.Graphics;
			GDIHelper.InitializeGraphics(graphics);
			Rectangle arrowRectangle = e.ArrowRectangle;
			arrowRectangle.X -= 2;
			GDIHelper.DrawArrow(graphics, e.Direction, arrowRectangle, arrowSize);
		}

		protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
		{
			base.OnRenderOverflowButtonBackground(e);
			Graphics graphics = e.Graphics;
			GDIHelper.InitializeGraphics(graphics);
			ToolStripItem item = e.Item;
			Rectangle bounds = item.Bounds;
			bounds = new Rectangle(0, 0, bounds.Width, bounds.Height);
			Size arrowSize = new Size(8, 8);
			GDIHelper.DrawArrow(graphics, System.Windows.Forms.ArrowDirection.Down, bounds, arrowSize);
		}

		protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
		{
			base.OnRenderItemImage(e);
		}

		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
		{
			base.OnRenderItemText(e);
		}

		protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
		{
			ToolStrip toolStrip = e.ToolStrip;
			Graphics graphics = e.Graphics;
			GDIHelper.InitializeGraphics(graphics);
			Rectangle imageRectangle = e.ImageRectangle;
			if (toolStrip is ToolStripDropDown)
			{
				imageRectangle.Width -= 2;
				imageRectangle.Height -= 2;
				RoundRectangle roundRect = new RoundRectangle(imageRectangle, 1);
				GDIHelper.DrawCheckBox(graphics, roundRect);
				GDIHelper.DrawCheckedStateByImage(graphics, imageRectangle);
			}
			else
			{
				base.OnRenderItemCheck(e);
			}
		}

		protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
		{
			ToolStrip toolStrip = e.ToolStrip;
			Rectangle contentRectangle = e.Item.ContentRectangle;
			if (toolStrip is ToolStripDropDown)
			{
				contentRectangle.X += _OffsetMargin;
				contentRectangle.Width -= _OffsetMargin;
			}
			Graphics graphics = e.Graphics;
			DrawSeparatorLine(contentRectangle, graphics, e.Vertical);
		}

		internal void CreateToolStripRegion(ToolStrip toolStrip, RoundRectangle roundRect)
		{
			using (GraphicsPath graphicsPath = roundRect.ToGraphicsBezierPath())
			{
				Region region = new Region(graphicsPath);
				graphicsPath.Widen(new Pen(MenuBorderColor));
				region.Union(graphicsPath);
				if (toolStrip.Region != null)
				{
					toolStrip.Region.Dispose();
				}
				toolStrip.Region = region;
			}
		}

		private void DrawSeparatorLine(Rectangle rect, Graphics g, bool isVertical)
		{
			Color borderColor = SkinManager.CurrentSkin.BorderColor;
			Color color = Color.FromArgb(10, borderColor);
			int num = isVertical ? 90 : 180;
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, borderColor, color, (float)num))
			{
				Blend blend = new Blend();
				blend.Positions = new float[5]
				{
					0f,
					0.2f,
					0.5f,
					0.8f,
					1f
				};
				blend.Factors = new float[5]
				{
					1f,
					0.3f,
					0f,
					0.3f,
					1f
				};
				linearGradientBrush.Blend = blend;
				using (Pen pen = new Pen(linearGradientBrush))
				{
					g.SmoothingMode = SmoothingMode.AntiAlias;
					if (isVertical)
					{
						g.DrawLine(pen, rect.X, rect.Y + 1, rect.X, rect.Bottom - 1);
					}
					else
					{
						g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
					}
				}
			}
		}
	}
}
