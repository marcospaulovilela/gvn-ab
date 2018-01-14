using gvn_ab_mobile.Helpers;
using MoreLinq;
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectMultipleItems : ContentView {
        class SelectItem {
            public Color BackgroundColor { get; set; }
            public object Data { get; set; }
            public bool IsSelected { get; set; }

            public string toString {
                get {
                    return this.Data?.ToString();
                }
            }
        }

        class SelectMultipleItemsViewModel : ViewModels.BaseViewModel {
            public Controls.SelectMultipleItems SelectMultipleItems { get; set; }

            public ICommand Finalizar { get; }
            public ObservableRangeCollection<SelectItem> ItemsForListView { get; set; }

            public SelectMultipleItemsViewModel(Controls.SelectMultipleItems selectMultipleItems) {
                this.Title = "Selecione ...";
                this.IsBusy = false;
                
                this.ItemsForListView = new ObservableRangeCollection<SelectItem>();

                this.Finalizar = new Command(() => FinalizarExecute());
                this.SelectMultipleItems = selectMultipleItems;
            }

            public void AbrirModal() {
                this.IsBusy = true;
            }

            void FinalizarExecute() {
                if (this.SelectMultipleItems.SelectedItems == null) {
                    this.Title = "Eeee...";
                } else {
                    this.SelectMultipleItems.SelectedItems.Clear();
                    foreach (var SelectedItem in this.ItemsForListView.Where(o => o.IsSelected).Select(o => o.Data)) {
                        this.SelectMultipleItems.SelectedItems.Add(SelectedItem);
                    };
                    this.Title = this.SelectMultipleItems?.SelectedItems?.Any() ?? false ? string.Join(", ", this.SelectMultipleItems.SelectedItems) : "Selecione ...";
                    this.SelectMultipleItems.SelectedItemsChanged(this.SelectMultipleItems, new EventArgs());
                };

                this.IsBusy = false;
            }
        }

        public event EventHandler SelectedItemsChanged;

        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(IEnumerable<object>), typeof(SelectMultipleItemsViewModel), null, BindingMode.TwoWay, propertyChanged: OnItemsSourceChanged);
        public static readonly BindableProperty SelectedItemsProperty = BindableProperty.Create(nameof(SelectedItems), typeof(ObservableCollection<object>), typeof(SelectMultipleItemsViewModel), null, BindingMode.Default);
        
        public IEnumerable<object> Items {
            get { return (IEnumerable<object>)GetValue(ItemsProperty); }
        }

        public ObservableCollection<object> SelectedItems {
            get { return (ObservableCollection<object>)GetValue(SelectedItemsProperty); }
        }

        static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue) {
            var self = ((SelectMultipleItems)bindable);
            
            self.viewModel.ItemsForListView?.AddRange(self.Items?.Select(obj => new SelectItem() {
                Data = obj,
                IsSelected = false
            }));
        }

        private SelectMultipleItemsViewModel viewModel;
        public SelectMultipleItems() {
            InitializeComponent();

            this.Content.BindingContext = this.viewModel = new SelectMultipleItemsViewModel(this);
            this.LabelItems.GestureRecognizers.Add(new TapGestureRecognizer {
                Command = new Command(() => {
                    this.viewModel?.AbrirModal();
                })
            });
        }

        public void SetBackgroundColor(Color color) {
            this.viewModel.ItemsForListView.ForEach(o => o.BackgroundColor = color);
            this.LabelItems.BackgroundColor = color;
        }


    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
        ((ListView)sender).SelectedItem = null;
    }
}
}