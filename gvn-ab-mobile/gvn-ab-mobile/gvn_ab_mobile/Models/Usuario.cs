using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes; 

namespace gvn_ab_mobile.Models {
    public class Usuario : Helpers.ObservableObject {
        private long? _id;
        [PrimaryKey, AutoIncrement]
        public long? Id {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }

        private string _cpf;
        [MaxLength(11), NotNull, Unique]
        public string Cpf {
            get { return this._cpf; }
            set { SetProperty(ref _cpf, value); }
        }

        private string _nome;
        [MaxLength(100), NotNull]
        public string Nome {
            get { return this._nome; }
            set { SetProperty(ref _nome, value); }
        }

        private string _password;
        [MaxLength(100), NotNull]
        public string Password {
            get { return this._password; }
            set { SetProperty(ref _password, value); }
        }

        private bool _root;
        [NotNull]
        public bool Root {
            get { return this._root; }
            set { SetProperty(ref this._root, value); }
        }

        public override string ToString() {
            return $"{this.Cpf} - {this.Nome}";
        }
    }
}
