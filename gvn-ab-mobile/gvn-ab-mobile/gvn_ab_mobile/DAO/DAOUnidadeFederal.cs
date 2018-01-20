using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gvn_ab_mobile.Models;

namespace gvn_ab_mobile.DAO {
    public class DAOUnidadeFederal : DAO<Models.UnidadeFederal> {
        public override int? CreateTable() {
            base.DropTable();
            return base.CreateTable();
        }

        public override int? Insert(UnidadeFederal obj) {
            if (obj == null) return null;
            try {
                string cmdText = "INSERT INTO UnidadeFederal (CodUnidadeFederal, NomUnidadeFederal, SglUnidadeFederal) values (?, ?, ?)";
                var cmd = connection.CreateCommand(cmdText, obj.CodUnidadeFederal, obj.NomUnidadeFederal, obj.SglUnidadeFederal);
                return cmd.ExecuteNonQuery();
            } catch(Exception e) {
                return null;
            };
        }

        public int? Insert(List<UnidadeFederal> obj) {
            if (obj == null || !obj.Any()) return null;
            try {
                StringBuilder cmdText = new StringBuilder("INSERT INTO UnidadeFederal (CodUnidadeFederal, NomUnidadeFederal, SglUnidadeFederal) values ");
                
                foreach(var o in obj) {
                    cmdText.Append($"('{o.CodUnidadeFederal}', '{o.NomUnidadeFederal}', '{o.SglUnidadeFederal}'),");
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
