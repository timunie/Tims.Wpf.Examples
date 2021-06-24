using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowInDifferentThread
{
    public class SharedViewModel : ObservableObject
    {

        private double _Top;
        public double Top
        {
            get { return _Top; }
            set { SetProperty(ref _Top, value); }
        }


        private double _Left;
        public double Left
        {
            get { return _Left; }
            set { SetProperty(ref _Left, value); }
        }


        private double _Width = 600;
        public double Width
        {
            get { return _Width; }
            set { SetProperty(ref _Width, value); }
        }


        private double _Height = 450;
        public double Height
        {
            get { return _Height; }
            set { SetProperty(ref _Height, value); }
        }

    }
}
