using System;
using System.Collections.Generic;

using SQLite;
using SQLiteNetExtensions.Attributes;

namespace gvn_ab_mobile.Models
{
    public class FichaCadastroIndividual : Helpers.ObservableObject
    {
        public FichaCadastroIndividual()
        {
            this.StatusSituacaoRua = true;
            this.DataObito = this.DtNaturalizacao = this.DtEntradaBrasil = this.DataNascimentoCidadao = DateTime.Now;
        }


        //Campo ID - Tipo long
        private long? _id;
        [PrimaryKey, AutoIncrement] //Chave Primária com incremento automático
        public long? Id
        {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }


        #region Condições de saude
        private string _descricaoCausaInternacaoEm12Meses; //Condicional
        /// <summary>
        /// Descrição da causa de internação do cidadão.
        /// Não deve ser preenchido se o campo statusTeveInternadoem12Meses = false.
        /// </summary>
        [MaxLength(100)]
        public string DescricaoCausaInternacaoEm12Meses
        {
            get { return this._descricaoCausaInternacaoEm12Meses; }
            set { SetProperty(ref _descricaoCausaInternacaoEm12Meses, value); }
        }

        private string _descricaoOutraCondicao1;
        /// <summary>
        /// Condição de saúde informada pelo cidadão.
        /// </summary>
        [MaxLength(100)]
        public string DescricaoOutraCondicao1
        {
            get { return this._descricaoOutraCondicao1; }
            set { SetProperty(ref _descricaoOutraCondicao1, value); }
        }

        private string _descricaoOutraCondicao2;
        /// <summary>
        /// Condição de saúde informada pelo cidadão.
        /// </summary>
        [MaxLength(100)]
        public string DescricaoOutraCondicao2
        {
            get { return this._descricaoOutraCondicao2; }
            set { SetProperty(ref _descricaoOutraCondicao2, value); }
        }

        private string _descricaoOutraCondicao3;
        /// <summary>
        /// Condição de saúde informada pelo cidadão.
        /// </summary>
        [MaxLength(100)]
        public string DescricaoOutraCondicao3
        {
            get { return this._descricaoOutraCondicao3; }
            set { SetProperty(ref _descricaoOutraCondicao3, value); }
        }

        private string _descricaoPlantasMedicinaisUsadas;
        /// <summary>
        /// Descrição das plantas medicinais utilizadas.
        /// Não deve ser preenchido se o campo statusUsaPlantasMedicinais = false.
        /// </summary>
        [MaxLength(100)]
        public string DescricaoPlantasMedicinaisUsadas
        {
            get { return this._descricaoPlantasMedicinaisUsadas; }
            set { SetProperty(ref _descricaoPlantasMedicinaisUsadas, value); }
        }

        private List<Models.DoencaCardiaca> _doencaCardiaca;
        /// <summary>
        /// Doenças cardíacas que o cidadão informou.
        /// Requerido preenchimento de pelo menos um item se o campo statusTeveDoencaCardiaca = true;
        /// Não deve ser preenchido se o campo statusTeveDoencaCardiaca = false.
        /// </summary>
        [OneToMany, MaxLength(3)]
        public List<Models.DoencaCardiaca> DoencaCardiaca
        {
            get { return this._doencaCardiaca; }
            set { SetProperty(ref _doencaCardiaca, value); }
        }

        private List<Models.DoencaRespiratoria> _doencaRespiratoria;
        /// <summary>
        /// Doenças respiratórias que o cidadão informou.
        /// Requerido preenchimento de pelo menos um item se o campo statusTemDoencaRespiratoria = true;
        /// Não deve ser preenchido o campo statusTemDoencaRespiratoria = false.
        /// </summary>
        [OneToMany, MaxLength(4)]
        public List<Models.DoencaRespiratoria> DoencaRespiratoria
        {
            get { return this._doencaRespiratoria; }
            set { SetProperty(ref _doencaRespiratoria, value); }
        }


        private List<Models.ProblemaRins> _doencaRins;
        /// <summary>
        /// Requerido preenchimento de pelo menos um item se o campo statusTemTeveDoencasRins = true;
        ///Não deve ser preenchido se o campo statusTemTeveDoencasRins = false
        /// </summary>
        [OneToMany, MaxLength(3)]
        public List<Models.ProblemaRins> DoencaRins
        {
            get { return this._doencaRins; }
            set { SetProperty(ref _doencaRins, value); }
        }


        private string _maternidadeDeReferencia;
        /// <summary>
        /// Nome da maternidade de referência.
        /// Não pode ser preenchido se o campo statusEhGestante = false.
        /// </summary>
        [MaxLength(100)]
        public string MaternidadeDeReferencia
        {
            get { return this._maternidadeDeReferencia; }
            set { SetProperty(ref _maternidadeDeReferencia, value); }
        }


        private long? SituacaoPesoId { get; set; }
        private Models.ConsideracaoPeso _situacaoPeso;
        /// <summary>
        /// //Situação referente ao peso corporal.
        /// </summary>
        [OneToOne("SituacaoPesoId")]
        public Models.ConsideracaoPeso SituacaoPeso
        {
            get { return this._situacaoPeso; }
            set { SetProperty(ref _situacaoPeso, value); }
        }

