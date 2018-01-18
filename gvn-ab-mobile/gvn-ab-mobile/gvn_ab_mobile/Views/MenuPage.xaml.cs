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
        public Models.Cbo Cbo { get; set; }
        public Models.Profissional Profissional { get; set; }

        public bool CboCadastroIndividual {
            get {
                string[] CbosAltorizados = new string[] { "322205", "322210", "322230", "322245", "322250", "322405", "322415", "322425", "322430", "352210", "515105", "515120", "515125", "515130", "515140", "515305", "515310", "422110" };
                return CbosAltorizados.Any(o => o.Equals(this.Cbo.CodCbo));
            }
        }

        public MenuPage(Models.Profissional profissional, Models.Cbo cbo) {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            this.Cbo = cbo;
            this.Profissional = profissional;

            this.BindingContext = this;
        }

        public MenuPage(Models.Profissional Usuario) {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            this.BindingContext = this;
            this.Profissional = Usuario;
        }

        async void OnAtendimentoIndividualClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage1());
        }

        async void OnCadastroIndividualClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new FichaCadastroIndividualPage.FichaCadastroIndividualPage1());
        }

        async void OnCadastroDomiciliarClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage1());
        }

        async void OnVisitaDomiciliarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FichaVisitaDomiciliarPage.FichaVisitaDomiciliarPage1());
        }

        private void OnSairClicked(object sender, EventArgs e) {
            App.Current.MainPage = new NavigationPage(new Views.Login.LoginPage()) { BarBackgroundColor = Color.FromHex("#003264") };
        }
    }
}