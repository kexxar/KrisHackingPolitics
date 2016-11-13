using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace KMMOpenNews
{
	public class RegistartionPageViewModel
	{
		private readonly RegistartionPage Page;
		private readonly Picker UserTypePicker;
		private readonly Entry UserNameEntry;
		private readonly Entry EmailEntry;
		private readonly Entry PasswordEntry;
		private readonly Entry PasswordConfirmationEntry;

		public int UserType;

		public RegistartionPageViewModel(RegistartionPage page, Picker userTypePicker, Entry userNameEntry, Entry emailEntry, Entry passwordEntry, Entry passwordConfirmationEntry)
		{
			Page = page;
			UserTypePicker = userTypePicker;
			UserNameEntry = userNameEntry;
			EmailEntry = emailEntry;
			PasswordEntry = passwordEntry;
			PasswordConfirmationEntry = passwordConfirmationEntry;


		}

		private ICommand _signUpClicked;
		public ICommand SingUpClicked { 
			get {
				//string UserName, string Email, int UserTypeId, string Password, string ConfirmPassword
				return _signUpClicked ?? (_signUpClicked = new Command(async() => {
					Validation();
				}));
			}

		}

		public bool PasswordValidation() {
			//TODO

			return true;
		}

		public async void  Validation() {

			if (string.IsNullOrEmpty(UserNameEntry.Text) && string.IsNullOrEmpty(EmailEntry.Text) && string.IsNullOrEmpty(PasswordEntry.Text) && string.IsNullOrEmpty(PasswordConfirmationEntry.Text)){;

				CrossService.Toast.Info("Unesi ime i lozinku.");

			} else if (string.IsNullOrEmpty(UserNameEntry.Text) || string.IsNullOrEmpty(EmailEntry.Text)) {
				CrossService.Toast.Info("Unesi ime i lozinku.");
				
			} else {

				if (UserTypePicker.SelectedIndex == 0)
				{
					UserType = 2;
				}
				else {
					UserType = 3;
				}

				var isRegister =  await DependencyService.Get<IRegistrationService>().RegistrationUser(UserNameEntry.Text, EmailEntry.Text, UserType, PasswordEntry.Text, PasswordConfirmationEntry.Text);
				if (isRegister)
				{

					CrossService.Toast.Info("Učitavanje. . .");
					Page.Navigation.PushAsync(new AddNewsPage());
				}
				else {
					CrossService.Toast.Info("Lozinka se ne poklapa.");
				}


				
			}
		}
	}
}
