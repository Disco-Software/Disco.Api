using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Disco.Mobile.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public string UserName { get; set; }
        public string UserPhoto { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
