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

[assembly: Dependency(typeof(AddScoreService))]
namespace KMMOpenNews
{
	public class AddScoreService : IAddScore
	{
		public Task<string> AddScore(NewsPost post, int score) {
			return Task.Run(async () => {
				var token = DependencyService.Get<IUserAccount>().GetCurrentToken();
				if (token == null) {
					return "Niste ulogovani";
				}
				var client = new HttpClient();

				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var requestUrl = "http://10.29.20.210:3000/api/Account/AddScore";
				client.DefaultRequestHeaders.Add("Authorization", "Bearer " + DependencyService.Get<IUserAccount>().GetCurrentToken());

				var parameters = new Dictionary<string, string> {
					{ "NewsPostId", post.Id.ToString() },
					{ "Score", score.ToString() }
				};
				var json = JsonConvert.SerializeObject(parameters);
				var resp = await client.PostAsync(requestUrl, new StringContent(json, Encoding.UTF8, "application/json"));
				if (resp.StatusCode == System.Net.HttpStatusCode.OK) {
					return "OK";
				} else {
					var content = await resp.Content.ReadAsStringAsync();
					JObject o = JObject.Parse(content);
					var message = o["Message"].ToString();
					return message;
				}
			});
		}
	}
}
