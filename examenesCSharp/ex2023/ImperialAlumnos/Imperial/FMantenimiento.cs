using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imperial
{
    public partial class FMantenimiento : Form
    {
        // TODO: COMPLETAR
        // Implementar toda la gestión de eventos necesaria para el formulario.
        private Nave seleccionada2;
        private TipoNave seleccionada;
        private imperialDataContext db;

        public FMantenimiento()
        {
            InitializeComponent();
            seleccionada = null;
            seleccionada2 = null;
            db = new imperialDataContext();
        }

        private void FMantenimiento_Load(object sender, EventArgs e)
        {
            lbTipoNave.DataSource = db.TipoNave;
            lbTipoNave.ClearSelected();
            lbTipoNaveMostrado.DataSource = db.TipoNave;
            lbTipoNaveMostrado.ClearSelected();
            dgvNave.DataSource = null;
        }

        private void cargarDatos()
        {
            
                dgvNave.DataSource = from nave in db.Nave where seleccionada.Codigo == nave.TipoNaveCodigo select new { nave.Nombre, nave.Capitan, nave.PlanetaFabricacion, nave.TipoNave };
                dgvNave.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvNave.ClearSelection();
        
        }

        private void mostrarSeleccionada()
        {
            if(seleccionada2 != null)
            {
                tbCapitan.Text = (string)seleccionada2.Capitan;
                tbNombre.Text = (string)seleccionada2.Nombre;
                tbPlanetaFabricacion.Text = (string)seleccionada2.PlanetaFabricacion;
                lbTipoNave.SetSelected(lbTipoNave.SelectedIndex, true);
            }
            else
            {
                tbNombre.Text = "";
                tbCapitan.Text = "";
                tbPlanetaFabricacion.Text = "";
                lbTipoNaveMostrado.ClearSelected();
            }
        }

        private void dgvNave_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dgvNave.SelectedRows.Count > 0)
                {
                    string id = (string)dgvNave.SelectedRows[0].Cells[0].Value;
                    seleccionada2 = db.Nave.First(x => x.Nombre.Equals(id));

                    mostrarSeleccionada();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void lbTipoNave_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for(int i = 0; i < lbTipoNave.Items.Count; i++)
                {
                    if(lbTipoNave.GetSelected(i))
                    {
                        seleccionada = (TipoNave)lbTipoNave.Items[i];
              
                    }
                }
                cargarDatos();
                mostrarSeleccionada();
            }catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            
        }

        private void bInserta_Click(object sender, EventArgs e)
        {
            try
            {
                seleccionada2 = new Nave();
                seleccionada2.Nombre = tbNombre.Text;
                seleccionada2.Capitan = tbCapitan.Text;
                seleccionada2.PlanetaFabricacion = tbPlanetaFabricacion.Text;

                seleccionada2.TipoNave = db.TipoNave.First(x => x.Denominacion.Equals(lbTipoNaveMostrado.Items[lbTipoNaveMostrado.SelectedIndex]));
                seleccionada2.TipoNaveCodigo = db.TipoNave.First(x => x.Denominacion.Equals(lbTipoNaveMostrado.Items[lbTipoNaveMostrado.SelectedIndex])).Codigo;

                db.Nave.InsertOnSubmit(seleccionada2);
                db.SubmitChanges();

                seleccionada2 = null;
                cargarDatos();
                mostrarSeleccionada();
            }catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void bModifica_Click(object sender, EventArgs e)
        {
            try
            {
                if (!tbNombre.Text.Equals(seleccionada2.Nombre)) seleccionada2.Nombre = tbNombre.Text;
                if (!tbCapitan.Text.Equals(seleccionada2.Capitan)) seleccionada2.Capitan = tbCapitan.Text;
                if (!tbPlanetaFabricacion.Text.Equals(seleccionada2.PlanetaFabricacion)) seleccionada2.PlanetaFabricacion = tbPlanetaFabricacion.Text;

                db.SubmitChanges();
                cargarDatos();
                seleccionada2 = null;
                mostrarSeleccionada();
                dgvNave.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void bBorra_Click(object sender, EventArgs e)
        {
           try
           {
               seleccionada2 = db.Nave.First(x=>x.Nombre.Equals(seleccionada2.Nombre));
               db.Nave.DeleteOnSubmit(seleccionada2);
               db.SubmitChanges();

               seleccionada2 = null;
               cargarDatos();
               mostrarSeleccionada();

               dgvNave.ClearSelection();
           }catch(Exception ex)
           {
               MessageBox.Show("ERROR: " + ex.Message);
           }
        }

        private void bLimpia_Click(object sender, EventArgs e)
        {
            seleccionada = null;
            seleccionada2 = null;
            mostrarSeleccionada();
        } 
    }
}
