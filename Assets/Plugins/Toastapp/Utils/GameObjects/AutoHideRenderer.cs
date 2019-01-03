using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHideRenderer : MonoBehaviour
{
	public void Awake()
	{
		this.GetComponent<MeshRenderer>().enabled = false;
	}
}
