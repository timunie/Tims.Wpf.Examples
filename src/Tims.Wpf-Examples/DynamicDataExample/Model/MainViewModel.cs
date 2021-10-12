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
            var filterPredicate = this.WhenAnyValue(x => x.Filter)
                          .Throttle(TimeSpan.FromMilliseconds(250), RxApp.MainThreadScheduler)
                          .DistinctUntilChanged()
                          .Select(listItemFilter);

            _listItemsCache
                .Connect()
                .Sort(SortExpressionComparer<ListItem>.Ascending(x => x.ID))
                .ObserveOn(RxApp.MainThreadScheduler)
                .AutoRefresh(x => x.Content, TimeSpan.FromMilliseconds(200))
                .Filter(filterPredicate)
                .Bind(out _ListItems)
                .Subscribe();

            CreateTestData(false);

            
        }

        private readonly SourceList<ListItem> _listItemsCache = new SourceList<ListItem>();

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

        Func<ListItem, bool> listItemFilter(string text) => listItem =>
        {
            return string.IsNullOrEmpty(text) || listItem.Content.Contains(text, StringComparison.OrdinalIgnoreCase);
        };

        public void CreateTestData(bool fastInsert = true)
        {
            _listItemsCache.Clear();

            if (fastInsert)
            {
                _listItemsCache.Edit((x) =>
                {
                    x.Clear();
                    for (int i = 0; i < ItemsToGenerate; i++)
                    {
                        x.Add(new ListItem() { ID = i, Content = $"Some Content {i:N0}" });
                    }
                });
            }
            else
            {
                for (int i = 0; i < ItemsToGenerate; i++)
                {
                    _listItemsCache.Add(new ListItem() { ID = i, Content = $"Some Content {i:N0}" });
                }
            }

        }


        private int _ItemsToGenerate = 5000;

        /// <summary>
        /// No of Items to generate
        /// </summary>
        public int ItemsToGenerate
        {
            get { return _ItemsToGenerate; }
            set { this.RaiseAndSetIfChanged(ref _ItemsToGenerate, value); }
        }

    }
}
