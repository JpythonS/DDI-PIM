﻿using System;
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
    public partial class CadastroCargos : Form
    {
        private readonly HttpClient httpClient;

        public CadastroCargos()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Properties.Settings.Default.Token}");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Você já está nesta tela !", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            menu menuCadastro = new menu();
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

        private void lblSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool result = ModalService.ExibirModalSairSistema();

            if (result)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Menu2 menu2 = new Menu2();
            menu2.Show();
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                const string apiUrlTipoCargo = "http://localhost:5294/api/tipoCargo";
                StringContent content = new StringContent($"{{\"valor\":\"{txtCargo.Text}\"}}", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(apiUrlTipoCargo, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cargo cadastrado com sucesso!");
                    txtCargo.Text = "";
                }
                else
                {
                    MessageBox.Show($"Erro na requisição POST. Status: {response.StatusCode}");
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Erro na requisição POST. Status: {ex.Message}");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                const string apiUrlEmpresa = "http://localhost:5294/api/empresa";
                StringContent content = new StringContent($"{{\"nome\":\"{textBoxNome.Text}\",\"cnpj\":\"{textBoxCnpj.Text}\"}}", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(apiUrlEmpresa, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Empresa cadastrada com sucesso!");
                    textBoxNome.Text = "";
                    textBoxCnpj.Text = "";
                }
                else
                {
                    MessageBox.Show($"Erro na requisição POST. Status: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na requisição POST. Status: {ex.Message}");
            }
        }
    }
}
