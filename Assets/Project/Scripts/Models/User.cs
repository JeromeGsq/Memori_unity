using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

public class User
{
	public string Name
	{
		get; set;
	}

	public List<Data> Datas
	{
		get;
		set;
	}

	public List<Reminder> Reminders
	{
		get;
		set;
	}

	[JsonIgnoreAttribute()]
	public Data CurrentData
	{
		get
		{
			var data = this.Datas.Where(w => w.DateTime.Date == DateTime.Now.Date).FirstOrDefault();
			return data;
		}
	}

	public User Init()
	{
		this.Name = "Hélène";
		this.Datas = new List<Data>();
		foreach(DateTime date in DateTimeExtension.AllDatesInMonth(2019, 1))
		{
			this.Datas.Add(new Data().Init(date));
		}
		this.Reminders = new List<Reminder>();
		return this;
	}
}

public class Reminder
{
	public DateTime DateTime
	{
		get;
		set;
	}

	public string Title
	{
		get;
		set;
	} 

	public string Content
	{
		get;
		set;
	}

	public Reminder Init()
	{
		this.DateTime = DateTime.Now;
		this.Title = "";
		this.Content = "";
		return this;
	}
}

public class Data
{
	public DateTime DateTime
	{
		get;
		set;
	}

	public List<Feeling> Feelings
	{
		get;
		set;
	}

	public string Description
	{
		get; set;
	}

	public Data Init(DateTime dateTime)
	{
		this.DateTime = dateTime.Date;
		this.Description = "";
		this.Feelings = new List<Feeling>()
		{
			new Feeling{
				FeelingType = FeelingType.Food,
				Title = "Faim",
			},
			new Feeling{
				FeelingType = FeelingType.Social,
				Title = "Social",
			},
			new Feeling{
				FeelingType = FeelingType.Power,
				Title = "Energie",
			},
			new Feeling{
				FeelingType = FeelingType.Entertainment,
				Title = "Divertissement",
			},
			new Feeling{
				FeelingType = FeelingType.Love,
				Title = "Amour",
			},
		};
		return this;
	}
}