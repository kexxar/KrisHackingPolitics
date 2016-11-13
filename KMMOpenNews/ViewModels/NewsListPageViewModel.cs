using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using PropertyChanged;
using Xamarin.Forms;

namespace KMMOpenNews
{
	[ImplementPropertyChanged]
	public class NewsListPageViewModel
	{
		private readonly NewsListPage Page;
		private readonly ListView NewsList;
		public string NewsType { get; set; }
		public ObservableCollection<NewsPost> NewsItems { get; set; } = new ObservableCollection<NewsPost>();

		public NewsListPageViewModel(NewsListPage page, string category, Func<NewsPost, object> sortOrder, ListView newsList)
		{
			Page = page;
			NewsList = newsList;
			NewsType = category.ToUpper();

			//var customCell = new DataTemplate(typeof(CustomCell));

			//NewsList = new ListView {
			//	// TODO ItemsSource = "",
			//	ItemTemplate = customCell
			//};

			NewsList.ItemSelected += (sender, e) => {
				//TODO 
				var news = e.SelectedItem as NewsPost;
				NewsList.SelectedItem = null;
				if (news != null) {
					Page.Navigation.PushAsync(new NewsPage(news));
				}
			};

			Task.Run(async () => {
				var fullList = await DependencyService.Get<IFetchNewsService>().FetchNewsList();
				Console.WriteLine(fullList);
				//TODO filtering disabled untill we have some news in specific categories
				//NewsItems = fullList.Where(x => x.NewsType.ToLower().Contains(category.ToLower())).ToList();
				//NewsItems = fullList;
				//fullList.OrderByDescending((arg) => arg.NewsDate);
				if (sortOrder != null) {
					var sorted = fullList.OrderByDescending(sortOrder);
				}
				Device.BeginInvokeOnMainThread(() => {
					NewsItems.Clear();
					fullList.ForEach(x => NewsItems.Add(x));
				});
			});

		}
	}
}
