using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Auth;

namespace KMMOpenNews.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
			if (account != null) {
				AccountStore.Create().Delete(account, App.AppName);
			}

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}

		public override void WillTerminate(UIApplication uiApplication) {
			base.WillTerminate(uiApplication);

  			var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
			if (account != null) {
				AccountStore.Create().Delete(account, App.AppName);
			}
		}
	}
}
