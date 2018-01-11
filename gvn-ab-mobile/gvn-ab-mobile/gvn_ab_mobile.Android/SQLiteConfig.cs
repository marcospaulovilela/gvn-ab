[assembly:Xamarin.Forms.Dependency(typeof(gvn_ab_mobile.Droid.SQLiteConfig))]

namespace gvn_ab_mobile.Droid {
    public class SQLiteConfig : Config.ISQLiteConfig {
        private string _path;
        public string Path {
            get {
                if (string.IsNullOrEmpty(_path)) {
                    _path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return _path;
            }
        }
    }
}