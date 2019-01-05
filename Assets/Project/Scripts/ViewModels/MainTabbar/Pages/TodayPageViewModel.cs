using System;
using System.Collections.Generic;
using UnityWeld.Binding;

[Binding]
public class TodayPageViewModel : BaseViewModel
{
	private string hello;
	private string today;
	private string remainingTime;

	private float scrollAmount;
	private string description;

	#region Properties
	[Binding]
	public string Today
	{
		get
		{
			return this.today;
		}
		set
		{
			this.Set(ref this.today, value, nameof(this.Today));
		}
	}

	[Binding]
	public string Hello
	{
		get
		{
			return this.hello;
		}
		set
		{
			this.Set(ref this.hello, value, nameof(this.Hello));
		}
	}

	[Binding]
	public string RemainingTime
	{
		get
		{
			return this.remainingTime;
		}
		set
		{
			this.Set(ref this.remainingTime, value, nameof(this.RemainingTime));
		}
	}

	[Binding]
	public float ScrollAmount
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

	[Binding]
	public string Description
	{
		get
		{
			return this.description;
		}
		set
		{
			this.Set(ref this.description, value, nameof(this.Description));
			UserLogic.Instance.SetDescription(value);
		}
	}

	public List<Feeling> Feelings
	{
		get
		{
			return UserLogic.Instance.User.CurrentData.Feelings;
		}
	}
	#endregion

	private void Start()
	{
		this.Today = DateTime.Now.ToString("dddd, dd MMMM yyyy");
		this.Hello = $"Hello, {UserLogic.Instance.User.Name}";
		this.Description = UserLogic.Instance.User.CurrentData.Description;

		this.RemainingTime = this.GetRemainingTime();
	}

	private void OnEnable()
	{
		this.RemainingTime = this.GetRemainingTime();
	}

	private string GetRemainingTime()
	{
		DateTime now = DateTime.Now;
		int hours = 0, minutes = 0;
		hours = (24 - now.Hour) - 1;
		minutes = (60 - now.Minute) - 1;

		return $"Temps restant avant demain : {hours.ToString("00")}:{minutes.ToString("00")}";
	}

	public void SetScrollAmount(float y)
	{
		this.ScrollAmount = (0.1f) + 1 - y;
	}
}
