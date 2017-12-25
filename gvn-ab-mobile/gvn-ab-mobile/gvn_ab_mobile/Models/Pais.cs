using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes; 

namespace gvn_ab_mobile.Models {
    public class Pais: Helpers.ObservableObject {
        private long? _codPais;
        [PrimaryKey]
        public long? CodPais {
            get { return this._codPais; }
            set { SetProperty(ref _codPais, value); }
        }

        private string _desPais;
        [MaxLength(100), NotNull]
        public string DesPais {
            get { return this._desPais; }
            set { SetProperty(ref _desPais, value); }
        }
        
        public override string ToString() {
            return $"{this.DesPais}";
        }
    }
}
