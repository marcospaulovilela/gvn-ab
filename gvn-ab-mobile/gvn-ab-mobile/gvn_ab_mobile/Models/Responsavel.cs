using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes; 

namespace gvn_ab_mobile.Models {
    public class Responsavel: Helpers.ObservableObject {
        private long? _codResponsavel;
        [PrimaryKey]
        public long? CodResponsavel {
            get { return this._codResponsavel; }
            set { SetProperty(ref _codResponsavel, value); }
        }

        private string _desResponsavel;
        [MaxLength(100), NotNull]
        public string DesResponsavel {
            get { return this._desResponsavel; }
            set { SetProperty(ref _desResponsavel, value); }
        }
        
        public override string ToString() {
            return $"{this.DesResponsavel}";
        }
    }
}
