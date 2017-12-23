using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SincronizacaoConfigPage2 : ContentPage {
        ViewModels.SincronizacaoConfigViewModel viewModel;

        public SincronizacaoConfigPage2(ViewModels.SincronizacaoConfigViewModel viewModel) {
            InitializeComponent();

            Versao.SelectedIndex = 0;
            this.BindingContext = this.viewModel = viewModel;

            var a = this.FindByName<Picker>("Versao");
            var a1 = this.FindByName<Entry>("cpf");
            var a2 = this.FindByName<Picker>("Unidade");
        }
    }
}