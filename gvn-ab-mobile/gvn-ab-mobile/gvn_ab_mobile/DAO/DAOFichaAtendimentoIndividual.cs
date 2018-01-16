using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO {
    class DAOFichaAtendimentoIndividual : DAO<Models.FichaAtendimentoIndividual> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            return base.CreateTable();
        }
    }
}
