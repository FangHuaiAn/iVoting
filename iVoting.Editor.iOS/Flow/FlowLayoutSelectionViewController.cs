using System;

using UIKit;

namespace iVoting.Editor.iOS
{
	public partial class FlowLayoutSelectionViewController : UIViewController
	{
		public FlowLayoutSelectionViewController (IntPtr handle) : base (handle)
		{
		}
		// moveToImageEditViewSegue
		// moveToVideoViewSegue
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			btnImage.TouchUpInside += (sender, e) => {
				PerformSegue ("moveToImageEditViewSegue", this);
			};

			btnVideo.TouchUpInside += (sender, e) => {
				PerformSegue ("moveToVideoViewSegue", this);
			};
		
		}



		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


