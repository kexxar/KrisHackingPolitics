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
				return _signUpClicked ?? (_signUpClicked = new Command(() => {
					Validation();
				}));
			}

		}

		public bool PasswordValidation() {
			//TODO

			return true;
		}

		public void Validation() {

			if (string.IsNullOrEmpty(UserNameEntry.Text) && string.IsNullOrEmpty(EmailEntry.Text)){;

				CrossService.Toast.Info("Please enter data.");

			} else if (string.IsNullOrEmpty(UserNameEntry.Text) || string.IsNullOrEmpty(EmailEntry.Text)) {
				CrossService.Toast.Info("Please enter user name and email.");
				
			} else {
				CrossService.Toast.Info("Loading. . .");

				Page.Navigation.PushAsync(new AddNewsPage());
				
			}
		}
	}
}
