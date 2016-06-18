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
    [Register ("GoogleLoginViewController")]
    partial class GoogleLoginViewController
    {
        [Outlet]
        UIKit.UILabel lbStatus { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lbStatus != null) {
                lbStatus.Dispose ();
                lbStatus = null;
            }
        }
    }
}