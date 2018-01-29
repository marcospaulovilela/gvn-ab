using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace gvn_ab_mobile.Helpers {
    public class RestAPI : IDisposable {
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

        public async Task<bool> PostAsync(Models.FichaVisitaDomiciliarTerritorial obj) {
            return await this.PostAsync(new {
                tipoFicha = "FichaVisitaDomiciliarTerritorial", objDados = obj
            });
        }

        public async Task<bool> PostAsync(Models.FichaCadastroDomiciliarTerritorial obj) {
            return await this.PostAsync(new {
                tipoFicha = "FichaCadastroDomiciliarTerritorial", objDados = obj
            });
        }

        public async Task<bool> PostAsync(Models.FichaCadastroIndividual obj) {
            return await this.PostAsync(new {
                tipoFicha = "FichaCadastroIndividual", objDados = obj
            });
        }


        public async Task<bool> PostAsync(object obj) {
            using (HttpClient client = new HttpClient()) {

                var uri = new Uri(this.Url);
                var json = JsonConvert.SerializeObject(obj);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode) return false;

                string result = await response.Content.ReadAsStringAsync();
                return String.Compare(result, "ack", StringComparison.CurrentCulture) == 0;
            };
        }

        public void Dispose() { }
    }
}
