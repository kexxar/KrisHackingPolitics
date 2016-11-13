using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KMMOpenNews;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(LoginService))]
namespace KMMOpenNews
{
	public class LoginService : ILoginService
	{

		public Task<User> LoginUser(string Username, string Password)
		{
			return Task.Run(async () =>
			{
				try
				{
					var client = new HttpClient();

					var requestUrl = "http://10.29.20.210:3000/Token";

					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					//using (var form = new MultipartFormDataContent()) {
					//	form.Add(new StringContent(Username), "username");
					//	form.Add(new StringContent(Password), "password");
					//	form.Add(new StringContent("password"),"grant_type");

					var parameters = new Dictionary<string, string> { {"username", Username }, {"password", Password }, { "grant_type", "password" } };

						var encodedContent = new FormUrlEncodedContent(parameters);
						var resp = await client.PostAsync(requestUrl, encodedContent).ConfigureAwait(false);

						var cont = await resp.Content.ReadAsStringAsync();

						var u = JsonConvert.DeserializeObject<User>(cont);


					//var response = await client.PostAsync(requestUrl, form);
					//var content = await response.Content.ReadAsStringAsync();
					//var user = JsonConvert.DeserializeObject<User>(content);

					//return user;
					//}

					var requestUrl1 = "http://10.29.20.210:3000/api/Account/UserInfo";

					client.DefaultRequestHeaders.Add("Authorization", "Bearer " + u.access_token);

					var resp1 = await client.GetAsync(requestUrl1); 

					var cont1 = await resp1.Content.ReadAsStreamAsync();

					var u1 = JsonConvert.DeserializeObject<User>(cont);

					u.UserTypeId = u1.UserTypeId;

					return u;

				}
				catch (Exception e){
					Console.WriteLine(e);
					return null;
				}
			
			});
		}
	}
}
