﻿using System.Collections.Generic;

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

        private string codProfissional;
        [MaxLength(11), NotNull, Unique]
        public string CodProfissional {
            get { return this.codProfissional; }
            set { SetProperty(ref codProfissional, value); }
        }

        private string nomProfissional;
        [MaxLength(100), NotNull]
        public string NomProfissional {
            get { return this.nomProfissional; }
            set { SetProperty(ref nomProfissional, value); }
        }

        private List<Models.Cbo> cbos;
        [OneToMany]
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
            return $"{this.codProfissional} - {this.nomProfissional}";
        }
    }
}
