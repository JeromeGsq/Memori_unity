using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TodayPageViewModel))]
public class TodayPageView : BasePageView<TodayPageViewModel>
{
	[SerializeField]
	private ScrollRect scrollRect;

	public override void Start()
	{
		base.Start();

		this.scrollRect.onValueChanged.AddListener((vector) =>
		{
			this.ViewModel?.SetScrollAmount(this.scrollRect.verticalNormalizedPosition);
		});	
	}
}
