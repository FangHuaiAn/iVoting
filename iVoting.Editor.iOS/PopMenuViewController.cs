using System;

using UIKit;

namespace iVoting.Editor.iOS
{
	public partial class PopMenuViewController : UIViewController
	{
		public PopMenuViewController () : base ("PopMenuViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.


			btnEdit.TouchUpInside += (sender, e) => {
				EventHandler<FeatureSelectedEventArgs> handle = FeatureSelected;
				if (null != handle) {
					handle (this, new FeatureSelectedEventArgs {SelectedFeatureName = "Edit" });
				}
			};

			btnVerify.TouchUpInside += (sender, e) => {
				EventHandler<FeatureSelectedEventArgs> handle = FeatureSelected;
				if (null != handle) {
					handle (this, new FeatureSelectedEventArgs { SelectedFeatureName = "Verify" });
				}
			};

			btnPublish.TouchUpInside += (sender, e) => {
				EventHandler<FeatureSelectedEventArgs> handle = FeatureSelected;
				if (null != handle) {
					handle (this, new FeatureSelectedEventArgs { SelectedFeatureName = "Publish" });
				}
			};
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public event EventHandler<FeatureSelectedEventArgs> FeatureSelected;

		public class FeatureSelectedEventArgs : EventArgs { 
			public string SelectedFeatureName { get; set; }
		}
	}
}


