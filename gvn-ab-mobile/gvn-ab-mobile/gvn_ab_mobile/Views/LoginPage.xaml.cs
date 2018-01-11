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


            System.Collections.Generic.List<Models.Cbo> cbo = new DAO.DAOCbo().Select();
            System.Collections.Generic.List<Models.Profissional> profissionais = new DAO.DAOProfissional().Select();
        }
    }
}