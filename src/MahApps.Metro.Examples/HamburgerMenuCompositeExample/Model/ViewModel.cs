using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TimsWpfControls.Model;

namespace HamburgerMenuCompositeExample.Model
{
    public class ViewModel : BaseClass
    {

        public ViewModel()
        {
            Images.CollectionChanged += Images_CollectionChanged;
            AddFolder(Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures));
        }


        internal static readonly string[] AllowedImageFiles = 
        {
            "*.jpg",
            "*.jpeg",
            "*.gif",
            "*.png",
            "*.tiff"
        };

        public ObservableCollection<string> Images { get; } = new ObservableCollection<string>();

        public bool HasImages => Images.Count > 0;

        private void Images_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(HasImages));
        }


        private RelayCommand _AddImagesCommand;
        public RelayCommand AddImagesCommand
        {
            get { return _AddImagesCommand ??= new RelayCommand((param) => AddImages()); }
        }

        private void AddImages()
        {
            var dlg = new OpenFileDialog
            {
                Filter = $"Image Files ({string.Join(";", AllowedImageFiles)})|{string.Join(";", AllowedImageFiles)}|All files (*.*)|*.*",
                Multiselect = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (dlg.ShowDialog() == true)
            {
                foreach (var file in dlg.FileNames)
                {
                    Images.Add(file);
                }
            }
        }

        private RelayCommand _AddFolderCommand;
        public RelayCommand AddFolderCommand
        {
            get { return _AddFolderCommand ??= new RelayCommand((param) => AddFolder(null)); }
        }

        internal async void AddFolder(string FolderName)
        {
            if (string.IsNullOrEmpty(FolderName))
            {
                var dialog = new CommonOpenFileDialog
                {
                    IsFolderPicker = true,
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                };

                if (dialog.ShowDialog()== CommonFileDialogResult.Ok)
                {
                    FolderName = dialog.FileName;
                }
            }
            var images = new List<string>();

            await Task.Run(() =>
            {
                if (Directory.Exists(FolderName ?? string.Empty))
                {
                    foreach (var file in Directory.GetFiles(FolderName, "", SearchOption.AllDirectories))
                    {
                        if (AllowedImageFiles.Contains("*" + Path.GetExtension(file)))
                        {
                            images.Add(file);
                        }
                    }
                }
            });

            foreach (var item in images)
            {
                Images.Add(item);
            }
            
        }

        private RelayCommand _ClearCollectionCommand;
        public RelayCommand ClearCollectionCommand
        {
            get { return _ClearCollectionCommand ??= new RelayCommand((param) => Clear()); }
            set { _ClearCollectionCommand = value; RaisePropertyChanged(nameof(ClearCollectionCommand)); }
        }

        private void Clear()
        {
            Images.Clear();
        }

    }
}