        private bool _statusEhDependenteAlcool;
        /// <summary>
        /// Marcador se o cidadão faz uso de álcool.
        /// </summary>
        public bool StatusEhDependenteAlcool
        {
            get { return this._statusEhDependenteAlcool; }
            set { SetProperty(ref _statusEhDependenteAlcool, value); }
        }

        private bool _statusEhDependenteOutrasDrogas;
        /// <summary>
        /// Marcador se o cidadão faz uso de outras drogas.
        /// </summary>
        public bool StatusEhDependenteOutrasDrogas
        {
            get { return this._statusEhDependenteOutrasDrogas; }
            set { SetProperty(ref _statusEhDependenteOutrasDrogas, value); }
        }

        private bool _statusEhFumante;
        /// <summary>
        /// Marcador se o cidadão é fumante.
        /// </summary>
        public bool StatusEhFumante
        {
            get { return this._statusEhFumante; }
            set { SetProperty(ref _statusEhFumante, value); }
        }

        private bool _statusEhGestante;
        /// <summary>
        /// Marcador se o cidadão é gestante.
        /// Não pode ser preenchido se:
        ///Campo sexoCidadao = 0 - Masculino;
        ///Campo dataNascimentoCidadao for menor que 9 anos ou maior que 60 anos a partir da dataAtendimento.
        /// </summary>
        public bool StatusEhGestante
        {
            get { return this._statusEhGestante; }
            set { SetProperty(ref _statusEhGestante, value); }
        }

        private bool _statusEstaAcamado;
        /// <summary>
        /// Marcador se o cidadão é acamado.
        /// </summary>
        public bool StatusEstaAcamado
        {
            get { return this._statusEstaAcamado; }
            set { SetProperty(ref _statusEstaAcamado, value); }
        }

        private bool _statusEstaDomiciliado;
        /// <summary>
        /// Marcador se o cidadão está domiciliado.
        /// </summary>
        public bool StatusEstaDomiciliado
        {
            get { return this._statusEstaDomiciliado; }
            set { SetProperty(ref _statusEstaDomiciliado, value); }
        }

        private bool _statusTemDiabetes;
        /// <summary>
        /// Marcador se o cidadão tem diabetes.
        /// </summary>
        public bool StatusTemDiabetes
        {
            get { return this._statusTemDiabetes; }
            set { SetProperty(ref _statusTemDiabetes, value); }
        }

        private bool _statusTemDoencaRespiratoria;
        /// <summary>
        /// Marcador se o cidadão tem doença respiratoria.
        /// </summary>
        public bool StatusTemDoencaRespiratoria
        {
            get { return this._statusTemDoencaRespiratoria; }
            set { SetProperty(ref _statusTemDoencaRespiratoria, value); }
        }

        private bool _statusTemHanseniase;
        /// <summary>
        /// Marcador se o cidadão tem hanseiase.
        /// </summary>
        public bool StatusTemHanseniase
        {
            get { return this._statusTemHanseniase; }
            set { SetProperty(ref _statusTemHanseniase, value); }
        }

        private bool _statusTemHipertensaoArterial;
        /// <summary>
        /// Marcador se o cidadão tem hipertensão arterial.
        /// </summary>
        public bool StatusTemHipertensaoArterial
        {
            get { return this._statusTemHipertensaoArterial; }
            set { SetProperty(ref _statusTemHipertensaoArterial, value); }
        }

        private bool _statusTemTeveCancer;
        /// <summary>
        /// Marcador se o cidadão teve cancer.
        /// </summary>
        public bool StatusTemTeveCancer
        {
            get { return this._statusTemTeveCancer; }
            set { SetProperty(ref _statusTemTeveCancer, value); }
        }

        private bool _statusTemTeveDoencasRins;
        /// <summary>
        /// Marcador se o cidadão teve doença nos rins.
        /// </summary>
        public bool StatusTemTeveDoencasRins
        {
            get { return this._statusTemTeveDoencasRins; }
            set { SetProperty(ref _statusTemTeveDoencasRins, value); }
        }

        private bool _statusTemTuberculose;
        /// <summary>
        /// Marcador se o cidadão tem tuberculose.
        /// </summary>
        public bool StatusTemTuberculose
        {
            get { return this._statusTemTuberculose; }
            set { SetProperty(ref _statusTemTuberculose, value); }
        }

        private bool _statusTeveAvcDerrame;
        /// <summary>
        /// Marcador se o cidadão teve AVC.
        /// </summary>
        public bool StatusTeveAvcDerrame
        {
            get { return this._statusTeveAvcDerrame; }
            set { SetProperty(ref _statusTeveAvcDerrame, value); }
        }

        private bool _statusTeveDoencaCardiaca;
        /// <summary>
        /// Marcador se o cidadão teve doenã cardiaca.
        /// </summary>
        public bool StatusTeveDoencaCardiaca
        {
            get { return this._statusTeveDoencaCardiaca; }
            set { SetProperty(ref _statusTeveDoencaCardiaca, value); }
        }

