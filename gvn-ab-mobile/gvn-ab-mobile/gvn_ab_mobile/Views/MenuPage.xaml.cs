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
        public Models.Profissional Profissional { get; set; }
        public Models.Cbo Cbo { get; set; }
        public Models.Equipe Equipe { get; set; }

        public bool CboCadastroIndividual {
            get {
                string[] CbosAltorizados = new string[] { "322205", "322210", "322230", "322245", "322250", "322405", "322415", "322425", "322430", "352210", "515105", "515120", "515125", "515130", "515140", "515305", "515310", "422110" };
                return true || CbosAltorizados.Any(o => o.Equals(this.Cbo.CodCbo));
            }
        }

        public bool CboCadastroDomiciliar {
            get {
                string[] CbosAltorizados = new string[] { "322205", "322210", "322230", "322245", "322250", "322405", "322415", "322425", "322430", "352210", "515105", "515120", "515125", "515130", "515140", "515305", "515310", "422110" };
                return true ||  CbosAltorizados.Any(o => o.Equals(this.Cbo.CodCbo));
            }
        }

        public bool CboVisitaDomiciliar {
            get {
                string[] CbosAltorizados = new string[] { "515105", "515120", "515310", "515140" };
                return true || CbosAltorizados.Any(o => o.Equals(this.Cbo.CodCbo));
            }
        }

        public MenuPage(Models.Profissional profissional, Models.Cbo cbo, Models.Equipe equipe) {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            this.Profissional = profissional;
            this.Cbo = cbo;
            this.Equipe = equipe;

            this.BindingContext = this;
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

        async void OnVisitaDomiciliarClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new FichaVisitaDomiciliarPage.FichaVisitaDomiciliarPage1());
        }

        private void OnSairClicked(object sender, EventArgs e) {
            App.Current.MainPage = new NavigationPage(new Views.Login.LoginPage()) { BarBackgroundColor = Color.FromHex("#003264") };
        }
    }
}