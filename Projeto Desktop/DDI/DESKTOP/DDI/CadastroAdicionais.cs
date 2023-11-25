using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDI
{
    public partial class CadastroAdicionais : Form
    {
        private ApiService apiService;
        public CadastroAdicionais()
        {
            InitializeComponent();
            apiService = new ApiService();
        }

        private async void CadastroAdicionais_Load(object sender, EventArgs e)
        {
            string apiUrlTipoAdicional = "http://localhost:5294/api/tipoAdicional";
            string apiUrlTipoDesconto = "http://localhost:5294/api/tipoDesconto";
            try
            {
                List<TipoGenerico> adicional = await apiService.GetTipoGenericoAsync(apiUrlTipoAdicional);
                comboAdicional.DataSource = adicional;
                comboAdicional.DisplayMember = "Valor";
                comboAdicional.ValueMember = "Cod";
                comboAdicional.SelectedIndex = -1;

                List<TipoGenerico> desconto = await apiService.GetTipoGenericoAsync(apiUrlTipoDesconto);
                comboDesconto.DataSource = desconto;
                comboDesconto.DisplayMember = "Valor";
                comboDesconto.ValueMember = "Cod";
                comboDesconto.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                // Trate erros de maneira apropriada
                MessageBox.Show($"Erro ao carregar opções de ComboBox: {ex.Message}");
            }
        }

        private async void btnCadastroAdicional_Click(object sender, EventArgs e)
        {
            try
            {
                const string apiUrlTipoAdicional = "http://localhost:5294/api/tipoAdicional";
                HttpResponseMessage response = await apiService.PostTipoGenericoAsync(apiUrlTipoAdicional, txtAdicional.Text);


                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Adicional cadastrado com sucesso!");
                    txtAdicional.Text = "";
                    List<TipoGenerico> adicional = await apiService.GetTipoGenericoAsync(apiUrlTipoAdicional);
                    comboAdicional.DataSource = adicional;
                    comboAdicional.SelectedIndex = -1;
                }
                else if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    MessageBox.Show("Adicional já existente!");
                }
                else
                {
                    MessageBox.Show($"Erro na requisição POST. Status: {response.StatusCode}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na requisição POST. Status: {ex}");
            }
        }

        private async void btnCadastroDesconto_Click(object sender, EventArgs e)
        {
            try
            {
                const string apiUrlTipoDesconto = "http://localhost:5294/api/tipoDesconto";
                HttpResponseMessage response = await apiService.PostTipoGenericoAsync(apiUrlTipoDesconto, txtDesconto.Text);


                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Desconto cadastrado com sucesso!");
                    txtDesconto.Text = "";
                    List<TipoGenerico> desconto = await apiService.GetTipoGenericoAsync(apiUrlTipoDesconto);
                    comboDesconto.DataSource = desconto;
                    comboDesconto.SelectedIndex = -1;
                }
                else if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    MessageBox.Show("Desconto já existente!");
                }
                else
                {
                    MessageBox.Show($"Erro na requisição POST. Status: {response.StatusCode}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na requisição POST. Status: {ex}");
            }
        }
    }
}
