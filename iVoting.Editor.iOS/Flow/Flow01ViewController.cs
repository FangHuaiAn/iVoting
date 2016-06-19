using System;

using UIKit;

namespace iVoting.Editor.iOS
{
	public partial class Flow01ViewController : UIViewController
	{
		private nint _selectedTag = 1001;

		public Flow01ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			LayoutButtons ();
			AddButtonsEvent ();

			btnNext.TouchUpInside += (sender, e) => {
				PerformSegue ("moveToLayoutSelectionViewSegue", this);
			};


		}

		private void AddButtonsEvent ()
		{
			foreach (var button in buttons) {

				button.TouchUpInside += (sender, e) => {
					_selectedTag = button.Tag;
					LayoutButtons ();
				};
			}
		}

		private void LayoutButtons () {
			foreach (var button in buttons) {

				if (button.Tag == _selectedTag ) {
					button.SetImage (UIImage.FromFile ("Images/selected.png"), UIControlState.Normal);
				}
				else { 
					button.SetImage (UIImage.FromFile ("Images/unselected.png"), UIControlState.Normal);
				}
			}
		}



		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


