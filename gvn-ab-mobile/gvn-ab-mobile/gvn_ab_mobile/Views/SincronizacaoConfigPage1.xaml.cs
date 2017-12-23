using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SincronizacaoConfigPage1 : ContentPage {
        ViewModels.SincronizacaoConfigViewModel viewModel;

        public SincronizacaoConfigPage1() {
            InitializeComponent();

            this.BindingContext = this.viewModel = new ViewModels.SincronizacaoConfigViewModel(this);
        }
    }
}