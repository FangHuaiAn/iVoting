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
            if (btnEdit != null) {
                btnEdit.Dispose ();
                btnEdit = null;
            }

            if (btnPublish != null) {
                btnPublish.Dispose ();
                btnPublish = null;
            }

            if (btnVerify != null) {
                btnVerify.Dispose ();
                btnVerify = null;
            }
        }
    }
}