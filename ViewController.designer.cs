// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace practice2
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView FlightTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationBar NavBar1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem SettingsButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField StartRangeTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FlightTableView != null) {
                FlightTableView.Dispose ();
                FlightTableView = null;
            }

            if (NavBar1 != null) {
                NavBar1.Dispose ();
                NavBar1 = null;
            }

            if (SettingsButton != null) {
                SettingsButton.Dispose ();
                SettingsButton = null;
            }

            if (StartRangeTextField != null) {
                StartRangeTextField.Dispose ();
                StartRangeTextField = null;
            }
        }
    }
}