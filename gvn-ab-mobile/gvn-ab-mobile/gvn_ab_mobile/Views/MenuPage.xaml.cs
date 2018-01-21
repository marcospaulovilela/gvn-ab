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
            using (DAO.DAOFichaCadastroIndividual DAOFichaCadastroIndividual = new DAO.DAOFichaCadastroIndividual()) {
                var Fichas = DAOFichaCadastroIndividual.Select();

                if (this.ViewModel.HasFichas = Fichas.Any()) {
                    this.ViewModel.SendText = $"Enviar fichas ({Fichas.Count()})";
                } else {
                    this.ViewModel.SendText = "Enviar fichas";
                }
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