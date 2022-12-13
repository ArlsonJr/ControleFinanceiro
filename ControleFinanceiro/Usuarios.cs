using Newtonsoft.Json.Linq;

using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ControleFinanceiro
{
    public partial class Usuarios : Form
    {
        private string arquivoJson;
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            this.Atualizar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmUsuariosEdit frmUserEdit = new frmUsuariosEdit( "Incluir", this.arquivoJson, this);

            frmUserEdit.Show();
        }

        public void Atualizar()
        {
            try
            {
                this.arquivoJson = Environment.CurrentDirectory;
                arquivoJson = arquivoJson.Replace("\\bin\\Debug\\netcoreapp3.1", "");
                arquivoJson = arquivoJson + "\\Dados\\usuario.json";
                var json = File.ReadAllText(arquivoJson);

                var jObject = JObject.Parse(json);

                DataTable table = new DataTable();
                table.Columns.Add("Nome".ToString());
                table.Columns.Add("CPF".ToString());
                DataRow dr;

                if (jObject != null)
                {
                    JArray arrayUsuarios = (JArray)jObject["usuarios"];

                    foreach (var item in arrayUsuarios)
                    {
                        dr = table.NewRow();

                        dr["Nome"] = item["nome"].ToString();
                        dr["CPF"] = item["cpf"].ToString();

                        table.Rows.Add(dr);
                    }
                }

                this.dgvUsuarios.DataSource = null;
                this.dgvUsuarios.DataSource = table;

                this.dgvUsuarios.Columns[0].Width = 250;

                this.dgvUsuarios.CurrentCell = this.dgvUsuarios.Rows[this.dgvUsuarios.Rows.Count - 1].Cells[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "BUGOU", MessageBoxButtons.OK);
                throw;
            }
        }
    }
}
