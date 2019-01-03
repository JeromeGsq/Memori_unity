using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MainTabbarViewModel))]
public class MainTabbarView : BaseView<MainTabbarViewModel>
{
	[SerializeField]
	private Transform pagesAnchor;

	[SerializeField]
	private List<GameObject> pagesViews = new List<GameObject>();

	public override void Start()
	{
		base.Start();
	}

	public override void OnPropertyChanged(object sender, PropertyChangedEventArgs property)
	{
		base.OnPropertyChanged(sender, property);

		if(property.PropertyName == nameof(this.ViewModel.Tabs))
		{
			foreach(var item in this.ViewModel.Tabs)
			{
				var page = NavigationService.Instance.ShowViewModel(item.Item1, item.Item2, this.pagesAnchor);
				page.SetActive(item.Item2 == this.ViewModel.SelectedIndex);
				this.pagesViews.Add(page);
			}
		}
		else if(property.PropertyName == nameof(this.ViewModel.SelectedIndex))
		{
			for(int i = 0; i < this.pagesViews?.Count; i++)
			{
				this.pagesViews?[i]?.SetActive(i == this.ViewModel.SelectedIndex);
			}
		}
	}
}