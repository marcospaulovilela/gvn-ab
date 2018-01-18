using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.Controls {
    public abstract class TableGridPage : ContentPage {
        public object Item { get; set; }
        public TableGridViewModel ViewModel { get; set; }

        public ICommand Save { get; }
        public ICommand Cancel { get; }

        public TableGridPage(TableGridViewModel viewModel, object item) {
            this.Item = item;
            this.ViewModel = viewModel;
            this.BindingContext = this;

            this.Save = new Command(() => this.SaveExecute());
            this.Cancel = new Command(() => this.CancelExecute());
        }

        private void SaveExecute() {
            this.ViewModel.SaveItem(this.Item);
            this.CancelExecute();
        }

        private void CancelExecute() {
            this.ViewModel.Back();
        }
    }
}