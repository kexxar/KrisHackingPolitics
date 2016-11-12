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
			Add.Source = ImageSource.FromFile("feather.png");

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				Console.WriteLine("Image clicked.");
				this.Navigation.PushAsync(new RegistartionPage());
			};

			Add.GestureRecognizers.Add(tapGestureRecognizer);
		}
	}
}
