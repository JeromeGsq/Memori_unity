using System;
using System.Collections.Generic;
using UnityWeld.Binding;

[Binding]
public class TodayPageViewModel : BaseViewModel
{
	private int index = 0;

	private string hello;
	private string today;
	private string remainingTime;

	private float scrollAmount;

	#region Properties
	public User User
	{
		get; set;
	}

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

	public List<Feeling> Feelings
	{
		get
		{
			return UserLogic.Instance.User.Feelings;
		}
	}
	#endregion

	private void Prepare()
	{
		this.index = (int)this.Parameters;
	}

	private void Start()
	{
		this.Prepare();
		this.User = this.LoadUser();

		this.Today = DateTime.Now.ToString("dddd, dd MMMM yyyy");
		this.Hello = $"Hello, {this.User.Name}";

		this.RemainingTime = this.GetRemainingTime();
	}

	private User LoadUser()
	{
		return new User
		{
			Name = "Hélène"
		};
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
