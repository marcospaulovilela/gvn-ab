using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.Config {
    public interface ISQLiteConfig {
        string Path { get; }
        SQLite.Net.Interop.ISQLitePlatform Platform { get; }
    }
}
