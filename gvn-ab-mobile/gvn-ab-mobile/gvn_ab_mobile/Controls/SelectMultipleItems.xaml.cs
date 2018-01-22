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
    public class SelectItem : Helpers.ObservableObject {
        public object Data { get; set; }
        
        private bool isSeleced = false;
        public bool IsSelected {
            get { return this.isSeleced; }
            set { SetProperty(ref isSeleced, value); }
        }

        public string toString {
            get {
                return this.Data?.ToString();
            }
        }
    }

    public class SelectMultipleItemsViewModel : ViewModels.BaseViewModel {
        public Controls.SelectMultipleItems SelectMultipleItems { get; set; }

        public ICommand Finalizar { get; }

        private string placeholder = "Selecione ...";
        public string Placeholder {
            get { return placeholder; }
            set { SetProperty(ref placeholder, value); }
        }

        public ObservableRangeCollection<SelectItem> ItemsForListView { get; set; }

        public SelectMultipleItemsViewModel(Controls.SelectMultipleItems selectMultipleItems) {
            this.Title = "Selecione...";

            this.ItemsForListView = new ObservableRangeCollection<SelectItem>();

            this.Finalizar = new Command(async () =>  await FinalizarExecuteAsync());
            this.SelectMultipleItems = selectMultipleItems;
        }

        async Task FinalizarExecuteAsync() {
            if (this.SelectMultipleItems.SelectedItems == null) {
                this.Title = "Eeee...";
            } else {
                this.SelectMultipleItems.SelectedItems.Clear();
                foreach (var SelectedItem in this.ItemsForListView.Where(o => o.IsSelected).Select(o => o.Data)) {
                    this.SelectMultipleItems.SelectedItems.Add(SelectedItem);
                };
                this.Title = this.SelectMultipleItems?.SelectedItems?.Any() ?? false ? string.Join(", ", this.SelectMultipleItems.SelectedItems) : "Selecione ...";

                this.SelectMultipleItems.InvokeEvenHandler();
                await PopupNavigation.PopAsync();
            };
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectMultipleItems : ContentView {
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(IEnumerable<object>), typeof(SelectMultipleItems), null, BindingMode.TwoWay, propertyChanged: OnItemsSourceChanged);
        public static readonly BindableProperty SelectedItemsProperty = BindableProperty.Create(nameof(SelectedItems), typeof(ObservableCollection<object>), typeof(SelectMultipleItems), null, BindingMode.TwoWay, propertyChanged: OnSelectedItemsChanged);

        public event EventHandler SelectedItemsChanged;
        public void InvokeEvenHandler() {
            this.SelectedItemsChanged(this, new EventArgs());
        }

        public IEnumerable<object> Items {
            get { return (IEnumerable<object>)GetValue(ItemsProperty); }
        }

        public ObservableCollection<object> SelectedItems {
            get { return (ObservableCollection<object>)GetValue(SelectedItemsProperty); }
        }

        static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue) {
            var self = ((SelectMultipleItems)bindable);

            self.ViewModel.ItemsForListView?.Clear();
            self.ViewModel.ItemsForListView?.AddRange(self.Items?.Select(o => new SelectItem() {
                Data = o,
                IsSelected = self.SelectedItems?.Contains(o) ?? false
            }));

            self.ViewModel.Title = self.SelectedItems?.Any() ?? false ? string.Join(", ", self.SelectedItems) : "Selecione ...";
        }

        static void OnSelectedItemsChanged(BindableObject bindable, object oldValue, object newValue) {
            var self = ((SelectMultipleItems)bindable);

            self.ViewModel.Title = self.SelectedItems?.Any() ?? false ? string.Join(", ", self.SelectedItems) : "Selecione ...";
            self.InvokeEvenHandler();
        }

        public string Placeholder {
            get { return this.ViewModel.Placeholder; }
            set { this.ViewModel.Placeholder = value; }
        }

        private SelectMultipleItemsViewModel ViewModel { get; set; }
        public SelectMultipleItems() {
            InitializeComponent();

            this.Content.BindingContext = this.ViewModel = new SelectMultipleItemsViewModel(this);
            this.LabelItems.GestureRecognizers.Add(new TapGestureRecognizer {
                Command = new Command(async () => {
                    await PopupNavigation.PushAsync(new SelectMultipleItemsPopUp(this.ViewModel));
                })
            });
        }

        public void SetBackgroundColor(Color color) {
            this.LabelItems.BackgroundColor = color;
        }
    }
}