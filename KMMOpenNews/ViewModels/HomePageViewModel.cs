using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KMMOpenNews
{
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

		public string Date1 { get; set;}
		public string Date2 { get; set; }
		public string Date3 { get; set; }

		public string Rate1 { get; set; }
		public string Rate2 { get; set; }
		public string Rate3 { get; set; }

		public HomePageViewModel(HomePage page)
		                         //, StackLayout topNews1, StackLayout topNews2, StackLayout topNews3)
		{
			Page = page;

			Task.Run(() => {
				//TODO get news from server

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
	}
}
