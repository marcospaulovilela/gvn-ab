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
            }
        }
    }
}
