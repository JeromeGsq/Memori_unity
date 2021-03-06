﻿using System.Globalization;
using System.Threading;
using UnityEngine;

public class App : MonoBehaviour {

	protected void Start () {
		CultureInfo ci = new CultureInfo("fr-FR");
		Thread.CurrentThread.CurrentCulture = ci;
		Thread.CurrentThread.CurrentUICulture = ci;

		NavigationService.Instance.ShowViewModel(typeof(SplashscreenViewModel));
	}
}