        private bool _statusTeveInfarto;
        /// <summary>
        /// Marcador se o cidadão teve infarto.
        /// </summary>
        public bool StatusTeveInfarto
        {
            get { return this._statusTeveInfarto; }
            set { SetProperty(ref _statusTeveInfarto, value); }
        }

        private bool _statusTeveInternadoem12Meses;
        /// <summary>
        /// Marcador se o cidadão estave instado em 12 meses.
        /// </summary>
        public bool StatusTeveInternadoem12Meses
        {
            get { return this._statusTeveInternadoem12Meses; }
            set { SetProperty(ref _statusTeveInternadoem12Meses, value); }
        }

        private bool _statusUsaOutrasPraticasIntegrativasOuComplementares;
        /// <summary>
        /// Marcador se o cidadão utiliza outras práticas integrativas complementares.
        /// </summary>
        public bool StatusUsaOutrasPraticasIntegrativasOuComplementares
        {
            get { return this._statusUsaOutrasPraticasIntegrativasOuComplementares; }
            set { SetProperty(ref _statusUsaOutrasPraticasIntegrativasOuComplementares, value); }
        }

        private bool _statusUsaPlantasMedicinais;
        /// <summary>
        /// Marcador se o cidadão utiliza plantas medicinais.
        /// </summary>
        public bool StatusUsaPlantasMedicinais
        {
            get { return this._statusUsaPlantasMedicinais; }
            set { SetProperty(ref _statusUsaPlantasMedicinais, value); }
        }

        private bool _statusDiagnosticoMental;
        /// <summary>
        /// Marcador que indica se o cidadão teve diagnóstico de problema mental.
        /// </summary>
        public bool StatusDiagnosticoMental
        {
            get { return this._statusDiagnosticoMental; }
            set { SetProperty(ref _statusDiagnosticoMental, value); }
        }
        #endregion

        #region Situação de rua
        private string _grauParentescoFamiliarFrequentado;
        /// <summary>
        /// Grau de parentesco do familiar que frequenta.
        /// Não pode ser preenchido se o campo statusSituacaoRua = false;
        /// Não pode ser preenchido se o campo statusVisitaFamiliarFrequentemente = false
        /// </summary>
        [MaxLength(100)]
        public string GrauParentescoFamiliarFrequentado
        {
            get { return this._grauParentescoFamiliarFrequentado; }
            set { SetProperty(ref _grauParentescoFamiliarFrequentado, value); }
        }

        private List<Models.AcessoHigiene> _higienePessoalSituacaoRua;
        /// <summary>
        /// Condições de higiene que o cidadão tem acesso.
        /// Não pode ser preenchido se o campo statusSituacaoRua = false;
        /// Requerido preenchimento de pelo menos um item se o campo statusTemAcessoHigienePessoalSituacaoRua = true.
        /// </summary>
        [OneToMany, MaxLength(4)]
        public List<Models.AcessoHigiene> HigienePessoalSituacaoRua
        {
            get { return this._higienePessoalSituacaoRua; }
            set { SetProperty(ref _higienePessoalSituacaoRua, value); }
        }

        private List<Models.OrigemAlimentacao> _origemAlimentoSituacaoRua;
        /// <summary>
        /// Origem da alimentação do cidadão em situação de rua.
        /// Não pode ser preenchido se o campo statusSituacaoRua = false.
        /// </summary>
        [OneToMany, MaxLength(5)]
        public List<Models.OrigemAlimentacao> OrigemAlimentoSituacaoRua
        {
            get { return this._origemAlimentoSituacaoRua; }
            set { SetProperty(ref _origemAlimentoSituacaoRua, value); }
        }

        private string _outraInstituicaoQueAcompanha;
        /// <summary>
        /// Nome de outra instituição que acompanha o cidadão.
        /// Não pode ser preenchido se o campo statusSituacaoRua = false;
        /// Não pode ser preenchido se o campo statusAcompanhadoPorOutraInstituição = false.
        /// </summary>
        [MaxLength(100)]
        public string OutraInstituicaoQueAcompanha
        {
            get { return this._outraInstituicaoQueAcompanha; }
            set { SetProperty(ref _outraInstituicaoQueAcompanha, value); }
        }

        public long? QuantidadeAlimentacoesAoDiaSituacaoRuaId { get; set; }
        private Models.QuantasVezesAlimentacao _quantidadeAlimentacoesAoDiaSituacaoRua;
        /// <summary>
        /// Código da quantidade de vezes que o cidadão se alimenta por dia.
        /// Não pode ser preenchido se o campo statusSituacaoRua = false.
        /// </summary>
        [OneToOne("QuantidadeAlimentacoesAoDiaSituacaoRuaId")]
        public Models.QuantasVezesAlimentacao QuantidadeAlimentacoesAoDiaSituacaoRua
        {
            get { return this._quantidadeAlimentacoesAoDiaSituacaoRua; }
            set { SetProperty(ref _quantidadeAlimentacoesAoDiaSituacaoRua, value); }
        }

