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

			UserTypePicker.Items.Add("User");
			UserTypePicker.Items.Add("Journalist");
			UserTypePicker.SelectedIndex = 0;
		}
	}
}
