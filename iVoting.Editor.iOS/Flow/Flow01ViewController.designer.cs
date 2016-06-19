// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace iVoting.Editor.iOS
{
	[Register ("Flow01ViewController")]
	partial class Flow01ViewController
	{
		[Outlet]
		UIKit.UIButton btnNext { get; set; }

		[Outlet]
		UIKit.UIButton[] buttons { get; set; }

		[Outlet]
		UIKit.UITextView txtDescription { get; set; }

		[Outlet]
		UIKit.UITextField txtTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnNext != null) {
				btnNext.Dispose ();
				btnNext = null;
			}

			if (txtDescription != null) {
				txtDescription.Dispose ();
				txtDescription = null;
			}

			if (txtTitle != null) {
				txtTitle.Dispose ();
				txtTitle = null;
			}
		}
	}
}
