using CIT.Client.Properties;
using System;
using System.Drawing;

namespace CIT.Client
{
	public static class LoadResource
	{
		private static Bitmap[] loadImages;

		static LoadResource()
		{
			loadImages = new Bitmap[15];
			loadImages[0] = Resources.loading;
			loadImages[1] = Resources.loader1;
			loadImages[2] = Resources.loader2;
			loadImages[3] = Resources.loader3;
			loadImages[4] = Resources.loader4;
			loadImages[5] = Resources.loader5;
			loadImages[6] = Resources.loader6;
			loadImages[7] = Resources.loader7;
			loadImages[8] = Resources.loader8;
			loadImages[9] = Resources.loader9;
			loadImages[10] = Resources.loader10;
			loadImages[11] = Resources.loader11;
			loadImages[12] = Resources.loader12;
			loadImages[13] = Resources.loader13;
		}

		public static Bitmap GetRandomLoadImage()
		{
			Random random = new Random(DateTime.Now.Millisecond);
			int num = random.Next(0, loadImages.Length);
			Bitmap bitmap = loadImages[num];
			return (bitmap == null) ? Resources.loading : bitmap;
		}
	}
}
