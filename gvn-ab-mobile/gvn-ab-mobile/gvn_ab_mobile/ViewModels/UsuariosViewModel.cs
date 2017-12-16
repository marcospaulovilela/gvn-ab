using System;
using System.Diagnostics;
using System.Threading.Tasks;

using gvn_ab_mobile.Helpers;
using gvn_ab_mobile.Models;
using gvn_ab_mobile.Views;

using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels {
    public class UsuariosViewModel : BaseViewModel {
        public ObservableRangeCollection<Usuario> Usuarios { get; set; }
        public Command LoadUsuariosCommand { get; set; }

        public UsuariosViewModel() {
            Title = "Usuarios";
            Usuarios = new ObservableRangeCollection<Models.Usuario>();
            LoadUsuariosCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewUsuarioPage, Usuario>(this, "AddUsuario", async (obj, u) => {
                var _u = u as Usuario;
                Usuarios.Add(_u);
                await DataStore.AddItemAsync(_u);
            });
        }

        async Task ExecuteLoadItemsCommand() {
            if (IsBusy)
                return;

            IsBusy = true;

            try {
                Usuarios.Clear();
                var items = await DataStore.GetItemsAsync(true);
                Usuarios.ReplaceRange(items);
            } catch (Exception ex) {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            } finally {
                IsBusy = false;
            }
        }
    }
}