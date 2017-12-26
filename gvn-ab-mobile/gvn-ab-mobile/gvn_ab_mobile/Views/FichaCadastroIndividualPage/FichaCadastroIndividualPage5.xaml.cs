using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Views.FichaCadastroIndividualPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FichaCadastroIndividualPage5 : ContentPage
    {
        ViewModels.FichaCadastroIndividualViewModel viewModel;

        public FichaCadastroIndividualPage5(ViewModels.FichaCadastroIndividualViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = this.viewModel = viewModel;
        }
    }
}