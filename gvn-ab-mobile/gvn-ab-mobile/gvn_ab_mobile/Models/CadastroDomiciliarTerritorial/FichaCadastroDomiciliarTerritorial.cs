using System;
using System.Collections.Generic;

using SQLite;
using SQLiteNetExtensions.Attributes;

namespace gvn_ab_mobile.Models {
    public class FichaCadastroDomiciliarTerritorial : Helpers.ObservableObject {

        public FichaCadastroDomiciliarTerritorial() {

        }

        //Campo ID - Tipo long
        private long? _id;
        [PrimaryKey, AutoIncrement] //Chave Primária com incremento automático
        public long? Id {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }

        //Campo statusTermoRecusa - Tipo bool
        private bool _statusTermoRecusa; //Obrigatório
        [NotNull]
        public bool StatusTermoRecusa {
            get { return this._statusTermoRecusa; }
            set { SetProperty(ref _statusTermoRecusa, value); }
        }

        //Campo fichaAtualizada - Tipo boolean
        private bool _fichaAtualizada; //Obrigatório
        [NotNull]
        public bool FichaAtualizada {
            get { return this._fichaAtualizada; }
            set { SetProperty(ref _fichaAtualizada, value); }
        }

        //Campo animaisNoDomicilio - Tipo List<Long>
        private List<Models.AnimalNoDomicilio> _animaisNoDomicilio; //Condicional
        [OneToMany(CascadeOperations = CascadeOperation.All), MaxLength(4)] //Máximo 4 códigos
        public List<Models.AnimalNoDomicilio> AnimaisNoDomicilio {
            get { return this._animaisNoDomicilio; }
            set { SetProperty(ref _animaisNoDomicilio, value); }
        }

        //Campo stAnimaisNoDomicilio - Tipo boolean
        private bool _stAnimaisNoDomicilio; //Condicional
        public bool StAnimaisNoDomicilio {
            get { return this._stAnimaisNoDomicilio; }
            set { SetProperty(ref _stAnimaisNoDomicilio, value); }
        }

        //Campo quantosAnimaisNoDomicilio - Tipo string
        private string _quantosAnimaisNoDomicilio; //Condicional
        [MaxLength(2)] //Máximo 2 caracteres
        public string QuantosAnimaisNoDomicilio {
            get { return this._quantosAnimaisNoDomicilio; }
            set { SetProperty(ref _quantosAnimaisNoDomicilio, value); }
        }

        //Campo tpCdsOrigem - Tipo Integer
        //Obrigatório
        [NotNull, MaxLength(1)] //Mínimo 1; Máximo 1 dígito
        public int TpCdsOrigem { get; } = 3;

        //Campo uuid - Tipo string
        private string _uuid; //Obrigatório
        [MaxLength(44)] //Mínimo 36 caracteres; Máximo 44 caracteres
        public string Uuid {
            get { return this._uuid; }
            set { SetProperty(ref _uuid, value); }
        }

        //Campo uuidFichaOriginadora - Tipo string
        private string _uuidFichaOriginadora; //Obrigatório
        [MaxLength(44)] //Mínimo 36 caracteres; Máximo 44 caracteres
        public string UuidFichaOriginadora {
            get { return this._uuidFichaOriginadora; }
            set { SetProperty(ref _uuidFichaOriginadora, value); }
        }


        //Campo tipoDeImovel - Tipo long
        public long? TipoDeImovelId { get; set; }
        private Models.TipoDeImovel _tipoDeImovel; //Obrigatório
        [OneToOne("TipoDeImovelId"), NotNull]
        public Models.TipoDeImovel TipoDeImovel {
            get { return this._tipoDeImovel; }
            set { SetProperty(ref _tipoDeImovel, value); }
        }

        //INÍCIO CONDIÇÃO MORADIA

        //Campo abastecimentoAgua - Tipo long
        public long? AbastecimentoAguaId { get; set; }
        private Models.AbastecimentoDeAgua _abastecimentoAgua; //Não Obrigatório
        [OneToOne("AbastecimentoAguaId")]
        public Models.AbastecimentoDeAgua AbastecimentoAgua {
            get { return this._abastecimentoAgua; }
            set { SetProperty(ref _abastecimentoAgua, value); }
        }

        //Campo areaProducaoRural - Tipo long
        public long? AreaProducaoRuralId { get; set; }
        private Models.CondicaoDePosseEUsoDaTerra _areaProducaoRural; //Condicional
        [OneToOne("AreaProducaoRuralId")]
        public Models.CondicaoDePosseEUsoDaTerra AreaProducaoRural {
            get { return this._areaProducaoRural; }
            set { SetProperty(ref _areaProducaoRural, value); }
        }

