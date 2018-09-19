using System.Windows.Forms;

namespace CIT.Client
{
	public class Loading
	{
		private delegate void MyDelegate(Control control, int alpha, bool isShowLoadingImage);

		private static OpaqueCommand cmd = new OpaqueCommand();

		public static void Show(Control ctr, MethodInvoker meth)
		{
			cmd.HideOpaqueLayer();
			cmd.ShowOpaqueLayer(ctr, 125, isShowLoadingImage: true, meth);
		}

		public static void Show(Control ctr, int count)
		{
			cmd.ShowOpaqueLayer(ctr, count, isShowLoadingImage: true, null);
		}

		public static void Show(Control ctr, int count, bool IsShow, MethodInvoker meth)
		{
			cmd.ShowOpaqueLayer(ctr, count, IsShow, meth);
		}

		public static void Hide()
		{
			cmd.HideOpaqueLayer();
		}
	}
}
