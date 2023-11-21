using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DDI
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public static readonly string API_URL_FUNCIONARIO = "http://localhost:5294/api/funcionario/";

        public ApiService() 
        { 
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Properties.Settings.Default.Token}");
        }

        public async Task<List<Empresa>> GetEmpresasAsync()
        {
            const string apiUrlTipoEmpresa = "http://localhost:5294/api/empresa";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrlTipoEmpresa);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Empresa>>(responseContent);
            }
            else
            {
                throw new Exception($"Erro na requisição à API: {response.StatusCode}");
            }
        }

        public async Task<List<Funcionario>> GetFuncionariosAsync(string token, string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Funcionario>>(responseContent);
                }
                else
                {
                    throw new Exception($"Erro na requisição à API: {response.StatusCode}");
                }
            }
        }

        public async Task<List<TipoGenerico>> GetTipoGenericoAsync(string apiUrl)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TipoGenerico>>(responseContent);
            }
            else
            {
                throw new Exception($"Erro na requisição à API: {response.StatusCode}");
            }
        }
        public async Task<List<RelatorioEmpresa>> GetRelatorioEmpresaAsync(string apiUrl)
        {

            
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<RelatorioEmpresa>>(responseContent);
                }
                else
                {
                    throw new Exception($"Erro na requisição à API: {response.StatusCode}");
                }
        }
    }
}
