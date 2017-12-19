using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO
{
    class DAOFichaOutrosSia : DAO<Models.FichaOutrosSia>
    {

        public Models.FichaOutrosSia GetFichaOutrosSiaByID(long id)
        {
            var result = base.Select("SELECT * FROM [FichaOutrosSia] WHERE [Id] = ?", id);
            return result.FirstOrDefault();
        }


    }
}
