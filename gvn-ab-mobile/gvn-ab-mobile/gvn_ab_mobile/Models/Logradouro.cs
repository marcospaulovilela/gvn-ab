using SQLite;
using SQLiteNetExtensions.Attributes;

namespace gvn_ab_mobile.Models {
    public class Logradouro: Helpers.ObservableObject {
        private long? codLogradouro;
        [PrimaryKey]
        public long? CodLogradouro {
            get { return this.codLogradouro; }
            set { SetProperty(ref codLogradouro, value); }
        }

        private string nomLogradouro;
        [MaxLength(100), NotNull]
        public string NomLogradouro {
            get { return this.nomLogradouro; }
            set { SetProperty(ref nomLogradouro, value); }
        }

        private long? codTipoLogradouro;
        [NotNull]
        public long? CodTipoLogradouro  {
            get { return this.codTipoLogradouro; }
            set { SetProperty(ref codTipoLogradouro, value); }
        }

        [NotNull, OneToOne("CodTipoLogradouro")]
        public TipoLogradouro TipoLogradouro { get; set; }

        public override string ToString() {
            return $" {this.TipoLogradouro?.NomTipoLogradouro ?? ""} {this.NomLogradouro}".Trim();
        }
    }
}
