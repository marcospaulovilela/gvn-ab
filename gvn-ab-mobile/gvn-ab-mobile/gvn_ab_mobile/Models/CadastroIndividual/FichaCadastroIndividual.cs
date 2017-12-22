using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace gvn_ab_mobile.Models
{
    public class FichaCadastroIndividual : Helpers.ObservableObject
    {
        
        //Campo ID - Tipo long
        private long? _id;
        [PrimaryKey, AutoIncrement] //Chave Primária com incremento automático
        public long? Id
        {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }

        //Campo statusTermoRecusaCadastroIndividualAtencaoBasica - Tipo boolean
        private bool _statusTermoRecusaCadastroIndividualAtencaoBasica; //Obrigatório
        [NotNull]
        public bool StatusTermoRecusaCadastroIndividualAtencaoBasica
        {
            get { return this._statusTermoRecusaCadastroIndividualAtencaoBasica; }
            set { SetProperty(ref _statusTermoRecusaCadastroIndividualAtencaoBasica, value);  }
        }

        //Campo fichaAtualizada - Tipo boolean
        private bool _fichaAtualizada; //Obrigatório
        [NotNull]
        public bool FichaAtualizada
        {
            get { return this._fichaAtualizada; }
            set { SetProperty(ref _fichaAtualizada, value); }
        }

        //Campo tpCdsOrigem - Tipo Integer
        private int _tpCdsOrigem; //Obrigatório
        [NotNull, MaxLength(1)] //Mínimo 1; Máximo 1
        public int TpCdsOrigem
        {
            get { return this._tpCdsOrigem; }
            set { SetProperty(ref _tpCdsOrigem, value); }
        }

        //CAMPO ESTRANHO (CONDICIONAL?)
        //Campo uuid - Tipo string
        private string _uuid; //Condicional
        [MaxLength(44)] //Mínimo 36 caracteres; Máximo 44 caracteres
        public string Uuid
        {
            get { return this._uuid; }
            set { SetProperty(ref _uuid, value); }
        }

        //Campo uuidFichaOriginadora - Tipo string
        private string _uuidFichaOriginadora; //Obrigatório
        [NotNull, MaxLength(44)] //Mínimo 36 caracteres; Máximo 44 caracteres
        public string UuidFichaOriginadora
        {
            get { return this._uuidFichaOriginadora; }
            set { SetProperty(ref _uuidFichaOriginadora, value); }
        }

        //INÍCIO CONDIÇÕES DE SAÚDE

        //Campo descricaoCausalInternacaoEm12Meses - Tipo string
        private string _descricaoCausalInternacaoEm12Meses; //Condicional
        [MaxLength(100)] //Máximo 100 caracteres
        public string DescricaoCausalInternacaoEm12Meses
        {
            get { return this._descricaoCausalInternacaoEm12Meses; }
            set { SetProperty(ref _descricaoCausalInternacaoEm12Meses, value); }
        }

        //Campo descricaoOutraCondicao1 - Tipo string
        private string _descricaoOutraCondicao1; //Não Obrigatório
        [MaxLength(100)] //Máximo 100 caracteres
        public string DescricaoOutraCondicao1
        {
            get { return this._descricaoOutraCondicao1; }
            set { SetProperty(ref _descricaoOutraCondicao1, value); }
        }

        //Campo descricaoOutraCondicao2 - Tipo string
        private string _descricaoOutraCondicao2; //Não Obrigatório
        [MaxLength(100)] //Máximo 100 caracteres
        public string DescricaoOutraCondicao2
        {
            get { return this._descricaoOutraCondicao2; }
            set { SetProperty(ref _descricaoOutraCondicao2, value); }
        }

        //Campo descricaoOutraCondicao3 - Tipo string
        private string _descricaoOutraCondicao3; //Não Obrigatório
        [MaxLength(100)] //Máximo 100 caracteres
        public string DescricaoOutraCondicao3
        {
            get { return this._descricaoOutraCondicao3; }
            set { SetProperty(ref _descricaoOutraCondicao3, value); }
        }

        //Campo descricaoPlantasMedicinaisUsadas - Tipo string
        private string _descricaoPlantasMedicinaisUsadas; //Não Obrigatório
        [MaxLength(100)] //Máximo 100 caracteres
        public string DescricaoPlantasMedicinaisUsadas
        {
            get { return this._descricaoPlantasMedicinaisUsadas; }
            set { SetProperty(ref _descricaoPlantasMedicinaisUsadas, value); }
        }

        //Campo doencaCardiaca - Tipo List<Long>
        private List<long> _doencaCardiaca; //Condicional
        [MaxLength(3)] //Máximo 3 códigos
        public List<long> DoencaCardiaca
        {
            get { return this._doencaCardiaca; }
            set { SetProperty(ref _doencaCardiaca, value); }
        }

        //Campo doencaRespiratoria - Tipo List<Long>
        private List<long> _doencaRespiratoria; //Condicional
        [MaxLength(4)] //Máximo 4 códigos
        public List<long> DoencaRespiratoria
        {
            get { return this._doencaRespiratoria; }
            set { SetProperty(ref _doencaRespiratoria, value); }
        }

        //Campo doencaRins - Tipo List<Long>
        private List<long> _doencaRins; //Condicional
        [MaxLength(3)] //Máximo 3 códigos
        public List<long> DoencaRins
        {
            get { return this._doencaRins; }
            set { SetProperty(ref _doencaRins, value); }
        }

        //Campo maternidadeDeReferencia - Tipo string
        private string _maternidadeDeReferencia; //Não Obrigatório
        [MaxLength(100)] //Máximo 100 caracteres
        public string MaternidadeDeReferencia
        {
            get { return this._maternidadeDeReferencia; }
            set { SetProperty(ref _maternidadeDeReferencia, value); }
        }

        //Campo situacaoPeso - Tipo long
        private long _situacaoPeso; //Não Obrigatório
        public long SituacaoPeso
        {
            get { return this._situacaoPeso; }
            set { SetProperty(ref _situacaoPeso, value); }
        }

        //Campo statusEhDependenteAlcool - Tipo boolean
        private bool _statusEhDependenteAlcool; //Não Obrigatório
        public bool StatusEhDependenteAlcool
        {
            get { return this._statusEhDependenteAlcool; }
            set { SetProperty(ref _statusEhDependenteAlcool, value); }
        }

        //Campo statusEhDependenteOutrasDrogas - Tipo boolean
        private bool _statusEhDependenteOutrasDrogas; //Não Obrigatório
        public bool StatusEhDependenteOutrasDrogas
        {
            get { return this._statusEhDependenteOutrasDrogas; }
            set { SetProperty(ref _statusEhDependenteOutrasDrogas, value); }
        }

        //Campo statusEhFumante - Tipo boolean
        private bool _statusEhFumante; //Não Obrigatório
        public bool StatusEhFumante
        {
            get { return this._statusEhFumante; }
            set { SetProperty(ref _statusEhFumante, value); }
        }

        //Campo statusEhGestante - Tipo boolean
        private bool _statusEhGestante; //Não Obrigatório
        public bool StatusEhGestante
        {
            get { return this._statusEhGestante; }
            set { SetProperty(ref _statusEhGestante, value); }
        }

        //Campo statusEstaAcamado - Tipo boolean
        private bool _statusEstaAcamado; //Não Obrigatório
        public bool StatusEstaAcamado
        {
            get { return this._statusEstaAcamado; }
            set { SetProperty(ref _statusEstaAcamado, value); }
        }

        //Campo statusEstaDomiciliado - Tipo boolean
        private bool _statusEstaDomiciliado; //Não Obrigatório
        public bool StatusEstaDomiciliado
        {
            get { return this._statusEstaDomiciliado; }
            set { SetProperty(ref _statusEstaDomiciliado, value); }
        }

        //Campo statusTemDiabetes - Tipo boolean
        private bool _statusTemDiabetes; //Não Obrigatório
        public bool StatusTemDiabetes
        {
            get { return this._statusTemDiabetes; }
            set { SetProperty(ref _statusTemDiabetes, value); }
        }

        //Campo statusTemDoencaoRespiratoria - Tipo boolean
        private bool _statusTemDoencaoRespiratoria; //Não Obrigatório
        public bool StatusTemDoencaoRespiratoria
        {
            get { return this._statusTemDoencaoRespiratoria; }
            set { SetProperty(ref _statusTemDoencaoRespiratoria, value); }
        }

        //Campo statusTemHanseniase - Tipo boolean
        private bool _statusTemHanseniase; //Não Obrigatório
        public bool StatusTemHanseniase
        {
            get { return this._statusTemHanseniase; }
            set { SetProperty(ref _statusTemHanseniase, value); }
        }

        //Campo statusTemHipertensaoArterial - Tipo boolean
        private bool _statusTemHipertensaoArterial; //Não Obrigatório
        public bool StatusTemHipertensaoArterial
        {
            get { return this._statusTemHipertensaoArterial; }
            set { SetProperty(ref _statusTemHipertensaoArterial, value); }
        }

        //Campo statusTemTeveCancer - Tipo boolean
        private bool _statusTemTeveCancer; //Não Obrigatório
        public bool StatusTemTeveCancer
        {
            get { return this._statusTemTeveCancer; }
            set { SetProperty(ref _statusTemTeveCancer, value); }
        }

        //Campo statusTemTeveDoencasRins - Tipo boolean
        private bool _statusTemTeveDoencasRins; //Não Obrigatório
        public bool StatusTemTeveDoencasRins
        {
            get { return this._statusTemTeveDoencasRins; }
            set { SetProperty(ref _statusTemTeveDoencasRins, value); }
        }

        //Campo statusTemTuberculose - Tipo boolean
        private bool _statusTemTuberculose; //Não Obrigatório
        public bool StatusTemTuberculose
        {
            get { return this._statusTemTuberculose; }
            set { SetProperty(ref _statusTemTuberculose, value); }
        }

        //Campo statusTeveAvcDerrame - Tipo boolean
        private bool _statusTeveAvcDerrame; //Não Obrigatório
        public bool StatusTeveAvcDerrame
        {
            get { return this._statusTeveAvcDerrame; }
            set { SetProperty(ref _statusTeveAvcDerrame, value); }
        }

        //Campo statusTeveDoencaCardiaca - Tipo boolean
        private bool _statusTeveDoencaCardiaca; //Não Obrigatório
        public bool StatusTeveDoencaCardiaca
        {
            get { return this._statusTeveDoencaCardiaca; }
            set { SetProperty(ref _statusTeveDoencaCardiaca, value); }
        }

        //Campo statusTeveInfarto - Tipo boolean
        private bool _statusTeveInfarto; //Não Obrigatório
        public bool StatusTeveInfarto
        {
            get { return this._statusTeveInfarto; }
            set { SetProperty(ref _statusTeveInfarto, value); }
        }

        //Campo statusTeveInternadoem12Meses - Tipo boolean
        private bool _statusTeveInternadoem12Meses; //Não Obrigatório
        public bool StatusTeveInternadoem12Meses
        {
            get { return this._statusTeveInternadoem12Meses; }
            set { SetProperty(ref _statusTeveInternadoem12Meses, value); }
        }

        //Campo statusUsaOutrasPraticasIntegrativasOuComplementares - Tipo boolean
        private bool _statusUsaOutrasPraticasIntegrativasOuComplementares; //Não Obrigatório
        public bool StatusUsaOutrasPraticasIntegrativasOuComplementares
        {
            get { return this._statusUsaOutrasPraticasIntegrativasOuComplementares; }
            set { SetProperty(ref _statusUsaOutrasPraticasIntegrativasOuComplementares, value); }
        }

        //Campo statusUsaPlantasMedicinais - Tipo boolean
        private bool _statusUsaPlantasMedicinais; //Não Obrigatório
        public bool StatusUsaPlantasMedicinais
        {
            get { return this._statusUsaPlantasMedicinais; }
            set { SetProperty(ref _statusUsaPlantasMedicinais, value); }
        }


        //Campo statusDiagnosticoMental - Tipo boolean
        private bool _statusDiagnosticoMental; //Não Obrigatório
        public bool StatusDiagnosticoMental
        {
            get { return this._statusDiagnosticoMental; }
            set { SetProperty(ref _statusDiagnosticoMental, value); }
        }

        //FIM CONDIÇÕES DE SAÚDE

        //INÍCIO EM SITUAÇÃO DE RUA

        //Campo grauParentescoFamiliarFrequentado - Tipo string
        private string _grauParentescoFamiliarFrequentado; //Condicional
        [MaxLength(100)] //Máximo 100 caracteres
        public string GrauParentescoFamiliarFrequentado
        {
            get { return this._grauParentescoFamiliarFrequentado; }
            set { SetProperty(ref _grauParentescoFamiliarFrequentado, value); }
        }

        //Campo higienePessoalSituacaoRua - Tipo List<Long>
        private List<long> _higienePessoalSituacaoRua; //Condicional
        [MaxLength(4)] //Máximo 4 códigos
        public List<long> HigienePessoalSituacaoRua
        {
            get { return this._higienePessoalSituacaoRua; }
            set { SetProperty(ref _higienePessoalSituacaoRua, value); }
        }

        //Campo origemAlimentoSituacaoRua - Tipo List<Long>
        private List<long> _origemAlimentoSituacaoRua; //Não obrigatório
        [MaxLength(5)] //Máximo 5 códigos
        public List<long> OrigemAlimentoSituacaoRua
        {
            get { return this._origemAlimentoSituacaoRua; }
            set { SetProperty(ref _origemAlimentoSituacaoRua, value); }
        }

        //Campo outraInstituicaoQueAcompanha - Tipo string
        private string _outraInstituicaoQueAcompanha; //Não Obrigatório
        [MaxLength(100)] //Máximo 100 caracteres
        public string OutraInstituicaoQueAcompanha
        {
            get { return this._outraInstituicaoQueAcompanha; }
            set { SetProperty(ref _outraInstituicaoQueAcompanha, value); }
        }

        //Campo quantidadeAlimentacoesAoDiaSituacaoRua - Tipo long
        private long _quantidadeAlimentacoesAoDiaSituacaoRua; //Não Obrigatório
        public long QuantidadeAlimentacoesAoDiaSituacaoRua
        {
            get { return this._quantidadeAlimentacoesAoDiaSituacaoRua; }
            set { SetProperty(ref _quantidadeAlimentacoesAoDiaSituacaoRua, value); }
        }

        //FIM EM SITUAÇÃO DE RUA


        //INÍCIO IDENTIFICAÇÃO USUÁRIO CIDADÃO

        //Campo nomeSocial - Tipo string
        private string _nomeSocial; //Não Obrigatório
        [MaxLength(70)] //Máximo 70 caracteres
        public string NomeSocial
        {
            get { return this._nomeSocial; }
            set { SetProperty(ref _nomeSocial, value);  }
        }

        //Campo codigoIbgeMunicipioNascimento - Tipo string
        private string _codigoIbgeMunicipioNascimento; //Condicional
        [MaxLength(7)] //Mínimo 7 caracteres - Máximo 7 caracteres
        public string CodigoIbgeMunicipioNascimento
        {
            get { return this._codigoIbgeMunicipioNascimento; }
            set { SetProperty(ref _codigoIbgeMunicipioNascimento, value); }
        }

        //Campo dataNascimentoCidadao - Tipo long
        private long _dataNascimentoCidadao;  //Obrigatório
        [NotNull]
        public long DataNascimentoCidadao
        {
            get { return this._dataNascimentoCidadao; }
            set { SetProperty(ref _dataNascimentoCidadao, value); }
        }

        //Campo desconheceNomeMae - Tipo boolean
        private bool _desconheceNomeMae; //Não Obrigatório
        public bool DesconheceNomeMae
        {
            get { return this._desconheceNomeMae; }
            set { SetProperty(ref _desconheceNomeMae, value); }
        }

        //Campo emailCidadao - Tipo string
        private string _emailCidadao; //Não Obrigatório
        [MaxLength(100)] //Mínimo 6 caracteres; Máximo 100 caracteres
        public string EmailCidadao
        {
            get { return this._emailCidadao; }
            set { SetProperty(ref _emailCidadao, value); }
        }


        //Campo nacionalidadeCidadao - Tipo string
        private long _nacionalidadeCidadao; //Obrigatório
        [NotNull]
        public long NacionalidadeCidadao
        {
            get { return this._nacionalidadeCidadao; }
            set { SetProperty(ref _nacionalidadeCidadao, value); }
        }

        //Campo nomeCidadao - Tipo string
        private string _nomeCidadao; //Obrigatório
        [NotNull, MaxLength(70)] //Mínimo 3 caracteres; Máximo 70 caracteres
        public string NomeCidadao
        {
            get { return this._nomeCidadao; }
            set { SetProperty(ref _nomeCidadao, value); }
        }

        //Campo nomeMaeCidadao - Tipo string
        private string _nomeMaeCidadao; //Condicional
        [MaxLength(70)] //Mínimo 3 caracteres; Máximo 70 caracteres
        public string NomeMaeCidadao
        {
            get { return this._nomeMaeCidadao; }
            set { SetProperty(ref _nomeMaeCidadao, value); }
        }

        //Campo cnsCidadao - Tipo string
        private string _cnsCidadao; //Não Obrigatório
        [MaxLength(15)] //Mínimo 15 caracteres; Máximo 15 caracteres
        public string CnsCidadao
        {
            get { return this._cnsCidadao; }
            set { SetProperty(ref _cnsCidadao, value); }
        }

        //Campo cnsResponsavelFamiliar - Tipo string
        private string _cnsResponsavelFamiliar; //Não Obrigatório
        [MaxLength(15)] //Mínimo 15 caracteres; Máximo 15 caracteres
        public string CnsResponsavelFamiliar
        {
            get { return this._cnsResponsavelFamiliar; }
            set { SetProperty(ref _cnsResponsavelFamiliar, value); }
        }

        //Campo numeroNisPisPasep - Tipo string
        private string _numeroNisPisPasep; //Não Obrigatório
        [MaxLength(11)] //Mínimo 11 caracteres; Máximo 11 caracteres
        public string NumeroNisPisPasep
        {
            get { return this._numeroNisPisPasep; }
            set { SetProperty(ref _numeroNisPisPasep, value); }
        }

        //Campo paisNascimento - Tipo long
        private long _paisNascimento; //Condicional
        public long PaisNascimento
        {
            get { return this._paisNascimento; }
            set { SetProperty(ref _paisNascimento, value); }
        }

        //Campo racaCorCidadao - Tipo long
        private long _racaCorCidadao; 
        [NotNull] //Obrigatório
        public long RacaCorCidadao
        {
            get { return this._racaCorCidadao; }
            set { SetProperty(ref _racaCorCidadao, value); }
        }

        //Campo sexoCidadao - Tipo long
        private long _sexoCidadao;
        [NotNull] //Obrigatório
        public long SexoCidadao
        {
            get { return this._sexoCidadao; }
            set { SetProperty(ref _sexoCidadao, value); }
        }

        //Campo statusEhResponsavel - Tipo boolean
        private bool _statusEhResponsavel; //Não Obrigatório
        public bool StatusEhResponsavel
        {
            get { return this._statusEhResponsavel; }
            set { SetProperty(ref _statusEhResponsavel, value); }
        }

        //Campo etnia - Tipo long
        private long _etnia; //Condicional
        public long Etnia
        {
            get { return this._etnia; }
            set { SetProperty(ref _etnia, value); }
        }

        //Campo nomePaiCidadao - Tipo string
        private string _nomePaiCidadao; //Condicional
        [MaxLength(70)] //Mínimo 3 caracteres; Máximo 70 caracteres
        public string NomePaiCidadao
        {
            get { return this._nomePaiCidadao; }
            set { SetProperty(ref _nomePaiCidadao, value); }
        }

        //Campo desconheceNomePai - Tipo string
        private bool _desconheceNomePai; //Não Obrigatório
        public bool DesconheceNomePai
        {
            get { return this._desconheceNomePai; }
            set { SetProperty(ref _desconheceNomePai, value); }
        }

        //Campo dtNaturalizacao - Tipo long
        private long _dtNaturalizacao; //Condicional
        public long DtNaturalizacao
        {
            get { return this._dtNaturalizacao; }
            set { SetProperty(ref _dtNaturalizacao, value); }
        }

        //Campo portariaNaturalizacao - Tipo string
        private string _portariaNaturalizacao; //Condicional
        [MaxLength(16)] //Mínimo 0 caracteres; Máximo 16 caracteres
        public string PortariaNaturalizacao
        {
            get { return this._portariaNaturalizacao; }
            set { SetProperty(ref _portariaNaturalizacao, value); }
        }

        //Campo dtEntradaBrasil - Tipo long
        private long _dtEntradaBrasil; //Condicional
        public long DtEntradaBrasil
        {
            get { return this._dtEntradaBrasil; }
            set { SetProperty(ref _dtEntradaBrasil, value); }
        }

        //Campo microarea - Tipo string
        private string _microarea; //Condicional
        [MaxLength(2)] //Mínimo 2 caracteres; Máximo 2 caracteres
        public string Microarea
        {
            get { return this._microarea; }
            set { SetProperty(ref _microarea, value); }
        }

        //Campo stForaArea - Tipo boolean
        private bool _stForaArea; //Não Obrigatório
        public bool StForaArea
        {
            get { return this._stForaArea; }
            set { SetProperty(ref _stForaArea, value); }
        }

        //FIM IDENTIFICAÇÃO USUÁRIO CIDADÃO

        //INÍCIO INFORMAÇÕES SÓCIO DEMOGRÁFICAS

        //Campo deficienciasCidadao - Tipo List<Long>
        private List<long> _deficienciasCidadao; //Condicional
        [MaxLength(5)] //Mínimo 1 código; Máximo 5 códigos
        public List<long> DeficienciasCidadao
        {
            get { return this._deficienciasCidadao; }
            set { SetProperty(ref _deficienciasCidadao, value); }
        }

        //Campo grauInstrucaoCidadao - Tipo long
        private long _grauInstrucaoCidadao; //Não Obrigatório
        public long GrauInstrucaoCidadao
        {
            get { return this._grauInstrucaoCidadao; }
            set { SetProperty(ref _grauInstrucaoCidadao, value); }
        }

        //Campo ocupacaoCodigoCbo2002 - Tipo string
        private string _ocupacaoCodigoCbo2002; //Não Obrigatório
        [MaxLength(6)] //Mínimo 6 caracteres; //Máximo 6 caracteres
        public string OcupacaoCodigoCbo2002
        {
            get { return this._ocupacaoCodigoCbo2002; }
            set { SetProperty(ref _ocupacaoCodigoCbo2002, value); }
        }

        //Campo orientacaoSexualCidadao - Tipo long
        private long _orientacaoSexualCidadao; //Não Obrigatório
        public long OrientacaoSexualCidadao
        {
            get { return this._orientacaoSexualCidadao; }
            set { SetProperty(ref _orientacaoSexualCidadao, value); }
        }

        //Campo povoComunidadeTradicional - Tipo string
        private string _povoComunidadeTradicional; //Não Obrigatório
        [MaxLength(100)] //Máximo 100 caracteres
        public string PovoComunidadeTradicional
        {
            get { return this._povoComunidadeTradicional; }
            set { SetProperty(ref _povoComunidadeTradicional, value); }
        }

        //Campo relacaoParentescoCidadao - Tipo long
        private long _relacaoParentescoCidadao; //Não Obrigatório
        public long RelacaoParentescoCidadao
        {
            get { return this._relacaoParentescoCidadao; }
            set { SetProperty(ref _relacaoParentescoCidadao, value); }
        }

        //Campo situacaoMercadoTrabalhoCidadao - Tipo long
        private long _situacaoMercadoTrabalhoCidadao; //Não Obrigatório
        public long SituacaoMercadoTrabalhoCidadao
        {
            get { return this._situacaoMercadoTrabalhoCidadao; }
            set { SetProperty(ref _situacaoMercadoTrabalhoCidadao, value); }
        }

        //Campo statusDesejaInformarOrientacaoSexual - Tipo boolean
        private bool _statusDesejaInformarOrientacaoSexual; //Não Obrigatório
        public bool StatusDesejaInformarOrientacaoSexual
        {
            get { return this._statusDesejaInformarOrientacaoSexual; }
            set { SetProperty(ref _statusDesejaInformarOrientacaoSexual, value); }
        }

        //Campo statusFrequentaBenzedeira - Tipo boolean
        private bool _statusFrequentaBenzedeira; //Não Obrigatório
        public bool StatusFrequentaBenzedeira
        {
            get { return this._statusFrequentaBenzedeira; }
            set { SetProperty(ref _statusFrequentaBenzedeira, value); }
        }

        //Campo statusFrequentaEscola - Tipo boolean
        private bool _statusFrequentaEscola; //Obrigatório
        [NotNull]
        public bool StatusFrequentaEscola
        {
            get { return this._statusFrequentaEscola; }
            set { SetProperty(ref _statusFrequentaEscola, value); }
        }

        //Campo statusMembroPovoComunidadeTradicional - Tipo boolean
        private bool _statusMembroPovoComunidadeTradicional; //Não Obrigatório
        public bool StatusMembroPovoComunidadeTradicional
        {
            get { return this._statusMembroPovoComunidadeTradicional; }
            set { SetProperty(ref _statusMembroPovoComunidadeTradicional, value); }
        }

        //Campo statusParticipaGrupoComunitario - Tipo boolean
        private bool _statusParticipaGrupoComunitario; //Não Obrigatório
        public bool StatusParticipaGrupoComunitario
        {
            get { return this._statusParticipaGrupoComunitario; }
            set { SetProperty(ref _statusParticipaGrupoComunitario, value); }
        }

        //Campo statusPossuiPlanoSaudePrivado - Tipo boolean
        private bool _statusPossuiPlanoSaudePrivado; //Não Obrigatório
        public bool StatusPossuiPlanoSaudePrivado
        {
            get { return this._statusPossuiPlanoSaudePrivado; }
            set { SetProperty(ref _statusPossuiPlanoSaudePrivado, value); }
        }

        //Campo statusTemAlgumaDeficiencia - Tipo boolean
        private bool _statusTemAlgumaDeficiencia; //Obrigatório
        [NotNull]
        public bool StatusTemAlgumaDeficiencia
        {
            get { return this._statusTemAlgumaDeficiencia; }
            set { SetProperty(ref _statusTemAlgumaDeficiencia, value); }
        }

        //Campo identidadeGeneroCidadao - Tipo long
        private long _identidadeGeneroCidadao; //Não Obrigatório
        public long IdentidadeGeneroCidadao
        {
            get { return this._identidadeGeneroCidadao; }
            set { SetProperty(ref _identidadeGeneroCidadao, value); }
        }

        //Campo statusDesejaInformarIdentidadeGenero - Tipo boolean
        private bool _statusDesejaInformarIdentidadeGenero; //Não Obrigatório
        public bool StatusDesejaInformarIdentidadeGenero
        {
            get { return this._statusDesejaInformarIdentidadeGenero; }
            set { SetProperty(ref _statusDesejaInformarIdentidadeGenero, value); }
        }

        //Campo responsavelPorCrianca - Tipo List<Long>
        private List<long> _responsavelPorCrianca; //Não Obrigatório
        [MaxLength(6)] //Mínimo 1; Máximo 6
        public List<long> ResponsavelPorCrianca
        {
            get { return this._responsavelPorCrianca; }
            set { SetProperty(ref _responsavelPorCrianca, value); }
        }

        //FIM INFORMAÇÕES SÓCIO DEMOGRÁFICAS

        //INÍCIO SAÍDA CIDADÃO CADASTRO

        //Campo motivoSaidaCidadao - Tipo long
        private long _motivoSaidaCidadao; //Não Obrigatório
        public long MotivoSaidaCidadao
        {
            get { return this._motivoSaidaCidadao; }
            set { SetProperty(ref _motivoSaidaCidadao, value); }
        }

        //Campo dataObito - Tipo long
        private long _dataObito; //Condicional
        public long DataObito
        {
            get { return this._dataObito; }
            set { SetProperty(ref _dataObito, value); }
        }

        //CAMPO ESTRANHO (DATA REPETIDA?)
        //Campo numeroDO - Tipo string
        private string _numeroDO; //Condicional
        [MaxLength(9)] //Mínimo 9 caracteres; Máximo 9 caracteres
        public string NumeroDO
        {
            get { return this._numeroDO; }
            set { SetProperty(ref _numeroDO, value); }
        }

        //FIM SAÍDA CIDADÃO CADASTRO

        //CARDINALIDADE RELAÇÃO FICHA HEADER

        [OneToOne]
        public FichaHeader Header
        {
            get;
            set;
        }

        //

    }
}
