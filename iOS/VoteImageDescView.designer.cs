// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace iVoting.iOS
{
	[Register ("VoteImageDescView")]
	partial class VoteImageDescView
	{
		[Outlet]
		UIKit.UIImageView imageDescription { get; set; }

		[Outlet]
		UIKit.UILabel lbDescription { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imageDescription != null) {
				imageDescription.Dispose ();
				imageDescription = null;
			}

			if (lbDescription != null) {
				lbDescription.Dispose ();
				lbDescription = null;
			}
		}
	}
}
