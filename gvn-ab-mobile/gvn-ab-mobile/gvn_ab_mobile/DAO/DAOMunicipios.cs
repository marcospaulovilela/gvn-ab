using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gvn_ab_mobile.Models;

namespace gvn_ab_mobile.DAO {
    public class DAOMunicipio : DAO<Models.Municipio> {
        public override int? CreateTable() {
            base.DropTable();
            return base.CreateTable();
        }

        public List<Models.Municipio> GetByCodUnidadeFederal(long? CodUnidadeFederal) {
            var result = base.Select("SELECT * FROM [Municipio] WHERE [CodUnidadeFederal] = ?", CodUnidadeFederal);
            return result;
        }

        public override int? Insert(Municipio obj) {
            if (obj == null) return null;
            try {
                string cmdText = "INSERT INTO Municipio (CodMunicipio, NomMunicipio, CodUnidadeFederal) values (?, ?, ?)";
                var cmd = connection.CreateCommand(cmdText, obj.CodMunicipio, obj.NomMunicipio, obj.CodUnidadeFederal);
                return cmd.ExecuteNonQuery();
            } catch(Exception e) {
                throw e;
            };
        }

        public int? Insert(List<Municipio> obj) {
            if (obj == null || !obj.Any()) return null;
            try {
                StringBuilder cmdText = new StringBuilder("INSERT INTO Municipio (CodMunicipio, NomMunicipio, CodUnidadeFederal) values ");
                
                foreach(var o in obj) {
                    cmdText.Append($"('{o.CodMunicipio}', '{o.NomMunicipio.Replace("'", "''")}', '{o.CodUnidadeFederal}'),");
                }
                cmdText[cmdText.Length - 1] = ' ';

                var cmd = connection.CreateCommand(cmdText.ToString());
                var result = cmd.ExecuteNonQuery();

                this.connection.Commit();
                return result;

            } catch (Exception e) {
                throw e;
            };
        }

    }
}
