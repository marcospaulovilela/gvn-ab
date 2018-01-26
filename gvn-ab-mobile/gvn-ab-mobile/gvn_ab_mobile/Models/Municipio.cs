using SQLite;
using SQLiteNetExtensions.Attributes;

namespace gvn_ab_mobile.Models {
    public class Municipio : Helpers.ObservableObject {
        private long? codMunicipio;
        [PrimaryKey]
        public long? CodMunicipio {
            get { return this.codMunicipio; }
            set { SetProperty(ref codMunicipio, value); }
        }

        private string nomMunicipio;
        [MaxLength(100), NotNull]
        public string NomMunicipio {
            get { return this.nomMunicipio; }
            set { SetProperty(ref nomMunicipio, value); }
        }

        private long? codUnidadeFederal;
        [NotNull]
        public long? CodUnidadeFederal {
            get { return this.codUnidadeFederal; }
            set { SetProperty(ref codUnidadeFederal, value); }
        }

        [NotNull, OneToOne("CodUnidadeFederal")]
        public UnidadeFederal UnidadeFederal { get; set; }

        public override string ToString() {
            return $" {this.nomMunicipio} ";
        }
    }
}
