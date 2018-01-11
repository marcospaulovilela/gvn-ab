using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace gvn_ab_mobile.Helpers {
    public class RestAPI {
        string Url { get; set; }
        public RestAPI(string url) {
            this.Url = url;
        }

        public async Task<List<T>> GetAsync<T>() {
            using (HttpClient client = new HttpClient()) {
                var responseJson = await client.GetStringAsync(this.Url);
                var reponseResult = JsonConvert.DeserializeObject<List<T>>(responseJson);

                return reponseResult;
            };
        }
    }
}
