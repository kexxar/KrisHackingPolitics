using System;
using System.Linq;
using KMMOpenNews.iOS;
using Xamarin.Auth;
using Xamarin.Forms;

[assembly:Dependency(typeof(UserAccount))]
namespace KMMOpenNews.iOS
{
	public class UserAccount : IUserAccount
	{
		private static User _user { get; set; }

		public string GetCurrentToken() {
			var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
			if (!account.Properties.ContainsKey("Token")) {
				return null;
			}
			return account.Properties["Token"];
		}

		public User LoadUser() {
			if (_user == null) {
				_user = new User();
			}
			var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
			_user.UserName = account.Username;
			_user.Password = account.Properties["Password"];
			_user.access_token = account.Properties["Token"];
			_user.Email = account.Properties["Email"];

			return _user;
		}

		public void SaveUser(User user) {
			Account account = new Account { Username = user.userName };
			//account.Properties.Add("Password", user.Password);
			//account.Properties.Add("Email", user.Email);
			account.Properties.Add("Token", user.access_token);
			AccountStore.Create().Save(account, App.AppName);
		}
	}
}
