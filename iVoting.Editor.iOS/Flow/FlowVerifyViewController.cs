using System;

using UIKit;

namespace iVoting.Editor.iOS
{
	public partial class FlowVerifyViewController : UIViewController
	{
		public FlowVerifyViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			btnApprove.TouchUpInside += (sender, e) => { this.NavigationController.PopToRootViewController (true);};

			btnReject.TouchUpInside += (sender, e) => { this.NavigationController.PopToRootViewController (true); };
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


