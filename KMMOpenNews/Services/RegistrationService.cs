using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KMMOpenNews;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(RegistrationService))]
namespace KMMOpenNews
{
	public class RegistrationService : IRegistrationService
	{

		public Task<string> RegistrationUser(string UserName, string Email, int UserTypeId, string Password, string ConfirmPassword)
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

					if (resp.StatusCode == System.Net.HttpStatusCode.OK) {
						return "OK";
					}
					var content = await resp.Content.ReadAsStringAsync();
					var o = JObject.Parse(content);
					var message = FormatReturnMessage(o);
					if (message != null) {
						return message;
					}
					var token = o["Message"];
					if (token != null) {
						return token.ToString();
					} else {
						return "";
					}

				}
				catch (Exception e) {
					Console.WriteLine(e);
					return e.Message;
				}
			
			});

		}

		private static string FormatReturnMessage(JObject o) {
			var messages = new List<string>();
			if (o["ModelState"] != null) {
				var state = o["ModelState"].First;
				foreach (var item in state) {
					var messageArray = item as JArray;
					messages.Add(messageArray.First.ToString());
				}
			}
			if (messages.Count > 0) {
				var msg = "";
				foreach (var m in messages) {
					msg += m + "\n";
				}
				msg = msg.TrimEnd(new char[] { '\n', '\t' });
				return msg;
			}
			return null;
		}
	}
}
