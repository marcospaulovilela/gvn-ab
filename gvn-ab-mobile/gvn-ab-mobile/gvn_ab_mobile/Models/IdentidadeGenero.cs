using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes; 

namespace gvn_ab_mobile.Models {
    public class IdentidadeGenero: Helpers.ObservableObject {
        private long? _codIdentidadeGenero;
        [PrimaryKey]
        public long? CodIdentidadeGenero {
            get { return this._codIdentidadeGenero; }
            set { SetProperty(ref _codIdentidadeGenero, value); }
        }

        private string _desIdentidadeGenero;
        [MaxLength(100), NotNull]
        public string DesIdentidadeGenero {
            get { return this._desIdentidadeGenero; }
            set { SetProperty(ref _desIdentidadeGenero, value); }
        }
        
        public override string ToString() {
            return $"{this.DesIdentidadeGenero}";
        }
    }
}
