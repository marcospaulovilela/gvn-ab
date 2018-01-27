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
    public class PickerSearchViewModel : ViewModels.BaseViewModel {
        private string placeholder = "Selecione ...";
        public string Placeholder {
            get { return placeholder; }
            set { SetProperty(ref placeholder, value); }
        }

        private bool isEnabled = true;
        public bool IsEnabled {
            get { return isEnabled; }
            set { SetProperty(ref isEnabled, value); }
        }


        private string filtro = string.Empty;
        public string Filtro {
            get { return filtro; }
            set {
                SetProperty(ref filtro, value);

                this.Items = this.Control.Items.Where(o => o.ToString().ToLower().IndexOf(value.ToLower()) != -1).ToList();
            }
        }

        private List<object> items;
        public List<object> Items {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public ICommand Cancelar { get; }

        private PickerSearch Control { get; set; }
        public PickerSearchViewModel(PickerSearch control) {
            this.Title = "Selecione ...";
            this.Control = control;
            
            this.Cancelar = new Command(async () => await FinalizarAsync(null) );
        }

        public async Task FinalizarAsync(object selectedItem) {
            this.Control.SelectedItem = selectedItem;
            this.Title = this.Control.SelectedItem?.ToString() ?? "Selecione ...";
            this.Control.InvokeEvenHandler();

            await PopupNavigation.PopAsync();
        }
    }

   public partial class PickerSearch : ContentView{
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(IEnumerable<object>), typeof(SelectMultipleItemsViewModel), null, BindingMode.TwoWay, propertyChanged: OnItemsSourceChanged);
        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(SelectMultipleItemsViewModel), null, BindingMode.TwoWay, propertyChanged: OnSelectedItemChanged);

        public event EventHandler SelectedItemChanged;
        public void InvokeEvenHandler() {
            this.SelectedItemChanged(this, new EventArgs());
        }

        public IEnumerable<object> Items {
            get { return (IEnumerable<object>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue) {
            var self = ((PickerSearch)bindable);

            var value = ((IEnumerable<object>)newValue);
            self.viewModel.Items = value.ToList();
        }

        static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue) {
            var self = ((PickerSearch)bindable);
            self.viewModel.Title = self.SelectedItem?.ToString() ?? "Selecione ...";
            self.InvokeEvenHandler();
        }

        public object SelectedItem {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public string Placeholder {
            get { return this.viewModel.Placeholder; }
            set { this.viewModel.Placeholder = value; }
        }

        public bool Enabled {
            get { return this.viewModel.IsEnabled; }
            set { this.viewModel.IsEnabled = value; }
        }

        public PickerSearchViewModel viewModel { get; set; }
        public PickerSearch() {
            InitializeComponent();

            this.Content.BindingContext = this.viewModel = new PickerSearchViewModel(this);
            this.LabelItems.GestureRecognizers.Add(new TapGestureRecognizer {
                Command = new Command(async () => {
                    this.viewModel.Filtro = string.Empty;
                    await PopupNavigation.PushAsync(new PickerSearchPopUp(this.viewModel));
                })
            });
        }

        public void SetBackgroundColor(Color color) {
            this.LabelItems.BackgroundColor = color;
        }
    }
}