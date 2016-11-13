using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KMMOpenNews;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(SearchService))]
namespace KMMOpenNews
{
	public class SearchService : ISearchService
	{
		public Task SearchInstitucije(string query, Action<List<Institucija>> callback) {
			return Task.Run(async () => {
				try {
					var client = new HttpClient();

					var requestUrl = Constants.GetSearchUrl(query.ToLower());

					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					//client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "token");

					var uri = new Uri(requestUrl);

					using (var response = await client.GetAsync(uri)) {
						if (response.StatusCode == System.Net.HttpStatusCode.OK) {
							if (response.Content != null) {
								var content = await response.Content.ReadAsStringAsync();
								JObject o = JObject.Parse(content);
								var recordsJArray = (JArray)o["result"]["records"];
								var records = recordsJArray.ToObject<List<Institucija>>();

								Device.BeginInvokeOnMainThread(() => {
									//SearchResult = content;
									callback.Invoke(records);
								});
							}
						}
					}
				} catch (Exception e) {
					Console.WriteLine(e);
				}
			});
		}
	}
}
