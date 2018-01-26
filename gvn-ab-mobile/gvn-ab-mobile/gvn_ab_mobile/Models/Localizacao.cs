using SQLite;
using SQLiteNetExtensions.Attributes;

namespace gvn_ab_mobile.Models {
    public class Localizacao: Helpers.ObservableObject {
        private long? codLocalizacao;
        [PrimaryKey]
        public long? CodLocalizacao {
            get { return this.codLocalizacao; }
            set { SetProperty(ref codLocalizacao, value); }
        }
        
        [NotNull]
        public string CodCep { get; set; }

        public long? CodLogradouro { get; set; }
        [NotNull, OneToOne("CodLogradouro")]
        public Logradouro Logradouro{ get; set; }

        public long? CodBairro { get; set; }
        [NotNull, OneToOne("CodBairro")]
        public Bairro Bairro { get; set; }

        [NotNull]
        public string DesComplemento  { get; set; }
    }
}
