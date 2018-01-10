using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;
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

        [OneToMany]
        public List<FichaHeader> Headers
        {
            get;
            set;
        }

        //

        //CARDINALIDADE RELAÇÃO FichaAtendimentoIndividualChild

        [OneToMany]
        public List<FichaAtendimentoIndividualChild> AtendimentosIndividuaisChild
        {
            get;
            set;
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
