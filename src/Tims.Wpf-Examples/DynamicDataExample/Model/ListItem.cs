using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDataExample.Model
{
    public class ListItem : ReactiveObject
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { this.RaiseAndSetIfChanged(ref _ID, value); }
        }



        private string _Content;

        /// <summary>
        /// Any content to display.
        /// </summary>
        public string Content
        {
            get { return _Content; }
            set { this.RaiseAndSetIfChanged(ref _Content, value); }
        }
    }
}
