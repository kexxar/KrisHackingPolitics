using System;
using Xamarin.Forms;

namespace KMMOpenNews
{
	public class CustomCell : ViewCell
	{
		public CustomCell() { 
		
			StackLayout cellWrapper = new StackLayout();
			StackLayout horizontalLayout = new StackLayout();
			Label Title = new Label();
			Label Descrpition = new Label();
			Label Rate = new Label();


			Title.SetBinding(Label.TextProperty, "Title");
			Descrpition.SetBinding(Label.TextProperty, "Description");
			Rate.SetBinding(Label.TextProperty, "Rate");

			View = cellWrapper;
		}
	}
}
