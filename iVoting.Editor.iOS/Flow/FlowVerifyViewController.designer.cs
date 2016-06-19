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
	[Register ("FlowVerifyViewController")]
	partial class FlowVerifyViewController
	{
		[Outlet]
		UIKit.UIButton btnApprove { get; set; }

		[Outlet]
		UIKit.UIButton btnReject { get; set; }

		[Outlet]
		UIKit.UILabel lbDescription { get; set; }

		[Outlet]
		UIKit.UILabel lbTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbTitle != null) {
				lbTitle.Dispose ();
				lbTitle = null;
			}

			if (lbDescription != null) {
				lbDescription.Dispose ();
				lbDescription = null;
			}

			if (btnApprove != null) {
				btnApprove.Dispose ();
				btnApprove = null;
			}

			if (btnReject != null) {
				btnReject.Dispose ();
				btnReject = null;
			}
		}
	}
}
