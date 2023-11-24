using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDI
{
    public partial class Login : Form
    {
        private readonly HttpClient httpClient;

        public Login()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            this.Load += Login_Load;
        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo e-mail.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(txtSenha.Text == "") {
                MessageBox.Show("Obrigatório informar o campo senha.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string apiUrl = "http://localhost:5294/api/auth/login";
            var requestData = new {Email = txtLogin.Text, Senha = txtSenha.Text};

            try
            {
                HttpResponseMessage response = await LoginAsync(apiUrl, requestData);

                string responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<LoginResponse>(responseContent);

                if (response.IsSuccessStatusCode && result.Token.Length > 0)
                {
                    Properties.Settings.Default.Token = result.Token;
                    Properties.Settings.Default.Save();


                    Menu menu2 = new Menu();
                    menu2.Show();
                    this.Hide();    
                } else {
                    MessageBox.Show("Credenciais incorretas. Por favor, tente novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch {
                MessageBox.Show("Credenciais incorretas. Por favor, tente novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private async Task<HttpResponseMessage> LoginAsync(string apiUrl, object requestData)
        {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, apiUrl))
            {
                string jsonContent = JsonConvert.SerializeObject(requestData);
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                return await httpClient.SendAsync(request);
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnEntrar;
        }
    }
}

public class LoginResponse
{
    public string Token { get; set; }
    // Outros campos da resposta, se houver
}
