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
        public ObservableRangeCollection<Models.Curso> Cursos { get; set; }
        public ObservableRangeCollection<Models.Ocupacao> Ocupacoes { get; set; }
        public ObservableRangeCollection<Models.Responsavel> Responsaveis { get; set; }
        public ObservableRangeCollection<Models.SituacaoMercado> SituacoesMercado { get; set; }
        public ObservableRangeCollection<Models.IdentidadeGenero> IdentidadeGeneros { get; set; }
        public ObservableRangeCollection<Models.OrientacaoSexual> OrientacoesSexuais { get; set; }
        public ObservableRangeCollection<Models.RelacaoParentesco> RelacoesParentesco { get; set; }

        // USADO PAGE 4
        public ObservableRangeCollection<Models.MotivoSaida> MotivosSaida { get; set; }

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
            
            this.Cursos = new ObservableRangeCollection<Models.Curso>(new DAO.DAOCurso().Select());
            this.Ocupacoes = new ObservableRangeCollection<Models.Ocupacao>(); //MAPEAR OS CBOS ..... AINDA TEM Q SER FEITO
            this.Responsaveis = new ObservableRangeCollection<Models.Responsavel>(new DAO.DAOResponsavel().Select()); 
            this.SituacoesMercado = new ObservableRangeCollection<Models.SituacaoMercado>(new DAO.DAOSituacaoMercado().Select());
            this.IdentidadeGeneros = new ObservableRangeCollection<Models.IdentidadeGenero>(new DAO.DAOIdentidadeGenero().Select());
            this.OrientacoesSexuais = new ObservableRangeCollection<Models.OrientacaoSexual>(new DAO.DAOOrientacaoSexual().Select());
            this.RelacoesParentesco = new ObservableRangeCollection<Models.RelacaoParentesco>(new DAO.DAORelacaoParentesco().Select());
        }

        private async System.Threading.Tasks.Task ConcordarExecuteAsync() {
            await this.Page.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage2(this));
        }

        private async System.Threading.Tasks.Task NaoConcordarExecuteAsync() {
            await this.Page.DisplayAlert("Salvar no banco", "voltar para o menu", "fazer isso depois.");
        }

        private async System.Threading.Tasks.Task ContinuarExecuteAsync() {
            var CurrentPage = this.Page.Navigation.NavigationStack.Last(); //PEGA A ULTIMA PAGINA NA PILHA DE NAVEGAÇÃO, OU SEJA A ATUAL.
            if (CurrentPage is Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage2) {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage3(this));
            } else if (CurrentPage is Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage3) {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage4(this));
            };
        }
    }
}