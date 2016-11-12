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


		}
	}
}
