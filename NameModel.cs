using System;
using System.Collections.Generic;
using UIKit;
namespace practice2
{
    public class NameModel : UIPickerViewModel
    {
        List<string> items;
        public event EventHandler textChanged;
        public string textNow = "";

        public NameModel(List<string> item)
        {
            this.items = item;
        }
        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return items.Count;
        }
        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }
        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return items[(int)row];
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            var text = items[(int)row];
			textNow = text;
            textChanged?.Invoke(null, null);
           

        }

    }
}
