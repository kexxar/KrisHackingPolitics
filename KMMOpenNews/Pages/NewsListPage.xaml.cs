using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KMMOpenNews
{
	public partial class NewsListPage : ContentPage
	{
		public NewsListPage(string category, Func<NewsPost, object> sortOrder = null)
		{
			InitializeComponent();
			BindingContext = new NewsListPageViewModel(this, category, sortOrder, NewsList);
		}
	}
}
