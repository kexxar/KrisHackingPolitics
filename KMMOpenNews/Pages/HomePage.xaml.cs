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

			LoadData();

		    MessagingCenter.Subscribe<User>(this, "Reload", (sender) =>
			{
				LoadData();
			});


			//var user  = DependencyService.Get<IUserAccount>().LoadUser();
			//if (user.UserTypeId == 5)
			//{
			//	UserLogo.IsVisible = false;
			//	UserName.IsVisible = false;
			//	Add.IsVisible = true;
			//	var tapGestureRecognizer = new TapGestureRecognizer();
			//	tapGestureRecognizer.Tapped += (s, e) =>
			//	{
			//		Console.WriteLine("Image clicked.");
			//		this.Navigation.PushAsync(new LoginPage());
			//	};

			//	Add.GestureRecognizers.Add(tapGestureRecognizer);

			//}
			//else if (user.UserTypeId == 3)
			//{
			//	UserLogo.IsVisible = true;
			//	UserName.IsVisible = true;
			//	UserName.Text = user.userName;
			//	Add.IsVisible = true;
			//	var tapGestureRecognizer = new TapGestureRecognizer();
			//	tapGestureRecognizer.Tapped += (s, e) =>
			//	{
			//		Console.WriteLine("Image clicked.");
			//		this.Navigation.PushAsync(new AddNewsPage());
			//	};

			//	Add.GestureRecognizers.Add(tapGestureRecognizer);
			//}
			//else if (user.UserTypeId == 2)
			//{
			//	UserLogo.IsVisible = true;
			//	UserName.IsVisible = true;
			//	UserName.Text = user.userName;
			//	Add.IsVisible = false;

			//} else if (user.UserTypeId == 0){
			//	UserLogo.IsVisible = true;
			//	UserName.IsVisible = true;
			//	Add.IsVisible = true;
			//	var tapGestureRecognizer = new TapGestureRecognizer();
			//	tapGestureRecognizer.Tapped += (s, e) =>
			//	{
			//		Console.WriteLine("Image clicked.");
			//		this.Navigation.PushAsync(new AddNewsPage());
			//	};

			//	Add.GestureRecognizers.Add(tapGestureRecognizer);

			//}



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

				this.Navigation.PushAsync(new NewsListPage("", (arg) => arg.NewsDate));
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

		public void LoadData() { 
			var user  = DependencyService.Get<IUserAccount>().LoadUser();
			if (user.UserTypeId == 5) {
				UserLogo.IsVisible = false;
				UserName.IsVisible = false;
				Add.IsVisible = true;
				var tapGestureRecognizer = new TapGestureRecognizer();
				tapGestureRecognizer.Tapped += (s, e) => {
					Console.WriteLine("Image clicked.");
					this.Navigation.PushAsync(new LoginPage());
				};

				Add.GestureRecognizers.Add(tapGestureRecognizer);

			} else if (user.UserTypeId == 3) {
				UserLogo.IsVisible = true;
				UserName.IsVisible = true;
				UserName.Text = user.userName;
				Add.IsVisible = true;
				var tapGestureRecognizer = new TapGestureRecognizer();
				tapGestureRecognizer.Tapped += (s, e) => {
					Console.WriteLine("Image clicked.");
					this.Navigation.PushAsync(new AddNewsPage());
				};

				Add.GestureRecognizers.Add(tapGestureRecognizer);
			} else if (user.UserTypeId == 2) {
				UserLogo.IsVisible = true;
				UserName.IsVisible = true;
				UserName.Text = user.userName;
				Add.IsVisible = false;

			} else if (user.UserTypeId == 1) { 
				UserLogo.IsVisible = true;
				UserName.IsVisible = true;
				Add.IsVisible = true;
				var tapGestureRecognizer = new TapGestureRecognizer();
				tapGestureRecognizer.Tapped += (s, e) => {
					Console.WriteLine("Image clicked.");
					this.Navigation.PushAsync(new AddNewsPage());
				};

				Add.GestureRecognizers.Add(tapGestureRecognizer);
			} else if (user.UserTypeId == 0) {
				UserLogo.IsVisible = true;
				UserName.IsVisible = true;
				Add.IsVisible = true;
				var tapGestureRecognizer = new TapGestureRecognizer();
				tapGestureRecognizer.Tapped += (s, e) =>
				{
					Console.WriteLine("Image clicked.");
					this.Navigation.PushAsync(new AddNewsPage());
				};

				Add.GestureRecognizers.Add(tapGestureRecognizer);

			}
		}
	}
}
