using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace gvn_ab_mobile.Models
{
    public class FichaAtendimentoIndividual : Helpers.ObservableObject
    {

        //Campo ID - Tipo long
        private long? _id;
        [PrimaryKey, AutoIncrement] //Chave Primária com incremento automático
        public long? Id
        {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }

        //Campo uuidFicha - Tipo string
        private string _uuidFicha; //Obrigatório
        [NotNull, MaxLength(44)] //Mínimo 36 caracteres; Máximo 44 caracteres 
        public string UuidFicha
        {
            get { return this._uuidFicha; }
            set { SetProperty(ref _uuidFicha, value); }
        }

        //Campo tpCdsOrigem - Tipo Integer
        private int _tpCdsOrigem; //Obrigatório
        [NotNull, MaxLength(1)] //Mínimo 1 dígito; Máximo 1 dígito
        public int TpCdsOrigem
        {
            get { return this._tpCdsOrigem; }
            set { SetProperty(ref _tpCdsOrigem, value); }
        }

        //INÍCIO ProblemaCondicaoAvaliacaoAI

        //Campo ciaps - Tipo List<string>
        private List<string> _ciaps; //Condicional
        [MaxLength(22)] //Mínimo 0; Máximo 22
        public List<string> Ciaps
        {
            get { return this._ciaps; }
            set { SetProperty(ref _ciaps, value); }
        }

        //Campo outrosCiap1 - Tipo string
        private string _outrosCiap1; //Condicional
        public string OutrosCiap1
        {
            get { return this._outrosCiap1; }
            set { SetProperty(ref _outrosCiap1, value); }
        }

        //Campo outrosCiap2 - Tipo string
        private string _outrosCiap2; //Condicional
        public string OutrosCiap2
        {
            get { return this._outrosCiap2; }
            set { SetProperty(ref _outrosCiap2, value); }
        }

        //Campo cid10 - Tipo string
        private string _cid10; //Condicional
        public string Cid10
        {
            get { return this._cid10; }
            set { SetProperty(ref _cid10, value); }
        }

        //Campo cid10_2 - Tipo string
        private string _cid10_2; //Condicional
        public string Cid10_2
        {
            get { return this._cid10_2; }
            set { SetProperty(ref _cid10_2, value); }
        }

        //FIM ProblemaCondicaoAvaliacaoAI

        //CARDINALIDADE RELAÇÃO FICHA HEADER

        //[OneToMany]
        //public List<FichaLotacaoHeader> Headers
        //{
        //    get;
        //    set;
        //}

        //Campo numeroProntuario - Tipo string
        private string _numeroProntuario; //Não Obrigatório
        [MaxLength(30)] //Mínimo 0 dígitos; Máximo 30 dígitos
        public string NumeroProntuario
        {
            get { return this._numeroProntuario; }
            set { SetProperty(ref _numeroProntuario, value); }
        }

        //Campo cns - Tipo string
        private string _cns; //Não Obrigatório
        [MaxLength(15)] //Mínimo 15 dígitos; Máximo 15 dígitos
        public string Cns
        {
            get { return this._cns; }
            set { SetProperty(ref _cns, value); }
        }

        //Campo dataNascimento - Tipo long
        private long _dataNascimento; //Obrigatório
        [NotNull]
        public long DataNascimento
        {
            get { return this._dataNascimento; }
            set { SetProperty(ref _dataNascimento, value); }
        }

        //Campo localDeAtendimento - Tipo long
        private Models.LocalDeAtendimento _localDeAtendimento; //Obrigatório
        [NotNull]
        public Models.LocalDeAtendimento LocalDeAtendimento
        {
            get { return this._localDeAtendimento; }
            set { SetProperty(ref _localDeAtendimento, value); }
        }

        //Campo sexo - Tipo long
        private Models.Sexo _sexo; //Obrigatório
        [NotNull]
        public Models.Sexo Sexo
        {
            get { return this._sexo; }
            set { SetProperty(ref _sexo, value); }
        }

        //Campo turno - Tipo long
        private Models.Turno _turno; //Obrigatório
        [NotNull]
        public Models.Turno Turno
        {
            get { return this._turno; }
            set { SetProperty(ref _turno, value); }
        }

        //Campo tipoAtendimento - Tipo long
        private Models.TipoDeAtendimento _tipoAtendimento; //Obrigatório
        [NotNull]
        public Models.TipoDeAtendimento TipoAtendimento
        {
            get { return this._tipoAtendimento; }
            set { SetProperty(ref _tipoAtendimento, value); }
        }

        //Campo pesoAcompanhamentoNutricional - Tipo double
        private double _pesoAcompanhamentoNutricional; //Não Obrigatório
        [MaxLength(7)] //Mínimo 1 dígito; Máximo 7 dígitos
        public double PesoAcompanhamentoNutricional
        {
            get { return this._pesoAcompanhamentoNutricional; }
            set { SetProperty(ref _pesoAcompanhamentoNutricional, value); }
        }

        //Campo alturaAcompanhamentoNutricional - Tipo double
        private double _alturaAcompanhamentoNutricional; //Não Obrigatório
        [MaxLength(5)] //Mínimo 2 dígitos; Máximo 5 dígitos
        public double AlturaAcompanhamentoNutricional
        {
            get { return this._alturaAcompanhamentoNutricional; }
            set { SetProperty(ref _alturaAcompanhamentoNutricional, value); }
        }

        //Campo aleitamentoMaterno - Tipo long
        private Models.AleitamentoMaterno _aleitamentoMaterno; //Não Obrigatório
        public Models.AleitamentoMaterno AleitamentoMaterno
        {
            get { return this._aleitamentoMaterno; }
            set { SetProperty(ref _aleitamentoMaterno, value); }
        }

        //Campo dumDaGestante - Tipo long
        private long _dumDaGestante; //Não Obrigatório
        public long DumDaGestante
        {
            get { return this._dumDaGestante; }
            set { SetProperty(ref _dumDaGestante, value); }
        }

        //Campo idadeGestacional - Tipo Integer
        private int _idadeGestacional; //Não Obrigatório
        [MaxLength(2)] //Mínimo 0 dígitos; Máximo 2 dígitos
        public int IdadeGestacional
        {
            get { return this._idadeGestacional; }
            set { SetProperty(ref _idadeGestacional, value); }
        }

        //Campo atencaoDomiciliarModalidade - Tipo long
        private Models.ModalidadeAD _atencaoDomiciliarModalidade; //Não Obrigatório
        public Models.ModalidadeAD AtencaoDomiciliarModalidade
        {
            get { return this._atencaoDomiciliarModalidade; }
            set { SetProperty(ref _atencaoDomiciliarModalidade, value); }
        }

        //Campo examesSolicitados - Tipo List<String>
        private List<string> _examesSolicitados; //Não Obrigatório
        [MaxLength(23)] //Mínimo 0 dígitos; Máximo 23 dígitos
        public List<string> ExamesSolicitados
        {
            get { return this._examesSolicitados; }
            set { SetProperty(ref _examesSolicitados, value); }
        }

        //Campo examesAvaliados - Tipo List<String>
        private List<string> _examesAvaliados; //Não Obrigatório
        [MaxLength(23)] //Mínimo 0 dígitos; Máximo 23 dígitos
        public List<string> ExamesAvaliados
        {
            get { return this._examesAvaliados; }
            set { SetProperty(ref _examesAvaliados, value); }
        }

        //Campo vacinaEmDia - Tipo boolean
        private bool _vacinaEmDia; //Não Obrigatório
        public bool VacinaEmDia
        {
            get { return this._vacinaEmDia; }
            set { SetProperty(ref _vacinaEmDia, value); }
        }

        //Campo ficouEmObservacao - Tipo boolean
        private bool _ficouEmObservacao; //Não Obrigatório
        public bool FicouEmObservacao
        {
            get { return this._ficouEmObservacao; }
            set { SetProperty(ref _ficouEmObservacao, value); }
        }

        //Campo nasfs - Tipo List<Long>
        private List<long> _nasfs; //Não Obrigatório
        [MaxLength(3)] //Mínimo 0 códigos; Máximo 3 códigos 
        public List<long> Nasfs
        {
            get { return this._nasfs; }
            set { SetProperty(ref _nasfs, value); }
        }

        //Campo condutas - Tipo List<Long>
        private List<long> _condutas; //Obrigatório
        [NotNull, MaxLength(12)] //Mínimo 1 código; Máximo 12 códigos 
        public List<long> Condutas
        {
            get { return this._condutas; }
            set { SetProperty(ref _condutas, value); }
        }

        //Campo stGravidezPlanejada - Tipo boolean
        private bool _stGravidezPlanejada; //Não Obrigatório
        public bool StGravidezPlanejada
        {
            get { return this._stGravidezPlanejada; }
            set { SetProperty(ref _stGravidezPlanejada, value); }
        }

        //Campo nuGravidezPrevias - Tipo Integer
        private int _nuGravidezPrevias; //Não Obrigatório
        [MaxLength(2)] //Mínimo 0 dígitos; Máximo 2 dígitos
        public int NuGravidezPrevias
        {
            get { return this._nuGravidezPrevias; }
            set { SetProperty(ref _nuGravidezPrevias, value); }
        }

        //Campo nuPartos - Tipo Integer
        private int _nuPartos; //Não Obrigatório
        [MaxLength(2)] //Mínimo 0 dígitos; Máximo 2 dígitos
        public int NuPartos
        {
            get { return this._nuPartos; }
            set { SetProperty(ref _nuPartos, value); }
        }

        //Campo racionalidadeSaude - Tipo long
        private Models.RacionalidadeSaude _racionalidadeSaude; //Não Obrigatório
        [MaxLength(1)] //Mínimo 0 dígitos; Máximo 1 dígito
        public Models.RacionalidadeSaude RacionalidadeSaude
        {
            get { return this._racionalidadeSaude; }
            set { SetProperty(ref _racionalidadeSaude, value); }
        }

        //Campo perimetroCefalico - Tipo long
        private long _perimetroCefalico; //Não Obrigatório
        [MaxLength(6)] //Mínimo 0 dígitos; Máximo 6 dígitos
        public long PerimetroCefalico
        {
            get { return this._perimetroCefalico; }
            set { SetProperty(ref _perimetroCefalico, value); }
        }

        //

        //CARDINALIDADE RELAÇÃO OUTROSSIA

        [OneToMany]
        public List<FichaOutrosSia> OutrosSia
        {
            get;
            set;
        }

        //

    }
}
