﻿using gvn_ab_mobile.Helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels {
    public class FichaCadastroDomiciliarViewModel : BaseViewModel {
        private Views.MenuPage MenuPage { get; set; }

        public ICommand Continuar { get; }

        public ICommand Concordar { get; }
        public ICommand NaoConcordar { get; }

        public ICommand ConcordarInstituicaoPermanencia { get; }
        public ICommand NaoConcordarInstituicaoPermanencia { get; }

        public Models.FichaCadastroDomiciliarTerritorial Ficha { get; set; }

        public ObservableCollection<object> Familias { get; set; }

        public List<Point> SignaturePoints;
        public Stream SignatureImage;
        public List<Point> SignaturePoints1;
        public Stream SignatureImage1;

        public string NomeRG => $"{this.Ficha.NomeCidadao}, portador(a) do RG nº {this.Ficha.Rg}".Trim();
        public string NomeRG1 => $"{this.Ficha.NomeResponsavelTecnico}, portador(a) do RG nº {this.Ficha.RgResponsavelTecnico}".Trim();

        //USADO PAGE 2

        public ObservableRangeCollection<Models.UnidadeFederal> UFs { get; set; }
        public ObservableRangeCollection<Models.TipoLogradouro> TiposLogradouros { get; set; }
        public ObservableRangeCollection<Models.TipoDeImovel> TiposImoveis { get; set; }
        public ObservableRangeCollection<Models.Municipio> Municipios { get; set; }

        private Models.UnidadeFederal uf;
        public Models.UnidadeFederal UF {
            get { return this.uf; }
            set {
                SetProperty(ref uf, value);

                this.CodigoIbgeMunicipio = null;
                using (DAO.DAOMunicipio DAOMunicipio = new DAO.DAOMunicipio()) {
                    this.Municipios.Clear();
                    this.Municipios.AddRange(DAOMunicipio.GetByCodUnidadeFederal(value.CodUnidadeFederal));
                };
            }

        }
        private Models.Municipio _codigoIbgeMunicipio;
        public Models.Municipio CodigoIbgeMunicipio
        {
            get { return this._codigoIbgeMunicipio; }
            set
            {
                this.Ficha.Municipio = value;
                SetProperty(ref _codigoIbgeMunicipio, value);
            }
        }

        private bool _stSemNumero; //Não Obrigatório
        public bool StSemNumero {
            get { return this._stSemNumero; }
            set {
                this.Ficha.StSemNumero = value;
                this.Ficha.Numero = value ? "SN" : string.Empty;

                SetProperty(ref _stSemNumero, value);
                OnPropertyChanged("HasNumero");
            }
        }
        public bool HasNumero {
            get {
                return !this.StSemNumero;
            }
        }

        private bool _stForaArea;
        public bool StForaArea {
            get { return this._stForaArea; }
            set {
                this.Ficha.StForaArea = value;
                this.Ficha.Microarea = value ? "FA" : string.Empty;

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

        private Models.TipoDeDomicilio _tipoDomicilio; //Não Obrigatório
        public Models.TipoDeDomicilio TipoDomicilio
        {
            get { return this._tipoDomicilio; }
            set {
                this.Ficha.TipoDomicilio = value;

                SetProperty(ref _tipoDomicilio, value);
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

                this.AnimaisSelecionados.Clear();

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

        public FichaCadastroDomiciliarViewModel(Views.MenuPage page) {
            this.Ficha = new Models.FichaCadastroDomiciliarTerritorial();
            this.MenuPage = page;

            this.Continuar = new Command(async () => await ContinuarExecuteAsync());

            this.Concordar = new Command(async () => await ConcordarExecuteAsync());
            this.NaoConcordar = new Command(async () => await NaoConcordarExecuteAsync());

            this.ConcordarInstituicaoPermanencia = new Command(async () => await ConcordarInstituicaoPermanenciaExecuteAsync());
            this.NaoConcordarInstituicaoPermanencia = new Command(async () => await NaoConcordarInstituicaoPermanenciaExecuteAsync());

            this.Municipios = new ObservableRangeCollection<Models.Municipio>();
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

            this.Familias = new ObservableCollection<object>();
        }

        private async System.Threading.Tasks.Task ConcordarExecuteAsync() {
            await this.MenuPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage2(this));
        }

        private async System.Threading.Tasks.Task NaoConcordarExecuteAsync() {
            await this.MenuPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarRecusaPage1(this));
        }

        private async System.Threading.Tasks.Task ConcordarInstituicaoPermanenciaExecuteAsync() {
            await this.MenuPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage7(this));
        }

        private async System.Threading.Tasks.Task NaoConcordarInstituicaoPermanenciaExecuteAsync() {
            await this.MenuPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarRecusaPage3(this));
        }

        public async System.Threading.Tasks.Task TelaInstituicaoPermanenciaExecuteAsync()
        {
            await this.MenuPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage6(this));
        }

        private async System.Threading.Tasks.Task ContinuarExecuteAsync() {
            var CurrentPage = this.MenuPage.Navigation.NavigationStack.Last(); //PEGA A ULTIMA PAGINA NA PILHA DE NAVEGAÇÃO, OU SEJA A ATUAL.
            if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarRecusaPage1)
            {
                await this.MenuPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarRecusaPage2(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarRecusaPage3)
            {
                await this.MenuPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarRecusaPage4(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage2)
            {
                await this.MenuPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage3(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage3)
            {
                await this.MenuPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage4(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage4)
            {
                this.Ficha.AnimaisNoDomicilio = this.AnimaisSelecionados.Select(o => (Models.AnimalNoDomicilio)o).ToList();

                await this.MenuPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage5(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage5)
            {
                await this.MenuPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage6(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage7)
            {
                await this.MenuPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage8(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage8)
            {

                SalvarExecuteAsync();

            };
        }

        public async System.Threading.Tasks.Task SalvarExecuteAsync()
        {

            this.IsBusy = true;
            #pragma warning disable CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída
            Task.Run(async () => {

                using (DAO.DAOFichaFamilia DAOFichaFamilia = new DAO.DAOFichaFamilia())
                using (DAO.DAOFichaUnicaLotacaoHeader DAOFichaUnicaLotacaoHeader = new DAO.DAOFichaUnicaLotacaoHeader())
                using (DAO.DAOFichaCadastroDomiciliarTerritorial DAOFichaCadastroDomiciliar = new DAO.DAOFichaCadastroDomiciliarTerritorial())
                {
                    try
                    {
                        this.Ficha.Header = new Models.FichaUnicaLotacaoHeader()
                        {
                            Cbo = this.MenuPage.ViewModel.Cbo.CodCbo,
                            CnsProfissional = this.MenuPage.ViewModel.Profissional.CnsProfissional,
                            Cnes = this.MenuPage.ViewModel.Estabelecimento.ImpCnes,
                            Ine = this.MenuPage.ViewModel.Equipe.CodEquipe,
                            DataAtendimento = DateTime.Now
                        };

                        this.Ficha.Familias = this.Familias.Select(o => (Models.FichaFamilia)o).ToList();

                        DAOFichaFamilia.Insert(this.Ficha.Familias);
                        DAOFichaUnicaLotacaoHeader.Insert(this.Ficha.Header);
                        DAOFichaCadastroDomiciliar.Insert(this.Ficha);
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(async () => await this.MenuPage.Navigation.PopToRootAsync());
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e);
                    }
                    finally
                    {
                        this.IsBusy = false;
                    };
                };
            });
            #pragma warning restore CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída
        }

    }

}