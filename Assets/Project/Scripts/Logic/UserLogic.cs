using System;
using System.Linq;
using Newtonsoft.Json;
using Root.DesignPatterns;

public class UserLogic : SceneSingleton<UserLogic>
{
	private const string UserCacheKey = "User";

	private User user;

	public User User
	{
		get
		{
			if(this.user == null)
			{
				this.user = this.LoadUser();
			}
			return this.user;
		}
	}

	private void Awake()
	{
		this.user = this.LoadUser();
		if(this.user.Datas.Find(w => w.DateTime.Date.Equals(DateTime.Now.Date)) == null)
		{
			this.user.Datas.Add(new Data().Init(DateTime.Now));
			this.SaveUser();
		}
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
			user = new User().Init();
			this.SaveUser(user);
		}

		return user;
	}

	public void SetDescription(string value)
	{
		if(!string.IsNullOrEmpty(value))
		{
			this.User.CurrentData.Description = value;
			this.SaveUser();
		}
	}

	public void SaveUser()
	{
		this.SaveUser(this.user);
	}

	private void SaveUser(User user)
	{
		var userSerialized = JsonConvert.SerializeObject(user);
		ES2.Save(userSerialized, UserCacheKey);
	}

	public void SetFeelingValue(FeelingType feelingType, int value)
	{
		var feeling = this.User.CurrentData.Feelings.Where(w => w.FeelingType == feelingType).FirstOrDefault();

		if(feeling != null)
		{
			feeling.Value = value;
			this.SaveUser();
		}
	}

	public void DeleteReminder(Reminder reminder)
	{
		this.User.Reminders.Remove(reminder);
	}
}