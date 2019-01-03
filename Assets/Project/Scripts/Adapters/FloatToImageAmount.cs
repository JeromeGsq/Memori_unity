using UnityEngine;
using UnityWeld.Binding;

[Adapter(typeof(string), typeof(float), typeof(FloatToImageAmountAdapterOptions))]
public class FloatToImageAmount : IAdapter
{
	public object Convert(object valueIn, AdapterOptions options)
	{
		var scale = ((FloatToImageAmountAdapterOptions)options).Scale;
		return ((float)valueIn) * scale;
	}
}

[CreateAssetMenu(menuName = "Unity MVVM/Adapter options/Float To Image [Options]")]
public class FloatToImageAmountAdapterOptions : AdapterOptions
{
	public float Scale = 1f;
}
