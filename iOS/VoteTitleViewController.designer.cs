// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iVoting.iOS
{
    [Register ("VoteTitleViewController")]
    partial class VoteTitleViewController
    {
        [Outlet]
        UIKit.UIButton btnCancel { get; set; }


        [Outlet]
        UIKit.UIButton btnConfirm { get; set; }


        [Outlet]
        UIKit.UIImageView imageDescription { get; set; }


        [Outlet]
        UIKit.UILabel lbDescription { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnCancel != null) {
                btnCancel.Dispose ();
                btnCancel = null;
            }

            if (btnConfirm != null) {
                btnConfirm.Dispose ();
                btnConfirm = null;
            }

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