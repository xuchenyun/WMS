using CIT.Client.Properties;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;

namespace CIT.Client
{
	public class UseClearTypeGridFit : IDisposable
	{
		private Graphics m_graphics;

		private TextRenderingHint m_textRenderingHint;

		public UseClearTypeGridFit(Graphics graphics)
		{
			if (graphics == null)
			{
				throw new ArgumentNullException("graphics", string.Format(CultureInfo.InvariantCulture, Resources.IDS_ArgumentException, new object[1]
				{
					"graphics"
				}));
			}
			m_graphics = graphics;
			m_textRenderingHint = m_graphics.TextRenderingHint;
			m_graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		}

		~UseClearTypeGridFit()
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
				m_graphics.TextRenderingHint = m_textRenderingHint;
			}
		}
	}
}
