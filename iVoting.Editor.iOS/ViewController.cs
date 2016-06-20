using System;
using System.Collections.Generic;

using UIKit;

namespace iVoting.Editor.iOS
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
			// 
			if (null == AppDelegate.EditingVotes) {
				AppDelegate.EditingVotes = new List<EditingVote> ();
			}

			btnLogin.TouchUpInside += (sender, e) => {
				PerformSegue ("moveToMenuViewSegue", this);
			};

		}

		public override void PrepareForSegue (UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			switch (segue.Identifier) {
			case "moveToMenuViewSegue": {

					if (segue.DestinationViewController is MenuViewController) {
						//var destViewController = segue.DestinationViewController as MenuViewController;

					}

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

