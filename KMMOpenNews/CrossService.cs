using System;
using Xamarin.Forms;

namespace KMMOpenNews
{
	public class CrossService
	{
		private static IToast _toast;
		/// <summary>
		/// Gets the toast service.
		/// </summary>
		/// <value>The toast.</value>
		public static IToast Toast
		{
			get
			{
				return _toast = _toast ?? DependencyService.Get<IToast>();
			}
		}
	}
}
