using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(KMMOpenNews.iOS.DependencyServices.Toast))]
namespace KMMOpenNews.iOS.DependencyServices
{
	public class Toast : IToast
	{
		private const float CORNER_RADIUS = 15;
		private const int OFFSET_TOP = -30;

		/// <summary>
		/// Show info toast with the supplied message
		/// </summary>
		/// <param name="message">Message to show.</param>
		public void Info(string message)
		{
			ShowToast(message, ToastIOS.Toast.LENGTH_LONG);
		}

		/// <summary>
		/// Show a short info toast with the supplied message
		/// </summary>
		/// <param name="message">Message to show.</param>
		public void ShortInfo(string message)
		{
			ShowToast(message, ToastIOS.Toast.LENGTH_SHORT);
		}

		/// <summary>
		/// Shows the toast message.
		/// </summary>
		/// <param name="message">Message text.</param>
		/// <param name="duration">Toast duration.</param>
		private void ShowToast(string message, int duration)
		{
			var toast = ToastIOS.Toast.MakeText(message, duration)
				.SetGravity(ToastIOS.ToastGravity.Bottom)
				.SetCornerRadius(CORNER_RADIUS);
			toast.theSettings().offsetTop = OFFSET_TOP;
			toast.Show();
		}
	}
}
