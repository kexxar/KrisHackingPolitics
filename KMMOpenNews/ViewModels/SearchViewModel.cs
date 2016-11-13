using System;
using System.Collections.ObjectModel;
using PropertyChanged;
using Xamarin.Forms;

namespace KMMOpenNews
{
	[ImplementPropertyChanged]
	public class SearchViewModel
	{
		public string SearchText { get; set; }
		public ObservableCollection<Institucija> SearchItems { get; set; } = new ObservableCollection<Institucija>();
		private bool Locked = false;

		public SearchViewModel() {
			
		}

		public void Search() {
			if (SearchText.Length > 2) {
				//TODO search
				if (!Locked) {
					Locked = true;
					DependencyService.Get<ISearchService>().SearchInstitucije(SearchText, (obj) => {
						Device.BeginInvokeOnMainThread(() => {
							SearchItems.Clear();
							obj.ForEach(x=> SearchItems.Add(x));
							Locked = false;
						});
					});
				}
			}
		}
	}
}
