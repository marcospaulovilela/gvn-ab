using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gvn_ab_mobile.Models;

namespace gvn_ab_mobile.DAO {
    public class DAOLocalizacao : DAO<Models.Localizacao> {
        public override int? CreateTable() {
            base.DropTable();
            return base.CreateTable();
        }

        public List<Models.Localizacao> GetLocalizacaoByCep(string CodCep) {
            var result = base.Select("SELECT * FROM [Localizacao] WHERE [CodCep] = ?", CodCep);
            return result;
        }

        public List<Models.Localizacao> GetLocalizacaoByBairro(long? CodBairro) {
            var result = base.Select("SELECT * FROM [Localizacao] WHERE [CodBairro] = ?", CodBairro);
            return result;
        }

        public override int? Insert(Localizacao obj) {
            if (obj == null) return null;
            try {
                string cmdText = "INSERT INTO Localizacao (CodLocalizacao, CodCep, CodLogradouro, CodBairro, DesComplemento) values (?, ?, ?, ?, ?)";
                var cmd = connection.CreateCommand(cmdText, obj.CodLocalizacao, obj.CodCep, obj.CodLogradouro, obj.CodBairro, obj.DesComplemento);
                return cmd.ExecuteNonQuery();
            } catch(Exception e) {
                return null;
            };
        }

        public int? Insert(List<Localizacao> obj) {
            if (obj == null || !obj.Any()) return null;
            try {
                StringBuilder cmdText = new StringBuilder("INSERT INTO Localizacao (CodLocalizacao, CodCep, CodLogradouro, CodBairro, DesComplemento) values ");
                
                foreach(var o in obj) {
                    cmdText.Append($"('{o.CodLocalizacao}', '{o.CodCep}', '{o.CodLogradouro}', '{o.CodBairro}', '{o.DesComplemento}'),");
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
