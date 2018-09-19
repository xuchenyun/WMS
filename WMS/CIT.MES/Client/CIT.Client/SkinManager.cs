using System;
using System.Windows.Forms;

namespace CIT.Client
{
	internal class SkinManager
	{
		private static SkinTheme _CurrentSkin;

		private static readonly string SkinFilePath = Application.StartupPath + "\\Config\\Skin.ini";

		private static readonly string SkinSectionName = "SkinManager";

		private static readonly string CurrentSkinName = "CurrentSkin";

		public static SkinTheme CurrentSkin
		{
			get
			{
				if (_CurrentSkin == null)
				{
					_CurrentSkin = GetSkinTeme();
				}
				return _CurrentSkin;
			}
		}

		private static SkinTheme GetSkinTeme()
		{
			try
			{
				IniConfig iniConfig = new IniConfig(SkinFilePath);
				int result = int.TryParse(iniConfig.IniReadValue(SkinSectionName, CurrentSkinName, "0"), out result) ? result : 0;
				switch (result.ToEnumByValue<EnumTheme>())
				{
				case EnumTheme.BlueSea:
					return new SkinThemeBlueSea();
				case EnumTheme.KissOfAngel:
					return new SkinThemeKissOfAngel();
				case EnumTheme.NoFlower:
					return new SkinThemeNoFlower();
				case EnumTheme.SunsetRed:
					return new SkinThemeSunsetRed();
				default:
					return new SkinThemeDefault();
				}
			}
			catch (Exception)
			{
				return new SkinThemeDefault();
			}
		}

		public static void SettingSkinTeme(EnumTheme theme)
		{
			switch (theme)
			{
			case EnumTheme.BlueSea:
				_CurrentSkin = new SkinThemeBlueSea();
				break;
			case EnumTheme.KissOfAngel:
				_CurrentSkin = new SkinThemeKissOfAngel();
				break;
			case EnumTheme.NoFlower:
				_CurrentSkin = new SkinThemeNoFlower();
				break;
			case EnumTheme.SunsetRed:
				_CurrentSkin = new SkinThemeSunsetRed();
				break;
			default:
				_CurrentSkin = new SkinThemeDefault();
				break;
			}
		}

		public static void Save()
		{
			try
			{
				IniConfig iniConfig = new IniConfig(SkinFilePath);
				iniConfig.IniWriteValue(SkinSectionName, CurrentSkinName, ((int)CurrentSkin.ThemeStyle).ToString());
			}
			catch (Exception ex)
			{
				MsgBox.Error($"保存主题信息出现异常：{ex.Message}\n");
			}
		}
	}
}
