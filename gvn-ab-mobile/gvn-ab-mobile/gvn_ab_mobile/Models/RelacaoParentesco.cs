using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes; 

namespace gvn_ab_mobile.Models {
    public class RelacaoParentesco: Helpers.ObservableObject {
        private long? _codRelacaoParentesco;
        [PrimaryKey]
        public long? CodRelacaoParentesco {
            get { return this._codRelacaoParentesco; }
            set { SetProperty(ref _codRelacaoParentesco, value); }
        }

        private string _desRelacaoParentesco;
        [MaxLength(100), NotNull]
        public string DesRelacaoParentesco {
            get { return this._desRelacaoParentesco; }
            set { SetProperty(ref _desRelacaoParentesco, value); }
        }
        
        public override string ToString() {
            return $"{this.DesRelacaoParentesco}";
        }
    }
}
