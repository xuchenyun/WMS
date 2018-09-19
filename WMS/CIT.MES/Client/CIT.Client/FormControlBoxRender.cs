using System.Drawing;
using System.Drawing.Drawing2D;

namespace CIT.Client
{
	internal class FormControlBoxRender
	{
		public GraphicsPath CreateCloseFlagPoints(Rectangle rect)
		{
			PointF pointF = new PointF((float)rect.X + (float)rect.Width / 2f, (float)rect.Y + (float)rect.Height / 2f);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(pointF.X, pointF.Y - 2f, pointF.X - 2f, pointF.Y - 4f);
			graphicsPath.AddLine(pointF.X - 2f, pointF.Y - 4f, pointF.X - 6f, pointF.Y - 4f);
			graphicsPath.AddLine(pointF.X - 6f, pointF.Y - 4f, pointF.X - 2f, pointF.Y);
			graphicsPath.AddLine(pointF.X - 2f, pointF.Y, pointF.X - 6f, pointF.Y + 4f);
			graphicsPath.AddLine(pointF.X - 6f, pointF.Y + 4f, pointF.X - 2f, pointF.Y + 4f);
			graphicsPath.AddLine(pointF.X - 2f, pointF.Y + 4f, pointF.X, pointF.Y + 2f);
			graphicsPath.AddLine(pointF.X, pointF.Y + 2f, pointF.X + 2f, pointF.Y + 4f);
			graphicsPath.AddLine(pointF.X + 2f, pointF.Y + 4f, pointF.X + 6f, pointF.Y + 4f);
			graphicsPath.AddLine(pointF.X + 6f, pointF.Y + 4f, pointF.X + 2f, pointF.Y);
			graphicsPath.AddLine(pointF.X + 2f, pointF.Y, pointF.X + 6f, pointF.Y - 4f);
			graphicsPath.AddLine(pointF.X + 6f, pointF.Y - 4f, pointF.X + 2f, pointF.Y - 4f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		public GraphicsPath CreateMinimizeFlagPath(Rectangle rect)
		{
			PointF pointF = new PointF((float)rect.X + (float)rect.Width / 2f, (float)rect.Y + (float)rect.Height / 2.5f);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(new RectangleF(pointF.X - 6f, pointF.Y + 1f, 12f, 2f));
			return graphicsPath;
		}

		public GraphicsPath CreateMaximizeFlafPath(Rectangle rect, bool maximize)
		{
			PointF pointF = new PointF((float)rect.X + (float)rect.Width / 2f, (float)rect.Y + (float)rect.Height / 1.9f);
			GraphicsPath graphicsPath = new GraphicsPath();
			if (maximize)
			{
				graphicsPath.AddLine(pointF.X - 3f, pointF.Y - 2f, pointF.X - 6f, pointF.Y - 2f);
				graphicsPath.AddLine(pointF.X - 6f, pointF.Y - 3f, pointF.X - 6f, pointF.Y + 5f);
				graphicsPath.AddLine(pointF.X - 6f, pointF.Y + 5f, pointF.X + 3f, pointF.Y + 5f);
				graphicsPath.AddLine(pointF.X + 3f, pointF.Y + 5f, pointF.X + 3f, pointF.Y + 1f);
				graphicsPath.AddLine(pointF.X + 3f, pointF.Y + 1f, pointF.X + 6f, pointF.Y + 1f);
				graphicsPath.AddLine(pointF.X + 6f, pointF.Y + 1f, pointF.X + 6f, pointF.Y - 6f);
				graphicsPath.AddLine(pointF.X + 6f, pointF.Y - 6f, pointF.X - 3f, pointF.Y - 6f);
				graphicsPath.CloseFigure();
				graphicsPath.AddRectangle(new RectangleF(pointF.X - 4f, pointF.Y, 5f, 3f));
				graphicsPath.AddLine(pointF.X - 1f, pointF.Y - 4f, pointF.X + 4f, pointF.Y - 4f);
				graphicsPath.AddLine(pointF.X + 4f, pointF.Y - 4f, pointF.X + 4f, pointF.Y - 1f);
				graphicsPath.AddLine(pointF.X + 4f, pointF.Y - 1f, pointF.X + 3f, pointF.Y - 1f);
				graphicsPath.AddLine(pointF.X + 3f, pointF.Y - 1f, pointF.X + 3f, pointF.Y - 3f);
				graphicsPath.AddLine(pointF.X + 3f, pointF.Y - 3f, pointF.X - 1f, pointF.Y - 3f);
				graphicsPath.CloseFigure();
			}
			else
			{
				graphicsPath.AddRectangle(new RectangleF(pointF.X - 6f, pointF.Y - 4f, 12f, 8f));
				graphicsPath.AddRectangle(new RectangleF(pointF.X - 5f, pointF.Y - 1f, 10f, 4f));
			}
			return graphicsPath;
		}

		public void DrawControlBox(Graphics g, Rectangle rect, EnumControlState controlState)
		{
			GradientColor color;
			switch (controlState)
			{
			case EnumControlState.HeightLight:
				color = SkinManager.CurrentSkin.ControlBoxHeightLightColor;
				break;
			case EnumControlState.Focused:
				color = SkinManager.CurrentSkin.ControlBoxPressedColor;
				break;
			default:
				color = SkinManager.CurrentSkin.ControlBoxDefaultColor;
				break;
			}
			Rectangle rect2 = new Rectangle(rect.Left, rect.Bottom, rect.Width, 1);
			g.SetClip(rect2, CombineMode.Exclude);
			GDIHelper.FillRectangle(g, rect, color);
			Color borderColor = SkinManager.CurrentSkin.BorderColor;
			Color color2 = Color.FromArgb(10, borderColor);
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, borderColor, color2, 90f))
			{
				linearGradientBrush.Blend.Positions = color.Positions;
				linearGradientBrush.Blend.Factors = color.Factors;
				using (Pen pen = new Pen(linearGradientBrush, 1f))
				{
					g.DrawLine(pen, rect.X, rect.Y, rect.X, rect.Bottom);
				}
			}
			g.ResetClip();
		}

		public void DrawCloseBox(Graphics g, Rectangle rect, EnumControlState controlState, int radius)
		{
			GradientColor color;
			switch (controlState)
			{
			case EnumControlState.HeightLight:
				color = SkinManager.CurrentSkin.CloseBoxHeightLightColor;
				break;
			case EnumControlState.Focused:
				color = SkinManager.CurrentSkin.CloseBoxPressedColor;
				break;
			default:
				color = SkinManager.CurrentSkin.ControlBoxDefaultColor;
				break;
			}
			Rectangle rect2 = new Rectangle(rect.Left, rect.Bottom, rect.Width, 1);
			g.SetClip(rect2, CombineMode.Exclude);
			GDIHelper.FillRectangle(g, new RoundRectangle(cornerRadius: new CornerRadius(0, radius + 2, 0, 0), rect: rect), color);
			Color borderColor = SkinManager.CurrentSkin.BorderColor;
			Color color2 = Color.FromArgb(10, borderColor);
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, borderColor, color2, 90f))
			{
				linearGradientBrush.Blend.Positions = color.Positions;
				linearGradientBrush.Blend.Factors = color.Factors;
				using (Pen pen = new Pen(linearGradientBrush, 1f))
				{
					g.DrawLine(pen, rect.X, rect.Y, rect.X, rect.Bottom);
				}
			}
			g.ResetClip();
		}
	}
}
