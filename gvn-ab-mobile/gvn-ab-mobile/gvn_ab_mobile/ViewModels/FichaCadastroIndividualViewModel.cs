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

namespace gvn_ab_mobile.ViewModels {
    public class FichaCadastroIndividualViewModel : BaseViewModel {
        private Views.FichaCadastroIndividualPage.ListFichaCadastroIndividual RootPage { get; set; }

        public ICommand Continuar { get; }

        public ICommand Concordar { get; }
        public ICommand NaoConcordar { get; }

        public Models.FichaCadastroIndividual Ficha { get; set; }

        public List<Point> SignaturePoints;
        public Stream SignatureImage;

        public string NomeRG => $"{this.Ficha.NomeCidadao}, portador(a) do RG nº {this.Ficha.Rg}".Trim();

        // USADO PAGE 2
        public ObservableRangeCollection<Models.Sexo> Sexos { get; set; }
        public ObservableRangeCollection<Models.Pais> Paises { get; set; }
        public ObservableRangeCollection<Models.Etnia> Etnias { get; set; }
        public ObservableRangeCollection<Models.RacaCor> RacasCores { get; set; }
        public ObservableRangeCollection<Models.UnidadeFederal> UFs { get; set; }
        public ObservableRangeCollection<Models.Municipio> Municipios { get; set; }

        private Models.UnidadeFederal uf;
        public Models.UnidadeFederal UF {
            get { return this.uf; }
            set {
                SetProperty(ref uf, value);

                this.Municipio = null;
                using (DAO.DAOMunicipio DAOMunicipio = new DAO.DAOMunicipio()) {
                    this.Municipios.Clear();
                    this.Municipios.AddRange(DAOMunicipio.GetByCodUnidadeFederal(value.CodUnidadeFederal));
                };
            }

        }
        private Models.Municipio municipio;
        public Models.Municipio Municipio {
            get { return this.municipio; }
            set {
                this.Ficha.MunicipioNascimento = value;
                SetProperty(ref municipio, value);
            }
        }

        private Models.Pais _paisNascimento;
        public Models.Pais PaisNascimento {
            get { return this._paisNascimento; }
            set {
                this.Ficha.PaisNascimento = value;

                SetProperty(ref _paisNascimento, value);
            }
        }

        Models.Sexo _sexoCidadao;
        public Models.Sexo SexoCidadao {
            get { return this._sexoCidadao; }
            set {
                this.Ficha.SexoCidadao = value;

                SetProperty(ref _sexoCidadao, value);
                OnPropertyChanged("IsMulher");
                OnPropertyChanged("IsMulherAndHasIdadeGravida");
            }
        }
        public bool IsMulher {
            get {
                return this.SexoCidadao?.Codigo == 1;
            }
        }
        public bool IsMulherAndHasIdadeGravida {
            get {
                System.DateTime data1 = DateTime.Now;
                System.DateTime data2 = this.Ficha.DataNascimentoCidadao;
                System.TimeSpan dataDiff = data1 - data2;
                double totalDays = dataDiff.TotalDays;

                return !((this.IsMulher == false) || ((totalDays < (9.0 * 365)) || (totalDays > (60.0 * 365))));
            }
        }

        public DateTime PropertyMinimumDate {
            get {
                return DateTime.Now.AddYears(-130);
            }
        }

        public DateTime PropertyMinimumDateNaturalizacao {
            get {
                DateTime data = DateTime.Now;
                int year = data.Year - this.Ficha.DataNascimentoCidadao.Year;
                int month = data.Month - this.Ficha.DataNascimentoCidadao.Month;
                int day = data.Day - this.Ficha.DataNascimentoCidadao.Day;

                if (data.Day != this.Ficha.DataNascimentoCidadao.Day) {
                    data = data.AddDays(-(day));
                    data = data.AddMonths(-(month));
                }
                return data.AddYears(-year);
            }
        }

        public bool HasIdadeResponsavelCrianca {
            get {
                System.DateTime data1 = DateTime.Now;
                System.DateTime data2 = this.Ficha.DataNascimentoCidadao;
                System.TimeSpan dataDiff = data1 - data2;
                double totalDays = dataDiff.TotalDays;

                return !(totalDays < (10.0 * 365));
            }
        }

