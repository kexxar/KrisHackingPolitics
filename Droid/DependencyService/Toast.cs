using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(KMMOpenNews.Droid.DependencyServices.Toast))]
namespace KMMOpenNews.Droid.DependencyServices
{
	public class Toast : IToast
	{
		/// <summary>
		/// Show info toast with the supplied message
		/// </summary>
		/// <param name="message">Message.</param>
		public void Info(string message)
		{
			//changed to the native android implementation, since the Acr.UserDialogs library has issues.
			//A lot of issues... mommy and daddy did not love him enough when he was little.
			Android.Widget.Toast.MakeText(Forms.Context, message, Android.Widget.ToastLength.Long).Show();
		}

		/// <summary>
		/// Show a short info toast with the supplied message
		/// </summary>
		/// <param name="message">Message to show.</param>
		public void ShortInfo(string message)
		{
			Android.Widget.Toast.MakeText(Forms.Context, message, Android.Widget.ToastLength.Short).Show();
		}
	}
}
