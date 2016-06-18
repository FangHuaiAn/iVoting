using Android.OS;
using Android.App;
using Android.Widget;

namespace iVoting.Droid
{
	[Activity (Label = "EmployeeLoginActivity", Theme = "@style/MyTheme")]
	public class EmployeeLoginActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView (Resource.Layout.employeeloginview);


			var txtAccount = FindViewById<EditText> (Resource.Id.employeeloginview_txtAccount);
			var txtPassword = FindViewById<EditText> (Resource.Id.employeeloginview_txtPassword);

			var btnLogin = FindViewById<Button> (Resource.Id.employeeloginview_btnLogin);

			btnLogin.Click += (sender, e) => { 
				
				var account = txtAccount.Text.Trim ();
				var password = txtPassword.Text.Trim ();

				var employee = new EmployeeManager ().Login (account, password);

				if (null != employee) {
					StartActivity (typeof (MenuActivity));
				}
			};

		}
	}
}

