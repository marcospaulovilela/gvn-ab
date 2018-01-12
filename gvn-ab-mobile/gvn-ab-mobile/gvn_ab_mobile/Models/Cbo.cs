using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace gvn_ab_mobile.Models {
    public class Cbo : Helpers.ObservableObject {

        private long? _id;
        [PrimaryKey, AutoIncrement]
        public long? Id {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }
        
        private long? codProfissionalCbo;
        [ForeignKey(typeof(Profissional))]
        public long? CodProfissionalCbo {
            get { return this.codProfissionalCbo; }
            set { SetProperty(ref codProfissionalCbo, value); }
        }

        private string codCbo;
        [NotNull]
        public string CodCbo {
            get { return this.codCbo; }
            set { SetProperty(ref codCbo, value); }
        }

        private string nomCbo;
        [MaxLength(100), NotNull]
        public string NomCbo {
            get { return this.nomCbo; }
            set { SetProperty(ref nomCbo, value); }
        }

        public override string ToString() {
            return $"{this.CodCbo} - {this.NomCbo}";
        }
    }
}
