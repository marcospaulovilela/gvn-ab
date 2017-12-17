using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;

namespace gvn_ab_mobile.Models
{
    class FichaCadastroDomiciliarTerritorial : Helpers.ObservableObject
    {

        //Campo ID - Tipo long
        private long? _id;
        [PrimaryKey, AutoIncrement] //Chave Primária com incremento automático
        public long? Id
        {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }

        //Campo statusTermoRecusa - Tipo bool
        private bool _statusTermoRecusa; //Obrigatório
        [NotNull]
        public bool StatusTermoRecusa
        {
            get { return this._statusTermoRecusa; }
            set { SetProperty(ref _statusTermoRecusa, value); }
        }

        //Campo fichaAtualizada - Tipo boolean
        private bool _fichaAtualizada; //Obrigatório
        [NotNull]
        public bool FichaAtualizada
        {
            get { return this._fichaAtualizada; }
            set { SetProperty(ref _fichaAtualizada, value); }
        }

        //Campo animaisNoDomicilio - Tipo List<Long>
        private List<long> _animaisNoDomicilio; //Condicional
        [MaxLength(4)] //Máximo 4 códigos
        public List<long> AnimaisNoDomicilio
        {
            get { return this._animaisNoDomicilio; }
            set { SetProperty(ref _animaisNoDomicilio, value); }
        }

        //Campo stAnimaisNoDomicilio - Tipo boolean
        private bool _stAnimaisNoDomicilio; //Condicional
        public bool StAnimaisNoDomicilio
        {
            get { return this._stAnimaisNoDomicilio; }
            set { SetProperty(ref _stAnimaisNoDomicilio, value); }
        }

        //Campo quantosAnimaisNoDomicilio - Tipo string
        private string _quantosAnimaisNoDomicilio; //Condicional
        [MaxLength(2)] //Máximo 2 caracteres
        public string QuantosAnimaisNoDomicilio
        {
            get { return this._quantosAnimaisNoDomicilio; }
            set { SetProperty(ref _quantosAnimaisNoDomicilio, value); }
        }

        //Campo tpCdsOrigem - Tipo Integer
        private int _tpCdsOrigem; //Obrigatório
        [NotNull, MaxLength(1)] //Mínimo 1; Máximo 1 dígito
        public int TpCdsOrigem
        {
            get { return this._tpCdsOrigem; }
            set { SetProperty(ref _tpCdsOrigem, value); }
        }

        //Campo uuid - Tipo string
        private string _uuid; //Obrigatório
        [NotNull, MaxLength(44)] //Mínimo 36 caracteres; Máximo 44 caracteres
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


        //Campo tipoDeImovel - Tipo long
        private long _tipoDeImovel; //Obrigatório
        [NotNull]
        public long TipoDeImovel
        {
            get { return this._tipoDeImovel; }
            set { SetProperty(ref _tipoDeImovel, value); }
        }

        //INÍCIO CONDIÇÃO MORADIA

        //Campo abastecimentoAgua - Tipo long
        private long _abastecimentoAgua; //Não Obrigatório
        public long AbastecimentoAgua
        {
            get { return this._abastecimentoAgua; }
            set { SetProperty(ref _abastecimentoAgua, value); }
        }

        //Campo areaProducaoRural - Tipo long
        private long _areaProducaoRural; //Condicional
        public long AreaProducaoRural
        {
            get { return this._areaProducaoRural; }
            set { SetProperty(ref _areaProducaoRural, value); }
        }

        //Campo destinoLixo - Tipo long
        private long _destinoLixo; //Não Obrigatório
        public long DestinoLixo
        {
            get { return this._destinoLixo; }
            set { SetProperty(ref _destinoLixo, value); }
        }

        //Campo formaEscoamentoBanheiro - Tipo long
        private long _formaEscoamentoBanheiro; //Não Obrigatório
        public long FormaEscoamentoBanheiro
        {
            get { return this._formaEscoamentoBanheiro; }
            set { SetProperty(ref _formaEscoamentoBanheiro, value); }
        }

        //Campo localizacao - Tipo long
        private long _localizacao; //Obrigatório
        [NotNull]
        public long Localizacao
        {
            get { return this._localizacao; }
            set { SetProperty(ref _localizacao, value); }
        }

