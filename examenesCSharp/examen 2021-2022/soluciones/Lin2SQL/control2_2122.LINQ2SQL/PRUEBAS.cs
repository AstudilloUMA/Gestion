using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Linq;

namespace control2_2122_LINQ2SQL
{
    public partial class PRUEBAS : Form
    {
        private tPaciente paciente;
        private tPruebas seleccionado;

        public PRUEBAS()
        {
            InitializeComponent();
            this.paciente = null;
            this.seleccionado = null;
        }

        private void ajustaDataGridView(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Columns.Count; ++i)
            {
                if (i < dataGridView.Columns.Count - 1)
                    dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                else
                    dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dataGridView.ClearSelection();
        }
        private void PRUEBAS_Load(object sender, EventArgs e)
        {
            BDDataContext miBD = new BDDataContext();
            dataGridView1.DataSource = miBD.tPaciente;
            ajustaDataGridView(dataGridView1);
            var categorias = from c in miBD.tReferenciasGlucosa select c.categoria;
            foreach (string s in categorias) lCategoria.Items.Add(s);
            lCategoria.Items.Add("Valor Erroneo");
            MostrarPruebas();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count>0)
                {
                    BDDataContext miBD = new BDDataContext();
                    string nif = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
                    paciente = miBD.tPaciente.First(x => x.NIF.Equals(nif));
                    MostrarPruebas();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void MostrarPruebas()
        {
            BDDataContext miBD = new BDDataContext();
            dataGridView2.DataSource = null;
            if (paciente != null)
            {
                dataGridView2.DataSource = from p in miBD.tPruebas where p.NIF.Equals(paciente.NIF) select p;
                seleccionado = null;
                ajustaDataGridView(dataGridView2);
            }
            MostrarSeleccionado();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    BDDataContext miBD = new BDDataContext();
                    int id = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
                    seleccionado = miBD.tPruebas.First(x => x.ID == id);
                    MostrarSeleccionado();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }
        private void MostrarSeleccionado()
        {
            if (seleccionado == null)
            {
                dateTimePicker1.Value = DateTime.Now;
                lCategoria.SelectedItem = null;
                tValor.Text = "";
            }
            else
            {
                dateTimePicker1.Value = seleccionado.fecha_hora;
                lCategoria.SelectedItem = getCategoria((float)seleccionado.valor_glucosa);
                tValor.Text = seleccionado.valor_glucosa.ToString();
            }
        }

        private string getCategoria(float valor)
        {
            string res = "Valor Erroneo";
            try
            {
                BDDataContext miBD = new BDDataContext();
                var c = from val in miBD.tReferenciasGlucosa
                        where val.desde <= valor && valor < val.hasta
                        select val;
                res = c.First().categoria;
            }
            catch
            {
                res = "Valor Erroneo";
            }
            return res;
        }
        private void bIns_Click(object sender, EventArgs e)
        {
            try
            {
                BDDataContext miBD = new BDDataContext();
                seleccionado = new tPruebas();
                seleccionado.NIF = paciente.NIF;
                seleccionado.fecha_hora = dateTimePicker1.Value;
                seleccionado.valor_glucosa = float.Parse(tValor.Text);
                miBD.tPruebas.InsertOnSubmit(seleccionado);
                miBD.SubmitChanges();
                seleccionado = null;
                MostrarPruebas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

        }

        private void bUpd_Click(object sender, EventArgs e)
        {
            try
            {
                BDDataContext miBD = new BDDataContext();
                seleccionado = miBD.tPruebas.First(x => x.ID == seleccionado.ID);
                if (!seleccionado.fecha_hora.Equals(dateTimePicker1.Value))
                    seleccionado.fecha_hora = dateTimePicker1.Value;
                    
                float val = float.Parse(tValor.Text);
                if (seleccionado.valor_glucosa != val) seleccionado.valor_glucosa = val;
                miBD.SubmitChanges();
                seleccionado = null;
                MostrarPruebas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

        }

        private void bDel_Click(object sender, EventArgs e)
        {
            try
            {
                BDDataContext miBD = new BDDataContext();
                seleccionado = miBD.tPruebas.First(x => x.ID == seleccionado.ID);
                miBD.tPruebas.DeleteOnSubmit(seleccionado);
                miBD.SubmitChanges();
                seleccionado = null;
                MostrarPruebas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

        }

        private void bClear_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            paciente = null;
            seleccionado = null;
            MostrarPruebas();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (seleccionado != null)
            {
                lCategoria.SelectedItem = getCategoria((float)seleccionado.valor_glucosa);
            }
        }
    }
}
