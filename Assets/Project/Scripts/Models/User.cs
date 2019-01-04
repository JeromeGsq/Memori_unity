using System.Collections.Generic;

public class User
{
	public string Name
	{
		get; set;
	} = "Hélène";

	public List<Feeling> Feelings
	{
		get; set;
	}

	public string Description
	{
		get; set;
	}
}