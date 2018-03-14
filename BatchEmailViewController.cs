using Foundation;
using System;
using UIKit;
using MessageUI;
using System.IO;
using System.Collections.Generic;

namespace practice2
{

    //batchEmailViewController

    public partial class BatchEmailViewController : UIViewController
    {
        DataManip dm = new DataManip();
        UIViewController vc;
        public BatchEmailViewController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            StartDateTextField.AttributedPlaceholder = new Foundation.NSAttributedString("Start Date:", null, UIColor.Red);
            EndDateTextField.AttributedPlaceholder = new Foundation.NSAttributedString("Ending Date:", null, UIColor.Red);
            var tapOutside = new UITapGestureRecognizer(() => View.EndEditing(true));
            tapOutside.CancelsTouchesInView = false;
            View.AddGestureRecognizer(tapOutside);


            Picker(StartDateTextField);
            Picker(EndDateTextField);

        }
        public void Picker(UITextField textField)
        {
            var datePicker = new UIDatePicker();
            datePicker.Mode = UIDatePickerMode.Date;
            textField.InputView = datePicker;
            datePicker.ValueChanged += (sender, e) =>
            {

                NSDateFormatter dateFormat = new NSDateFormatter();
                dateFormat.DateFormat = "MM/dd/yyyy";
                textField.Text = dateFormat.ToString(datePicker.Date);
                ResignFirstResponder();
            };
        }

        partial void EmailBatchButton_TouchUpInside(UIButton sender)
        {
            
            MFMailComposeViewController mailController;
            var documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string start;
            string end;
            vc = this;
            var allLines="";
            var fileName = Path.Combine(documentFolder, "Batch2.csv");
            if (StartDateTextField.Text != "" && EndDateTextField.Text != "")
            {
                
                start = StartDateTextField.Text;
                end = EndDateTextField.Text;
                var flightcard = dm.BatchEmail(start, end);
                foreach (var card in flightcard)
                {
                    string actualPassengers = "";
                    var passengers = card.getPassengers();
                    foreach(var person in passengers){
                        if(person != ""){
                            actualPassengers += person + "  ";
                        }
                    }

                    var dateOut = card.dateOut.ToString();
                    var subDateOut = dateOut.Substring(0, 10);
                    var dateIn = card.dateIn;
                    var subDateIn = dateIn.Substring(0, 10);

                    var line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}\n",card.planeType, subDateOut,subDateIn,card.destination,card.hobbsIn, card.hobbsOut,
                                             card.totalHobbs,actualPassengers, card.leaseName,card.flightType,card.cashSpent,card.pilot
                                             );
                    allLines += line;

                }
                File.WriteAllText(fileName, allLines);



            }
            else
            {
                ToastIOS.Toast.MakeText("Please select both parameters").Show();
            }
            if (File.Exists(fileName))
            {
                NSData data = NSData.FromFile(fileName);

                if (MFMailComposeViewController.CanSendMail)
                {
                    string[] recipients = new string[] { "jerrycook356@gmail.com" };
                    StartDateTextField.Text = "";
                    EndDateTextField.Text = "";
                    mailController = new MFMailComposeViewController();
                    mailController.SetToRecipients(recipients);
                    //mailController.SetCcRecipients(new string[] { "jerrycook356@gmail.com" });
                    mailController.SetSubject("FlightCard Batch Email");
                    mailController.AddAttachmentData(data, "text/csv", "batch.csv");


                    mailController.Finished += (object s, MFComposeResultEventArgs args) =>
                    {
                        
                        args.Controller.DismissViewController(true, null);
                    };
                    vc.PresentViewController(mailController, true, null);

                }

            }
        }
    }
}