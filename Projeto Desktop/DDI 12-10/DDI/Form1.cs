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
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient;

        public Form1()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo e-mail.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(txtSenha.Text == "") {
                MessageBox.Show("Obrigatório informar o campo senha.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            string apiUrl = "http://localhost:5294/api/auth/login";
            var requestData = new {Email = txtLogin.Text, Senha = txtSenha.Text};

            try
            {
                HttpResponseMessage response = await LoginAsync(apiUrl, requestData);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<string>(responseContent);

                    MessageBox.Show(result);
                }
            } catch( Exception ex) {
                MessageBox.Show(ex.Message);

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
