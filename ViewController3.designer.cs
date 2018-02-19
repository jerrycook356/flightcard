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
    [Register ("ViewController3")]
    partial class ViewController3
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AddButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem cancelButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CancelButton2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField CashSpentTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField DateInTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField DateOutTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField DestinationTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField FlightTypeTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField HobbsInTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField HobbsOutTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField HobbsTotalTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField leaseTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView MainStoryBoard { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField passengerAddTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PassengerButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField pilotTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PlaneTypeTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem saveButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SaveButton2 { get; set; }

        [Action ("AddButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("CancelButton_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CancelButton_Activated (UIKit.UIBarButtonItem sender);

        [Action ("CancelButton2_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CancelButton2_TouchUpInside (UIKit.UIButton sender);

        [Action ("changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void changed (UIKit.UITextField sender);

        [Action ("HobbsOutDidEnd:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void HobbsOutDidEnd (UIKit.UITextField sender);

        [Action ("PassengerButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PassengerButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("SaveButton_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SaveButton_Activated (UIKit.UIBarButtonItem sender);

        [Action ("SaveButton2_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SaveButton2_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AddButton != null) {
                AddButton.Dispose ();
                AddButton = null;
            }

            if (cancelButton != null) {
                cancelButton.Dispose ();
                cancelButton = null;
            }

            if (CancelButton2 != null) {
                CancelButton2.Dispose ();
                CancelButton2 = null;
            }

            if (CashSpentTextField != null) {
                CashSpentTextField.Dispose ();
                CashSpentTextField = null;
            }

            if (DateInTextField != null) {
                DateInTextField.Dispose ();
                DateInTextField = null;
            }

            if (DateOutTextField != null) {
                DateOutTextField.Dispose ();
                DateOutTextField = null;
            }

            if (DestinationTextField != null) {
                DestinationTextField.Dispose ();
                DestinationTextField = null;
            }

            if (FlightTypeTextField != null) {
                FlightTypeTextField.Dispose ();
                FlightTypeTextField = null;
            }

            if (HobbsInTextField != null) {
                HobbsInTextField.Dispose ();
                HobbsInTextField = null;
            }

            if (HobbsOutTextField != null) {
                HobbsOutTextField.Dispose ();
                HobbsOutTextField = null;
            }

            if (HobbsTotalTextField != null) {
                HobbsTotalTextField.Dispose ();
                HobbsTotalTextField = null;
            }

            if (leaseTextField != null) {
                leaseTextField.Dispose ();
                leaseTextField = null;
            }

            if (MainStoryBoard != null) {
                MainStoryBoard.Dispose ();
                MainStoryBoard = null;
            }

            if (passengerAddTextField != null) {
                passengerAddTextField.Dispose ();
                passengerAddTextField = null;
            }

            if (PassengerButton != null) {
                PassengerButton.Dispose ();
                PassengerButton = null;
            }

            if (pilotTextField != null) {
                pilotTextField.Dispose ();
                pilotTextField = null;
            }

            if (PlaneTypeTextField != null) {
                PlaneTypeTextField.Dispose ();
                PlaneTypeTextField = null;
            }

            if (saveButton != null) {
                saveButton.Dispose ();
                saveButton = null;
            }

            if (SaveButton2 != null) {
                SaveButton2.Dispose ();
                SaveButton2 = null;
            }
        }
    }
}