using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO
{
    class DAOFichaFamilia : DAO<Models.FichaFamilia>
    {

        public Models.FichaFamilia GetFichaFamiliaByID(long id)
        {
            var result = base.Select("SELECT * FROM [FichaFamilia] WHERE [Id] = ?", id);
            return result.FirstOrDefault();
        }


    }
}
