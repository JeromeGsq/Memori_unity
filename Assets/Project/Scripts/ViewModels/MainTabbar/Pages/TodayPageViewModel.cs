using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class TodayPageViewModel : BaseViewModel
{
	private int index = 0;

	private void Start()
	{
		this.index = (int)this.Parameters;
	}
}
