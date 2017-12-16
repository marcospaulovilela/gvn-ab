using System;

using gvn_ab_mobile.Models;

using Xamarin.Forms;

namespace gvn_ab_mobile.Views {
    public partial class NewUsuarioPage : ContentPage {
        public Usuario usuario { get; set; }

        public NewUsuarioPage() {
            InitializeComponent();

            usuario = new Usuario {
                Cpf = "",
                Nome = "John Doe"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e) {
            MessagingCenter.Send(this, "AddUsuario", usuario);
            await Navigation.PopToRootAsync();
        }
    }
}