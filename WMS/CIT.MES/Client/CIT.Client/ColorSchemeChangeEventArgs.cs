using System;

namespace CIT.Client
{
	public class ColorSchemeChangeEventArgs : EventArgs
	{
		private ColorScheme m_eColorSchema;

		public ColorScheme ColorSchema => m_eColorSchema;

		public ColorSchemeChangeEventArgs(ColorScheme eColorSchema)
		{
			m_eColorSchema = eColorSchema;
		}
	}
}
