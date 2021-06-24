using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowInDifferentThread
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var vm = this.DataContext as SharedViewModel;

            var thread = new Thread(() =>
            {
                var child = new ChildWindow();
                child.Show();

                child.Dispatcher.InvokeAsync(() => { child.SetViewModel(vm); });

                // shut donw the other thread when child is closed.
                child.Closed += (_, __) => child.Dispatcher.BeginInvokeShutdown(System.Windows.Threading.DispatcherPriority.Background);

                System.Windows.Threading.Dispatcher.Run();
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
