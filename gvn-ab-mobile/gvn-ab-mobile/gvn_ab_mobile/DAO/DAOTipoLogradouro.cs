using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gvn_ab_mobile.Models;

namespace gvn_ab_mobile.DAO {
    public class DAOTipoLogradouro : DAO<Models.TipoLogradouro> {
        public override int? CreateTable() {
            base.DropTable();
            return base.CreateTable();
        }

        public override int? Insert(TipoLogradouro obj) {
            if (obj == null) return null;
            try {
                string cmdText = "INSERT INTO TipoLogradouro (CodTipoLogradouro, NomTipoLogradouro) values (?, ?)";
                var cmd = connection.CreateCommand(cmdText, obj.CodTipoLogradouro, obj.NomTipoLogradouro);
                return cmd.ExecuteNonQuery();
            } catch(Exception e) {
                return null;
            };
        }

        public int? Insert(List<TipoLogradouro> obj) {
            if (obj == null || !obj.Any()) return null;
            try {
                StringBuilder cmdText = new StringBuilder("INSERT INTO TipoLogradouro (CodTipoLogradouro, NomTipoLogradouro) values ");
                
                foreach(var o in obj) {
                    cmdText.Append($"('{o.CodTipoLogradouro}', '{o.NomTipoLogradouro.Replace("'", "\'")}'),");
                }
                cmdText[cmdText.Length - 1] = ' ';

                var cmd = connection.CreateCommand(cmdText.ToString());
                var result = cmd.ExecuteNonQuery();

                this.connection.Commit();
                return result;

            } catch (Exception e) {
                return null;
            };
        }

    }
}
