using System;

using UIKit;

namespace iVoting.Editor.iOS
{
	public partial class FlowVideoViewController : UIViewController
	{
		public FlowVideoViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			btnNext.TouchUpInside += (sender, e) => { this.NavigationController.PopToRootViewController (true); };
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


