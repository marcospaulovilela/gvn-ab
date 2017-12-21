using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage {
        ViewModels.LoginViewModel viewModel;

        public LoginPage() {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false); //DESATIVA A BARRA DE NAVEGAÇÃO
            InitializeComponent();

            this.BindingContext = this.viewModel = new ViewModels.LoginViewModel(this);
        }

        private async Task ButtonReset_ClickedAsync(object sender, EventArgs e) {
            var DAO = new DAO.DAOUsuario();
            DAO.ClearBase();
            DAO.Insert(new Models.Usuario() {
                Cpf = "123456789",
                Nome = "Usuario Teste",
                Password = "123",
                Root = true
            });
        }
    }
}