        //Campo destinoLixo - Tipo long
        public long? DestinoLixoId { get; set; }
        private Models.DestinoDoLixo _destinoLixo; //Não Obrigatório
        [OneToOne("DestinoLixoId")]
        public Models.DestinoDoLixo DestinoLixo {
            get { return this._destinoLixo; }
            set { SetProperty(ref _destinoLixo, value); }
        }

        //Campo formaEscoamentoBanheiro - Tipo long
        public long? FormaEscoamentoBanheiroId { get; set; }
        private Models.FormaDeEscoamentoDoBanheiroOuSanitario _formaEscoamentoBanheiro; //Não Obrigatório
        [OneToOne("FormaEscoamentoBanheiroId")]
        public Models.FormaDeEscoamentoDoBanheiroOuSanitario FormaEscoamentoBanheiro {
            get { return this._formaEscoamentoBanheiro; }
            set { SetProperty(ref _formaEscoamentoBanheiro, value); }
        }

        //Campo localizacao - Tipo long
        public long? LocalizacaoId { get; set; }
        private Models.LocalizacaoDaMoradia _localizacao; //Obrigatório
        [OneToOne("LocalizacaoId"), NotNull]
        public Models.LocalizacaoDaMoradia Localizacao {
            get { return this._localizacao; }
            set { SetProperty(ref _localizacao, value); }
        }

        //Campo materialPredominanteParedesExtDomicilio - Tipo long
        public long? MaterialPredominanteParedesExtDomicilioId { get; set; }
        private Models.MaterialPredominanteNaConstrucao _materialPredominanteParedesExtDomicilio; //Não Obrigatório
        [OneToOne("MaterialPredominanteParedesExtDomicilioId")]
        public Models.MaterialPredominanteNaConstrucao MaterialPredominanteParedesExtDomicilio {
            get { return this._materialPredominanteParedesExtDomicilio; }
            set { SetProperty(ref _materialPredominanteParedesExtDomicilio, value); }
        }

        //Campo nuComodos - Tipo string
        private string _nuComodos; //Não Obrigatório
        [MaxLength(2)] //Máximo 2 caracteres
        public string NuComodos {
            get { return this._nuComodos; }
            set { SetProperty(ref _nuComodos, value); }
        }

        //Campo nuMoradores - Tipo string
        private string _nuMoradores; //Não Obrigatório
        [MaxLength(4)] //Máximo 4 caracteres
        public string NuMoradores {
            get { return this._nuMoradores; }
            set { SetProperty(ref _nuMoradores, value); }
        }

        //Campo situacaoMoradiaPosseTerra - Tipo long
        public long? SituacaoMoradiaPosseTerraId { get; set; }
        private Models.SituacaoDeMoradia _situacaoMoradiaPosseTerra; //Não Obrigatório
        [OneToOne("SituacaoMoradiaPosseTerraId")]
        public Models.SituacaoDeMoradia SituacaoMoradiaPosseTerra {
            get { return this._situacaoMoradiaPosseTerra; }
            set { SetProperty(ref _situacaoMoradiaPosseTerra, value); }
        }

        //Campo stDisponibilidadeEnergia - Tipo long
        private bool _stDisponibilidadeEnergia; //Não Obrigatório
        public bool StDisponibilidadeEnergia {
            get { return this._stDisponibilidadeEnergia; }
            set { SetProperty(ref _stDisponibilidadeEnergia, value); }
        }

        //Campo tipoAcessoDomicilio - Tipo long
        public long? TipoAcessoDomicilioId { get; set; }
        private Models.TipoDeAcessoAoDomicilio _tipoAcessoDomicilio; //Não Obrigatório
        [OneToOne("TipoAcessoDomicilioId")]
        public Models.TipoDeAcessoAoDomicilio TipoAcessoDomicilio {
            get { return this._tipoAcessoDomicilio; }
            set { SetProperty(ref _tipoAcessoDomicilio, value); }
        }

        //Campo tipoDomicilio - Tipo long
        public long? TipoDomicilioId { get; set; }
        private Models.TipoDeDomicilio _tipoDomicilio; //Não Obrigatório
        [OneToOne("TipoDomicilioId")]
        public Models.TipoDeDomicilio TipoDomicilio {
            get { return this._tipoDomicilio; }
            set { SetProperty(ref _tipoDomicilio, value); }
        }

        //Campo aguaConsumoDomicilio - Tipo long
        public long? AguaConsumoDomicilioId { get; set; }
        private Models.AguaConsumoDomicilio _aguaConsumoDomicilio; //Não Obrigatório
        [OneToOne("AguaConsumoDomicilioId")]
        public Models.AguaConsumoDomicilio AguaConsumoDomicilio {
            get { return this._aguaConsumoDomicilio; }
            set { SetProperty(ref _aguaConsumoDomicilio, value); }
        }

