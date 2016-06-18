using System;

using UIKit;

namespace iVoting.iOS
{
	public partial class ViewController : UIViewController
	{
		protected ViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.


			btnGoogle.TouchUpInside += delegate {
				// moveToGoogleLoginViewSegue
				PerformSegue ("moveToGoogleLoginViewSegue", this);
			};

			btnFacebook.TouchUpInside += delegate {
				// moveToFacebookLoginViewSegue
				PerformSegue ("moveToFacebookLoginViewSegue", this);
			};

			btnEmployee.TouchUpInside += delegate {
				// moveToEmployeeLoginViewSegue
				PerformSegue ("moveToEmployeeLoginViewSegue", this);
			};


		}


		public override void PrepareForSegue (UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			switch (segue.Identifier) {
			case "moveToGoogleLoginViewSegue": {

				}
				break;
			case "moveToFacebookLoginViewSegue": {

				}
				break;
			case "moveToEmployeeLoginViewSegue": {

				}
				break;
			}
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

