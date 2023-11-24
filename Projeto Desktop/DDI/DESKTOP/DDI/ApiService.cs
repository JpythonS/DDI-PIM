﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public async Task<List<Funcionario>> GetFuncionariosAsync(string apiUrl)
        {
            
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

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

        public async Task AtualizarFolhaDePagamento()
        {
            string apiUrl = "http://localhost:5294/api/pagamento/gerar-pagamentos";

            // Criar instância HttpClient
           
            
                try
                {
                    // Pode ser necessário configurar cabeçalhos, parâmetros, etc., dependendo da API
                    // Exemplo: client.DefaultRequestHeaders.Add("Chave", "Valor");

                    // Dados a serem enviados (se necessário)
                    // Exemplo: var dados = new { chave1 = "valor1", chave2 = "valor2" };

                    // Converta os dados para JSON (se necessário)
                    // Exemplo: var json = JsonConvert.SerializeObject(dados);

                    // Criação do conteúdo da requisição
                    // Exemplo: var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

                    // Enviar a requisição HTTP POST
                    HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, null); // Substitua 'null' pelo conteúdo se necessário

                    // Verificar se a requisição foi bem-sucedida
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Requisição bem-sucedida!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    

