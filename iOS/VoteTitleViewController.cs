using System;

using UIKit;

namespace iVoting.iOS
{
	public partial class VoteTitleViewController : UIViewController
	{
		public Vote SelectedVote { get; set; }

		public VoteTitleViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			Title = SelectedVote.Title;

			lbDescription.Text = SelectedVote.Description;
			imageDescription.Image = UIImage.FromFile ("Images/votebg.jpg");

			btnCancel.TouchUpInside += (sender, e) => {
				this.NavigationController.PopToRootViewController (true);
			};

			btnConfirm.TouchUpInside += (sender, e) => {
				PerformSegue ("moveToVoteDescViewSegue", this);
			};
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			switch (segue.Identifier) {
			case "moveToVoteDescViewSegue": {

					if (segue.DestinationViewController is VoteDescriptionViewController) {
						var destViewController = segue.DestinationViewController as VoteDescriptionViewController;
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


