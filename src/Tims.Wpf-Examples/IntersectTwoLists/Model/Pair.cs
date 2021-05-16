using System;
using System.Collections.Generic;
using System.Text;
using TimsWpfControls.Model;

namespace IntersectTwoLists.Model
{
    public class Pair : BaseClass
    {
        private Human _Human;
        public Human Human
        {
            get { return _Human; }
            set { _Human = value; RaisePropertyChanged(nameof(Human)); }
        }

        private Dog _Dog;
        public Dog Dog
        {
            get { return _Dog; }
            set { _Dog = value; RaisePropertyChanged(nameof(Dog)); }
        }

    }
}
