using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChartRenderer : MonoBehaviour
{
	[SerializeField]
	private Camera camera;

	[SerializeField]
	private LineRenderer line;

	[SerializeField]
	private Transform dot;

	[SerializeField]
	private SpriteRenderer dotImage;

	[SerializeField]
	private float widthMultiplier = 0.6f;

	private Coroutine coroutine;
	private List<Vector3> points;

	private Vector3[] smoothPoints;

	public List<Vector3> Points
	{
		get
		{
			return this.points;
		}
		set
		{
			this.points = value;
			this.SetPoints();
		}
	} 

	public LineRenderer Line
	{
		get
		{
			return this.line;
		}
	}

	public SpriteRenderer DotImage
	{
		get
		{
			return this.dotImage;
		}
	}

	private void OnEnable()
	{
		this.line.widthMultiplier = widthMultiplier;
	}

	private void SetPoints()
	{
		if(this.coroutine != null)
		{
			StopCoroutine(this.coroutine);
			this.coroutine = null;
		}

		this.line.positionCount = 0;
		this.smoothPoints = LineSmoother.SmoothLine(this.Points.ToArray(), 0.4f);
		this.coroutine = StartCoroutine(this.AddPoint());
	}

	private IEnumerator<WaitForEndOfFrame> AddPoint()
	{
		foreach(var item in this.smoothPoints)
		{
			this.line.SetPosition(this.line.positionCount++, item);
			this.dot.transform.localPosition = item + new Vector3(-14.5f, -2.5f, 0);
			yield return new WaitForEndOfFrame();
		}
	}
}
