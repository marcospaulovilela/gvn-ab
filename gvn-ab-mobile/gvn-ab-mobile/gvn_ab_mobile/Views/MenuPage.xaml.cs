using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage {
        public MenuPage() {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
        }

        async void OnAtendimentoIndividualClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage1());
        }

        async void OnCadastroIndividualClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FichaCadastroIndividualPage.FichaCadastroIndividualPage1());
        }

        async void OnCadastroDomiciliarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage1());
        }

    }
}