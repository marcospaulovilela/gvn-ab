using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gvn_ab_mobile.Models;

namespace gvn_ab_mobile.DAO {
    public class DAOLogradouro : DAO<Models.Logradouro> {
        public override int? CreateTable() {
            base.DropTable();
            return base.CreateTable();
        }

        public override int? Insert(Logradouro obj) {
            if (obj == null) return null;
            try {
                string cmdText = "INSERT INTO Logradouro (CodLogradouro, NomLogradouro, CodTipoLogradouro) values (?, ?, ?)";
                var cmd = connection.CreateCommand(cmdText, obj.CodLogradouro, obj.NomLogradouro, obj.CodTipoLogradouro);
                return cmd.ExecuteNonQuery();
            } catch(Exception e) {
                return null;
            };
        }

        public int? Insert(List<Logradouro> obj) {
            if (obj == null || !obj.Any()) return null;
            try {
                StringBuilder cmdText = new StringBuilder("INSERT INTO Logradouro (CodLogradouro, NomLogradouro, CodTipoLogradouro) values ");
                
                foreach(var o in obj) {
                    cmdText.Append($"('{o.CodLogradouro}', '{o.NomLogradouro}', '{o.CodTipoLogradouro}'),");
                }
                cmdText[cmdText.Length - 1] = ' ';

                var cmd = connection.CreateCommand(cmdText.ToString());
                return cmd.ExecuteNonQuery();
            } catch (Exception e) {
                return null;
            };
        }

    }
}
