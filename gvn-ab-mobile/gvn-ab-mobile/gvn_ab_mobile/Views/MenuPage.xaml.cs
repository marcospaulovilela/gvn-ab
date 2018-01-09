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
        private Models.Usuario Usuario { get; set; }

        public MenuPage() {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            this.BindingContext = this;
        }

        public MenuPage(Models.Usuario Usuario) {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            this.BindingContext = this;
            this.Usuario = Usuario;
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

        private void OnSairClicked(object sender, EventArgs e) {
            App.Current.MainPage = new NavigationPage(new Views.LoginPage());
        }
    }
}