using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListViewDetailsExample
{
    public class ExampleWithDetail : ObservableObject
    {
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        private string _Detail;
        public string Detail
        {
            get { return _Detail; }
            set { SetProperty(ref _Detail, value); }
        }

    }
}