        //FIM CONDIÇÃO MORADIA

        //INÍCIO ENDEREÇO LOCAL PERMANÊNCIA


        public long? BairroId { get; set; }
        private Models.Bairro bairro; //Obrigatório
        [OneToOne("BairroId")]
        public Models.Bairro Bairro {
            get { return this.bairro; }
            set { SetProperty(ref bairro, value); }
        }

        //Campo cep - Tipo string
        private string _cep; //Obrigatório
        [NotNull, MaxLength(8)] //Mínimo 8 caracteres; Máximo 8 caracteres
        public string Cep {
            get { return this._cep; }
            set { SetProperty(ref _cep, value); }
        }

        //Campo codigoIbgeMunicipio - Tipo string
        public long? MunicipioId { get; set; }
        private Models.Municipio _municipio; //Obrigatório
        [OneToOne("MunicipioId")] //Mínimo 7 caracteres; Máximo 7 caracteres
        public Models.Municipio Municipio {
            get { return this._municipio; }
            set { SetProperty(ref _municipio, value); }
        }

        //Campo complemento - Tipo string
        private string _complemento; //Não Obrigatório
        [MaxLength(30)] //Máximo 30 caracteres
        public string Complemento {
            get { return this._complemento; }
            set { SetProperty(ref _complemento, value); }
        }


        //Campo codigoIbgeMunicipio - Tipo string
        public long? LogradouroId { get; set; }
        private Models.Logradouro logradouro; //Obrigatório
        [OneToOne("LogradouroId")] //Mínimo 7 caracteres; Máximo 7 caracteres
        public Models.Logradouro Logradouro {
            get { return this.logradouro; }
            set { SetProperty(ref logradouro, value); }
        }

        //Campo numero - Tipo string
        private string _numero; //Obrigatório
        [MaxLength(10)] //Mínimo 1 caracter; Máximo 10 caracteres
        public string Numero {
            get { return this._numero; }
            set { SetProperty(ref _numero, value); }
        }

        //Campo numeroDneUf - Tipo string
        public long? UnidadeFederalId { get; set; }
        private Models.UnidadeFederal unidadeFederal; //Obrigatório
        [OneToOne("UnidadeFederalId")]
        public Models.UnidadeFederal UnidadeFederal {
            get { return this.unidadeFederal; }
            set { SetProperty(ref unidadeFederal, value); }
        }

        //Campo telefoneContato - Tipo string
        private string _telefoneContato; //Não Obrigatório
        [MaxLength(11)] //Mínimo 10 caracteres; Máximo 11 caracteres
        public string TelefoneContato {
            get { return this._telefoneContato; }
            set { SetProperty(ref _telefoneContato, value); }
        }

        //Campo telefoneResidencia - Tipo string
        private string _telefoneResidencia; //Não Obrigatório
        [MaxLength(10)] //Mínimo 10 caracteres; Máximo 11 caracteres
        public string TelefoneResidencia {
            get { return this._telefoneResidencia; }
            set { SetProperty(ref _telefoneResidencia, value); }
        }

        //Campo tipoLogradouroNumeroDne - Tipo string
        public long? TipoLogradouroNumeroDneId { get; set; }
        private Models.TipoLogradouro _tipoLogradouroNumeroDne; //Obrigatório
        [OneToOne("TipoLogradouroNumeroDneId")]
        public Models.TipoLogradouro TipoLogradouroNumeroDne {
            get { return this._tipoLogradouroNumeroDne; }
            set { SetProperty(ref _tipoLogradouroNumeroDne, value); }
        }

        //Campo stSemNumero - Tipo boolean
        private bool _stSemNumero; //Não Obrigatório
        public bool StSemNumero {
            get { return this._stSemNumero; }
            set { SetProperty(ref _stSemNumero, value); }
        }

        //Campo pontoReferencia - Tipo string
        private string _pontoReferencia; //Não Obrigatório
        [MaxLength(40)] //Máximo 40 caracteres
        public string PontoReferencia {
            get { return this._pontoReferencia; }
            set { SetProperty(ref _pontoReferencia, value); }
        }

        //Campo microarea - Tipo string
        private string _microarea; //Condicional
        [MaxLength(2)] //Mínimo 2 caracteres; Máximo 2 caracteres
        public string Microarea {
            get { return this._microarea; }
            set { SetProperty(ref _microarea, value); }
        }

        //Campo stForaArea - Tipo boolean
        private bool _stForaArea; //Não Obrigatório
        public bool StForaArea {
            get { return this._stForaArea; }
            set { SetProperty(ref _stForaArea, value); }
        }

        //FIM ENDEREÇO LOCAL PERMANÊNCIA

        //INÍCIO INSTITUIÇÃO PERMANÊNCIA

