using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchResultViewModel : BaseViewModel
{
	private Data data = new Data();

	public SearchPageViewModel SearchPageViewModel
	{
		get;
		set;
	}

	public void SetModel(Data data, SearchPageViewModel searchPageViewModel)
	{
		this.SearchPageViewModel = searchPageViewModel;
		this.data = data;
		this.RaiseAllPropertyChanged(typeof(SearchResultViewModel));
	}
}
