#define TRACE
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CIT.Client
{
	public class BseRenderer : ToolStripProfessionalRenderer
	{
		private static Rectangle[] baseSizeGripRectangles;

		private static int MarginInset;

		private static Blend MenuItemBlend;

		private static Blend ButtonBlend;

		static BseRenderer()
		{
			MarginInset = 2;
			ButtonBlend = new Blend();
			ButtonBlend.Positions = new float[5]
			{
				0f,
				0.1f,
				0.2f,
				0.5f,
				1f
			};
			ButtonBlend.Factors = new float[5]
			{
				0.6f,
				0.7f,
				0.8f,
				1f,
				1f
			};
			MenuItemBlend = new Blend();
			MenuItemBlend.Positions = new float[5]
			{
				0f,
				0.1f,
				0.2f,
				0.5f,
				1f
			};
			MenuItemBlend.Factors = new float[5]
			{
				0.7f,
				0.8f,
				0.9f,
				1f,
				1f
			};
			baseSizeGripRectangles = new Rectangle[6]
			{
				new Rectangle(8, 0, 2, 2),
				new Rectangle(8, 4, 2, 2),
				new Rectangle(8, 8, 2, 2),
				new Rectangle(4, 4, 2, 2),
				new Rectangle(4, 8, 2, 2),
				new Rectangle(0, 8, 2, 2)
			};
		}

		public BseRenderer()
			: base(new ColorTableBlack())
		{
			base.ColorTable.UseSystemColors = false;
		}

		public BseRenderer(ProfessionalColorTable professionalColorTable)
			: base(professionalColorTable)
		{
		}

		protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
		{
			if (base.ColorTable.UseSystemColors)
			{
				base.OnRenderArrow(e);
			}
			else
			{
				ProfessionalColorTable professionalColorTable = base.ColorTable as ProfessionalColorTable;
				if (professionalColorTable != null && e.Item.Enabled)
				{
					if (e.Item.Owner is MenuStrip)
					{
						e.ArrowColor = professionalColorTable.MenuItemText;
					}
					else if (e.Item.Owner is StatusStrip)
					{
						e.ArrowColor = professionalColorTable.StatusStripText;
					}
					else if (e.Item.Owner.GetType() != typeof(ToolStripDropDownMenu))
					{
						e.ArrowColor = professionalColorTable.ToolStripText;
					}
				}
				base.OnRenderArrow(e);
			}
		}

		protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
		{
			if (base.ColorTable.UseSystemColors)
			{
				base.OnRenderDropDownButtonBackground(e);
			}
			else
			{
				ToolStripButton toolStripButton = e.Item as ToolStripButton;
				Rectangle rectangle = new Rectangle(Point.Empty, toolStripButton.Size);
				if (!IsZeroWidthOrHeight(rectangle))
				{
					Graphics graphics = e.Graphics;
					ProfessionalColorTable professionalColorTable = base.ColorTable as ProfessionalColorTable;
					if (professionalColorTable != null)
					{
						using (new UseAntiAlias(graphics))
						{
							Rectangle buttonRectangle = GetButtonRectangle(rectangle);
							if (toolStripButton.Checked)
							{
								DrawButtonBorder(graphics, buttonRectangle, professionalColorTable.ButtonPressedBorder);
							}
							if (toolStripButton.Selected && !toolStripButton.Pressed)
							{
								RenderButton(graphics, buttonRectangle, professionalColorTable.MenuItemTopLevelSelectedGradientBegin);
								DrawButtonBorder(graphics, buttonRectangle, professionalColorTable.ButtonSelectedHighlightBorder);
							}
							if (toolStripButton.Pressed)
							{
								RenderButton(graphics, buttonRectangle, professionalColorTable.MenuItemPressedGradientBegin);
								DrawInnerButtonBorder(graphics, buttonRectangle, professionalColorTable.ButtonSelectedHighlightBorder);
								DrawButtonBorder(graphics, buttonRectangle, professionalColorTable.MenuBorder);
							}
						}
					}
					else
					{
						base.OnRenderDropDownButtonBackground(e);
					}
				}
			}
		}

		protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
		{
			if (base.ColorTable.UseSystemColors)
			{
				base.OnRenderDropDownButtonBackground(e);
			}
			else
			{
				ToolStripDropDownButton toolStripDropDownButton = e.Item as ToolStripDropDownButton;
				Rectangle rectangle = new Rectangle(Point.Empty, toolStripDropDownButton.Size);
				if (!IsZeroWidthOrHeight(rectangle))
				{
					Graphics graphics = e.Graphics;
					ProfessionalColorTable professionalColorTable = base.ColorTable as ProfessionalColorTable;
					if (professionalColorTable != null)
					{
						using (new UseAntiAlias(graphics))
						{
							Rectangle buttonRectangle = GetButtonRectangle(rectangle);
							if (toolStripDropDownButton.Selected && !toolStripDropDownButton.Pressed)
							{
								RenderButton(graphics, buttonRectangle, professionalColorTable.MenuItemTopLevelSelectedGradientBegin);
								DrawButtonBorder(graphics, buttonRectangle, professionalColorTable.ButtonSelectedHighlightBorder);
							}
							if (toolStripDropDownButton.Pressed)
							{
								RenderButton(graphics, buttonRectangle, professionalColorTable.MenuItemPressedGradientBegin);
								DrawInnerButtonBorder(graphics, buttonRectangle, professionalColorTable.ButtonSelectedHighlightBorder);
								DrawButtonBorder(graphics, buttonRectangle, professionalColorTable.MenuBorder);
							}
						}
					}
					else
					{
						base.OnRenderDropDownButtonBackground(e);
					}
				}
			}
		}

		protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
		{
			if (base.ColorTable.UseSystemColors)
			{
				base.OnRenderDropDownButtonBackground(e);
			}
			else
			{
				ToolStripSplitButton toolStripSplitButton = e.Item as ToolStripSplitButton;
				Rectangle rectangle = new Rectangle(Point.Empty, toolStripSplitButton.ButtonBounds.Size);
				if (!IsZeroWidthOrHeight(rectangle))
				{
					Graphics graphics = e.Graphics;
					ProfessionalColorTable professionalColorTable = base.ColorTable as ProfessionalColorTable;
					if (professionalColorTable != null)
					{
						using (new UseAntiAlias(graphics))
						{
							Rectangle buttonRectangle = GetButtonRectangle(rectangle);
							Rectangle rectangle2 = new Rectangle(toolStripSplitButton.DropDownButtonBounds.Location, toolStripSplitButton.DropDownButtonBounds.Size);
							Rectangle buttonRectangle2 = GetButtonRectangle(rectangle2);
							if (toolStripSplitButton.Selected && !toolStripSplitButton.Pressed && !toolStripSplitButton.ButtonPressed)
							{
								RenderButton(graphics, buttonRectangle, professionalColorTable.MenuItemTopLevelSelectedGradientBegin);
								RenderButton(graphics, buttonRectangle2, professionalColorTable.MenuItemTopLevelSelectedGradientBegin);
								DrawButtonBorder(graphics, buttonRectangle, professionalColorTable.ButtonSelectedHighlightBorder);
								DrawButtonBorder(graphics, buttonRectangle2, professionalColorTable.ButtonSelectedHighlightBorder);
							}
							if (toolStripSplitButton.ButtonPressed)
							{
								RenderButton(graphics, buttonRectangle, professionalColorTable.MenuItemPressedGradientBegin);
								RenderButton(graphics, buttonRectangle2, professionalColorTable.MenuItemPressedGradientBegin);
								DrawInnerButtonBorder(graphics, buttonRectangle, professionalColorTable.ButtonSelectedHighlightBorder);
								DrawButtonBorder(graphics, buttonRectangle, professionalColorTable.MenuBorder);
								DrawInnerButtonBorder(graphics, buttonRectangle2, professionalColorTable.ButtonSelectedHighlightBorder);
								DrawButtonBorder(graphics, buttonRectangle2, professionalColorTable.MenuBorder);
							}
							if (toolStripSplitButton.DropDownButtonPressed)
							{
								RenderButton(graphics, buttonRectangle, professionalColorTable.MenuItemTopLevelSelectedGradientBegin);
								RenderButton(graphics, buttonRectangle2, professionalColorTable.MenuItemTopLevelSelectedGradientBegin);
								DrawButtonBorder(graphics, buttonRectangle, base.ColorTable.ButtonSelectedHighlightBorder);
								DrawButtonBorder(graphics, buttonRectangle2, base.ColorTable.ButtonSelectedHighlightBorder);
							}
							if (e.Item.Owner is MenuStrip)
							{
								DrawArrow(new ToolStripArrowRenderEventArgs(graphics, toolStripSplitButton, rectangle2, professionalColorTable.MenuItemText, System.Windows.Forms.ArrowDirection.Down));
							}
							if (e.Item.Owner is StatusStrip)
							{
								DrawArrow(new ToolStripArrowRenderEventArgs(graphics, toolStripSplitButton, rectangle2, professionalColorTable.StatusStripText, System.Windows.Forms.ArrowDirection.Down));
							}
							if (e.Item.Owner != null)
							{
								DrawArrow(new ToolStripArrowRenderEventArgs(graphics, toolStripSplitButton, rectangle2, professionalColorTable.ToolStripText, System.Windows.Forms.ArrowDirection.Down));
							}
						}
					}
					else
					{
						base.OnRenderDropDownButtonBackground(e);
					}
				}
			}
		}

		protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = e.Item as ToolStripMenuItem;
			Rectangle rectangle = new Rectangle(Point.Empty, toolStripMenuItem.Size);
			if (!IsZeroWidthOrHeight(rectangle))
			{
				Graphics graphics = e.Graphics;
				ProfessionalColorTable professionalColorTable = base.ColorTable as ProfessionalColorTable;
				if (professionalColorTable != null)
				{
					using (new UseAntiAlias(graphics))
					{
						if (e.ToolStrip is MenuStrip)
						{
							if (toolStripMenuItem.Selected && !toolStripMenuItem.Pressed)
							{
								RenderMenuItem(graphics, rectangle, professionalColorTable.MenuItemTopLevelSelectedGradientBegin);
								ControlPaint.DrawBorder(e.Graphics, rectangle, professionalColorTable.MenuItemTopLevelSelectedBorder, ButtonBorderStyle.Solid);
							}
							if (toolStripMenuItem.Pressed)
							{
								RenderButton(graphics, rectangle, base.ColorTable.MenuItemPressedGradientBegin);
								Rectangle bounds = rectangle;
								bounds.Inflate(-1, -1);
								ControlPaint.DrawBorder(e.Graphics, bounds, base.ColorTable.ButtonSelectedHighlightBorder, ButtonBorderStyle.Solid);
								ControlPaint.DrawBorder(e.Graphics, rectangle, base.ColorTable.MenuBorder, ButtonBorderStyle.Solid);
							}
						}
						else
						{
							base.OnRenderMenuItemBackground(e);
						}
					}
				}
				else
				{
					base.OnRenderMenuItemBackground(e);
				}
			}
		}

		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
		{
			if (!base.ColorTable.UseSystemColors)
			{
				ProfessionalColorTable professionalColorTable = base.ColorTable as ProfessionalColorTable;
				if (professionalColorTable != null)
				{
					if (e.ToolStrip is MenuStrip)
					{
						if (professionalColorTable.MenuItemText != Color.Empty)
						{
							e.TextColor = professionalColorTable.MenuItemText;
						}
					}
					else if (e.ToolStrip is StatusStrip)
					{
						if (professionalColorTable.StatusStripText != Color.Empty)
						{
							e.TextColor = professionalColorTable.StatusStripText;
						}
					}
					else if (!(e.ToolStrip is ToolStripDropDown) && professionalColorTable.ToolStripText != Color.Empty)
					{
						e.TextColor = professionalColorTable.ToolStripText;
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

		protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
		{
			base.OnRenderOverflowButtonBackground(e);
			ToolStripItem item = e.Item;
			if (!item.Selected && !item.Pressed)
			{
				ProfessionalColorTable professionalColorTable = base.ColorTable as ProfessionalColorTable;
				if (professionalColorTable != null)
				{
					Graphics graphics = e.Graphics;
					bool flag = item.RightToLeft == RightToLeft.Yes;
					bool flag2 = e.ToolStrip.Orientation == Orientation.Horizontal;
					Rectangle empty = Rectangle.Empty;
					empty = (flag ? new Rectangle(0, item.Height - 8, 9, 5) : new Rectangle(item.Width - 12, item.Height - 8, 9, 5));
					ArrowDirection direction = flag2 ? ArrowDirection.Down : ArrowDirection.Right;
					int num = (!flag || !flag2) ? 1 : (-1);
					empty.Offset(num, 1);
					RenderArrowInternal(graphics, empty, direction, professionalColorTable.ToolStripGradientMiddle);
					empty.Offset(-1 * num, -1);
					RenderArrowInternal(graphics, empty, direction, professionalColorTable.ToolStripText);
					if (flag2)
					{
						num = (flag ? (-2) : 0);
						RenderOverflowButtonLine(graphics, professionalColorTable.ToolStripText, empty.Right - 6, empty.Y - 2, empty.Right - 2, empty.Y - 2);
						RenderOverflowButtonLine(graphics, professionalColorTable.ToolStripGradientMiddle, empty.Right - 5 + num, empty.Y - 1, empty.Right - 1 + num, empty.Y - 1);
					}
					else
					{
						RenderOverflowButtonLine(graphics, professionalColorTable.ToolStripText, empty.X, empty.Y, empty.X, empty.Bottom - 1);
						RenderOverflowButtonLine(graphics, professionalColorTable.ToolStripGradientMiddle, empty.X + 1, empty.Y + 1, empty.X + 1, empty.Bottom);
					}
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

		protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
		{
			Graphics graphics = e.Graphics;
			StatusStrip statusStrip = e.ToolStrip as StatusStrip;
			if (statusStrip != null)
			{
				Rectangle sizeGripBounds = statusStrip.SizeGripBounds;
				if (!IsZeroWidthOrHeight(sizeGripBounds))
				{
					Rectangle[] array = new Rectangle[baseSizeGripRectangles.Length];
					Rectangle[] array2 = new Rectangle[baseSizeGripRectangles.Length];
					for (int i = 0; i < baseSizeGripRectangles.Length; i++)
					{
						Rectangle rectangle = baseSizeGripRectangles[i];
						if (statusStrip.RightToLeft == RightToLeft.Yes)
						{
							rectangle.X = sizeGripBounds.Width - rectangle.X - rectangle.Width;
						}
						rectangle.Offset(sizeGripBounds.X, sizeGripBounds.Bottom - 12);
						array[i] = rectangle;
						if (statusStrip.RightToLeft == RightToLeft.Yes)
						{
							rectangle.Offset(1, -1);
						}
						else
						{
							rectangle.Offset(-1, -1);
						}
						array2[i] = rectangle;
					}
					using (SolidBrush brush2 = new SolidBrush(base.ColorTable.GripDark))
					{
						using (SolidBrush brush = new SolidBrush(base.ColorTable.GripDark))
						{
							graphics.FillRectangles(brush, array);
							graphics.FillRectangles(brush2, array2);
						}
					}
				}
			}
		}

		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
		{
			if (base.ColorTable.UseSystemColors)
			{
				base.OnRenderToolStripBackground(e);
			}
			else
			{
				Trace.WriteLine("ToolStrip: " + e.ToolStrip.GetType());
				Rectangle rectangle = new Rectangle(0, 0, e.ToolStrip.Width, e.ToolStrip.Height);
				Rectangle rectangle2 = rectangle;
				rectangle2.Height = rectangle.Height / 2 + 1;
				if (rectangle.Width > 0 && rectangle.Height > 0)
				{
					if (e.ToolStrip is StatusStrip)
					{
						using (SolidBrush brush = new SolidBrush(base.ColorTable.StatusStripGradientEnd))
						{
							e.Graphics.FillRectangle(brush, rectangle);
						}
						int height = rectangle.Height / 2;
						Rectangle rect = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, height);
						rect.Height++;
						using (LinearGradientBrush brush2 = new LinearGradientBrush(rect, base.ColorTable.StatusStripGradientBegin, Color.FromArgb(128, base.ColorTable.StatusStripGradientBegin), LinearGradientMode.Vertical))
						{
							e.Graphics.FillRectangle(brush2, rect);
						}
						height = rectangle.Height / 4 + 1;
						Rectangle rect2 = new Rectangle(rectangle.X, rectangle.Height - height, rectangle.Width, height);
						using (LinearGradientBrush brush2 = new LinearGradientBrush(rect2, base.ColorTable.StatusStripGradientEnd, Color.FromArgb(128, base.ColorTable.StatusStripGradientBegin), LinearGradientMode.Vertical))
						{
							e.Graphics.FillRectangle(brush2, rect2);
						}
					}
					else if (e.ToolStrip is MenuStrip)
					{
						using (SolidBrush brush = new SolidBrush(base.ColorTable.MenuStripGradientEnd))
						{
							e.Graphics.FillRectangle(brush, rectangle);
						}
						int height = rectangle.Height / 3;
						Rectangle rect2 = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, height);
						using (LinearGradientBrush brush2 = new LinearGradientBrush(rect2, base.ColorTable.MenuStripGradientBegin, Color.FromArgb(128, base.ColorTable.StatusStripGradientBegin), LinearGradientMode.Vertical))
						{
							e.Graphics.FillRectangle(brush2, rect2);
						}
					}
					else if (e.ToolStrip is ToolStripDropDown)
					{
						base.OnRenderToolStripBackground(e);
					}
					else
					{
						using (SolidBrush brush = new SolidBrush(base.ColorTable.ToolStripGradientEnd))
						{
							e.Graphics.FillRectangle(brush, rectangle);
						}
						int height = rectangle.Height / 2;
						Rectangle rect = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, height);
						using (LinearGradientBrush brush2 = new LinearGradientBrush(rect, base.ColorTable.ToolStripGradientBegin, base.ColorTable.ToolStripGradientMiddle, LinearGradientMode.Vertical))
						{
							e.Graphics.FillRectangle(brush2, rect);
						}
						height = rectangle.Height / 4;
						Rectangle rect2 = new Rectangle(rectangle.X, rectangle.Height - height, rectangle.Width, height);
						using (LinearGradientBrush brush2 = new LinearGradientBrush(rect2, base.ColorTable.ToolStripGradientEnd, base.ColorTable.ToolStripGradientMiddle, LinearGradientMode.Vertical))
						{
							e.Graphics.FillRectangle(brush2, rect2);
						}
					}
				}
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

		private static GraphicsPath GetBackgroundPath(Rectangle bounds, int radius)
		{
			int x = bounds.X;
			int y = bounds.Y;
			int width = bounds.Width;
			int height = bounds.Height;
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(x, y, radius, radius, 180f, 90f);
			graphicsPath.AddArc(x + width - radius, y, radius, radius, 270f, 90f);
			graphicsPath.AddArc(x + width - radius, y + height - radius, radius, radius, 0f, 90f);
			graphicsPath.AddArc(x, y + height - radius, radius, radius, 90f, 90f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		private static void RenderButton(Graphics graphics, Rectangle buttonBounds, Color gradientColor)
		{
			using (GraphicsPath path = GetBackgroundPath(buttonBounds, 3))
			{
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(buttonBounds, gradientColor, Color.Transparent, LinearGradientMode.Vertical))
				{
					linearGradientBrush.Blend = ButtonBlend;
					graphics.FillPath(linearGradientBrush, path);
				}
			}
		}

		private static void RenderMenuItem(Graphics graphics, Rectangle menuBounds, Color gradientColor)
		{
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(menuBounds, gradientColor, Color.Transparent, LinearGradientMode.Vertical))
			{
				linearGradientBrush.Blend = MenuItemBlend;
				graphics.FillRectangle(linearGradientBrush, menuBounds);
			}
		}

		private static void DrawButtonBorder(Graphics graphics, Rectangle buttonBounds, Color borderColor)
		{
			using (GraphicsPath path = GetBackgroundPath(buttonBounds, 3))
			{
				using (Pen pen = new Pen(borderColor))
				{
					graphics.DrawPath(pen, path);
				}
			}
		}

		private static void DrawInnerButtonBorder(Graphics graphics, Rectangle buttonBounds, Color innerBorderColor)
		{
			Rectangle bounds = buttonBounds;
			bounds.Height--;
			bounds.Width--;
			using (GraphicsPath path = GetBackgroundPath(bounds, 3))
			{
				using (Pen pen = new Pen(innerBorderColor))
				{
					graphics.DrawPath(pen, path);
				}
			}
		}

		private static Rectangle GetButtonRectangle(Rectangle bounds)
		{
			Rectangle result = bounds;
			result.Width--;
			result.Height--;
			result.Inflate(0, -1);
			return result;
		}

		private static void RenderArrowInternal(Graphics graphics, Rectangle dropDownRectangle, ArrowDirection direction, Color color)
		{
			Point point = new Point(dropDownRectangle.Left + dropDownRectangle.Width / 2, dropDownRectangle.Top + dropDownRectangle.Height / 2);
			point.X += dropDownRectangle.Width % 2;
			Point[] array = null;
			switch (direction)
			{
			case ArrowDirection.Left:
				array = new Point[3]
				{
					new Point(point.X + 2, point.Y - 3),
					new Point(point.X + 2, point.Y + 3),
					new Point(point.X - 1, point.Y)
				};
				break;
			case ArrowDirection.Up:
				array = new Point[3]
				{
					new Point(point.X - 2, point.Y + 1),
					new Point(point.X + 3, point.Y + 1),
					new Point(point.X, point.Y - 2)
				};
				break;
			case ArrowDirection.Right:
				array = new Point[3]
				{
					new Point(point.X - 2, point.Y - 3),
					new Point(point.X - 2, point.Y + 3),
					new Point(point.X + 1, point.Y)
				};
				break;
			default:
				array = new Point[3]
				{
					new Point(point.X - 2, point.Y - 1),
					new Point(point.X + 3, point.Y - 1),
					new Point(point.X, point.Y + 2)
				};
				break;
			}
			using (SolidBrush brush = new SolidBrush(color))
			{
				graphics.FillPolygon(brush, array);
			}
		}

		private static void RenderOverflowButtonLine(Graphics graphics, Color color, int x1, int y1, int x2, int y2)
		{
			using (Pen pen = new Pen(color))
			{
				graphics.DrawLine(pen, x1, y1, x2, y2);
			}
		}

		private static bool IsZeroWidthOrHeight(Rectangle rectangle)
		{
			if (rectangle.Width != 0)
			{
				return rectangle.Height == 0;
			}
			return true;
		}
	}
}
