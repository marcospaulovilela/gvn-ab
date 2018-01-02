using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO {
    public abstract class DAO<T> : IDisposable
        where T : class {

        private static string dbName = "gvn-ab.db3";
        /// <summary>
        /// Apaga todo o banco de dados (CUIDADO!!, Com sabedoria usar você deve.)
        /// </summary>
        /// <returns></returns>
        public static int? DropDatabase() {
            gvn_ab_mobile.Config.ISQLiteConfig config = Xamarin.Forms.DependencyService.Get<gvn_ab_mobile.Config.ISQLiteConfig>();
            using (var connection = new SQLiteConnection(config.Platform, System.IO.Path.Combine(config.Path, dbName))) {
                List<string> tables = new List<string>(){
                    "Pais", "RacaCor", "Etnia", "OrientacaoSexual", "Curso", "RelacaoParentesco", "Responsavel", "Sexo", "MotivoSaida", "Nacionalidade", "SituacaoMercado", "IdentidadeGenero", "Usuario"
                };
                
                connection.BeginTransaction();
                try {
                    foreach (var table in tables) {
                        connection.Execute($"DROP TABLE IF EXISTS {table}");
                    };
                    connection.Commit();

                    return connection?.Execute("VACUUM");
                } catch (Exception e) {
                    connection.Rollback();
                    return null;
                } finally {
                    connection.Close();
                };
            };
        }

        private SQLiteConnection connection;

        public DAO() {
            gvn_ab_mobile.Config.ISQLiteConfig config = Xamarin.Forms.DependencyService.Get<gvn_ab_mobile.Config.ISQLiteConfig>();
            this.connection = new SQLiteConnection(config.Platform, System.IO.Path.Combine(config.Path, dbName));
        }

        public virtual bool ValidateInsert(T obj) { return true; }
        public virtual bool ValidateUpdate(T obj) { return true; }
        public virtual bool ValidateDelete(T obj) { return true; }

        public virtual int? CreateTable() {
            return this.connection?.CreateTable<T>();
        }

        /// <summary>
        /// Apaga a tabela do banco.
        /// </summary>
        /// <returns></returns>
        public virtual int? DropTable() {
            return this.connection?.DropTable<T>();
        }

        public virtual int? Insert(T obj) {
            if (this.ValidateInsert(obj))
                return this.connection?.Insert(obj);
            return 0;
        }

        public virtual int? Insert(List<T> obj) {
            if (obj.TrueForAll(o => this.ValidateInsert(o)))
                return this.connection?.InsertAll(obj);

            return 0;
        }

        public virtual int? Update(T obj) {
            if (this.ValidateUpdate(obj))
                return this.connection?.Update(obj);
            return 0;
        }

        /// <summary>
        /// Deleta todos os dados da tabela.
        /// </summary>
        /// <returns></returns>
        public virtual int? Delete() {
            return this.connection?.DeleteAll<T>();
        }

        /// <summary>
        /// Deleta o registro equivalente na tabela
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual int? Delete(T obj) {
            if (this.ValidateDelete(obj))
                return this.connection?.Delete(obj);
            return 0;
        }

        public List<T> Select() {
            var scan = this.connection?.Table<T>().ToList();
            if (scan == null)
                scan = new List<T>();

            return scan;
        }

        public T Select(long id) {
            return this.connection?.Get<T>(id);
        }

        public List<T> Select(string query, params object[] parameters) {
            return this.connection?.Query<T>(query, parameters);
        }

        public void ClearTable() {
            this.connection?.DeleteAll<T>();
        }

        public int? Execute (string query, params object[] parameters) {
            var command = this.connection.CreateCommand(query, parameters);
            return command?.ExecuteNonQuery();
        }

        public void Dispose() {
            this.connection?.Dispose();
        }

    }
}