        private bool _statusAcompanhadoPorOutraInstituicao;
        /// <summary>
        /// Marcador que indica se o cidadão é acompanhado por outra instituição.
        /// Não pode ser preenchido se o campo statusSituacaoRua = false.
        /// </summary>
        public bool StatusAcompanhadoPorOutraInstituicao
        {
            get { return this._statusAcompanhadoPorOutraInstituicao; }
            set { SetProperty(ref _statusAcompanhadoPorOutraInstituicao, value); }
        }

        private bool _statusPossuiReferenciaFamiliar;
        /// <summary>
        /// Marcador que indica se o cidadão possuiu alguma referência familiar.
        /// Não pode ser preenchido se o campo statusSituacaoRua = false.
        /// </summary>
        public bool StatusPossuiReferenciaFamiliar
        {
            get { return this._statusPossuiReferenciaFamiliar; }
            set { SetProperty(ref _statusPossuiReferenciaFamiliar, value); }
        }

        private bool _statusRecebeBeneficio;
        /// <summary>
        /// Marcador que indica se o cidadão recebe algum benefício.
        /// Não pode ser preenchido se o campo statusSituacaoRua = false.
        /// </summary>
        public bool StatusRecebeBeneficio
        {
            get { return this._statusRecebeBeneficio; }
            set { SetProperty(ref _statusRecebeBeneficio, value); }
        }

        private bool _statusSituacaoRua;
        /// <summary>
        /// Marcador que indica se o cidadão está em situação de rua.
        /// </summary>
        [NotNull]
        public bool StatusSituacaoRua
        {
            get { return this._statusSituacaoRua; }
            set { SetProperty(ref _statusSituacaoRua, value); }
        }

        private bool _statusTemAcessoHigienePessoalSituacaoRua;
        /// <summary>
        /// Marcador que indica se o cidadão tem acesso a higiene pessoal.
        /// Não pode ser preenchido se o campo statusSituacaoRua = false
        /// </summary>
        public bool StatusTemAcessoHigienePessoalSituacaoRua
        {
            get { return this._statusTemAcessoHigienePessoalSituacaoRua; }
            set { SetProperty(ref _statusTemAcessoHigienePessoalSituacaoRua, value); }
        }

        private bool _statusVisitaFamiliarFrequentemente;
        /// <summary>
        /// Marcador que indica se o cidadão visita algum familiar frequentemente.
        /// Não pode ser preenchido se o campo statusSituacaoRua = false.
        /// </summary>
        public bool StatusVisitaFamiliarFrequentemente
        {
            get { return this._statusVisitaFamiliarFrequentemente; }
            set { SetProperty(ref _statusVisitaFamiliarFrequentemente, value); }
        }

        public long? TempoSituacaoRuaId { get; set; }
        private Models.TempoSituacaoDeRua _tempoSituacaoRua;
        /// <summary>
        /// Código do tempo que o cidadão está em situação de rua.
        /// Não pode ser preenchido se o campo statusSituacaoRua = false.
        /// </summary>
        [OneToOne("TempoSituacaoRuaId")]
        public Models.TempoSituacaoDeRua TempoSituacaoRua
        {
            get { return this._tempoSituacaoRua; }
            set { SetProperty(ref _tempoSituacaoRua, value); }
        }
        #endregion

        #region Identificacao do usuário cidadao
        private string _nomeSocial;
        /// <summary>
        /// Nome social do cidadão.
        /// Somente texto e apóstrofo 
        /// </summary>
        [MaxLength(70)]
        public string NomeSocial
        {
            get { return this._nomeSocial; }
            set { SetProperty(ref _nomeSocial, value); }
        }


        public long? MunicipioNascimentoId { get; set; }
        private Models.Municipio Municipio;
        /// <summary>
        /// Código IBGE do município.
        /// Só pode ser preenchido se o campo nacionalidadeCidadao = 1 (Brasileiro). Neste caso é de preenchimento obrigatório.
        /// </summary>
        [OneToOne("MunicipioNascimentoId")]
        public Models.Municipio MunicipioNascimento
        {
            get { return this.Municipio; }
            set { SetProperty(ref Municipio, value); }
        }

        private DateTime _dataNascimentoCidadao;
        /// <summary>
        /// Data de nascimento do cidadão no formato epoch time.
        /// Não pode ser posterior a dataAtendimento ou mais anterior que 130 anos a partir da dataAtendimento.
        /// </summary>
        [NotNull]
        public DateTime DataNascimentoCidadao
        {
            get { return this._dataNascimentoCidadao; }
            set { SetProperty(ref _dataNascimentoCidadao, value); }
        }

        private bool _desconheceNomeMae;
        /// <summary>
        /// Marcador que indica que o cidadão desconhece o nome da mãe
        /// </summary>
        public bool DesconheceNomeMae
        {
            get { return this._desconheceNomeMae; }
            set { SetProperty(ref _desconheceNomeMae, value); }
        }

        private string _emailCidadao;
        /// <summary>
        /// E-mail do cidadão.
        /// Requerido seguir o padrão endereco@domínio.extensao
        /// </summary>
        [MaxLength(100)]
        public string EmailCidadao
        {
            get { return this._emailCidadao; }
            set { SetProperty(ref _emailCidadao, value); }
        }

