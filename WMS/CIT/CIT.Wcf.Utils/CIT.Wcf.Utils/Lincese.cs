using CIT.LUtils.Common;
using System;

namespace CIT.LUtils
{
	public class Lincese
	{
		private bool deadline = false;

		private string deadmsg = "";

		private int deadday = 0;

		public LicObj Licobj
		{
			get;
			set;
		}

		public bool DeadLine
		{
			get
			{
				return deadline;
			}
			set
			{
				deadline = value;
				OnDeadLineChange();
			}
		}

		public string DeadMsg
		{
			get
			{
				return deadmsg;
			}
			set
			{
				deadmsg = value;
				OnDeadMsgChange();
			}
		}

		public int DeadDay
		{
			get
			{
				return deadday;
			}
			set
			{
				deadday = value;
				OnDeadDayChange();
			}
		}

		public event EventHandler DeadLineChange;

		public event EventHandler DeadMsgChange;

		public event EventHandler DeadDayChange;

		public void OnDeadLineChange()
		{
			if (this.DeadLineChange != null)
			{
				this.DeadLineChange(this, EventArgs.Empty);
			}
		}

		public void OnDeadMsgChange()
		{
			if (this.DeadMsgChange != null)
			{
				this.DeadMsgChange(this, EventArgs.Empty);
			}
		}

		public void OnDeadDayChange()
		{
			if (this.DeadDayChange != null)
			{
				this.DeadDayChange(this, EventArgs.Empty);
			}
		}
	}
}
