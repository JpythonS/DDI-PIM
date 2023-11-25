using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;


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
                List<Funcionario> funcionarios = await apiService.GetFuncionariosAsync(ApiService.API_URL_FUNCIONARIO);

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

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:5294/api/empresa/relatorio-funcionarios";
            List<RelatorioEmpresa>dadosrelatorioempresa = await apiService.GetRelatorioEmpresaAsync(apiUrl);
            GerarRelatorioExcel(dadosrelatorioempresa);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:5294/api/funcionario";
            List<Funcionario> dadosrelatoriofunionario = await apiService.GetFuncionariosAsync(apiUrl);
            GerarRelatorioFuncionarioExcel(dadosrelatoriofunionario);
        }

        private void GerarRelatorioExcel(List<RelatorioEmpresa> dados)
        {
            // Crie um novo pacote Excel.
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                // Crie uma planilha Excel.
                var worksheet = package.Workbook.Worksheets.Add("Empresas");

                // Adicione cabeçalhos à planilha.
                worksheet.Cells["A1"].Value = "Empresa";
                worksheet.Cells["B1"].Value = "Media Salarial";
                worksheet.Cells["C1"].Value = "Soma Salarial";
                worksheet.Cells["D1"].Value = "Quantidade de funcionarios";
                // Adicione outras colunas conforme necessário.

                // Preencha os dados da API na planilha.
                for (int i = 0; i < dados.Count; i++)
                {
                    var empresa = dados[i];
                    int linha = i + 2; // Comece na linha 2 para evitar sobrescrever os cabeçalhos.

                    worksheet.Cells["A" + linha].Value = empresa.NomeEmpresa;
                    worksheet.Cells["B" + linha].Value = empresa.MediaSalarial;
                    worksheet.Cells["C" + linha].Value = empresa.SomaSalarial;
                    worksheet.Cells["D" + linha].Value = empresa.QuantidadeFuncionarios;
                    // Preencha outras colunas conforme necessário.
                }

                // Salve a planilha em um arquivo Excel.
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Arquivo Excel (*.xlsx)|*.xlsx",
                    FileName = "RelatorioEmpresas.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var file = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(file);
                }
            }
        }

        private void GerarRelatorioFuncionarioExcel(List<Funcionario> dados)
        {
            // Crie um novo pacote Excel.
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                // Crie uma planilha Excel.
                var worksheet = package.Workbook.Worksheets.Add("Empresas");

                // Adicione cabeçalhos à planilha.
                worksheet.Cells["A1"].Value = "Id";
                worksheet.Cells["B1"].Value = "Nome";
                worksheet.Cells["C1"].Value = "CPF";
                worksheet.Cells["D1"].Value = "RG";
                worksheet.Cells["E1"].Value = "Data de Nascimento";
                worksheet.Cells["F1"].Value = "Celular";
                worksheet.Cells["G1"].Value = "Endereco";
                worksheet.Cells["H1"].Value = "Cidade";
                worksheet.Cells["I1"].Value = "Estado";
                worksheet.Cells["J1"].Value = "Empresa";
                worksheet.Cells["K1"].Value = "Salario";
                worksheet.Cells["L1"].Value = "Cargo";
                // Adicione outras colunas conforme necessário.

                // Preencha os dados da API na planilha.
                for (int i = 0; i < dados.Count; i++)
                {
                    Funcionario funcionario = dados[i];
                    int linha = i + 2; // Comece na linha 2 para evitar sobrescrever os cabeçalhos.

                    worksheet.Cells["A" + linha].Value = funcionario.Id;
                    worksheet.Cells["B" + linha].Value = funcionario.Nome;
                    worksheet.Cells["C" + linha].Value = funcionario.Cpf;
                    worksheet.Cells["D" + linha].Value = funcionario.Rg;
                    worksheet.Cells["E" + linha].Value = funcionario.DataNascimento;
                    worksheet.Cells["F" + linha].Value = funcionario.Celular;
                    worksheet.Cells["G" + linha].Value = funcionario.Endereco;
                    worksheet.Cells["H" + linha].Value = funcionario.Cidade;
                    worksheet.Cells["I" + linha].Value = funcionario.Estado;
                    worksheet.Cells["J" + linha].Value = funcionario.Empresa;
                    worksheet.Cells["K" + linha].Value = funcionario.SalarioBase;
                    worksheet.Cells["L" + linha].Value = funcionario.Cargo;
                    
                    // Preencha outras colunas conforme necessário.
                }

                // Salve a planilha em um arquivo Excel.
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Arquivo Excel (*.xlsx)|*.xlsx",
                    FileName = "RelatorioFuncionarios.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var file = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(file);
                }
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroAdicionais menuAdicionais = new CadastroAdicionais();
            menuAdicionais.Show();
            this.Close();
        }
    }
}

public class RelatorioEmpresa
{
    public string NomeEmpresa { get; set; }
    public double MediaSalarial { get; set; }
    public double SomaSalarial { get; set; }
    public int QuantidadeFuncionarios { get; set; }
}