using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gvn_ab_mobile.Models;

namespace gvn_ab_mobile.DAO {
    public class DAOFichaUnicaLotacaoHeader : DAO<Models.FichaUnicaLotacaoHeader> {
        public override int? CreateTable() {
            base.DropTable();
            return base.CreateTable();
        }
    }
}
