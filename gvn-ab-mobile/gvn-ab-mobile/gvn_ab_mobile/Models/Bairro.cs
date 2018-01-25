using SQLite;
using SQLiteNetExtensions.Attributes;

namespace gvn_ab_mobile.Models {
    public class Bairro : Helpers.ObservableObject {
        private long? codBairro;
        [PrimaryKey]
        public long? CodBairro {
            get { return this.codBairro; }
            set { SetProperty(ref codBairro, value); }
        }

        private string nomBairro;
        [NotNull]
        public string NomBairro {
            get { return this.nomBairro; }
            set { SetProperty(ref nomBairro, value); }
        }

        private long? codMunicipio;
        [NotNull]
        public long? CodMunicipio {
            get { return this.codMunicipio; }
            set { SetProperty(ref codMunicipio, value); }
        }

        public override string ToString() {
            return $" {this.nomBairro} ";
        }
    }
}
