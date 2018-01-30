using gvn_ab_mobile.Helpers;
using gvn_ab_mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using gvn_ab_mobile.Views;

namespace gvn_ab_mobile.ViewModels {
    public class MenuViewModel : BaseViewModel {
        private MenuPage MenuPage  { get; set; }

        public Models.Profissional Profissional { get; set; }
        public Models.Cbo Cbo { get; set; }
        public Models.Equipe Equipe { get; set; }
        public Models.Estabelecimento Estabelecimento { get; set; }

        public ICommand Send { get; }

        public bool CboCadastroIndividual {
            get {
                string[] CbosAltorizados = new string[] { "322205", "322210", "322230", "322245", "322250", "322405", "322415", "322425", "322430", "352210", "515105", "515120", "515125", "515130", "515140", "515305", "515310", "422110" };
                return CbosAltorizados.Any(o => o.Equals(this.Cbo.CodCbo));
            }
        }

        public bool CboCadastroDomiciliar {
            get {
                string[] CbosAltorizados = new string[] { "322205", "322210", "322230", "322245", "322250", "322405", "322415", "322425", "322430", "352210", "515105", "515120", "515125", "515130", "515140", "515305", "515310", "422110" };
                return CbosAltorizados.Any(o => o.Equals(this.Cbo.CodCbo));
            }
        }

        public bool CboVisitaDomiciliar {
            get {
                string[] CbosAltorizados = new string[] { "515105", "515120", "515310", "515140" };
                return CbosAltorizados.Any(o => o.Equals(this.Cbo.CodCbo));
            }
        }

        private bool hasFichas = false;
        public bool HasFichas {
            get { return this.hasFichas; }
            set { SetProperty(ref hasFichas, value); }
        }

        private string sendText = "Enviar fichas";
        public string SendText {
            get { return this.sendText; }
            set { SetProperty(ref sendText, value); }
        }

        public MenuViewModel(MenuPage menuPage, Models.Profissional profissional, Models.Cbo cbo, Models.Equipe equipe) {
            this.MenuPage  = menuPage;

            this.Profissional = profissional;
            this.Cbo = cbo;
            this.Equipe = equipe;

            using (DAO.DAOEstabelecimento DAOEstabelecimento = new DAO.DAOEstabelecimento()) {
                this.Estabelecimento = DAOEstabelecimento.Select()?.First();

                this.Estabelecimento.Municipio = new DAO.DAOMunicipio().Select(this.Estabelecimento.Municipio.CodMunicipio);
                this.Send = new Command(() => SendExecute());
            }
        }

        public void LoadSend() {
            using (DAO.DAOFichaCadastroIndividual DAOFichaCadastroIndividual = new DAO.DAOFichaCadastroIndividual())
            using (DAO.DAOFichaCadastroDomiciliarTerritorial DAOFichaCadastroDomiciliar = new DAO.DAOFichaCadastroDomiciliarTerritorial())
            using (DAO.DAOFichaVisitaDomiciliar DAOFichaVisitaDomiciliar = new DAO.DAOFichaVisitaDomiciliar()) {
                var FichasCadastroIndividual = DAOFichaCadastroIndividual.Select();
                var FichasCadastroDomiciliar = DAOFichaCadastroDomiciliar.Select();
                var FichasVisitaDomociliar = DAOFichaVisitaDomiciliar.Select();

                var nFichas = FichasCadastroIndividual.Count + FichasCadastroDomiciliar.Count + FichasVisitaDomociliar.Count;

                if (this.HasFichas = nFichas > 0) {
                    this.SendText = $"Enviar fichas ({nFichas})";
                } else {
                    this.SendText = "Enviar fichas";
                };
            };
        }

        private void SendExecute() {
            this.IsBusy = true;
            Task.Run(async () => {
                try {
                    using (DAO.DAOFichaCadastroIndividual DAOFichaCadastroIndividual = new DAO.DAOFichaCadastroIndividual())
                    using (DAO.DAOFichaCadastroDomiciliarTerritorial DAOFichaCadastroDomiciliar = new DAO.DAOFichaCadastroDomiciliarTerritorial())
                    using (DAO.DAOFichaVisitaDomiciliar DAOFichaVisitaDomiciliar = new DAO.DAOFichaVisitaDomiciliar())
                    using (DAO.DAOSincronizacaoConfig DAOSincronizacaoConfig = new DAO.DAOSincronizacaoConfig()) {
                        var fichasCadastroIndividual = DAOFichaCadastroIndividual.Select();
                        var fichasCadastroDomiciliar = DAOFichaCadastroDomiciliar.Select();
                        var fichasVisitaDomiciliar = DAOFichaVisitaDomiciliar.Select();

                        var sincronizacaoConfig = DAOSincronizacaoConfig.Select().FirstOrDefault();
                        if (sincronizacaoConfig == null) return;

                        using (var api = new RestAPI($"http://{sincronizacaoConfig.DesEndereco}/Governa.Saude.AtencaoBasica.Ministerio/Handlers/Mobile/Send.ashx")) {
                            PostResult result;
                            List<Tuple<object, string>> Erros = new List<Tuple<object, string>>();

                            #region Envia as fichas de cadastro individual
                            foreach (var o in fichasCadastroIndividual) {
                                if ((result = await api.PostAsync(o)).Status) {
                                    DAOFichaCadastroIndividual.Delete(o);
                                } else {
                                    Erros.Add(Tuple.Create<object, string>(o, result.Message));
                                };
                            };
                            #endregion

                            #region Envia as fichas de visita domiciliar
                            foreach (var o in fichasVisitaDomiciliar) {
                                if ((result = await api.PostAsync(o)).Status) {
                                    DAOFichaVisitaDomiciliar.Delete(o);
                                } else {
                                    Erros.Add(Tuple.Create<object, string>(o, result.Message));
                                };
                            };
                            #endregion

                            #region Envia as fichas de cadastro domiciliar
                            foreach (var o in fichasCadastroDomiciliar) {
                                if ((result = await api.PostAsync(o)).Status) {
                                    DAOFichaCadastroDomiciliar.Delete(o);
                                } else {
                                    Erros.Add(Tuple.Create<object, string>(o, result.Message));
                                };
                            };
                            #endregion

                            this.LoadSend();

                            if (Erros.Any()) {
                                Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                                    await this.MenuPage.Navigation.PushAsync(new ListErro(new ListErroViewModel(Erros.Select(o => new ErroItem(o)).ToList())))
                                );
                            };
                        };


                    };
                } catch(Exception e) { } finally { this.IsBusy = false; };
            });
        }
    }
}
