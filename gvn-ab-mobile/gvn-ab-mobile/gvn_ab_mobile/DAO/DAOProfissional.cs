using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gvn_ab_mobile.Models;

namespace gvn_ab_mobile.DAO {
    public class DAOProfissional : DAO<Models.Profissional> {
        public Models.Profissional GetUsuarioByCodigo(string CodProfissional) {
            var result = base.Select("SELECT * FROM [Usuario] WHERE [CodProfissional] = ?", CodProfissional);
            return result.FirstOrDefault();
        }
    }
}