        public long? NacionalidadeCidadaoId { get; set; }
        private Models.Nacionalidade _nacionalidadeCidadao;
        /// <summary>
        /// Indica se o cidadão é brasileiro, naturalizado ou estrangeiro.
        /// </summary>
        [OneToOne("NacionalidadeCidadaoId"), NotNull]
        public Models.Nacionalidade NacionalidadeCidadao
        {
            get { return this._nacionalidadeCidadao; }
            set { SetProperty(ref _nacionalidadeCidadao, value); }
        }

        private string _nomeCidadao;
        /// <summary>
        /// Nome completo do cidadão.
        /// As regras de validação de um nome estão descritas em Validar nome.
        /// </summary>
        [NotNull, MaxLength(70)]
        public string NomeCidadao
        {
            get { return this._nomeCidadao; }
            set { SetProperty(ref _nomeCidadao, value); }
        }

        private string _nomeMaeCidadao;
        /// <summary>
        /// Nome da mãe do cidadão.
        /// As regras de validação de um nome estão descritas em Validar nome;
        /// Não deve ser preenchido se o campo desconheceNomeMae = true.
        /// </summary>
        [MaxLength(70)]
        public string NomeMaeCidadao
        {
            get { return this._nomeMaeCidadao; }
            set { SetProperty(ref _nomeMaeCidadao, value); }
        }

        private string _cnsCidadao;
        /// <summary>
        /// CNS do cidadão.
        /// Validado por algoritmo.
        /// </summary>
        [MaxLength(15)]
        public string CnsCidadao
        {
            get { return this._cnsCidadao; }
            set { SetProperty(ref _cnsCidadao, value); }
        }

        private string _cnsResponsavelFamiliar;
        /// <summary>
        /// CNS do responsável do cidadão.
        /// Validado por algoritmo;
        /// Só pode ser preenchido se o campo statusEhResponsavel = false.
        /// </summary>
        [MaxLength(15)]
        public string CnsResponsavelFamiliar
        {
            get { return this._cnsResponsavelFamiliar; }
            set { SetProperty(ref _cnsResponsavelFamiliar, value); }
        }

        private string _telefoneCelular;
        /// <summary>
        /// Número de celular do cidadão.
        /// Apenas números.
        /// </summary>
        [MaxLength(11)]
        public string TelefoneCelular
        {
            get { return this._telefoneCelular; }
            set { SetProperty(ref _telefoneCelular, value); }
        }

        private string _numeroNisPisPasep;
        /// <summary>
        /// Número do NIS (PIS / PASEP) do cidadão.
        /// Apenas números.
        /// </summary>
        [MaxLength(11)]
        public string NumeroNisPisPasep
        {
            get { return this._numeroNisPisPasep; }
            set { SetProperty(ref _numeroNisPisPasep, value); }
        }

        public long? PaisNascimentoId { get; set; }
        private Models.Pais _paisNascimento;
        /// <summary>
        /// Código do país de nascimento do cidadão.
        /// Só pode ser preenchido se o campo nacionalidadeCidadao = 3(Estrangeiro).Neste caso o preenchimento é obrigatório;
        /// Se o campo nacionalidadeCidadao for igual a 1 (Brasileira), este campo deve ser preenchido com 31 (BRASIL).
        /// </summary>
        [OneToOne("PaisNascimentoId")]
        public Models.Pais PaisNascimento
        {
            get { return this._paisNascimento; }
            set { SetProperty(ref _paisNascimento, value); }
        }

        public long? RacaCorCidadaoId { get; set; }
        private Models.RacaCor _racaCorCidadao;
        /// <summary>
        /// Raça / cor do cidadão.
        /// </summary>
        [OneToOne("RacaCorCidadaoId"), NotNull]
        public Models.RacaCor RacaCorCidadao
        {
            get { return this._racaCorCidadao; }
            set { SetProperty(ref _racaCorCidadao, value); }
        }

        public long? SexoCidadaoId { get; set; }
        private Models.Sexo _sexoCidadao;
        /// <summary>
        /// Sexo do cidadão.
        /// </summary>
        [OneToOne("SexoCidadaoId"), NotNull]
        public Models.Sexo SexoCidadao
        {
            get { return this._sexoCidadao; }
            set { SetProperty(ref _sexoCidadao, value); }
        }

        private bool _statusEhResponsavel;
        /// <summary>
        /// Marcador que indica se o cidadão é responsável familiar.
        /// </summary>
        public bool StatusEhResponsavel
        {
            get { return this._statusEhResponsavel; }
            set { SetProperty(ref _statusEhResponsavel, value); }
        }


        public long? EtniaId { get; set; }
        private Models.Etnia _etnia;
        /// <summary>
        /// Etnia do cidadão.
        /// Só deve ser preenchido se o campo racaCorCidadao = 5. Neste caso o preenchimento é obrigatório.
        /// </summary>
        [OneToOne("EtniaId")]
        public Models.Etnia Etnia
        {
            get { return this._etnia; }
            set { SetProperty(ref _etnia, value); }
        }

