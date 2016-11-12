using System;
namespace KMMOpenNews
{
	public interface IToast
	{
		/// <summary>
		/// Show info toast with the supplied message
		/// </summary>
		/// <param name="message">Message to show.</param>
		void Info(string message);

		/// <summary>
		/// Show a short info toast with the supplied message
		/// </summary>
		/// <param name="message">Message to show.</param>
		void ShortInfo(string message);
	}
}
