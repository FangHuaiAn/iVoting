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
	[Register ("PopMenuViewController")]
	partial class PopMenuViewController
	{
		[Outlet]
		UIKit.UIButton btnEdit { get; set; }

		[Outlet]
		UIKit.UIButton btnPublish { get; set; }

		[Outlet]
		UIKit.UIButton btnVerify { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnVerify != null) {
				btnVerify.Dispose ();
				btnVerify = null;
			}

			if (btnEdit != null) {
				btnEdit.Dispose ();
				btnEdit = null;
			}

			if (btnPublish != null) {
				btnPublish.Dispose ();
				btnPublish = null;
			}
		}
	}
}
