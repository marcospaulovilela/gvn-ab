using gvn_ab_mobile.Helpers;
using MoreLinq;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Controls {
    public class TableGridItem : Helpers.ObservableObject {
        public ICommand Edit { get; }
        public ICommand Delete { get; }

        private TableGrid tableGrid;
        public TableGridItem(object data, TableGrid tableGrid) {
            this.Edit = new Command(async () => await this.tableGrid.viewModel.EditItemAsync(this));
            this.Delete = new Command(() => this.tableGrid.viewModel.DeleteItem(this));

            this.Data = data;
            this.tableGrid = tableGrid;
        }

        public object Data { get; set; }
        public string toString {
            get {
                return this.Data?.ToString();
            }
        }
    }

    public class TableGridViewModel : ViewModels.BaseViewModel {
        public ICommand Add { get; }

        private TableGrid Control { get; set; }

        public TableGridViewModel(TableGrid control) {
            this.Control = control;
            this.ItemsForListView = new ObservableCollection<TableGridItem>();
            this.Add = new Command(async () => await this.AddExecuteAsync());

        }

        private async Task AddExecuteAsync() {
            var item = System.Activator.CreateInstance(Type.GetType(this.Control.ItemType));
            var page = (TableGridPage)System.Activator.CreateInstance(Type.GetType(this.Control.ItemPage), this, item);

            await this.Control.Navigation.PushModalAsync(page);
        }

        public void SaveItem(object item) {
            if (!this.Control.Items.Contains(item)) {
                this.Control.Items.Add(item);
            };
            TableGrid.OnItemsSourceChanged(this.Control, this.Control.Items, this.Control.Items);
        }

        public async Task EditItemAsync(TableGridItem item) {
            var page = (TableGridPage)System.Activator.CreateInstance(Type.GetType(this.Control.ItemPage), this, item.Data);
            await this.Control.Navigation.PushModalAsync(page);
        }

        public void DeleteItem(TableGridItem item) {
            this.Control.Items.Remove(item.Data);
            TableGrid.OnItemsSourceChanged(this.Control, this.Control.Items, this.Control.Items);
        }

        public void Back() {
            this.Control.Navigation.PopModalAsync();
        }

        private ObservableCollection<TableGridItem> itemsForListView;
        public ObservableCollection<TableGridItem> ItemsForListView {
            get { return itemsForListView; }
            set { SetProperty(ref itemsForListView, value); }
        }
    }

    public partial class TableGrid : ContentView {
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<object>), typeof(TableGrid), null, BindingMode.TwoWay, propertyChanged: OnItemsSourceChanged);

        public string ItemType { get; set; }
        public string ItemPage { get; set; }

        public ICommand Add { get; }

        public ObservableCollection<object> Items {
            get { return (ObservableCollection<object>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue) {
            var self = ((TableGrid)bindable);

            var value = ((ObservableCollection<object>)newValue);
            self.viewModel.ItemsForListView = new ObservableCollection<TableGridItem>(value.Select(o => new TableGridItem(o, self)));
        }

        public string Title {
            get { return this.viewModel.Title; }
            set { this.viewModel.Title = value; }
        }

        public TableGridViewModel viewModel { get; set; }
        public TableGrid() {
            InitializeComponent();

            this.Content.BindingContext = this.viewModel = new TableGridViewModel(this);
        }

        private void ListViewBugado_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            ((ListView)sender).SelectedItem = null;
        }
    }
}