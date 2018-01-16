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
    public class FichaCadastroDomiciliarViewModel : BaseViewModel
    {
        private Page Page { get; set; }

        public ICommand Continuar { get; }

        public ICommand Concordar { get; }
        public ICommand NaoConcordar { get; }

        public ICommand ConcordarInstituicaoPermanencia { get; }
        public ICommand NaoConcordarInstituicaoPermanencia { get; }

        public Models.FichaCadastroDomiciliarTerritorial Ficha { get; set; }

        //USADO PAGE 2

        public ObservableRangeCollection<Models.TipoDeLogradouro> TiposLogradouros { get; set;  }
        public ObservableRangeCollection<Models.TipoDeImovel> TiposImoveis { get; set; }

        private bool _stSemNumero; //Não Obrigatório
        public bool StSemNumero
        {
            get { return this._stSemNumero; }
            set {
                this.Ficha.StSemNumero = value;

                SetProperty(ref _stSemNumero, value);
                OnPropertyChanged("HasNumero");
            }
        }
        public bool HasNumero
        {
            get
            {
                return !this.StSemNumero;
            }
        }

        private bool _stForaArea; //Não Obrigatório
        public bool StForaArea
        {
            get { return this._stForaArea; }
            set {
                this.Ficha.StForaArea = value;

                SetProperty(ref _stForaArea, value);
                OnPropertyChanged("IsForaArea");
            }
        }
        public bool IsForaArea
        {
            get
            {
                return !this.StForaArea;
            }
        }

        private Models.TipoDeImovel _tipoDeImovel; //Obrigatório
        public Models.TipoDeImovel TipoDeImovel
        {
            get { return this._tipoDeImovel; }
            set {
                this.Ficha.TipoDeImovel = value;

                SetProperty(ref _tipoDeImovel, value);
                OnPropertyChanged("HasTipoDomicilio");
                OnPropertyChanged("IsDomicilio");
            }
        }
        public bool HasTipoDomicilio
        {
            get
            {
                return !((this.TipoDeImovel?.Codigo == 7) || (this.TipoDeImovel?.Codigo == 8) || (this.TipoDeImovel?.Codigo == 9)
                    || (this.TipoDeImovel?.Codigo == 10) || (this.TipoDeImovel?.Codigo == 11));
            }
        }
        public bool IsDomicilio
        {
            get
            {
                return this.TipoDeImovel?.Codigo == 1;
            }
        }

        // USADO PAGE 3
        public ObservableRangeCollection<Models.SituacaoDeMoradia> SituacoesDeMoradia { get; set; }
        public ObservableRangeCollection<Models.LocalizacaoDaMoradia> LocalizacoesMoradias { get; set; }
        public ObservableRangeCollection<Models.TipoDeDomicilio> TiposDeDomicilio { get; set; }
        public ObservableRangeCollection<Models.TipoDeAcessoAoDomicilio> TiposAcessoDomicilio { get; set; }
        public ObservableRangeCollection<Models.CondicaoDePosseEUsoDaTerra> CondicoesPosseUsoTerra { get; set; }
        public ObservableRangeCollection<Models.MaterialPredominanteNaConstrucao> MateriaisPredominantesConstrucao { get; set; }
        public ObservableRangeCollection<Models.AbastecimentoDeAgua> AbastecimentosAgua { get; set; }
        public ObservableRangeCollection<Models.AguaConsumoDomicilio> AguaConsumoDomicilio { get; set; }
        public ObservableRangeCollection<Models.FormaDeEscoamentoDoBanheiroOuSanitario> FormasEscoamentoBanheiroOuSanitario { get; set; }
        public ObservableRangeCollection<Models.DestinoDoLixo> DestinosLixo { get; set; }

        private Models.LocalizacaoDaMoradia _localizacao; //Obrigatório
        public Models.LocalizacaoDaMoradia Localizacao
        {
            get { return this._localizacao; }
            set {
                this.Ficha.Localizacao = value;

                SetProperty(ref _localizacao, value);
                OnPropertyChanged("IsRural");
            }
        }
        public bool IsRural
        {
            get
            {
                return this.Localizacao?.Codigo == 84;
            }
        }

        //USADO PAGE 4
        public ObservableRangeCollection<Models.AnimalNoDomicilio> AnimaisNoDomicilio { get; set; }
        public ObservableCollection<object> AnimaisSelecionados { get; } = new ObservableCollection<object>();

        private bool _stAnimaisNoDomicilio; //Condicional
        public bool StAnimaisNoDomicilio
        {
            get { return this._stAnimaisNoDomicilio; }
            set {
                this.Ficha.StAnimaisNoDomicilio = value;

                SetProperty(ref _stAnimaisNoDomicilio, value);
                OnPropertyChanged("HasAnimais");
            }
        }
        public bool HasAnimais
        {
            get
            {
                return this.StAnimaisNoDomicilio;
            }
        }

        //USADO PAGE 5
        public ObservableRangeCollection<Models.RendaFamiliar> RendasFamiliares { get; set; }


        public FichaCadastroDomiciliarViewModel(Page page)
        {
            this.Ficha = new Models.FichaCadastroDomiciliarTerritorial();
            this.Page = page;

            this.Continuar = new Command(async () => await ContinuarExecuteAsync());

            this.Concordar = new Command(async () => await ConcordarExecuteAsync());
            this.NaoConcordar = new Command(async () => await NaoConcordarExecuteAsync());

            this.ConcordarInstituicaoPermanencia = new Command(async () => await ConcordarInstituicaoPermanenciaExecuteAsync());
            this.NaoConcordarInstituicaoPermanencia = new Command(async () => await NaoConcordarInstituicaoPermanenciaExecuteAsync());

            this.TiposLogradouros = new ObservableRangeCollection<Models.TipoDeLogradouro>(new DAO.DAOTipoDeLogradouro().Select());
            this.TiposImoveis = new ObservableRangeCollection<Models.TipoDeImovel>(new DAO.DAOTipoDeImovel().Select());

            this.SituacoesDeMoradia = new ObservableRangeCollection<Models.SituacaoDeMoradia>(new DAO.DAOSituacaoDeMoradia().Select());
            this.LocalizacoesMoradias = new ObservableRangeCollection<Models.LocalizacaoDaMoradia>(new DAO.DAOLocalizacaoDaMoradia().Select());
            this.TiposDeDomicilio = new ObservableRangeCollection<Models.TipoDeDomicilio>(new DAO.DAOTipoDeDomicilio().Select());
            this.TiposAcessoDomicilio = new ObservableRangeCollection<Models.TipoDeAcessoAoDomicilio>(new DAO.DAOTipoDeAcessoAoDomicilio().Select());
            this.CondicoesPosseUsoTerra = new ObservableRangeCollection<Models.CondicaoDePosseEUsoDaTerra>(new DAO.DAOCondicaoDePosseEUsoDaTerra().Select());
            this.MateriaisPredominantesConstrucao = new ObservableRangeCollection<Models.MaterialPredominanteNaConstrucao>(new DAO.DAOMaterialPredominanteNaConstrucao().Select());
            this.AbastecimentosAgua = new ObservableRangeCollection<Models.AbastecimentoDeAgua>(new DAO.DAOAbastecimentoDeAgua().Select());
            this.AguaConsumoDomicilio = new ObservableRangeCollection<Models.AguaConsumoDomicilio>(new DAO.DAOAguaConsumoDomicilio().Select());
            this.FormasEscoamentoBanheiroOuSanitario = new ObservableRangeCollection<Models.FormaDeEscoamentoDoBanheiroOuSanitario>(new DAO.DAOFormaDeEscoamentoDoBanheiroOuSanitario().Select());
            this.DestinosLixo = new ObservableRangeCollection<Models.DestinoDoLixo>(new DAO.DAODestinoDoLixo().Select());

            this.AnimaisNoDomicilio = new ObservableRangeCollection<Models.AnimalNoDomicilio>(new DAO.DAOAnimalNoDomicilio().Select());

            this.RendasFamiliares = new ObservableRangeCollection<Models.RendaFamiliar>(new DAO.DAORendaFamiliar().Select());
        }

        private async System.Threading.Tasks.Task ConcordarExecuteAsync()
        {
            await this.Page.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage2(this));
        }

        private async System.Threading.Tasks.Task NaoConcordarExecuteAsync()
        {
            await this.Page.DisplayAlert("Fazer assinatura do cidadão", "", "Ok");
        }

        private async System.Threading.Tasks.Task ConcordarInstituicaoPermanenciaExecuteAsync()
        {
            await this.Page.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage7(this));
        }

        private async System.Threading.Tasks.Task NaoConcordarInstituicaoPermanenciaExecuteAsync()
        {
            await this.Page.DisplayAlert("Fazer assinatura do cidadão", "", "Ok");
        }

        private async System.Threading.Tasks.Task ContinuarExecuteAsync()
        {
            var CurrentPage = this.Page.Navigation.NavigationStack.Last(); //PEGA A ULTIMA PAGINA NA PILHA DE NAVEGAÇÃO, OU SEJA A ATUAL.
            if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage2)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage3(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage3)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage4(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage4)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage5(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage5)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage6(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage7)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage8(this));
            };
        }

    }

}