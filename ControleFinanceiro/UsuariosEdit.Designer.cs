
namespace ControleFinanceiro
{
    partial class frmUsuariosEdit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExcluirAmortizacao = new System.Windows.Forms.Button();
            this.btnIncluirAmortizacao = new System.Windows.Forms.Button();
            this.btnExcluirEmprestimo = new System.Windows.Forms.Button();
            this.btnIncluirEmprestimo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvAmortizacoes = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvEmprestimos = new System.Windows.Forms.DataGridView();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtRg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdUser = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmortizacoes)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprestimos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtIdUser);
            this.panel1.Controls.Add(this.btnExcluirAmortizacao);
            this.panel1.Controls.Add(this.btnIncluirAmortizacao);
            this.panel1.Controls.Add(this.btnExcluirEmprestimo);
            this.panel1.Controls.Add(this.btnIncluirEmprestimo);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtTelefone);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtEndereco);
            this.panel1.Controls.Add(this.txtRg);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.txtCPF);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 588);
            this.panel1.TabIndex = 0;
            // 
            // btnExcluirAmortizacao
            // 
            this.btnExcluirAmortizacao.Location = new System.Drawing.Point(519, 547);
            this.btnExcluirAmortizacao.Name = "btnExcluirAmortizacao";
            this.btnExcluirAmortizacao.Size = new System.Drawing.Size(72, 31);
            this.btnExcluirAmortizacao.TabIndex = 17;
            this.btnExcluirAmortizacao.Text = "Excluir";
            this.btnExcluirAmortizacao.UseVisualStyleBackColor = true;
            // 
            // btnIncluirAmortizacao
            // 
            this.btnIncluirAmortizacao.Location = new System.Drawing.Point(439, 547);
            this.btnIncluirAmortizacao.Name = "btnIncluirAmortizacao";
            this.btnIncluirAmortizacao.Size = new System.Drawing.Size(72, 31);
            this.btnIncluirAmortizacao.TabIndex = 16;
            this.btnIncluirAmortizacao.Text = "Incluir";
            this.btnIncluirAmortizacao.UseVisualStyleBackColor = true;
            // 
            // btnExcluirEmprestimo
            // 
            this.btnExcluirEmprestimo.Location = new System.Drawing.Point(87, 547);
            this.btnExcluirEmprestimo.Name = "btnExcluirEmprestimo";
            this.btnExcluirEmprestimo.Size = new System.Drawing.Size(72, 31);
            this.btnExcluirEmprestimo.TabIndex = 15;
            this.btnExcluirEmprestimo.Text = "Excluir";
            this.btnExcluirEmprestimo.UseVisualStyleBackColor = true;
            // 
            // btnIncluirEmprestimo
            // 
            this.btnIncluirEmprestimo.Location = new System.Drawing.Point(7, 547);
            this.btnIncluirEmprestimo.Name = "btnIncluirEmprestimo";
            this.btnIncluirEmprestimo.Size = new System.Drawing.Size(72, 31);
            this.btnIncluirEmprestimo.TabIndex = 14;
            this.btnIncluirEmprestimo.Text = "Incluir";
            this.btnIncluirEmprestimo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvAmortizacoes);
            this.groupBox2.Location = new System.Drawing.Point(439, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 312);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Amortizações";
            // 
            // dgvAmortizacoes
            // 
            this.dgvAmortizacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAmortizacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAmortizacoes.Location = new System.Drawing.Point(3, 19);
            this.dgvAmortizacoes.Name = "dgvAmortizacoes";
            this.dgvAmortizacoes.RowTemplate.Height = 25;
            this.dgvAmortizacoes.Size = new System.Drawing.Size(418, 290);
            this.dgvAmortizacoes.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvEmprestimos);
            this.groupBox1.Location = new System.Drawing.Point(7, 227);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 312);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Emprestimos";
            // 
            // dgvEmprestimos
            // 
            this.dgvEmprestimos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmprestimos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmprestimos.Location = new System.Drawing.Point(3, 19);
            this.dgvEmprestimos.Name = "dgvEmprestimos";
            this.dgvEmprestimos.RowTemplate.Height = 25;
            this.dgvEmprestimos.Size = new System.Drawing.Size(418, 290);
            this.dgvEmprestimos.TabIndex = 11;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(74, 180);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(100, 23);
            this.txtTelefone.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Telefone:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(74, 141);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(100, 23);
            this.txtEndereco.TabIndex = 8;
            // 
            // txtRg
            // 
            this.txtRg.Location = new System.Drawing.Point(74, 102);
            this.txtRg.Name = "txtRg";
            this.txtRg.Size = new System.Drawing.Size(225, 23);
            this.txtRg.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Rg:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Endereço:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(740, 24);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(123, 68);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(74, 63);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(100, 23);
            this.txtCPF.TabIndex = 3;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(101, 24);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(225, 23);
            this.txtNome.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "CPF:";
            // 
            // txtIdUser
            // 
            this.txtIdUser.Location = new System.Drawing.Point(74, 24);
            this.txtIdUser.Name = "txtIdUser";
            this.txtIdUser.Size = new System.Drawing.Size(27, 23);
            this.txtIdUser.TabIndex = 18;
            // 
            // frmUsuariosEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 588);
            this.Controls.Add(this.panel1);
            this.Name = "frmUsuariosEdit";
            this.Text = "Usuário";
            this.Load += new System.EventHandler(this.UsuariosEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmortizacoes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprestimos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtRg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvEmprestimos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExcluirEmprestimo;
        private System.Windows.Forms.Button btnIncluirEmprestimo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvAmortizacoes;
        private System.Windows.Forms.Button btnExcluirAmortizacao;
        private System.Windows.Forms.Button btnIncluirAmortizacao;
        private System.Windows.Forms.TextBox txtIdUser;
    }
}