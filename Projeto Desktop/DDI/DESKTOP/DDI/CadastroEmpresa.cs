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
        private readonly HttpClient httpClient;
        private readonly string apiUrlTipoCargo = "http://localhost:5294/api/tipoCargo";
        private readonly string apiUrlTipoUsuario = "http://localhost:5294/api/tipoUsuario";

        private global::CadastroFuncionario Funcionario;

        public CadastroEmpresa()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Properties.Settings.Default.Token}");
        }

        public void ObterDadosCadastroFuncionario(global::CadastroFuncionario funcionario)
        {
            Funcionario = funcionario;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CadastroFuncionario menu = new CadastroFuncionario();
            menu.definirDadosSalvosAnteriormente(Funcionario);
            menu.Show();
            this.Close();
        }

        private async void CadastroEmpresa_Load(object sender, EventArgs e)
        {
            try
            {
                List<TipoGenerico> cargos = await GetTipoGenericoAsync(apiUrlTipoCargo);
                comboBoxCargo.DataSource = cargos;
                comboBoxCargo.DisplayMember = "Valor";
                comboBoxCargo.ValueMember = "Cod";
                comboBoxCargo.SelectedIndex = -1;

                List<Empresa> empresas = await GetEmpresasAsync();
                comboBoxEmpresa.DataSource = empresas;
                comboBoxEmpresa.DisplayMember = "Nome";
                comboBoxEmpresa.ValueMember = "Id";
                comboBoxEmpresa.SelectedIndex = -1;

                List<TipoGenerico> niveisPermissaoUsuario = await GetTipoGenericoAsync(apiUrlTipoUsuario);
                comboBoxNivelPermissao.DataSource = niveisPermissaoUsuario;
                comboBoxNivelPermissao.DisplayMember = "Valor";
                comboBoxNivelPermissao.ValueMember = "Cod";
                comboBoxNivelPermissao.SelectedIndex = -1;
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

        private async void btnAvancar_Click(object sender, EventArgs e)
        {
            try
            {            
                var request = new CreateFuncionarioRequest
                {
                    NomeCompleto = Funcionario.Nome,
                    DataNascimento = Funcionario.DataNascimento,
                    Endereco = Funcionario.Endereco,
                    Cpf = Funcionario.Cpf,
                    TipoCargoCod = Convert.ToInt32(comboBoxCargo.SelectedValue),
                    SalarioBase = Convert.ToDouble(textBoxSalario.Text),
                    JornadaTrabalhoSemanal = Convert.ToDouble(textBoxHorasSemana.Text),
                    UsuarioEmail = textBoxEmail.Text,
                    EmpresaId = Convert.ToInt32(comboBoxEmpresa.SelectedValue),
                    Rg = Funcionario.Rg,
                    Celular = Funcionario.Celular,
                    CelularContatoEmergencia = Funcionario.CelularEmergencia,
                    Bairro = Funcionario.Bairro,
                    Cidade = Funcionario.Cidade,
                    Estado = Funcionario.Estado,
                    Pis = Funcionario.Pis
                };

                var response = await CadastrarFuncionarioAsync(request);

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

        private async Task<HttpResponseMessage> CadastrarFuncionarioAsync(CreateFuncionarioRequest request)
        {
            string requestBody = JsonConvert.SerializeObject(request);
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            const string apiUrlCadastrarFuncionario = "http://localhost:5294/api/funcionario";
            return await httpClient.PostAsync(apiUrlCadastrarFuncionario, content);
        }

        private async Task<List<TipoGenerico>> GetTipoGenericoAsync(string apiUrl)
        {                  
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

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

        private async Task<List<Empresa>> GetEmpresasAsync()
        {
            const string apiUrlTipoEmpresa = "http://localhost:5294/api/empresa";
            HttpResponseMessage response = await httpClient.GetAsync(apiUrlTipoEmpresa);

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

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroFuncionario menuCadastro = new CadastroFuncionario();
            menuCadastro.Show();
            this.Close();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Você já está nesta tela !", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroCargos menuCadastro = new CadastroCargos();
            menuCadastro.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Consulta alterarExcluir = new Consulta();
            alterarExcluir.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Relatorio Relatorio = new Relatorio();
            Relatorio.Show();
            this.Close();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Relatorio Relatorio = new Relatorio();
            Relatorio.Show();
            this.Close();
        }

        private void lblSair_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool result = ModalService.ExibirModalSairSistema();

            if (result)
            {
                Login form1 = new Login();
                form1.Show();
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Menu menu2 = new Menu();
            menu2.Show();
            this.Close();
        }

        private void linkLabelFuncionarios_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Você realmente deseja cancelar ?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        private void linkLabelEmpresasCargos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroCargos menuCadastro = new CadastroCargos();
            menuCadastro.Show();
            this.Close();
        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Relatorio Relatorio = new Relatorio();
            Relatorio.Show();
            this.Close();
        }

        private void linkLabelGetFuncionario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Consulta alterarExcluir = new Consulta();
            alterarExcluir.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSair_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool result = ModalService.ExibirModalSairSistema();

            if (result)
            {
                Login form1 = new Login();
                form1.Show();
                this.Close();
            }
        }
    }
    }
    

public class TipoGenerico
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
