
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace iVoting.Droid
{
	[Activity (Label = "選擇登入方式", Theme = "@style/MyTheme")]
	public class LoginSelectionActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here

			SetContentView (Resource.Layout.loginselectionview);


			var btnFacebook = FindViewById<Button> (Resource.Id.loginselectionview_btnFacebook);
			btnFacebook.Click += delegate {
				StartActivity (typeof(FacebookLoginActivity));
			};

			var btnGoogle = FindViewById<Button> (Resource.Id.loginselectionview_btnGoogle);
			btnGoogle.Click += delegate {
				StartActivity (typeof (GoogleLoginActivity));
			};

			var btnEmployee = FindViewById<Button> (Resource.Id.loginselectionview_btnEmployee);
			btnEmployee.Click += delegate {
				StartActivity (typeof (EmployeeLoginActivity));
			};

		}
	}
}

