using SQLite;

namespace gvn_ab_mobile.Models
{
    public class FichaHeader : Helpers.ObservableObject
    {

        //Campo ID - Tipo long
        private long? _id;
        [PrimaryKey, AutoIncrement] //Chave Primária com incremento automático
        public long? Id
        {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }

        //INÍCIO FICHA HEADER

        //Campo cnsProfissional - Tipo string
        private string _cnsProfissional; //Obrigatório
        [NotNull]
        public string CnsProfissional
        {
            get { return this._cnsProfissional; }
            set { SetProperty(ref _cnsProfissional, value); }
        }

        //Campo cbo - Tipo string
        private string _cbo; //Obrigatório
        [NotNull]
        public string Cbo
        {
            get { return this._cbo; }
            set { SetProperty(ref _cbo, value); }
        }

        //Campo cnes - Tipo string
        private string _cnes; //Obrigatório
        [NotNull]
        public string Cnes
        {
            get { return this._cnes; }
            set { SetProperty(ref _cnes, value); }
        }

        //Campo ine - Tipo string
        private string _ine; //Obrigatório
        [NotNull]
        public string Ine
        {
            get { return this._ine; }
            set { SetProperty(ref _ine, value); }
        }

        //FIM FICHA HEADER

    }
}
