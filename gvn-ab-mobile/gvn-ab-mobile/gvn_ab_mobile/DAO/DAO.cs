using MoreLinq;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;

namespace gvn_ab_mobile.DAO {
    public abstract class DAO<T> : IDisposable
        where T : new () {

        private static string dbName = "gvn-ab-1.db3";
     
        protected SQLiteConnection connection;

        public DAO() {
            gvn_ab_mobile.Config.ISQLiteConfig config = Xamarin.Forms.DependencyService.Get<gvn_ab_mobile.Config.ISQLiteConfig>();
            this.connection = new SQLiteConnection(System.IO.Path.Combine(config.Path, dbName));
        }

        public virtual bool ValidateInsert(T obj) { return true; }
        public virtual bool ValidateUpdate(T obj) { return true; }
        public virtual bool ValidateDelete(T obj) { return true; }

        public virtual int? CreateTable() {
            return this.connection?.CreateTable<T>();
        }

        public bool TableExists() {
            const string cmdText = "SELECT name FROM sqlite_master WHERE type='table' AND name=?";
            var cmd = connection.CreateCommand(cmdText, typeof(T).Name);
            return cmd.ExecuteScalar<string>() != null;
        }
        
        /// <summary>
        /// Apaga a tabela do banco.
        /// </summary>
        /// <returns></returns>
        public virtual int? DropTable() {
            return this.connection?.DropTable<T>();
        }

        public virtual int? Insert(T obj) {
            if (!this.ValidateInsert(obj)) return 0;

            this.connection?.InsertWithChildren(obj, true);
            return 1;
        }

        public virtual int? Insert(IEnumerable<T> obj) {
            if (obj == null) return 0;
            
            if (new List<T>(obj).TrueForAll(o => this.ValidateInsert(o)))
                this.connection?.InsertAllWithChildren(obj, true);

            return 1;
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
            var scan = this.connection?.GetAllWithChildren<T>();
            if (scan == null)
                scan = new List<T>();

            return scan;
        }

        public T Select(long? id) {
            var obj = this.connection.Get<T>(id);
            this.connection?.GetChildren<T>(obj);

            return obj;
        }

        public List<T> Select(string query, params object[] parameters) {
            List<T> result = this.connection?.Query<T>(query, parameters);
            if (result == null) return null;

            result.ForEach(o => this.connection?.GetChildren<T>(o, true));
            return result;
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
