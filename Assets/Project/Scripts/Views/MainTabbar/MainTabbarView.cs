using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(MainTabbarViewModel))]
public class MainTabbarView : BaseView<MainTabbarViewModel>
{
	[SerializeField]
	private Transform pagesAnchor;

	public override void Start()
	{
		base.Start();
	}

	public override void OnPropertyChanged(object sender, string property)
	{
		base.OnPropertyChanged(sender, property);

		if(property == nameof(this.ViewModel.Tabs))
		{
			foreach(var item in this.ViewModel.Tabs)
			{
				NavigationService.Instance.ShowViewModel(item.Item1, item.Item2, this.pagesAnchor);
			}
		}
	}
}