        //Campo materialPredominanteParedesExtDomicilio - Tipo long
        private long _materialPredominanteParedesExtDomicilio; //Não Obrigatório
        public long MaterialPredominanteParedesExtDomicilio
        {
            get { return this._materialPredominanteParedesExtDomicilio; }
            set { SetProperty(ref _materialPredominanteParedesExtDomicilio, value); }
        }

        //Campo nuComodos - Tipo string
        private string _nuComodos; //Não Obrigatório
        [MaxLength(2)] //Máximo 2 caracteres
        public string NuComodos
        {
            get { return this._nuComodos; }
            set { SetProperty(ref _nuComodos, value); }
        }

        //Campo nuMoradores - Tipo string
        private string _nuMoradores; //Não Obrigatório
        [MaxLength(4)] //Máximo 4 caracteres
        public string NuMoradores
        {
            get { return this._nuMoradores; }
            set { SetProperty(ref _nuMoradores, value); }
        }

        //Campo situacaoMoradiaPosseTerra - Tipo long
        private long _situacaoMoradiaPosseTerra; //Não Obrigatório
        public long SituacaoMoradiaPosseTerra
        {
            get { return this._situacaoMoradiaPosseTerra; }
            set { SetProperty(ref _situacaoMoradiaPosseTerra, value); }
        }

        //Campo stDisponibilidadeEnergia - Tipo long
        private long _stDisponibilidadeEnergia; //Não Obrigatório
        public long stDisponibilidadeEnergia
        {
            get { return this._stDisponibilidadeEnergia; }
            set { SetProperty(ref _stDisponibilidadeEnergia, value); }
        }

        //Campo tipoAcessoDomicilio - Tipo long
        private long _tipoAcessoDomicilio; //Não Obrigatório
        public long TipoAcessoDomicilio
        {
            get { return this._tipoAcessoDomicilio; }
            set { SetProperty(ref _tipoAcessoDomicilio, value); }
        }

        //Campo tipoDomicilio - Tipo long
        private long _tipoDomicilio; //Não Obrigatório
        public long TipoDomicilio
        {
            get { return this._tipoAcessoDomicilio; }
            set { SetProperty(ref _tipoAcessoDomicilio, value); }
        }

        //Campo aguaConsumoDomicilio - Tipo long
        private long _aguaConsumoDomicilio; //Não Obrigatório
        public long AguaConsumoDomicilio
        {
            get { return this._aguaConsumoDomicilio; }
            set { SetProperty(ref _aguaConsumoDomicilio, value); }
        }

        //FIM CONDIÇÃO MORADIA

        //INÍCIO ENDEREÇO LOCAL PERMANÊNCIA

        //Campo bairro - Tipo string
        private string _bairro; //Obrigatório
        [NotNull, MaxLength(72)] //Máximo 72 caracteres
        public string Bairro
        {
            get { return this._bairro; }
            set { SetProperty(ref _bairro, value); }
        }

        //Campo cep - Tipo string
        private string _cep; //Obrigatório
        [NotNull, MaxLength(8)] //Mínimo 8 caracteres; Máximo 8 caracteres
        public string Cep
        {
            get { return this._cep; }
            set { SetProperty(ref _cep, value); }
        }

        //Campo codigoIbgeMunicipio - Tipo string
        private string _codigoIbgeMunicipio; //Obrigatório
        [NotNull, MaxLength(7)] //Mínimo 7 caracteres; Máximo 7 caracteres
        public string CodigoIbgeMunicipio
        {
            get { return this._codigoIbgeMunicipio; }
            set { SetProperty(ref _codigoIbgeMunicipio, value); }
        }

        //Campo complemento - Tipo string
        private string _complemento; //Não Obrigatório
        [MaxLength(30)] //Máximo 30 caracteres
        public string Complemento
        {
            get { return this._complemento; }
            set { SetProperty(ref _complemento, value); }
        }

        //Campo nomeLogradouro - Tipo string
        private string _nomeLogradouro; //Obrigatório
        [NotNull, MaxLength(72)] //Máximo 72 caracteres
        public string NomeLogradouro
        {
            get { return this._nomeLogradouro; }
            set { SetProperty(ref _nomeLogradouro, value); }
        }

        //Campo numero - Tipo string
        private string _numero; //Obrigatório
        [NotNull, MaxLength(10)] //Mínimo 1 caracter; Máximo 10 caracteres
        public string Numero
        {
            get { return this._numero; }
            set { SetProperty(ref _numero, value); }
        }

