using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Root.DesignPatterns;

public class UserLogic : SceneSingleton<UserLogic>
{
	private const string UserCacheKey = "User";

	public User User
	{
		get; set;
	}

	private void Awake()
	{
		this.User = this.LoadUser();
	}

	public User LoadUser()
	{
		User user = null;

		if(ES2.Exists(UserCacheKey))
		{
			var userFromCache = ES2.Load<string>(UserCacheKey);
			user = JsonConvert.DeserializeObject<User>(userFromCache);
		}
		
		if(user == null)
		{
			user = new User
			{
				Name = "Hélène",
				Description = "",
				Feelings = new List<Feeling>()
				{
					new Feeling{
						FeelingType = FeelingType.Food,
						Title = "Faim",
					},
					new Feeling{
						FeelingType = FeelingType.Social,
						Title = "Social",
					},
					new Feeling{
						FeelingType = FeelingType.Power,
						Title = "Energie",
					},
					new Feeling{
						FeelingType = FeelingType.Entertainment,
						Title = "Divertissement",
					},
					new Feeling{
						FeelingType = FeelingType.Love,
						Title = "Amour",
					},
				}
			};

			this.SaveUser(user);
		}

		return user;
	}

	public void SetDescription(string value)
	{
		if(!string.IsNullOrEmpty(value))
		{
			this.User.Description = value;
			this.SaveUser(this.User);
		}
	}

	public void SaveUser(User user)
	{
		var userSerialized = JsonConvert.SerializeObject(user);
		ES2.Save(userSerialized, UserCacheKey);
	}

	public void SetFeelingValue(FeelingType feelingType, int value)
	{
		var feeling = this.User.Feelings.Where(w => w.FeelingType == feelingType).FirstOrDefault();

		if(feeling != null)
		{
			feeling.Value = value;
			this.SaveUser(this.User);
		}
	}
}