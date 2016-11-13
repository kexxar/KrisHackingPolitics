using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KMMOpenNews
{
	public partial class NewsListPage : ContentPage
	{
		public NewsListPage()
		{
			InitializeComponent();
			BindingContext = new NewsListPageViewModel(this, NewsList);
		}
	}
}
