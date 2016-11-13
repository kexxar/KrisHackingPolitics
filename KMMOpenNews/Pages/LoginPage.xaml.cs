using System;
using System.Collections.Generic;
using Xamarin.Auth;
using Xamarin.Forms;

namespace KMMOpenNews
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
			BindingContext = new LoginPageViewModel(this);

			UserNameEntry.InputTransparent = false;

			Register.Command = new Command(() => {
				this.Navigation.PushAsync(new RegistartionPage());
			});

			SignIn.Command = new Command(async () => {
				var user = await DependencyService.Get<ILoginService>().LoginUser( UserNameEntry.Text, PasswordEntry.Text);

				if (user != null)
				{
					CrossService.Toast.Info("Učitavanje. . .");
					DependencyService.Get<IUserAccount>().SaveUser(user);

					//await this.Navigation.PushAsync(new HomePage());
					MessagingCenter.Send(new User(), "Reload");
					await this.Navigation.PopAsync();

				} else {
					CrossService.Toast.Info("Pogrešno korisničko ime ili lozinka.");
				}
			});
		}

		public void Validate() { 
		    
		}
	}
}
