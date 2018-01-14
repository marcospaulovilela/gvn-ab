using gvn_ab_mobile.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels {
    public class FichaCadastroIndividualViewModel : BaseViewModel {
        private Page Page { get; set; }

        public ICommand Continuar { get; }

        public ICommand Concordar { get; }
        public ICommand NaoConcordar { get; }

        public Models.FichaCadastroIndividual Ficha { get; set; }

        // USADO PAGE 2
        public ObservableRangeCollection<Models.Sexo> Sexos { get; set; }
        public ObservableRangeCollection<Models.Pais> Paises { get; set; }
        public ObservableRangeCollection<Models.Etnia> Etnias { get; set; }
        public ObservableRangeCollection<Models.RacaCor> RacasCores { get; set; }
        public ObservableRangeCollection<Models.Nacionalidade> Nacionalidades { get; set; }

        // USADO PAGE 3
        public ObservableRangeCollection<Models.CursoMaisElevado> CursosMaisElevados { get; set; }
        public ObservableRangeCollection<Models.Ocupacao> Ocupacoes { get; set; }
        public ObservableRangeCollection<Models.ResponsavelCrianca> ResponsaveisCriancas { get; set; }
        public ObservableRangeCollection<Models.SituacaoMercadoTrabalho> SituacoesMercadoTrabalho { get; set; }
        public ObservableRangeCollection<Models.IdentidadeGeneroCidadao> IdentidadeGeneroCidadaos { get; set; }
        public ObservableRangeCollection<Models.OrientacaoSexual> OrientacoesSexuais { get; set; }
        public ObservableRangeCollection<Models.RelacaoParentesco> RelacoesParentesco { get; set; }

        // USADO PAGE 4
        public ObservableRangeCollection<Models.MotivoSaida> MotivosSaida { get; set; }

        // USADO PAGE 5
        public ObservableRangeCollection<Models.ConsideracaoPeso> ConsideracoesPeso { get; set; }
        public ObservableRangeCollection<Models.DoencaCardiaca> DoencasCardiacas { get; set; }
        public ObservableRangeCollection<Models.ProblemaRins> ProblemasRins { get; set; }
        public ObservableRangeCollection<Models.DoencaRespiratoria> DoencasRespiratorias { get; set; }
        
        public FichaCadastroIndividualViewModel(Page page) {
            this.Ficha = new Models.FichaCadastroIndividual();
            this.Page = page;

            this.Continuar = new Command(async () => await ContinuarExecuteAsync());

            this.Concordar = new Command(async () => await ConcordarExecuteAsync());
            this.NaoConcordar = new Command(async () => await NaoConcordarExecuteAsync());

            this.Sexos = new ObservableRangeCollection<Models.Sexo>(new DAO.DAOSexo().Select()); //traz todos os sexos na base.
            this.Paises = new ObservableRangeCollection<Models.Pais>(new DAO.DAOPais().Select());
            this.Etnias = new ObservableRangeCollection<Models.Etnia>(new DAO.DAOEtnia().Select());
            this.RacasCores = new ObservableRangeCollection<Models.RacaCor>(new DAO.DAORacaCor().Select());
            this.Nacionalidades = new ObservableRangeCollection<Models.Nacionalidade>(new DAO.DAONacionalidade().Select());
            
            this.CursosMaisElevados = new ObservableRangeCollection<Models.CursoMaisElevado>(new DAO.DAOCursoMaisElevado().Select());
            //this.Ocupacoes = new ObservableRangeCollection<Models.Ocupacao>(); //MAPEAR OS CBOS ..... AINDA TEM Q SER FEITO
            this.ResponsaveisCriancas = new ObservableRangeCollection<Models.ResponsavelCrianca>(new DAO.DAOResponsavelCrianca().Select()); 
            this.SituacoesMercadoTrabalho = new ObservableRangeCollection<Models.SituacaoMercadoTrabalho>(new DAO.DAOSituacaoMercadoTrabalho().Select());
            this.IdentidadeGeneroCidadaos = new ObservableRangeCollection<Models.IdentidadeGeneroCidadao>(new DAO.DAOIdentidadeGeneroCidadao().Select());
            this.OrientacoesSexuais = new ObservableRangeCollection<Models.OrientacaoSexual>(new DAO.DAOOrientacaoSexual().Select());
            this.RelacoesParentesco = new ObservableRangeCollection<Models.RelacaoParentesco>(new DAO.DAORelacaoParentesco().Select());

            this.MotivosSaida = new ObservableRangeCollection<Models.MotivoSaida>(new DAO.DAOMotivoSaida().Select());

            this.ConsideracoesPeso = new ObservableRangeCollection<Models.ConsideracaoPeso>(new DAO.DAOConsideracaoPeso().Select());
            this.DoencasCardiacas= new ObservableRangeCollection<Models.DoencaCardiaca>(new DAO.DAODoencaCardiaca().Select());
            this.ProblemasRins = new ObservableRangeCollection<Models.ProblemaRins>(new DAO.DAOProblemaRins().Select());
            this.DoencasRespiratorias = new ObservableRangeCollection<Models.DoencaRespiratoria>(new DAO.DAODoencaRespiratoria().Select());

        }

        private async System.Threading.Tasks.Task ConcordarExecuteAsync() {
            await this.Page.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage2(this));
        }

        private async System.Threading.Tasks.Task NaoConcordarExecuteAsync() {
            await this.Page.DisplayAlert("Fazer assinatura do cidadão", "", "Ok");
        }

        private async System.Threading.Tasks.Task ContinuarExecuteAsync() {
            var CurrentPage = this.Page.Navigation.NavigationStack.Last(); //PEGA A ULTIMA PAGINA NA PILHA DE NAVEGAÇÃO, OU SEJA A ATUAL.
            if (CurrentPage is Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage2) {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage3(this));
            } else if (CurrentPage is Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage3) {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage4(this));
            } else if (CurrentPage is Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage4) {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage5(this));
            } else if (CurrentPage is Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage5) {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage6(this));
            };
        }
    }
}