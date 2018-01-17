using gvn_ab_mobile.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels
{
    public class FichaAtendimentoIndividualViewModel : BaseViewModel
    {

        private Page Page { get; set; }

        public ICommand Continuar { get; }

        public Models.FichaAtendimentoIndividual Ficha { get; set; }

        // USADO PAGE 1
        public ObservableRangeCollection<Models.Turno> Turnos { get; set; }
        public ObservableRangeCollection<Models.Sexo> Sexos { get; set; }

        private Models.Sexo _sexo; //Obrigatório
        public Models.Sexo Sexo
        {
            get { return this._sexo; }
            set {
                this.Ficha.Sexo = value;

                SetProperty(ref _sexo, value);
                OnPropertyChanged("IsMulher");
            }
        }
        public bool IsMulher
        {
            get
            {
                return this.Sexo?.Codigo == 1;
            }
        }

        private Models.Turno _turno; //Obrigatório
        public Models.Turno Turno
        {
            get { return this._turno; }
            set {
                this.Ficha.Turno = value;

                SetProperty(ref _turno, value);
            }
        }

        // USADO PAGE 2
        public ObservableRangeCollection<Models.LocalDeAtendimento> LocaisAtendimentos { get; set; }
        public ObservableRangeCollection<Models.TipoDeAtendimento> TiposAtendimentos { get; set; }
        public ObservableRangeCollection<Models.ModalidadeAD> ModalidadesAD { get; set; }
        public ObservableRangeCollection<Models.RacionalidadeSaude> RacionalidadesSaude { get; set; }
        public ObservableRangeCollection<Models.AleitamentoMaterno> AleitamentosMaternos { get; set; }

        private Models.LocalDeAtendimento _localDeAtendimento; //Obrigatório
        public Models.LocalDeAtendimento LocalDeAtendimento
        {
            get { return this._localDeAtendimento; }
            set
            {
                this.Ficha.LocalDeAtendimento = value;

                SetProperty(ref _localDeAtendimento, value);
            }
        }

        private Models.TipoDeAtendimento _tipoAtendimento; //Obrigatório
        public Models.TipoDeAtendimento TipoAtendimento
        {
            get { return this._tipoAtendimento; }
            set
            {
                this.Ficha.TipoAtendimento = value;

                SetProperty(ref _tipoAtendimento, value);
            }
        }

        private Models.ModalidadeAD _atencaoDomiciliarModalidade; //Não Obrigatório
        public Models.ModalidadeAD AtencaoDomiciliarModalidade
        {
            get { return this._atencaoDomiciliarModalidade; }
            set
            {
                this.Ficha.AtencaoDomiciliarModalidade = value;

                SetProperty(ref _atencaoDomiciliarModalidade, value);
            }
        }

        private Models.RacionalidadeSaude _racionalidadeSaude; //Não Obrigatório
        public Models.RacionalidadeSaude RacionalidadeSaude
        {
            get { return this._racionalidadeSaude; }
            set
            {
                this.Ficha.RacionalidadeSaude = value;

                SetProperty(ref _racionalidadeSaude, value);
            }
        }

        private Models.AleitamentoMaterno _aleitamentoMaterno; //Não Obrigatório
        public Models.AleitamentoMaterno AleitamentoMaterno
        {
            get { return this._aleitamentoMaterno; }
            set
            {
                this.Ficha.AleitamentoMaterno = value;

                SetProperty(ref _aleitamentoMaterno, value);
            }
        }

        //USADO PAGE 3
        public ObservableRangeCollection<Models.ListaCiapCondicaoAvaliada> ListaCiapCondicoesAvaliadas { get; set; }
        public ObservableCollection<object> CondicoesSelecionadas { get; } = new ObservableCollection<object>();

        public FichaAtendimentoIndividualViewModel(Page page)
        {
            this.Ficha = new Models.FichaAtendimentoIndividual();
            this.Page = page;

            this.Continuar = new Command(async () => await ContinuarExecuteAsync());

            this.Turnos = new ObservableRangeCollection<Models.Turno>(new DAO.DAOTurno().Select());
            this.Sexos = new ObservableRangeCollection<Models.Sexo>(new DAO.DAOSexo().Select()); //traz todos os sexos na base.

            this.LocaisAtendimentos = new ObservableRangeCollection<Models.LocalDeAtendimento>(new DAO.DAOLocalDeAtendimento().Select());
            this.TiposAtendimentos = new ObservableRangeCollection<Models.TipoDeAtendimento>(new DAO.DAOTipoDeAtendimento().Select());
            this.ModalidadesAD = new ObservableRangeCollection<Models.ModalidadeAD>(new DAO.DAOModalidadeAD().Select());
            this.RacionalidadesSaude = new ObservableRangeCollection<Models.RacionalidadeSaude>(new DAO.DAORacionalidadeSaude().Select());
            this.AleitamentosMaternos = new ObservableRangeCollection<Models.AleitamentoMaterno>(new DAO.DAOAleitamentoMaterno().Select());

            this.ListaCiapCondicoesAvaliadas = new ObservableRangeCollection<Models.ListaCiapCondicaoAvaliada>(new DAO.DAOListaCiapCondicaoAvaliada().Select());
        }

        private async System.Threading.Tasks.Task ContinuarExecuteAsync()
        {
            var CurrentPage = this.Page.Navigation.NavigationStack.Last(); //PEGA A ULTIMA PAGINA NA PILHA DE NAVEGAÇÃO, OU SEJA A ATUAL.
            if (CurrentPage is Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage1)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage2(this));
            }
            else if (CurrentPage is Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage2)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage3(this));
            }
            else if (CurrentPage is Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage3)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage4(this));
            }
            else if (CurrentPage is Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage4)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage5(this));
            }
            else if (CurrentPage is Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage5)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage6(this));
            }
            else if (CurrentPage is Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage6)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage7(this));
            };
        }

    }

}
