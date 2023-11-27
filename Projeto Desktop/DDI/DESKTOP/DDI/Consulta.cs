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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DDI
{
    public partial class Consulta : Form
    {
        private readonly HttpClient httpClient;
        private readonly ApiService apiService;

        public Consulta()
        {
            InitializeComponent();
            apiService = new ApiService();
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Properties.Settings.Default.Token}");
        }

        private async void AlterarExcluir_Load(object sender, EventArgs e)
        {
            const string apiUrlTipoCargo = "http://localhost:5294/api/tipoCargo";
            const string apiUrlTipoUsuario = "http://localhost:5294/api/tipoUsuario";

            List<TipoGenerico> cargos = await apiService.GetTipoGenericoAsync(apiUrlTipoCargo);
            comboBoxCargo.DataSource = cargos;
            comboBoxCargo.ValueMember = "Cod";
            comboBoxCargo.DisplayMember = "Valor";
            comboBoxCargo.SelectedIndex = -1;

            List<TipoGenerico> niveisDePermissao = await apiService.GetTipoGenericoAsync(apiUrlTipoUsuario);
            comboBoxNivelPermissao.DataSource = niveisDePermissao;
            comboBoxNivelPermissao.ValueMember = "Cod";
            comboBoxNivelPermissao.DisplayMember = "Valor";
            comboBoxNivelPermissao.SelectedIndex = -1;

            List<Empresa> empresas = await apiService.GetEmpresasAsync();
            comboBoxEmpresa.DataSource = empresas;
            comboBoxEmpresa.ValueMember = "Id";
            comboBoxEmpresa.DisplayMember = "Nome";
            comboBoxEmpresa.SelectedIndex = -1;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroFuncionario menuCadastro = new CadastroFuncionario();
            menuCadastro.Show();
            this.Close();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroEmpresa menuCadastro = new CadastroEmpresa();
            menuCadastro.Show();
            this.Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroCargos menuCadastro = new CadastroCargos();
            menuCadastro.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Você já está nesta tela !", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void lblSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(textBoxMatricula.Text, out int id))
                {
                    List<Funcionario> funcionarios = await BuscarFuncionarioAsync(id);

                    if (funcionarios.ToArray().Length == 1)
                    {
                        PreencherCamposComFuncionario(funcionarios.First());
                    }
                    else
                    {
                        MessageBox.Show("Funcionário não encontrado.");
                    }
                }
                else
                {
                    MessageBox.Show("ID inválido. Insira um número válido na caixa de texto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private async Task<List<Funcionario>> BuscarFuncionarioAsync(int id)
        {
            // Construa a URL completa com o ID como um parâmetro de consulta.
            string apiUrl = $"http://localhost:5294/api/funcionario?id={id}";

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Funcionario>>(json);
            }

            return null;
        }

        private void PreencherCamposComFuncionario(Funcionario funcionario)
        {
            textBoxNome.Text = funcionario.Nome;
            textBoxCel.Text = funcionario.Celular;
            textBoxCelEmergencial.Text = funcionario.CelularContatoEmergencia;
            textBoxBairro.Text = funcionario.Bairro;
            textBoxCidade.Text = funcionario.Cidade;
            textBoxEstado.Text = funcionario.Estado;
            textBoxSalario.Text = funcionario.SalarioBase.ToString();
            textBoxEndereco.Text = funcionario.Endereco;       
            textBoxEmail.Text = funcionario.Email;
            comboBoxCargo.Text = funcionario.Cargo;
            comboBoxEmpresa.Text = funcionario.Empresa;
            comboBoxNivelPermissao.Text = funcionario.NivelPermissao;
        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            bool result = ModalService.ExibirModalExclusao();

            if (result && int.TryParse(textBoxMatricula.Text, out int id))
            {
                string apiUrl = $"http://localhost:5294/api/funcionario/{id}";
                HttpResponseMessage response = await httpClient.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Funcionário excluído com sucesso.");
                }
                else
                {
                    MessageBox.Show("Erro ao excluir o funcionário: " + response.ReasonPhrase);
                }
            }
            else
            {
                MessageBox.Show("ID inválido. Insira um número válido na caixa de texto.");
            }
        }

        private async void btnAvancar_Click(object sender, EventArgs e)
        {

            if (int.TryParse(textBoxMatricula.Text, out int id))
            {

                UpdateFuncionarioRequest funcionario = new UpdateFuncionarioRequest();            

                if (textBoxNome.Text != "")
                    funcionario.NomeCompleto = textBoxNome.Text;

                if (textBoxCel.Text != "")
                    funcionario.Celular = textBoxCel.Text;

                if (textBoxCelEmergencial.Text != "")
                    funcionario.CelularContatoEmergencia = textBoxCelEmergencial.Text;

                if (textBoxEndereco.Text != "")
                    funcionario.Endereco = textBoxEndereco.Text;

                if (textBoxBairro.Text != "")
                    funcionario.Bairro = textBoxBairro.Text;

                if (textBoxCidade.Text != "")
                    funcionario.Cidade = textBoxCidade.Text;

                if (textBoxEstado.Text != "")
                    funcionario.Estado = textBoxEstado.Text;

                if (comboBoxCargo.SelectedIndex != -1)
                    funcionario.Cargo = comboBoxCargo.SelectedValue.ToString();

                if (textBoxSalario.Text != "")
                    funcionario.SalarioBase = textBoxSalario.Text;

                if (comboBoxEmpresa.SelectedIndex != -1)
                    funcionario.Empresa = comboBoxEmpresa.SelectedValue.ToString();

                try 
                {
                    var response = await AtualizarFuncionarioAsync(funcionario, id.ToString());

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Funcionário atualizado com sucesso!");
                    }
                    else
                    {
                        string requestBody = JsonConvert.SerializeObject(funcionario);
                        MessageBox.Show("Erro ao atualizar funcionário");
                    }
                } catch  
                {
                    MessageBox.Show("Erro ao acessar a API: ");
                }

            }
            else
            {
                MessageBox.Show("ID inválido. Insira um número válido na caixa de texto.");
            }

            //if (textBoxNumero.Text != "")
            //    funcionario.Numero = textBoxNumero.Text;
        }

        private async Task<HttpResponseMessage> AtualizarFuncionarioAsync(UpdateFuncionarioRequest funcionario, string id)
        {
            string requestBody = JsonConvert.SerializeObject(funcionario);
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            string apiUrlCadastrarFuncionario = "http://localhost:5294/api/funcionario/atualizar/" + id;
            return await httpClient.PostAsync(apiUrlCadastrarFuncionario, content);
        }

        private void linkLabelFuncionarios_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // cadastrar pessoal
            CadastroFuncionario menuCadastro = new CadastroFuncionario();
            menuCadastro.Show();
            this.Close();
        }

        private void linkLabelEmpresasCargos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroCargos menuCadastro = new CadastroCargos();
            menuCadastro.Show();
            this.Close();
        }

        private void linkLabelGetFuncionario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Você já está nesta tela!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
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

        private void linkLabel4_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Relatorio Relatorio = new Relatorio();
            Relatorio.Show();
            this.Close();
        }

        private void linkLabelGetFuncionario_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Você já está nesta tela!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroAdicionais menuAdicionais = new CadastroAdicionais();
            menuAdicionais.Show();
            this.Close();
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void linkLabelFuncionarios_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroFuncionario menuCadastro = new CadastroFuncionario();
            menuCadastro.Show();
            this.Close();
        }

        private void linkLabelEmpresasCargos_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroCargos menuCadastro = new CadastroCargos();
            menuCadastro.Show();
            this.Close();
        }
    }
    }



public class UpdateFuncionarioRequest 
{
    public string NomeCompleto { get; set; }
    public string Endereco { get; set; }
    public string Celular { get; set; }
    public string CelularContatoEmergencia { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cargo { get; set; }
    public string SalarioBase { get; set; }
    public string Empresa { get; set; }
}
