﻿using System;
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
            this.ViewModel.LoadSend();
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
            await Navigation.PushAsync(new FichaCadastroIndividualPage.ListFichaCadastroIndividual(this));
            //await Navigation.PushAsync(new FichaCadastroIndividualPage.FichaCadastroIndividualPage1(new ViewModels.FichaCadastroIndividualViewModel(this)));
        }

        async void OnCadastroDomiciliarClicked(object sender, EventArgs e) {
            //var viewModelCadastroDomiciliar = new ViewModels.FichaCadastroDomiciliarViewModel(this);
            await Navigation.PushAsync(new FichaCadastroDomiciliarPage.ListFichaCadastroDomiciliar(this));

            //await Navigation.PushAsync(new FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage1(viewModelCadastroDomiciliar));
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