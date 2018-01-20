using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace gvn_ab_mobile.Models {
    public class Equipe : Helpers.ObservableObject {

        private long? _id;
        [PrimaryKey, AutoIncrement]
        public long? Id {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }

        private long? codCboEquipe;
        [ForeignKey(typeof(Cbo))]
        public long? CodCboEquipe {
            get { return this.codCboEquipe; }
            set { SetProperty(ref codCboEquipe, value); }
        }

        private string codEquipe;
        [NotNull]
        public string CodEquipe {
            get { return this.codEquipe; }
            set { SetProperty(ref codEquipe, value); }
        }

        private string desEquipe;
        [MaxLength(100), NotNull]
        public string DesEquipe {
            get { return this.desEquipe; }
            set { SetProperty(ref desEquipe, value); }
        }
        
        public override string ToString() {
            return $"{this.CodEquipe} - {this.DesEquipe}";
        }
    }
}
