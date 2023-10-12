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
    public partial class Menu2 : Form
    {
        private string apiUrl = "http://localhost:5294/api/funcionario/";
        public Menu2()
        {
            InitializeComponent();
        }

        private void lblSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Menu2 menu2 = new Menu2();
            this.Close();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // cadastrar pessoal
            MessageBox.Show(Properties.Settings.Default.Token);

            menu menuCadastro = new menu();
            menuCadastro.Show();
            this.Hide();
        }

        private async Task<List<Funcionario>> GetFuncionariosAsync(string token)
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

        private async void Menu2_Load(object sender, EventArgs e)
        {
            try
            {
                List<Funcionario> funcionarios = await GetFuncionariosAsync(Properties.Settings.Default.Token);

                // Preencher a ListView com os resultados
                foreach (Funcionario funcionario in funcionarios)
                {

                    ColumnHeader headerNome = new ColumnHeader();
                    headerNome.Text = "Nome";
                    headerNome.Width = 100;
                    headerNome.TextAlign = HorizontalAlignment.Center;


                    ColumnHeader headerCargo = new ColumnHeader();
                    headerCargo.Text = "Cargo";
                    headerCargo.Width = 100;
                    headerCargo.TextAlign = HorizontalAlignment.Center;

                    listView1.Columns.Add(headerNome);
                    listView1.Columns.Add(headerCargo);
                    listView1.View = View.Details;

                    ListViewItem item = new ListViewItem(funcionario.Nome);
                    item.SubItems.Add(funcionario.Cargo);

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
            this.Hide();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroEmpresa menuCadastro = new CadastroEmpresa();
            menuCadastro.Show();
            this.Hide();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AlterarExcluir alterarExcluir = new AlterarExcluir();
            alterarExcluir.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Relatorio Relatorio = new Relatorio();
            Relatorio.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Cpf { get; set; }
    public string Cargo { get; set; }
    public double SalarioBase { get; set; }
    public double JornadaTrabalhoSemanal { get; set; }
    public string Email { get; set; }
    public string Empresa { get; set; }
    // Outros campos, se houver
}
