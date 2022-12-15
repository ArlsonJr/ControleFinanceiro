using Newtonsoft.Json.Linq;

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ControleFinanceiro
{
    public partial class frmUsuariosEdit : Form
    {
        private string arquivoJson;
        private string opcao;
        private UsuariosView frmUsuarios;
        private string idUsuario;
        public frmUsuariosEdit(string opcao, string arquivoJson, UsuariosView frmUsuarios, string idUsuario = null)
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

                    var item = arrayUsuarios.Where(x => x["id"].Value<string>() == this.idUsuario).FirstOrDefault();

                    this.txtIdUser.Text = item["id"].ToString();
                    this.txtNome.Text = item["nome"].ToString();
                    this.txtCPF.Text = item["cpf"] == null ? "" : item["cpf"].ToString();
                    this.txtRg.Text = item["rg"] == null ? "" : item["rg"].ToString();
                    this.txtEndereco.Text = item["endereco"] == null ? "" : item["endereco"].ToString();
                    this.txtTelefone.Text = item["telefone"] == null ? "" : item["telefone"].ToString();

                    DataTable table = new DataTable();
                    table.Columns.Add("Id".ToString());
                    table.Columns.Add("Data".ToString());
                    table.Columns.Add("Valor".ToString());
                    table.Columns.Add("Porcentagem".ToString());
                    table.Columns.Add("Juros".ToString());
                    table.Columns.Add("Total".ToString());

                    var emprestimos = item["emprestimos"];

                    if (emprestimos != null)
                    {
                        DataRow dr;

                        foreach (var drEmprestimos in emprestimos)
                        {
                            dr = table.NewRow();

                            dr["Id"] = drEmprestimos["id_Emprt"].ToString();
                            dr["Data"] = drEmprestimos["data"].ToString();
                            dr["Valor"] = drEmprestimos["valor"].ToString();
                            dr["Porcentagem"] = drEmprestimos["porcentagem"].ToString() + "%";
                            dr["Juros"] = drEmprestimos["juros"].ToString();
                            dr["Total"] = drEmprestimos["total"].ToString();

                            table.Rows.Add(dr);
                        }
                    }

                    this.dgvEmprestimos.DataSource = null;
                    this.dgvEmprestimos.DataSource = table;

                    this.dgvEmprestimos.Columns[0].Width = 25;
                    this.dgvEmprestimos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dgvEmprestimos.Columns[1].Width = 75;
                    this.dgvEmprestimos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dgvEmprestimos.Columns[2].Width = 60;
                    this.dgvEmprestimos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvEmprestimos.Columns[3].Width = 80;
                    this.dgvEmprestimos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvEmprestimos.Columns[4].Width = 60;
                    this.dgvEmprestimos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvEmprestimos.Columns[5].Width = 60;
                    this.dgvEmprestimos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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

            try
            {
                var json = File.ReadAllText(arquivoJson);
                var jsonObj = JObject.Parse(json);
                var arrayUsuarios = jsonObj.GetValue("usuarios") as JArray;

                if (this.opcao == "Editar")
                {
                    if (this.txtIdUser.TextLength > 0)
                    {
                        foreach (var user in arrayUsuarios.Where(obj => obj["id"].Value<string>() == this.txtIdUser.Text))
                        {
                            user["nome"] = !string.IsNullOrEmpty(this.txtNome.Text) ? this.txtNome.Text : "";
                            user["cpf"] = !string.IsNullOrEmpty(this.txtCPF.Text) ? this.txtCPF.Text : "";
                            user["rg"] = !string.IsNullOrEmpty(this.txtRg.Text) ? this.txtRg.Text : "";
                            user["endereco"] = !string.IsNullOrEmpty(this.txtEndereco.Text) ? this.txtEndereco.Text : "";
                            user["telefone"] = !string.IsNullOrEmpty(this.txtTelefone.Text) ? this.txtTelefone.Text : "";
                        }

                        jsonObj["usuarios"] = arrayUsuarios;
                        string saida = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                        File.WriteAllText(arquivoJson, saida);
                    }
                    else
                    {
                        MessageBox.Show("O ID do usuário é inválido, tente novamente!", "BUGOU", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    JArray max = (JArray)jsonObj["usuarios"];

                    var item = max.Max(x => x["id"].Value<string>());

                    int id = Convert.ToInt32(item);

                    id++;

                    var newUser = "{\"id\": \"" + id + "\"," + "\"nome\": \"" + this.txtNome.Text + "\"," + "\"cpf\": \"" + this.txtCPF.Text + "\"," + "\"rg\": \"" + this.txtRg.Text + "\"," + "\"endereco\": \"" + this.txtEndereco.Text + "\"," + "\"telefone\": \"" + this.txtTelefone.Text + "\"}";

                    var novoUsuario = JObject.Parse(newUser);

                    arrayUsuarios.Add(novoUsuario);

                    jsonObj["usuarios"] = arrayUsuarios;

                    string novoJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(arquivoJson, novoJsonResult);
                }

                this.Close();

                this.frmUsuarios.Atualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar: " + ex.Message.ToString(), "BUGOU", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmprestimos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvEmprestimos.CurrentRow.Cells[0].Value.ToString() != "")
            {
                DataTable table = new DataTable();

                table.Columns.Add("Id".ToString());
                table.Columns.Add("Data".ToString());
                table.Columns.Add("Valor".ToString());

                var json = File.ReadAllText(arquivoJson);

                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray arrayUsuarios = (JArray)jObject["usuarios"];

                    var item = arrayUsuarios.Where(x => x["id"].Value<string>() == this.idUsuario).FirstOrDefault();

                    var emprestimos = item["emprestimos"].Where(x => x["id_Emprt"].Value<string>() == this.dgvEmprestimos.CurrentRow.Cells[0].Value.ToString()).FirstOrDefault();

                    if (emprestimos != null)
                    {
                        var amortizacao = emprestimos["amortizacao"];

                        if (amortizacao != null)
                        {
                            foreach (var amorte in amortizacao)
                            {
                                DataRow dr = table.NewRow();

                                dr["Id"] = amorte["id_amort"].ToString();
                                dr["Data"] = amorte["data"].ToString();
                                dr["Valor"] = amorte["valor"].ToString();

                                table.Rows.Add(dr);
                            }
                        }
                    }
                }

                this.dgvAmortizacoes.DataSource = null;
                this.dgvAmortizacoes.DataSource = table;

                this.dgvAmortizacoes.Columns[0].Width = 25;
                this.dgvAmortizacoes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvAmortizacoes.Columns[1].Width = 75;
                this.dgvAmortizacoes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvAmortizacoes.Columns[2].Width = 60;
                this.dgvAmortizacoes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnIncluirEmprestimo_Click(object sender, EventArgs e)
        {
            if (this.txtIdUser.TextLength == 0)
            {
                MessageBox.Show("Primeira salve o usuário para criar o id - Número identificador!", "BUGOU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (MessageBox.Show("Deseja incluir um emprestimo?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }

            EmprestimosEdit frm = new EmprestimosEdit(this.txtIdUser.Text, this.arquivoJson, this.dgvEmprestimos);

            frm.Show();
        }

        private void btnIncluirAmortizacao_Click(object sender, EventArgs e)
        {
            if (this.dgvEmprestimos.Rows.Count <= 0)
            {
                MessageBox.Show("Selecione um emprestimo ou inclua um emprestimo!", "BUGOU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Deseja incluir uma amortização?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }

            AmortizacoesEdit frm = new AmortizacoesEdit(this.txtIdUser.Text, this.arquivoJson, this.dgvAmortizacoes, this.dgvEmprestimos.CurrentRow.Cells[0].Value.ToString());

            frm.Show();
        }

        private void tsmiExcluirEmprestimo_Click(object sender, EventArgs e)
        {

        }

        private void tsmiExcluirAmortizacao_Click(object sender, EventArgs e)
        {

        }
    }
}
