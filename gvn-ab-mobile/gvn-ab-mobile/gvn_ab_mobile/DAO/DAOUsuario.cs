using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gvn_ab_mobile.Models;

namespace gvn_ab_mobile.DAO {
    public class DAOUsuario : DAO<Models.Usuario> {
        public Models.Usuario GetUsuarioByCpf(string cpf) {
            var result = base.Select("SELECT * FROM [Usuario] WHERE [Cpf] = ?", cpf);
            return result.FirstOrDefault();
        }
    }
}
