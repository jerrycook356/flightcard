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
    [Register ("BatchEmailViewController")]
    partial class BatchEmailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CancelButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton EmailBatchButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EndDateTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel RangeTitleLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField StartDateTextField { get; set; }

        [Action ("EmailBatchButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void EmailBatchButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (CancelButton != null) {
                CancelButton.Dispose ();
                CancelButton = null;
            }

            if (EmailBatchButton != null) {
                EmailBatchButton.Dispose ();
                EmailBatchButton = null;
            }

            if (EndDateTextField != null) {
                EndDateTextField.Dispose ();
                EndDateTextField = null;
            }

            if (RangeTitleLabel != null) {
                RangeTitleLabel.Dispose ();
                RangeTitleLabel = null;
            }

            if (StartDateTextField != null) {
                StartDateTextField.Dispose ();
                StartDateTextField = null;
            }
        }
    }
}