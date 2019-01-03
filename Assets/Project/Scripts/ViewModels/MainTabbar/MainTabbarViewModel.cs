using System;
using System.Collections.Generic;
using UnityWeld.Binding;

[Binding]
public class MainTabbarViewModel : BaseViewModel
{
	private const int SELECTED_INDEX = 1;

	private int selectedIndex = SELECTED_INDEX;
	private List<Tuple<Type, int>> tabs;

	#region Properties
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

	public int SelectedIndex
	{
		get
		{
			return this.selectedIndex;
		}
		set
		{
			this.Set(ref this.selectedIndex, value, nameof(this.SelectedIndex));
		}
	}
	#endregion

	private void Start()
	{
		this.Tabs = new List<Tuple<Type, int>>{
			new Tuple<Type, int>(typeof(CalendarPageViewModel), 0),
			new Tuple<Type, int>(typeof(TodayPageViewModel), 1),
			new Tuple<Type, int>(typeof(SearchPageViewModel), 2),
		};
	}

	[Binding]
	public void SetTabIndex(string index)
	{
		int.TryParse(index, out int value);
		this.SelectedIndex = value;
	}
}