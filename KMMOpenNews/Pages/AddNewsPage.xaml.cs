using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KMMOpenNews
{
	public partial class AddNewsPage : ContentPage
	{
		public string vest;

		public AddNewsPage()
		{
			InitializeComponent();
			BindingContext = new AddNewsPageViewModel(this);

			NewsType.Items.Add("POLITIKA");
			NewsType.Items.Add("DRUŠTVO");

			NewsType.SelectedIndex = 0;

			if (NewsType.SelectedIndex == 0)
			{
				vest = "POLITIKA";
			}
			else {
				vest = "DRUŠTVO";
			}


			Add.Command = new Command(async() => {
				var isAdded = await DependencyService.Get<IAddNews>().AddNews(Title.Text, vest, ArticleDescription.Text);

				if (isAdded)
				{
					CrossService.Toast.Info("Uspesno ste dodali vest.");
					await this.Navigation.PopAsync();
				}
				else {
					CrossService.Toast.Info("Popunite zahtevana polja.");
				}
			});
		}
	}
}
