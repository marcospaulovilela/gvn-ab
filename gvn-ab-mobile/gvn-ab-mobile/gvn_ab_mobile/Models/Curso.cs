using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes; 

namespace gvn_ab_mobile.Models {
    public class Curso: Helpers.ObservableObject {
        private long? _codCurso;
        [PrimaryKey]
        public long? CodCurso {
            get { return this._codCurso; }
            set { SetProperty(ref _codCurso, value); }
        }

        private string _desCurso;
        [MaxLength(100), NotNull]
        public string DesCurso {
            get { return this._desCurso; }
            set { SetProperty(ref _desCurso, value); }
        }
        
        public override string ToString() {
            return $" {this.CodCurso} - {this.DesCurso}";
        }
    }
}
