using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KMMOpenNews
{
	public partial class SearchInstitution : ContentPage
	{
		private SearchViewModel ViewModel { 
			get {
				return BindingContext as SearchViewModel;
			}
		}
		public SearchInstitution() {
			InitializeComponent();
			BindingContext = new SearchViewModel();
			SearchEntry.TextChanged += (sender, e) => {
				ViewModel.Search();
			};

			SearchList.ItemSelected += (sender, e) => {
				if (e.SelectedItem != null) {
					var item = (Institucija)e.SelectedItem;
					MessagingCenter.Send(item.ShortText, "searchDone");
					SearchList.SelectedItem = null;
					Navigation.PopAsync();
				}
			};
		}

		protected override bool OnBackButtonPressed() {
			MessagingCenter.Send("", "searchDone");
			return base.OnBackButtonPressed();
		}
	}
}
