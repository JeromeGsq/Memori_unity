using System;
using System.Collections.Generic;
using UnityWeld.Binding;

[Binding]
public class RemindersPageViewModel : BaseViewModel
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

	public void SetScrollAmount(float y)
	{
		this.ScrollAmount = (0.2f) + 1 - y;
	}
}
