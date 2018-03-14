using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
//settings view Controller

namespace practice2
{
    public partial class SettingsViewController : UIViewController
    {
        List<string> stringList;
        DataManip dm = new DataManip();
        validation val;
        UIViewController vc;
        public SettingsViewController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var tapOutSide = new UITapGestureRecognizer(() => View.EndEditing(true));
            tapOutSide.CancelsTouchesInView = false;
            View.AddGestureRecognizer(tapOutSide);
            HideOnReturn(AddPilotTextField);
            HideOnReturn(AddPlaneTextField);
            HideOnReturn(AddLeaseTextField);

        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            val = new validation(this);
            vc = this;
            stringList = dm.FillPilotPicker();
            pickerMaker(stringList, DeletePilotTextField);
            stringList = dm.FillLeasePicker();
            pickerMaker(stringList, DeleteLeaseTextField);
            stringList = dm.FillPlanePicker();
            pickerMaker(stringList, DeletePlaneTextField);

        }

        partial void AddPlaneButton_TouchUpInside(UIButton sender)
        {
            if (val.IsPresent(AddPlaneTextField))
            {
                var alert = UIAlertController.Create("Alert!", "Do you want to add: " +
                                                     AddPlaneTextField.Text + " As a plane?",
                                                     UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("YES", UIAlertActionStyle.Default, (obj) =>
                  {
                      string plane = AddPlaneTextField.Text.Replace(',', '.');
                      dm.AddPlane(plane);

                      ToastIOS.Toast.MakeText("Plane Added!").Show();
                      AddPlaneTextField.Text = "";
                      stringList = dm.FillPlanePicker();
                      pickerMaker(stringList, DeletePlaneTextField);
                  }));
                alert.AddAction(UIAlertAction.Create("NO", UIAlertActionStyle.Cancel, (obj) =>
                  {
                      AddPlaneTextField.Text = "";
                  }));
                vc.PresentViewController(alert, true, null);

            }
        }

        partial void DeletePlaneButton_TouchUpInside(UIButton sender)
        {

            if (val.IsPresent(DeletePlaneTextField))
            {
                var alert = UIAlertController.Create("Alert!", "Do you want to delete: " +
                                                    DeletePlaneTextField.Text,
                                                     UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("YES", UIAlertActionStyle.Destructive, (obj) =>
                  {
                      dm.DeletePlane(DeletePlaneTextField.Text);
                      ToastIOS.Toast.MakeText("Plane Deleted!").Show();
                      DeletePlaneTextField.Text = "";
                      stringList = dm.FillPlanePicker();
                      pickerMaker(stringList, DeletePlaneTextField);
                  }));
                alert.AddAction(UIAlertAction.Create("NO", UIAlertActionStyle.Default, (obj) =>
                  {
                      DeletePlaneTextField.Text = "";
                  }));
                vc.PresentViewController(alert, true, null);
            }
        }


        partial void DeletePilotButton_TouchUpInside(UIButton sender)
        {
            if (val.IsPresent(DeletePilotTextField))
            {
                var alert = UIAlertController.Create("Alert!", "Do you want to delete: " +
                                                     DeletePilotTextField.Text + "from pilot list?",
                                                     UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("YES", UIAlertActionStyle.Destructive, (obj) =>
                 {


                     dm.DeletePilot(DeletePilotTextField.Text);
                     ToastIOS.Toast.MakeText("Pilot Deleted").Show();
                     DeletePilotTextField.Text = "";
                     stringList = dm.FillPilotPicker();
                     pickerMaker(stringList, DeletePilotTextField);
                 }));
                alert.AddAction(UIAlertAction.Create("NO", UIAlertActionStyle.Default, (obj) =>
                  {
                      DeletePilotTextField.Text = "";
                  }));
                vc.PresentViewController(alert, true, null);
            }
        }



        partial void AddPilotButton_TouchUpInside(UIButton sender)
        {
            if (val.IsPresent(AddPilotTextField))
            {
                var alert = UIAlertController.Create("Alert!", "Do you want to add: " +
                                                    AddPilotTextField.Text + " As a pilot?",
                                                    UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("YES", UIAlertActionStyle.Default, (obj) =>
                  {
                      string pilot = AddPilotTextField.Text.Replace(',', '.');
                      dm.AddPilot(pilot);
                      ToastIOS.Toast.MakeText("Pilot Added!").Show();
                      AddPilotTextField.Text = "";
                      stringList = dm.FillPilotPicker();
                      pickerMaker(stringList, DeletePilotTextField);
                  }));
                alert.AddAction(UIAlertAction.Create("NO", UIAlertActionStyle.Default, (obj) =>
                  {
                      AddPilotTextField.Text = "";
                  }));
                vc.PresentViewController(alert, true, null);
            }
        }

        partial void AddButtonLease_TouchUpInside(UIButton sender)
        {
            if (val.IsPresent(AddLeaseTextField))
            {
                var alert = UIAlertController.Create("Alert!", "Do you want to add: " +
                                                     AddLeaseTextField.Text + " to leases?", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("YES", UIAlertActionStyle.Default, (obj) =>
                  {
                     string lease = AddLeaseTextField.Text.Replace(',','.');
                      dm.AddLease(lease);
                      ToastIOS.Toast.MakeText("Lease Added!").Show();
                      AddLeaseTextField.Text = "";
                      stringList = dm.FillLeasePicker();
                      pickerMaker(stringList, DeleteLeaseTextField);
                  }));
                alert.AddAction(UIAlertAction.Create("NO", UIAlertActionStyle.Default, (obj) =>
                  {
                      AddLeaseTextField.Text = "";
                  }));
                vc.PresentViewController(alert, true, null);

            }
        }
        partial void DeleteButtonLease_TouchUpInside(UIButton sender)
        {
            if (val.IsPresent(DeleteLeaseTextField))
            {
                var alert = UIAlertController.Create("Alert!", "Do you want to delete: " +
                                                     DeleteLeaseTextField.Text + " from the lease list?", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("YES", UIAlertActionStyle.Destructive, (obj) =>
                  {
                      dm.DeleteLease(DeleteLeaseTextField.Text);
                      ToastIOS.Toast.MakeText("Lease Deleted").Show();
                      DeleteLeaseTextField.Text = "";
                      stringList = dm.FillLeasePicker();
                      pickerMaker(stringList, DeleteLeaseTextField);
                  }));
                alert.AddAction(UIAlertAction.Create("NO", UIAlertActionStyle.Default, (obj) =>
                   {
                       DeleteLeaseTextField.Text = "";
                   }));
                vc.PresentViewController(alert, true, null);
            }
        }


        public void pickerMaker(List<string> items, UITextField field)
        {
            var pickerView = new UIPickerView();
            var viewModel = new NameModel(items);
            pickerView.Model = viewModel;
            pickerView.ShowSelectionIndicator = true;
            field.InputView = pickerView;
            viewModel.textChanged += (sender, e) =>
           {
               field.Text = viewModel.textNow;
               field.ResignFirstResponder();
           };
        }
        public void HideOnReturn(UITextField field)
        {
            field.ShouldReturn = (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };
        }

        partial void BatchPrintButton_TouchUpInside(UIButton sender)
        {
            
        }
    }
}