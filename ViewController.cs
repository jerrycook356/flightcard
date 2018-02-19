using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using SQLite;
using System.IO;

namespace practice2
{
    public partial class ViewController : UIViewController
    {
        UIViewController vc;
        DataManip db = new DataManip();
        private UIRefreshControl refreshControl;
        String startRange = "";
        public ViewController(IntPtr handle) : base(handle)
        {

        }
        public override void ViewDidLoad()
        {



        }
        public override void ViewDidAppear(bool animated)

        {
          
            db = new DataManip();
            var cards = new List<FlightCards>();
             vc = this;

            var tapOutside = new UITapGestureRecognizer(() => View.EndEditing(true));
            tapOutside.CancelsTouchesInView = false;
            View.AddGestureRecognizer(tapOutside);

            Picker(StartRangeTextField);

            if (Reachability.IsHostReachable("http://www.google.com"))
            {   db.QueryUpdateTables();
                db.updateLocalFromRemote();
                db.updatePilotFromRemote();
                db.updatePlaneFromRemote();
                db.updateLeaseFromRemote();
                cards = db.LoadArray(startRange);
               
               
            }
            else
            {
                cards = db.LoadArray(startRange);

                try
                {
                    Reachability.ReachabilityChanged += delegate
                    {
                        if (Reachability.IsHostReachable("https://www.google.com"))
                        {
                            db.QueryUpdateTables();
                            db.updateLocalFromRemote();
                            db.updatePilotFromRemote();
                            db.updatePlaneFromRemote();
                            db.updateLeaseFromRemote();
                            cards = db.LoadArray(startRange);
                            ToastIOS.Toast.MakeText("Host online, Syncing with remote database", ToastIOS.Toast.LENGTH_LONG).Show();
                        }
                    };


                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.ToString());
                }
            }
            db = new DataManip();

            FlightTableView.Source = new FlightTVS(cards, this);
            FlightTableView.RowHeight = 150f;
            FlightTableView.EstimatedRowHeight = 150f;
            FlightTableView.ReloadData();

			refreshControl = new UIRefreshControl();

			FlightTableView.AddSubview(refreshControl);
			refreshControl.ValueChanged += refreshTable;


        }
              void refreshTable(Object sender, EventArgs e){

			   List<FlightCards> cards2 = new List<FlightCards>();
            if (Reachability.IsHostReachable("http://www.google.com"))
            {   db.QueryUpdateTables();
                db.updateLocalFromRemote();
                db.updateLeaseFromRemote();
                db.updatePilotFromRemote();
                db.updatePlaneFromRemote();
                cards2 = db.LoadArray(startRange);
            }
            else{
                cards2 = db.LoadArray(startRange);
                Reachability.InternetConnectionStatus();
                Reachability.LocalWifiConnectionStatus();
                Reachability.RemoteHostStatus(); 
                try{
                    Reachability.ReachabilityChanged+= delegate {
                        if (Reachability.IsHostReachable("http://www.google.com")) {
                            db.QueryUpdateTables();
                           
                            db.updateLocalFromRemote();
                            db.updateLeaseFromRemote();
                            db.updatePilotFromRemote();
                            db.updatePlaneFromRemote();
                            cards2 = db.LoadArray(startRange);
                        }
                        
};
                }catch(Exception ex){
                    Console.Out.WriteLine(ex.ToString());
                }
            }
                
              ToastIOS.Toast.MakeText("Refreshing");
				FlightTableView.Source = new FlightTVS(cards2, this);
            FlightTableView.RowHeight = 150f;
				FlightTableView.EstimatedRowHeight = 150f;
				refreshControl.EndRefreshing();
				FlightTableView.ReloadData();
	
                
            }

        public void Picker(UITextField textfield)
        {
            var datePicker = new UIDatePicker();
            datePicker.Mode = UIDatePickerMode.Date;
            textfield.InputView = datePicker;
            textfield.Text = DateTime.Now.ToString("MM/dd/yyyy");
            datePicker.ValueChanged += (sender, e) => {
                NSDateFormatter dateFormat = new NSDateFormatter();
                dateFormat.DateFormat = "MM/dd/yyyy";
                textfield.Text = dateFormat.ToString(datePicker.Date);
                startRange = textfield.Text;
                ReloadInputViews();
                ResignFirstResponder();
            };
        }
      
    }
 
}