using CIT.Client.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace CIT.Client
{
	public class PopForm : BaseForm
	{
		private SoundPlayer _Player;

		private IContainer components = null;

		public int CloseFormTimeLag
		{
			get;
			set;
		}

		public int ShowFormTimelag
		{
			get;
			set;
		}

		public PopForm()
		{
			InitializeComponent();
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Opacity = 0.949999988079071;
			base.ShowInTaskbar = false;
			base.TopMost = true;
			base.CapitionLogo = Resources.naruto;
			CloseFormTimeLag = 1000;
			ShowFormTimelag = 400;
			base.StartPosition = FormStartPosition.Manual;
			base.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - base.Width, Screen.PrimaryScreen.WorkingArea.Height - base.Height);
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			Win32.AnimateWindow(base.Handle, CloseFormTimeLag, 589824);
			base.OnFormClosing(e);
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			if (_Player != null)
			{
				_Player.Stop();
				_Player.Dispose();
			}
			base.OnFormClosed(e);
		}

		protected override void OnLoad(EventArgs e)
		{
			Win32.AnimateWindow(base.Handle, ShowFormTimelag, 8);
			base.OnLoad(e);
		}

		protected void playSound(Stream fileStream)
		{
			if (_Player == null)
			{
				_Player = new SoundPlayer();
				_Player.Stream = fileStream;
				_Player.Play();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			Text = "PopForm";
		}
	}
}
