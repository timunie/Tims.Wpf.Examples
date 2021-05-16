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
                new Person("Quinn", "Montes", 82),
                new Person("Lila", "Baldwin", 73),
                new Person("Patrice", "Wallace", 97),
                new Person("Stanton", "York", 36),
                new Person("Kerry", "Gates", 9),
                new Person("Coleen", "Hahn", 38),
                new Person("Suzette", "Orr", 75),
                new Person("Rey", "Cobb", 70),
                new Person("Josephine", "Turner", 87),
                new Person("Noel", "Christensen", 69),
                new Person("Maryellen", "Roach", 15),
                new Person("Adriana", "Carney", 41),
                new Person("Ferdinand", "Riggs", 50),
                new Person("Donnie", "Moyer", 77),
                new Person("Beth", "Frey", 26),
                new Person("Kristina", "Matthews", 2),
                new Person("Santo", "Shaffer", 21),
                new Person("Rosalie", "Esparza", 83),
                new Person("Lynn", "Mccormick", 25),
                new Person("Mary", "Walls", 25),
                new Person("Kelley", "Bentley", 40),
                new Person("Howard", "Chen", 40),
                new Person("Elbert", "Mckee", 84),
                new Person("Elsie", "Walton", 22),
                new Person("Gladys", "Oneill", 50),
                new Person("Felix", "Carey", 45),
                new Person("Rosalind", "Cooley", 76),
                new Person("Willie", "Johnston", 15),
                new Person("Kristine", "Quinn", 78),
                new Person("Beverley", "Gaines", 2),
                new Person("Robby", "Soto", 57),
                new Person("Caroline", "Austin", 48),
                new Person("Augustus", "Alvarado", 12),
                new Person("Alissa", "Proctor", 49),
                new Person("Darron", "Saunders", 13),
                new Person("Lester", "Bass", 42),
                new Person("Ernest", "Howard", 82),
                new Person("Mona", "Nash", 96),
                new Person("Jolene", "Benson", 33),
                new Person("Cyrus", "Cochran", 73),
                new Person("Danielle", "Guerrero", 64),
                new Person("Laverne", "Moreno", 92),
                new Person("Lina", "Huber", 72),
                new Person("Nicolas", "Shannon", 90),
                new Person("Antone", "Mays", 30),
                new Person("Bridgett", "Winters", 75),
                new Person("Betty", "Brennan", 26),
                new Person("Davis", "Sexton", 45),
                new Person("Sheldon", "Alvarez", 26),
                new Person("Rolland", "Mcbride", 72),
                new Person("Chuck", "Henry", 64),
                new Person("Merle", "Armstrong", 42),
                new Person("Francisco", "Rowland", 2),
                new Person("Georgette", "Singh", 52),
                new Person("Luella", "Moss", 90),
                new Person("Jeramy", "Mcfarland", 65),
                new Person("Prince", "Clay", 49),
                new Person("Ken", "Pena", 16),
                new Person("Evelyn", "Fox", 39),
                new Person("Chelsea", "Thomas", 12),
                new Person("Nicholas", "Wallace", 32),
                new Person("Geraldo", "Jensen", 77),
                new Person("Yolanda", "Haley", 89),
                new Person("Aisha", "Le", 0),
                new Person("Melanie", "Roach", 77),
                new Person("Sean", "Middleton", 93),
                new Person("Foster", "Hardin", 82),
                new Person("Jillian", "Oliver", 64),
                new Person("Leon", "Koch", 21),
                new Person("Elton", "Ball", 65),
                new Person("Myles", "Aguirre", 62),
                new Person("Pierre", "Newton", 66),
                new Person("Wilbert", "Gaines", 12),
                new Person("Johnny", "Wiggins", 17),
                new Person("Mohammed", "Pratt", 55),
                new Person("Jerri", "Luna", 13),
                new Person("Elden", "Wright", 35),
                new Person("Traci", "Reed", 72),
                new Person("Ronda", "Ellis", 87),
                new Person("Roxanne", "Briggs", 44),
                new Person("Garret", "Gilmore", 35),
                new Person("Maria", "Hanna", 38),
                new Person("Hazel", "Weiss", 4),
                new Person("Florentino", "Davies", 74),
                new Person("Wilburn", "Valenzuela", 37),
                new Person("Hope", "Curry", 33),
                new Person("Elvia", "Garrison", 89),
                new Person("Jamie", "Stevens", 28),
                new Person("Dwayne", "Jackson", 24),
                new Person("Lynette", "Donaldson", 9),
                new Person("Adam", "Vang", 98),
                new Person("Cornelia", "Berg", 20),
                new Person("Clement", "Pennington", 84),
                new Person("Asa", "Kerr", 97),
                new Person("Jeff", "Valencia", 95),
                new Person("Jackson", "Kemp", 65),
                new Person("Alta", "Mccormick", 96),
                new Person("Chas", "Nolan", 83),
                new Person("Patti", "Little", 95),
                new Person("Tracie", "Combs", 56),
                new Person("Arthur", "Gates", 13),
                new Person("Carl", "Peters", 33),
                new Person("Sylvia", "Gibbs", 7),
                new Person("Davis", "Shields", 35),
                new Person("Ines", "Baxter", 35),
                new Person("Leslie", "Lowery", 68),
                new Person("Pete", "Moody", 67),
                new Person("Paris", "Dominguez", 1),
                new Person("Walton", "Klein", 54),
                new Person("Lori", "Branch", 40),
                new Person("Santiago", "Noble", 22),
                new Person("Fanny", "Francis", 70),
                new Person("Luis", "Booker", 2),
                new Person("Randi", "Mills", 57),
                new Person("Donovan", "Sexton", 21),
                new Person("Johnnie", "Watts", 37),
                new Person("Elroy", "Paul", 35),
                new Person("Luz", "Bryan", 1),
                new Person("Bonnie", "Braun", 65),
                new Person("Claudio", "Grant", 14),
                new Person("Fermin", "Joyce", 35),
                new Person("Lyle", "Benjamin", 12),
                new Person("Jerold", "Schmidt", 22),
                new Person("Alfreda", "Chase", 53),
                new Person("Lindsey", "Griffin", 84),
                new Person("Melinda", "Rhodes", 86),
                new Person("Latisha", "Knapp", 78),
                new Person("Deanna", "Ferguson", 3),
                new Person("Tim", "Duke", 52),
                new Person("Dexter", "Moore", 86),
                new Person("Leandro", "Lamb", 97),
                new Person("Vicky", "Larson", 31),
                new Person("Wendy", "Bates", 50),
                new Person("Dorothea", "Martinez", 88),
                new Person("Jared", "Lopez", 98),
                new Person("Benny", "Hoffman", 92),
                new Person("Deborah", "Saunders", 12),
                new Person("Mary", "Decker", 30),
                new Person("Luella", "Frye", 81),
                new Person("Veronica", "Silva", 29),
                new Person("Benton", "Pearson", 68),
                new Person("Maynard", "Woodard", 39),
                new Person("Dora", "Fox", 24),
                new Person("Fredric", "Benson", 93),
                new Person("Celia", "Robbins", 12),
                new Person("Sallie", "Randolph", 39),
                new Person("Stan", "Morrow", 21),
                new Person("Tyson", "Cruz", 92),
                new Person("Elma", "Macdonald", 17),
                new Person("Dawn", "Mayo", 77),
                new Person("Cheri", "Washington", 86),
                new Person("Bernadette", "Mcclain", 48),
                new Person("Claudette", "Rangel", 60),
                new Person("Bradley", "Kline", 32),
                new Person("Annie", "Richards", 32),
                new Person("Genaro", "Holden", 86),
                new Person("Cornell", "Guerra", 15),
                new Person("Sid", "Alvarez", 58),
                new Person("Cyrus", "Woodard", 30),
                new Person("Colin", "Graham", 88),
                new Person("Imelda", "Kelly", 15),
                new Person("Tory", "Carter", 79),
                new Person("Lesley", "Koch", 49),
                new Person("Danny", "Pennington", 55),
                new Person("Wayne", "Allison", 43),
                new Person("Gertrude", "Nelson", 27),
                new Person("Bennie", "Snyder", 60),
                new Person("Elias", "Dawson", 86),
                new Person("Fanny", "Parsons", 8),
                new Person("Ericka", "Heath", 44),
                new Person("Bret", "Daugherty", 40),
                new Person("Pearlie", "Barrera", 58),
                new Person("Shirley", "Johnston", 36),
                new Person("Ty", "Sharp", 74),
                new Person("Elva", "Lowe", 49),
                new Person("Dwayne", "Owen", 76),
                new Person("Cheryl", "Macdonald", 59),
                new Person("Kieth", "Hancock", 71),
                new Person("Alex", "Murray", 7),
                new Person("Carlos", "Mckenzie", 18),
                new Person("Frances", "Cowan", 2),
                new Person("Cherie", "Rasmussen", 20),
                new Person("Armando", "Delgado", 53),
                new Person("Eugenia", "Proctor", 88),
                new Person("Kris", "Norman", 89),
                new Person("Tameka", "Cortez", 7),
                new Person("Chauncey", "Fischer", 45),
                new Person("Arden", "Hansen", 90),
                new Person("Hubert", "Gaines", 62),
                new Person("Damion", "Marsh", 57),
                new Person("Mollie", "Buckley", 50),
                new Person("Adalberto", "Bishop", 95),
                new Person("Kathleen", "Vaughn", 23),
                new Person("Marisol", "Boyle", 25),
                new Person("Emily", "Stanton", 55),
                new Person("Brianna", "Mcguire", 45),
                new Person("Ambrose", "Snow", 68),
                new Person("Tabatha", "Bruce", 5),
                new Person("Casandra", "Avery", 21),
                new Person("Fran", "Pena", 21)
            });

        public ICollectionView FilteredView { get; }

        
        bool _FilterFirstName = true;
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

        bool _FilterLastName = true;
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

        string _FilterText = "Mo";
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
