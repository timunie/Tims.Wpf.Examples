using ControlzEx.Theming;
using MahApps.Metro.Controls;
using MahApps.Metro.Theming;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomThemesExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonApplyTheme_Click(object sender, RoutedEventArgs e)
        {
            App.SetAppTheme(ComboBoxBaseTheme.SelectedItem as string, ColorPickerAccent.SelectedColor.Value);
        }
    }
}
