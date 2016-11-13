using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using KMMOpenNews;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(FetchNewsService))]
namespace KMMOpenNews
{
	public class FetchNewsService : IFetchNewsService
	{
		public Task<List<NewsPost>> FetchLatestNews() {
			var requestUrl = "http://10.29.20.210:3000/api/Account/GetLatesNews";
			return FetchNews(requestUrl);
		}

		public Task<List<NewsPost>> FetchNewsList() {
			var requestUrl = "http://10.29.20.210:3000/api/Account/GetNews";
			return FetchNews(requestUrl);
		}

		private Task<List<NewsPost>> FetchNews(string requestUrl) { 
			return Task.Run(async () => {
				try {
					var client = new HttpClient();

					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

					var response = await client.GetAsync(requestUrl);
					var content = await response.Content.ReadAsStringAsync();
					Console.WriteLine(content);
					if (response.StatusCode == System.Net.HttpStatusCode.OK) {
						var list = JsonConvert.DeserializeObject<List<NewsPost>>(content);
						return list;
					}
				} catch (Exception e) {
					Console.WriteLine(e);
				}

				return new List<NewsPost>();
			});
		}
	}
}
