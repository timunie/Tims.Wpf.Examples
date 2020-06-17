using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using TimsWpfControls.Model;

namespace IntersectTwoLists.Model
{
    public class Dog : BaseClass
    {
        public Dog()
        {

        }

        public Dog(string name, Color? colorOfLine)
        {
            Name = name;
            ColorOfLine = colorOfLine;
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertyChanged(nameof(Name)); }
        }

        private Color? _ColorOfLine;
        public Color? ColorOfLine
        {
            get { return _ColorOfLine; }
            set { _ColorOfLine = value; RaisePropertyChanged(nameof(ColorOfLine)); }
        }
    }
}
