using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CIT.Client.Docking
{
	public class FloatWindowCollection : ReadOnlyCollection<FloatWindow>
	{
		internal FloatWindowCollection()
			: base((IList<FloatWindow>)new List<FloatWindow>())
		{
		}

		internal int Add(FloatWindow fw)
		{
			if (base.Items.Contains(fw))
			{
				return base.Items.IndexOf(fw);
			}
			base.Items.Add(fw);
			return base.Count - 1;
		}

		internal void Dispose()
		{
			for (int num = base.Count - 1; num >= 0; num--)
			{
				base[num].Close();
			}
		}

		internal void Remove(FloatWindow fw)
		{
			base.Items.Remove(fw);
		}

		internal void BringWindowToFront(FloatWindow fw)
		{
			base.Items.Remove(fw);
			base.Items.Add(fw);
		}
	}
}
