using System;
using System.ComponentModel;

public interface IViewModel
{
	object Parameters
	{
		get; set;
	}

	Action<object, string> PropertyChanged
	{
		get; set;
	}

	void SetParameters<T>(T parameters);
}