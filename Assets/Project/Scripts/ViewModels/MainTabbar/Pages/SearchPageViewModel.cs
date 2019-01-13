using System;
using System.Collections.Generic;
using System.Linq;
using UnityWeld.Binding;

[Binding]
public class SearchPageViewModel : BaseViewModel
{
	private Single scrollAmount;
	private string search;
	private List<Data> datas;

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
	public string Search
	{
		get
		{
			return this.search;
		}
		set
		{
			this.Set(ref this.search, value, nameof(this.Search));
		}
	}

	[Binding]
	public List<Data> Datas
	{
		get
		{
			return this.datas;
		}
		set
		{
			this.Set(ref this.datas, value, nameof(this.Datas));
		}
	}

	public void SetScrollAmount(float y)
	{
		this.ScrollAmount = (0.2f) + 1 - y;
	}

	[Binding]
	public void MakeSearch()
	{
		string keywords = this.Search;
		this.Datas = UserLogic.Instance.User.Datas.Where(w => w.Description.Contains(keywords)).ToList();
	}
}
