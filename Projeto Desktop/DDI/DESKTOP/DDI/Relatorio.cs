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
        public Relatorio()
        {
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
            MessageBox.Show("Você realmente deseja cancelar ?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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
    }
}
