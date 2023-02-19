using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableCollectionExample.Models
{
    public class CustomItem : INotifyPropertyChanged
    {
        private string text;
        public CustomItem() { }
        public string ImagePath { get; set; }
        public string Text
        {
            get => text;
            set
            {
                text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
            }
        }
        public string ButtonText { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
