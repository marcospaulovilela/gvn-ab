using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gvn_ab_mobile.Models;

namespace gvn_ab_mobile.DAO {
    public class DAOOcupacao : DAO<Models.Ocupacao> {
        public override int? CreateTable() {
            base.DropTable();
            return base.CreateTable();
        }

        public override int? Insert(Ocupacao obj) {
            if (obj == null) return null;
            try {
                string cmdText = "INSERT INTO OCupacao (CodOcupacao, DesOcupacao) values (?, ?)";
                var cmd = connection.CreateCommand(cmdText, obj.CodOcupacao, obj.DesOcupacao);
                return cmd.ExecuteNonQuery();
            } catch(Exception e) {
                return null;
            };
        }

        public int? Insert(List<Ocupacao> obj) {
            if (obj == null || !obj.Any()) return null;
            try {
                StringBuilder cmdText = new StringBuilder("INSERT INTO OCupacao (CodOcupacao, DesOcupacao) values ");
                
                foreach(var o in obj) {
                    cmdText.Append($"('{o.CodOcupacao}', '{o.DesOcupacao.Replace("'", "\'")}'),");
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
