using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes; 

namespace gvn_ab_mobile.Models {
    public class SituacaoMercado: Helpers.ObservableObject {
        private long? _codSituacaoMercado;
        [PrimaryKey]
        public long? CodSituacaoMercado {
            get { return this._codSituacaoMercado; }
            set { SetProperty(ref _codSituacaoMercado, value); }
        }

        private string _desSituacaoMercado;
        [MaxLength(100), NotNull]
        public string DesSituacaoMercado {
            get { return this._desSituacaoMercado; }
            set { SetProperty(ref _desSituacaoMercado, value); }
        }
        
        public override string ToString() {
            return $"{this.DesSituacaoMercado}";
        }
    }
}
