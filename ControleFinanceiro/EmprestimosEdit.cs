using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControleFinanceiro
{
    public partial class EmprestimosEdit : Form
    {
        private string idUsuario;
        private string arquivoJson;
        private DataGridView dgvEmprestimos;
        public EmprestimosEdit(string idUsuario, string arquivoJson, DataGridView dgvEmprestimos)
        {
            InitializeComponent();

            this.idUsuario = idUsuario;
            this.arquivoJson = arquivoJson;
            this.dgvEmprestimos = dgvEmprestimos;
        }
        private void EmprestimosEdit_Load(object sender, EventArgs e)
        {
            this.dtData.Focus();
        }

        private void mtxtPorcen_Leave(object sender, EventArgs e)
        {
            if (this.mtxtValor.TextLength > 0)
            {
                decimal valor = Convert.ToDecimal(this.mtxtValor.Text);
                decimal perce = Convert.ToDecimal(this.mtxtPorcen.Text);

                decimal juros = perce * (valor / 100);

                this.mtxtJuros.Text = juros.ToString("N2");
                this.mtxtTotal.Text = (valor + juros).ToString("N2");

                this.btnSalvar.Focus();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (this.mtxtValor.TextLength == 0)
            {
                MessageBox.Show("Informe o valor do emprestimo!", "BUGOU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.mtxtValor.Focus();
                return;
            }

            if (this.mtxtPorcen.TextLength == 0)
            {
                MessageBox.Show("Informa a porcentagem!", "BUGOU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.mtxtPorcen.Focus();
                return;
            }

            if (this.mtxtJuros.TextLength == 0)
            {
                MessageBox.Show("Informe o Juros!", "BUGOU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.mtxtJuros.Focus();
                return;
            }

            if (this.mtxtTotal.TextLength == 0)
            {
                MessageBox.Show("Informa o valor total do emprestimo!", "BUGOU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.mtxtTotal.Focus();
                return;
            }

            DataTable table = new DataTable();
            table.Columns.Add("Id".ToString());
            table.Columns.Add("Data".ToString());
            table.Columns.Add("Valor".ToString());
            table.Columns.Add("Porcentagem".ToString());
            table.Columns.Add("Juros".ToString());
            table.Columns.Add("Total".ToString());

            var json = File.ReadAllText(arquivoJson);

            var jObject = JObject.Parse(json);

            JArray arrayUsuarios = (JArray)jObject["usuarios"];

            var item = arrayUsuarios.Where(x => x["id"].Value<string>() == this.idUsuario).FirstOrDefault();

            var emprestimos = item["emprestimos"];
            DataRow dr;
            if (emprestimos != null)
            {


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

            dr = table.NewRow();

            dr["Id"] = "x";
            dr["Data"] = this.dtData.Text;
            dr["Valor"] = this.mtxtValor.Text;
            dr["Porcentagem"] = this.mtxtPorcen.Text + "%";
            dr["Juros"] = this.mtxtJuros.Text;
            dr["Total"] = this.mtxtTotal.Text;

            table.Rows.Add(dr);

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

            this.dgvEmprestimos.CurrentCell = this.dgvEmprestimos.Rows[this.dgvEmprestimos.Rows.Count - 1].Cells[0];

            this.Close();

            //var json = File.ReadAllText(arquivoJson);

            //var jObject = JObject.Parse(json);

            //if (jObject != null)
            //{
            //    JArray arrayUsuarios = (JArray)jObject["usuarios"];

            //    var item = arrayUsuarios.Where(x => x["id"].Value<string>() == this.idUsuario).FirstOrDefault();

            //    var emprestimos = item["emprestimos"];

            //    int id = 0;
            //    if (emprestimos != null)
            //    {
            //        var maxIdEmprt = emprestimos.Max(x => x["id_Emprt"].Value<string>());
            //        id = Convert.ToInt32(maxIdEmprt);
            //    }

            //    id++;

            //    string jsonEmprestimo = "[";

            //    foreach (var dr in emprestimos)
            //    {
            //        jsonEmprestimo += "{\"id_Emprt\": \"" + dr["id_Emprt"] + "\"," + "\"valor\": \"" + dr["valor"] + "\"," + "\"data\": \"" + dr["data"] + "\"," + "\"porcentagem\": \"" + dr["porcentagem"] + "\"," + "\"juros\": \"" + dr["juros"] + "\"," + "\"total\": \"" + dr["total"] + "\"}, ";
            //    }

            //    jsonEmprestimo += "\n{\"id_Emprt\": \"" + id + "\"," + "\"valor\": \"" + this.mtxtValor.Text + "\"," + "\"data\": \"" + this.dtData.Text + "\"," + "\"porcentagem\": \"" + this.mtxtPorcen.Text + "\"," + "\"juros\": \"" + this.mtxtJuros.Text + "\"," + "\"total\": \"" + this.mtxtTotal.Text + "\"}";

            //    jsonEmprestimo += "]";

            //    var novoEmprestimo = JToken.Parse(jsonEmprestimo);

            //    item["emprestimos"] = novoEmprestimo;

            //    jObject["usuarios"] = arrayUsuarios;

            //    string novoJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
            //    File.WriteAllText(arquivoJson, novoJsonResult);
            //}
        }
    }
}