        private string _nomePaiCidadao;
        /// <summary>
        /// Nome do pai do cidadão.
        /// As regras de validação de um nome estão descritas em Validar nome;
        /// Não deve ser preenchido se o campo desconheceNomePai = true.Caso contrário, o preenchimento é obrigatório
        /// </summary>
        [MaxLength(70)]
        public string NomePaiCidadao
        {
            get { return this._nomePaiCidadao; }
            set { SetProperty(ref _nomePaiCidadao, value); }
        }

        private bool _desconheceNomePai;
        /// <summary>
        /// Marcador que indica que o cidadão desconhece o nome do pai.
        /// </summary>
        public bool DesconheceNomePai
        {
            get { return this._desconheceNomePai; }
            set { SetProperty(ref _desconheceNomePai, value); }
        }

        private DateTime? _dtNaturalizacao;
        /// <summary>
        /// Data de naturalização do cidadão no formato epoch time.
        /// Só deve ser preenchido se o campo nacionalidadeCidadao = 2.Neste caso, é de preenchimento obrigatório;
        /// Não pode ser posterior a dataAtendimento;
        /// Não pode ser anterior a dataNascimentoCidadao.
        /// </summary>
        public DateTime? DtNaturalizacao
        {
            get { return this._dtNaturalizacao; }
            set { SetProperty(ref _dtNaturalizacao, value); }
        }

        private string _portariaNaturalizacao;
        /// <summary>
        /// Portaria de naturalização do cidadão.
        /// Só deve ser preenchido se o campo nacionalidadeCidadao = 2. Neste caso o preenchimento é obrigatório.
        /// </summary>
        [MaxLength(16)]
        public string PortariaNaturalizacao
        {
            get { return this._portariaNaturalizacao; }
            set { SetProperty(ref _portariaNaturalizacao, value); }
        }

        private DateTime? _dtEntradaBrasil;
        /// <summary>
        /// Data em que o cidadão entrou no Brasil. 
        /// Só deve ser preenchido se o campo nacionalidadeCidadao = 3.Neste caso o preenchimento é obrigatório;
        /// Não pode ser posterior a dataAtendimento;
        /// Não pode ser anterior a dataNascimentoCidadao.
        /// </summary>
        public DateTime? DtEntradaBrasil
        {
            get { return this._dtEntradaBrasil; }
            set { SetProperty(ref _dtEntradaBrasil, value); }
        }

        private string _microarea;
        /// <summary>
        /// Microárea na qual o cidadão se encontra.
        /// Não deve ser preenchido se o campo stForaArea = true. Caso contrário, o preenchimento é obrigatório.
        /// </summary>
        [MaxLength(2)]
        public string Microarea
        {
            get { return this._microarea; }
            set { SetProperty(ref _microarea, value); }
        }

        private bool _stForaArea;
        /// <summary>
        /// Marcador que indica que o cidadão está fora da área.
        /// </summary>
        public bool StForaArea
        {
            get { return this._stForaArea; }
            set { SetProperty(ref _stForaArea, value); }
        }
        #endregion

        #region Informações socio demograficas
        private List<Models.DeficienciaCidadao> _deficienciasCidadao;
        /// <summary>
        /// Deficiências que o cidadão possui.
        /// Requerido preenchimento de pelo menos um item se o campo statusTemAlgumaDeficiencia = true;
        /// Não deve ser preenchido se o campo statusTemAlgumaDeficiencia = false.
        /// </summary>
        [OneToMany, MaxLength(5)]
        public List<Models.DeficienciaCidadao> DeficienciasCidadao
        {
            get { return this._deficienciasCidadao; }
            set { SetProperty(ref _deficienciasCidadao, value); }
        }

        public long? GrauInstrucaoCidadaoId { get; set; }
        private Models.CursoMaisElevado _grauInstrucaoCidadao;
        /// <summary>
        /// Curso mais elevado que o cidadão frequenta ou frequentou.
        /// </summary>
        [OneToOne("GrauInstrucaoCidadaoId")]
        public Models.CursoMaisElevado GrauInstrucaoCidadao
        {
            get { return this._grauInstrucaoCidadao; }
            set { SetProperty(ref _grauInstrucaoCidadao, value); }
        }

        public string OcupacaoId { get; set; }
        private Models.Ocupacao ocupacao;
        /// <summary>
        /// Código do CBO que representa a ocupação do cidadão.
        /// Deve ser um código de CBO válido.
        /// </summary>
        [OneToOne("OcupacaoId")]
        public Models.Ocupacao Ocupacao
        {
            get { return this.ocupacao; }
            set { SetProperty(ref ocupacao, value); }
        }

        public long? OrientacaoSexualCidadaoId { get; set; }
        private Models.OrientacaoSexual _orientacaoSexualCidadao;
        /// <summary>
        /// Orientação sexual informada pelo cidadão. 
        /// Não pode ser preenchido se o campo statusDesejaInformarOrientacaoSexual = false
        /// </summary>
        [OneToOne("OrientacaoSexualCidadaoId")]
        public Models.OrientacaoSexual OrientacaoSexualCidadao
        {
            get { return this._orientacaoSexualCidadao; }
            set { SetProperty(ref _orientacaoSexualCidadao, value); }
        }

