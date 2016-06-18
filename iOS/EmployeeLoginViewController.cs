using System;

using UIKit;

namespace iVoting.iOS
{
	public partial class EmployeeLoginViewController : UIViewController
	{
		protected EmployeeLoginViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			btnLogin.TouchUpInside += (sender, e) => { 
			
				var account = txtAccount.Text.Trim ();
				var password = txtPassword.Text.Trim ();

				var employee = new EmployeeManager ().Login (account, password);

				if (null != employee) {

					PerformSegue ("moveFromEmployeeLoginToMenuViewSegue", this);

				}
			};

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


