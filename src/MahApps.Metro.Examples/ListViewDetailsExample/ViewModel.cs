using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ListViewDetailsExample
{
    public class ViewModel : ObservableObject
    {
        public ObservableCollection<ExampleWithDetail> Examples { get; } = new ObservableCollection<ExampleWithDetail>
        {
            new ExampleWithDetail() {Title ="Test 1" , Detail ="This is only visible if this ListViewItem is selected"},
            new ExampleWithDetail() {Title ="Test 2" , Detail ="This is also only visible if this ListViewItem is selected Like 'Test 1'"},
            new ExampleWithDetail() {Title ="Test 3" , Detail ="Another Test"},
        };
    }
}
