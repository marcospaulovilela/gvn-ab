using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectMultipleItemsPopUp : Rg.Plugins.Popup.Pages.PopupPage {
		public SelectMultipleItemsPopUp(SelectMultipleItemsViewModel viewModel) {
            InitializeComponent();

            this.BindingContext = viewModel;
            this.CloseWhenBackgroundIsClicked = false;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            var selectedItem = (((ListView)sender).SelectedItem) as SelectItem;
            if(selectedItem != null) {
                selectedItem.IsSelected = !selectedItem.IsSelected;
            };

            ((ListView)sender).SelectedItem = null;
        }
    }
}