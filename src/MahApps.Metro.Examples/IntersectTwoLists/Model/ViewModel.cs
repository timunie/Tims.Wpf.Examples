using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TimsWpfControls.Model;

namespace IntersectTwoLists.Model
{
    public class ViewModel : BaseClass
    {
        public ViewModel()
        {
            People1.CollectionChanged += People_CollectionChanged;
        }

        private void People_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Person person in e.NewItems)
                {
                    person.PropertyChanged += Person_PropertyChanged;
                }
            }

            if (e.OldItems != null)
            {
                foreach (Person person in e.OldItems)
                {
                    person.PropertyChanged -= Person_PropertyChanged;
                }
            }
        }

        private void Person_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(PeopleInBothCollections));
        }

        public ObservableCollection<Person> People1 { get; } = new ObservableCollection<Person>()
        {
            new Person("Donald", "Duck"),
            new Person("Daisy", "Duck"),
            new Person("Jack", "Daniels")
        };

        public ObservableCollection<Person> People2 { get; } = new ObservableCollection<Person>()
        {
            new Person("Donald", "Duck"),
            new Person("Daisy", "Duck"),
            new Person("Jim", "Beam")
        };

        public IEnumerable<Person> PeopleInBothCollections
        {
            get
            {
                foreach (var person in People1)
                {
                    if (People2.Any(x => x.FirstName == person.FirstName && x.LastName == person.LastName))
                    {
                        yield return person;
                    }
                }
            }
        }
    }
}
