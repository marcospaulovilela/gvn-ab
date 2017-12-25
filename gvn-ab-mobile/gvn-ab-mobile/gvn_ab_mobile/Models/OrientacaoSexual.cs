using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes; 

namespace gvn_ab_mobile.Models {
    public class OrientacaoSexual: Helpers.ObservableObject {
        private long? _codOrientacaoSexual;
        [PrimaryKey]
        public long? CodOrientacaoSexual {
            get { return this._codOrientacaoSexual; }
            set { SetProperty(ref _codOrientacaoSexual, value); }
        }

        private string _desOrientacaoSexual;
        [MaxLength(100), NotNull]
        public string DesOrientacaoSexual {
            get { return this._desOrientacaoSexual; }
            set { SetProperty(ref _desOrientacaoSexual, value); }
        }
        
        public override string ToString() {
            return $"{this.DesOrientacaoSexual}";
        }
    }
}
