using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Auth;
using System.Linq;

namespace KMMOpenNews.Droid
{
	[Activity(Label = "obJavi!", Icon = "@drawable/logo", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());
		}

		protected override void OnDestroy() {
			base.OnDestroy();

 			 var account = AccountStore.Create(Forms.Context).FindAccountsForService(App.AppName).FirstOrDefault();
			if (account != null) {
				AccountStore.Create(Forms.Context).Delete(account, App.AppName);
			}
		}
	}
}
