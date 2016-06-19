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
	[Register ("FlowVideoViewController")]
	partial class FlowVideoViewController
	{
		[Outlet]
		UIKit.UIButton btnEditDescription { get; set; }

		[Outlet]
		UIKit.UIButton btnNext { get; set; }

		[Outlet]
		UIKit.UIButton btnResourceSelection { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnResourceSelection != null) {
				btnResourceSelection.Dispose ();
				btnResourceSelection = null;
			}

			if (btnEditDescription != null) {
				btnEditDescription.Dispose ();
				btnEditDescription = null;
			}

			if (btnNext != null) {
				btnNext.Dispose ();
				btnNext = null;
			}
		}
	}
}
