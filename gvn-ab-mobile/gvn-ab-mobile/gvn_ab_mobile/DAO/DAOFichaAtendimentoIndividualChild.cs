using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO
{
    class DAOFichaAtendimentoIndividualChild : DAO<Models.FichaAtendimentoIndividualChild>
    {

        public Models.FichaAtendimentoIndividualChild GetFichaAtendimentoIndividualChildByID(long id)
        {
            var result = base.Select("SELECT * FROM [FichaAtendimentoIndividualChild] WHERE [Id] = ?", id);
            return result.FirstOrDefault();
        }


    }
}
