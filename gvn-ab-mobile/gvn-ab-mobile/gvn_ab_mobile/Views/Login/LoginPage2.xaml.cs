using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Views.Login {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage2 : ContentPage {
        ViewModels.LoginViewModel viewModel;

        public LoginPage2(ViewModels.LoginViewModel loginViewModel) {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false); //DESATIVA A BARRA DE NAVEGAÇÃO
            InitializeComponent();

            this.BindingContext = this.viewModel = loginViewModel;
        }

    }
}