using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using static System.Net.Mime.MediaTypeNames;

namespace ControleFinanceiro
{
    public partial class frmUsuariosEdit : Form
    {
        private string arquivoJson;
        private string opcao;
        private Usuarios frmUsuarios;
        public frmUsuariosEdit(string opcao, string arquivoJson, Usuarios frmUsuarios)
        {
            InitializeComponent();

            this.arquivoJson = arquivoJson;
            this.opcao = opcao;
            this.frmUsuarios = frmUsuarios;
        }

        private void UsuariosEdit_Load(object sender, EventArgs e)
        {
            this.Text = this.opcao + " - " + this.Text;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (this.txtNome.TextLength == 0)
            {
                MessageBox.Show("Informe o nome do usuário!", "BUGOU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newUser = "{\"nome\": \"" + this.txtNome.Text + "\"," + "\"cpf\": \"" + this.txtCPF.Text + "\"}"; 

            try
            {
                var json = File.ReadAllText(this.arquivoJson);
                var jsonObj = JObject.Parse(json);

                var arrayUsuarios = jsonObj.GetValue("usuarios") as JArray;

                var novoUsuario = JObject.Parse(newUser);

                arrayUsuarios.Add(novoUsuario);

                jsonObj["usuarios"] = arrayUsuarios;

                string novoJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(arquivoJson, novoJsonResult);

                this.Close();

                this.frmUsuarios.Atualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar: " + ex.Message.ToString(), "BUGOU", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
