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
    [Register ("VoteDescriptionViewController")]
    partial class VoteDescriptionViewController
    {
        [Outlet]
        UIKit.UIButton btnConfirm { get; set; }


        [Outlet]
        UIKit.UIView contentView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnConfirm != null) {
                btnConfirm.Dispose ();
                btnConfirm = null;
            }

            if (contentView != null) {
                contentView.Dispose ();
                contentView = null;
            }
        }
    }
}