namespace CIT.Client
{
	internal enum AnimateWindowFlag
	{
		AW_HOR_POSITIVE = 1,
		AW_HOR_NEGATIVE = 2,
		AW_VER_POSITIVE = 4,
		AW_VER_NEGATIVE = 8,
		AW_CENTER = 0x10,
		AW_HIDE = 0x10000,
		AW_ACTIVATE = 0x20000,
		AW_SLIDE = 0x40000,
		AW_BLEND = 0x80000
	}
}
