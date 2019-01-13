using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class SearchResultViewModel : BaseViewModel
{
	private Data data = new Data();

	#region Properties
	[Binding]
	public string Date
	{
		get
		{
			return this.data.DateTime.ToString("dddd MMMM yyyy");
		}
	}

	[Binding]
	public string Description
	{
		get
		{
			return this.data.Description;
		}
	}

	[Binding]
	public string AverageFeelings
	{
		get
		{
			if(this.data?.Feelings != null)
			{

				int value = 0;
				foreach(var feeling in this.data?.Feelings)
				{
					value += feeling.Value;
				}
				value = value / 5;

				return $"Moyenne de la journée : <size=120%>{value.ToString("0.0")}</size>/5";
				;
			}
			return string.Empty;
		}
	}
	#endregion

	public void SetModel(Data data)
	{
		this.data = data;
		this.RaiseAllPropertyChanged(typeof(SearchResultViewModel));
	}
}
