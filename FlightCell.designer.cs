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
    [Register ("FlightCell")]
    partial class FlightCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DateOutLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DestinationLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PilotLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DateOutLabel != null) {
                DateOutLabel.Dispose ();
                DateOutLabel = null;
            }

            if (DestinationLabel != null) {
                DestinationLabel.Dispose ();
                DestinationLabel = null;
            }

            if (PilotLabel != null) {
                PilotLabel.Dispose ();
                PilotLabel = null;
            }
        }
    }
}