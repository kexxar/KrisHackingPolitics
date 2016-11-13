using System;
namespace KMMOpenNews
{
	public interface IUserAccount
	{
		void SaveUser(User user);
		User LoadUser();
		string GetCurrentToken();
	}
}
