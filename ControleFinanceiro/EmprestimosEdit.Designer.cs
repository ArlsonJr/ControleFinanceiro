
namespace ControleFinanceiro
{
    partial class EmprestimosEdit
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
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.mtxtTotal = new System.Windows.Forms.MaskedTextBox();
            this.mtxtJuros = new System.Windows.Forms.MaskedTextBox();
            this.mtxtPorcen = new System.Windows.Forms.MaskedTextBox();
            this.mtxtValor = new System.Windows.Forms.MaskedTextBox();
            this.dtData = new System.Windows.Forms.DateTimePicker();
            this.txtIdEmprestimo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.mtxtTotal);
            this.panel1.Controls.Add(this.mtxtJuros);
            this.panel1.Controls.Add(this.mtxtPorcen);
            this.panel1.Controls.Add(this.mtxtValor);
            this.panel1.Controls.Add(this.dtData);
            this.panel1.Controls.Add(this.txtIdEmprestimo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 210);
            this.panel1.TabIndex = 0;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(227, 179);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "%";
            // 
            // mtxtTotal
            // 
            this.mtxtTotal.Location = new System.Drawing.Point(99, 169);
            this.mtxtTotal.Name = "mtxtTotal";
            this.mtxtTotal.Size = new System.Drawing.Size(69, 23);
            this.mtxtTotal.TabIndex = 11;
            this.mtxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mtxtJuros
            // 
            this.mtxtJuros.Location = new System.Drawing.Point(99, 138);
            this.mtxtJuros.Name = "mtxtJuros";
            this.mtxtJuros.Size = new System.Drawing.Size(69, 23);
            this.mtxtJuros.TabIndex = 10;
            this.mtxtJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mtxtPorcen
            // 
            this.mtxtPorcen.Location = new System.Drawing.Point(99, 107);
            this.mtxtPorcen.Name = "mtxtPorcen";
            this.mtxtPorcen.Size = new System.Drawing.Size(69, 23);
            this.mtxtPorcen.TabIndex = 9;
            this.mtxtPorcen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtPorcen.Leave += new System.EventHandler(this.mtxtPorcen_Leave);
            // 
            // mtxtValor
            // 
            this.mtxtValor.Location = new System.Drawing.Point(99, 76);
            this.mtxtValor.Name = "mtxtValor";
            this.mtxtValor.Size = new System.Drawing.Size(69, 23);
            this.mtxtValor.TabIndex = 8;
            this.mtxtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtData
            // 
            this.dtData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtData.Location = new System.Drawing.Point(99, 45);
            this.dtData.Name = "dtData";
            this.dtData.Size = new System.Drawing.Size(95, 23);
            this.dtData.TabIndex = 7;
            // 
            // txtIdEmprestimo
            // 
            this.txtIdEmprestimo.Enabled = false;
            this.txtIdEmprestimo.Location = new System.Drawing.Point(99, 14);
            this.txtIdEmprestimo.Name = "txtIdEmprestimo";
            this.txtIdEmprestimo.ReadOnly = true;
            this.txtIdEmprestimo.Size = new System.Drawing.Size(25, 23);
            this.txtIdEmprestimo.TabIndex = 6;
            this.txtIdEmprestimo.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Total:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Juros:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Porcentagem:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Valor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            // 
            // EmprestimosEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 210);
            this.Controls.Add(this.panel1);
            this.Name = "EmprestimosEdit";
            this.Text = "Emprestimo";
            this.Load += new System.EventHandler(this.EmprestimosEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mtxtTotal;
        private System.Windows.Forms.MaskedTextBox mtxtJuros;
        private System.Windows.Forms.MaskedTextBox mtxtPorcen;
        private System.Windows.Forms.MaskedTextBox mtxtValor;
        private System.Windows.Forms.DateTimePicker dtData;
        private System.Windows.Forms.TextBox txtIdEmprestimo;
        private System.Windows.Forms.Button btnSalvar;
    }
}