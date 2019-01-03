using System;
using UnityWeld.Binding;

[Binding]
public class SliderViewModel : BaseViewModel
{
	private Feeling feeling = new Feeling();

	private float currentAmount = 3;
	private string rating;

	#region Properties
	[Binding]
	public float CurrentAmount
	{
		get
		{
			return this.currentAmount;
		}
		set
		{
			this.Set(ref this.currentAmount, value, nameof(this.CurrentAmount));
			this.OnPropertyChanged(nameof(this.Rating));
		}
	}

	[Binding]
	public string Rating
	{
		get
		{
			return $"{(int)this.CurrentAmount}/5" ;
		}
	}

	[Binding]
	public string Title
	{
		get
		{
			return this.feeling.Title;
		}
	}
	#endregion

	public void SetModel(Feeling feeling)
	{
		this.feeling = feeling;
		this.RaiseAllPropertyChanged(typeof(SliderViewModel));
	}
}
