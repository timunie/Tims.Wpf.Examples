using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DynamicDataExample.Model
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            _listItemsCache
                .Connect()
                //.Sort(SortExpressionComparer<ListItem>.Ascending(x => x.ID))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _ListItems)
                .Subscribe();

            CreateTestData(false);

        }

        private readonly SourceCache<ListItem, int> _listItemsCache = new SourceCache<ListItem, int>(x => x.ID);

        private readonly ReadOnlyObservableCollection<ListItem> _ListItems;
        public ReadOnlyObservableCollection<ListItem> ListItems => _ListItems;


        private string _Filter;

        /// <summary>
        /// A filter to search for an item.
        /// </summary>
        public string Filter
        {
            get { return _Filter; }
            set { this.RaiseAndSetIfChanged(ref _Filter, value); }
        }


        public void CreateTestData(bool fastInsert = true)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            if (fastInsert)
            {
                _listItemsCache.Edit((x) =>
                {
                    x.Clear();
                    for (int i = 0; i < 5_000; i++)
                    {
                        x.AddOrUpdate(new ListItem() { ID = i, Content = $"Some Content {i:N0}" });
                    }
                });
            }
            else
            {
                for (int i = 0; i < 5_000; i++)
                {
                    _listItemsCache.AddOrUpdate(new ListItem() { ID = i, Content = $"Some Content {i:N0}" });
                }
            }

            stopwatch.Stop();

            MessageBox.Show($"The update took {stopwatch.ElapsedMilliseconds} ms");

        }

    }
}
