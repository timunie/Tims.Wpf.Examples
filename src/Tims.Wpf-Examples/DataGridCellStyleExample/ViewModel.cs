using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TimsWpfControls.Converter;
using TimsWpfControls.Model;

namespace DataGridCellStyleExample
{

    public class Person : BaseClass
    {
        public Person(string firstName, string lastName, int age)
        {
            Name = lastName;
            FirstName = firstName;
            Age = age;
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertyChanged(nameof(Name)); }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; RaisePropertyChanged(nameof(FirstName)); }
        }

        private int _Age;
        public int Age
        {
            get { return _Age; }
            set { _Age = value; RaisePropertyChanged(nameof(Age)); }
        }

    }

    public class ViewModel : BaseClass
    {
        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>()
        {
            new Person("Tim", "U.", 32),
            new Person("Tom", "Tommy", 45),
            new Person("Tick", "Tack", 10),
            new Person("Trick", "Track", 20)
        };
    }
}
