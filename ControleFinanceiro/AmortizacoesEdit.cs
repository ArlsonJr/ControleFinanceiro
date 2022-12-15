using Newtonsoft.Json.Linq;

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ControleFinanceiro
{
    public partial class AmortizacoesEdit : Form
    {
        private string idUsuario;
        private string arquivoJson;
        private DataGridView dgvAmortizacoes;
        private string idEmprt;
        public AmortizacoesEdit(string idUsuario, string arquivoJson, DataGridView dgvAmortizacoes, string idEmprt)
        {
            InitializeComponent();

            this.idUsuario = idUsuario;
            this.arquivoJson = arquivoJson;
            this.dgvAmortizacoes = dgvAmortizacoes;
            this.idEmprt = idEmprt;
        }

        private void AmortizacoesEdit_Load(object sender, EventArgs e)
        {
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.mtxtValor.TextLength == 0)
                {
                    MessageBox.Show("Informe o valor da amortização!", "BUGOU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.mtxtValor.Focus();
                    return;
                }

                var json = File.ReadAllText(arquivoJson);
                var jObject = JObject.Parse(json);
                JArray arrayUsuarios;

                if (jObject != null)
                {
                    arrayUsuarios = (JArray)jObject["usuarios"];

                    var usuario = arrayUsuarios.Where(x => x["id"].Value<string>() == this.idUsuario).FirstOrDefault();

                    var emprestimo = usuario["emprestimos"].Where(x => x["id_Emprt"].Value<string>() == this.idEmprt).FirstOrDefault();

                    int id = 0;

                    if (emprestimo != null)
                    {
                        string jsonEmprestimo = "[";

                        foreach (var drEmpt in usuario["emprestimos"])
                        {
                            if (drEmpt["id_Emprt"].ToString() == this.idEmprt)
                            {
                                jsonEmprestimo += "{\"id_Emprt\": \"" + drEmpt["id_Emprt"] + "\"," + "\"valor\": \"" + drEmpt["valor"] + "\"," + "\"data\": \"" + drEmpt["data"] + "\"," + "\"porcentagem\": \"" + drEmpt["porcentagem"] + "\"," + "\"juros\": \"" + drEmpt["juros"] + "\"," + "\"total\": \"" + drEmpt["total"] + "\"," + "\"amortizacao\": [";

                                var amortizacao = emprestimo["amortizacao"];

                                string jsonAmortiza = "";

                                if (amortizacao != null)
                                {
                                    foreach (var drAmort in amortizacao)
                                    {
                                        jsonAmortiza += "{\"id_amort\": \"" + drAmort["id_amort"] + "\"," + "\"valor\": \"" + drAmort["valor"] + "\"," + "\"data\": \"" + drAmort["data"] + "\"}";
                                    }
                                    var maxIdEmprt = amortizacao.Max(x => x["id_amort"].Value<string>());

                                    id = Convert.ToInt32(maxIdEmprt);
                                }

                                id++;

                                jsonAmortiza += "{\"id_amort\": \"" + id + "\"," + "\"valor\": \"" + this.mtxtValor.Text + "\"," + "\"data\": \"" + this.dtData.Text + "\"}";

                                jsonAmortiza += "]";

                                jsonEmprestimo += jsonAmortiza + "\n},";
                            }
                            else
                            {
                                var amortizacao = emprestimo["amortizacao"];

                                if (amortizacao != null)
                                {
                                    jsonEmprestimo += "{\"id_Emprt\": \"" + drEmpt["id_Emprt"] + "\"," + "\"valor\": \"" + drEmpt["valor"] + "\"," + "\"data\": \"" + drEmpt["data"] + "\"," + "\"porcentagem\": \"" + drEmpt["porcentagem"] + "\"," + "\"juros\": \"" + drEmpt["juros"] + "\"," + "\"total\": \"" + drEmpt["total"] + "\"," + "\"amortizacao\": [";
                                }
                                else
                                {
                                    jsonEmprestimo += "{\"id_Emprt\": \"" + drEmpt["id_Emprt"] + "\"," + "\"valor\": \"" + drEmpt["valor"] + "\"," + "\"data\": \"" + drEmpt["data"] + "\"," + "\"porcentagem\": \"" + drEmpt["porcentagem"] + "\"," + "\"juros\": \"" + drEmpt["juros"] + "\"," + "\"total\": \"" + drEmpt["total"] + "\"}";
                                }

                                if (amortizacao != null)
                                {
                                    string jsonAmortiza = "";

                                    foreach (var drAmort in amortizacao)
                                    {
                                        jsonAmortiza += "{\"id_amort\": \"" + drAmort["id_amort"] + "\"," + "\"valor\": \"" + drAmort["valor"] + "\"," + "\"data\": \"" + drAmort["data"] + "\"}";
                                    }
                                    var maxIdEmprt = amortizacao.Max(x => x["id_amort"].Value<string>());

                                    id = Convert.ToInt32(maxIdEmprt);

                                    jsonEmprestimo += jsonAmortiza;
                                }
                            }
                        }

                        jsonEmprestimo += "]";

                        var novoEmprestimo = JToken.Parse(jsonEmprestimo);

                        usuario["emprestimos"] = novoEmprestimo;

                        jObject["usuarios"] = arrayUsuarios;

                        string novoJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                        File.WriteAllText(arquivoJson, novoJsonResult);
                    }
                }

                DataTable table = new DataTable();

                table.Columns.Add("Id".ToString());
                table.Columns.Add("Data".ToString());
                table.Columns.Add("Valor".ToString());

                DataRow dr;

                if (jObject != null)
                {
                    arrayUsuarios = (JArray)jObject["usuarios"];

                    var item = arrayUsuarios.Where(x => x["id"].Value<string>() == this.idUsuario).FirstOrDefault();

                    var emprestimos = item["emprestimos"].Where(x => x["id_Emprt"].Value<string>() == this.idEmprt).FirstOrDefault();

                    if (emprestimos != null)
                    {
                        var armortizacao = emprestimos["amortizacao"];

                        foreach (var amorte in armortizacao)
                        {
                            dr = table.NewRow();

                            dr["Id"] = amorte["id_amort"].ToString();
                            dr["Data"] = amorte["data"].ToString();
                            dr["Valor"] = amorte["valor"].ToString();

                            table.Rows.Add(dr);
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

                this.dgvAmortizacoes.CurrentCell = this.dgvAmortizacoes.Rows[this.dgvAmortizacoes.Rows.Count - 1].Cells[0];

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar: " + ex.Message.ToString(), "BUGOU", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
