using System;
using System.Collections.Generic;
using System.Text;
using TimsWpfControls.Model;

namespace IntersectTwoLists.Model
{
    public class Person : BaseClass
    {
        public Person()
        {

        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; RaisePropertyChanged(nameof(FirstName)); }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; RaisePropertyChanged(nameof(LastName)); }
        }


    }
}
