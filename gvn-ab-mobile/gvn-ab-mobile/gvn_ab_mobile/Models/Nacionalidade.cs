using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes; 

namespace gvn_ab_mobile.Models {
    public class Nacionalidade: Helpers.ObservableObject {
        private long? _codNacionalidade;
        [PrimaryKey]
        public long? CodNacionalidade {
            get { return this._codNacionalidade; }
            set { SetProperty(ref _codNacionalidade, value); }
        }

        private string _desNacionalidade;
        [MaxLength(100), NotNull]
        public string DesNacionalidade {
            get { return this._desNacionalidade; }
            set { SetProperty(ref _desNacionalidade, value); }
        }
        
        public override string ToString() {
            return $"{this.DesNacionalidade}";
        }
    }
}
