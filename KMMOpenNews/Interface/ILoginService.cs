using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KMMOpenNews
{
	public interface ILoginService
	{
		Task<User> LoginUser(string Username, string Password);
	}
}
