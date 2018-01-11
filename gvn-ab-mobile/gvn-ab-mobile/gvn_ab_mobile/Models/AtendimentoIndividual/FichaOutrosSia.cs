using System.Collections.Generic;

using SQLite;
using SQLiteNetExtensions.Attributes;

namespace gvn_ab_mobile.Models
{
    public class FichaOutrosSia : Helpers.ObservableObject
    {

        //Campo ID - Tipo long
        private long? _id;
        [PrimaryKey, AutoIncrement] //Chave Primária com incremento automático
        public long? Id
        {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }

        //Campo idFichaAtendimentoIndividual - Tipo long
        public long _idFichaAtendimentoIndividual;
        [ForeignKey(typeof(FichaAtendimentoIndividual))] //Chave Estrangeira
        public long IdFichaAtendimentoIndividual
        {
            get { return this._idFichaAtendimentoIndividual; }
            set { SetProperty(ref _idFichaAtendimentoIndividual, value); }
        }

        //INÍCIO Ficha OutrosSia

        //Campo codigoExame - Tipo string
        private string _codigoExame; //Não Obrigatório
        public string CodigoExame
        {
            get { return this._codigoExame; }
            set { SetProperty(ref _codigoExame, value); }
        }

        //Campo solicitadoAvaliado - Tipo List<string>
        private List<string> _solicitadoAvaliado; //Obrigatório
        [MaxLength(2)] //Mínimo 1; Máximo 2
        public List<string> SolicitadoAvaliado
        {
            get { return this._solicitadoAvaliado; }
            set { SetProperty(ref _solicitadoAvaliado, value); }
        }

        //FIM Ficha OutrosSia

    }
}
