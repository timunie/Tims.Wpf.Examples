using HamburgerMenuCompositeExample.Model;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace HamburgerMenuCompositeExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        ViewModel ViewModel => DataContext as ViewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (var file in files)
                {
                    var fileAtribute = File.GetAttributes(file);
                    if (fileAtribute == FileAttributes.Directory)
                    {
                        ViewModel.AddFolder(file);
                    }
                    else
                    {
                        if (ViewModel.AllowedImageFiles.Contains("*" + Path.GetExtension(file)))
                        {
                            ViewModel.Images.Add(file);
                        }
                    }
                }
            }
        }

        private void ListView_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Effects = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }
    }
}
