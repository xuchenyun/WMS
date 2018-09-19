using System.Windows.Forms;

namespace CIT.Client
{
	public class MsgBox
	{
		private static MyMsgFrm myMfr = new MyMsgFrm();

		public static DialogResult Waring(string caption, string text)
		{
			Loading.Hide();
			myMfr = new MyMsgFrm(caption, text, EnumMessageBox.Warning);
			myMfr.ShowDialog();
			return myMfr.DialogResult;
		}

		public static DialogResult Waring(string text)
		{
			Loading.Hide();
			myMfr = new MyMsgFrm("开铭智能温馨提示", text, EnumMessageBox.Warning);
			myMfr.ShowDialog();
			return myMfr.DialogResult;
		}

		public static DialogResult Error(string caption, string text)
		{
			Loading.Hide();
			myMfr = new MyMsgFrm(caption, text, EnumMessageBox.Error);
			myMfr.ShowDialog();
			return myMfr.DialogResult;
		}

		public static DialogResult Error(string text)
		{
			Loading.Hide();
			myMfr = new MyMsgFrm("开铭智能温馨提示", text, EnumMessageBox.Error);
			myMfr.ShowDialog();
			return myMfr.DialogResult;
		}

		public static DialogResult Info(string caption, string text)
		{
			Loading.Hide();
			myMfr = new MyMsgFrm(caption, text, EnumMessageBox.Info);
			myMfr.ShowDialog();
			return myMfr.DialogResult;
		}

		public static DialogResult Info(string text)
		{
			Loading.Hide();
			myMfr = new MyMsgFrm("开铭智能温馨提示", text, EnumMessageBox.Info);
			myMfr.ShowDialog();
			return myMfr.DialogResult;
		}

		public static DialogResult Question(string caption, string text)
		{
			Loading.Hide();
			myMfr = new MyMsgFrm(caption, text, EnumMessageBox.Question);
			myMfr.ShowDialog();
			return myMfr.DialogResult;
		}

		public static DialogResult Question(string text)
		{
			Loading.Hide();
			myMfr = new MyMsgFrm("开铭智能温馨提示", text, EnumMessageBox.Question);
			myMfr.ShowDialog();
			return myMfr.DialogResult;
		}
	}
}
