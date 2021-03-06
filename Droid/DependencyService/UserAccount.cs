﻿using System;
using System.Linq;
using KMMOpenNews.Droid;
using Xamarin.Auth;
using Xamarin.Forms;
[assembly: Dependency(typeof(UserAccount))]
namespace KMMOpenNews.Droid
{
	public class UserAccount : IUserAccount
	{
		private static User _user { get; set; }

		public string GetCurrentToken() {
			var account = AccountStore.Create(Forms.Context).FindAccountsForService(App.AppName).FirstOrDefault();
			if (!account.Properties.ContainsKey("Token")) {
				return null;
			}
			return account.Properties["Token"];
		}

		public User LoadUser() {
			if (_user == null) {
				_user = new User();
			}
			var account = AccountStore.Create(Forms.Context).FindAccountsForService(App.AppName).FirstOrDefault();

			if (account == null) {
				_user.UserName = "Gost";
				_user.UserTypeId = 5;

				return _user;

			}
			_user.UserName = account.Username;
			//	_user.Password = account.Properties["Password"];
			if (account.Properties.ContainsKey("UserTypeId"))
			{
				_user.UserTypeId = int.Parse(account.Properties["UserTypeId"]);

			} else {
				_user.UserTypeId = 5;
			}

			_user.access_token = account.Properties["Token"];

			return _user;
		}

		public void SaveUser(User user) {
			Account account = new Account { Username = user.userName };
			//account.Properties.Add("Password", user.Password);
			//account.Properties.Add("Email", user.Email);
			account.Properties.Add("Token", user.access_token);
			account.Properties.Add("UserTypeId", user.UserTypeId.ToString());
			AccountStore.Create(Forms.Context).Save(account, App.AppName);
		}
	}
}
