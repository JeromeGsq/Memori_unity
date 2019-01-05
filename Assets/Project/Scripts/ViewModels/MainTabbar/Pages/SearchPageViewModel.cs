using System;
using System.Collections.Generic;
using UnityWeld.Binding;

[Binding]
public class SearchPageViewModel : BaseViewModel
{
	private Single scrollAmount;

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

	public List<SearchResult> SearchResult
	{
		get
		{
			return null;
		}
	}

	public void SetScrollAmount(float y)
	{
		this.ScrollAmount = (0.2f) + 1 - y;
	}
}
