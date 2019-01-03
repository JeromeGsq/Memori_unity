using System;
using System.Collections.Generic;
using UnityWeld.Binding;

[Binding]
public class MainTabbarViewModel : BaseViewModel
{
	private List<Tuple<Type, int>> tabs;

	public List<Tuple<Type, int>> Tabs
	{
		get
		{
			return this.tabs;
		}
		set
		{
			this.Set(ref this.tabs, value, nameof(this.Tabs));
		}
	}

	private void Start()
	{
		StartCoroutine(CoroutineUtils.DelaySeconds(
			() =>
				{
					this.Tabs = new List<Tuple<Type, int>>{
						new Tuple<Type, int>(typeof(TodayPageViewModel), 0),
						new Tuple<Type, int>(typeof(TodayPageViewModel), 1),
						new Tuple<Type, int>(typeof(TodayPageViewModel), 2),
					};
				}, 
			1)
		);
	
	}
}
