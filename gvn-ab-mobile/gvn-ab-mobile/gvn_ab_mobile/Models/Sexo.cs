using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes; 

namespace gvn_ab_mobile.Models {
    public class Sexo: Helpers.ObservableObject {
        private long? _codSexo;
        [PrimaryKey]
        public long? CodSexo {
            get { return this._codSexo; }
            set { SetProperty(ref _codSexo, value); }
        }

        private string _desSexo;
        [MaxLength(100), NotNull]
        public string DesSexo {
            get { return this._desSexo; }
            set { SetProperty(ref _desSexo, value); }
        }
        
        public override string ToString() {
            return $"{this.DesSexo}";
        }
    }
}
