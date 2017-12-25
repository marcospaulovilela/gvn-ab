using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes; 

namespace gvn_ab_mobile.Models {
    public class Etinia: Helpers.ObservableObject {
        private long? _codEtinia;
        [PrimaryKey]
        public long? CodEtinia {
            get { return this._codEtinia; }
            set { SetProperty(ref _codEtinia, value); }
        }

        private string _desEtinia;
        [MaxLength(100), NotNull]
        public string DesEtinia {
            get { return this._desEtinia; }
            set { SetProperty(ref _desEtinia, value); }
        }
        
        public override string ToString() {
            return $"{this.DesEtinia}";
        }
    }
}
