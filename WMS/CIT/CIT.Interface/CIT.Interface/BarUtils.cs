using System.Reflection;
using System.Text.RegularExpressions;

namespace CIT.Interface
{
	public class BarUtils
	{
		public static string DllPath = "";

		public static MethodInfo _methodInfo = null;

		public static object EntityObj = null;

		private bool RegBarHead(string head, string barcode)
		{
			Regex regex = new Regex("^" + head);
			Match match = regex.Match(barcode);
			return match.Success;
		}

		public MitBarcode MatchBarcode_UAES(string barcode)
		{
			MitBarcode mitBarcode = new MitBarcode();
			string[] array = barcode.Split('@');
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (RegBarHead("12S", text))
				{
					mitBarcode.vision = text.Remove(0, "12S".Length);
				}
				else if (RegBarHead("P", text))
				{
					string text2 = text.Remove(0, "P".Length);
					string[] array3 = text2.Split('-');
					mitBarcode.partNo = array3[0];
				}
				else if (RegBarHead("1P", text))
				{
					mitBarcode.manufacturerTypeNo = text.Remove(0, "1P".Length);
				}
				else if (RegBarHead("31P", text))
				{
					mitBarcode.orderNo = text.Remove(0, "31P".Length);
				}
				else if (RegBarHead("12V", text))
				{
					mitBarcode.supplierId = text.Remove(0, "12V".Length);
				}
				else if (RegBarHead("10V", text))
				{
					mitBarcode.supplierLoc = text.Remove(0, "10V".Length);
				}
				else if (RegBarHead("2P", text))
				{
					mitBarcode.index = text.Remove(0, "2P".Length);
				}
				else if (RegBarHead("20P", text))
				{
					mitBarcode.addInfo = text.Remove(0, "20P".Length);
				}
				else if (RegBarHead("6D", text))
				{
					mitBarcode.makeDate = text.Remove(0, "6D".Length);
				}
				else if (RegBarHead("14D", text))
				{
					mitBarcode.expDate = text.Remove(0, "14D".Length);
				}
				else if (RegBarHead("30P", text))
				{
					mitBarcode.roHs = text.Remove(0, "30P".Length);
				}
				else if (RegBarHead("Z", text))
				{
					string text3 = text.Remove(0, "Z".Length).Trim();
					mitBarcode.msLevel = (string.IsNullOrEmpty(text3) ? "N" : text3);
				}
				else if (RegBarHead("K", text))
				{
					mitBarcode.purchaseNo = text.Remove(0, "K".Length);
				}
				else if (RegBarHead("16K", text))
				{
					mitBarcode.shippingNote = text.Remove(0, "16K".Length);
				}
				else if (RegBarHead("V", text))
				{
					string text5 = mitBarcode.supplNo = text.Remove(0, "V".Length).Trim();
				}
				else if (RegBarHead("3S", text))
				{
					mitBarcode.packageId = text.Remove(0, "3S".Length);
				}
				else if (RegBarHead("Q", text))
				{
					string text6 = text.Remove(0, "Q".Length).Trim();
					text6 = (string.IsNullOrEmpty(text6) ? "0" : text6.Replace("NAR", "@").Split('@')[0]);
					mitBarcode.quantity = int.Parse(text6);
				}
				else if (RegBarHead("20T", text))
				{
					mitBarcode.count = int.Parse(text.Remove(0, "20T".Length));
				}
				else if (RegBarHead("1T", text))
				{
					mitBarcode.batch1 = text.Remove(0, "1T".Length);
				}
				else if (RegBarHead("2T", text))
				{
					mitBarcode.batch2 = text.Remove(0, "2T".Length);
				}
				else if (RegBarHead("1Z", text))
				{
					mitBarcode.supplierData = text.Remove(0, "1Z".Length);
				}
			}
			return mitBarcode;
		}
	}
}
