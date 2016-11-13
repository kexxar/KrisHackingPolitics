using System;
namespace KMMOpenNews
{
	public class User
	{
		public string access_token { get; set; }
		public string token_type { get; set; }
		public string expires_in { get; set; }
		public string userName { get; set;  }


		public string Email { get; set; }
		public string UserName { get; set; }
		public string UserType { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }

		public User()
		{
			
		}
	}
}
