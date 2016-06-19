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
    [Register ("VoteNowCellView")]
    partial class VoteNowCellView
    {
        [Outlet]
        public UIKit.UIButton btnCheck { get; set; }


        [Outlet]
        UIKit.UILabel lbTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnCheck != null) {
                btnCheck.Dispose ();
                btnCheck = null;
            }

            if (lbTitle != null) {
                lbTitle.Dispose ();
                lbTitle = null;
            }
        }
    }
}