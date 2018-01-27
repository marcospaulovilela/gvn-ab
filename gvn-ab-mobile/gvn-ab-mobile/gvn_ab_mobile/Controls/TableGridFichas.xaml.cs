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
    public class TableGridFichasItem : Helpers.ObservableObject {
        public ICommand Edit { get; }
        public ICommand Delete { get; }
        public bool IsVisible { get; set; }

        private TableGridFichas tableGrid;
        public TableGridFichasItem(object data, TableGridFichas tableGrid) {
            this.Edit = new Command(() => this.tableGrid.EditItems(this));
            this.Delete = new Command(() => this.tableGrid.DeleteItem(this));

            this.IsVisible = tableGrid.CanEdit;

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

    public class TableGridFichasViewModel : ViewModels.BaseViewModel {
      
        public TableGridFichas Control { get; }
        public ObservableRangeCollection<TableGridFichasItem> ItemsForListView { get; } = new ObservableRangeCollection<TableGridFichasItem>();
        
        public TableGridFichasViewModel(TableGridFichas control) {
            this.Control = control;
        }
    }

    public partial class TableGridFichas : ContentView {
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableRangeCollection<object>), typeof(TableGridFichas), null, BindingMode.TwoWay, propertyChanged: OnItemsSourceChanged);
        public static readonly BindableProperty DeleteProperty = BindableProperty.Create(nameof(Delete), typeof(ICommand), typeof(TableGridFichas), null);
        public static readonly BindableProperty AddProperty = BindableProperty.Create(nameof(Add), typeof(ICommand), typeof(TableGridFichas), null);
        public static readonly BindableProperty EditProperty = BindableProperty.Create(nameof(Edit), typeof(ICommand), typeof(TableGridFichas), null);

        public ObservableRangeCollection<object> Items {
            get { return (ObservableRangeCollection<object>)GetValue(ItemsProperty); }
        }

        public ICommand Add { get { return (ICommand)GetValue(AddProperty); } }
        public ICommand Edit { get { return (ICommand)GetValue(EditProperty); } }
        public void EditItems(TableGridFichasItem item) {
            this.Edit?.Execute(item.Data);
        }

        public ICommand Delete { get { return (ICommand)GetValue(DeleteProperty); } }
        public void DeleteItem(TableGridFichasItem item) {
            this.Delete?.Execute(item.Data);
        }

        public bool CanEdit { get; set; } = true;

        public static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue) {
            var self = ((TableGridFichas)bindable);

            var value = ((ObservableRangeCollection<object>)newValue);
            self.viewModel.ItemsForListView.Clear();
            self.viewModel.ItemsForListView.AddRange(new ObservableRangeCollection<TableGridFichasItem>(value.Select(o => new TableGridFichasItem(o, self))));
        }

        public string ItemPage { get; set; }
        public TableGridFichasViewModel viewModel { get; }

        public string Title {
            get { return this.viewModel.Title; }
            set { this.viewModel.Title = value; }
        }

        public TableGridFichas() {
            InitializeComponent();

            this.Content.BindingContext = this.viewModel = new TableGridFichasViewModel(this);
        }

        private void ListViewBugado_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            var obj = ((ListView)sender).SelectedItem as TableGridFichasItem;
            ((ListView)sender).SelectedItem = null;

            if (obj == null || !this.CanEdit) return;

            obj.Edit.Execute(null);
        }
    }
}