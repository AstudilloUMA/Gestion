using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace control2_2122
{
    public partial class PRUEBAS : Form
    {
        private Paciente paciente;
        private Prueba seleccionado;

        public PRUEBAS()
        {
            InitializeComponent();
            this.paciente = null;
            this.seleccionado = null;
        }        
        private void PRUEBAS_Load(object sender, EventArgs e)
        {            
            this.tPacienteTableAdapter.Fill(this.control2_2122DataSet.tPaciente);
            foreach (string s in ReferenciasGlucosa.ListaValoresReferenciasGlucosa())
                lCategoria.Items.Add(s);
            MostrarPruebas();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count>0)
                {
                    string nif = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
                    paciente = new Paciente(nif);
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
            dataGridView2.Rows.Clear();
            if (paciente != null)
            {
                foreach(Prueba p in Prueba.ListaPruebas(paciente))
                {
                    dataGridView2.Rows.Add(p.IDPrueba,p.PacientePrueba,p.FechaPrueba,p.ValorPrueba,p.CategoriaPrueba);
                }
                seleccionado = null;                
            }
            MostrarSeleccionado();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    int id = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
                    seleccionado = new Prueba(id);
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
                dateTimePicker1.Value = seleccionado.FechaPrueba;
                lCategoria.SelectedItem = seleccionado.CategoriaPrueba;
                tValor.Text = seleccionado.ValorPrueba.ToString();
            }
        }
        private void bIns_Click(object sender, EventArgs e)
        {
            try
            {
                seleccionado = new Prueba(paciente, dateTimePicker1.Value, double.Parse(tValor.Text));
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
                if (!seleccionado.FechaPrueba.Equals(dateTimePicker1.Value))
                    seleccionado.FechaPrueba = dateTimePicker1.Value;
                double val = double.Parse(tValor.Text);
                if (seleccionado.ValorPrueba != val) seleccionado.ValorPrueba = val;
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
                seleccionado.BorraPrueba();
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
            if (seleccionado == null)
            {
                lCategoria.SelectedItem = null;
            }
            else
            {
                lCategoria.SelectedItem = seleccionado.CategoriaPrueba;
            }
        }
    }
}
