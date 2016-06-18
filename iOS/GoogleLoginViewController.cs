using System;

using UIKit;
using Google.SignIn;

namespace iVoting.iOS
{
	public partial class GoogleLoginViewController : UIViewController, ISignInUIDelegate
	{
		private GoogleUser User { get; set; }

		protected GoogleLoginViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SignIn.SharedInstance.UIDelegate = this;

			SignIn.SharedInstance.SignedIn += (object sender, SignInDelegateEventArgs e) => {

				if (e.User != null && e.Error == null) {
					User = e.User;

					InvokeOnMainThread (() => {

						lbStatus.Text = e.User.Profile.Name;

						PerformSegue ("moveFromGoogleLoginToMenuViewSegue", this);

					});
				}
			};

			SignIn.SharedInstance.Disconnected += (object sender, SignInDelegateEventArgs e) => {

				if (e.User != null && e.Error == null) {
					User = null;
					InvokeOnMainThread (() => {
						lbStatus.Text = string.Empty;
					});
				}

			};

			SignIn.SharedInstance.SignInUserSilently ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}