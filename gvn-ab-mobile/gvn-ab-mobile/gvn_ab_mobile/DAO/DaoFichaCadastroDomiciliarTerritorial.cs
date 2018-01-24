using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO {
    class DAOFichaCadastroDomiciliarTerritorial : DAO<Models.FichaCadastroDomiciliarTerritorial> {

        public override int? CreateTable()
        {
            base.DropTable();
            return base.CreateTable();
        }

    }
}
