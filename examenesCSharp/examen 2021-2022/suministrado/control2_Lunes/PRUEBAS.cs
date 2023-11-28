using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Linq;

namespace control2_Lunes
{
    public partial class PRUEBAS : Form
    {
        private Lunes_tPaciente seleccionada;
        private Lunes_tPruebas seleccionada2;
        private DataClasses1DataContext db;

        public PRUEBAS()
        {
            InitializeComponent();
            seleccionada = null;
            seleccionada2 = null;
            db = new DataClasses1DataContext();
        }

        private void PRUEBAS_Load(object sender, EventArgs e)
        {
            lCategoria.DataSource = db.Lunes_tReferenciasGlucosa;
            lCategoria.ClearSelected();

            dataGridView1.DataSource = db.Lunes_tPaciente;
            dataGridView1.ClearSelection();

            mostrarSeleccionado();
        }

        private void bIns_Click(object sender, EventArgs e)
        {

        }

        private void bUpd_Click(object sender, EventArgs e)
        {

        }

        private void bDel_Click(object sender, EventArgs e)
        {

        }

        private void bClear_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string id = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
                    seleccionada = db.Lunes_tPaciente.First(x => x.NIF.Equals(id));

                    mostrarSeleccionado();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR holaaa: " + ex.Message);
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    int id = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
                    seleccionada2 = db.Lunes_tPruebas.First(x => x.ID == id);
                    mostrarSeleccionado2();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void cargarDatos()
        {
            dataGridView2.DataSource = from pr in db.Lunes_tPruebas where seleccionada.NIF.Equals(pr.NIF) select pr;
        }

        private void mostrarSeleccionado()
        {
            dataGridView2.DataSource = null;
            if (seleccionada != null)
            {
                cargarDatos();
                seleccionada = null;
                mostrarSeleccionado2();
            }
        }
        private void mostrarSeleccionado2()
        {
            if (seleccionada2 != null)
            {
                tValor.Text = seleccionada2.valor_glucosa.ToString();
                dateTimePicker1.Value = seleccionada2.fecha_hora;
                Lunes_tReferenciasGlucosa categoria = db.Lunes_tReferenciasGlucosa.First(x => (x.desde<seleccionada2.valor_glucosa) && (x.hasta>seleccionada2.valor_glucosa));
                Console.WriteLine(categoria.categoria);
                for (int i = 0; i < lCategoria.Items.Count; i++)
                {
                    if (categoria.categoria.Equals(lCategoria.Items[i].ToString()))
                    {
                        lCategoria.SetSelected(i, true);
                        break;
                    }
                }
            }
            else
            {
                tValor.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                lCategoria.ClearSelected();
            }
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
