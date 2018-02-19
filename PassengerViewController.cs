using Foundation;
using System;
using UIKit;
using System.Collections.Generic;


namespace practice2
{
    public partial class PassengerViewController : UIViewController
    {
        List<string> passengerList = new List<string>();
        List<UITextField> textFieldList = new List<UITextField>();



        public PassengerViewController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var tapOutSide = new UITapGestureRecognizer(() => View.EndEditing(true));
            View.AddGestureRecognizer(tapOutSide);

            passengerList = new List<String>();
            passengerList = DataManip.returnPassengerList();
            fillTextFieldList();
            fillTextFields();

        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            passengerList = new List<string>();
            passengerList = DataManip.returnPassengerList();
        }
        public void fillTextFieldList()
        {

            textFieldList.Add(passenger1TextField);
            textFieldList.Add(passenger2TextField);
            textFieldList.Add(passenger3TextField);
            textFieldList.Add(passenger4TextField);
            textFieldList.Add(passenger5TextField);
            textFieldList.Add(passenger6TextField);
            textFieldList.Add(passenger7TextField);
            textFieldList.Add(passenger8TextField);
            textFieldList.Add(passenger9TextField);
            textFieldList.Add(passenger10TextField);
            textFieldList.Add(passenger11TextField);
            textFieldList.Add(passenger12TextField);
            textFieldList.Add(passenger13TextField);
            textFieldList.Add(passenger14TextField);
            textFieldList.Add(passenger15TextField);
            textFieldList.Add(passenger16TextField);
            textFieldList.Add(passenger17TextField);
            textFieldList.Add(passenger18TextField);
            textFieldList.Add(passenger19TextField);
            textFieldList.Add(passenger20TextField);
            textFieldList.Add(passenger21TextField);
            textFieldList.Add(passenger22TextField);
            textFieldList.Add(passenger23TextField);
            textFieldList.Add(passenger24TextField);
        }

                                       
        public void fillTextFields()
        {
            
            var count = passengerList.Count;
           
            for (int i = 0; i < count; i++)
            {
                textFieldList[i].Text = passengerList[i];


            }

        }

        partial void OkButton_TouchUpInside(UIButton sender)
        {
            List<string> newList = new List<string>();
            var count = textFieldList.Count;
            for (int i = 0; i < count;i++){
                if(textFieldList[i].Text != "")
                newList.Add(textFieldList[i].Text);
            }
           
            DataManip.updatePassengerList(newList);
            }

     public void  HideOnReturn(UITextField field){
            field.ShouldReturn = (textField) => {
                textField.ResignFirstResponder();
                return true;
            };
        }
    }
}