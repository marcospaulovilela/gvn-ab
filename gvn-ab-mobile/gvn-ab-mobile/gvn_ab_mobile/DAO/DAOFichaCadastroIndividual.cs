using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO {
    public class DAOFichaCadastroIndividual : DAO<Models.FichaCadastroIndividual> {
        public override int? CreateTable()
        {
            return base.CreateTable();
        }

        public List<Models.FichaCadastroIndividual> GetAllFichas()
        {
            var result = base.Select("SELECT * FROM [FichasCadastroIndividual]");
            return result;
        }

        public Models.FichaCadastroIndividual GetFichaFromUuid(string uuid)
        {
            var result = base.Select("SELECT * FROM [FichasCadastroIndividual] WHERE [Uuid] = ?", uuid);
            return result.FirstOrDefault();
        }
    }
}
