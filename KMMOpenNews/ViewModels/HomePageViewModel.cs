using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyChanged;
using Xamarin.Forms;

namespace KMMOpenNews
{
	[ImplementPropertyChanged]
	public class HomePageViewModel
	{
		private readonly HomePage Page;
		private readonly StackLayout TopNews1;
		private readonly StackLayout TopNews2;
		private readonly StackLayout TopNews3;

		public string TopTitle { get; set;}
		public string TopDescription { get; set; }

		public string TopTitle1 { get; set; }
		public string TopDescription1 { get; set; }

		public string TopTitle2 { get; set; }
		public string TopDescription2 { get; set; }

		public string Date1 { get; set; }
		public string Date2 { get; set; }
		public string Date3 { get; set; }

		public string Rate1 { get; set; }
		public string Rate2 { get; set; }
		public string Rate3 { get; set; }

		public List<NewsPost> LatestNews { get; set; }

		public HomePageViewModel(HomePage page)
		                         //, StackLayout topNews1, StackLayout topNews2, StackLayout topNews3)
		{
			Page = page;

			Task.Run(async () => {
				//TODO get news from server
				LatestNews = await DependencyService.Get<IFetchNewsService>().FetchLatestNews();
				Device.BeginInvokeOnMainThread(() => {
					if (LatestNews.Count > 2) {
						var news = LatestNews[0];
						TopTitle = news.Title;
						TopDescription = FormatBody(news.Body);
						Rate1 = news.TotalScore.ToString();
						Date1 = news.NewsDate.ToString();

						news = LatestNews[1];
						TopTitle1 = news.Title;
						TopDescription1 = FormatBody(news.Body);
						Rate2 = news.TotalScore.ToString();
						Date2 = news.NewsDate.ToString();

						news = LatestNews[2];
						TopTitle2 = news.Title;
						TopDescription2 = FormatBody(news.Body);
						Rate3 = news.TotalScore.ToString();
						Date3 = news.NewsDate.ToString();
					}
				});
			});

			//TopNews1 = topNews1;

			Date1 = DateTime.Today.ToString();
			Date2 = DateTime.Today.ToString();
			Date3 = DateTime.Today.ToString();

			Rate1 = "4.7";
			Rate2 = "4.2";
			Rate3 = "3.1";


			TopTitle = "ewrrretrtrtretvc  dsf";
			TopDescription = "dsfagasfhhhfj fdgghjgnhdfgg  dfggdfgghs dsfgertdfv edfsgsdf fsadgfdfsgdf dfbd";

			TopTitle1 = "ewrrretrtrtretvc  dsf";
			TopDescription1 = "dsfagasfhhhfj fdgghjgnhdfgg  dfggdfgghs dsfgertdfv edfsgsdf fsadgfdfsgdf dfbd";

			TopTitle2 = "ewrrretrtrtretvc  dsf";
			TopDescription2 = "dsfagasfhhhfj fdgghjgnhdfgg  dfggdfgghs dsfgertdfv edfsgsdf fsadgfdfsgdf dfbd";
		}

		private static string FormatBody(string body) {
			if (body.Length > 50) {
				return body.Substring(0, 50) + "...";
			} else {
				return body;
			}
		}
	}
}
