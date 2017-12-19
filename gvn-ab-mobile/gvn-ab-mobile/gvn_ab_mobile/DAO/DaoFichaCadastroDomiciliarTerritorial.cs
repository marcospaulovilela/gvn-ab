using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO
{
    class DAOFichaCadastroDomiciliarTerritorial : DAO<Models.FichaCadastroDomiciliarTerritorial>
    {

        public Models.FichaCadastroDomiciliarTerritorial GetFichaCadastroDomiciliarTerritorialByID(long id)
        {
            var result = base.Select("SELECT * FROM [FichaCadastroDomiciliarTerritorial] WHERE [Id] = ?", id);
            return result.FirstOrDefault();
        }


    }
}
