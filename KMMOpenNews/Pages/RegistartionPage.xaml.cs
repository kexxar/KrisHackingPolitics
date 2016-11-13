using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KMMOpenNews
{
	public partial class RegistartionPage : ContentPage
	{
		public RegistartionPage()
		{
			InitializeComponent();
			BindingContext = new RegistartionPageViewModel(this, UserTypePicker, UserNameEntry, EmailEntry, PasswordEntry, PasswordConfirmationEntry);

			UserTypePicker.Items.Add("Korisnik");
			UserTypePicker.Items.Add("Novinar");
			UserTypePicker.SelectedIndex = 0;
		}
	}
}
