using CIT.Client.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CIT.Client
{
	public class GDIHelper
	{
		public static void InitializeGraphics(Graphics g)
		{
			if (g != null)
			{
				g.SmoothingMode = SmoothingMode.AntiAlias;
				g.InterpolationMode = InterpolationMode.HighQualityBicubic;
				g.CompositingQuality = CompositingQuality.HighQuality;
			}
		}

		public static void DrawImage(Graphics g, Rectangle rect, Image img, float opacity)
		{
			if (!(opacity <= 0f))
			{
				using (ImageAttributes imageAttributes = new ImageAttributes())
				{
					SetImageOpacity(imageAttributes, (opacity >= 1f) ? 1f : opacity);
					Rectangle rectangle = new Rectangle(rect.X, rect.Y + rect.Height / 2 - img.Size.Height / 2, img.Size.Width, img.Size.Height);
					g.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAttributes);
				}
			}
		}

		public static void DrawImage(Graphics g, Rectangle rect, Image img)
		{
			Rectangle rectangle = new Rectangle(rect.X, rect.Y + rect.Height / 2 - img.Size.Height / 2, img.Size.Width, img.Size.Height);
			g.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
		}

		public static void DrawImage(Graphics g, Rectangle rect, Image img, Size imgSize)
		{
			if (g != null && img != null)
			{
				int x = rect.X + rect.Width / 2 - imgSize.Width / 2;
				int y = rect.Y;
				Rectangle rect2 = new Rectangle(x, y + rect.Height / 2 - imgSize.Height / 2, imgSize.Width, imgSize.Height);
				g.DrawImage(img, rect2);
			}
		}

		public static void DrawImageAndString(Graphics g, Rectangle rect, Image image, Size imageSize, string text, Font font, Color forceColor)
		{
			int x = rect.X;
			int y = rect.Y;
			SizeF sizeF = g.MeasureString(text, font);
			int num = Convert.ToInt32(sizeF.Width) + 2;
			x += rect.Width / 2 - num / 2;
			if (image != null)
			{
				x -= imageSize.Width / 2;
				Rectangle rect2 = new Rectangle(x, y + rect.Height / 2 - imageSize.Height / 2, imageSize.Width, imageSize.Height);
				g.DrawImage(image, rect2);
				x += imageSize.Width + 2;
			}
			g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
			using (SolidBrush brush = new SolidBrush(forceColor))
			{
				g.DrawString(text, font, brush, (float)x, (float)(y + rect.Height / 2 - Convert.ToInt32(sizeF.Height) / 2 + 2));
			}
		}

		public static void FillRectangle(Graphics g, Rectangle rect, GradientColor color)
		{
			if (rect.Width > 0 && rect.Height > 0 && g != null)
			{
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, color.First, color.Second, LinearGradientMode.Vertical))
				{
					linearGradientBrush.Blend.Factors = color.Factors;
					linearGradientBrush.Blend.Positions = color.Positions;
					g.FillRectangle(linearGradientBrush, rect);
				}
			}
		}

		public static void FillRectangle(Graphics g, Rectangle rect, Color color)
		{
			if (rect.Width > 0 && rect.Height > 0 && g != null)
			{
				using (Brush brush = new SolidBrush(color))
				{
					g.FillRectangle(brush, rect);
				}
			}
		}

		public static void FillRectangle(Graphics g, RoundRectangle roundRect, GradientColor color)
		{
			if (roundRect.Rect.Width > 0 && roundRect.Rect.Height > 0)
			{
				using (GraphicsPath path = roundRect.ToGraphicsBezierPath())
				{
					using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(roundRect.Rect, color.First, color.Second, LinearGradientMode.Vertical))
					{
						linearGradientBrush.Blend.Factors = color.Factors;
						linearGradientBrush.Blend.Positions = color.Positions;
						g.FillPath(linearGradientBrush, path);
					}
				}
			}
		}

		public static void FillRectangle(Graphics g, RoundRectangle roundRect, Color color)
		{
			if (roundRect.Rect.Width > 0 && roundRect.Rect.Height > 0)
			{
				using (GraphicsPath path = roundRect.ToGraphicsBezierPath())
				{
					using (Brush brush = new SolidBrush(color))
					{
						g.FillPath(brush, path);
					}
				}
			}
		}

		public static void FillPath(Graphics g, GraphicsPath path, Rectangle rect, GradientColor color)
		{
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, color.First, color.Second, LinearGradientMode.Vertical))
			{
				linearGradientBrush.Blend.Factors = color.Factors;
				linearGradientBrush.Blend.Positions = color.Positions;
				g.FillPath(linearGradientBrush, path);
			}
		}

		public static void FillPath(Graphics g, RoundRectangle roundRect, Color color1, Color color2, Blend blend)
		{
			GradientColor color3 = new GradientColor(color1, color2, blend.Factors, blend.Positions);
			FillRectangle(g, roundRect, color3);
		}

		public static void FillPath(Graphics g, RoundRectangle roundRect, Color color1, Color color2)
		{
			if (roundRect.Rect.Width > 0 && roundRect.Rect.Height > 0)
			{
				using (GraphicsPath path = roundRect.ToGraphicsBezierPath())
				{
					using (LinearGradientBrush brush = new LinearGradientBrush(roundRect.Rect, color1, color2, LinearGradientMode.Vertical))
					{
						g.FillPath(brush, path);
					}
				}
			}
		}

		public static void DrawPathBorder(Graphics g, GraphicsPath path, Color color)
		{
			using (Pen pen = new Pen(color, 1f))
			{
				g.DrawPath(pen, path);
			}
		}

		public static void DrawPathBorder(Graphics g, RoundRectangle roundRect, Color color, int borderWidth)
		{
			using (GraphicsPath path = roundRect.ToGraphicsBezierPath())
			{
				using (Pen pen = new Pen(color, (float)borderWidth))
				{
					g.DrawPath(pen, path);
				}
			}
		}

		public static void DrawPathBorder(Graphics g, RoundRectangle roundRect, Color color)
		{
			DrawPathBorder(g, roundRect, color, 1);
		}

		public static void DrawPathInnerBorder(Graphics g, RoundRectangle roundRect, Color color)
		{
			Rectangle rect = roundRect.Rect;
			rect.X++;
			rect.Y++;
			rect.Width -= 2;
			rect.Height -= 2;
			DrawPathBorder(g, new RoundRectangle(rect, roundRect.CornerRadius), color);
		}

		public static void DrawPathOuterBorder(Graphics g, RoundRectangle roundRect, Color color)
		{
			Rectangle rect = roundRect.Rect;
			rect.X--;
			rect.Y--;
			rect.Width += 2;
			rect.Height += 2;
			DrawPathBorder(g, new RoundRectangle(rect, roundRect.CornerRadius), color);
		}

		public static void DrawPathOuterBorder(Graphics g, RoundRectangle roundRect, Color color, int borderWidth)
		{
			Rectangle rect = roundRect.Rect;
			rect.X--;
			rect.Y--;
			rect.Width += 2;
			rect.Height += 2;
			DrawPathBorder(g, new RoundRectangle(rect, roundRect.CornerRadius), color, borderWidth);
		}

		public static void DrawPathBorder(Graphics g, RoundRectangle roundRect)
		{
			DrawPathBorder(g, roundRect, SkinManager.CurrentSkin.BorderColor);
		}

		public static void DrawPathInnerBorder(Graphics g, RoundRectangle roundRect)
		{
			Color innerBorderColor = SkinManager.CurrentSkin.InnerBorderColor;
			DrawPathInnerBorder(g, roundRect, innerBorderColor);
		}

		public static void DrawPathOuterBorder(Graphics g, RoundRectangle roundRect)
		{
			DrawPathOuterBorder(g, roundRect, SkinManager.CurrentSkin.OuterBorderColor);
		}

		public static void DrawGradientLine(Graphics g, Color lineColor, Blend blend, int angle, int lineWidth, int x1, int y1, int x2, int y2)
		{
			Color color = Color.FromArgb(10, lineColor);
			Rectangle rect = new Rectangle(x1, y1, x2 - x1 + 1, y2 - y1 + 1);
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, lineColor, color, (float)angle))
			{
				linearGradientBrush.Blend = blend;
				using (Pen pen = new Pen(linearGradientBrush, (float)lineWidth))
				{
					g.SmoothingMode = SmoothingMode.AntiAlias;
					g.DrawLine(pen, x1, y1, x2, y2);
				}
			}
		}

		public static void DrawGradientLine(Graphics g, Color lineColor, int angle, int x1, int y1, int x2, int y2)
		{
			Blend blend = new Blend();
			blend.Positions = new float[5]
			{
				0f,
				0.15f,
				0.5f,
				0.85f,
				1f
			};
			blend.Factors = new float[5]
			{
				1f,
				0.4f,
				0f,
				0.4f,
				1f
			};
			DrawGradientLine(g, lineColor, blend, angle, 1, x1, y1, x2, y2);
		}

		public static void SetImageOpacity(ImageAttributes imgAttributes, float opacity)
		{
			float[][] newColorMatrix = new float[5][]
			{
				new float[5]
				{
					1f,
					0f,
					0f,
					0f,
					0f
				},
				new float[5]
				{
					0f,
					1f,
					0f,
					0f,
					0f
				},
				new float[5]
				{
					0f,
					0f,
					1f,
					0f,
					0f
				},
				new float[5]
				{
					0f,
					0f,
					0f,
					opacity,
					0f
				},
				new float[5]
				{
					0f,
					0f,
					0f,
					0f,
					1f
				}
			};
			ColorMatrix newColorMatrix2 = new ColorMatrix(newColorMatrix);
			imgAttributes.SetColorMatrix(newColorMatrix2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
		}

		public static void DrawArrow(Graphics g, System.Windows.Forms.ArrowDirection direction, Rectangle rect, Size arrowSize)
		{
			float offset = 1.8f;
			DrawArrow(g, direction, rect, arrowSize, offset, Color.FromArgb(55, 63, 78));
		}

		public static void DrawArrow(Graphics g, System.Windows.Forms.ArrowDirection direction, Rectangle rect, Size arrowSize, float offset, Color c)
		{
			Point point = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				PointF[] points = null;
				switch (direction)
				{
				case System.Windows.Forms.ArrowDirection.Down:
					points = new PointF[4]
					{
						new PointF((float)point.X, (float)(point.Y + arrowSize.Height / 2)),
						new PointF((float)(point.X - arrowSize.Width / 2), (float)(point.Y - arrowSize.Height / 2)),
						new PointF((float)point.X, (float)(point.Y - arrowSize.Height / 2) + offset),
						new PointF((float)(point.X + arrowSize.Width / 2), (float)(point.Y - arrowSize.Height / 2))
					};
					break;
				case System.Windows.Forms.ArrowDirection.Up:
					points = new PointF[4]
					{
						new PointF((float)point.X, (float)(point.Y - arrowSize.Height / 2)),
						new PointF((float)(point.X - arrowSize.Width / 2), (float)(point.Y + arrowSize.Height / 2)),
						new PointF((float)point.X, (float)(point.Y + arrowSize.Height / 2) - offset),
						new Point(point.X + arrowSize.Width / 2, point.Y + arrowSize.Height / 2)
					};
					break;
				case System.Windows.Forms.ArrowDirection.Left:
					points = new PointF[4]
					{
						new PointF((float)(point.X - arrowSize.Width / 2), (float)point.Y),
						new PointF((float)(point.X + arrowSize.Width / 2), (float)(point.Y - arrowSize.Height / 2)),
						new PointF((float)(point.X + arrowSize.Width / 2) - offset, (float)point.Y),
						new PointF((float)(point.X + arrowSize.Width / 2), (float)(point.Y + arrowSize.Height / 2))
					};
					break;
				case System.Windows.Forms.ArrowDirection.Right:
					points = new PointF[4]
					{
						new PointF((float)(point.X + arrowSize.Width / 2), (float)point.Y),
						new PointF((float)(point.X - arrowSize.Width / 2), (float)(point.Y - arrowSize.Height / 2)),
						new PointF((float)(point.X - arrowSize.Width / 2) + offset, (float)point.Y),
						new PointF((float)(point.X - arrowSize.Width / 2), (float)(point.Y + arrowSize.Height / 2))
					};
					break;
				}
				graphicsPath.AddLines(points);
				using (Brush brush = new SolidBrush(c))
				{
					g.FillPath(brush, graphicsPath);
				}
			}
		}

		public static void DrawCrystalButton(Graphics g, Rectangle rect, Color surroundColor, Color centerColor, Color lightColor, Blend blend)
		{
			Rectangle rectangle = rect;
			rectangle.Inflate(-1, -1);
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddEllipse(rect);
				using (PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath))
				{
					pathGradientBrush.WrapMode = WrapMode.Clamp;
					pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(rect.Left + rect.Width / 2), Convert.ToSingle(rect.Bottom));
					pathGradientBrush.CenterColor = centerColor;
					pathGradientBrush.SurroundColors = new Color[1]
					{
						surroundColor
					};
					pathGradientBrush.Blend = blend;
					g.FillPath(pathGradientBrush, graphicsPath);
				}
			}
			Rectangle rect2 = new Rectangle(0, 0, rect.Width / 2, rect.Height / 2);
			rect2.X = rect.X + (rect.Width - rect2.Width) / 2;
			rect2.Y = rect.Y + rect.Height / 2;
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddEllipse(rect2);
				using (PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath))
				{
					pathGradientBrush.WrapMode = WrapMode.Clamp;
					pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(rect.Left + rect.Width / 2), Convert.ToSingle(rect.Bottom));
					pathGradientBrush.CenterColor = Color.White;
					pathGradientBrush.SurroundColors = new Color[1]
					{
						Color.Transparent
					};
					g.FillPath(pathGradientBrush, graphicsPath);
				}
			}
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				int num = 160;
				int num2 = 180 + (180 - num) / 2;
				graphicsPath.AddArc(rectangle, (float)num2, (float)num);
				Point point = Point.Round(graphicsPath.PathData.Points[0]);
				Point point2 = Point.Round(graphicsPath.PathData.Points[graphicsPath.PathData.Points.Length - 1]);
				Point point3 = new Point(rectangle.Left + rectangle.Width / 2, point2.Y - 3);
				graphicsPath.AddCurve(new Point[3]
				{
					point2,
					point3,
					point
				});
				using (PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath))
				{
					pathGradientBrush.WrapMode = WrapMode.Clamp;
					pathGradientBrush.CenterPoint = point3;
					pathGradientBrush.CenterColor = Color.Transparent;
					pathGradientBrush.SurroundColors = new Color[1]
					{
						lightColor
					};
					blend = new Blend(3);
					blend.Factors = new float[3]
					{
						0.3f,
						0.8f,
						1f
					};
					blend.Positions = new float[3]
					{
						0f,
						0.5f,
						1f
					};
					pathGradientBrush.Blend = blend;
					g.FillPath(pathGradientBrush, graphicsPath);
				}
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(rect.Left, rect.Top), new Point(rect.Left, point.Y), Color.White, Color.Transparent))
				{
					blend = new Blend(4);
					blend.Factors = new float[4]
					{
						0f,
						0.4f,
						0.8f,
						1f
					};
					blend.Positions = new float[4]
					{
						0f,
						0.3f,
						0.4f,
						1f
					};
					linearGradientBrush.Blend = blend;
					g.FillPath(linearGradientBrush, graphicsPath);
				}
			}
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				int num = 160;
				int num2 = 180 + (180 - num) / 2;
				graphicsPath.AddArc(rectangle, (float)num2, (float)num);
				using (Pen pen = new Pen(Color.White))
				{
					g.DrawPath(pen, graphicsPath);
				}
			}
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				int num = 160;
				int num2 = (180 - num) / 2;
				graphicsPath.AddArc(rectangle, (float)num2, (float)num);
				Point point4 = Point.Round(graphicsPath.PathData.Points[0]);
				Rectangle rect3 = rectangle;
				rect3.Inflate(-1, -1);
				num = 160;
				num2 = (180 - num) / 2;
				graphicsPath.AddArc(rect3, (float)num2, (float)num);
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(rectangle.Left, rectangle.Bottom), new Point(rectangle.Left, point4.Y - 1), lightColor, Color.FromArgb(50, lightColor)))
				{
					g.FillPath(linearGradientBrush, graphicsPath);
				}
			}
		}

		public static void DrawEllipseBorder(Graphics g, Rectangle rect, Color color, int borderWidth)
		{
			using (Pen pen = new Pen(color, (float)borderWidth))
			{
				g.DrawEllipse(pen, rect);
			}
		}

		public static void FillEllipse(Graphics g, Rectangle rect, Color color)
		{
			using (SolidBrush brush = new SolidBrush(color))
			{
				g.FillEllipse(brush, rect);
			}
		}

		public static void FillEllipse(Graphics g, Rectangle rect, Color color1, Color color2)
		{
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddEllipse(rect);
				using (PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath))
				{
					pathGradientBrush.CenterColor = color1;
					pathGradientBrush.SurroundColors = new Color[1]
					{
						color2
					};
					Blend blend = new Blend();
					blend.Factors = new float[3]
					{
						0f,
						0.8f,
						1f
					};
					blend.Positions = new float[3]
					{
						0f,
						0.5f,
						1f
					};
					pathGradientBrush.Blend = blend;
					g.FillPath(pathGradientBrush, graphicsPath);
				}
			}
		}

		public static void DrawCheckedState(Graphics g, Rectangle rect, Color color)
		{
			PointF[] points = new PointF[3]
			{
				new PointF((float)rect.X + (float)rect.Width / 5f, (float)rect.Y + (float)rect.Height / 2.5f),
				new PointF((float)rect.X + (float)rect.Width / 2.5f, (float)rect.Bottom - (float)rect.Height / 3.6f),
				new PointF((float)rect.Right - (float)rect.Width / 5f, (float)rect.Y + (float)rect.Height / 7f)
			};
			using (Pen pen = new Pen(color, 2f))
			{
				g.SmoothingMode = SmoothingMode.AntiAlias;
				g.CompositingQuality = CompositingQuality.HighQuality;
				g.DrawLines(pen, points);
			}
		}

		public static void DrawCheckedStateByImage(Graphics g, Rectangle rect)
		{
			rect.Inflate(-1, -1);
			g.DrawImage(Resources.check, rect);
		}

		public static void DrawCheckedState(Graphics g, Rectangle rect)
		{
			DrawCheckedState(g, rect, Color.Green);
		}

		public static void DrawCheckBox(Graphics g, RoundRectangle roundRect)
		{
			using (GraphicsPath path = roundRect.ToGraphicsBezierPath())
			{
				using (PathGradientBrush pathGradientBrush = new PathGradientBrush(path))
				{
					pathGradientBrush.CenterColor = SkinManager.CurrentSkin.BaseColor;
					pathGradientBrush.SurroundColors = new Color[1]
					{
						SkinManager.CurrentSkin.BorderColor
					};
					Blend blend = new Blend();
					blend.Positions = new float[3]
					{
						0f,
						0.18f,
						1f
					};
					blend.Factors = new float[3]
					{
						0f,
						0.89f,
						1f
					};
					pathGradientBrush.Blend = blend;
					g.FillPath(pathGradientBrush, path);
				}
				DrawPathBorder(g, roundRect);
			}
		}

		public static Color GetOppositeColor(Color sourceColor)
		{
			return Color.FromArgb(255 - sourceColor.A, 255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);
		}
	}
}
