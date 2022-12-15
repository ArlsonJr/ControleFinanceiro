using Newtonsoft.Json.Linq;

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ControleFinanceiro
{
    public partial class UsuariosView : Form
    {
        private string arquivoJson;
        public UsuariosView()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            this.Atualizar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmUsuariosEdit frmUserEdit = new frmUsuariosEdit("Incluir", this.arquivoJson, this);

            frmUserEdit.Show();
        }

        public void Atualizar()
        {
            try
            {
                this.arquivoJson = Environment.CurrentDirectory;
                arquivoJson = arquivoJson.Replace("\\bin\\Debug\\netcoreapp3.1", "");
                arquivoJson = arquivoJson + "\\usuario.json";
                var json = File.ReadAllText(arquivoJson);

                if (json == "")
                    return;

                var jObject = JObject.Parse(json);

                DataTable table = new DataTable();
                table.Columns.Add("Id".ToString());
                table.Columns.Add("Nome".ToString());
                table.Columns.Add("CPF".ToString());
                table.Columns.Add("Telefone".ToString());
                table.Columns.Add("Qtd.".ToString());
                table.Columns.Add("Valor".ToString());

                DataRow dr;

                if (jObject != null)
                {
                    JArray arrayUsuarios = (JArray)jObject["usuarios"];

                    foreach (var item in arrayUsuarios)
                    {
                        dr = table.NewRow();

                        dr["Id"] = item["id"].ToString();
                        dr["Nome"] = item["nome"].ToString();
                        dr["CPF"] = item["cpf"] == null ? "" : item["cpf"].ToString();
                        dr["Telefone"] = item["telefone"] == null ? "" : item["telefone"].ToString();

                        decimal valorEmprestimos = 0;
                        int countEmprt = 0;

                        var emprestimos = item["emprestimos"];

                        if (emprestimos != null)
                        {
                            foreach (var drEmprestimos in emprestimos)
                            {
                                valorEmprestimos += Convert.ToDecimal(drEmprestimos["valor"].ToString());
                                countEmprt++;
                            }
                        }

                        dr["Valor"] = valorEmprestimos.ToString("N2");
                        dr["Qtd."] = countEmprt;
                        table.Rows.Add(dr);
                    }
                }

                this.dgvUsuarios.DataSource = null;
                this.dgvUsuarios.DataSource = table;

                this.dgvUsuarios.Columns[0].Width = 25;
                this.dgvUsuarios.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvUsuarios.Columns[1].Width = 250;
                this.dgvUsuarios.Columns[4].Width = 35;
                this.dgvUsuarios.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvUsuarios.Columns[5].Width = 60;
                this.dgvUsuarios.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                this.dgvUsuarios.CurrentCell = this.dgvUsuarios.Rows[this.dgvUsuarios.Rows.Count - 1].Cells[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "BUGOU", MessageBoxButtons.OK);
                throw;
            }
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Editar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.Editar();
        }
        public void Editar()
        {
            if (this.dgvUsuarios.CurrentRow.Cells[0].Value.ToString() != "")
            {
                frmUsuariosEdit frmUserEdit = new frmUsuariosEdit("Editar", this.arquivoJson, this, this.dgvUsuarios.CurrentRow.Cells[0].Value.ToString());

                frmUserEdit.Show();
            }
        }

        private void tsmiExcluir_Click(object sender, EventArgs e)
        {
            var json = File.ReadAllText(arquivoJson);

            try
            {
                var jObject = JObject.Parse(json);

                JArray arrayUsuarios = (JArray)jObject["usuarios"];

                var userId = this.dgvUsuarios.CurrentRow.Cells[0].Value.ToString();

                if (userId.Length > 0)
                {
                    var userDeletar = arrayUsuarios.FirstOrDefault(x => x["id"].Value<string>() == userId);
                    arrayUsuarios.Remove(userDeletar);
                    string saida = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(arquivoJson, saida);
                }
                else
                {
                    MessageBox.Show("O ID do usuário é inválido, tente novamente!", "BUGOU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Atualizar();
                }

                this.Atualizar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dgvUsuarios_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //seleciona a row com o botão direito do mouse
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || e.Button != MouseButtons.Right)
                return;

            this.dgvUsuarios.Rows[e.RowIndex].Selected = true;

            this.dgvUsuarios.CurrentCell = this.dgvUsuarios.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }
    }
}
