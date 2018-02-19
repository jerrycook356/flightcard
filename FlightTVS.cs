using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using MessageUI;

namespace practice2
{
    internal class FlightTVS : UITableViewSource
    {
        private List<FlightCards> cards;
        DataManip dm =  new DataManip();
        UIViewController vc;
        MFMailComposeViewController mailController;
        WebService ws = new WebService();
        public FlightTVS(List<FlightCards> cards,UIViewController vc)
        {
            this.cards = cards;
            this.vc = vc;

        }
       

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (FlightCell)tableView.DequeueReusableCell("cell_id", indexPath);
            var card = cards[indexPath.Row];
            if(cell == null){
                cell.UpdateCell(card);
            }
            cell.UpdateCell(card);
            cell.UserInteractionEnabled = true;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return cards.Count;
        }
       public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            switch(editingStyle){
                case UITableViewCellEditingStyle.Delete:

                    UIAlertController actionSheetAlert = UIAlertController.Create(
                "Menu", "Select An Action", UIAlertControllerStyle.ActionSheet);
                    actionSheetAlert.AddAction(UIAlertAction.Create("Email", UIAlertActionStyle.Default, (obj) =>
                      {
                      if (MFMailComposeViewController.CanSendMail)
                      {
                              var passengers = cards[indexPath.Row].getPassengers();
                              List<String> actualPassengers = new List<string>();
                              foreach(var person in passengers)
                            {
                                  if (person != "")
                                      actualPassengers.Add(person);
                            }
                              String passString = "Passengers: \n";
                            foreach(var passenger in actualPassengers){
                                  passString += passenger + "\n";
                            }
                              var dateOut = cards[indexPath.Row].dateOut;
                              var dateIn = cards[indexPath.Row].dateOut;
                              var destination = cards[indexPath.Row].destination;
                              var hobbsIn = cards[indexPath.Row].hobbsIn;
                              var hobbsOut = cards[indexPath.Row].hobbsOut;
                              var hobbsTotal = cards[indexPath.Row].totalHobbs;
                              var cash = cards[indexPath.Row].cashSpent;
                              var flighttype = cards[indexPath.Row].flightType;
                              var pilot = cards[indexPath.Row].pilot;
                              var plane = cards[indexPath.Row].planeType;
                              var lease = cards[indexPath.Row].leaseName;

                              String message = string.Format("Date Out =    {0} \n " +
                                                             "Date In =     {1} \n" +
                                                             "Destination = {2} \n" +
                                                             "Hobbs In =    {3} \n"+
                                                             "Hobbs Out =   {4} \n" +
                                                             "Total Hobbs = {5}\n " +
                                                             "Cash Spent =  {6} \n" +
                                                             "Flight Type = {7} \n" +
                                                             "Pilot =       {8}\n" +
                                                             "Plane =       {9}\n" +
                                                             "Lease =       {10} \n", dateOut, dateIn, 
                                                             destination, hobbsIn, hobbsOut, hobbsTotal,
                                                             cash, flighttype, pilot, plane, lease);
                              String body = message + passString;
                              mailController = new MFMailComposeViewController();
                            mailController.SetToRecipients(new string[] {"jerrycook356@gmail.com"});
                            mailController.SetSubject("Flight Card");
                            mailController.SetMessageBody("Flight card information:  \n "+body, false);
                              mailController.Finished += (object s,
                                                          MFComposeResultEventArgs args) =>
                              {
                                  Console.WriteLine(args.Result.ToString());
                                  args.Controller.DismissViewController(true, null);
                              };
                            vc.PresentViewController(mailController,true,null);
                        
                        }
                      }));
                    actionSheetAlert.AddAction(UIAlertAction.Create("Edit", UIAlertActionStyle.Default, (obj) =>
                      {
                        
                        DataManip.SetIsUpdate(true);
                        DataManip.SetEditCard(cards[indexPath.Row]);

                          UIStoryboard board = UIStoryboard.FromName("Main", null);
                          UIViewController ctrl = (UIViewController)board.InstantiateViewController("Add");
                          ctrl.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
                          vc.PresentViewController(ctrl, true, null);
                      }));
                    actionSheetAlert.AddAction(UIAlertAction.Create("Delete", UIAlertActionStyle.Default, (obj) =>
                      {
                     
                          DataManip.deleteRecordFromFlightCards(cards[indexPath.Row]);                         
                          cards.RemoveAt(indexPath.Row);
                          tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);                    
                          
                      }));
                  
                    actionSheetAlert.AddAction(UIAlertAction.Create("Cancel",UIAlertActionStyle.Cancel,(obj) => {}));
                    vc.PresentViewController(actionSheetAlert, true, null);
                    tableView.DeselectRow(indexPath, true);
                    break;
                case UITableViewCellEditingStyle.None:
                    Console.WriteLine("commit editing style none called");
                    break;

            }
        }
     
        
        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;

        }
        public override string TitleForDeleteConfirmation(UITableView tableView, NSIndexPath indexPath)
        {
            return "Menu";

        }
       
    }
}