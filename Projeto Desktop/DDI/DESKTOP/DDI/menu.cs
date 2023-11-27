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

namespace DDI
{
    public partial class Menu : Form
    {
        private readonly string apiUrl = "http://localhost:5294/api/funcionario/";
        private readonly ApiService apiService;
        public Menu()
        {
            apiService = new ApiService();
            InitializeComponent();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // cadastrar pessoal
            CadastroFuncionario menuCadastro = new CadastroFuncionario();
            menuCadastro.Show();
            this.Close();
        }

        private async void Menu2_Load(object sender, EventArgs e)
        {

            ColumnHeader headerMatricula = new ColumnHeader()
            {
                Text = "Matrícula",
                Width = 100,
                TextAlign = HorizontalAlignment.Center
            };

            ColumnHeader headerNome = new ColumnHeader()
            {
                Text = "Nome",
                Width = 200,
                TextAlign = HorizontalAlignment.Center
            };


            ColumnHeader headerCargo = new ColumnHeader()
            {
                Text = "Cargo",
                Width = 100,
                TextAlign = HorizontalAlignment.Center
            };

            ColumnHeader headerEmpresa = new ColumnHeader()
            {
                Text = "Empresa",
                Width = 100,
                TextAlign = HorizontalAlignment.Center
            };

            listView1.Columns.Add(headerMatricula);
            listView1.Columns.Add(headerNome);
            listView1.Columns.Add(headerCargo);
            listView1.Columns.Add(headerEmpresa);
            listView1.View = View.Details;

            try
            {
                List<Funcionario> funcionarios = await apiService.GetFuncionariosAsync(apiUrl);

                // Preencher a ListView com os resultados
                foreach (Funcionario funcionario in funcionarios)
                {
                    ListViewItem item = new ListViewItem(funcionario.Id.ToString());
                    item.SubItems.Add(funcionario.Nome);
                    item.SubItems.Add(funcionario.Cargo);
                    item.SubItems.Add(funcionario.Empresa);
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                // Trate erros de maneira apropriada
                MessageBox.Show($"Erro ao obter funcionários: {ex.Message}");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroCargos menuCadastro = new CadastroCargos();
            menuCadastro.Show();
            this.Close();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroEmpresa menuCadastro = new CadastroEmpresa();
            menuCadastro.Show();
            this.Close();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Consulta alterarExcluir = new Consulta();
            alterarExcluir.Show();
            this.Close();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Relatorio Relatorio = new Relatorio();
            Relatorio.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
           await apiService.AtualizarFolhaDePagamento();
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

        private void linkLabelGetFuncionario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
                Consulta alterarExcluir = new Consulta();
                alterarExcluir.Show();
                this.Close();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroAdicionais menuAdicionais = new CadastroAdicionais();
            menuAdicionais.Show();
            this.Close();
        }

        private void linkLabelEmpresasCargos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroCargos menuCadastro = new CadastroCargos();
            menuCadastro.Show();
            this.Close();
        }

        private void linkLabelFuncionarios_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroFuncionario menuCadastro = new CadastroFuncionario();
            menuCadastro.Show();
            this.Close();
        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Relatorio Relatorio = new Relatorio();
            Relatorio.Show();
            this.Close();
        }
    }

}

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string DataNascimento { get; set; }
    public string Endereco { get; set; }
    public string Cpf { get; set; }
    public string Rg { get; set; }
    public string Celular { get; set; } 
    public string CelularContatoEmergencia { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Pis { get; set; }
    public string Cargo { get; set; }
    public double SalarioBase { get; set; }
    public double JornadaTrabalhoSemanal { get; set; }
    public string Email { get; set; }
    public string Empresa { get; set; }
    public string NivelPermissao { get; set; }
}
    
