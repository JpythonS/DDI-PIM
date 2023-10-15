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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        public void definirDadosSalvosAnteriormente(CadastroFuncionario funcionario)
        {
            txtNome.Text = funcionario.Nome;
            txtCpf.Text = funcionario.Cpf;
            txtRg.Text = funcionario.Rg;
            txtPis.Text = funcionario.Pis;
            txtData.Text = funcionario.DataNascimento;
            txtCel.Text = funcionario.Celular;
            textBoxCelEmergencia.Text = funcionario.CelularEmergencia;
            txtEndereco.Text = funcionario.Endereco;
            txtNumero.Text = funcionario.Numero;
            txtBairro.Text = funcionario.Bairro;
            txtCidade.Text = funcionario.Cidade;
            txtEstado.Text = funcionario.Estado;
        }

        private void lblSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Close();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Você realmente deseja cancelar ?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        private void lblSair_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Você realmente deseja sair ?", "Atenção!",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você realmente deseja cancelar ?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Você já está nesta tela !", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void lblSair_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool result = ModalService.ExibirModalSairSistema();

            if (result)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AlterarExcluir alterarExcluir = new AlterarExcluir();
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastroFuncionario cadastroFuncionario = new CadastroFuncionario 
            {
                Nome = txtNome.Text,
                Cpf = txtCpf.Text,
                Rg = txtRg.Text,
                Pis = txtPis.Text,
                DataNascimento = txtData.Text,
                Celular = txtCel.Text,
                CelularEmergencia = textBoxCelEmergencia.Text,
                Endereco = txtEndereco.Text,
                Numero = txtNumero.Text,
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                Estado = txtEstado.Text

            };

            CadastroEmpresa cadastroEmpresa = new CadastroEmpresa();
            cadastroEmpresa.ObterDadosCadastroFuncionario(cadastroFuncionario);
            cadastroEmpresa.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Menu2 menu2 = new Menu2();
            menu2.Show();
            this.Close();
        }
    }
}

public class CadastroFuncionario
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Rg { get; set; }
    public string Pis { get; set; }
    public string DataNascimento { get; set; }
    public string Celular { get; set; }
    public string CelularEmergencia { get; set; }
    public string Cep { get; set; }
    public string Endereco { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
}
