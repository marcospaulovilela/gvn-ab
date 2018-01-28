using gvn_ab_mobile.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels {
    public class MenuViewModel : BaseViewModel {
        private Page Page { get; set; }

        public Models.Profissional Profissional { get; set; }
        public Models.Cbo Cbo { get; set; }
        public Models.Equipe Equipe { get; set; }
        public Models.Estabelecimento Estabelecimento { get; set; }

        public ICommand Send { get; }

        public bool CboCadastroIndividual {
            get {
                string[] CbosAltorizados = new string[] { "322205", "322210", "322230", "322245", "322250", "322405", "322415", "322425", "322430", "352210", "515105", "515120", "515125", "515130", "515140", "515305", "515310", "422110" };
                return true || CbosAltorizados.Any(o => o.Equals(this.Cbo.CodCbo));
            }
        }

        public bool CboCadastroDomiciliar {
            get {
                string[] CbosAltorizados = new string[] { "322205", "322210", "322230", "322245", "322250", "322405", "322415", "322425", "322430", "352210", "515105", "515120", "515125", "515130", "515140", "515305", "515310", "422110" };
                return true || CbosAltorizados.Any(o => o.Equals(this.Cbo.CodCbo));
            }
        }

        public bool CboVisitaDomiciliar {
            get {
                string[] CbosAltorizados = new string[] { "515105", "515120", "515310", "515140" };
                return true || CbosAltorizados.Any(o => o.Equals(this.Cbo.CodCbo));
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

        public MenuViewModel(Page page, Models.Profissional profissional, Models.Cbo cbo, Models.Equipe equipe) {
            this.Page = page;

            this.Profissional = profissional;
            this.Cbo = cbo;
            this.Equipe = equipe;

            using (DAO.DAOEstabelecimento DAOEstabelecimento = new DAO.DAOEstabelecimento()) {
                this.Estabelecimento = DAOEstabelecimento.Select()?.First();

                this.Estabelecimento.Municipio = new DAO.DAOMunicipio().Select(this.Estabelecimento.Municipio.CodMunicipio);
                this.Send = new Command(() => SendExecute());
            }
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
                            #region Envia as fichas de cadastro individual
                            //foreach (var o in fichasCadastroIndividual) {
                            //    string buffer = Newtonsoft.Json.JsonConvert.SerializeObject(o);
                            //    if(await api.PostAsync(o)) {
                            //        DAOFichaCadastroIndividual.Delete(o);
                            //    };
                            //};
                            #endregion

                            #region Envia as fichas de visita domiciliar
                            foreach (var o in fichasVisitaDomiciliar) {
                                if (await api.PostAsync(o)) {
                                    //DAOFichaVisitaDomiciliar.Delete(o);
                                };
                            };
                            #endregion


                        };


                    };
                } catch(Exception e) { } finally { this.IsBusy = false; };
            });
        }
    }
}
