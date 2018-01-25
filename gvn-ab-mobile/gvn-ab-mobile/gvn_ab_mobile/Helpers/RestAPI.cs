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

        public async Task<bool> PostAsync(object obj) {
            using (HttpClient client = new HttpClient()) {

                var uri = new Uri(this.Url);
                var json = JsonConvert.SerializeObject(obj);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(uri, content);
                return response.IsSuccessStatusCode;
            };
        }
    }
}
