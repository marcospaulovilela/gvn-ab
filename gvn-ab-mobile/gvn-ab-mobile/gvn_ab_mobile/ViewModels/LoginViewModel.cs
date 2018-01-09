using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels {
    public class LoginViewModel : BaseViewModel {
        private Page Page { get; set; }

        public ICommand Login{ get; private set; }
        public ICommand Sincronizar { get; private set; }

        public Models.Usuario Usuario {get;set;}

        public LoginViewModel(Page page) {
            this.Usuario = new Models.Usuario();
            this.Page = page;

            this.Login = new Command(async () => await LoginExecuteAsync());
            this.Sincronizar = new Command(async () => await SincronizarExecuteAsync());
        }

        private async Task LoginExecuteAsync() {
            using (var objDao = new DAO.DAOUsuario()) {
                var CpfUser = objDao.GetUsuarioByCpf(this.Usuario.Cpf);
                if (CpfUser != null && CpfUser.Password == this.Usuario.Password) { //SERIO??? BRINCADEIRA SEGURANÇA FAZER DIREITO DEPOIS.....
                    this.Usuario.Cpf = this.Usuario.Password = ""; //limpa a entidade para caso voltar no login.
                    await this.Page.Navigation.PushAsync(new Views.MenuPage());
                } else {
                    await this.Page.DisplayAlert("Erro de login", "Usuario ou senha invalidos", "Ok");
                };
            };
        }

        private  async Task SincronizarExecuteAsync() {
            await this.Page.Navigation.PushAsync(new Views.SincronizacaoConfigPage1());
        }
    }
}
