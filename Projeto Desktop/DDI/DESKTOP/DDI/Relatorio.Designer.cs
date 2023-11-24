namespace DDI
{
    partial class Relatorio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Relatorio));
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnRelatorio1 = new System.Windows.Forms.Button();
            this.btnRelatorio2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabelEmpresasCargos = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabelGetFuncionario = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabelFuncionarios = new System.Windows.Forms.LinkLabel();
            this.lblSair = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(219, 248);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(769, 317);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnRelatorio1
            // 
            this.btnRelatorio1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatorio1.Location = new System.Drawing.Point(219, 87);
            this.btnRelatorio1.Name = "btnRelatorio1";
            this.btnRelatorio1.Size = new System.Drawing.Size(217, 34);
            this.btnRelatorio1.TabIndex = 14;
            this.btnRelatorio1.Text = "Relatorio de empresas";
            this.btnRelatorio1.UseVisualStyleBackColor = true;
            this.btnRelatorio1.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnRelatorio2
            // 
            this.btnRelatorio2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatorio2.Location = new System.Drawing.Point(219, 142);
            this.btnRelatorio2.Name = "btnRelatorio2";
            this.btnRelatorio2.Size = new System.Drawing.Size(217, 34);
            this.btnRelatorio2.TabIndex = 15;
            this.btnRelatorio2.Text = "Relatório de funcionários";
            this.btnRelatorio2.UseVisualStyleBackColor = true;
            this.btnRelatorio2.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 108;
            this.label1.Text = "Relatórios";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.linkLabelEmpresasCargos);
            this.panel1.Controls.Add(this.linkLabel4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.linkLabelGetFuncionario);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.linkLabelFuncionarios);
            this.panel1.Controls.Add(this.lblSair);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 609);
            this.panel1.TabIndex = 111;
            // 
            // linkLabelEmpresasCargos
            // 
            this.linkLabelEmpresasCargos.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(135)))), ((int)(((byte)(26)))));
            this.linkLabelEmpresasCargos.AutoSize = true;
            this.linkLabelEmpresasCargos.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelEmpresasCargos.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelEmpresasCargos.LinkColor = System.Drawing.Color.Black;
            this.linkLabelEmpresasCargos.Location = new System.Drawing.Point(10, 226);
            this.linkLabelEmpresasCargos.Name = "linkLabelEmpresasCargos";
            this.linkLabelEmpresasCargos.Size = new System.Drawing.Size(131, 17);
            this.linkLabelEmpresasCargos.TabIndex = 107;
            this.linkLabelEmpresasCargos.TabStop = true;
            this.linkLabelEmpresasCargos.Text = "Empresas e Cargos";
            this.linkLabelEmpresasCargos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelEmpresasCargos_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(135)))), ((int)(((byte)(26)))));
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel4.LinkColor = System.Drawing.Color.Black;
            this.linkLabel4.Location = new System.Drawing.Point(10, 338);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(136, 17);
            this.linkLabel4.TabIndex = 104;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Relatório de gestão";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 23);
            this.label6.TabIndex = 103;
            this.label6.Text = "Relatório";
            // 
            // linkLabelGetFuncionario
            // 
            this.linkLabelGetFuncionario.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(135)))), ((int)(((byte)(26)))));
            this.linkLabelGetFuncionario.AutoSize = true;
            this.linkLabelGetFuncionario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelGetFuncionario.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelGetFuncionario.LinkColor = System.Drawing.Color.Black;
            this.linkLabelGetFuncionario.Location = new System.Drawing.Point(10, 282);
            this.linkLabelGetFuncionario.Name = "linkLabelGetFuncionario";
            this.linkLabelGetFuncionario.Size = new System.Drawing.Size(83, 17);
            this.linkLabelGetFuncionario.TabIndex = 102;
            this.linkLabelGetFuncionario.TabStop = true;
            this.linkLabelGetFuncionario.Text = "Funcionário";
            this.linkLabelGetFuncionario.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGetFuncionario_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 23);
            this.label5.TabIndex = 101;
            this.label5.Text = "Consulta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 100;
            this.label4.Text = "Cadastro";
            // 
            // linkLabelFuncionarios
            // 
            this.linkLabelFuncionarios.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(135)))), ((int)(((byte)(26)))));
            this.linkLabelFuncionarios.AutoSize = true;
            this.linkLabelFuncionarios.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelFuncionarios.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelFuncionarios.LinkColor = System.Drawing.Color.Black;
            this.linkLabelFuncionarios.Location = new System.Drawing.Point(10, 201);
            this.linkLabelFuncionarios.Name = "linkLabelFuncionarios";
            this.linkLabelFuncionarios.Size = new System.Drawing.Size(88, 17);
            this.linkLabelFuncionarios.TabIndex = 99;
            this.linkLabelFuncionarios.TabStop = true;
            this.linkLabelFuncionarios.Text = "Funcionários";
            this.linkLabelFuncionarios.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelFuncionarios_LinkClicked);
            // 
            // lblSair
            // 
            this.lblSair.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(135)))), ((int)(((byte)(26)))));
            this.lblSair.AutoSize = true;
            this.lblSair.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSair.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblSair.LinkColor = System.Drawing.Color.Black;
            this.lblSair.Location = new System.Drawing.Point(4, 401);
            this.lblSair.Name = "lblSair";
            this.lblSair.Size = new System.Drawing.Size(37, 19);
            this.lblSair.TabIndex = 97;
            this.lblSair.TabStop = true;
            this.lblSair.Text = "Sair";
            this.lblSair.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSair_LinkClicked_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-19, -14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRelatorio2);
            this.Controls.Add(this.btnRelatorio1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Relatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatórios";
            this.Load += new System.EventHandler(this.Relatorio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnRelatorio1;
        private System.Windows.Forms.Button btnRelatorio2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabelEmpresasCargos;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabelGetFuncionario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabelFuncionarios;
        private System.Windows.Forms.LinkLabel lblSair;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}