using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KMMOpenNews
{
	public partial class NewsPage : ContentPage
	{
		public NewsPage(NewsPost post)
		{
			InitializeComponent();
			BindingContext = new NewsPageViewModel(this, post, NewsTypeLabel);
		}
	}
}
