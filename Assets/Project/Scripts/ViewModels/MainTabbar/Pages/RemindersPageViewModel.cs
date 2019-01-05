using System;
using System.Collections.Generic;
using UnityWeld.Binding;

[Binding]
public class RemindersPageViewModel : BaseViewModel
{
	private Single scrollAmount;

	[Binding]
	public Single ScrollAmount
	{
		get
		{
			return this.scrollAmount;
		}
		set
		{
			this.Set(ref this.scrollAmount, value, nameof(this.ScrollAmount));
		}
	}

	public List<Reminder> Reminders
	{
		get
		{
			return UserLogic.Instance.User.Reminders;
		}
	}

	[Binding]
	public void AddReminder()
	{
		this.Reminders.Add(new Reminder().Init());
		this.RaisePropertyChanged(nameof(this.Reminders));
		UserLogic.Instance.SaveUser();
	}

	public void SetScrollAmount(float y)
	{
		this.ScrollAmount = (0.2f) + 1 - y;
	}

	public void DeleteReminder(Reminder reminder)
	{
		this.Reminders.Remove(reminder);
		this.RaisePropertyChanged(nameof(this.Reminders));
	}
}
