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

		this.ConfigurePoints();
	}

	public override void OnPropertyChanged(object sender, PropertyChangedEventArgs property)
	{
		base.OnPropertyChanged(sender, property);

		if(property.PropertyName == nameof(this.ViewModel.Points))
		{
			this.ConfigurePoints();
		}
	}

	private void ConfigurePoints()
	{
		this.chartRenderer.Points = this.ViewModel?.Points;
	}
}
