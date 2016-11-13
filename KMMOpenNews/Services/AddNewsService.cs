using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KMMOpenNews
{
	public class AddNewsService : IAddNews
	{
		public Task<bool> AddNews(string Title, string NewsType, string Desctipiton)
		{
			return Task.Run(async () => {
				try
				{
					var client = new HttpClient();

					var requestUrl = "http://10.29.20.210:3000/api/Account/NewArticle";

					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					var parameters = new Dictionary<string, string> { { "Title", Title }, { "Body", Desctipiton }, { "NewsType", NewsType }};
					var json = JsonConvert.SerializeObject(parameters);

					var resp = await client.PostAsync(requestUrl, new StringContent(json, Encoding.UTF8, "application/json"));

					if (resp.StatusCode == System.Net.HttpStatusCode.OK)
					{
						return true;
					}
					else {
						return false;
					}

				}
				catch (Exception e) {
					Console.WriteLine(e);
					return false;
				}
					
			
			});


			throw new NotImplementedException();
		}
	}
}
