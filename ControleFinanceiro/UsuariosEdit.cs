using Newtonsoft.Json.Linq;

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ControleFinanceiro
{
    public partial class frmUsuariosEdit : Form
    {
        private string arquivoJson;
        private string opcao;
        private Usuarios frmUsuarios;
        private string idUsuario;
        public frmUsuariosEdit(string opcao, string arquivoJson, Usuarios frmUsuarios, string idUsuario = null)
        {
            InitializeComponent();

            this.arquivoJson = arquivoJson;
            this.opcao = opcao;
            this.frmUsuarios = frmUsuarios;
            this.idUsuario = idUsuario;
        }

        private void UsuariosEdit_Load(object sender, EventArgs e)
        {
            this.Text = this.opcao + " - " + this.Text;

            if (this.idUsuario != null)
            {
                var json = File.ReadAllText(arquivoJson);

                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray arrayUsuarios = (JArray)jObject["usuarios"];

                    foreach (var item in arrayUsuarios.Where(x => x["id"].Value<string>() == this.idUsuario))
                    {
                        this.txtIdUser.Text = item["id"].ToString();
                        this.txtNome.Text = item["nome"].ToString();
                        this.txtCPF.Text = item["cpf"] == null ? "" : item["cpf"].ToString();
                        this.txtRg.Text = item["rg"] == null ? "" : item["rg"].ToString();
                        this.txtEndereco.Text = item["endereco"] == null ? "" : item["endereco"].ToString();
                        this.txtTelefone.Text = item["telefone"] == null ? "" : item["telefone"].ToString();
                    }
                }
            }
            this.txtIdUser.Enabled = false;
            this.txtIdUser.ReadOnly = true;
            this.txtIdUser.TabStop = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (this.txtNome.TextLength == 0)
            {
                MessageBox.Show("Informe o nome do usuário!", "BUGOU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cpf = this.txtCPF.TextLength == 11 ? string.Format("###.###.###-##", this.txtCPF.Text) : this.txtCPF.Text;

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
