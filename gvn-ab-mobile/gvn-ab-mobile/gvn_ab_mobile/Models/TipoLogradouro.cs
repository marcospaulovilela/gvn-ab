using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace gvn_ab_mobile.Models {
    public class TipoLogradouro : Helpers.ObservableObject {
        
        private long? codTipoLogradouro;
        [PrimaryKey]
        public long? CodTipoLogradouro {
            get { return this.codTipoLogradouro; }
            set { SetProperty(ref codTipoLogradouro, value); }
        }

        private string nomTipoLogradouro;
        [NotNull]
        public string NomTipoLogradouro {
            get { return this.nomTipoLogradouro; }
            set { SetProperty(ref nomTipoLogradouro, value); }
        }
        
        public override string ToString() {
            return $"{this.NomTipoLogradouro}";
        }
    }
}
