using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDI
{
    public partial class Relatorio : Form
    {
        private readonly ApiService apiService;
        public Relatorio()
        {
            apiService = new ApiService();
            InitializeComponent();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Consulta alterarExcluir = new Consulta();
            alterarExcluir.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Você já está nesta tela !", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Você já está nesta tela !", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Você já está nesta tela!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void linkLabelGetFuncionario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Consulta alterarExcluir = new Consulta();
            alterarExcluir.Show();
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
            // cadastrar pessoal
            CadastroFuncionario menuCadastro = new CadastroFuncionario();
            menuCadastro.Show();
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

        private async void Relatorio_Load(object sender, EventArgs e)
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
                List<Funcionario> funcionarios = await apiService.GetFuncionariosAsync(Properties.Settings.Default.Token, ApiService.API_URL_FUNCIONARIO);

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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
