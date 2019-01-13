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

		this.InitFeelingViews(this.ViewModel?.Feelings);

		LayoutRebuilder.MarkLayoutForRebuild(transform as RectTransform);
	}

	public override void OnEnable()
	{
		base.OnEnable();
		LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
		LayoutRebuilder.ForceRebuildLayoutImmediate(feelingAnchor as RectTransform);
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

		foreach(var item in this.feelingViews)
		{
			Destroy(item.gameObject);
		}

		Debug.Log("InitFeelingViews() : Generating feeling cells");

		foreach(var feeling in feelings)
		{
			GameObject feelingView = Instantiate(this.feelingPrefab, this.feelingAnchor);
			SliderViewModel viewModel = feelingView.GetComponent<SliderViewModel>();
			viewModel.SetModel(feeling);
			switch(feeling.FeelingType)
			{
				case FeelingType.All:
					viewModel.SetGradient(this.allGradient);
					break;
				case FeelingType.Food:
					viewModel.SetGradient(this.foodGradient);
					break;
				case FeelingType.Social:
					viewModel.SetGradient(this.socialGradient);
					break;
				case FeelingType.Power:
					viewModel.SetGradient(this.powerGradient);
					break;
				case FeelingType.Entertainment:
					viewModel.SetGradient(this.entertainmentGradient);
					break;
				case FeelingType.Love:
					viewModel.SetGradient(this.loveGradient);
					break;
			}

			this.feelingViews.Add(feelingView);
		}

		LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
		LayoutRebuilder.ForceRebuildLayoutImmediate(feelingAnchor as RectTransform);
	}
}
