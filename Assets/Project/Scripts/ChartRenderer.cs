using System.Collections.Generic;
using UnityEngine;

public class ChartRenderer : MonoBehaviour
{
	[SerializeField]
	private Camera camera;

	[SerializeField]
	private LineRenderer line;

	[SerializeField]
	private Transform dot;

	[SerializeField]
	private float widthMultiplier = 0.6f;

	private List<Vector3> points = new List<Vector3>();
	private Vector3[] smoothPoints;

	private void OnEnable()
	{
		this.points.Clear();
		this.line.positionCount = 0;

		for(int i = 0; i < 30; i++)
		{
			points.Add(new Vector2(i, Random.Range(0, 5)));
		}

		this.smoothPoints = LineSmoother.SmoothLine(points.ToArray(), 0.1f);

		this.line.widthMultiplier = widthMultiplier;

		StartCoroutine(this.AddPoint());
	}

	IEnumerator<WaitForEndOfFrame> AddPoint()
	{
		foreach(var item in this.smoothPoints)
		{
			this.line.SetPosition(this.line.positionCount++, item);
			this.dot.transform.localPosition = item + new Vector3(-14.5f, -2.5f, 0);
			yield return new WaitForEndOfFrame();
		}
	}
}
