using ObservableCollectionExample.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ObservableCollectionExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private CustomItem cItem;
        private ObservableCollection<CustomItem> customItemsObservableCollection;

        public MainWindowViewModel()
        {
            ButtonCommand = ReactiveCommand.Create<CustomItem>(
                item =>
                {
                    CItem = item;
                });

            AddItemCommand = ReactiveCommand.Create(() => { CustomItemsObservableCollection.Add(new CustomItem { Text = "Item1", ButtonText = "Click Me!", ImagePath = "Assets/pic/christmas-sock.png" });  });
            DeleteItemCommand = ReactiveCommand.Create(() => { CustomItemsObservableCollection.RemoveAt(CustomItemsObservableCollection.Count - 1);});

            customItemsObservableCollection = new ObservableCollection<CustomItem>();
            customItemsObservableCollection.Add(new CustomItem { Text = "Item1", ButtonText = "Click Me!", ImagePath = "Assets/pic/christmas-sock.png" });
            customItemsObservableCollection.Add(new CustomItem { Text = "Item2", ButtonText = "Click Me!", ImagePath = "Assets/pic/earmuffs.png" });
            customItemsObservableCollection.Add(new CustomItem { Text = "Item3", ButtonText = "Click Me!", ImagePath = "Assets/pic/heater.png" });
            customItemsObservableCollection.Add(new CustomItem { Text = "Item4", ButtonText = "Click Me!", ImagePath = "Assets/pic/hot-drink.png" });
            customItemsObservableCollection.Add(new CustomItem { Text = "Item5", ButtonText = "Click Me!", ImagePath = "Assets/pic/mountain.png" });
            customItemsObservableCollection.Add(new CustomItem { Text = "Item6", ButtonText = "Click Me!", ImagePath = "Assets/pic/penguin.png" });
            customItemsObservableCollection.Add(new CustomItem { Text = "Item7", ButtonText = "Click Me!", ImagePath = "Assets/pic/pine-tree.png" });
            customItemsObservableCollection.Add(new CustomItem { Text = "Item8", ButtonText = "Click Me!", ImagePath = "Assets/pic/snowman.png" });
        }

        public CustomItem CItem
        {
            get => cItem;
            set
            {
                this.RaiseAndSetIfChanged(ref cItem, value);
            }
        }

        public ObservableCollection<CustomItem> CustomItemsObservableCollection
        {
            get => customItemsObservableCollection;
            set
            {
                this.RaiseAndSetIfChanged(ref customItemsObservableCollection, value);
            }
        }

        public ReactiveCommand<CustomItem,Unit> ButtonCommand { get; }
        public ReactiveCommand<Unit, Unit> AddItemCommand { get; }
        public ReactiveCommand<Unit, Unit> DeleteItemCommand { get; }
    }
}
