using UnityEngine;

public class App : MonoBehaviour {

	protected void Start () {
		NavigationService.Instance.ShowViewModel(typeof(SplashscreenViewModel));
	}

}
