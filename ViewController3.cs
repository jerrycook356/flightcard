using System;
using System.Collections.Generic;
using UIKit;
using ToastIOS;
using System.IO;
using Foundation;
using System.Data.SqlTypes;
using System.Globalization;

namespace practice2
{
    public partial class ViewController3 : UIViewController
    {
        DataManip dm = new DataManip();
        WebService ws = new WebService();
        public validation val;
        List<string> stringList = new List<string>();
        List<string> tempList;
        FlightCards card;
        String dateOutString;

        protected ViewController3(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var tapOutSide = new UITapGestureRecognizer(() => View.EndEditing(true));
            tapOutSide.CancelsTouchesInView = false;
            View.AddGestureRecognizer(tapOutSide);
            HideOnReturn(DestinationTextField);
            HideOnReturn(HobbsInTextField);
            HideOnReturn(HobbsOutTextField);
            HideOnReturn(CashSpentTextField);
            HideOnReturn(passengerAddTextField);

        }
        public override void ViewDidAppear(bool animated)
        {
            DestinationTextField.AttributedPlaceholder = new Foundation.NSAttributedString("Destination", null, UIColor.Red);
            HobbsInTextField.AttributedPlaceholder = new Foundation.NSAttributedString("Hobbs Out", null, UIColor.Red);
            HobbsOutTextField.AttributedPlaceholder = new Foundation.NSAttributedString("Hobbs In", null, UIColor.Red);
            HobbsTotalTextField.AttributedPlaceholder = new Foundation.NSAttributedString("Total Hobbs", null, UIColor.Red);
            CashSpentTextField.AttributedPlaceholder = new Foundation.NSAttributedString("Cash Spent", null, UIColor.Red);
            FlightTypeTextField.AttributedPlaceholder = new Foundation.NSAttributedString("Flight Type", null, UIColor.Red);
            PlaneTypeTextField.AttributedPlaceholder = new Foundation.NSAttributedString("Plane Type", null, UIColor.Red);
            leaseTextField.AttributedPlaceholder = new Foundation.NSAttributedString("Lease Name", null, UIColor.Red);
            pilotTextField.AttributedPlaceholder = new Foundation.NSAttributedString("Pilot", null, UIColor.Red);
            passengerAddTextField.AttributedPlaceholder = new Foundation.NSAttributedString("Enter Passengers", null, UIColor.Red);

            base.ViewDidLoad();
            UIViewController vc = this;
            val = new validation(vc);
            var update = DataManip.GetIsUpdate();
            var temp = DataManip.GetIsTemp();


            DateOutTextField.Text = DateTime.Now.ToString("MM/dd/yyyy");
            DateInTextField.Text = DateTime.Now.ToString("MM/dd/yyyy");
            datePickerMaker(DateOutTextField);
            datePickerMaker(DateInTextField);
            HobbsInTextField.KeyboardType = UIKeyboardType.DecimalPad;
            HobbsOutTextField.KeyboardType = UIKeyboardType.DecimalPad;
            HobbsTotalTextField.KeyboardType = UIKeyboardType.DecimalPad;
            CashSpentTextField.KeyboardType = UIKeyboardType.DecimalPad;
            var flightList = new List<string>{
                "Whole Day","Half Day","Two Days","Three Days","Four Days",
                "Five Days","Six Days","Seven Days","Eight Days","Nine Days",
                "Ten Days","_________Days"
            };

            pickerMaker(flightList, FlightTypeTextField);
            stringList = dm.FillPilotPicker();
            pickerMaker(stringList, pilotTextField);

            stringList = dm.FillLeasePicker();
            pickerMaker(stringList, leaseTextField);



            stringList = dm.FillPlanePicker();
            pickerMaker(stringList, PlaneTypeTextField);
            DestinationTextField.Text = "";
            HobbsInTextField.Text = "";
            HobbsOutTextField.Text = "";
            HobbsTotalTextField.Text = "";
            CashSpentTextField.Text = "";
            FlightTypeTextField.Text = "";
            pilotTextField.Text = "";
            leaseTextField.Text = "";

            if (update)
            {
                card = DataManip.GetEditCard();
                DataManip.clearPassengerList();
                var dateOut = card.dateOut.ToString();
                var dateIn = card.dateIn;
                dateIn = card.dateIn.Substring(0, 10);
                DateOutTextField.Text = dateOut;
                DateInTextField.Text = dateIn;
                HobbsInTextField.Text = card.hobbsIn;
                HobbsOutTextField.Text = card.hobbsOut;

                if ((card.hobbsIn != "") && (card.hobbsOut != ""))
                {
                    var number = (double.Parse(card.hobbsOut) - double.Parse(card.hobbsIn)).ToString("F1");

                    HobbsTotalTextField.Text = number;
                }
                CashSpentTextField.Text = card.cashSpent;
                DestinationTextField.Text = card.destination;
                foreach (var passenger in card.getPassengers())
                {
                    if (passenger != "")
                        dm.addPassengerToList(passenger);
                }

                PlaneTypeTextField.Text = card.planeType;
                pilotTextField.Text = card.pilot;
                leaseTextField.Text = card.leaseName;
                FlightTypeTextField.Text = card.flightType;

            }
            if (temp)
            {

                tempList = DataManip.GetTemp();
                DateOutTextField.Text = tempList[0];
                DateInTextField.Text = tempList[1];
                HobbsInTextField.Text = tempList[2];
                HobbsOutTextField.Text = tempList[3];
                HobbsTotalTextField.Text = tempList[4];
                CashSpentTextField.Text = tempList[5];
                pilotTextField.Text = tempList[6];
                leaseTextField.Text = tempList[7];
                FlightTypeTextField.Text = tempList[8];
                PlaneTypeTextField.Text = tempList[9];
                DestinationTextField.Text = tempList[10];

                DataManip.SetIsTemp(false);
                DataManip.ClearTempInfo();

            }


        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void pickerMaker(List<String> items, UITextField field)
        {
            var PickerView = new UIPickerView();
            var ViewModel = new NameModel(items);
            PickerView.Model = ViewModel;
            PickerView.ShowSelectionIndicator = true;

            field.InputView = PickerView;

            ViewModel.textChanged += (sender, e) =>
            {
                field.Text = ViewModel.textNow;
                field.ResignFirstResponder();
            };


        }
        public void datePickerMaker(UITextField textField)
        {
            var datePicker = new UIDatePicker();
            datePicker.Mode = UIDatePickerMode.Date;
            textField.InputView = datePicker;
            datePicker.ValueChanged += (sender, e) =>
            {
                NSDateFormatter dateFormat = new NSDateFormatter();
                NSDateFormatter outFormat = new NSDateFormatter();
                outFormat.DateFormat = "yyyy-MM-dd";
                dateFormat.DateFormat = "MM/dd/yyyy";
                textField.Text = dateFormat.ToString(datePicker.Date);
                dateOutString = outFormat.ToString(datePicker.Date);
                ResignFirstResponder();
            };
        }


        partial void PassengerButton_TouchUpInside(UIButton sender)
        {
            DataManip.SetIsTemp(true);

            DataManip.AddToTemp(DateOutTextField.Text);
            DataManip.AddToTemp(DateInTextField.Text);
            DataManip.AddToTemp(HobbsInTextField.Text);
            DataManip.AddToTemp(HobbsOutTextField.Text);
            DataManip.AddToTemp(HobbsTotalTextField.Text);
            DataManip.AddToTemp(CashSpentTextField.Text);
            DataManip.AddToTemp(pilotTextField.Text);
            DataManip.AddToTemp(leaseTextField.Text);
            DataManip.AddToTemp(FlightTypeTextField.Text);
            DataManip.AddToTemp(PlaneTypeTextField.Text);
            DataManip.AddToTemp(DestinationTextField.Text);

            UIStoryboard board = UIStoryboard.FromName("Main", null);
            UIViewController ctrl = (UIViewController)board.InstantiateViewController("PassengerView");
            ctrl.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
            this.PresentViewController(ctrl, true, null);
        }


        partial void AddButton_TouchUpInside(UIButton sender)
        {

            String passenger;
            var count = dm.returnListCount();
            if (count < 24)
            {
                passenger = passengerAddTextField.Text.Replace(',', '.');
                dm.addPassengerToList(passenger);
                Toast.MakeText("Passenger Added!").Show();
                passengerAddTextField.Text = "";
            }

            if (count == 24)
            {

                Toast.MakeText("Passenger Limit Reached");

            }

        }

        partial void HobbsOutDidEnd(UITextField sender)
        {
            if (HobbsInTextField.Text != "")
            {
                if (HobbsOutTextField.Text != "")
                {
                    var number = (double.Parse(HobbsOutTextField.Text) - double.Parse(HobbsInTextField.Text)).ToString("F1");

                    Console.Out.WriteLine("string number in hobs did endd  = " + number);
                    HobbsTotalTextField.Text = number;
                }
            }
        }


        //takes place after plane is selected
        partial void changed(UITextField sender)
        {
            Console.Out.WriteLine("inside change from plane");
            string name = PlaneTypeTextField.Text;
            var hobb = dm.FillHobbsIn(name);
            if (hobb != null)
            {
                HobbsInTextField.Text = hobb;
            }
        }
        public void HideOnReturn(UITextField field)
        {
            field.ShouldReturn = (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };
        }

        partial void SaveButton2_TouchUpInside(UIButton sender)
        {
            List<string> passengers = new List<string>();
            var update = DataManip.GetIsUpdate();
            if ((HobbsInTextField.Text != "") && (HobbsOutTextField.Text != ""))
            {
                var number = (double.Parse(HobbsOutTextField.Text) - double.Parse(HobbsInTextField.Text)).ToString("F1");
                HobbsTotalTextField.Text = number;
            }

            passengers = DataManip.returnPassengerList();
            if (passengers.Count != 24)
            {
                for (int i = passengers.Count; i < 24; i++)
                {
                    passengers.Add("");
                }

            }
            string destination = DestinationTextField.Text.Replace(',', '.');


            var dateOutFromTextField = DateTime.Parse(DateOutTextField.Text);
            var dateOut = dateOutFromTextField.Add(DateTime.Now.TimeOfDay);



            var newCard = new FlightCards(
                                         dateOut, DateInTextField.Text,
                                         destination, HobbsInTextField.Text,
                                         HobbsOutTextField.Text, HobbsTotalTextField.Text,
                                         CashSpentTextField.Text, FlightTypeTextField.Text,
                                         pilotTextField.Text, PlaneTypeTextField.Text, leaseTextField.Text,
                                         passengers[0], passengers[1], passengers[2], passengers[3], passengers[4],
                                         passengers[5], passengers[6], passengers[7], passengers[8], passengers[9],
                                         passengers[10], passengers[11], passengers[12], passengers[13], passengers[14], passengers[15], passengers[16],
                                         passengers[17], passengers[18], passengers[19], passengers[20], passengers[21], passengers[22],
                                         passengers[23]);



            if (update)
            {
                FlightCards old = DataManip.GetEditCard();
                newCard.dateOut = old.dateOut;

                if (Reachability.IsHostReachable("https://www.google.com"))
                {

                    Toast.MakeText("Flight Card Saved!", Toast.LENGTH_LONG).Show();
                    dm.updateFlightCardTable(newCard);
                    ws.updateFlightCard(newCard);
                }
                else
                {
                    dm.updateFlightCardTable(newCard);
                    dm.AddtoUpdateTable(newCard);
                }
        

            }

            else
            {
                if (Reachability.IsHostReachable("https://www.google.com"))
                {
                    ws.SaveToServiceAsync(newCard);

                }
                else
                {

                    dm.AddToAddTable(newCard);
                    dm.SaveFlightCard(newCard);
                    dm.saveAll();
                }

            }
            DataManip.clearPassengerList();
            DataManip.SetIsUpdate(false);
            UIStoryboard board = UIStoryboard.FromName("Main", null);
            UIViewController ctrl = (UIViewController)board.InstantiateViewController("TableController");
            ctrl.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
            this.PresentViewController(ctrl, true, null);

        }


        partial void CancelButton2_TouchUpInside(UIButton sender)
        {
            DataManip.clearPassengerList();
            DataManip.SetIsUpdate(false);
            var update = DataManip.GetIsUpdate();
            UIStoryboard board = UIStoryboard.FromName("Main", null);
            UIViewController ctrl = (UIViewController)board.InstantiateViewController("TableController");
            ctrl.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
            this.PresentViewController(ctrl, true, null);

        }

      
    }     
}