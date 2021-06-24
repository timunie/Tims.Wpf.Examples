using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WindowInDifferentThread
{
    /// <summary>
    /// Interaction logic for ChildWindow.xaml
    /// </summary>
    public partial class ChildWindow : Window
    {
        public SharedViewModel ViewModel { get; private set; }

        public ChildWindow()
        {
            InitializeComponent();
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateLocation();
        }


        public void SetViewModel(SharedViewModel sharedViewModel)
        {
            if (ViewModel is not null)
            {
                ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
            }

            ViewModel = sharedViewModel;
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;

            UpdateLocation();
        }

        private void UpdateLocation()
        {
            this.Dispatcher.InvokeAsync(() =>
            {
                var width = ViewModel.Width / 2;
                var height = ViewModel.Height / 2;

                this.Width = width;
                this.Height = height;

                var left = ViewModel.Left + ((ViewModel.Width - width) / 2);
                var top = ViewModel.Top + ((ViewModel.Height - height) / 2);

                this.Top = top;
                this.Left = left;
            }, DispatcherPriority.Send);
        }

    }
}
