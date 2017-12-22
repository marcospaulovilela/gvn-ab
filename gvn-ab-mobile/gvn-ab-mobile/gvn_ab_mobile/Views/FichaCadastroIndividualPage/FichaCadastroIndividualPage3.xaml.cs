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
    public partial class FichaCadastroIndividualPage3 : ContentPage
    {
        ViewModels.FichaCadastroIndividualViewModel viewModel;

        public FichaCadastroIndividualPage3()
        {
            InitializeComponent();
            this.BindingContext = this.viewModel = new ViewModels.FichaCadastroIndividualViewModel(this);
        }
    }
}