using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class CalendarPageViewModel : BaseViewModel
{
	private DateTime dateTime;

	private Single scrollAmount;

	private List<Vector3> points;

	private FeelingType feelingType;

	private string lifeLevel;

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

	[Binding]
	public DateTime DateTime
	{
		get
		{
			return this.dateTime;
		}
		set
		{
			this.Set(ref this.dateTime, value, nameof(this.DateTime));
			this.ExtractDatas();
			this.RaisePropertyChanged(nameof(CurrentDateTime));
		}
	}

	[Binding]
	public string CurrentDateTime
	{
		get
		{
			return this.DateTime.ToString("MMMM yyyy");
		}
	}

	[Binding]
	public bool HasPoints
	{
		get
		{
			return (this.Points != null && this.Points.Count != 0);
		}
	}

	[Binding]
	public List<Vector3> Points
	{
		get
		{
			return this.points;
		}
		set
		{
			this.Set(ref this.points, value, nameof(this.Points));
			this.RaisePropertyChanged(nameof(this.HasPoints));
		}
	}

	[Binding]
	public FeelingType FeelingType
	{
		get
		{
			return this.feelingType;
		}
		set
		{
			this.Set(ref this.feelingType, value, nameof(this.FeelingType));
			this.RaisePropertyChanged(nameof(this.FeelingTypeName));
			this.ExtractDatas();
		}
	}

	[Binding]
	public string LifeLevel
	{
		get
		{
			return this.lifeLevel;
		}
		set
		{
			this.Set(ref this.lifeLevel, value, nameof(this.LifeLevel));
		}
	}

	[Binding]
	public string FeelingTypeName
	{
		get
		{
			switch(this.FeelingType)
			{
				case FeelingType.All:
					return "Tout";
				case FeelingType.Food:
					return "Nourriture";
				case FeelingType.Social:
					return "Social";
				case FeelingType.Power:
					return "Energie";
				case FeelingType.Entertainment:
					return "Divertissement";
				case FeelingType.Love:
					return "Amour";
				default:
					return "-";
			}
		}
	}

	private void Start()
	{
		this.FeelingType = FeelingType.All;
		this.DateTime = DateTime.Now;
	}

	private void ExtractDatas()
	{
		// Points
		List<Vector3> points = new List<Vector3>();
		var datas = UserLogic.Instance.User.Datas
			.Where(w => w.DateTime.Year == this.dateTime.Year)
			.Where(w => w.DateTime.Month == this.dateTime.Month)
			.OrderBy(w => w.DateTime)
			.ToList();

		foreach(var data in datas)
		{
			float totalValue = 0;

			foreach(var feeling in data.Feelings)
			{
				if(this.FeelingType == FeelingType.All)
				{
					totalValue += feeling.Value;
				}
				else if(this.FeelingType == feeling.FeelingType)
				{
					totalValue += feeling.Value;
				}
			}

			if(this.FeelingType == FeelingType.All)
			{
				totalValue = totalValue / 5;
			}
			
			points.Add(new Vector3(data.DateTime.Day, totalValue, 0));
		}

		this.Points = points;

		// Life level
		float lifeLevel = 0;

		foreach(var point in this.Points)
		{
			lifeLevel += point.y;
		}

		lifeLevel = lifeLevel / this.Points.Count;

		if(float.IsNaN(lifeLevel) || lifeLevel == 0)
		{
			this.LifeLevel = $"Niveau de vie : <size=120%>-</size>";
		}
		else
		{
			this.LifeLevel = $"Niveau de vie : <size=120%>{lifeLevel.ToString("0.0")}</size>/5";
		}
	}

	[Binding]
	public void ChangeMonth(string add)
	{
		int.TryParse(add, out int addInt);
		this.DateTime = this.DateTime.AddMonths(addInt);
	}

	[Binding]
	public void ChangeFeelingType(string add)
	{
		int.TryParse(add, out int addInt);
		var index = (int)this.FeelingType + addInt;

		// Here, last is Love = 5
		var lastEnumIndex = Enum.GetValues(typeof(FeelingType)).Cast<int>().Last();

		if(index < 0)
		{
			index = lastEnumIndex;
		}
		else if(index > lastEnumIndex)
		{
			index = 0;
		}

		this.FeelingType = (FeelingType)index;
	}

	public void SetScrollAmount(float y)
	{
		this.ScrollAmount = (0.2f) + 1 - y;
	}
}
