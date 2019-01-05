using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SearchPageViewModel))]
public class SearchPageView : BasePageView<SearchPageViewModel>
{
	[SerializeField]
	private Transform searchAnchor;

	[SerializeField]
	private GameObject searchPrefab;

	[SerializeField]
	private List<GameObject> searchViews;

	[Space(20)]

	[SerializeField]
	private ScrollRect scrollRect;

	public override void Start()
	{
		base.Start();

		this.ViewModel?.SetScrollAmount(1);
		this.scrollRect.onValueChanged.AddListener((vector) =>
		{
			if(this.scrollRect.content.sizeDelta.y > Screen.height)
			{
				this.ViewModel?.SetScrollAmount(this.scrollRect.verticalNormalizedPosition);
			}
			else
			{
				this.ViewModel?.SetScrollAmount(1);
			}
		});

		this.InitSearchResultViews(this.ViewModel?.SearchResult);

		LayoutRebuilder.MarkLayoutForRebuild(transform as RectTransform);
	}

	public override void OnEnable()
	{
		base.OnEnable();
		LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
		LayoutRebuilder.ForceRebuildLayoutImmediate(searchAnchor as RectTransform);
	}

	public override void OnPropertyChanged(object sender, PropertyChangedEventArgs property)
	{
		base.OnPropertyChanged(sender, property);

		if(property.PropertyName == nameof(this.ViewModel.SearchResult))
		{
			this.InitSearchResultViews(this.ViewModel.SearchResult);
		}
	}

	private void InitSearchResultViews(List<SearchResult> searchResults)
	{
		if(searchResults == null)
		{
			Debug.LogWarning("InitRemindersViews() : SearchResults are null");
			return;
		}

		foreach(var item in this.searchViews)
		{
			Destroy(item.gameObject);
		}

		Debug.Log("InitFeelingViews() : Generating searchResults cells");

		foreach(var searchResult in searchResults)
		{
			GameObject searchResultView = Instantiate(this.searchPrefab, this.searchAnchor);
			searchResultView.GetComponent<SearchResultViewModel>().SetModel(searchResult, this.ViewModel);
			this.searchViews.Add(searchResultView);
		}

		LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
		LayoutRebuilder.ForceRebuildLayoutImmediate(searchAnchor as RectTransform);
	}
}
