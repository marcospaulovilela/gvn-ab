using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels {
    public class LoginViewModel : BaseViewModel {
        private Page Page { get; set; }
        public ICommand Login{ get; private set; }
        
        public Models.Usuario usuario {get;set;}
        

        public LoginViewModel(Page page) {
            this.usuario = new Models.Usuario();
            this.Page = page;

            this.Login = new Command(async () => await LoginExecuteAsync());
        }

        private async System.Threading.Tasks.Task LoginExecuteAsync() {
            using (var objDao = new DAO.DAOUsuario()) {
                var CpfUser = objDao.GetUsuarioByCpf(this.usuario.Cpf);
                if(CpfUser != null && CpfUser.Password == this.usuario.Password) { //SERIO??? BRINCADEIRA SEGURANÇA FAZER DIREITO DEPOIS.....
                    this.usuario.Cpf = this.usuario.Password = ""; //limpa a entidade para caso voltar no login.
                    await this.Page.Navigation.PushAsync(new Views.MenuPage());
                } else {
                    await this.Page.DisplayAlert("Erro de login", "Usuario ou senha invalidos", "Ok");
                };
            };
        }
    }
}
