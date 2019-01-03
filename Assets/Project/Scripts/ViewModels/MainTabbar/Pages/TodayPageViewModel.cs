using System;
using UnityWeld.Binding;

[Binding]
public class TodayPageViewModel : BaseViewModel
{
	private int index = 0;

	private string today;


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

	private void Start()
	{
		this.Prepare();

		this.Today = "Hello";
	}

	private void Prepare()
	{
		this.index = (int)this.Parameters;
	}
}
