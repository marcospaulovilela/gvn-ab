using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO {
    public abstract class DAO<T>
        where T : class {
        private SQLiteConnection connection;

        public DAO(string dbName = "gvn-ab.db3") {
            gvn_ab_mobile.Config.ISQLiteConfig config = Xamarin.Forms.DependencyService.Get<gvn_ab_mobile.Config.ISQLiteConfig>();
            this.connection = new SQLiteConnection(config.Platform, System.IO.Path.Combine(config.Path, dbName));
            this.connection.CreateTable<T>();
        }

        public virtual bool ValidateInsert (T obj) { return true; }
        public virtual bool ValidateUpdate (T obj) { return true; }
        public virtual bool ValidateDelete (T obj) { return true; }

        public virtual int Insert(T obj) {
            if(this.ValidateInsert(obj))
                return this.connection.Insert(obj);
            return 0;
        }
        public virtual int Update(T obj) {
            if (this.ValidateUpdate(obj))
                return this.connection.Update(obj);
            return 0;
        }
        public virtual int Delete(T obj) {
            if (this.ValidateDelete(obj))
                return this.connection.Delete(obj);
            return 0;
        }

        public virtual List<T> Select() {
            var scan = this.connection.Table<T>().ToList();
            if (scan == null)
                scan = new List<T>();

            return scan;
        }

        public virtual List<T> Select(string query, params object[] parameters) {
            return this.connection.Query<T>(query, parameters);
        }
       
        public void Dispose() {
            this.connection.Dispose();
        }

    }
}
