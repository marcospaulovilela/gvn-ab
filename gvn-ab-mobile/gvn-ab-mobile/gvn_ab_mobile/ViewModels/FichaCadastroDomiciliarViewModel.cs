using gvn_ab_mobile.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels {
    public class FichaCadastroDomiciliarViewModel : BaseViewModel {
        private Page Page { get; set; }

        public ICommand Continuar { get; }

        public ICommand Concordar { get; }
        public ICommand NaoConcordar { get; }

        public ICommand ConcordarInstituicaoPermanencia { get; }
        public ICommand NaoConcordarInstituicaoPermanencia { get; }

        public Models.FichaCadastroDomiciliarTerritorial Ficha { get; set; }

        public ObservableCollection<object> Teste { get; set; }

        //USADO PAGE 2

        public ObservableRangeCollection<Models.UnidadeFederal> UFs { get; set; }
        public ObservableRangeCollection<Models.TipoLogradouro> TiposLogradouros { get; set; }
        public ObservableRangeCollection<Models.TipoDeImovel> TiposImoveis { get; set; }
        public ObservableRangeCollection<Models.Municipio> Municipios { get; set; }

        private Models.Municipio _codigoIbgeMunicipio;
        public Models.Municipio CodigoIbgeMunicipio {
            get { return this._codigoIbgeMunicipio; }
            set {
                this.Ficha.Municipio = value;
                SetProperty(ref _codigoIbgeMunicipio, value);
            }
        }

        private Models.UnidadeFederal unidadeFederal; //Obrigatório
        public Models.UnidadeFederal UnidadeFederal {
            get { return this.unidadeFederal; }
            set {
                this.Ficha.UnidadeFederal = value;

                SetProperty(ref unidadeFederal, value);
            }
        }

        private bool _stSemNumero; //Não Obrigatório
        public bool StSemNumero {
            get { return this._stSemNumero; }
            set {
                this.Ficha.StSemNumero = value;

                SetProperty(ref _stSemNumero, value);
                OnPropertyChanged("HasNumero");
            }
        }
        public bool HasNumero {
            get {
                return !this.StSemNumero;
            }
        }

        private bool _stForaArea; //Não Obrigatório
        public bool StForaArea {
            get { return this._stForaArea; }
            set {
                this.Ficha.StForaArea = value;

                SetProperty(ref _stForaArea, value);
                OnPropertyChanged("IsForaArea");
            }
        }
        public bool IsForaArea {
            get {
                return !this.StForaArea;
            }
        }

        private Models.TipoLogradouro _tipoLogradouroNumeroDne; //Obrigatório
        public Models.TipoLogradouro TipoLogradouroNumeroDne {
            get { return this._tipoLogradouroNumeroDne; }
            set {
                this.Ficha.TipoLogradouroNumeroDne = value;

                SetProperty(ref _tipoLogradouroNumeroDne, value);
            }
        }

        private Models.TipoDeImovel _tipoDeImovel; //Obrigatório
        public Models.TipoDeImovel TipoDeImovel {
            get { return this._tipoDeImovel; }
            set {
                this.Ficha.TipoDeImovel = value;

                SetProperty(ref _tipoDeImovel, value);
                OnPropertyChanged("HasTipoDomicilio");
                OnPropertyChanged("IsDomicilio");
                OnPropertyChanged("IsNotDomicilio");
                OnPropertyChanged("HasTipoDomicilioAndIsRural");
            }
        }
        public bool HasTipoDomicilio {
            get {
                return !((this.TipoDeImovel?.Codigo == 7) || (this.TipoDeImovel?.Codigo == 8) || (this.TipoDeImovel?.Codigo == 9)
                    || (this.TipoDeImovel?.Codigo == 10) || (this.TipoDeImovel?.Codigo == 11));
            }
        }
        public bool IsDomicilio {
            get {
                return this.TipoDeImovel?.Codigo == 1;
            }
        }
        public bool IsNotDomicilio {
            get {
                return !(this.TipoDeImovel?.Codigo == 1);
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
        public ObservableRangeCollection<Models.AguaConsumoDomicilio> AguaConsumoDomicilios { get; set; }
        public ObservableRangeCollection<Models.FormaDeEscoamentoDoBanheiroOuSanitario> FormasEscoamentoBanheiroOuSanitario { get; set; }
        public ObservableRangeCollection<Models.DestinoDoLixo> DestinosLixo { get; set; }

        private Models.SituacaoDeMoradia _situacaoMoradiaPosseTerra; //Não Obrigatório
        public Models.SituacaoDeMoradia SituacaoMoradiaPosseTerra {
            get { return this._situacaoMoradiaPosseTerra; }
            set {
                this.Ficha.SituacaoMoradiaPosseTerra = value;

                SetProperty(ref _situacaoMoradiaPosseTerra, value);
            }
        }

        private Models.LocalizacaoDaMoradia _localizacao; //Obrigatório
        public Models.LocalizacaoDaMoradia Localizacao {
            get { return this._localizacao; }
            set {
                this.Ficha.Localizacao = value;

                SetProperty(ref _localizacao, value);
                OnPropertyChanged("IsRural");
                OnPropertyChanged("HasTipoDomicilioAndIsRural");
            }
        }
        public bool IsRural {
            get {
                return this.Localizacao?.Codigo == 84;
            }
        }
        public bool HasTipoDomicilioAndIsRural {
            get {
                return ((this.HasTipoDomicilio == true) && (this.IsRural == true));
            }
        }

        private Models.TipoDeAcessoAoDomicilio _tipoAcessoDomicilio; //Não Obrigatório
        public Models.TipoDeAcessoAoDomicilio TipoAcessoDomicilio {
            get { return this._tipoAcessoDomicilio; }
            set {
                this.Ficha.TipoAcessoDomicilio = value;

                SetProperty(ref _tipoAcessoDomicilio, value);
            }
        }

        private Models.CondicaoDePosseEUsoDaTerra _areaProducaoRural; //Condicional
        public Models.CondicaoDePosseEUsoDaTerra AreaProducaoRural {
            get { return this._areaProducaoRural; }
            set {
                this.Ficha.AreaProducaoRural = value;

                SetProperty(ref _areaProducaoRural, value);
            }
        }

        private Models.MaterialPredominanteNaConstrucao _materialPredominanteParedesExtDomicilio; //Não Obrigatório
        public Models.MaterialPredominanteNaConstrucao MaterialPredominanteParedesExtDomicilio {
            get { return this._materialPredominanteParedesExtDomicilio; }
            set {
                this.Ficha.MaterialPredominanteParedesExtDomicilio = value;

                SetProperty(ref _materialPredominanteParedesExtDomicilio, value);
            }
        }

        private Models.AbastecimentoDeAgua _abastecimentoAgua; //Não Obrigatório
        public Models.AbastecimentoDeAgua AbastecimentoAgua {
            get { return this._abastecimentoAgua; }
            set {
                this.Ficha.AbastecimentoAgua = value;

                SetProperty(ref _abastecimentoAgua, value);
            }
        }

        private Models.AguaConsumoDomicilio _aguaConsumoDomicilio; //Não Obrigatório
        public Models.AguaConsumoDomicilio AguaConsumoDomicilio {
            get { return this._aguaConsumoDomicilio; }
            set {
                this.AguaConsumoDomicilio = value;

                SetProperty(ref _aguaConsumoDomicilio, value);
            }
        }

        private long _formaEscoamentoBanheiro; //Não Obrigatório
        public long FormaEscoamentoBanheiro {
            get { return this._formaEscoamentoBanheiro; }
            set {
                this.Ficha.FormaEscoamentoBanheiro = value;

                SetProperty(ref _formaEscoamentoBanheiro, value);
            }
        }

        private Models.DestinoDoLixo _destinoLixo; //Não Obrigatório
        public Models.DestinoDoLixo DestinoLixo {
            get { return this._destinoLixo; }
            set {
                this.Ficha.DestinoLixo = value;

                SetProperty(ref _destinoLixo, value);
            }
        }

        //USADO PAGE 4
        public ObservableRangeCollection<Models.AnimalNoDomicilio> AnimaisNoDomicilio { get; set; }
        public ObservableCollection<object> AnimaisSelecionados { get; } = new ObservableCollection<object>();

        private bool _stAnimaisNoDomicilio; //Condicional
        public bool StAnimaisNoDomicilio {
            get { return this._stAnimaisNoDomicilio; }
            set {
                this.Ficha.StAnimaisNoDomicilio = value;

                SetProperty(ref _stAnimaisNoDomicilio, value);
                OnPropertyChanged("HasAnimais");
            }
        }
        public bool HasAnimais {
            get {
                return this.StAnimaisNoDomicilio;
            }
        }


        //USADO PAGE 5
        public ObservableRangeCollection<Models.RendaFamiliar> RendasFamiliares { get; set; }

        public FichaCadastroDomiciliarViewModel(Page page) {
            this.Ficha = new Models.FichaCadastroDomiciliarTerritorial();
            this.Page = page;

            this.Continuar = new Command(async () => await ContinuarExecuteAsync());

            this.Concordar = new Command(async () => await ConcordarExecuteAsync());
            this.NaoConcordar = new Command(async () => await NaoConcordarExecuteAsync());

            this.ConcordarInstituicaoPermanencia = new Command(async () => await ConcordarInstituicaoPermanenciaExecuteAsync());
            this.NaoConcordarInstituicaoPermanencia = new Command(async () => await NaoConcordarInstituicaoPermanenciaExecuteAsync());

            this.Municipios = new ObservableRangeCollection<Models.Municipio>(new DAO.DAOMunicipio().Select());
            this.UFs = new ObservableRangeCollection<Models.UnidadeFederal>(new DAO.DAOUnidadeFederal().Select());
            this.TiposLogradouros = new ObservableRangeCollection<Models.TipoLogradouro>(new DAO.DAOTipoLogradouro().Select());
            this.TiposImoveis = new ObservableRangeCollection<Models.TipoDeImovel>(new DAO.DAOTipoDeImovel().Select());

            this.SituacoesDeMoradia = new ObservableRangeCollection<Models.SituacaoDeMoradia>(new DAO.DAOSituacaoDeMoradia().Select());
            this.LocalizacoesMoradias = new ObservableRangeCollection<Models.LocalizacaoDaMoradia>(new DAO.DAOLocalizacaoDaMoradia().Select());
            this.TiposDeDomicilio = new ObservableRangeCollection<Models.TipoDeDomicilio>(new DAO.DAOTipoDeDomicilio().Select());
            this.TiposAcessoDomicilio = new ObservableRangeCollection<Models.TipoDeAcessoAoDomicilio>(new DAO.DAOTipoDeAcessoAoDomicilio().Select());
            this.CondicoesPosseUsoTerra = new ObservableRangeCollection<Models.CondicaoDePosseEUsoDaTerra>(new DAO.DAOCondicaoDePosseEUsoDaTerra().Select());
            this.MateriaisPredominantesConstrucao = new ObservableRangeCollection<Models.MaterialPredominanteNaConstrucao>(new DAO.DAOMaterialPredominanteNaConstrucao().Select());
            this.AbastecimentosAgua = new ObservableRangeCollection<Models.AbastecimentoDeAgua>(new DAO.DAOAbastecimentoDeAgua().Select());
            this.AguaConsumoDomicilios = new ObservableRangeCollection<Models.AguaConsumoDomicilio>(new DAO.DAOAguaConsumoDomicilio().Select());
            this.FormasEscoamentoBanheiroOuSanitario = new ObservableRangeCollection<Models.FormaDeEscoamentoDoBanheiroOuSanitario>(new DAO.DAOFormaDeEscoamentoDoBanheiroOuSanitario().Select());
            this.DestinosLixo = new ObservableRangeCollection<Models.DestinoDoLixo>(new DAO.DAODestinoDoLixo().Select());

            this.AnimaisNoDomicilio = new ObservableRangeCollection<Models.AnimalNoDomicilio>(new DAO.DAOAnimalNoDomicilio().Select());

            this.RendasFamiliares = new ObservableRangeCollection<Models.RendaFamiliar>(new DAO.DAORendaFamiliar().Select());

            this.Teste = new ObservableCollection<object>();
        }

        private async System.Threading.Tasks.Task ConcordarExecuteAsync() {
            await this.Page.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage2(this));
        }

        private async System.Threading.Tasks.Task NaoConcordarExecuteAsync() {
            await this.Page.DisplayAlert("Fazer assinatura do cidadão", "", "Ok");
        }

        private async System.Threading.Tasks.Task ConcordarInstituicaoPermanenciaExecuteAsync() {
            await this.Page.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage7(this));
        }

        private async System.Threading.Tasks.Task NaoConcordarInstituicaoPermanenciaExecuteAsync() {
            await this.Page.DisplayAlert("Fazer assinatura do cidadão", "", "Ok");
        }

        private async System.Threading.Tasks.Task ContinuarExecuteAsync() {
            var CurrentPage = this.Page.Navigation.NavigationStack.Last(); //PEGA A ULTIMA PAGINA NA PILHA DE NAVEGAÇÃO, OU SEJA A ATUAL.
            if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage2) {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage3(this));
            } else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage3) {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage4(this));
            } else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage4) {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage5(this));
            } else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage5) {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage6(this));
            } else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage7) {
                await this.Page.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage8(this));
            };
        }

    }

}