using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;

namespace BSE.Windows.Forms
{
	internal static class DisplayInformation
	{
		private static class NativeMethods
		{
			[DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
			public static extern int GetCurrentThemeName(StringBuilder pszThemeFileName, int dwMaxNameChars, StringBuilder pszColorBuff, int dwMaxColorChars, StringBuilder pszSizeBuff, int cchMaxSizeChars);
		}

		private const string m_strRegExpression = ".*\\.msstyles$";

		[ThreadStatic]
		private static bool m_bIsThemed;

		internal static bool IsThemed => m_bIsThemed;

		static DisplayInformation()
		{
			SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
			SetScheme();
		}

		private static void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
		{
			SetScheme();
		}

		private static void SetScheme()
		{
			if (VisualStyleRenderer.IsSupported && VisualStyleInformation.IsEnabledByUser)
			{
				StringBuilder stringBuilder = new StringBuilder(512);
				if (NativeMethods.GetCurrentThemeName(stringBuilder, stringBuilder.Capacity, null, 0, null, 0) == 0)
				{
					Regex regex = new Regex(".*\\.msstyles$");
					m_bIsThemed = regex.IsMatch(Path.GetFileName(stringBuilder.ToString()));
				}
			}
		}
	}
}
