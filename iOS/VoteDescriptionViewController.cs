using System;
using System.Linq;
using System.CodeDom.Compiler;
using System.Collections.Generic;

using UIKit;
using Foundation;
using ObjCRuntime;

using Debug = System.Diagnostics.Debug;

namespace iVoting.iOS
{
	public partial class VoteDescriptionViewController : UIViewController
	{
		public Vote SelectedVote { get; set; }

		public VoteDescriptionViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//
			LoadImageDescView ();

			View.BringSubviewToFront (btnConfirm);


			btnConfirm.TouchUpInside += (sender, e) => {

				PerformSegue ("moveToVoteNowViewSegue", this);

			};

		}


		private void LoadImageDescView () { 

			NSArray views = NSBundle.MainBundle.LoadNib ("VoteImageDescView", this, new NSDictionary ());

			if (1 == views.Count) {
				UIView tempView = Runtime.GetNSObject (views.ValueAt (0)) as UIView;

				if (tempView is VoteImageDescView) {

					var descView = tempView as VoteImageDescView;
					descView.UpdateUIWith (SelectedVote);

					descView.Frame = new System.Drawing.RectangleF (0, 0, (float)View.Bounds.Width, (float)View.Bounds.Height);
					View.AddSubview (descView);

				}
			}
		}


		public override void PrepareForSegue (UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			switch (segue.Identifier) {
			case "moveToVoteNowViewSegue": {

					if (segue.DestinationViewController is VoteNowViewController) {
						var destViewController = segue.DestinationViewController as VoteNowViewController;
						destViewController.SelectedVote = SelectedVote;
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


