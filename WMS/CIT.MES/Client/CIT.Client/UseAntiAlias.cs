using CIT.Client.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace CIT.Client
{
	public class UseAntiAlias : IDisposable
	{
		private Graphics m_graphics;

		private SmoothingMode m_smoothingMode;

		public UseAntiAlias(Graphics graphics)
		{
			if (graphics == null)
			{
				throw new ArgumentNullException("graphics", string.Format(CultureInfo.InvariantCulture, Resources.IDS_ArgumentException, new object[1]
				{
					"graphics"
				}));
			}
			m_graphics = graphics;
			m_smoothingMode = m_graphics.SmoothingMode;
			m_graphics.SmoothingMode = SmoothingMode.AntiAlias;
		}

		~UseAntiAlias()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				m_graphics.SmoothingMode = m_smoothingMode;
			}
		}
	}
}