        private string _povoComunidadeTradicional;
        /// <summary>
        /// Nome da comunidade tradicional que o cidadão pertence.
        /// Não deve ser preenchido se o campo statusMembroPovoComunidadeTradicional = false.
        /// </summary>
        [MaxLength(100)]
        public string PovoComunidadeTradicional
        {
            get { return this._povoComunidadeTradicional; }
            set { SetProperty(ref _povoComunidadeTradicional, value); }
        }

        public long? RelacaoParentescoCidadaoId { get; set; }
        private Models.RelacaoParentesco _relacaoParentescoCidadao;
        /// <summary>
        /// Código da relação de parentesco com o responsável familiar.
        /// Só pode ser preenchido se o campo statusEhResponsavel = false.
        /// </summary>
        [OneToOne("RelacaoParentescoCidadaoId")]
        public Models.RelacaoParentesco RelacaoParentescoCidadao
        {
            get { return this._relacaoParentescoCidadao; }
            set { SetProperty(ref _relacaoParentescoCidadao, value); }
        }

        public long? SituacaoMercadoTrabalhoCidadaoId { get; set; }
        private Models.SituacaoMercadoTrabalho _situacaoMercadoTrabalhoCidadao;
        /// <summary>
        /// Código da situação do cidadão no mercado de trabalho.
        /// </summary>
        [OneToOne("SituacaoMercadoTrabalhoCidadaoId")]
        public Models.SituacaoMercadoTrabalho SituacaoMercadoTrabalhoCidadao
        {
            get { return this._situacaoMercadoTrabalhoCidadao; }
            set { SetProperty(ref _situacaoMercadoTrabalhoCidadao, value); }
        }

        private bool _statusDesejaInformarOrientacaoSexual;
        /// <summary>
        /// Marcador que indica se o cidadão deseja informar sua orientação sexual.
        /// </summary>
        public bool StatusDesejaInformarOrientacaoSexual
        {
            get { return this._statusDesejaInformarOrientacaoSexual; }
            set { SetProperty(ref _statusDesejaInformarOrientacaoSexual, value); }
        }

        private bool _statusFrequentaBenzedeira;
        /// <summary>
        /// Marcador que indica se o cidadão frequenta cuidador tradicional.
        /// </summary>
        public bool StatusFrequentaBenzedeira
        {
            get { return this._statusFrequentaBenzedeira; }
            set { SetProperty(ref _statusFrequentaBenzedeira, value); }
        }

        private bool _statusFrequentaEscola;
        /// <summary>
        /// Marcador que indica se o cidadão frequenta escola ou creche.
        /// </summary>
        [NotNull]
        public bool StatusFrequentaEscola
        {
            get { return this._statusFrequentaEscola; }
            set { SetProperty(ref _statusFrequentaEscola, value); }
        }

        private bool _statusMembroPovoComunidadeTradicional;
        /// <summary>
        /// Marcador que indica se o cidadão é membro de um povo ou comunidade tradicional.
        /// </summary>
        public bool StatusMembroPovoComunidadeTradicional
        {
            get { return this._statusMembroPovoComunidadeTradicional; }
            set { SetProperty(ref _statusMembroPovoComunidadeTradicional, value); }
        }

        private bool _statusParticipaGrupoComunitario;
        /// <summary>
        /// Marcador que indica se o cidadão participa de algum grupo comunitário.
        /// </summary>
        public bool StatusParticipaGrupoComunitario
        {
            get { return this._statusParticipaGrupoComunitario; }
            set { SetProperty(ref _statusParticipaGrupoComunitario, value); }
        }

        private bool _statusPossuiPlanoSaudePrivado;
        /// <summary>
        /// Marcador que indica se o cidadão possui plano de saúde privado.
        /// </summary>
        public bool StatusPossuiPlanoSaudePrivado
        {
            get { return this._statusPossuiPlanoSaudePrivado; }
            set { SetProperty(ref _statusPossuiPlanoSaudePrivado, value); }
        }

        private bool _statusTemAlgumaDeficiencia; //Obrigatório
        /// <summary>
        /// Marcador que indica se cidadão tem alguma deficiência.
        /// </summary>
        [NotNull]
        public bool StatusTemAlgumaDeficiencia
        {
            get { return this._statusTemAlgumaDeficiencia; }
            set { SetProperty(ref _statusTemAlgumaDeficiencia, value); }
        }

        public long? IdentidadeGeneroCidadaoId { get; set; }
        private Models.IdentidadeGeneroCidadao _identidadeGeneroCidadao;
        /// <summary>
        /// Identidade de gênero informada pelo cidadão. 
        /// Não pode ser preenchido se o campo statusDesejaInformarIdentidadeGenero = false.
        /// </summary>
        [OneToOne("IdentidadeGeneroCidadaoId")]
        public Models.IdentidadeGeneroCidadao IdentidadeGeneroCidadao
        {
            get { return this._identidadeGeneroCidadao; }
            set { SetProperty(ref _identidadeGeneroCidadao, value); }
        }

