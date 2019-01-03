using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePageView<T> : BaseView<T>, IPageView
{
	public void SetActive(bool active)
	{
		this.gameObject.SetActive(active);
	}
}
