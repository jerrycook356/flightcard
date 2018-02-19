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
    [Register ("SettingsViewController")]
    partial class SettingsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AddButtonLease { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField AddLeaseTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AddPilotButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField AddPilotTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AddPlaneButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField AddPlaneTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BatchPrintButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DeleteButtonLease { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField DeleteLeaseTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DeletePilotButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField DeletePilotTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DeletePlaneButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField DeletePlaneTextField { get; set; }

        [Action ("AddButtonLease_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddButtonLease_TouchUpInside (UIKit.UIButton sender);

        [Action ("AddPilotButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddPilotButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("AddPlaneButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddPlaneButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("BatchPrintButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BatchPrintButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("DeleteButtonLease_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DeleteButtonLease_TouchUpInside (UIKit.UIButton sender);

        [Action ("DeletePilotButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DeletePilotButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("DeletePlaneButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DeletePlaneButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AddButtonLease != null) {
                AddButtonLease.Dispose ();
                AddButtonLease = null;
            }

            if (AddLeaseTextField != null) {
                AddLeaseTextField.Dispose ();
                AddLeaseTextField = null;
            }

            if (AddPilotButton != null) {
                AddPilotButton.Dispose ();
                AddPilotButton = null;
            }

            if (AddPilotTextField != null) {
                AddPilotTextField.Dispose ();
                AddPilotTextField = null;
            }

            if (AddPlaneButton != null) {
                AddPlaneButton.Dispose ();
                AddPlaneButton = null;
            }

            if (AddPlaneTextField != null) {
                AddPlaneTextField.Dispose ();
                AddPlaneTextField = null;
            }

            if (BatchPrintButton != null) {
                BatchPrintButton.Dispose ();
                BatchPrintButton = null;
            }

            if (DeleteButtonLease != null) {
                DeleteButtonLease.Dispose ();
                DeleteButtonLease = null;
            }

            if (DeleteLeaseTextField != null) {
                DeleteLeaseTextField.Dispose ();
                DeleteLeaseTextField = null;
            }

            if (DeletePilotButton != null) {
                DeletePilotButton.Dispose ();
                DeletePilotButton = null;
            }

            if (DeletePilotTextField != null) {
                DeletePilotTextField.Dispose ();
                DeletePilotTextField = null;
            }

            if (DeletePlaneButton != null) {
                DeletePlaneButton.Dispose ();
                DeletePlaneButton = null;
            }

            if (DeletePlaneTextField != null) {
                DeletePlaneTextField.Dispose ();
                DeletePlaneTextField = null;
            }
        }
    }
}