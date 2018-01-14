using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using gvn_ab_mobile.Views.FichaCadastroIndividualPage;

namespace gvn_ab_mobile.Views.FichaCadastroIndividualPage {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FichaCadastroIndividualPage2 : ContentPage {
        ViewModels.FichaCadastroIndividualViewModel viewModel;

        public FichaCadastroIndividualPage2(ViewModels.FichaCadastroIndividualViewModel viewModel) {
            InitializeComponent();
            this.BindingContext = this.viewModel = viewModel;
        }

        private void Switch_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }
    }
}