using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.Models {
    public class Estabelecimento : Helpers.ObservableObject {
        private long? _id;
        [PrimaryKey, AutoIncrement]
        public long? Id {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }

        public long? _codEstabelecimento;
        [NotNull, Unique]
        public long? CodEstabelecimento {
            get { return this._codEstabelecimento; }
            set { SetProperty(ref _codEstabelecimento, value); }
        }

        public string _nomEstabelecimento;
        [NotNull, Unique]
        public string NomEstabelecimento {
            get { return this._nomEstabelecimento; }
            set { SetProperty(ref _nomEstabelecimento, value); }
        }


        public override string ToString() {
            return this.NomEstabelecimento;
        }

    }
}
