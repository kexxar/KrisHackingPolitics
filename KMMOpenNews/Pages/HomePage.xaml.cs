using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KMMOpenNews
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();
			BindingContext = new HomePageViewModel(this);
			                                       //, TopNews1, TopNews2, TopNews3);
			Add.Source = ImageSource.FromFile("feather.png");

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				Console.WriteLine("Image clicked.");
				this.Navigation.PushAsync(new RegistartionPage());
			};

			Add.GestureRecognizers.Add(tapGestureRecognizer);


			var tapGestureRecognizerNews1 = new TapGestureRecognizer();
			tapGestureRecognizerNews1.Tapped += (s, e) =>
			{
				Console.WriteLine("News1 clicked.");
				this.Navigation.PushAsync(new NewsPage());
			};

			TopNews1.GestureRecognizers.Add(tapGestureRecognizerNews1);

			var tapGestureRecognizerNews2 = new TapGestureRecognizer();
			tapGestureRecognizerNews2.Tapped += (s, e) =>
			{
				Console.WriteLine("News2 clicked.");
				this.Navigation.PushAsync(new NewsPage());
			};

			TopNews2.GestureRecognizers.Add(tapGestureRecognizerNews2);

			var tapGestureRecognizerNews3 = new TapGestureRecognizer();
			tapGestureRecognizerNews3.Tapped += (s, e) =>
			{
				Console.WriteLine("News1 clicked.");
				this.Navigation.PushAsync(new NewsPage());
			};

			TopNews3.GestureRecognizers.Add(tapGestureRecognizerNews3);

			New.Command = new Command(() => {

				this.Navigation.PushAsync(new NewsListPage());
			});

			Politics.Command = new Command(() =>
			{

				this.Navigation.PushAsync(new NewsListPage());
			});

			Society.Command = new Command(() =>
			{

				this.Navigation.PushAsync(new NewsListPage());
			});

			Chronicle.Command = new Command(() =>
			{

				this.Navigation.PushAsync(new NewsListPage());
			});

		}
	}
}
