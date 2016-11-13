using System;
using Xamarin.Forms;

namespace KMMOpenNews
{
	public class NewsListPageViewModel
	{
		private readonly NewsListPage Page;
		private readonly ListView NewsList;

		public NewsListPageViewModel(NewsListPage page, ListView newsList)
		{
			Page = page;
			NewsList = newsList;

			var customCell = new DataTemplate(typeof(CustomCell));

			NewsList = new ListView {
				// TODO ItemsSource = "",
				ItemTemplate = customCell
			};

			NewsList.ItemSelected += (sender, e) => {
				//TODO 
				//Page.Navigation.PushAsync(new NewsPage());

			};

		}
	}
}