        private DateTime _dataNascimentoCidadao;
        public DateTime DataNascimentoCidadao {
            get { return this._dataNascimentoCidadao; }
            set {
                this.Ficha.DataNascimentoCidadao = value;

                SetProperty(ref _dataNascimentoCidadao, value);
                OnPropertyChanged("IsMulherAndHasIdadeGravida");
                OnPropertyChanged("PropertyMinimumDateNaturalizacaoOuEntradaBrasil");
                OnPropertyChanged("HasIdadeResponsavelCrianca");
            }
        }

        private Models.Etnia _etnia; //Condicional
        public Models.Etnia Etnia {
            get { return this._etnia; }
            set {
                this.Ficha.Etnia = value;

                SetProperty(ref _etnia, value);
            }
        }

        Models.RacaCor _racaCorCidadao;
        public Models.RacaCor RacaCorCidadao {
            get { return this._racaCorCidadao; }
            set {
                this.Ficha.RacaCorCidadao = value;

                SetProperty(ref _racaCorCidadao, value);
                OnPropertyChanged("IsRacaCor5");
            }
        }
        public bool IsRacaCor5 {
            get {
                return this.RacaCorCidadao?.Codigo == 5;
            }
        }

        private bool _statusEhResponsavel; //Não Obrigatório
        public bool StatusEhResponsavel {
            get { return this._statusEhResponsavel; }
            set {
                this.Ficha.StatusEhResponsavel = value;
                this.Ficha.CnsResponsavelFamiliar = string.Empty;

                SetProperty(ref _statusEhResponsavel, value);
                OnPropertyChanged("IsResponsavel");
            }
        }
        public bool IsResponsavel {
            get {
                return !this.StatusEhResponsavel;
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

        private bool _desconheceNomeMae; //Não Obrigatório
        public bool DesconheceNomeMae {
            get { return this._desconheceNomeMae; }
            set {
                this.Ficha.DesconheceNomeMae = value;
                this.Ficha.NomeMaeCidadao = string.Empty;

                SetProperty(ref _desconheceNomeMae, value);
                OnPropertyChanged("KnowsNomeMae");
            }
        }
        public bool KnowsNomeMae {
            get {
                return !this.DesconheceNomeMae;
            }
        }

        private bool _desconheceNomePai; //Não Obrigatório
        public bool DesconheceNomePai {
            get { return this._desconheceNomePai; }
            set {
                this.Ficha.DesconheceNomePai = value;
                this.Ficha.NomePaiCidadao = string.Empty;

                SetProperty(ref _desconheceNomePai, value);
                OnPropertyChanged("KnowsNomePai");
            }
        }
        public bool KnowsNomePai {
            get {
                return !this.DesconheceNomePai;
            }
        }

        Models.Nacionalidade _nacionalidadeCidadao;
        public Models.Nacionalidade NacionalidadeCidadao {
            get { return this._nacionalidadeCidadao; }
            set {
                this.Ficha.NacionalidadeCidadao = value;

                SetProperty(ref _nacionalidadeCidadao, value);
                OnPropertyChanged("IsBrasileiro");
                OnPropertyChanged("IsEstrangeiro");
                OnPropertyChanged("IsNaturalizado");
            }
        }

        public bool IsBrasileiro {
            get {
                return this.NacionalidadeCidadao?.Codigo == 1;
            }
            set {

                //Arrumar

                this.Ficha.PaisNascimento.Codigo = 31;
                this.Ficha.PaisNascimento.Descricao = "Brasil";
            }

        }
        public bool IsEstrangeiro {
            get {
                return this.NacionalidadeCidadao?.Codigo == 3;
            }
        }
        public bool IsNaturalizado {
            get {
                return this.NacionalidadeCidadao?.Codigo == 2;
            }
        }

        public ObservableRangeCollection<Models.Nacionalidade> Nacionalidades { get; set; }

        // USADO PAGE 3
        public ObservableRangeCollection<Models.CursoMaisElevado> CursosMaisElevados { get; set; }
        public ObservableRangeCollection<Models.Ocupacao> Ocupacoes { get; set; }
        public ObservableRangeCollection<Models.ResponsavelCrianca> ResponsaveisCriancas { get; set; }
        public ObservableCollection<object> ResponsaveisCriancasSelecionadas { get; } = new ObservableCollection<object>();
        public ObservableRangeCollection<Models.SituacaoMercadoTrabalho> SituacoesMercadoTrabalho { get; set; }
        public ObservableRangeCollection<Models.IdentidadeGeneroCidadao> IdentidadeGeneroCidadaos { get; set; }
        public ObservableRangeCollection<Models.OrientacaoSexual> OrientacoesSexuais { get; set; }
        public ObservableRangeCollection<Models.RelacaoParentesco> RelacoesParentesco { get; set; }
        public ObservableRangeCollection<Models.DeficienciaCidadao> DeficienciasCidadao { get; set; }
        public ObservableCollection<object> DeficienciasSelecionadas { get; } = new ObservableCollection<object>();

        private Models.RelacaoParentesco _relacaoParentescoCidadao; //Não Obrigatório
        public Models.RelacaoParentesco RelacaoParentescoCidadao {
            get { return this._relacaoParentescoCidadao; }
            set {
                this.Ficha.RelacaoParentescoCidadao = value;

                SetProperty(ref _relacaoParentescoCidadao, value);
            }
        }

        private Models.CursoMaisElevado _grauInstrucaoCidadao; //Não Obrigatório
        public Models.CursoMaisElevado GrauInstrucaoCidadao {
            get { return this._grauInstrucaoCidadao; }
            set {
                this.Ficha.GrauInstrucaoCidadao = value;

                SetProperty(ref _grauInstrucaoCidadao, value);
            }
        }

        private Models.SituacaoMercadoTrabalho _situacaoMercadoTrabalhoCidadao; //Não Obrigatório
        public Models.SituacaoMercadoTrabalho SituacaoMercadoTrabalhoCidadao {
            get { return this._situacaoMercadoTrabalhoCidadao; }
            set {
                this.Ficha.SituacaoMercadoTrabalhoCidadao = value;

                SetProperty(ref _situacaoMercadoTrabalhoCidadao, value);
            }
        }

        private Models.OrientacaoSexual _orientacaoSexualCidadao; //Não Obrigatório
        public Models.OrientacaoSexual OrientacaoSexualCidadao {
            get { return this._orientacaoSexualCidadao; }
            set {
                this.Ficha.OrientacaoSexualCidadao = value;

                SetProperty(ref _orientacaoSexualCidadao, value);
            }
        }

        private Models.IdentidadeGeneroCidadao _identidadeGeneroCidadao; //Não Obrigatório
        public Models.IdentidadeGeneroCidadao IdentidadeGeneroCidadao {
            get { return this._identidadeGeneroCidadao; }
            set {
                this.Ficha.IdentidadeGeneroCidadao = value;

                SetProperty(ref _identidadeGeneroCidadao, value);
            }
        }

        private bool _statusMembroPovoComunidadeTradicional; //Não Obrigatório
        public bool StatusMembroPovoComunidadeTradicional {
            get { return this._statusMembroPovoComunidadeTradicional; }
            set {
                this.Ficha.StatusMembroPovoComunidadeTradicional = value;
                this.Ficha.PovoComunidadeTradicional = string.Empty;

                SetProperty(ref _statusMembroPovoComunidadeTradicional, value);
                OnPropertyChanged("IsMembroPovoComunidadeTradicional");
            }
        }
        public bool IsMembroPovoComunidadeTradicional {
            get {
                return this.StatusMembroPovoComunidadeTradicional;
            }
        }

        private bool _statusDesejaInformarOrientacaoSexual; //Não Obrigatório
        public bool StatusDesejaInformarOrientacaoSexual {
            get { return this._statusDesejaInformarOrientacaoSexual; }
            set {
                this.Ficha.StatusDesejaInformarOrientacaoSexual = value;
                this.Ficha.OrientacaoSexualCidadao = null;

                SetProperty(ref _statusDesejaInformarOrientacaoSexual, value);
                OnPropertyChanged("WantsInformarOrientacaoSexual");
            }
        }
        public bool WantsInformarOrientacaoSexual {
            get {
                return this.StatusDesejaInformarOrientacaoSexual;
            }
        }

        private bool _statusDesejaInformarIdentidadeGenero; //Não Obrigatório
        public bool StatusDesejaInformarIdentidadeGenero {
            get { return this._statusDesejaInformarIdentidadeGenero; }
            set {
                this.Ficha.StatusDesejaInformarIdentidadeGenero = value;
                this.Ficha.IdentidadeGeneroCidadao = null;

                SetProperty(ref _statusDesejaInformarIdentidadeGenero, value);
                OnPropertyChanged("WantsInformarIdentidadeGenero");
            }
        }
        public bool WantsInformarIdentidadeGenero {
            get {
                return this.StatusDesejaInformarIdentidadeGenero;
            }
        }

        private bool _statusTemAlgumaDeficiencia; //Obrigatório
        public bool StatusTemAlgumaDeficiencia {
            get { return this._statusTemAlgumaDeficiencia; }
            set {
                this.Ficha.StatusTemAlgumaDeficiencia = value;
                this.DeficienciasSelecionadas.Clear();

                SetProperty(ref _statusTemAlgumaDeficiencia, value);
                OnPropertyChanged("HasAlgumaDeficiencia");
            }
        }
        public bool HasAlgumaDeficiencia {
            get {
                return this.StatusTemAlgumaDeficiencia;
            }
        }

        // USADO PAGE 4
        public ObservableRangeCollection<Models.MotivoSaida> MotivosSaida { get; set; }

        private bool _statusDesejaSairDoCadastro;
        public bool StatusDesejaSairDoCadastro {
            get { return this._statusDesejaSairDoCadastro; }
            set {
                SetProperty(ref _statusDesejaSairDoCadastro, value);

                this.MotivoSaida = null;
                this.Ficha.NumeroDO = null;

                OnPropertyChanged("WantsSairDoCadastro");
                OnPropertyChanged("WantsSairDoCadastroAndIsMotivoObito");
            }
        }
        public bool WantsSairDoCadastro {
            get {
                return this.StatusDesejaSairDoCadastro;
            }
        }

        Models.MotivoSaida _motivoSaida;
        public Models.MotivoSaida MotivoSaida {
            get { return this._motivoSaida; }
            set {
                this.Ficha.MotivoSaidaCidadao = value;

                SetProperty(ref _motivoSaida, value);
                OnPropertyChanged("IsMotivoObito");
                OnPropertyChanged("WantsSairDoCadastroAndIsMotivoObito");
            }
        }
        public bool IsMotivoObito {
            get {
                return this.MotivoSaida?.Codigo == 135;
            }
        }
        public bool WantsSairDoCadastroAndIsMotivoObito {
            get {
                return ((this.WantsSairDoCadastro == true) && (this.IsMotivoObito == true));
            }
        }

        // USADO PAGE 5
        public ObservableRangeCollection<Models.ConsideracaoPeso> ConsideracoesPeso { get; set; }
        public ObservableRangeCollection<Models.DoencaCardiaca> DoencasCardiacas { get; set; }
        public ObservableCollection<object> DoencasCardiacasSelecionadas { get; } = new ObservableCollection<object>();

        public ObservableRangeCollection<Models.ProblemaRins> ProblemasRins { get; set; }
        public ObservableCollection<object> ProblemasRinsSelecionados { get; } = new ObservableCollection<object>();

        public ObservableRangeCollection<Models.DoencaRespiratoria> DoencasRespiratorias { get; set; }
        public ObservableCollection<object> DoencasRespiratoriasSelecionadas { get; } = new ObservableCollection<object>();

        private bool _statusEhGestante; //Não Obrigatório
        public bool StatusEhGestante {
            get { return this._statusEhGestante; }
            set {
                this.Ficha.StatusEhGestante = value;

                SetProperty(ref _statusEhGestante, value);
                OnPropertyChanged("IsGestante");
            }
        }
        public bool IsGestante {
            get {
                return this.StatusEhGestante;
            }
        }

        private bool _statusDoencaCardiaca; //Não Obrigatório
        public bool StatusDoencaCardiaca {
            get { return this._statusDoencaCardiaca; }
            set {
                this.Ficha.StatusTeveDoencaCardiaca = value;

                this.DoencasCardiacasSelecionadas.Clear();

                SetProperty(ref _statusDoencaCardiaca, value);
                OnPropertyChanged("HasDoencaCardiaca");
            }
        }
        public bool HasDoencaCardiaca {
            get {
                return this.StatusDoencaCardiaca;
            }
        }

        private bool _statusDoencaRins; //Não Obrigatório
        public bool StatusDoencaRins {
            get { return this._statusDoencaRins; }
            set {
                this.Ficha.StatusTemTeveDoencasRins = value;

                this.ProblemasRinsSelecionados.Clear();

                SetProperty(ref _statusDoencaRins, value);
                OnPropertyChanged("HasDoencaRins");
            }
        }
        public bool HasDoencaRins {
            get {
                return this.StatusDoencaRins;
            }
        }

        private bool _statusDoencaRespiratoria; //Não Obrigatório
        public bool StatusDoencaRespiratoria {
            get { return this._statusDoencaRespiratoria; }
            set {
                this.Ficha.StatusTemDoencaRespiratoria = value;
                this.DoencasRespiratoriasSelecionadas.Clear();

                SetProperty(ref _statusDoencaRespiratoria, value);
                OnPropertyChanged("HasDoencaRespiratoria");
            }
        }
        public bool HasDoencaRespiratoria {
            get {
                return this.StatusDoencaRespiratoria;
            }
        }

        private bool _statusTeveInternadoem12Meses; //Não Obrigatório
        public bool StatusTeveInternadoEm12Meses {
            get { return this._statusTeveInternadoem12Meses; }
            set {
                this.Ficha.StatusTeveInternadoem12Meses = value;
                this.Ficha.DescricaoCausaInternacaoEm12Meses = string.Empty;

                SetProperty(ref _statusTeveInternadoem12Meses, value);
                OnPropertyChanged("HasInternacaoEm12Meses");
            }
        }
        public bool HasInternacaoEm12Meses {
            get {
                return this.StatusTeveInternadoEm12Meses;
            }
        }

        private bool _statusUsaPlantasMedicinais; //Não Obrigatório
        public bool StatusUsaPlantasMedicinais {
            get { return this._statusUsaPlantasMedicinais; }
            set {
                this.Ficha.StatusUsaPlantasMedicinais = value;
                this.Ficha.DescricaoPlantasMedicinaisUsadas = string.Empty;

                SetProperty(ref _statusUsaPlantasMedicinais, value);
                OnPropertyChanged("UsesPlantasMedicinais");
            }
        }
        public bool UsesPlantasMedicinais {
            get {
                return this.StatusUsaPlantasMedicinais;
            }
        }

        private bool _outrasCondicoesDeSaude;
        public bool OutrasCondicoesDeSaude {
            get { return this._outrasCondicoesDeSaude; }
            set {
                SetProperty(ref _outrasCondicoesDeSaude, value);

                this.Ficha.DescricaoOutraCondicao1 = string.Empty;
                this.Ficha.DescricaoOutraCondicao2 = string.Empty;
                this.Ficha.DescricaoOutraCondicao3 = string.Empty;

                OnPropertyChanged("HasOutrasCondicoesDeSaude");
            }
        }
        public bool HasOutrasCondicoesDeSaude {
            get {
                return this.OutrasCondicoesDeSaude == true;
            }
        }

        //USADO PAGE 6
        public ObservableRangeCollection<Models.AcessoHigiene> HigienePessoal { get; set; }
        public ObservableCollection<object> HigienesSelecionadas { get; } = new ObservableCollection<object>();
        public ObservableRangeCollection<Models.QuantasVezesAlimentacao> QuantasVezesAlimentacao { get; set; }
        public ObservableRangeCollection<Models.TempoSituacaoDeRua> TempoSituacoesDeRua { get; set; }
        public ObservableRangeCollection<Models.OrigemAlimentacao> OrigemAlimentacao { get; set; }
        public ObservableCollection<object> OrigensAlimentacaoSelecionadas { get; } = new ObservableCollection<object>();

        private bool _statusSituacaoRua = true; //Obrigatório
        public bool StatusSituacaoRua {
            get { return this._statusSituacaoRua; }
            set {
                this.Ficha.StatusSituacaoRua = value;

                this.TempoSituacaoRua = null;
                this.Ficha.StatusRecebeBeneficio = false;
                this.Ficha.StatusPossuiReferenciaFamiliar = false;
                this.QuantidadeAlimentacoesAoDiaSituacaoRua = null;
                this.OrigensAlimentacaoSelecionadas.Clear();
                this.StatusAcompanhadoPorOutraInstituicao = false;
                this.StatusVisitaFamiliarFrequentemente = false;
                this.StatusTemAcessoHigienePessoalSituacaoRua = false;

                SetProperty(ref _statusSituacaoRua, value);
                OnPropertyChanged("IsSituacaoRua");
                OnPropertyChanged("IsSituacaoRuaAndVisitsFamiliarFrequentemente");
                OnPropertyChanged("IsSituacaoRuaAndHasAcessoHigienePessoalSituacaoRua");
                OnPropertyChanged("IsSituacaoRuaAndIsAcompanhadoPorOutraInstituicao");
            }
        }
        public bool IsSituacaoRua {
            get {
                return this.StatusSituacaoRua;
            }
        }

        private Models.TempoSituacaoDeRua _tempoSituacaoRua;
        public Models.TempoSituacaoDeRua TempoSituacaoRua {
            get { return this._tempoSituacaoRua; }
            set {
                this.Ficha.TempoSituacaoRua = value;

                SetProperty(ref _tempoSituacaoRua, value);
            }
        }

        private Models.QuantasVezesAlimentacao _quantidadeAlimentacoesAoDiaSituacaoRua;
        public Models.QuantasVezesAlimentacao QuantidadeAlimentacoesAoDiaSituacaoRua {
            get { return this._quantidadeAlimentacoesAoDiaSituacaoRua; }
            set {
                this.Ficha.QuantidadeAlimentacoesAoDiaSituacaoRua = value;

                SetProperty(ref _quantidadeAlimentacoesAoDiaSituacaoRua, value);
            }
        }

        private bool _statusAcompanhadoPorOutraInstituicao; //Não Obrigatório
        public bool StatusAcompanhadoPorOutraInstituicao {
            get { return this._statusAcompanhadoPorOutraInstituicao; }
            set {
                this.Ficha.StatusAcompanhadoPorOutraInstituicao = value;
                this.Ficha.OutraInstituicaoQueAcompanha = string.Empty;

                SetProperty(ref _statusAcompanhadoPorOutraInstituicao, value);
                OnPropertyChanged("IsAcompanhadoPorOutraInstituicao");
                OnPropertyChanged("IsSituacaoRuaAndIsAcompanhadoPorOutraInstituicao");
            }
        }
        public bool IsAcompanhadoPorOutraInstituicao {
            get {
                return this.StatusAcompanhadoPorOutraInstituicao;
            }
        }
        public bool IsSituacaoRuaAndIsAcompanhadoPorOutraInstituicao {
            get {
                return ((this.IsSituacaoRua == true) && (this.IsAcompanhadoPorOutraInstituicao == true));
            }
        }

        private bool _statusVisitaFamiliarFrequentemente; //Não Obrigatório
        public bool StatusVisitaFamiliarFrequentemente {
            get { return this._statusVisitaFamiliarFrequentemente; }
            set {
                this.Ficha.StatusVisitaFamiliarFrequentemente = value;
                this.Ficha.GrauParentescoFamiliarFrequentado = string.Empty;

                SetProperty(ref _statusVisitaFamiliarFrequentemente, value);
                OnPropertyChanged("VisitsFamiliarFrequentemente");
                OnPropertyChanged("IsSituacaoRuaAndVisitsFamiliarFrequentemente");
            }
        }
        public bool VisitsFamiliarFrequentemente {
            get {
                return this.StatusVisitaFamiliarFrequentemente;
            }
        }
        public bool IsSituacaoRuaAndVisitsFamiliarFrequentemente {
            get {
                return ((this.IsSituacaoRua == true) && (this.VisitsFamiliarFrequentemente == true));
            }
        }

        private bool _statusTemAcessoHigienePessoalSituacaoRua; //Não Obrigatório
        public bool StatusTemAcessoHigienePessoalSituacaoRua {
            get { return this._statusTemAcessoHigienePessoalSituacaoRua; }
            set {
                this.Ficha.StatusTemAcessoHigienePessoalSituacaoRua = value;
                this.HigienesSelecionadas.Clear();

                SetProperty(ref _statusTemAcessoHigienePessoalSituacaoRua, value);
                OnPropertyChanged("HasAcessoHigienePessoalSituacaoRua");
                OnPropertyChanged("IsSituacaoRuaAndHasAcessoHigienePessoalSituacaoRua");
            }
        }
        public bool HasAcessoHigienePessoalSituacaoRua {
            get {
                return this.StatusTemAcessoHigienePessoalSituacaoRua;
            }
        }
        public bool IsSituacaoRuaAndHasAcessoHigienePessoalSituacaoRua {
            get {
                return ((this.IsSituacaoRua == true) && (this.HasAcessoHigienePessoalSituacaoRua == true));
            }
        }


        public FichaCadastroIndividualViewModel(Views.FichaCadastroIndividualPage.ListFichaCadastroIndividual rootPage, Models.FichaCadastroIndividual objFicha = null) {
            this.Ficha = new Models.FichaCadastroIndividual(); ;
            this.RootPage = rootPage;

            this.Continuar = new Command(async () => await ContinuarExecuteAsync());

            this.Concordar = new Command(async () => await ConcordarExecuteAsync());
            this.NaoConcordar = new Command(async () => await NaoConcordarExecuteAsync());

            this.Sexos = new ObservableRangeCollection<Models.Sexo>(new DAO.DAOSexo().Select()); //traz todos os sexos na base.
            this.Paises = new ObservableRangeCollection<Models.Pais>(new DAO.DAOPais().Select());
            this.Etnias = new ObservableRangeCollection<Models.Etnia>(new DAO.DAOEtnia().Select());
            this.RacasCores = new ObservableRangeCollection<Models.RacaCor>(new DAO.DAORacaCor().Select());
            this.Nacionalidades = new ObservableRangeCollection<Models.Nacionalidade>(new DAO.DAONacionalidade().Select());
            this.UFs = new ObservableRangeCollection<Models.UnidadeFederal>(new DAO.DAOUnidadeFederal().Select());
            this.Municipios = new ObservableRangeCollection<Models.Municipio>();

            this.CursosMaisElevados = new ObservableRangeCollection<Models.CursoMaisElevado>(new DAO.DAOCursoMaisElevado().Select());
            this.Ocupacoes = new ObservableRangeCollection<Models.Ocupacao>(new DAO.DAOOcupacao().Select());
            this.ResponsaveisCriancas = new ObservableRangeCollection<Models.ResponsavelCrianca>(new DAO.DAOResponsavelCrianca().Select());
            this.SituacoesMercadoTrabalho = new ObservableRangeCollection<Models.SituacaoMercadoTrabalho>(new DAO.DAOSituacaoMercadoTrabalho().Select());
            this.IdentidadeGeneroCidadaos = new ObservableRangeCollection<Models.IdentidadeGeneroCidadao>(new DAO.DAOIdentidadeGeneroCidadao().Select());
            this.OrientacoesSexuais = new ObservableRangeCollection<Models.OrientacaoSexual>(new DAO.DAOOrientacaoSexual().Select());
            this.RelacoesParentesco = new ObservableRangeCollection<Models.RelacaoParentesco>(new DAO.DAORelacaoParentesco().Select());
            this.DeficienciasCidadao = new ObservableRangeCollection<Models.DeficienciaCidadao>(new DAO.DAODeficienciaCidadao().Select());

            this.MotivosSaida = new ObservableRangeCollection<Models.MotivoSaida>(new DAO.DAOMotivoSaida().Select());

            this.ConsideracoesPeso = new ObservableRangeCollection<Models.ConsideracaoPeso>(new DAO.DAOConsideracaoPeso().Select());
            this.DoencasCardiacas = new ObservableRangeCollection<Models.DoencaCardiaca>(new DAO.DAODoencaCardiaca().Select());
            this.ProblemasRins = new ObservableRangeCollection<Models.ProblemaRins>(new DAO.DAOProblemaRins().Select());
            this.DoencasRespiratorias = new ObservableRangeCollection<Models.DoencaRespiratoria>(new DAO.DAODoencaRespiratoria().Select());

            this.HigienePessoal = new ObservableRangeCollection<Models.AcessoHigiene>(new DAO.DAOAcessoHigiene().Select());
            this.QuantasVezesAlimentacao = new ObservableRangeCollection<Models.QuantasVezesAlimentacao>(new DAO.DAOQuantasVezesAlimentacao().Select());
            this.TempoSituacoesDeRua = new ObservableRangeCollection<Models.TempoSituacaoDeRua>(new DAO.DAOTempoSituacaoDeRua().Select());
            this.OrigemAlimentacao = new ObservableRangeCollection<Models.OrigemAlimentacao>(new DAO.DAOOrigemAlimentacao().Select());

            //Valor Default para o Switch Situação de Rua
            this.StatusSituacaoRua = true;

        }

        private async System.Threading.Tasks.Task ConcordarExecuteAsync() {
            await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage2(this));
        }

        private async System.Threading.Tasks.Task NaoConcordarExecuteAsync() {
            await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualRecusaPage1(this));
        }

