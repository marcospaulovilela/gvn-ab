using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes; 

namespace gvn_ab_mobile.Models {
    public class RacaCor : Helpers.ObservableObject {
        private long? _codRacaCor;
        [PrimaryKey]
        public long? CodRacaCor {
            get { return this._codRacaCor; }
            set { SetProperty(ref _codRacaCor, value); }
        }

        private string _desRacaCor;
        [MaxLength(100), NotNull]
        public string DesRacaCor {
            get { return this._desRacaCor; }
            set { SetProperty(ref _desRacaCor, value); }
        }
        
        public override string ToString() {
            return $"{this.DesRacaCor}";
        }
    }
}
