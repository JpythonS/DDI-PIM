using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace DDI
{
    public partial class CadastroEmpresa : Form
    {
        private string Nome;
        private string Cpf;
        private string Rg;
        private string Pis;
        private string DataNascimento;
        private string Celular;
        private string Cep;
        private string Endereco;
        private string Numero;
        private string Bairro;
        private string Cidade;
        private string Estado;
        

        public CadastroEmpresa()
        {
            InitializeComponent();
        }

        public void ObterDadosCadastroFuncionario(string nome,string cpf, string rg, string pis, string dataNascimento, string celular, string cep, string endereco, string numero, string bairro, string cidadde, string estado)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Pis = pis;
            this.Celular = celular;
            this.DataNascimento = dataNascimento;
            this.Cep = cep;
            this.Endereco = endereco;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cidade = cidadde;
            this.Estado = estado;
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
 

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você realmente deseja cancelar ?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        private async void CadastroEmpresa_Load(object sender, EventArgs e)
        {
            try
            {
                List<TipoCargo> cargos = await GetCargosAsync();
                comboBoxCargo.DataSource = cargos;
                comboBoxCargo.DisplayMember = "Valor";
                comboBoxCargo.ValueMember = "Cod";

                List<Empresa> empresas = await GetEmpresasAsync();
                comboBoxEmpresa.DataSource = empresas;
                comboBoxEmpresa.DisplayMember = "Nome";
                comboBoxEmpresa.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                // Trate erros de maneira apropriada
                MessageBox.Show($"Erro ao carregar opções de cargo: {ex.Message}");
            }
        }

        private void lblSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Você realmente deseja sair ?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        private async   void btnAvancar_Click(object sender, EventArgs e)
        {
            try
            {

                var request = new CreateFuncionarioRequest
                {
                    NomeCompleto = this.Nome,
                    DataNascimento = this.DataNascimento,
                    Endereco = this.Endereco,
                    Cpf = this.Cpf,
                    TipoCargoCod = Convert.ToInt32(comboBoxCargo.SelectedValue),
                    SalarioBase = Convert.ToDouble(textBoxSalario.Text),
                    JornadaTrabalhoSemanal = Convert.ToDouble(textBoxHorasSemana.Text),
                    UsuarioEmail = textBoxEmail.Text,
                    EmpresaId = Convert.ToInt32(comboBoxEmpresa.SelectedValue),
                    Rg = this.Rg,
                    Celular = this.Celular,
                    CelularContatoEmergencia = textBoxCelularEmergencia.Text,
                    Bairro = this.Bairro,
                    Cidade = this.Cidade,
                    Estado = this.Estado,
                    Pis = this.Pis
                };

                var response = await CadastrarFuncionarioAsync(request, Properties.Settings.Default.Token);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Funcionário cadastrado com sucesso!");
                }
                else
                {
                    MessageBox.Show($"Erro ao cadastrar funcionário. Status: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Trate erros de maneira apropriada
                MessageBox.Show($"Erro ao cadastrar funcionário: {ex.Message}");
            }
        }

        private async Task<HttpResponseMessage> CadastrarFuncionarioAsync(CreateFuncionarioRequest request, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                string requestBody = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                const string apiUrlCadastrarFuncionario = "http://localhost:5294/api/funcionario";
                return await client.PostAsync(apiUrlCadastrarFuncionario, content);
            }
        }

        private async Task<List<TipoCargo>> GetCargosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Properties.Settings.Default.Token}");
                const string apiUrlTipoCargo = "http://localhost:5294/api/tipoCargo";
                HttpResponseMessage response = await client.GetAsync(apiUrlTipoCargo);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<TipoCargo>>(responseContent);
                }
                else
                {
                    throw new Exception($"Erro na requisição à API: {response.StatusCode}");
                }
            }
        }

        private async Task<List<Empresa>> GetEmpresasAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Properties.Settings.Default.Token}");
                const string apiUrlTipoEmpresa = "http://localhost:5294/api/empresa";
                HttpResponseMessage response = await client.GetAsync(apiUrlTipoEmpresa);

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
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            menu menuCadastro = new menu();
            menuCadastro.Show();
            this.Hide();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Você já está nesta tela !", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroCargos menuCadastro = new CadastroCargos();
            menuCadastro.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AlterarExcluir alterarExcluir = new AlterarExcluir();
            alterarExcluir.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Relatorio Relatorio = new Relatorio();
            Relatorio.Show();
            this.Hide();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Relatorio Relatorio = new Relatorio();
            Relatorio.Show();
            this.Hide();
        }

        private void lblSair_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
    }

public class TipoCargo
{
    public int Cod { get; set; }
    public string Valor { get; set; }
}

public class Empresa
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

public class CreateFuncionarioRequest
{
    public string NomeCompleto { get; set; }

    public string DataNascimento { get; set; }

    public string Endereco { get; set; }

    public string Cpf { get; set; }

    public int TipoCargoCod { get; set; }
    public double SalarioBase { get; set; }

    public double JornadaTrabalhoSemanal { get; set; }

    public string UsuarioEmail { get; set; }

    public int EmpresaId { get; set; }

    public string Rg { get; set; }

    public string Celular { get; set; }

    public string CelularContatoEmergencia { get; set; }

    public string Bairro { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }

    public string Pis { get; set; }
}
