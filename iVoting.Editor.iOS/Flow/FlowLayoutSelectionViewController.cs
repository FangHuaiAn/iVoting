﻿using System;

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
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


