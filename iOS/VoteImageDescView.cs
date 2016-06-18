using Foundation;
using System;
using UIKit;

namespace iVoting.iOS
{
    public partial class VoteImageDescView : UIView
    {
        public VoteImageDescView (IntPtr handle) : base (handle)
        {
        }

		public void UpdateUIWith (Vote vote) {
			lbDescription.Text = vote.Description;
			imageDescription.Image = UIImage.FromFile ("Images/sample.jpg");
		}
    }
}