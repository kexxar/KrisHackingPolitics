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
			if (account != null && account.Properties != null && account.Properties.ContainsKey("Token")) {
				return account.Properties["Token"];
			}
			return null;
		}

		public User LoadUser() {
			if (_user == null) {
				_user = new User();
			}
			var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();

			if (account == null) {
				_user.UserName = "Gost";
				_user.UserTypeId = 5;

				return _user;

			}
			_user.UserName = account.Username;

			if (account.Properties.ContainsKey("UserTypeId")) {
				_user.UserTypeId = int.Parse(account.Properties["UserTypeId"]);

			} else {
				_user.UserTypeId = 5;
			}

			_user.access_token = account.Properties["Token"];

			return _user;
		}

		public void SaveUser(User user) {
			Account account = new Account { Username = user.userName };
			account.Properties.Add("Token", user.access_token);
			account.Properties.Add("UserTypeId", user.UserTypeId.ToString());
			AccountStore.Create().Save(account, App.AppName);
		}
	}
}
