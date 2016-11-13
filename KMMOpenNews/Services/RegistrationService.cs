using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KMMOpenNews;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(RegistrationService))]
namespace KMMOpenNews
{
	public class RegistrationService : IRegistrationService
	{

		public Task<bool> RegistrationUser(string UserName, string Email, int UserTypeId, string Password, string ConfirmPassword)
		{
			return Task.Run(async() => {
				try
				{
					var client = new HttpClient();

					var requestUrl = "http://10.29.20.210:3000/api/Account/Register";

					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					//using (var form = new MultipartFormDataContent())
					//{
					//	form.Add(new StringContent(UserName), "UserName");
					//	form.Add(new StringContent(Email), "Email");
					//	form.Add(new StringContent(UserTypeId.ToString()), "UserTypeId");
					//	form.Add(new StringContent(Password), "Password");
					//	form.Add(new StringContent(ConfirmPassword), "ConfirmPassword");

					var parameters = new Dictionary<string, string> { { "UserName", UserName }, { "Password", Password }, { "ConfirmPassword", ConfirmPassword }, { "Email", Email }, { "UserTypeId", UserTypeId.ToString()} };
					var json = JsonConvert.SerializeObject(parameters);
					//var encodedContent = new FormUrlEncodedContent(parameters);
					//var resp = await client.PostAsync(requestUrl, encodedContent).ConfigureAwait(false);
					//var resp = await client.PostAsync(requestUrl, new StringContent(json), "application/json");
					var resp = await client.PostAsync(requestUrl, new StringContent(json, Encoding.UTF8, "application/json"));

					if (resp.StatusCode == System.Net.HttpStatusCode.OK)
					{
						return true;
					}
					else {
						return false;
					}
					//}

				}
				catch (Exception e) {

					Console.WriteLine(e);
					return false;
				}
			
			});

		}
	}
}
