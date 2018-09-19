using System;
using System.Windows.Forms;

namespace CIT.Client
{
	internal class OpaqueCommand
	{
		private MyOpaqueLayer m_OpaqueLayer = null;

		internal void ShowOpaqueLayer(Control control, int alpha, bool isShowLoadingImage, MethodInvoker meth)
		{
			try
			{
				string text = null;
				Random random = new Random(DateTime.Now.Millisecond);
				string msg = string.IsNullOrEmpty(text) ? BaseForm.iWaittingMessage[random.Next(0, BaseForm.iWaittingMessage.Length)] : text;
				m_OpaqueLayer = new MyOpaqueLayer(control, alpha, isShowLoadingImage, msg);
				control.Controls.Add(m_OpaqueLayer);
				m_OpaqueLayer.Dock = DockStyle.Fill;
				m_OpaqueLayer.BringToFront();
				m_OpaqueLayer.Enabled = true;
				m_OpaqueLayer.Visible = true;
				IAsyncResult asyncResult = meth.BeginInvoke(HideOpaqueLayer, meth);
			}
			catch
			{
			}
		}

		internal void HideOpaqueLayer()
		{
			try
			{
				if (m_OpaqueLayer != null)
				{
					m_OpaqueLayer.Visible = false;
					m_OpaqueLayer.Enabled = false;
				}
			}
			catch (Exception)
			{
			}
		}

		internal void HideOpaqueLayer(IAsyncResult results)
		{
			try
			{
				if (m_OpaqueLayer != null)
				{
					try
					{
						((MethodInvoker)results.AsyncState).EndInvoke(results);
					}
					catch (Exception)
					{
					}
					m_OpaqueLayer.Visible = false;
					m_OpaqueLayer.Enabled = false;
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
