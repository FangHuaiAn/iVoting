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
			// 

			lbTitle.Text = AppDelegate.SelectedEditingVote.Target;
			lbDescription.Text = AppDelegate.SelectedEditingVote.Reason;

			btnApprove.TouchUpInside += (sender, e) => {
				AppDelegate.SelectedEditingVote.Status = EditStatus.Approve;
				NavigationController.PopToRootViewController (true);
			
			};

			btnReject.TouchUpInside += (sender, e) => {
				AppDelegate.SelectedEditingVote.Status = EditStatus.Reject;
				NavigationController.PopToRootViewController (true); 
			};
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


