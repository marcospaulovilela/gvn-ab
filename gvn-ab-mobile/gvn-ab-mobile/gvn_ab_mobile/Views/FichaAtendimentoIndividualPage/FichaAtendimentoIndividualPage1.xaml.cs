using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using gvn_ab_mobile.Views.FichaAtendimentoIndividualPage;

namespace gvn_ab_mobile.Views.FichaAtendimentoIndividualPage {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FichaAtendimentoIndividualPage1 : ContentPage {
        ViewModels.FichaAtendimentoIndividualViewModel viewModel;

        public FichaAtendimentoIndividualPage1() {
            InitializeComponent();
            this.BindingContext = this.viewModel = new ViewModels.FichaAtendimentoIndividualViewModel(this);
        }
    }
}