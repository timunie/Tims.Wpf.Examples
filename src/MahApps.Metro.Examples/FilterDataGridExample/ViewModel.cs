using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;

namespace FilterDataGridExample
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public ViewModel()
        {
            FilteredView = CollectionViewSource.GetDefaultView(People);
            FilteredView.Filter = IsFilterOK;
        }

        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>(
            new[]
            {
                new Person("James", "uncle", 19),
                new Person("John", "toe", 19),
                new Person("Robert", "feeling", 37),
                new Person("Michael", "look", 67),
                new Person("William", "secretary", 15),
                new Person("David", "baseball", 85),
                new Person("Richard", "cheese", 61),
                new Person("Joseph", "shock", 7),
                new Person("Thomas", "fold", 64),
                new Person("Charles", "aftermath", 23),
                new Person("Christopher", "truck", 57),
                new Person("Daniel", "burst", 8),
                new Person("Matthew", "act", 19),
                new Person("Anthony", "skate", 64),
                new Person("Donald", "authority", 33),
                new Person("Mark", "view", 32),
                new Person("Paul", "soda", 57),
                new Person("Steven", "brick", 96),
                new Person("Andrew", "stew", 56),
                new Person("Kenneth", "silk", 47),
                new Person("Joshua", "rose", 20),
                new Person("Kevin", "border", 34),
                new Person("Brian", "town", 31),
                new Person("George", "jelly", 14),
                new Person("Edward", "surprise", 22),
                new Person("Ronald", "driving", 89),
                new Person("Timothy", "sky", 46),
                new Person("Jason", "pollution", 26),
                new Person("Jeffrey", "ice", 42),
                new Person("Ryan", "hour", 72),
                new Person("Jacob", "thumb", 74),
                new Person("Gary", "sweater", 48),
                new Person("Nicholas", "lock", 76),
                new Person("Eric", "sea", 23),
                new Person("Jonathan", "fall", 58),
                new Person("Stephen", "low", 31),
                new Person("Larry", "cobweb", 36),
                new Person("Justin", "butter", 13),
                new Person("Scott", "cannon", 20),
                new Person("Brandon", "drop", 65),
                new Person("Benjamin", "amusement", 77),
                new Person("Samuel", "bottle", 62),
                new Person("Frank", "zephyr", 21),
                new Person("Gregory", "pets", 67),
                new Person("Raymond", "request", 84),
                new Person("Alexander", "wealth", 87),
                new Person("Patrick", "title", 61),
                new Person("Jack", "believe", 50),
                new Person("Dennis", "deer", 27),
                new Person("Jerry", "donkey", 31),
                new Person("Tyler", "spring", 31),
                new Person("Aaron", "chance", 89),
                new Person("Jose", "planes", 50),
                new Person("Henry", "produce", 99),
                new Person("Adam", "metal", 65),
                new Person("Douglas", "rain", 51),
                new Person("Nathan", "secretary", 5),
                new Person("Peter", "range", 5),
                new Person("Zachary", "engine", 80),
                new Person("Kyle", "money", 22),
                new Person("Walter", "mitten", 78),
                new Person("Harold", "sort", 25),
                new Person("Jeremy", "men", 26),
                new Person("Ethan", "sheet", 11),
                new Person("Carl", "winter", 33),
                new Person("Keith", "play", 45),
                new Person("Roger", "whistle", 62),
                new Person("Gerald", "mouth", 19),
                new Person("Christian", "crime", 27),
                new Person("Terry", "sweater", 46),
                new Person("Sean", "holiday", 21),
                new Person("Arthur", "transport", 65),
                new Person("Austin", "smell", 75),
                new Person("Noah", "scissors", 42),
                new Person("Lawrence", "picture", 42),
                new Person("Jesse", "sky", 84),
                new Person("Joe", "basketball", 51),
                new Person("Bryan", "stem", 96),
                new Person("Billy", "chickens", 26),
                new Person("Jordan", "religion", 6),
                new Person("Albert", "sticks", 97),
                new Person("Dylan", "pollution", 13),
                new Person("Bruce", "spark", 16),
                new Person("Willie", "afterthought", 26),
                new Person("Gabriel", "railway", 11),
                new Person("Alan", "whip", 93),
                new Person("Juan", "cheese", 49),
                new Person("Logan", "rainstorm", 23),
                new Person("Wayne", "ball", 38),
                new Person("Ralph", "planes", 1),
                new Person("Roy", "calendar", 61),
                new Person("Eugene", "grip", 72),
                new Person("Randy", "cable", 77),
                new Person("Vincent", "donkey", 14),
                new Person("Russell", "cannon", 41),
                new Person("Louis", "arm", 79),
                new Person("Philip", "shoes", 82),
                new Person("Bobby", "sink", 100),
                new Person("Johnny", "grandmother", 97),
                new Person("Bradley", "pan", 96),
                new Person("Mary", "shame", 23),
                new Person("Patricia", "rock", 28),
                new Person("Jennifer", "thrill", 61),
                new Person("Linda", "support", 30),
                new Person("Elizabeth", "friend", 34),
                new Person("Barbara", "wing", 29),
                new Person("Susan", "collar", 67),
                new Person("Jessica", "stranger", 67),
                new Person("Sarah", "art", 18),
                new Person("Karen", "seed", 22),
                new Person("Nancy", "canvas", 93),
                new Person("Lisa", "beginner", 94),
                new Person("Margaret", "cracker", 68),
                new Person("Betty", "oranges", 65),
                new Person("Sandra", "acoustics", 90),
                new Person("Ashley", "queen", 85),
                new Person("Dorothy", "middle", 33),
                new Person("Kimberly", "nation", 78),
                new Person("Emily", "sun", 21),
                new Person("Donna", "bite", 27),
                new Person("Michelle", "volcano", 58),
                new Person("Carol", "hill", 12),
                new Person("Amanda", "toes", 78),
                new Person("Melissa", "digestion", 15),
                new Person("Deborah", "shoe", 53),
                new Person("Stephanie", "jewel", 19),
                new Person("Rebecca", "business", 51),
                new Person("Laura", "bird", 65),
                new Person("Sharon", "basketball", 35),
                new Person("Cynthia", "flesh", 9),
                new Person("Kathleen", "offer", 83),
                new Person("Amy", "ghost", 5),
                new Person("Shirley", "island", 88),
                new Person("Angela", "sack", 49),
                new Person("Helen", "school", 17),
                new Person("Anna", "attack", 76),
                new Person("Brenda", "sock", 17),
                new Person("Pamela", "cover", 77),
                new Person("Nicole", "arithmetic", 27),
                new Person("Samantha", "yak", 2),
                new Person("Katherine", "rabbits", 82),
                new Person("Emma", "rhythm", 37),
                new Person("Ruth", "muscle", 97),
                new Person("Christine", "jail", 2),
                new Person("Catherine", "sponge", 69),
                new Person("Debra", "page", 54),
                new Person("Rachel", "substance", 88),
                new Person("Carolyn", "flowers", 85),
                new Person("Janet", "rest", 56),
                new Person("Virginia", "ticket", 16),
                new Person("Maria", "guide", 3),
                new Person("Heather", "sense", 81),
                new Person("Diane", "thumb", 63),
                new Person("Julie", "bridge", 17),
                new Person("Joyce", "plantation", 73),
                new Person("Victoria", "linen", 63),
                new Person("Kelly", "building", 76),
                new Person("Christina", "lake", 0),
                new Person("Lauren", "wash", 29),
                new Person("Joan", "zephyr", 76),
                new Person("Evelyn", "square", 13),
                new Person("Olivia", "governor", 28),
                new Person("Judith", "plastic", 20),
                new Person("Megan", "linen", 62),
                new Person("Cheryl", "person", 29),
                new Person("Martha", "vacation", 12),
                new Person("Andrea", "wound", 92),
                new Person("Frances", "cable", 48),
                new Person("Hannah", "anger", 78),
                new Person("Jacqueline", "hat", 59),
                new Person("Ann", "water", 3),
                new Person("Gloria", "queen", 99),
                new Person("Jean", "mask", 54),
                new Person("Kathryn", "toy", 39),
                new Person("Alice", "event", 70),
                new Person("Teresa", "hate", 69),
                new Person("Sara", "donkey", 23),
                new Person("Janice", "lace", 6),
                new Person("Doris", "trees", 83),
                new Person("Madison", "frogs", 59),
                new Person("Julia", "stocking", 72),
                new Person("Grace", "plough", 49),
                new Person("Judy", "caption", 64),
                new Person("Abigail", "trouble", 4),
                new Person("Marie", "decision", 73),
                new Person("Denise", "form", 7),
                new Person("Beverly", "ticket", 60),
                new Person("Amber", "run", 29),
                new Person("Theresa", "direction", 58),
                new Person("Marilyn", "rest", 62),
                new Person("Danielle", "peace", 45),
                new Person("Diana", "frogs", 71),
                new Person("Brittany", "sand", 74),
                new Person("Natalie", "rail", 72),
                new Person("Sophia", "friction", 42),
                new Person("Rose", "rail", 17),
                new Person("Isabella", "man", 88),
                new Person("Alexis", "team", 72),
                new Person("Kayla", "act", 99),
                new Person("Charlotte", "pie", 97)
            });

        public ICollectionView FilteredView { get; }

        
        bool _FilterFirstName;
        public bool FilterFirstName
        {
            get { return _FilterFirstName; }
            set
            {
                _FilterFirstName = value;
                OnPropertyChanged(nameof(FilterFirstName));
                FilteredView.Refresh();
            }
        }

        bool _FilterLastName;
        public bool FilterLastName
        {
            get { return _FilterLastName; }
            set
            {
                _FilterLastName = value;
                OnPropertyChanged(nameof(FilterLastName));
                FilteredView.Refresh();
            }
        }

        string _FilterText;
        public string FilterText
        {
            get { return _FilterText; }
            set
            {
                _FilterText = value;
                OnPropertyChanged(nameof(FilterText));
                FilteredView.Refresh();
            }
        }


        int? _MinAge;
        public int? MinAge
        {
            get { return _MinAge; }
            set 
            { 
                _MinAge = value; 
                OnPropertyChanged(nameof(MinAge));
                FilteredView.Refresh();
            }
        }

        int? _MaxAge;
        public int? MaxAge
        {
            get { return _MaxAge; }
            set
            {
                _MaxAge = value;
                OnPropertyChanged(nameof(MaxAge));
                FilteredView.Refresh();
            }
        }

        bool IsFilterOK (object item)
        {
            bool accepted = false;
            if (item is Person person)
            {
                // check the Name
                if (string.IsNullOrWhiteSpace(FilterText))
                    accepted |= true;
                else if (!string.IsNullOrWhiteSpace(FilterText) && FilterFirstName && person.FirstName.Contains(FilterText, StringComparison.OrdinalIgnoreCase))
                    accepted |= true;
                else if (!string.IsNullOrWhiteSpace(FilterText) && FilterLastName && person.LastName.Contains(FilterText, StringComparison.OrdinalIgnoreCase))
                    accepted |= true;

                // check the Age
                if (MinAge != null && MaxAge != null)
                    accepted &= person.Age >= MinAge && person.Age <= MaxAge;
                else if (MinAge != null)
                    accepted &= person.Age >= MinAge;
                else if (MaxAge != null)
                    accepted &= person.Age <= MaxAge;
            }

            return accepted;
        }
    }
}
