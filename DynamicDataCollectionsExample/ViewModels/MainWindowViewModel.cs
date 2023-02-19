using DynamicData;
using DynamicDataCollectionsExample.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;

namespace DynamicDataCollectionsExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private CustomItem cItem;
        private readonly ReadOnlyObservableCollection<CustomItem> cItems;
        private readonly ReadOnlyObservableCollection<CustomItem> cItems2;
        private SourceList<CustomItem> sourceList;


        public MainWindowViewModel()
        {
            sourceList = new SourceList<CustomItem>();
            sourceList.Add(new CustomItem { Text = "Item1", ButtonText = "Click Me!", ImagePath = "Assets/pic/christmas-sock.png" });
            sourceList.Add(new CustomItem { Text = "Item2", ButtonText = "Click Me!", ImagePath = "Assets/pic/earmuffs.png" });
            sourceList.Add(new CustomItem { Text = "Item3", ButtonText = "Click Me!", ImagePath = "Assets/pic/heater.png" });
            sourceList.Add(new CustomItem { Text = "Item4", ButtonText = "Click Me!", ImagePath = "Assets/pic/hot-drink.png" });
            sourceList.Add(new CustomItem { Text = "Item5", ButtonText = "Click Me!", ImagePath = "Assets/pic/mountain.png" });
            sourceList.Add(new CustomItem { Text = "Item6", ButtonText = "Click Me!", ImagePath = "Assets/pic/penguin.png" });
            sourceList.Add(new CustomItem { Text = "Item7", ButtonText = "Click Me!", ImagePath = "Assets/pic/pine-tree.png" });
            sourceList.Add(new CustomItem { Text = "Item8", ButtonText = "Click Me!", ImagePath = "Assets/pic/snowman.png" });

            sourceList.Connect().AutoRefresh(x => x.Status).Filter(x => x.Status == true).ObserveOn(RxApp.MainThreadScheduler).Bind(out cItems).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Status).Filter(x => x.Status == false).ObserveOn(RxApp.MainThreadScheduler).Bind(out cItems2).Subscribe();

            ButtonCommand = ReactiveCommand.Create<CustomItem>(
                item =>
                {
                    CItem = item;
                    CItem.Status = !CItem.Status;
                });
        }

        public CustomItem CItem
        {
            get => cItem;
            set
            {
                this.RaiseAndSetIfChanged(ref cItem, value);
            }
        }

        public ReactiveCommand<CustomItem, Unit> ButtonCommand { get; }
        public ReadOnlyObservableCollection<CustomItem> CItems => cItems;
        public ReadOnlyObservableCollection<CustomItem> CItems2 => cItems2;
    }
}
