using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO
{
    class DAOFichaCadastroIndividual : DAO<Models.FichaCadastroIndividual>
    {

        public Models.FichaCadastroIndividual GetFichaCadastroIndividualByID(long id)
        {
            var result = base.Select("SELECT * FROM [FichaCadastroIndividual] WHERE [Id] = ?", id);
            return result.FirstOrDefault();
        }


    }
}
