using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KMMOpenNews
{
	public partial class HomePage : ContentPage
	{
		private HomePageViewModel ViewModel { 
			get {
				return BindingContext as HomePageViewModel;
			}
		}
		public HomePage()
		{
			InitializeComponent();
			BindingContext = new HomePageViewModel(this);
			                                       //, TopNews1, TopNews2, TopNews3);
			Add.Source = ImageSource.FromFile("feather.png");

			MessagingCenter.Subscribe<HomePage, User>(this, "userChanged", (a, user) => {
				Console.WriteLine("user changed: " + user);
			});

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				Console.WriteLine("Image clicked.");
				this.Navigation.PushAsync(new LoginPage());
			};

			Add.GestureRecognizers.Add(tapGestureRecognizer);


			var tapGestureRecognizerNews1 = new TapGestureRecognizer();
			tapGestureRecognizerNews1.Tapped += (s, e) =>
			{
				Console.WriteLine("News1 clicked.");
				this.Navigation.PushAsync(new NewsPage(ViewModel.LatestNews[0]));
			};

			TopNews1.GestureRecognizers.Add(tapGestureRecognizerNews1);

			var tapGestureRecognizerNews2 = new TapGestureRecognizer();
			tapGestureRecognizerNews2.Tapped += (s, e) =>
			{
				Console.WriteLine("News2 clicked.");
				this.Navigation.PushAsync(new NewsPage(ViewModel.LatestNews[1]));
			};

			TopNews2.GestureRecognizers.Add(tapGestureRecognizerNews2);

			var tapGestureRecognizerNews3 = new TapGestureRecognizer();
			tapGestureRecognizerNews3.Tapped += (s, e) =>
			{
				Console.WriteLine("News1 clicked.");
				this.Navigation.PushAsync(new NewsPage(ViewModel.LatestNews[2]));
			};

			TopNews3.GestureRecognizers.Add(tapGestureRecognizerNews3);

			New.Command = new Command(() => {

				this.Navigation.PushAsync(new NewsListPage("new", a=>a.NewsDate));
			});

			Politics.Command = new Command(() =>
			{

				this.Navigation.PushAsync(new NewsListPage("politics"));
			});

			Society.Command = new Command(() =>
			{

				this.Navigation.PushAsync(new NewsListPage("society"));
			});

			Chronicle.Command = new Command(() =>
			{

				this.Navigation.PushAsync(new NewsListPage("chronicle"));
			});

		}
	}
}
