using gvn_ab_mobile.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableRangeCollection<Models.Municipio> Municipios { get; set; }

        private Models.Municipio municipio;
        public Models.Municipio Municipio
        {
            get { return this.municipio; }
            set {

                this.Ficha.MunicipioNascimento = value;
                SetProperty(ref municipio, value);
            }
        }

        private Models.Pais _paisNascimento;
        public Models.Pais PaisNascimento
        {
            get { return this._paisNascimento; }
            set {
                this.Ficha.PaisNascimento = value;

                SetProperty(ref _paisNascimento, value);
            }
        }

        private Models.Sexo _sexoCidadao;
        public Models.Sexo SexoCidadao {
            get { return this._sexoCidadao; }
            set {
                this.Ficha.SexoCidadao = value;

                SetProperty(ref _sexoCidadao, value);
                OnPropertyChanged("IsMulher");
            }
        }
        public bool IsMulher
        {
            get
            {
                return this.SexoCidadao?.Codigo == 1;
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
            get
            {
                return this.NacionalidadeCidadao?.Codigo == 1;
            }
            set
            {
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

        private bool _statusDesejaSairDoCadastro; //Obrigatório
        public bool StatusDesejaSairDoCadastro {
            get { return this._statusDesejaSairDoCadastro; }
            set {
                SetProperty(ref _statusDesejaSairDoCadastro, value);
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
        public bool WantsSairDoCadastroAndIsMotivoObito
        {
            get
            {
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
        public bool OutrasCondicoesDeSaude
        {
            get { return this._outrasCondicoesDeSaude; }
            set
            {
                SetProperty(ref _outrasCondicoesDeSaude, value);
                OnPropertyChanged("HasOutrasCondicoesDeSaude");
            }
        }
        public bool HasOutrasCondicoesDeSaude
        {
            get
            {
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

        private bool _statusSituacaoRua; //Obrigatório
        public bool StatusSituacaoRua {
            get { return this._statusSituacaoRua; }
            set {
                this.Ficha.StatusSituacaoRua = value;

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
        public Models.TempoSituacaoDeRua TempoSituacaoRua
        {
            get { return this._tempoSituacaoRua; }
            set {
                this.Ficha.TempoSituacaoRua = value;

                SetProperty(ref _tempoSituacaoRua, value);
            }
        }

        private Models.QuantasVezesAlimentacao _quantidadeAlimentacoesAoDiaSituacaoRua;
        public Models.QuantasVezesAlimentacao QuantidadeAlimentacoesAoDiaSituacaoRua
        {
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
        public bool IsSituacaoRuaAndIsAcompanhadoPorOutraInstituicao
        {
            get
            {
                return ((this.IsSituacaoRua == true) && (this.IsAcompanhadoPorOutraInstituicao == true));
            }
        }

        private bool _statusVisitaFamiliarFrequentemente; //Não Obrigatório
        public bool StatusVisitaFamiliarFrequentemente {
            get { return this._statusVisitaFamiliarFrequentemente; }
            set {
                this.Ficha.StatusVisitaFamiliarFrequentemente = value;

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
        public bool IsSituacaoRuaAndVisitsFamiliarFrequentemente
        {
            get
            {
                return ((this.IsSituacaoRua == true) && ( this.VisitsFamiliarFrequentemente == true));
            }
        }

        private bool _statusTemAcessoHigienePessoalSituacaoRua; //Não Obrigatório
        public bool StatusTemAcessoHigienePessoalSituacaoRua {
            get { return this._statusTemAcessoHigienePessoalSituacaoRua; }
            set {
                this.Ficha.StatusTemAcessoHigienePessoalSituacaoRua = value;

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
        public bool IsSituacaoRuaAndHasAcessoHigienePessoalSituacaoRua
        {
            get
            {
                return ((this.IsSituacaoRua == true) && (this.HasAcessoHigienePessoalSituacaoRua == true));
            }
        }

        /*public bool ShowOutraInstituicaoQueAcompanha
        {
            get
            {
                return (IsSituacaoRua && IsAcompanhadoPorOutraInstituicao);
            }
        }*/


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
            this.Municipios = new ObservableRangeCollection<Models.Municipio>(new DAO.DAOMunicipio().Select());

            this.CursosMaisElevados = new ObservableRangeCollection<Models.CursoMaisElevado>(new DAO.DAOCursoMaisElevado().Select());
            //this.Ocupacoes = new ObservableRangeCollection<Models.Ocupacao>(); //MAPEAR OS CBOS ..... AINDA TEM Q SER FEITO
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