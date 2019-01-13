using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class ReminderViewModel : BaseViewModel
{
	private Reminder reminder = new Reminder();

	public RemindersPageViewModel RemindersPageViewModel {
		get;
		set;
	}

	#region Properties
	[Binding]
	public string Title
	{
		get
		{
			return this.reminder.Title;
		}
		set
		{
			this.reminder.Title = value;
			UserLogic.Instance.SaveUser();
		}
	}

	[Binding]
	public string Content
	{
		get
		{
			return this.reminder.Content;
		}
		set
		{
			this.reminder.Content = value;
			UserLogic.Instance.SaveUser();
		}
	}

	[Binding]
	public string Date
	{
		get
		{
			return this.reminder.DateTime.ToString("dd MMMM yyyy - HH:mm");
		}
	}
	#endregion

	[Binding]
	public void DeleteReminder()
	{
		RemindersPageViewModel.DeleteReminder(reminder);
	}

	public void SetModel(Reminder reminder, RemindersPageViewModel remindersPageViewModel)
	{
		this.RemindersPageViewModel = remindersPageViewModel;
		this.reminder = reminder;
		this.RaiseAllPropertyChanged(typeof(ReminderViewModel));
	}
}
