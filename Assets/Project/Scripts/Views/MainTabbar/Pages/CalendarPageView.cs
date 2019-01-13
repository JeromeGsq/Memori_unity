using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CalendarPageViewModel))]
public class CalendarPageView : BasePageView<CalendarPageViewModel>
{
	[Space(20)]

	[SerializeField]
	private ChartRenderer chartRenderer;

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
	}

	public override void OnPropertyChanged(object sender, PropertyChangedEventArgs property)
	{
		base.OnPropertyChanged(sender, property);

		if(property.PropertyName == nameof(this.ViewModel.Points))
		{
			this.ConfigureColors();
			this.ConfigurePoints();
		}
	}

	private void ConfigureColors()
	{
		var gradient = new Gradient();

		switch(this.ViewModel.FeelingType)
		{
			case FeelingType.All:
				gradient = this.allGradient;
				break;
			case FeelingType.Food:
				gradient = this.foodGradient;
				break;
			case FeelingType.Social:
				gradient = this.socialGradient;
				break;
			case FeelingType.Power:
				gradient = this.powerGradient;
				break;
			case FeelingType.Entertainment:
				gradient = this.entertainmentGradient;
				break;
			case FeelingType.Love:
				gradient = this.loveGradient;
				break;
		}

		this.chartRenderer.DotImage.color = gradient.colorKeys[0].color;

		this.chartRenderer.Line.colorGradient = gradient;
	}

	private void ConfigurePoints()
	{
		this.chartRenderer.Points = this.ViewModel?.Points;
	}
}
