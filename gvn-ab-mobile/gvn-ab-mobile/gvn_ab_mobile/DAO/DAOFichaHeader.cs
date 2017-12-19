using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO
{
    class DAOFichaHeader : DAO<Models.FichaHeader>
    {

        public Models.FichaHeader GetFichaHeaderByID(long id)
        {
            var result = base.Select("SELECT * FROM [FichaHeader] WHERE [Id] = ?", id);
            return result.FirstOrDefault();
        }


    }
}
