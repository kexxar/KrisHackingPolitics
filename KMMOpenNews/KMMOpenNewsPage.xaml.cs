using System;
using Xamarin.Forms;

namespace KMMOpenNews
{
	public partial class KMMOpenNewsPage : ContentPage
	{
		Button btn {
			get {
				return TestButton as Button;
			}
		}
		public KMMOpenNewsPage()
		{
			InitializeComponent();
			btn.Clicked += (sender, e) => {
				DependencyService.Get<ISearchService>().SearchInstitucije("123", (obj) => {
					Console.WriteLine("search fnished");
					Console.WriteLine(obj);
				});
			};
		}
	}
}
