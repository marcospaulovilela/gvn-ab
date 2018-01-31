using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO
{
    class DAOFichaCadastroIndividual : DAO<Models.FichaCadastroIndividual>
    {
        public override int? CreateTable()
        {
            //base.DropTable();
            return base.CreateTable();
        }
    }
}
