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

		public RegistartionPageViewModel(RegistartionPage page, Picker userTypePicker, Entry userNameEntry, Entry emailEntry)
		{
			Page = page;
			UserTypePicker = userTypePicker;
			UserNameEntry = userNameEntry;
			EmailEntry = emailEntry;


		}

		private ICommand _signUpClicked;
		public ICommand SignUpClicked { 
			get {
				return _signUpClicked ?? (_signUpClicked = new Command(() => {
					Validation();
				}));
			}

		}


		public void Validation() {

			if (string.IsNullOrEmpty(UserNameEntry.Text) && string.IsNullOrEmpty(EmailEntry.Text)){
				//MessagingCenter.Unsubscribe<RegistartionPage, string>(this, "Hi");
				//DisplayAlert("Alert", "You have been alerted", "OK");



			} else if (string.IsNullOrEmpty(UserNameEntry.Text) || string.IsNullOrEmpty(EmailEntry.Text)) {
				
			} else {
				
			}
		}
	}
}
