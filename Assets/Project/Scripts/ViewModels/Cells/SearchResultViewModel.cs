using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchResultViewModel : BaseViewModel
{
	private SearchResult searchResult = new SearchResult();

	public SearchPageViewModel SearchPageViewModel
	{
		get;
		set;
	}

	public void SetModel(SearchResult searchResult, SearchPageViewModel searchPageViewModel)
	{
		this.SearchPageViewModel = searchPageViewModel;
		this.searchResult = searchResult;
		this.RaiseAllPropertyChanged(typeof(SearchResultViewModel));
	}
}
