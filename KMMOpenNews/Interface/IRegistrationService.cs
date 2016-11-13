using System;
using System.Threading.Tasks;

namespace KMMOpenNews
{
	public interface IRegistrationService
	{
		Task<string> RegistrationUser(string UserName, string Email, int UserTypeId, string Password, string ConfirmPassword);
	}
}
