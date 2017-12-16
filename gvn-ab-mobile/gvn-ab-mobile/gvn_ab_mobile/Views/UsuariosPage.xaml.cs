using System;

using gvn_ab_mobile.Models;
using gvn_ab_mobile.ViewModels;

using Xamarin.Forms;

namespace gvn_ab_mobile.Views {
    public partial class UsuariosPage : ContentPage {
        UsuariosViewModel viewModel;

        public UsuariosPage() {
            InitializeComponent();

            BindingContext = viewModel = new UsuariosViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args) {
            var usuario = args.SelectedItem as Usuario;
            if (usuario == null)
                return;

            await Navigation.PushAsync(new UsuarioPage(new UsuarioViewModel(usuario)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void Add_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new NewUsuarioPage());
        }

        protected override void OnAppearing() {
            base.OnAppearing();

            if (viewModel.Usuarios.Count == 0)
                viewModel.LoadUsuariosCommand.Execute(null);
        }
    }
}
