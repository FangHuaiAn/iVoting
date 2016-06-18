using System;
using System.Drawing;

using UIKit;
using CoreGraphics;

using Debug = System.Diagnostics.Debug;

namespace iVoting.Editor.iOS
{
	public partial class MenuViewController : UIViewController
	{
		private PopMenuViewController PopMenuView { get; set; }

		public MenuViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			btnAdd.Enabled = false;

			PopMenuView = new PopMenuViewController ();
			PopMenuView.FeatureSelected += (sender, e) => {
				Debug.WriteLine (e.SelectedFeatureName);

				if ("Edit" == e.SelectedFeatureName) {
					btnAdd.Enabled = true;
				} 
				else { 
					btnAdd.Enabled = false;
				}

			};


			btnMenu.Clicked += (sender, e) => { 
				UIPopoverController pop = new UIPopoverController (PopMenuView);
				pop.SetPopoverContentSize (new CGSize (200, 150), true);
				pop.PresentFromBarButtonItem ( btnMenu, UIPopoverArrowDirection.Any, true);
			};

			btnAdd.Clicked += (sender, e) => { 
			
			};
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


