using Foundation;
using System;
using UIKit;

namespace practice2
{
    public partial class FlightCell : UITableViewCell
    {
        public FlightCell (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateCell(FlightCards card)
        {
            var dateOut = card.dateOut.ToString();

            var noTime = dateOut.Split(' ');

            DateOutLabel.Text = noTime[0];
            PilotLabel.Text = card.pilot;
            DestinationLabel.Text = card.destination;
        }
    }
}