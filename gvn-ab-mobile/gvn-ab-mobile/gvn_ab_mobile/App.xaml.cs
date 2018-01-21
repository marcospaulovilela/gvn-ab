using gvn_ab_mobile.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace gvn_ab_mobile {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            RestartWizard();

            SetMainPage();
        }

        public static void SetMainPage() {
            Current.MainPage = new NavigationPage(new Views.Login.LoginPage()) {
                BarBackgroundColor = Color.FromHex("#003264")
            };
        }

        private Models.AssinaturaTermoRecusa.TermoDeRecusaModel termoDeRecusa;
        public Models.AssinaturaTermoRecusa.TermoDeRecusaModel TermoDeRecusa => termoDeRecusa;

        public static new App Current => ((App)Application.Current);

        public void RestartWizard()
        {
            termoDeRecusa = new Models.AssinaturaTermoRecusa.TermoDeRecusaModel();

        }

        public void CompleteWizard()
        {
            MainPage = new NavigationPage(new Views.Login.LoginPage());
        }
    }
}
