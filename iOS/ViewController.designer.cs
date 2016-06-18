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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton btnEmployee { get; set; }


        [Outlet]
        UIKit.UIButton btnFacebook { get; set; }


        [Outlet]
        UIKit.UIButton btnGoogle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnEmployee != null) {
                btnEmployee.Dispose ();
                btnEmployee = null;
            }

            if (btnFacebook != null) {
                btnFacebook.Dispose ();
                btnFacebook = null;
            }

            if (btnGoogle != null) {
                btnGoogle.Dispose ();
                btnGoogle = null;
            }
        }
    }
}