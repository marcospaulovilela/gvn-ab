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

        public ViewModels.MenuViewModel ViewModel { get; set; }

        protected override void OnAppearing() {
            using (DAO.DAOFichaCadastroIndividual DAOFichaCadastroIndividual = new DAO.DAOFichaCadastroIndividual())
            using (DAO.DAOFichaCadastroDomiciliarTerritorial DAOFichaCadastroDomiciliar = new DAO.DAOFichaCadastroDomiciliarTerritorial())
            using (DAO.DAOFichaVisitaDomiciliar DAOFichaVisitaDomiciliar = new DAO.DAOFichaVisitaDomiciliar()) {
                var FichasCadastroIndividual = DAOFichaCadastroIndividual.Select();
                var FichasCadastroDomiciliar = DAOFichaCadastroDomiciliar.Select();
                var FichasVisitaDomociliar = DAOFichaVisitaDomiciliar.Select();

                var nFichas = FichasCadastroIndividual.Count + FichasCadastroDomiciliar.Count + FichasVisitaDomociliar.Count;

                if (this.ViewModel.HasFichas = nFichas > 0) {
                    this.ViewModel.SendText = $"Enviar fichas ({nFichas})";
                } else {
                    this.ViewModel.SendText = "Enviar fichas";
                };
            };
        }

        public MenuPage(Models.Profissional profissional, Models.Cbo cbo, Models.Equipe equipe) {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            this.BindingContext = this.ViewModel = new ViewModels.MenuViewModel(this, profissional, cbo, equipe);
        }

        async void OnAtendimentoIndividualClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage1());
        }

        async void OnCadastroIndividualClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new FichaCadastroIndividualPage.FichaCadastroIndividualPage1(new ViewModels.FichaCadastroIndividualViewModel(this)));
        }

        async void OnCadastroDomiciliarClicked(object sender, EventArgs e) {
            var viewModelCadastroDomiciliar = new ViewModels.FichaCadastroDomiciliarViewModel(this);
            
            await Navigation.PushAsync(new FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage1(viewModelCadastroDomiciliar));
        }

        async void OnVisitaDomiciliarClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new FichaVisitaDomiciliarPage.ListFichaVisitaDomiciliarPage(this));
        }

        async void OnEnviarFichasClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new SalvarFichas.ListaFichasPage());
        }

        private void OnSairClicked(object sender, EventArgs e) {
            App.Current.MainPage = new NavigationPage(new Views.Login.LoginPage()) { BarBackgroundColor = Color.FromHex("#003264") };
        }
    }
}