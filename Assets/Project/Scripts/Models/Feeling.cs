using UnityEngine;

public class Feeling
{
	public string Title
	{
		get; set;
	}

	public FeelingType FeelingType
	{
		get; set;
	}

	public int Value
	{
		get; set;
	} = 3;

	public Feeling()
	{
		this.Value = 3;
	}

	public Feeling(int value)
	{
#if UNITY_EDITOR
		this.Value = value;
#endif
	}
}
