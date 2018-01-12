using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels {
    public class LoginViewModel : BaseViewModel {
        private Page Page { get; set; }

        public ICommand Login { get; private set; }
        public ICommand CboSelect { get; private set; }
        public ICommand Sincronizar { get; private set; }

        public Models.Profissional Profissional { get; set; }
        public Models.Cbo Cbo { get; set; }

        public LoginViewModel(Page page) {
            this.Profissional = new Models.Profissional() {
                DesLogin = "admsaude",
                DesSenha = "123456"
            };
            this.Page = page;

            this.Login = new Command(async () => await LoginExecuteAsync());
            this.CboSelect = new Command(async () => await this.Page.Navigation.PushAsync(new Views.MenuPage(this.Profissional, this.Cbo = this.Profissional.Cbos.First())));
            this.Sincronizar = new Command(async () => await SincronizarExecuteAsync());
        }

        private async Task LoginExecuteAsync() {
            try {
                using (var objDao = new DAO.DAOProfissional()) {
                    var CpfUser = objDao.GetProfissionalByDesLogin(this.Profissional.DesLogin);
                    this.Profissional = CpfUser;

                    if (CpfUser != null && CpfUser.DesSenha == this.Profissional.DesSenha) { //SERIO??? BRINCADEIRA SEGURANÇA FAZER DIREITO DEPOIS.....
                        CpfUser.DesLogin = CpfUser.DesSenha = string.Empty; // LIMPA, POIS SE VOLTAR PARA TELA DE LOGIN, O USUARIO DEVE SER DIGITADO NOVAMENTE

                        if (this.Profissional.Cbos?.Count() == 0) {
                            await this.Page.DisplayAlert("Erro de usuario", "Usuario não possui nenhum CBO vinculado.", "Ok");
                        } else if (this.Profissional.Cbos?.Count() == 1) {
                            await this.Page.Navigation.PushAsync(new Views.MenuPage(this.Profissional, this.Cbo = this.Profissional.Cbos.First()));
                        } else {
                            await this.Page.Navigation.PushAsync(new Views.Login.LoginPage2(this));
                        };

                    } else {
                        await this.Page.DisplayAlert("Erro de login", "Usuario ou senha invalidos", "Ok");
                    };
                };
            } catch(Exception e) {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        private async Task SincronizarExecuteAsync() {
            await this.Page.Navigation.PushAsync(new Views.SincronizacaoConfigPage1());
        }
    }
}
