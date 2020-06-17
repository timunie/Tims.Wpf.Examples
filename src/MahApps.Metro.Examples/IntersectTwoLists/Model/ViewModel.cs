using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Media;
using TimsWpfControls.Model;

namespace IntersectTwoLists.Model
{
    public class ViewModel : BaseClass
    {
        public ViewModel()
        {
            Humen.CollectionChanged += Any_CollectionChanged;
            Dogs.CollectionChanged += Any_CollectionChanged;

            Humen.Add(new Human("Jake", Colors.Green));
            Humen.Add(new Human("Tim", Colors.Blue));
            Humen.Add(new Human("Lisa", Colors.Pink));

            Dogs.Add(new Dog("Rex", Colors.Blue));
            Dogs.Add(new Dog("Daisy", Colors.Pink));
            Dogs.Add(new Dog("Snoopy", Colors.AliceBlue));
        }

        private void Any_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (BaseClass item in e.NewItems)
                {
                    item.PropertyChanged += Item_PropertyChanged; ;
                }
            }

            if (e.OldItems != null)
            {
                foreach (BaseClass item in e.OldItems)
                {
                    item.PropertyChanged -= Item_PropertyChanged;
                }
            }

            RaisePropertyChanged(nameof(GoingForAWalk));
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(GoingForAWalk));
        }

        public ObservableCollection<Human> Humen { get; } = new ObservableCollection<Human>();

        public ObservableCollection<Dog> Dogs { get; } = new ObservableCollection<Dog>();

        public IEnumerable<Pair> GoingForAWalk
        {
            get
            {
                foreach (var human in Humen)
                {
                    foreach (var dog in Dogs.Where(d => d.ColorOfLine == human.ColorOfLine))
                    {
                        yield return new Pair() { Dog = dog, Human = human };
                    }
                }
            }
        }
    }
}
