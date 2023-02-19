using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDataCollectionsExample.Models
{
    public class CustomItem : AbstractNotifyPropertyChanged
    {
        private string text = "";
        private bool status;
        public CustomItem() {
            ImagePath = string.Empty;
            ButtonText = string.Empty;
            Text = string.Empty;
            
        }
        public string ImagePath { get; set; }
        public string ButtonText { get; set; }
        public string Text
        {
            get => text;
            set
            {
                this.SetAndRaise(ref text, value);
            }
        }

        public bool Status
        {
            get => status;
            set
            {
                SetAndRaise(ref status, value);
            }
        }

    }
}
