using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SliderViewModel))]
public class SliderView : BaseViewCell<SliderViewModel>
{
	[SerializeField]
	private Image fill;

	[SerializeField]
	private Image dot;

	public override void Start()
	{
		base.Start();
		this.ConfigureColors();
	}

	private void ConfigureColors()
	{
		if(this.ViewModel?.Gradient?.colorKeys != null && this.ViewModel?.Gradient?.colorKeys?.Length != 0)
		{
			var color = this.ViewModel.Gradient.colorKeys[0].color;
			this.fill.color = color;
			this.dot.color = new Color(color.r - 0.1f, color.g - 0.1f, color.b - 0.1f);
		}
	}

	public override void OnPropertyChanged(object sender, PropertyChangedEventArgs property)
	{
		base.OnPropertyChanged(sender, property);

		if(property.PropertyName == nameof(this.ViewModel.Gradient))
		{
			this.ConfigureColors();
		}
	}
}
