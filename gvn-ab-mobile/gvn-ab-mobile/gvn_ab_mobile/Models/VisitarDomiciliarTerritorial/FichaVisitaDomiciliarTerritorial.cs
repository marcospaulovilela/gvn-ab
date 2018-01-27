using System;
using System.Collections.Generic;

using SQLite;
using SQLiteNetExtensions.Attributes;

namespace gvn_ab_mobile.Models {
    public class FichaVisitaDomiciliarTerritorial : Helpers.ObservableObject {

        //Campo ID - Tipo long
        private long? _id;
        [PrimaryKey, AutoIncrement] //Chave Primária com incremento automático
        public long? Id {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }

        //CAMPO UUID - Tipo String
        private string _uuid;
        /// <summary>
        /// Código UUID para identificar a ficha na base de dados nacional.
        /// É recomendado concatenar o CNES na frente do UUID, de modo que os 7 dígitos (CNES) + 1 de hífen somados aos 36 (32 caracteres + 4 hífen) do UUID são a limitação de 44 bytes do campo. Formato canônico.
        /// </summary>
        [MaxLength(44)]
        public string Uuid {
            get { return this._uuid; }
            set { SetProperty(ref _uuid, value); }
        }

        //CAMPO TPCDSORIGEM - Tipo Integer
        /// <summary>
        /// Tipo de origem dos dados do registro.
        /// </summary>
        [NotNull, MaxLength(1)]
        public int TpCdsOrigem { get; } = 3;


        public long? HeaderId { get; set; }
        //CAMPO HEADERTRANSPORT
        private FichaUnicaLotacaoHeader _header;

        [NotNull, OneToOne("HeaderId")]
        public FichaUnicaLotacaoHeader Header {
            get { return this._header; }
            set { SetProperty(ref _header, value); }
        }

        public long? TurnoId { get; set; }
        //CAMPO TURNO
        //Campo turno - Tipo long
        private Models.Turno _turno; //Obrigatório
        [OneToOne("TurnoId"), NotNull]
        public Models.Turno Turno {
            get { return this._turno; }
            set { SetProperty(ref _turno, value); }
        }

        //Campo numProntuario - Tipo string
        private string _numProntuario; //Não Obrigatório
        [MaxLength(30)] //Mínimo 0 dígitos; Máximo 30 dígitos
        public string NumProntuario {
            get { return this._numProntuario; }
            set { SetProperty(ref _numProntuario, value); }
        }

        //Campo cnsCidadao - Tipo string
        private string _cnsCidadao; //Não Obrigatório
        [MaxLength(15)] //Mínimo 15 dígitos; Máximo 15 dígitos
        public string CnsCidadao {
            get { return this._cnsCidadao; }
            set { SetProperty(ref _cnsCidadao, value); }
        }

        //Campo dtNascimento - Tipo long
        private long _dtNascimento; //Obrigatório
        [NotNull]
        public long DtNascimento {
            get { return this._dtNascimento; }
            set { SetProperty(ref _dtNascimento, value); }
        }

        public long? SexoId { get; set; }
        //Campo sexo - Tipo long
        private Models.Sexo _sexo; //Obrigatório
        [OneToOne("SexoId"), NotNull]
        public Models.Sexo Sexo {
            get { return this._sexo; }
            set { SetProperty(ref _sexo, value); }
        }

        //Campo statusVisitaCompartilhadaOutroProfissional - Tipo boolean
        private bool _statusVisitaCompartilhadaOutroProfissional; //Não Obrigatório
        public bool StatusVisitaCompartilhadaOutroProfissional {
            get { return this._statusVisitaCompartilhadaOutroProfissional; }
            set { SetProperty(ref _statusVisitaCompartilhadaOutroProfissional, value); }
        }

        //CAMPO motivosVisita
        private List<Models.MotivoVisita> _motivosVisita;
        [OneToMany, MaxLength(10)]
        public List<Models.MotivoVisita> MotivosVisita {
            get { return this._motivosVisita; }
            set { SetProperty(ref _motivosVisita, value); }
        }

        public long? DesfechoId { get; set; }
        //CAMPO desfecho
        private Models.Desfecho _desfecho;
        [OneToOne("DesfechoId")]
        public Models.Desfecho Desfecho {
            get { return this._desfecho; }
            set { SetProperty(ref _desfecho, value); }
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


        public long? TipoDeImovelId { get; set; }
        //Campo tipoDeImovel - Tipo long
        private Models.TipoDeImovel _tipoDeImovel; //Obrigatório
        [OneToOne("TipoDeImovelId"), NotNull]
        public Models.TipoDeImovel TipoDeImovel {
            get { return this._tipoDeImovel; }
            set { SetProperty(ref _tipoDeImovel, value); }
        }

        //Campo pesoAcompanhamentoNutricional - Tipo double
        private double _pesoAcompanhamentoNutricional; //Não Obrigatório
        [MaxLength(7)] //Mínimo 1 dígito; Máximo 7 dígitos
        public double PesoAcompanhamentoNutricional {
            get { return this._pesoAcompanhamentoNutricional; }
            set { SetProperty(ref _pesoAcompanhamentoNutricional, value); }
        }

        //Campo alturaAcompanhamentoNutricional - Tipo double
        private double _alturaAcompanhamentoNutricional; //Não Obrigatório
        [MaxLength(5)] //Mínimo 2 dígitos; Máximo 5 dígitos
        public double AlturaAcompanhamentoNutricional {
            get { return this._alturaAcompanhamentoNutricional; }
            set { SetProperty(ref _alturaAcompanhamentoNutricional, value); }
        }


        public override string ToString() {
            return $"Mudar o metodo tostring da ficha {this.GetType().Name}";
        }
    }
}
