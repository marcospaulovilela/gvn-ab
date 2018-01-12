using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gvn_ab_mobile.Models;

namespace gvn_ab_mobile.DAO {
    public class DAOProfissional : DAO<Models.Profissional> {
        public override int? CreateTable() {
            base.DropTable();
            return base.CreateTable();
        }

        public Models.Profissional GetProfissionalByDesLogin(string DesLogin) {
            var result = base.Select("SELECT * FROM [Profissional] WHERE [DesLogin] = ?", DesLogin);
            return result.FirstOrDefault();
        }
    }
}
