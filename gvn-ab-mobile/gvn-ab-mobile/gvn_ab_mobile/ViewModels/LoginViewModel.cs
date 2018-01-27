using System;
using System.Collections.ObjectModel;
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

        public bool SelectCbo { get; set; } = true;
        public Models.Profissional Profissional { get; set; }

        private Models.Cbo cbo;
        public Models.Cbo Cbo {
            get { return this.cbo; }
            set {
                SetProperty(ref cbo, value);
            }
        }

        private Models.Equipe equipe;
        public Models.Equipe Equipe {
            get { return this.equipe; }
            set {
                SetProperty(ref equipe, value);
            }
        }

        public bool HasUser { get; set; }
        public override bool NotIsBusy {
            get {
                return this.HasUser && !this.IsBusy;
            }
        }

        public LoginViewModel(Page page) {
            this.Profissional = new Models.Profissional() {
                DesLogin = "admsaude",
                DesSenha = "123456"
            };
            this.Page = page;

            this.Login = new Command(async () => await LoginExecuteAsync());
            this.CboSelect = new Command(() => CallMenu());

            this.Sincronizar = new Command(async () => await SincronizarExecuteAsync());

            using(DAO.DAOProfissional dao = new DAO.DAOProfissional()) {
                this.HasUser = dao.TableExists() && dao.Select().Any();
            }
        }

        private void CallMenu() {
            App.Current.MainPage = new NavigationPage(new Views.MenuPage(this.Profissional, this.Cbo, this.Equipe)) {
                BarBackgroundColor = Color.FromHex("#003264")
            };
        }

        private async Task LoginExecuteAsync() {
            this.IsBusy = true;
            try {
                using (var objDao = new DAO.DAOProfissional()) {
                    var user = objDao.GetProfissionalByDesLogin(this.Profissional.DesLogin);

                    if (user != null && user.DesSenha == this.Profissional.DesSenha) { //SERIO??? BRINCADEIRA SEGURANÇA FAZER DIREITO DEPOIS.....
                        this.Profissional = user;
                        if (this.Profissional.Cbos?.Count() == 0) {
                            await this.Page.DisplayAlert("Erro de usuario", "Usuario não possui nenhum CBO vinculado.", "Ok");
                        } else if (this.Profissional.Cbos?.Count() == 1) {
                            this.SelectCbo = false;
                            this.Cbo = this.Profissional.Cbos.First();

                            if (this.Cbo?.Equipes?.Count == 1) {
                                this.Equipe = this.Cbo.Equipes.First();
                                CallMenu();
                            } else {
                                await this.Page.Navigation.PushAsync(new Views.Login.LoginPage2(this));
                            };
                        } else {
                            await this.Page.Navigation.PushAsync(new Views.Login.LoginPage2(this));
                        };

                    } else {
                        await this.Page.DisplayAlert("Erro de login", "Usuario ou senha invalidos", "Ok");
                    };
                };
            } catch (Exception e) {
                System.Diagnostics.Debug.WriteLine(e);
            } finally {
                this.IsBusy = false;
            };
        }

        private async Task SincronizarExecuteAsync() {
            await this.Page.Navigation.PushAsync(new Views.SincronizacaoConfigPage1());
        }
    }
}
