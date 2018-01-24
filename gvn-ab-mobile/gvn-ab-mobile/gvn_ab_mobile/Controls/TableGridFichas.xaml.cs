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

namespace gvn_ab_mobile.Controls
{
    public class TableGridFichasItem : Helpers.ObservableObject
    {
        public ICommand Edit { get; }
        public ICommand Delete { get; }

        private TableGridFichas tableGrid;
        public TableGridFichasItem(object data, TableGridFichas tableGrid)
        {
            this.Edit = new Command(async () => await this.tableGrid.viewModel.EditItemAsync(this));
            this.Delete = new Command(() => this.tableGrid.viewModel.DeleteItem(this));

            this.Data = data;
            this.tableGrid = tableGrid;
        }

        public object Data { get; set; }
        public string toString
        {
            get
            {
                return this.Data?.ToString();
            }
        }
    }

    public class TableGridFichasViewModel : ViewModels.BaseViewModel
    {
        public ICommand Add { get; }

        private TableGridFichas Control { get; set; }

        public TableGridFichasViewModel(TableGridFichas control)
        {
            this.Control = control;
            this.ItemsForListView = new ObservableCollection<TableGridFichasItem>();
            this.Add = new Command(async () => await this.AddExecuteAsync());

        }

        private async Task AddExecuteAsync()
        {
            var item = System.Activator.CreateInstance(Type.GetType(this.Control.ItemType));
            var page = (TableGridPage)System.Activator.CreateInstance(Type.GetType(this.Control.ItemPage), this, item);

            await this.Control.Navigation.PushModalAsync(page);
        }

        public void SaveItem(object item)
        {
            if (!this.Control.Items.Contains(item))
            {
                this.Control.Items.Add(item);
            };
            TableGrid.OnItemsSourceChanged(this.Control, this.Control.Items, this.Control.Items);
        }

        public async Task EditItemAsync(TableGridFichasItem item)
        {
            var page = (TableGridPage)System.Activator.CreateInstance(Type.GetType(this.Control.ItemPage), this, item.Data);
            await this.Control.Navigation.PushModalAsync(page);
        }

        public void DeleteItem(TableGridFichasItem item)
        {
            this.Control.Items.Remove(item.Data);
            TableGridFichas.OnItemsSourceChanged(this.Control, this.Control.Items, this.Control.Items);
        }

        public void Back()
        {
            this.Control.Navigation.PopModalAsync();
        }

        private ObservableCollection<TableGridFichasItem> itemsForListView;
        public ObservableCollection<TableGridFichasItem> ItemsForListView
        {
            get { return itemsForListView; }
            set { SetProperty(ref itemsForListView, value); }
        }
    }

    public partial class TableGridFichas : ContentView
    {
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<object>), typeof(TableGridFichas), null, BindingMode.TwoWay, propertyChanged: OnItemsSourceChanged);

        public string ItemType { get; set; }
        public string ItemPage { get; set; }

        public ICommand Add { get; }

        public ObservableCollection<object> Items
        {
            get { return (ObservableCollection<object>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var self = ((TableGridFichas)bindable);

            var value = ((ObservableCollection<object>)newValue);
            self.viewModel.ItemsForListView = new ObservableCollection<TableGridFichasItem>(value.Select(o => new TableGridFichasItem(o, self)));
        }

        public string Title
        {
            get { return this.viewModel.Title; }
            set { this.viewModel.Title = value; }
        }

        public TableGridFichasViewModel viewModel { get; set; }
        public TableGridFichas()
        {
            InitializeComponent();

            this.Content.BindingContext = this.viewModel = new TableGridFichasViewModel(this);
        }

        private void ListViewBugado_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}