        private bool _statusDesejaInformarIdentidadeGenero;
        /// <summary>
        /// Marcador que indica se o cidadão deseja informar sua identidade de gênero.
        /// </summary>
        public bool StatusDesejaInformarIdentidadeGenero
        {
            get { return this._statusDesejaInformarIdentidadeGenero; }
            set { SetProperty(ref _statusDesejaInformarIdentidadeGenero, value); }
        }

        private List<Models.ResponsavelCrianca> _responsavelPorCrianca;
        /// <summary>
        /// Código do responsável por crianças de até 9 anos.
        /// Não pode ser preenchido se a dataNascimentoCidadao for anterior ou igual a 10 anos a partir da dataAtendimento.
        /// </summary>
        [OneToMany, MaxLength(6)]
        public List<Models.ResponsavelCrianca> ResponsavelPorCrianca
        {
            get { return this._responsavelPorCrianca; }
            set { SetProperty(ref _responsavelPorCrianca, value); }
        }
        #endregion

        #region Saida cidadão do cadastro
        public long? MotivoSaidaCidadaoId { get; set; }
        private Models.MotivoSaida _motivoSaidaCidadao;
        /// <summary>
        /// Motivo da saída do cidadão do cadastro.
        /// </summary>
        [OneToOne("MotivoSaidaCidadaoId")]
        public Models.MotivoSaida MotivoSaidaCidadao
        {
            get { return this._motivoSaidaCidadao; }
            set { SetProperty(ref _motivoSaidaCidadao, value); }
        }

        private DateTime? _dataObito;
        /// <summary>
        /// Dataa de óbito do cidadão no formato epoch time.
        /// Só pode ser preenchido se o campo motivoSaidaCidadao = 135. Neste caso o preenchimento é obrigatório.
        /// </summary>
        public DateTime? DataObito
        {
            get { return this._dataObito; }
            set { SetProperty(ref _dataObito, value); }
        }

        private string _numeroDO;
        /// <summary>
        /// Data de óbito do cidadão no formato epoch time.
        /// Só pode ser preenchido se o campo motivoSaidaCidadao = 135.
        /// </summary>
        [MaxLength(9)]
        public string NumeroDO
        {
            get { return this._numeroDO; }
            set { SetProperty(ref _numeroDO, value); }
        }
        #endregion

        private bool _statusTermoRecusaCadastroIndividualAtencaoBasica;
        /// <summary>
        /// Marcador que indica se o termo de recusa foi assinalado.
        /// </summary>
        [NotNull]
        public bool StatusTermoRecusaCadastroIndividualAtencaoBasica
        {
            get { return this._statusTermoRecusaCadastroIndividualAtencaoBasica; }
            set { SetProperty(ref _statusTermoRecusaCadastroIndividualAtencaoBasica, value); }
        }

        private bool _fichaAtualizada;
        /// <summary>
        /// 
        /// </summary>
        [NotNull]
        public bool FichaAtualizada
        {
            get { return this._fichaAtualizada; }
            set { SetProperty(ref _fichaAtualizada, value); }
        }

        /// <summary>
        /// Tipo de origem dos dados do registro.
        /// </summary>
        [NotNull, MaxLength(1)]
        public int TpCdsOrigem { get; } = 3;

        private string _uuid;
        /// <summary>
        /// Código UUID para identificar a ficha na base de dados nacional.
        /// É recomendado concatenar o CNES na frente do UUID, de modo que os 7 dígitos (CNES) + 1 de hífen somados aos 36 (32 caracteres + 4 hífen) do UUID são a limitação de 44 bytes do campo. Formato canônico.
        /// </summary>
        [MaxLength(44)]
        public string Uuid
        {
            get { return this._uuid; }
            set { SetProperty(ref _uuid, value); }
        }

        private string _uuidFichaOriginadora;
        /// <summary>
        /// Código UUID para identificar a ficha que deu origem ao cadastro do registro.
        ///  Se for uma ficha de atualização, deve ser preenchido com o UUID da ficha que deu origem ao registro. Se for a ficha de cadastro, este campo deve ser igual ao campo uuid.
        /// </summary>
        [MaxLength(44)]
        public string UuidFichaOriginadora
        {
            get { return this._uuidFichaOriginadora; }
            set { SetProperty(ref _uuidFichaOriginadora, value); }
        }

        public long? HeaderId { get; set; }
        private FichaUnicaLotacaoHeader _header;
        [OneToOne("HeaderId")]
        public FichaUnicaLotacaoHeader Header
        {
            get { return this._header; }
            set { SetProperty(ref _header, value); }
        }
        //

        // Assinatura Termo de Recusa

        //Campo AssinaturaBase64 - Tipo String
        private string _assinaturaBase64;
        public string AssinaturaBase64
        {
            get { return this._assinaturaBase64; }
            set { SetProperty(ref _assinaturaBase64, value); }
        }

        //

        public override string ToString()
        {
            return $"Ficha {this.Id}";
        }

    }
}
