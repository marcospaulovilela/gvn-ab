using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes; 

namespace gvn_ab_mobile.Models {
    public class Ocupacao: Helpers.ObservableObject {
        private string _codOcupacao;
        [PrimaryKey]
        public string CodOcupacao {
            get { return this._codOcupacao; }
            set { SetProperty(ref _codOcupacao, value); }
        }

        private string _desOcupacao;
        [MaxLength(100), NotNull]
        public string DesOcupacao {
            get { return this._desOcupacao; }
            set { SetProperty(ref _desOcupacao, value); }
        }
        
        public override string ToString() {
            return $" {this.CodOcupacao} - {this.DesOcupacao}";
        }
    }
}
