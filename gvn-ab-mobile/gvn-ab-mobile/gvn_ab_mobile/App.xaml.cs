using gvn_ab_mobile.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace gvn_ab_mobile {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage() {
            Current.MainPage = new NavigationPage(new Views.Login.LoginPage()) {
                BarBackgroundColor = Color.FromHex("#003264")
            };
        }
    }
}