        private async System.Threading.Tasks.Task ContinuarExecuteAsync() {
            var CurrentPage = this.RootPage.Navigation.NavigationStack.Last(); //PEGA A ULTIMA PAGINA NA PILHA DE NAVEGAÇÃO, OU SEJA A ATUAL.
            if (CurrentPage is Views.FichaCadastroIndividualPage.FichaCadastroIndividualRecusaPage1) {
                await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualRecusaPage2(this));
            } else if (CurrentPage is Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage2) {
                await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage3(this));
            } else if (CurrentPage is Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage3) {
                //passa informaçoes da model para a entidade
                this.Ficha.ResponsavelPorCrianca = this.ResponsaveisCriancasSelecionadas.Select(o => (Models.ResponsavelCrianca)o).ToList();
                this.Ficha.DeficienciasCidadao = this.DeficienciasSelecionadas.Select(o => (Models.DeficienciaCidadao)o).ToList();

                await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage4(this));
            } else if (CurrentPage is Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage4) {
                await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage5(this));
            } else if (CurrentPage is Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage5) {

                this.Ficha.DoencaCardiaca = this.DoencasCardiacasSelecionadas.Select(o => (Models.DoencaCardiaca)o).ToList();
                this.Ficha.DoencaRins = this.ProblemasRinsSelecionados.Select(o => (Models.ProblemaRins)o).ToList();
                this.Ficha.DoencaRespiratoria = this.DoencasRespiratoriasSelecionadas.Select(o => (Models.DoencaRespiratoria)o).ToList();

                await this.RootPage.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage6(this));
            } else if (CurrentPage is Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage6) {
                this.Ficha.OrigemAlimentoSituacaoRua = this.OrigensAlimentacaoSelecionadas.Select(o => (Models.OrigemAlimentacao)o).ToList();
                this.Ficha.HigienePessoalSituacaoRua = this.HigienesSelecionadas.Select(o => (Models.AcessoHigiene)o).ToList();

                await SalvarExecuteAsync();

            };
        }

        public async System.Threading.Tasks.Task SalvarExecuteAsync() {

            this.IsBusy = true;
#pragma warning disable CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída
            Task.Run(async () => {

                using (DAO.DAOFichaUnicaLotacaoHeader DAOFichaUnicaLotacaoHeader = new DAO.DAOFichaUnicaLotacaoHeader())
                using (DAO.DAOFichaCadastroIndividual DAOFichaCadastroIndividual = new DAO.DAOFichaCadastroIndividual()) {
                    try {
                        this.Ficha.Header = new Models.FichaUnicaLotacaoHeader() {
                            Cbo = this.RootPage.MenuPage.ViewModel.Cbo.CodCbo,
                            CnsProfissional = this.RootPage.MenuPage.ViewModel.Profissional.CnsProfissional,
                            Cnes = this.RootPage.MenuPage.ViewModel.Estabelecimento.ImpCnes,
                            Ine = this.RootPage.MenuPage.ViewModel.Equipe.CodEquipe,
                            DataAtendimento = DateTime.Now
                        };

                        DAOFichaUnicaLotacaoHeader.Insert(this.Ficha.Header);
                        DAOFichaCadastroIndividual.Insert(this.Ficha);
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(async () => {
                            var BackCount = this.RootPage.Navigation.NavigationStack.Count - 2;
                            for (var counter = 1; counter < BackCount; counter++) {
                                this.RootPage.Navigation.RemovePage(this.RootPage.Navigation.NavigationStack[this.RootPage.Navigation.NavigationStack.Count - 2]);
                            };

                            await this.RootPage.Navigation.PopAsync();
                        });
                    } catch (Exception e) {
                        System.Diagnostics.Debug.WriteLine(e);
                    } finally {
                        this.IsBusy = false;
                    };
                };
            });
#pragma warning restore CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída

        }

    }
}