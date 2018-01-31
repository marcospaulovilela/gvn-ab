using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO {
    public class DAOFichaFamilia : DAO<Models.FichaFamilia> {

        public override int? CreateTable()
        {
            //base.DropTable();
            return base.CreateTable();
        }

    }
}
