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
	[Register ("FlowLayoutSelectionViewController")]
	partial class FlowLayoutSelectionViewController
	{
		[Outlet]
		UIKit.UIButton btnImage { get; set; }

		[Outlet]
		UIKit.UIButton btnVideo { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnImage != null) {
				btnImage.Dispose ();
				btnImage = null;
			}

			if (btnVideo != null) {
				btnVideo.Dispose ();
				btnVideo = null;
			}
		}
	}
}
