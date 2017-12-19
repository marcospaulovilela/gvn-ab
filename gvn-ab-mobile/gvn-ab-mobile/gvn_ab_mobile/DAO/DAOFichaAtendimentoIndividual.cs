using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO
{
    class DAOFichaAtendimentoIndividual : DAO<Models.FichaAtendimentoIndividual>
    {

        public Models.FichaAtendimentoIndividual GetFichaAtendimentoIndividualByID(long id)
        {
            var result = base.Select("SELECT * FROM [FichaAtendimentoIndividual] WHERE [Id] = ?", id);
            return result.FirstOrDefault();
        }


    }
}
