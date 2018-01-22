using SQLite;

namespace gvn_ab_mobile.Models {
    public class UnidadeFederal : Helpers.ObservableObject {
        private long? codUnidadeFederal;
        [PrimaryKey]
        public long? CodUnidadeFederal {
            get { return this.codUnidadeFederal; }
            set { SetProperty(ref codUnidadeFederal, value); }
        }

        private string nomUnidadeFederal;
        [MaxLength(100), NotNull]
        public string NomUnidadeFederal {
            get { return this.nomUnidadeFederal; }
            set { SetProperty(ref nomUnidadeFederal, value); }
        }

        private string sglUnidadeFederal;
        [MaxLength(2), NotNull]
        public string SglUnidadeFederal {
            get { return this.sglUnidadeFederal; }
            set { SetProperty(ref sglUnidadeFederal, value); }
        }

        public override string ToString() {
            return $" {this.NomUnidadeFederal}  -  {this.SglUnidadeFederal} ";
        }
    }
}
