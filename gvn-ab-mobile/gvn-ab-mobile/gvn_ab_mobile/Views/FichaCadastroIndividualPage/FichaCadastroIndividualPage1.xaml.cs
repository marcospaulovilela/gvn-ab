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
    public partial class FichaCadastroIndividualPage1 : ContentPage
    {
        ViewModels.FichaCadastroIndividualViewModel viewModel;

        public FichaCadastroIndividualPage1()
        {
            InitializeComponent();
            this.BindingContext = this.viewModel = new ViewModels.FichaCadastroIndividualViewModel(this);
        }

        async void OnConcordaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FichaCadastroIndividualPage.FichaCadastroIndividualPage2());
        }
    }
}