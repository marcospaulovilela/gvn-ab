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

        public FichaCadastroIndividualPage2() {
            InitializeComponent();
            this.BindingContext = this.viewModel = new ViewModels.FichaCadastroIndividualViewModel(this);
        }
    }
}