        //Campo nomeInstituicaoPermanencia - Tipo string
        private string _nomeInstituicaoPermanencia; //Não Obrigatório
        [MaxLength(100)] //Máximo 100 caracteres
        public string NomeInstituicaoPermanencia {
            get { return this._nomeInstituicaoPermanencia; }
            set { SetProperty(ref _nomeInstituicaoPermanencia, value); }
        }

        //Campo stOutrosProfissionaisVinculados - Tipo boolean
        private bool _stOutrosProfissionaisVinculados; //Não Obrigatório
        public bool StOutrosProfissionaisVinculados {
            get { return this._stOutrosProfissionaisVinculados; }
            set { SetProperty(ref _stOutrosProfissionaisVinculados, value); }
        }

        //Campo nomeResponsavelTecnico - Tipo string
        private string _nomeResponsavelTecnico; //Obrigatório
        [NotNull, MaxLength(70)] //Mínimo 3 caracteres; Máximo 70 caracteres
        public string NomeResponsavelTecnico {
            get { return this._nomeResponsavelTecnico; }
            set { SetProperty(ref _nomeResponsavelTecnico, value); }
        }

        //Campo rgResponsavelTecnico - Tipo string
        private string _rgResponsavelTecnico; //Obrigatório
        [MaxLength(8)] //Mínimo 3 caracteres; Máximo 70 caracteres
        public string RgResponsavelTecnico {
            get { return this._rgResponsavelTecnico; }
            set { SetProperty(ref _rgResponsavelTecnico, value); }
        }

        //Campo cnsResponsavelTecnico - Tipo string
        private string _cnsResponsavelTecnico; //Não Obrigatório
        [MaxLength(15)] //Mínimo 15 caracteres; Máximo 15 caracteres
        public string CnsResponsavelTecnico {
            get { return this._cnsResponsavelTecnico; }
            set { SetProperty(ref _cnsResponsavelTecnico, value); }
        }

        //Campo cargoInstituicao - Tipo string
        private string _cargoInstituicao; //Não Obrigatório
        [MaxLength(100)] //Máximo 100 caracteres
        public string CargoInstituicao {
            get { return this._cargoInstituicao; }
            set { SetProperty(ref _cargoInstituicao, value); }
        }

        //Campo telefoneResponsavelTecnico - Tipo string
        private string _telefoneResponsavelTecnico; //Não Obrigatório
        [MaxLength(11)] //Mínimo 10 caracteres; Máximo 11 caracteres
        public string TelefoneResponsavelTecnico {
            get { return this._telefoneResponsavelTecnico; }
            set { SetProperty(ref _telefoneResponsavelTecnico, value); }
        }

        //Campo NomeCidadão
        private string _nomeCidadao;
        [MaxLength(70)]
        public string NomeCidadao {
            get { return this._nomeCidadao; }
            set { SetProperty(ref _nomeCidadao, value); }
        }

        //Campo Rg do Cidadão - Tipo String
        private string _rg;
        [MaxLength(8)]
        public string Rg {
            get { return this._rg; }
            set { SetProperty(ref _rg, value); }
        }

        //FIM INSTITUIÇÃO PERMANÊNCIA

        //CARDINALIDADE RELAÇÃO FICHA HEADER

        public long? HeaderId { get; set; }
        private FichaUnicaLotacaoHeader _header;
        [OneToOne("HeaderId")]
        public FichaUnicaLotacaoHeader Header {
            get { return this._header; }
            set { SetProperty(ref _header, value); }
        }

        //

        //CARDINALIDADE FICHA FACMILIA

        private List<Models.FichaFamilia> _familias;
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Models.FichaFamilia> Familias {
            get { return this._familias; }
            set { SetProperty(ref _familias, value); }
        }

        //

        // Assinaturas Termos de Recusa

        //Campo AssinaturaRecusaCadastroBase64 - Tipo String
        private string _assinaturaRecusaCadastroBase64;
        public string AssinaturaRecusaCadastroBase64 {
            get { return this._assinaturaRecusaCadastroBase64; }
            set { SetProperty(ref _assinaturaRecusaCadastroBase64, value); }
        }

        //Campo AssinaturaRecusaInstituicaoPermanenciaBase64 - Tipo String
        private string _assinaturaRecusaInstituicaoPermanenciaCadastroBase64;
        public string AssinaturaRecusaInstituicaoPermanenciaCadastroBase64 {
            get { return this._assinaturaRecusaInstituicaoPermanenciaCadastroBase64; }
            set { SetProperty(ref _assinaturaRecusaInstituicaoPermanenciaCadastroBase64, value); }
        }

        //
        public override string ToString() {
            return $"Ficha {this.Id}: " +
                   $"{this.Bairro} - " + 
                   $"{this.Logradouro} - " +
                   $"{this.Numero}";
        }

    }
}
