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
    [Register ("MenuViewController")]
    partial class MenuViewController
    {
        [Outlet]
        UIKit.UITableView voteTable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (voteTable != null) {
                voteTable.Dispose ();
                voteTable = null;
            }
        }
    }
}