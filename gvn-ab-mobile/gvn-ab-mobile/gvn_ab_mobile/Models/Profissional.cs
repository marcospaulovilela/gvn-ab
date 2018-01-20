using System.Collections.Generic;

using SQLite;
using SQLiteNetExtensions.Attributes;

namespace gvn_ab_mobile.Models {
    public class Profissional : Helpers.ObservableObject {
        private long? id;
        [PrimaryKey, AutoIncrement]
        public long? Id {
            get { return this.id; }
            set { SetProperty(ref id, value); }
        }

        private string cpfProfissional;
        [MaxLength(11), NotNull]
        public string CpfProfissional {
            get { return this.cpfProfissional; }
            set { SetProperty(ref cpfProfissional, value); }
        }

        private string cnsProfissional;
        [MaxLength(15), NotNull]
        public string CnsProfissional {
            get { return this.cnsProfissional; }
            set { SetProperty(ref cnsProfissional, value); }
        }

        private string desLogin;
        [NotNull, Unique]
        public string DesLogin {
            get { return this.desLogin; }
            set { SetProperty(ref desLogin, value); }
        }

        private string nomProfissional;
        [MaxLength(100), NotNull]
        public string NomProfissional {
            get { return this.nomProfissional; }
            set { SetProperty(ref nomProfissional, value); }
        }

        private List<Models.Cbo> cbos;
        [OneToMany("CodProfissionalCbo", null, CascadeOperations = CascadeOperation.All)]
        public List<Models.Cbo> Cbos {
            get { return this.cbos; }
            set { SetProperty(ref cbos, value); }
        }

        private string desSenha;
        [MaxLength(100), NotNull]
        public string DesSenha {
            get { return this.desSenha; }
            set { SetProperty(ref desSenha, value); }
        }
        
        public override string ToString() {
            return $"{this.cpfProfissional} - {this.nomProfissional}";
        }
    }
}
