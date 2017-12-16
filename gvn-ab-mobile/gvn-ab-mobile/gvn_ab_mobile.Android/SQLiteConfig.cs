using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net.Interop;

[assembly:Xamarin.Forms.Dependency(typeof(gvn_ab_mobile.Droid.SQLiteConfig))]

namespace gvn_ab_mobile.Droid {
    public class SQLiteConfig : Config.ISQLiteConfig {
        private string _path;
        private SQLite.Net.Interop.ISQLitePlatform _platform;

        public string Path {
            get {
                if (string.IsNullOrEmpty(_path)) {
                    _path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return _path;
            }
        }

        public ISQLitePlatform Platform {
            get {
                if (_platform == null) {
                    _platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return _platform;
            }
        }
    }
}