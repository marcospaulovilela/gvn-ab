using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using gvn_ab_mobile.Views.FichaAtendimentoIndividualPage;

namespace gvn_ab_mobile.Views.FichaAtendimentoIndividualPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FichaAtendimentoIndividualPage6 : ContentPage
    {
        ViewModels.FichaAtendimentoIndividualViewModel viewModel;

        public FichaAtendimentoIndividualPage6(ViewModels.FichaAtendimentoIndividualViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = this.viewModel = viewModel;
        }
    }
}