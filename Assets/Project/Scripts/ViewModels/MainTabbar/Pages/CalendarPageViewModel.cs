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
	public bool HasPoints
	{
		get
		{
			return (this.Points != null && this.Points.Count != 0);
		}
	}

	private void Start()
	{
		this.DateTime = DateTime.Now;
		this.ExtractDatas();
	}

	private void ExtractDatas()
	{
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
				totalValue += feeling.Value;
				totalValue = totalValue / 5;
			}
			
			points.Add(new Vector3(data.DateTime.Day, totalValue , 0));
		}

		this.Points = points;
	}

	[Binding]
	public void ChangeMonth(string add)
	{
		int.TryParse(add, out int addInt);
		this.DateTime = this.DateTime.AddMonths(addInt);
	}

	public void SetScrollAmount(float y)
	{
		this.ScrollAmount = (0.2f) + 1 - y;
	}
}