        //Campo numeroDneUf - Tipo string
        private string _numeroDneUf; //Obrigatório
        [NotNull]
        public string NumeroDneUf
        {
            get { return this._numeroDneUf; }
            set { SetProperty(ref _numeroDneUf, value); }
        }

        //Campo telefoneContato - Tipo string
        private string _telefoneContato; //Não Obrigatório
        [MaxLength(11)] //Mínimo 10 caracteres; Máximo 11 caracteres
        public string TelefoneContato
        {
            get { return this._telefoneContato; }
            set { SetProperty(ref _telefoneContato, value); }
        }

        //Campo telefoneResidencia - Tipo string
        private string _telefoneResidencia; //Não Obrigatório
        [MaxLength(10)] //Mínimo 10 caracteres; Máximo 11 caracteres
        public string TelefoneResidencia
        {
            get { return this._telefoneResidencia; }
            set { SetProperty(ref _telefoneResidencia, value); }
        }

        //Campo tipoLogradouroNumeroDne - Tipo string
        private string _tipoLogradouroNumeroDne; //Obrigatório
        [NotNull]
        public string TipoLogradouroNumeroDne
        {
            get { return this._tipoLogradouroNumeroDne; }
            set { SetProperty(ref _tipoLogradouroNumeroDne, value); }
        }

        //Campo stSemNumero - Tipo boolean
        private bool _stSemNumero; //Não Obrigatório
        public bool StSemNumero
        {
            get { return this._stSemNumero; }
            set { SetProperty(ref _stSemNumero, value); }
        }

        //Campo pontoReferencia - Tipo string
        private string _pontoReferencia; //Não Obrigatório
        [MaxLength(40)] //Máximo 40 caracteres
        public string PontoReferencia
        {
            get { return this._pontoReferencia; }
            set { SetProperty(ref _pontoReferencia, value); }
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

        //FIM ENDEREÇO LOCAL PERMANÊNCIA

        //INÍCIO INSTITUIÇÃO PERMANÊNCIA

        //Campo nomeInstituicaoPermanencia - Tipo string
        private string _nomeInstituicaoPermanencia; //Não Obrigatório
        [MaxLength(100)] //Máximo 100 caracteres
        public string NomeInstituicaoPermanencia
        {
            get { return this._nomeInstituicaoPermanencia; }
            set { SetProperty(ref _nomeInstituicaoPermanencia, value); }
        }

        //Campo stOutrosProfissionaisVinculados - Tipo boolean
        private bool _stOutrosProfissionaisVinculados; //Não Obrigatório
        public bool StOutrosProfissionaisVinculados
        {
            get { return this._stOutrosProfissionaisVinculados; }
            set { SetProperty(ref _stOutrosProfissionaisVinculados, value); }
        }

        //Campo nomeResponsavelTecnico - Tipo string
        private string _nomeResponsavelTecnico; //Obrigatório
        [NotNull, MaxLength(70)] //Mínimo 3 caracteres; Máximo 70 caracteres
        public string NomeResponsavelTecnico
        {
            get { return this._nomeResponsavelTecnico; }
            set { SetProperty(ref _nomeResponsavelTecnico, value); }
        }

        //Campo cnsResponsavelTecnico - Tipo string
        private string _cnsResponsavelTecnico; //Não Obrigatório
        [MaxLength(15)] //Mínimo 15 caracteres; Máximo 15 caracteres
        public string CnsResponsavelTecnico
        {
            get { return this._cnsResponsavelTecnico; }
            set { SetProperty(ref _cnsResponsavelTecnico, value); }
        }

        //Campo cargoInstituicao - Tipo string
        private string _cargoInstituicao; //Não Obrigatório
        [MaxLength(100)] //Máximo 100 caracteres
        public string CargoInstituicao
        {
            get { return this._cargoInstituicao; }
            set { SetProperty(ref _cargoInstituicao, value); }
        }

        //Campo telefoneResponsavelTecnico - Tipo string
        private string _telefoneResponsavelTecnico; //Não Obrigatório
        [MaxLength(11)] //Mínimo 10 caracteres; Máximo 11 caracteres
        public string TelefoneResponsavelTecnico
        {
            get { return this._telefoneResponsavelTecnico; }
            set { SetProperty(ref _telefoneResponsavelTecnico, value); }
        }

        //FIM INSTITUIÇÃO PERMANÊNCIA

    }
}
