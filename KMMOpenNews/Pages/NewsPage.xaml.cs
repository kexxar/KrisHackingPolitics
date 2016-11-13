using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KMMOpenNews
{
	public partial class NewsPage : ContentPage
	{
		public NewsPage()
		{
			InitializeComponent();
			BindingContext = new NewsPageViewModel(this, NewsTypeLabel);
		}
	}
}
