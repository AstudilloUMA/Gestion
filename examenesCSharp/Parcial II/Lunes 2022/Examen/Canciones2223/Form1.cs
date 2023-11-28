using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canciones2223
{
    public partial class Form1 : Form
    {
        private HospitalEntities db;
        private Asistencia seleccionado;
        private DateTime now;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            seleccionado = null;
            now = tCalendar.SelectionStart;
            MostrarSeleccionado();
        }

        private void tSeleccionar_Click(object sender, EventArgs e)
        {
            now = tCalendar.SelectionStart;
            seleccionado = null;
            MostrarSeleccionado();
        }

        private void MostrarSeleccionado()
        {
            try
            {
                if (seleccionado == null)
                {
                    db = new HospitalEntities();
                    var asistencias = from g in db.Asistencia where g.FECHA.Equals(now) select new { ID = g.ID, CENTRO = g.CENTRO, MOTIVO = g.MOTIVO, FECHA = g.FECHA, NUMERO = g.NUMERO };
                    dataGridView1.DataSource = asistencias.ToArray();
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.ClearSelection();

                    tID.Text = "";
                    tNumero.Text = "";

                    lCentro.DataSource = db.Centro.ToArray();
                    lMotivo.DataSource = db.MOTIVO_CONSULTA.ToArray();
                    lCentro.SelectedItems.Clear();
                    lMotivo.SelectedItems.Clear();

                }
                else
                {
                    tID.Text = seleccionado.ID.ToString();
                    tNumero.Text = seleccionado.NUMERO.ToString();

                    tCalendar.SelectionStart = seleccionado.FECHA;
                    lCentro.SelectedItem = seleccionado.Centro1;
                    lMotivo.SelectedItem = seleccionado.MOTIVO_CONSULTA;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    seleccionado = db.Asistencia.First(x => x.ID == id);
                    MostrarSeleccionado();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void tInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                seleccionado = new Asistencia();
                seleccionado.Centro1 = (Centro) lCentro.SelectedItem;
                seleccionado.NUMERO = int.Parse(tNumero.Text);
                seleccionado.FECHA = tCalendar.SelectionStart;
                seleccionado.MOTIVO = getMotivo((MOTIVO_CONSULTA) lMotivo.SelectedItem);

                db.Asistencia.Add(seleccionado);
                db.SaveChanges();
                seleccionado = null;
                MostrarSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private int getMotivo(MOTIVO_CONSULTA mOTIVO_CONSULTA)
        {
            int res = 0;
            try
            {
                res = db.MOTIVO_CONSULTA.First(x => x.CODIGO == mOTIVO_CONSULTA.CODIGO).CODIGO;
            }
            catch
            {
                res = -1;
            }
            return res;
        }


        private void tModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (seleccionado.NUMERO != int.Parse(tNumero.Text.ToString()))
                    seleccionado.NUMERO = int.Parse(tNumero.Text.ToString());

                if (!seleccionado.FECHA.Equals(tCalendar.SelectionStart))
                    seleccionado.FECHA = tCalendar.SelectionStart;

                if (seleccionado.MOTIVO != getMotivo((MOTIVO_CONSULTA)lMotivo.SelectedItem))
                    seleccionado.MOTIVO = getMotivo((MOTIVO_CONSULTA)lMotivo.SelectedItem);

                if (seleccionado.Centro1 != lCentro.SelectedItem)
                    seleccionado.Centro1 = (Centro) lCentro.SelectedItem;

                
                
                db.SaveChanges();
                seleccionado = null;
                MostrarSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void tBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                db.Asistencia.Remove(seleccionado);
                db.SaveChanges();
                seleccionado = null;
                MostrarSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void tLimpiar_Click(object sender, EventArgs e)
        {
            seleccionado = null;
            MostrarSeleccionado();
        }

        private void tExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
