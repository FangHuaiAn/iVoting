using System;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreGraphics;

using Facebook.CoreKit;
using Facebook.LoginKit;

using Debug = System.Diagnostics.Debug;

namespace iVoting.iOS
{
	public partial class FacebookLoginViewController : UIViewController
	{
		LoginButton loginView;
		ProfilePictureView pictureView;
		UILabel nameLabel;
		List<string> readPermissions = new List<string> { "public_profile" };

		protected FacebookLoginViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// If was send true to Profile.EnableUpdatesOnAccessTokenChange method
			// this notification will be called after the user is logged in and
			// after the AccessToken is gotten
			Profile.Notifications.ObserveDidChange ((sender, e) => {

				if (e.NewProfile == null)
					return;

				nameLabel.Text = e.NewProfile.Name;

			});

			var width = this.View.Bounds.Width;

			// The user image profile is set automatically once is logged in
			pictureView = new ProfilePictureView (new CGRect ( (width-100)/2, 80, 100, 100));

			// Create the label that will hold user's facebook name
			nameLabel = new UILabel (new RectangleF ( (float)(width-200.0f)/2, 220, 200, 21)) {
				TextAlignment = UITextAlignment.Center,
				BackgroundColor = UIColor.Clear
			};

			// Set the Read and Publish permissions you want to get
			loginView = new LoginButton (new CGRect ((float)(width - 200.0f) / 2, 350, 200, 30)) {
				LoginBehavior = LoginBehavior.Native,
				ReadPermissions = readPermissions.ToArray ()
			};

			// Handle actions once the user is logged in
			loginView.Completed += (sender, e) => {
				if (e.Error != null) {
					return;
				}

				if (e.Result.IsCancelled) {
					return;
				}

			};

			// Handle actions once the user is logged out
			loginView.LoggedOut += (sender, e) => {
				// Handle your logout
			};



			// Add views to main view
			View.AddSubview (loginView);
			View.AddSubview (pictureView);
			View.AddSubview (nameLabel);


		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			var profile = Profile.CurrentProfile;
			if (profile != null) {
				InvokeOnMainThread (() => {
					PerformSegue ("moveFromFacebookLoginToMenuViewSegue", this);
				});
			}
		}

	}
}


