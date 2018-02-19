using System;
using UIKit;
namespace practice2
{
    
    public class validation
    {
        UIViewController vc;
        public validation(UIViewController vc)
        {
            this.vc = vc;
        }
        public Boolean IsPresent(UITextField field)
        {
            if (field.Text.Length == 0){
                var alert = UIAlertController.Create("Alert", "All fields must be filled in",
                                                     UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Cancel, null));

                vc.PresentViewController(alert,true,null);
                return false;
            }
            return true;
        }
    }
}
