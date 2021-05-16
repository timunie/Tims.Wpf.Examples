using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlinkingButton
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string Name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }

        private bool _DoBlink;
        public bool DoBlink
        {
            get { return _DoBlink; }
            set { _DoBlink = value; RaisePropertyChanged(nameof(DoBlink)); }
        }

    }
}
