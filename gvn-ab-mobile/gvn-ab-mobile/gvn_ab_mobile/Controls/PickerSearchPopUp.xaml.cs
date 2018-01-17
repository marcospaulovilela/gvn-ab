using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerSearchPopUp : Rg.Plugins.Popup.Pages.PopupPage {
        private PickerSearchViewModel viewModel { get; set; }
		public PickerSearchPopUp(PickerSearchViewModel pickerSearch) {
            InitializeComponent();

            this.CloseWhenBackgroundIsClicked = false;
            this.BindingContext = viewModel = pickerSearch;
        }

        private async Task ListView_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e) {
            var listView = (ListView)sender;
            var obj = listView.SelectedItem;
            listView.SelectedItem = null;

            if(obj != null) await this.viewModel.FinalizarAsync(obj);
        }
    }
}