using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gvn_ab_mobile.Models;

namespace gvn_ab_mobile.DAO {
    public class DAOOcupacao : DAO<Models.Ocupacao> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return 1;
        }
    }
}
