using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace gvn_ab_mobile.Helpers {
    public class PostResult {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
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

        public async Task<PostResult> PostAsync(Models.FichaVisitaDomiciliarTerritorial obj) {
            return await this.PostAsync(new {
                tipoFicha = "FichaVisitaDomiciliarTerritorial", objDados = obj
            });
        }

        public async Task<PostResult> PostAsync(Models.FichaCadastroDomiciliarTerritorial obj) {
            return await this.PostAsync(new {
                tipoFicha = "FichaCadastroDomiciliarTerritorial", objDados = obj
            });
        }

        public async Task<PostResult> PostAsync(Models.FichaCadastroIndividual obj) {
            return await this.PostAsync(new {
                tipoFicha = "FichaCadastroIndividual", objDados = obj
            });
        }


        public async Task<PostResult> PostAsync(object obj) {
            using (HttpClient client = new HttpClient()) {
                var result = new PostResult();

                var uri = new Uri(this.Url);
                var json = JsonConvert.SerializeObject(obj);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, content);

                if (result.Status = response.IsSuccessStatusCode){
                    string buffer = await response.Content.ReadAsStringAsync();
                    if(String.Compare(buffer, "ack", StringComparison.CurrentCulture) != 0) {
                        result.Status = false;
                        result.Message = buffer.Replace("nack|", "");
                    };
                };

                return result;
            };
        }

        public void Dispose() { }
    }
}
