using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;

namespace gvn_ab_mobile.Models
{
    class FichaAtendimentoIndividual : Helpers.ObservableObject
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

        //INÍCIO FichaAtendimentoIndividualChild

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
        private long _localDeAtendimento; //Obrigatório
        [NotNull]
        public long LocalDeAtendimento
        {
            get { return this._localDeAtendimento; }
            set { SetProperty(ref _localDeAtendimento, value); }
        }

        //Campo sexo - Tipo long
        private long _sexo; //Obrigatório
        [NotNull]
        public long Sexo
        {
            get { return this._sexo; }
            set { SetProperty(ref _sexo, value); }
        }

        //Campo turno - Tipo long
        private long _turno; //Obrigatório
        [NotNull]
        public long Turno
        {
            get { return this._turno; }
            set { SetProperty(ref _turno, value); }
        }

        //Campo tipoAtendimento - Tipo long
        private long _tipoAtendimento; //Obrigatório
        [NotNull]
        public long TipoAtendimento
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

        //FIM FichaAtendimentoIndividualChild

    }
}
