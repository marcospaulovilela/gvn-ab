using SQLite;

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


        public override string ToString() {
            return $" {this.codLogradouro} - {this.NomLogradouro}";
        }
    }
}
