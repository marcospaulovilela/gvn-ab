﻿using SQLite;
using SQLiteNetExtensions.Attributes;

namespace gvn_ab_mobile.Models {
    public class Estabelecimento : Helpers.ObservableObject {
        private long? id;
        [PrimaryKey, AutoIncrement]
        public long? Id {
            get { return this.id; }
            set { SetProperty(ref id, value); }
        }

        private long? codUnidade;
        [NotNull, Unique]
        public long? CodUnidade {
            get { return this.codUnidade; }
            set { SetProperty(ref codUnidade, value); }
        }

        private string impCnes;
        [NotNull, Unique]
        public string ImpCnes {
            get { return this.impCnes; }
            set { SetProperty(ref impCnes, value); }
        }

        private string desNomFantasia;
        [NotNull, Unique]
        public string DesNomFantasia {
            get { return this.desNomFantasia; }
            set { SetProperty(ref desNomFantasia, value); }
        }

        private long? codMunicipio;
        public long? CodMunicipio {
            get { return this.codMunicipio; }
            set { SetProperty(ref codMunicipio, value); }
        }

        [OneToOne("CodMunicipio")]
        public Municipio Municipio { get; set; }

        public override string ToString() {
            return this.DesNomFantasia;
        }

    }
}
