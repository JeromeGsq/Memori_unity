using UnityWeld.Binding;

[Binding]
public class SliderViewModel : BaseViewModel
{
	private Feeling feeling = new Feeling();

	private float currentAmount;
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
			this.RaisePropertyChanged(nameof(this.Rating));
		}
	}

	[Binding]
	public string Rating
	{
		get
		{
			return $"{(int)this.CurrentAmount}/5";
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
		this.CurrentAmount = this.feeling.Value;
		this.RaiseAllPropertyChanged(typeof(SliderViewModel));
	}

	private void OnDisable()
	{
		UserLogic.Instance?.SetFeelingValue(this.feeling.FeelingType, (int)this.CurrentAmount);
	}

	private void OnDestroy()
	{
		UserLogic.Instance?.SetFeelingValue(this.feeling.FeelingType, (int)this.CurrentAmount);
	}
}
