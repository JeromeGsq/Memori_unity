﻿using System.ComponentModel;
using UnityEngine;

public abstract class UnityViewModel : MonoBehaviour, IViewModel, INotifyPropertyChanged
{
	public object Parameters
	{
		get;
		set;
	}

	public event PropertyChangedEventHandler PropertyChanged;

	public void SetParameters<T>(T parameters)
	{
		this.Parameters = parameters;
	}

	protected void Set<T>(ref T property,  object value, string propertyName)
	{
		property = (T)value;
		this.OnPropertyChanged(propertyName);
	}

	protected void OnPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
