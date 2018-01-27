using gvn_ab_mobile.Helpers;
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

namespace gvn_ab_mobile.ViewModels
{
    public class FichaCadastroDomiciliarViewModel : BaseViewModel
    {
        private Views.FichaCadastroDomiciliarPage.ListFichaCadastroDomiciliar RootPage { get; set; }

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
        public ObservableRangeCollection<Models.Logradouro> Logradouros { get; set; }
        public ObservableRangeCollection<Models.Bairro> Bairros { get; set; }
        public ObservableRangeCollection<Models.TipoDeImovel> TiposImoveis { get; set; }
        public ObservableRangeCollection<Models.Municipio> Municipios { get; set; }

        private Models.UnidadeFederal uf;
        public Models.UnidadeFederal UF
        {
            get { return this.uf; }
            set
            {
                SetProperty(ref uf, value);

                //this.CodigoIbgeMunicipio = null;
                //using (DAO.DAOMunicipio DAOMunicipio = new DAO.DAOMunicipio()) {
                //this.Municipios.Clear();
                //this.Municipios.AddRange(DAOMunicipio.GetByCodUnidadeFederal(value.CodUnidadeFederal));
                //};
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

        private Models.Bairro bairro;
        public Models.Bairro Bairro {
            get { return this.bairro; }
            set {
                if (value == this.Ficha.Bairro) return;
                this.Ficha.Bairro = value;
                SetProperty(ref bairro, value);

                this.Logradouro = null;
                try {
                    using (DAO.DAOLocalizacao DAOLocalizacao = new DAO.DAOLocalizacao()) {
                        var LocalizacoesBairro = DAOLocalizacao.GetLocalizacaoByBairro(value.CodBairro);
                        this.Logradouros.Clear();
                        this.Logradouros.AddRange(LocalizacoesBairro.Select(o => o.Logradouro));
                    }
                } catch (Exception e) {

                }

            }
        }

        private Models.Logradouro logradouro;
        public Models.Logradouro Logradouro {
            get { return this.logradouro; }
            set {
                this.Ficha.Logradouro = value;
                SetProperty(ref logradouro, value);
            }
        }


        private bool _stSemNumero; //Não Obrigatório
        public bool StSemNumero
        {
            get { return this._stSemNumero; }
            set
            {
                this.Ficha.StSemNumero = value;
                this.Ficha.Numero = value ? "SN" : string.Empty;

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

        private bool _stForaArea;
        public bool StForaArea
        {
            get { return this._stForaArea; }
            set
            {
                this.Ficha.StForaArea = value;
                this.Ficha.Microarea = value ? "FA" : string.Empty;

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
            set
            {
                this.Ficha.TipoDeImovel = value;

                SetProperty(ref _tipoDeImovel, value);
                OnPropertyChanged("HasTipoDomicilio");
                OnPropertyChanged("IsDomicilio");
                OnPropertyChanged("IsNotDomicilio");
                OnPropertyChanged("HasTipoDomicilioAndIsRural");
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
        public bool IsNotDomicilio
        {
            get
            {
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
        public Models.SituacaoDeMoradia SituacaoMoradiaPosseTerra
        {
            get { return this._situacaoMoradiaPosseTerra; }
            set
            {
                this.Ficha.SituacaoMoradiaPosseTerra = value;

                SetProperty(ref _situacaoMoradiaPosseTerra, value);
            }
        }

        private Models.LocalizacaoDaMoradia _localizacao; //Obrigatório
        public Models.LocalizacaoDaMoradia Localizacao
        {
            get { return this._localizacao; }
            set
            {
                this.Ficha.Localizacao = value;

                SetProperty(ref _localizacao, value);
                OnPropertyChanged("IsRural");
                OnPropertyChanged("HasTipoDomicilioAndIsRural");
            }
        }
        public bool IsRural
        {
            get
            {
                return this.Localizacao?.Codigo == 84;
            }
        }
        public bool HasTipoDomicilioAndIsRural
        {
            get
            {
                return ((this.HasTipoDomicilio == true) && (this.IsRural == true));
            }
        }

        private Models.TipoDeDomicilio _tipoDomicilio; //Não Obrigatório
        public Models.TipoDeDomicilio TipoDomicilio
        {
            get { return this._tipoDomicilio; }
            set
            {
                this.Ficha.TipoDomicilio = value;

                SetProperty(ref _tipoDomicilio, value);
            }
        }

        private Models.TipoDeAcessoAoDomicilio _tipoAcessoDomicilio; //Não Obrigatório
        public Models.TipoDeAcessoAoDomicilio TipoAcessoDomicilio
        {
            get { return this._tipoAcessoDomicilio; }
            set
            {
                this.Ficha.TipoAcessoDomicilio = value;

                SetProperty(ref _tipoAcessoDomicilio, value);
            }
        }

        private Models.CondicaoDePosseEUsoDaTerra _areaProducaoRural; //Condicional
        public Models.CondicaoDePosseEUsoDaTerra AreaProducaoRural
        {
            get { return this._areaProducaoRural; }
            set
            {
                this.Ficha.AreaProducaoRural = value;

                SetProperty(ref _areaProducaoRural, value);
            }
        }

        private Models.MaterialPredominanteNaConstrucao _materialPredominanteParedesExtDomicilio; //Não Obrigatório
        public Models.MaterialPredominanteNaConstrucao MaterialPredominanteParedesExtDomicilio
        {
            get { return this._materialPredominanteParedesExtDomicilio; }
            set
            {
                this.Ficha.MaterialPredominanteParedesExtDomicilio = value;

                SetProperty(ref _materialPredominanteParedesExtDomicilio, value);
            }
        }

        private Models.AbastecimentoDeAgua _abastecimentoAgua; //Não Obrigatório
        public Models.AbastecimentoDeAgua AbastecimentoAgua
        {
            get { return this._abastecimentoAgua; }
            set
            {
                this.Ficha.AbastecimentoAgua = value;

                SetProperty(ref _abastecimentoAgua, value);
            }
        }

        Models.AguaConsumoDomicilio _aguaConsumoDomicilio; //Não Obrigatório
        public Models.AguaConsumoDomicilio AguaConsumoDomicilio
        {
            get { return this._aguaConsumoDomicilio; }
            set
            {
                this.Ficha.AguaConsumoDomicilio = value;

                SetProperty(ref _aguaConsumoDomicilio, value);
            }
        }

        private Models.FormaDeEscoamentoDoBanheiroOuSanitario _formaEscoamentoBanheiro; //Não Obrigatório
        public Models.FormaDeEscoamentoDoBanheiroOuSanitario FormaEscoamentoBanheiro
        {
            get { return this._formaEscoamentoBanheiro; }
            set
            {
                this.Ficha.FormaEscoamentoBanheiro = value;

                SetProperty(ref _formaEscoamentoBanheiro, value);
            }
        }

        private Models.DestinoDoLixo _destinoLixo; //Não Obrigatório
        public Models.DestinoDoLixo DestinoLixo
        {
            get { return this._destinoLixo; }
            set
            {
                this.Ficha.DestinoLixo = value;

                SetProperty(ref _destinoLixo, value);
            }
        }

        //USADO PAGE 4
        public ObservableRangeCollection<Models.AnimalNoDomicilio> AnimaisNoDomicilio { get; set; }
        public ObservableCollection<object> AnimaisSelecionados { get; } = new ObservableCollection<object>();

        private bool _stAnimaisNoDomicilio; //Condicional
        public bool StAnimaisNoDomicilio
        {
            get { return this._stAnimaisNoDomicilio; }
            set
            {
                this.Ficha.StAnimaisNoDomicilio = value;

                this.AnimaisSelecionados.Clear();

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

        //SUPER VALIDAÇÕES

        private string _nuMoradores;
        public string NuMoradores
        {
            get { return this._nuMoradores; }
            set
            {
                if (value.Length > 0)
                {
                    int numFamilias = this.Familias.Count();

                    int numMoradores = int.Parse(value);

                    if (numMoradores < numFamilias)
                    {
                        this.Ficha.NuMoradores = numFamilias.ToString();
                    }
                    else
                    {

                        List<Models.FichaFamilia> listaFamilias = this.Familias.Select(o => (Models.FichaFamilia)o).ToList();
                        int somaMembros = 0;

                        for (int i = 0; i < listaFamilias.Count(); i++)
                        {
                            somaMembros += listaFamilias.ElementAt(i).NumeroMembrosFamilia;
                        }

                        if (numMoradores < somaMembros)
                        {
                            this.Ficha.NuMoradores = somaMembros.ToString();
                        }
                        else
                        {
                            this.Ficha.NuMoradores = value;
                        }

                    }

                    SetProperty(ref _nuMoradores, this.Ficha.NuMoradores);

                }
                else
                {
                    this.Ficha.NuMoradores = "1";

                    SetProperty(ref _nuMoradores, "1");
                }
            }
        }

        private string _quantosAnimaisNoDomicilio;
        public string QuantosAnimaisNoDomicilio
        {

            get { return this._quantosAnimaisNoDomicilio; }
            set
            {

                if (value.Length > 0)
                {

                    int numAnimais = int.Parse(value);

                    int animaisSelecionados = this.AnimaisSelecionados.Count();

                    if (numAnimais < animaisSelecionados)
                    {
                        this.Ficha.QuantosAnimaisNoDomicilio = animaisSelecionados.ToString();
                    }
                    else
                    {
                        this.Ficha.QuantosAnimaisNoDomicilio = numAnimais.ToString();
                    }

                    SetProperty(ref _quantosAnimaisNoDomicilio, this.Ficha.QuantosAnimaisNoDomicilio);

                }
                else
                {

                    int animaisSelecionados = this.AnimaisSelecionados.Count();

                    this.Ficha.QuantosAnimaisNoDomicilio = animaisSelecionados.ToString();

                    SetProperty(ref _quantosAnimaisNoDomicilio, this.Ficha.QuantosAnimaisNoDomicilio);
                }

            }

        }

        //

        public FichaCadastroDomiciliarViewModel(Views.FichaCadastroDomiciliarPage.ListFichaCadastroDomiciliar page, Models.FichaCadastroDomiciliarTerritorial ficha = null)
        {
            this.Ficha = new Models.FichaCadastroDomiciliarTerritorial();
            this.RootPage = page;

            this.Continuar = new Command(async () => await ContinuarExecuteAsync());

            this.Concordar = new Command(async () => await ConcordarExecuteAsync());
            this.NaoConcordar = new Command(async () => await NaoConcordarExecuteAsync());

            this.ConcordarInstituicaoPermanencia = new Command(async () => await ConcordarInstituicaoPermanenciaExecuteAsync());
            this.NaoConcordarInstituicaoPermanencia = new Command(async () => await NaoConcordarInstituicaoPermanenciaExecuteAsync());


            #region CarregamentoDados Page2
            this.Logradouros = new ObservableRangeCollection<Models.Logradouro>();
            this.Bairros = new ObservableRangeCollection<Models.Bairro>(new DAO.DAOBairro().Select());
            this.TiposImoveis = new ObservableRangeCollection<Models.TipoDeImovel>(new DAO.DAOTipoDeImovel().Select());

            using (var DAOEstabelecimento = new DAO.DAOEstabelecimento())
            {
                var estabelecimento = DAOEstabelecimento.Select().First();

                this.Municipios = new ObservableRangeCollection<Models.Municipio>();
                this.UFs = new ObservableRangeCollection<Models.UnidadeFederal>();

                this.UFs.Add(new DAO.DAOUnidadeFederal().Select(estabelecimento.Municipio.CodUnidadeFederal));
                this.UF = this.UFs.First();

                this.Municipios.Add(estabelecimento.Municipio);
                this.CodigoIbgeMunicipio = this.Municipios.First();
            };
            #endregion

            this.Familias = new ObservableCollection<object>();

        }

        private async System.Threading.Tasks.Task ConcordarExecuteAsync()
        {
            await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage2(this));
        }

        private async System.Threading.Tasks.Task NaoConcordarExecuteAsync()
        {
            await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarRecusaPage1(this));
        }

        private async System.Threading.Tasks.Task ConcordarInstituicaoPermanenciaExecuteAsync()
        {
            await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage7(this));
        }

        private async System.Threading.Tasks.Task NaoConcordarInstituicaoPermanenciaExecuteAsync()
        {
            await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarRecusaPage3(this));
        }

        public async System.Threading.Tasks.Task TelaInstituicaoPermanenciaExecuteAsync()
        {
            await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage6(this));
        }

        private async System.Threading.Tasks.Task ContinuarExecuteAsync()
        {
            var CurrentPage = this.RootPage.Navigation.NavigationStack.Last(); //PEGA A ULTIMA PAGINA NA PILHA DE NAVEGAÇÃO, OU SEJA A ATUAL.
            if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarRecusaPage1)
            {
                await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarRecusaPage2(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarRecusaPage3)
            {
                await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarRecusaPage4(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage2)
            {
                this.RendasFamiliares = new ObservableRangeCollection<Models.RendaFamiliar>(new DAO.DAORendaFamiliar().Select());

                await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage5(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage3)
            {
                if (this.TipoDeImovel.Codigo == 1)
                {
                    this.AnimaisNoDomicilio = new ObservableRangeCollection<Models.AnimalNoDomicilio>(new DAO.DAOAnimalNoDomicilio().Select());
                    await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage4(this));
                }
                else
                {
                    await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage6(this));
                };

            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage4)
            {

                this.Ficha.AnimaisNoDomicilio = this.AnimaisSelecionados.Select(o => (Models.AnimalNoDomicilio)o).ToList();
                await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage6(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage5)
            {
                #region Carregament dados page 3
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
                #endregion

                await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage3(this));
            }
            else if (CurrentPage is Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage7)
            {
                await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage8(this));
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
            Task.Run(async () =>
            {

                using (DAO.DAOFichaFamilia DAOFichaFamilia = new DAO.DAOFichaFamilia())
                using (DAO.DAOFichaUnicaLotacaoHeader DAOFichaUnicaLotacaoHeader = new DAO.DAOFichaUnicaLotacaoHeader())
                using (DAO.DAOFichaCadastroDomiciliarTerritorial DAOFichaCadastroDomiciliar = new DAO.DAOFichaCadastroDomiciliarTerritorial())
                {
                    try {
                        this.Ficha.Header = new Models.FichaUnicaLotacaoHeader() {
                            Cbo = this.RootPage.MenuPage.ViewModel.Cbo.CodCbo,
                            CnsProfissional = this.RootPage.MenuPage.ViewModel.Profissional.CnsProfissional,
                            Cnes = this.RootPage.MenuPage.ViewModel.Estabelecimento.ImpCnes,
                            Ine = this.RootPage.MenuPage.ViewModel.Equipe.CodEquipe,
                            DataAtendimento = DateTime.Now
                        };

                        this.Ficha.Familias = this.Familias.Select(o => (Models.FichaFamilia)o).ToList();

                        DAOFichaFamilia.Insert(this.Ficha.Familias);
                        DAOFichaUnicaLotacaoHeader.Insert(this.Ficha.Header);
                        DAOFichaCadastroDomiciliar.Insert(this.Ficha);

                        Xamarin.Forms.Device.BeginInvokeOnMainThread(async () => {
                            var BackCount = this.RootPage.Navigation.NavigationStack.Count - 2;
                            for (var counter = 1; counter < BackCount; counter++) {
                                this.RootPage.Navigation.RemovePage(this.RootPage.Navigation.NavigationStack[this.RootPage.Navigation.NavigationStack.Count - 2]);
                            };

                            await this.RootPage.Navigation.PopAsync();
                            //await this.RootPage.Navigation.PopToRootAsync();
                        });
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