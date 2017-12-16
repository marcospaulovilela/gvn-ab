
using gvn_ab_mobile.ViewModels;

using Xamarin.Forms;

namespace gvn_ab_mobile.Views {
    public partial class UsuarioPage : ContentPage {
        UsuarioViewModel viewModel;

        public UsuarioPage() {
            InitializeComponent();
        }

        public UsuarioPage(UsuarioViewModel viewModel) {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }
    }
}
