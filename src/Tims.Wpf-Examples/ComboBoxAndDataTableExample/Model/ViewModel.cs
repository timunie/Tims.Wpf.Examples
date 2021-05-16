using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBoxAndDataTableExample.Model
{
    public class ViewModel 
    {
        public ViewModel()
        {
            People.Columns.Add("First Name", typeof(string));
            People.Columns.Add("Last Name", typeof(string));
            People.Columns.Add("Age", typeof(int));
        }

        public ObservableCollection<string> Animals { get; } = new ObservableCollection<string>()
        {
            "Dog",
            "Cat",
            "Ant"
        };

        public DataTable People { get; } = new DataTable();
    }
}
