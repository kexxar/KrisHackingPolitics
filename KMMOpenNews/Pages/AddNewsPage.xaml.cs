using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KMMOpenNews
{
	public partial class AddNewsPage : ContentPage
	{
		public AddNewsPage()
		{
			InitializeComponent();
			BindingContext = new AddNewsPageViewModel(this);

			NewsType.Items.Add("POLITIKA");
			NewsType.Items.Add("DRUŠTVO");

			NewsType.SelectedIndex = 0;

		}
	}
}
