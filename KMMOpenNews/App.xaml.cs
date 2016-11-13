using Xamarin.Forms;

namespace KMMOpenNews
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new NavigationPage(new HomePage());
			MainPage = new AddNewsPage();
			//MainPage = new NavigationPage(new KMMOpenNewsPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
