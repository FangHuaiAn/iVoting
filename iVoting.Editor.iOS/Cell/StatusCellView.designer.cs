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
	[Register ("StatusCellView")]
	partial class StatusCellView
	{
		[Outlet]
		UIKit.UIButton btnStatus { get; set; }

		[Outlet]
		UIKit.UILabel lbStatus { get; set; }

		[Outlet]
		UIKit.UILabel lbTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbTitle != null) {
				lbTitle.Dispose ();
				lbTitle = null;
			}

			if (btnStatus != null) {
				btnStatus.Dispose ();
				btnStatus = null;
			}

			if (lbStatus != null) {
				lbStatus.Dispose ();
				lbStatus = null;
			}
		}
	}
}
