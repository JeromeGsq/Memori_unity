using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TodayPageViewModel))]
public class TodayPageView : BasePageView<TodayPageViewModel>
{
	[SerializeField]
	private Transform feelingAnchor;

	[SerializeField]
	private GameObject feelingPrefab;

	[SerializeField]
	private List<GameObject> feelingViews;

	[Space(20)]

	[SerializeField]
	private ScrollRect scrollRect;

	public override void Start()
	{
		base.Start();

		this.scrollRect.onValueChanged.AddListener((vector) =>
		{
			this.ViewModel?.SetScrollAmount(this.scrollRect.verticalNormalizedPosition);
		});

		this.InitFeelingViews(this.ViewModel?.Feelings);
	}

	public override void OnPropertyChanged(object sender, PropertyChangedEventArgs property)
	{
		base.OnPropertyChanged(sender, property);

		if(property.PropertyName == nameof(this.ViewModel.Feelings))
		{
			 this.InitFeelingViews(this.ViewModel.Feelings);
		}
	}

	private void InitFeelingViews(List<Feeling> feelings)
	{
		if(feelings == null)
		{
			Debug.LogWarning("InitFeelingViews() : feelings are null");
			return;
		}

		Debug.LogWarning("InitFeelingViews() : generating feeling cells");

		foreach(var feeling in feelings)
		{
			GameObject feelingView = Instantiate(this.feelingPrefab, this.feelingAnchor);
			feelingView.GetComponent<SliderViewModel>().SetModel(feeling);
			this.feelingViews.Add(feelingView);
		}

		LayoutRebuilder.MarkLayoutForRebuild(transform as RectTransform);
	}
}
